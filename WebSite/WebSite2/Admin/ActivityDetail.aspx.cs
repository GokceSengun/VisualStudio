using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ActivityDetail : System.Web.UI.Page
{
    private Activities activity;
    protected void Page_Load(object sender, EventArgs e)
    {
        getActivity(); //etkinlikleri getirir
    }


    private void getActivity()
    {
        try
        {
            //etkinlikleri sqldeki id ye göre getirir
            int Id = 0;
            if (string.IsNullOrEmpty(Request["Id"]) || !Int32.TryParse(Request["Id"], out Id))
                Response.Redirect(Urls.Admin.MainPage);

            activity = Activities.GetById(Id);

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
        //sqldeki etkinlik tablosundali verilere göre sayfadaki alanları doldurur
        txtEventId.Text = activity.Id.ToString();
        txtEventName.Text = activity.Name;
        txtEventDuration.Text = activity.Duration;
        txtEventContent.Text = activity.Contents;
        txtEventClassifyByAge.Text = activity.ClassifyByAge;
        txtEventClassifyByStage.Text = activity.ClassifyByStage;
        drpClasses.SelectedValue = (Convert.ToInt32(activity.Class)).ToString();
      
        drpEducater.SelectedValue = (Convert.ToInt32(activity.Educater)).ToString();
       

        fillDropdowns();//atanan etkinlikler, eğitmen ve sınıf için droplist şeklinde alanları dolduran method
    }

    private void fillDropdowns()
    {
        //sql sistemindeki bir öğrenci için atanan etkinlikleri etkinlik idsine göre getirir
        var students = AssignedActivities.GetStudentsByActivityId(activity.Id);
        drpStudents.DataSource = students;
        drpStudents.DataValueField = "Id";
        drpStudents.DataTextField = "NameSurname";
        drpStudents.DataBind();

        //sql sistemindeki etkinliklerin yapılacağı sınıfları getirir
        var classes = Classes.GetAll();
        drpClasses.DataSource = classes;
        drpClasses.DataValueField = "Id";
        drpClasses.DataTextField = "Name";
        drpClasses.DataBind();

        //sql sistemindeki eğitmenleri getirir
        var educater = Users.GetAll().Where(q => q.Role == Users.UserRoles.Teacher).ToList();
        drpEducater.DataSource = educater;
        drpEducater.DataValueField = "Id";
        drpEducater.DataTextField = "Username";
        drpEducater.DataBind();

    }

    protected void btnDeleteActivity_Click(object sender, EventArgs e)
    {
        try
        {
          
            var studentId = Convert.ToInt32(drpStudents.SelectedValue);

            //etkinliğin id sine göre o etkinliği siler
            AssignedActivities.Delete(activity.Id, studentId);

            fillDropdowns();
            Informer.Inform("Seçili öğrenci artık bu etkinliği almıyor.", Scop.UserControls.Informer.InformTypes.Success);
        }
        catch (Exception ex)
        {
            Informer.Inform("Hata oluştu!", Scop.UserControls.Informer.InformTypes.Error, ex);
        }
    }

    //Seçili etkinliğin bilgilerini güncellemek için çağırılan method
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            
            var name = txtEventName.Text;
            var duration = txtEventDuration.Text;
            var contents = txtEventContent.Text;
            var ClassifyByAge = txtEventClassifyByAge.Text;
            var ClassifyByStage = txtEventClassifyByStage.Text;
            var Class = (Convert.ToInt32(drpClasses.SelectedValue));
            var educater = (Convert.ToInt32(drpEducater.SelectedValue));


            //güncellemek için çağırılan method
            Activities.Update(Convert.ToInt32(txtEventId.Text), name, duration, contents, ClassifyByAge, ClassifyByStage, Class, educater);
        }
        catch (Exception ex)
        {
            Informer.Inform("Hata oluştu.", Scop.UserControls.Informer.InformTypes.Error, ex);
            return;
        }

        Informer.Inform("Kayıt güncellendi.", Scop.UserControls.Informer.InformTypes.Success);
    }

}
