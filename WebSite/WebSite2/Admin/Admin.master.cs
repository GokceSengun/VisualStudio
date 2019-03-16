using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Admin : System.Web.UI.MasterPage
{
    //role management
    protected void Page_Init(object sender, EventArgs e)
    {
        var obj = (Session[SessionObj.SessionKey] as SessionObj);

        if (obj == null || obj.CurrentUser == null || obj.CurrentUser.Role != Users.UserRoles.Admin)
            Response.Redirect(Urls.Login);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
