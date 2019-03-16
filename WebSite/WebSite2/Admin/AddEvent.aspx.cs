using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddEvent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //sayfa yenilenmediyse
        if (!IsPostBack)
            fillDropLists(); //egitmen ve sınıf bilgilerini droplist olarak çağırır
    }

    private void fillDropLists()
    {

        //sql sistemindeki etkinliklerin yapılacağı sınıfları getirir
        var classes = Classes.GetAll();

        drpClasses.DataSource = classes;
        drpClasses.DataValueField = "Id";
        drpClasses.DataTextField = "Name";
        drpClasses.DataBind();

        //sql sistemindeki eğitmenleri getirir
        var educaters = Users.GetAll().Where(q => q.Role == Users.UserRoles.Teacher);

        drpEducater.DataSource = educaters;
        drpEducater.DataValueField = "Id";
        drpEducater.DataTextField = "Username";
        drpEducater.DataBind();

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        //sql tablosundaki(activities) verileri çeker
        try
        {
            var name = txtEventName.Text;
            var duration = txtEventDuration.Text;


            var age = txtEventClassifyByAge.Text;
            var stage = txtEventClassifyByStage.Text;

            var classes = Convert.ToInt32(drpClasses.SelectedValue);
            var educater = Convert.ToInt32(drpEducater.SelectedValue);

            var content = txtEventContent.Text;


            if (name == "" || duration == "" || content == "")
            {
                Informer.Inform("İsim, Süre ve İçerik alanları boş geçilemez.", Scop.UserControls.Informer.InformTypes.Warning);
                return;
            }

            Activities.AddNew(name, duration, content, age, stage, classes, educater);
        }
        catch (Exception ex)
        {
            Informer.Inform("Hata oluştu.", Scop.UserControls.Informer.InformTypes.Error, ex);
            return;
        }

        clearForm();
        Informer.Inform("Etkinlik oluşturuldu.", Scop.UserControls.Informer.InformTypes.Success);
    }

    //sayfa yenilendiğinde textboxları boşaltır
    private void clearForm()
    {
        txtEventName.Text = "";
        txtEventDuration.Text = "";
        txtEventClassifyByAge.Text = "";
        txtEventClassifyByStage.Text = "";
        drpClasses.SelectedIndex = 0;
        drpEducater.SelectedIndex = 0;
        txtEventContent.Text = "";
    }
}