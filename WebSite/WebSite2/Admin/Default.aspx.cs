using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //sayfa yenilenmediyse çağırılan method
        if (!IsPostBack)
            preparePage();
    }

    private void preparePage()
    {
        try
        {
            //Sistemde kayıtlı öğrencileri getirmek için kullanılan DBClass sınıfından çağırılan method
            var students = Students.GetAll();
            RepaterStudents.DataSource = students;
            RepaterStudents.DataBind();
            checkForStudentDelete(students);

            //Sistemde kayıtlı öğrencileri getirmek için kullanılan DBClass sınıfından çağırılan method
            var events = Activities.GetAll();
            RepetearEvents.DataSource = events;
            RepetearEvents.DataBind();
            checkForEventDelete(events);
        }
        catch (Exception ex)
        {
           Informer.Inform("Veritabanına bağlanılamadı.", Scop.UserControls.Informer.InformTypes.Error, ex);
        }
    }

    //Öğrencinin id sine göre öğrenciyi sistemden siler. Bunu admin gerçekleştirir Role=1
    private void checkForStudentDelete(List<Students> students)
    {
        if (Request.QueryString["Action"] == "DeleteStudent" && Request.QueryString["Id"] != null &&
            students.Count(q => q.Id == Convert.ToInt32(Request.QueryString["Id"])) > 0)
        {
            Students.DeleteById(Convert.ToInt32(Request.QueryString["Id"]));
            Response.Redirect(Urls.Admin.MainPage);
        }
    }

    //Etkinliğin id sine göre etkinliği sistemden siler. Bunu admin gerçekleştirir Role=1
    private void checkForEventDelete(List<Activities> events)
    {
        if (Request.QueryString["Action"] == "DeleteEvent" && Request.QueryString["Id"] != null &&
            events.Count(q => q.Id == Convert.ToInt32(Request.QueryString["Id"])) > 0)
        {
            Activities.DeleteById(Convert.ToInt32(Request.QueryString["Id"]));
            Response.Redirect(Urls.Admin.MainPage);
        }

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

    }
}