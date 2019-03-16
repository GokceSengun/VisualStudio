using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReportPage : System.Web.UI.Page
{
    private int studentId;
    private int activityId;

    Reports report;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            checkFormVariables();
            setDataTable();

            //sayfa yenilenmediyse methodu çağır
            if (!IsPostBack)
                setFields();
        }
        catch (Exception ex)
        {
            Informer.Inform(ex);
        }
    }

    //eğitmenin, öğrenci raporuna ait bilgileri aldığı method
    private void setFields()
    {
        try
        {
            if (report != null) // rapor oluşturulmuş ise
            {
                txtReport.Text = report.Comments;
                txtGrade.Text = report.Grade;
                txtStage.Text = report.Stage;
                txtActivityName.Text = report.Detail.ActivityName;
                txtStudentName.Text = report.Detail.StudentName;
                txtApprover.Text = report.ApproverName;


                //rapor o an sistemdeki eğitmene ait değil ise bu alanları değiştiremez
                if (!string.IsNullOrEmpty(report.ApproverName) || (Session[SessionObj.SessionKey] as SessionObj).CurrentUser.Username != report.Detail.EducaterName)
                {
                    txtGrade.Enabled = false;
                    txtStage.Enabled = false;
                    txtReport.Enabled = false;
                }
            }
            else// Rapor henüz oluşturulmamış
            {
                var detail = Reports.GetReportDetail(studentId, activityId);
                txtActivityName.Text = detail.ActivityName;
                txtStudentName.Text = detail.StudentName;
            }

        }
        catch (Exception ex)
        {
            Informer.Inform(ex);
        }
    }

    //sql serverdan, öğrenciye ait raporları getirir
    private void setDataTable()
    {
        try
        {
            var reports = Reports.GetForStudent(studentId);

            //DBClass'a ait methodlar
            RepetearReports.DataSource = reports;
            RepetearReports.DataBind(); 
        }
        catch (Exception ex)
        {
            Informer.Inform(ex);
        }
    }

    //sistemdeki bilgilerin kontrolü
    private void checkFormVariables()
    {
        //sistemde öyle bir öğrenci yok ise anasayfaya gönderir
        if (string.IsNullOrEmpty(Request["StudentId"]) || !Int32.TryParse(Request["StudentId"], out studentId))
            Response.Redirect(Urls.Educator.MainPage);

        //sistemde öyle bir etkinlik yok ise anasayfaya gönderir
        if (string.IsNullOrEmpty(Request["ActivityId"]) || !Int32.TryParse(Request["ActivityId"], out activityId))
            Response.Redirect(Urls.Educator.MainPage);

        //Öğrenci de o etkinlik yok ise anasayfaya gönderir
        if (!AssignedActivities.CheckActivity(activityId, studentId))
            Response.Redirect(Urls.Educator.MainPage);


        //sistemdeki öğrenciye ait belirli etkinliğin raporunu getiren method
        report = Reports.GetReport(studentId, activityId);

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            //raporda öğrenciye ait bilgiler
            var comments = txtReport.Text;
            var grade = txtGrade.Text;
            var stage = txtStage.Text;

            //raporu oluşturan method
            Reports.Save(grade, stage, comments, studentId, activityId);
            setDataTable();
            Informer.Inform("Rapor Kaydedildi", Scop.UserControls.Informer.InformTypes.Success);
        }
        catch (Exception ex)
        {
            Informer.Inform(ex);
        }
    }

}
