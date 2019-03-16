using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Scop.UserControls
{
    public partial class Informer : System.Web.UI.UserControl
    {
        public enum InformTypes
        {
            Warning,
            Error,
            Success
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            hideAll();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Inform(Exception ex)
        {
            hideAll();
            infoError.Visible = true;
            lblinfoError.InnerText = "Hata oluştu. Hata Detayı: " + ex.Message;
        }
        public void Inform(string message, InformTypes informType, Exception ex = null)
        {
            hideAll();
            switch (informType)
            {
                case InformTypes.Error: //hata mesajı
                    infoError.Visible = true;
                    lblinfoError.InnerText = ex == null ? message : message + " Hata Detayı: " + ex.Message;
                    return;
                case InformTypes.Success://başarı mesajı
                    infoSuccess.Visible = true;
                    lblinfoSuccess.InnerText = message;
                    return;

                case InformTypes.Warning://uyarı mesajı
                    infoWarning.Visible = true;
                    lblinfoWarning.InnerText = ex == null ? message : message + " Hata Detayı: " + ex.Message;
                    return;
            }
        }

        private void hideAll()
        {
            infoError.Visible = false;
            infoSuccess.Visible = false;
            infoWarning.Visible = false;
        }
    }
}