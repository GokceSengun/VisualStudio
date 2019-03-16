using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ViewReports : System.Web.UI.Page
{

    private int studentId;
    private int activityId;

    Reports report;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //sayfa yüklendiğinde çağırılan methodlar
            checkFormVariables();
            setDataTable();


        }
        catch (Exception ex)
        {
            Informer.Inform(ex);
        }
    }

    //Adminin, öğrenci raporuna ait bilgileri aldığı method
    private void setFields()
    {
        try
        {
            if (report != null)// Rapor oluşturulmuş ise
            {
                txtReport.Text = report.Comments;
                txtGrade.Text = report.Grade;
                txtStage.Text = report.Stage;
                txtActivityName.Text = report.Detail.ActivityName;
                txtStudentName.Text = report.Detail.StudentName;
                txtEducater.Text = report.Detail.EducaterName;

                btnSave.Text = string.IsNullOrEmpty(report.ApproverName) ? "Onayla" : "Onayı Geri Al";

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

    //sistemdeki raporları getiren method
    private void setDataTable()
    {
        try
        {
            var reports = Reports.GetAll();

            //DBClass'a ait methodlar
            RepetearReports.DataSource = reports;
            RepetearReports.DataBind();
        }
        catch (Exception ex)
        {
            Informer.Inform(ex);
        }
    }

    //sql tablosundaki studentid ve activityid değerlerini karşıltıran, kontrollerini yapan method
    private void checkFormVariables()
    {
        try
        {
            if (!string.IsNullOrEmpty(Request["StudentId"]) && Int32.TryParse(Request["StudentId"], out studentId) &&
              !string.IsNullOrEmpty(Request["ActivityId"]) && Int32.TryParse(Request["ActivityId"], out activityId))
            {
                reportForm.Visible = true;
                report = Reports.GetReport(studentId, activityId);
                setFields();
            }
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
            //sistemde var olan admini alır
            var currentUser = (Session[SessionObj.SessionKey] as SessionObj).CurrentUser;
            if (string.IsNullOrEmpty(report.ApproverName))
            {
                //rapor onaylamak için çağırılan method
                Reports.Approve(report.Id, currentUser.Id);
                btnSave.Text = "Onayı Geri Al";
                Informer.Inform("Rapor Onaylandı", Scop.UserControls.Informer.InformTypes.Success);
                sendMail();
            }
            else
            {
                //rapor onayını geri almak için çağırılan method
                Reports.UndoApprove(report.Id);
                btnSave.Text = "Onayla";
                Informer.Inform("Onay İptal Edildi", Scop.UserControls.Informer.InformTypes.Success);

            }
            
            setDataTable();
        }
        catch (Exception ex)
        {
            Informer.Inform(ex);
        }
    }

    //mail gönderme methodu
    private void sendMail()
    {
        //rapordaki  bilgileri sql den çeker
        try
        {
            var student = Students.GetById(studentId);
            var content = string.Format
                         ("Öğrenci Adı:{0} <br>" +
                          "Etkinlik Adı:{1} <br>" +
                          "Eğitmen Adı:{2} <br>" +
                          "Not:{3} <br>" +
                          "Seviye:{4} <br><br>" +
                          "Rapor:{5} ", txtStudentName.Text, txtActivityName.Text, txtEducater.Text, txtGrade.Text, txtStage.Text, txtReport.Text);


            
            Mail.Send("Öğrenci Raporu", content, student.Mail);
        }
        catch (Exception ex)
        {
            Informer.Inform("Rapor onaylandı. Mail göndirilemedi.", Scop.UserControls.Informer.InformTypes.Error, ex);
        }
    }
}