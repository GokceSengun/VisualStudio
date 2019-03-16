using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Educator_Default : System.Web.UI.Page
{
    //role management
    private Users CurrentUser;
    protected void Page_Load(object sender, EventArgs e)
    {
        CurrentUser = (Session[SessionObj.SessionKey] as SessionObj).CurrentUser;

        //sayfa yenilenmediyse
        if (!IsPostBack)
            preparePage();
    }


    private void preparePage()
    {
        try
        {
            //Sistemde kayıtlı öğrencileri getirmek için kullanılan DBClass sınıfından çağırılan method
            var students = Students.GetStudentsForEducater(CurrentUser.Id);
            RepaterStudents.DataSource = students;
            RepaterStudents.DataBind();

        }
        catch (Exception ex)
        {
            Informer.Inform( ex);
        }
    }
}