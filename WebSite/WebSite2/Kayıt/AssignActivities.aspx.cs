using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Kayıt_AssignActivities : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //sayfa yenilenmediyse methodu çağırır
        if (!IsPostBack)
            fillDropLists();
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

            //sistemdeki tüm etkinlikleri getirir
            var activities = Activities.GetAll();

            //DBClass'a ait methodlar
            drpActivities.DataSource = activities;
            drpActivities.DataValueField = "Id";
            drpActivities.DataTextField = "Name";
            drpActivities.DataBind();
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
            var student = Convert.ToInt32(drpstudents.SelectedValue);
            var activity = Convert.ToInt32(drpActivities.SelectedValue);

            //öğrenciye etkinliği atayan methodu çağırır
            AssignedActivities.Assign(student, activity);

        }
        catch (Exception ex)
        {
            Informer.Inform(ex);
            return;
        }

        Informer.Inform("Etkinlik atandı.", Scop.UserControls.Informer.InformTypes.Success);

    }

}