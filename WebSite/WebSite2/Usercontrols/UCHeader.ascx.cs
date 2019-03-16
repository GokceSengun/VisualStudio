using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UCHeader : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void btnLogout_ServerClick(object sender, EventArgs e)
    {
        //çerezleri temizler
        Request.Cookies.Clear();

        Request.Cookies.Remove(CommonConstants.CookieNameOfPassword);
        Request.Cookies.Remove(CommonConstants.CookieNameOfUserName);

        Response.Cookies[CommonConstants.CookieNameOfPassword].Expires = DateTime.Now.AddDays(-1);
        Response.Cookies[CommonConstants.CookieNameOfUserName].Expires = DateTime.Now.AddDays(-1);

        Session.Clear();
        //anasayfaya yönlendirir
        Response.Redirect(Urls.Login);
    }
}