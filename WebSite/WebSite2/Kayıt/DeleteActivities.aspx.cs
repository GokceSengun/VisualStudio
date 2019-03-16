using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Kayıt_DeleteActivities : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //sayfa yenilenmediyse methodu çağır
        if (!IsPostBack)
            fillDropLists();
    }


    protected void drpstudents_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //öğrenci idsine göre atanan etkinlikleri çeker
            var activities = AssignedActivities.GetByStudentId(Convert.ToInt32(drpstudents.SelectedValue));

            //DBClass'a ait methodlar
            drpActivities.DataSource = activities;
            drpActivities.DataValueField = "ActivityId";
            drpActivities.DataTextField = "ActivityName";
            drpActivities.DataBind();
        }
        catch (Exception ex)
        {
            Informer.Inform(ex);
        }
    }

    private void fillDropLists()
    {
        try
        {
            //sistemdeki tüm öğrencileri getirir
            var students = Students.GetAll();

            //DBClass'a ait methodlar
            drpstudents.DataSource = students;
            drpstudents.DataValueField = "Id";
            drpstudents.DataTextField = "NameSurname";
            drpstudents.DataBind();

            drpstudents_SelectedIndexChanged(null, null);
        }
        catch (Exception ex)
        {
            Informer.Inform(ex);
        }


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            var activity = Convert.ToInt32(drpActivities.SelectedValue);
            var student = Convert.ToInt32(drpstudents.SelectedValue);

            //öğrenciye ait etkinliği silen methodu çağırır
            AssignedActivities.Delete(activity, student);

            //sistemdeki tüm öğrencileri getirir
            fillDropLists();
            Informer.Inform("Etkinlik Silindi.", Scop.UserControls.Informer.InformTypes.Success);
        }
        catch (Exception ex)
        {
            Informer.Inform(ex);
        }
    }

}