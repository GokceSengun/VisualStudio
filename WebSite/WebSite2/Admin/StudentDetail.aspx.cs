using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentDetail : System.Web.UI.Page
{
    private Students student;
    protected void Page_Load(object sender, EventArgs e)
    {
        getStudent(); //öğrencileri getirir
    }

    private void getStudent()
    {
        //öğrenci id sine göre öğrencileri alır
        try
        {
            int Id = 0;
            if (string.IsNullOrEmpty(Request["Id"]) || !Int32.TryParse(Request["Id"], out Id))
                Response.Redirect(Urls.Admin.MainPage);

            student = Students.GetById(Id);

            //sayfa yenilenmediyse
            if (!IsPostBack)
                fillFields();


        }
        catch (Exception ex)
        {
            Informer.Inform("Hata oluştu.", Scop.UserControls.Informer.InformTypes.Error, ex);
        }
    }

    private void fillFields()
    {
        //sayfadaki textbox alanlarını sqldeki verilere göre doldurur
        txtId.Text = student.Id.ToString();
        txtStudentName.Text = student.Name;
        txtStudentSurname.Text = student.Surname;
        txtParentName.Text = student.ParentName;
        txtAge.Text = student.Age.ToString();
        txtPhone.Text = student.Phone.ToString();
        txtEmail.Text = student.Mail;
        txtAddress.Text = student.Adress;
        txtPaymentType.SelectedValue = (Convert.ToInt32(student.PaymentType)).ToString();
        txtAmount.Text = student.Amount.ToString();

        fillActivities();//öğrenciye ait etkinlikleri droplist şeklinde getirir
    }

    private void fillActivities()
    {
        //öğrenciye ait sql deki AssignedActivites tablosundan öğrenciye atanan etkinlikleri getirir etkinlik id sine göre
        var activities = AssignedActivities.GetByStudentId(student.Id);
        drpActivities.DataSource = activities;
        drpActivities.DataValueField = "ActivityId";
        drpActivities.DataTextField = "ActivityName";
        drpActivities.DataBind();
    }

    protected void btnDeleteActivity_Click(object sender, EventArgs e)
    {
        try
        {
            var activity = Convert.ToInt32(drpActivities.SelectedValue);
            //öğrenci idsine göre o öğrenciye ait atanan etkinliği siler
            AssignedActivities.Delete(activity, student.Id);

            fillActivities();
            Informer.Inform("Etkinlik Silindi.", Scop.UserControls.Informer.InformTypes.Success);
        }
        catch (Exception ex)
        {
            Informer.Inform("Hata oluştu!", Scop.UserControls.Informer.InformTypes.Error, ex);
        }
    }

    //seçili öğrencinin bilgilerini görüntülemek için çağırılan method
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            var name = txtStudentName.Text;
            var surname = txtStudentSurname.Text;
            var parentname = txtParentName.Text;

            int age = 0;
            long phoneTmp = 0;
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

            //seçili öğrencinin bilgilerini günceller
            Students.Update(Convert.ToInt32(txtId.Text), name, surname, parentname, age, phone, mail, address, paymentType, amount);
        }
        catch (Exception ex)
        {
            Informer.Inform("Hata oluştu.", Scop.UserControls.Informer.InformTypes.Error, ex);
            return;
        }

        Informer.Inform("Kayıt güncellendi.", Scop.UserControls.Informer.InformTypes.Success);
    }


}
