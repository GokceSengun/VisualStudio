using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Kayıt_Registry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //kayıtta alınan bilgileri sql servera kaydeder.
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            var name = txtStudentName.Text;
            var surname = txtStudentSurname.Text;
            var parentname = txtParentName.Text;

            int age = 0;
            long phoneTmp=0 ;
            if (!Int32.TryParse(txtAge.Text, out age))
            {
                Informer.Inform("Yaş alanı numerik olmalı.", Scop.UserControls.Informer.InformTypes.Warning);
                return;
            }

            if (txtPhone.Text != "" && !Int64.TryParse(txtPhone.Text, out phoneTmp))
            {
                Informer.Inform("Telefon numarası alanı numerik olmalı.", Scop.UserControls.Informer.InformTypes.Warning);
                return;
            }

            long? phone = phoneTmp;
            if (phone == 0)
                phone = null;

            var mail = txtEmail.Text;
            try
            {
                MailAddress m = new MailAddress(mail);
            }
            catch (FormatException)
            {
                Informer.Inform("Mail adresi düzgün formatta değil.", Scop.UserControls.Informer.InformTypes.Warning);
                return;
            }
            var address = txtAddress.Text;
            var paymentType = txtPaymentType.SelectedValue;

            var amount = Convert.ToInt32(txtAmount.Text);


            if (name == "" || surname == "" || parentname == "")
            {
                Informer.Inform("İsim, Süre ve İçerik alanları boş geçilemez.", Scop.UserControls.Informer.InformTypes.Warning);
                return;
            }

            //yeni bir öğrenci kaydı oluşturan method
            Students.AddNew(name, surname, parentname, age, phone, mail, address, paymentType, amount);
        }
        catch (Exception ex)
        {
            Informer.Inform(ex);
            return;
        }

        clearForm(); 
        Informer.Inform("Kayıt oluşturuldu.", Scop.UserControls.Informer.InformTypes.Success);
    }

    //sayfa yenilendikten sonra textboxları boşaltır
    private void clearForm()
    {
        txtStudentName.Text = "";
        txtStudentSurname.Text = "";
        txtParentName.Text = "";
        txtAge.Text = "";
        txtPhone.Text = "";
        txtEmail.Text = "";
        txtAddress.Text = "";
        txtPaymentType.Text = "";
        txtAmount.Text = "";

    }
}
