using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Reports için özet açıklama
/// </summary>
public class Reports
{
    //report classına ait özellikler
    public int Id { get; set; }
    public int AssignedActivityId { get; set; }

    public int ActivityId { get; set; }
    public int StudentId { get; set; }
    public string Stage { get; set; }
    public string Grade { get; set; }
    public string Comments { get; set; }
    public int? Approver { get; set; }
    public string ApproverName { get; set; }
    public DateTime Date { get; set; }

    public ReportDetail Detail { get; set; }


    //rapora ait constructor reports tablosundan satırdaki bilgileri alır
    public Reports(DataRow row)
    {
        Id = Convert.ToInt32(row["Id"]);
        AssignedActivityId = Convert.ToInt32(row["AssignedActivityId"]);
        ActivityId = Convert.ToInt32(row["ActivityId"]);
        StudentId = Convert.ToInt32(row["StudentId"]);

        Stage = row["Stage"].ToString();
        Grade = row["Grade"].ToString();
        Comments = row["Comments"].ToString();
        Date = Convert.ToDateTime(row["Date"]);
        if (row["Approver"] != DBNull.Value)
            Approver = Convert.ToInt32(row["Approver"]);

        ApproverName = row["ApproverName"].ToString();

        Detail = new ReportDetail(row);

    }

    //tüm raporları nesne olarak getirir
    public static object GetAll()
    {
        //raporları liste olarak tutar
        var willReturn = new List<Reports>();

        var sql = "Select  r.*,u.Username 'ApproverName', s.NameSurname 'StudentName', a.Name 'ActivityName', edu.Username 'EducaterName', aa.ActivityId,aa.StudentId  from Reports r"
                     + " inner join AssignedActivities aa on aa.Id = r.AssignedActivityId"
                     + " left join Users u on u.Id = r.Approver "
                     + " left join Activities a on a.Id=aa.ActivityId"
                     + " left join Users edu on edu.Id = a.Educater "
                     + " left join Students s on s.Id=aa.StudentId ";

        var dt = DBClass.ExecuteDataTable(sql);

        foreach (DataRow row in dt.Rows)
            willReturn.Add(new Reports(row));
        return willReturn;
    }

    //öğrenciye ait tüm raporları liste olarak getirir
    public static List<Reports> GetForStudent(int studentId)
    {
        var willReturn = new List<Reports>();

        var sql = "Select  r.*,u.Username 'ApproverName', s.NameSurname 'StudentName', a.Name 'ActivityName', edu.Username 'EducaterName', aa.ActivityId,aa.StudentId  from Reports r"
                     + " inner join AssignedActivities aa on aa.Id = r.AssignedActivityId"
                     + " left join Users u on u.Id = r.Approver "
                     + " left join Activities a on a.Id=aa.ActivityId"
                     + " left join Users edu on edu.Id = a.Educater "
                     + " left join Students s on s.Id=aa.StudentId where studentId =" + studentId;
        var dt = DBClass.ExecuteDataTable(sql);

        foreach (DataRow row in dt.Rows)
            willReturn.Add(new Reports(row));
        return willReturn;
    }

    //rapor onaylama methodu
    public static bool Approve(int reportId, int approverId)
    {
        //onaylayan adminin id si ve öğrenci id sine göre sqlden çeker
        var sql = string.Format("Update Reports set Approver={0} where Id={1}", approverId, reportId);
        return DBClass.ExecuteNonQuery(sql);
    }

    //rapor oynayı geri alma methodu
    public static bool UndoApprove(int reportId)
    {
        //onaylayan adminin id si ve öğrenci id sine göre sqlden çeker
        var sql = string.Format("Update Reports set Approver=NULL where Id={0} ", reportId);
        return DBClass.ExecuteNonQuery(sql);
    }

    //raporları öğrenci ve etkinliğe göre getiren method
    public static Reports GetReport(int studentId, int activityId)
    {

        var sql = "Select  r.*,u.Username 'ApproverName', s.NameSurname 'StudentName', a.Name 'ActivityName',edu.Username 'EducaterName', aa.ActivityId,aa.StudentId   from Reports r"
                     + " right join AssignedActivities aa on aa.Id = r.AssignedActivityId"
                     + " left join Users u on u.Id = r.Approver "
                     + " left join Activities a on a.Id=aa.ActivityId"
                     + " left join Users edu on edu.Id = a.Educater "
                     + " left join Students s on s.Id=aa.StudentId where studentId =" + studentId
                     + " and activityId=" + activityId;

        var row = DBClass.ExecuteDataRow(sql);

        if (row == null)
        {
            throw new Exception("Rapor bulunamadı");
        }

        if (row["Id"] == DBNull.Value)
            return null;

        return new Reports(row);
    }

    //raporu sql sistemine parametrelere göre kaydeden method
    public static bool Save(string grade, string stage, string comments, int studentId, int activityId)
    {
        var sql = string.Format("Declare @aaId int " +
            "Select @aaId=aa.Id from AssignedActivities aa where StudentId={0} and ActivityId={1} " +
            "Delete from Reports where AssignedActivityId=@aaId " +
            " INSERT INTO [OgrenciTakip].[dbo].[Reports]" +
           "([AssignedActivityId]" +
           ",[Stage]" +
           ",[Grade]" +
           ",[Comments])" +
              " VALUES" +
           "(@aaId" +
           " ,'{2}' " +
           " ,'{3}'" +
           " ,'{4}' " +
           ")", studentId, activityId, stage, grade, comments);

        return DBClass.ExecuteNonQuery(sql);
    }

    //rapor detayını öğrenci ve etkinliğe göre getiren method
    public static ReportDetail GetReportDetail(int studentId, int activityId)
    {

        var sql = "Select  s.NameSurname 'StudentName', a.Name 'ActivityName',edu.Username 'EducaterName'  from Reports r"
                     + " right join AssignedActivities aa on aa.Id = r.AssignedActivityId"
                     + " left join Activities a on a.Id=aa.ActivityId"
                     + " left join Users edu on edu.Id = a.Educater "
                     + " left join Students s on s.Id=aa.StudentId where studentId =" + studentId
                     + " and activityId=" + activityId;


        var row = DBClass.ExecuteDataRow(sql);

        return new ReportDetail(row);
    }
}