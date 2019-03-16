using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Urls için özet açıklama
/// </summary>
public class Urls
{
    public const string Login = "~/Login";

    //admin giriş yaptığında gideceği sayfalar
    public static class Admin
    {
        public const string MainPage = "~/Admin/";
        public const string AddEvents = "~/Admin/AddEvent.aspx";
        public const string Rapors = "~/Admin/ViewReports.aspx/";
        public const string StudentDetail = "~/Admin/StudentDetail.aspx";
        public const string ActivityDetail = "~/Admin/ActivityDetail.aspx";
    }

    //eğitmen giriş yaptığında gideceği sayfalar
    public static class Educator
    {
        public const string MainPage = "~/Educator/";
        public const string Report = "~/Educator/ReportPage.aspx";

    }
    //kayıt giriş yaptığında gideceği sayfalar
    public static class Registry    
    {
        public const string MainPage = "~/Kayıt/";
        public const string Register = "~/Kayıt/Registry.aspx";
        public const string AssignActivities = "~/Kayıt/AssignActivities.aspx";
        public const string DeleteActivities = "~/Kayıt/DeleteActivities.aspx";
    }

}