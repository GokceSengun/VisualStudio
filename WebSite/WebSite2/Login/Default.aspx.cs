using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //kullanıcı adı şifre kontrolü

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            var user = Users.Login(txtUsername.Value, txtPassword.Value);
            if (user == null)
                lblInfo.InnerText = "Hatalı kullanıcı adı veya şifre";
            else
            {
                lblInfo.InnerText = user.Username + " başarıyla giriş yaptı";
                Session[SessionObj.SessionKey] = new SessionObj(user);
                RedirectUserPage(user);
            }
        }
        catch (Exception ex)
        {
            lblInfo.InnerText = ex.Message;
        }

    }

    //Kullanıcının tipine göre hangi url ye yönlendireceğini seçer

    private void RedirectUserPage(Users user)
    {

        switch (user.Role)
        {
            case Users.UserRoles.Admin:
                Response.Redirect(Urls.Admin.MainPage);
                break;

            case Users.UserRoles.Teacher:
                Response.Redirect(Urls.Educator.MainPage);
                break;

            case Users.UserRoles.Register:
                Response.Redirect(Urls.Registry.MainPage);
                break;
        }
    }
}