using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// AssignedActivities için özet açıklama
/// </summary>
public class AssignedActivities
{
    public int ID { get; set; }
    public int ActivityId { get; set; }
    public int StudentId { get; set; }

    public string ActivityName { get; set; }

    public AssignedActivities(DataRow row)
    {
        //atanan etkinlikler için constructor alanlarını tablodan çeker
        ID = Convert.ToInt32(row["ID"]);
        ActivityId = Convert.ToInt32(row["ActivityId"]);
        StudentId = Convert.ToInt32(row["StudentId"]);

        ActivityName = row["ActivityName"].ToString();
    }

    //öğrenci idsine göre atanan etkinlikleri listeler AssignedActivities tablosundan çeker
    public static List<AssignedActivities> GetByStudentId(int studentId)
    {
        var willReturn = new List<AssignedActivities>();
        var sql = string.Format("SELECT aa.*,a.Name 'ActivityName'"
                  + " FROM[OgrenciTakip].[dbo].[AssignedActivities] aa inner join Activities a on a.Id = aa.ActivityId"
                  + " where StudentId ={0}", studentId);
        var dt = DBClass.ExecuteDataTable(sql);

        foreach (DataRow row in dt.Rows)
            willReturn.Add(new AssignedActivities(row));

        return willReturn;
    }
    //öğrenci id sine göre öğrenciye etkinliği atar. bu atamayı etkinlik id ye göre yapar sql e kaydeder.
    public static bool Assign(int studentId, int activityId)
    {
        var sql = string.Format("Declare @count int =0"
        + " Select @count = COUNT(*) from AssignedActivities where ActivityId ={0} and StudentId = {1}"
        + " IF @count=0"
        + " BEGIN"
           + " INSERT INTO [OgrenciTakip].[dbo].[AssignedActivities]"
           + " ([ActivityId]"
           + " ,[StudentId])"
           + " VALUES"
           + " ({0}"
           + " ,{1})"
           + " END", activityId, studentId);

        return DBClass.ExecuteNonQuery(sql);
    }

    //etkinlik id sine göre o etkinliği alan öğrencileri alır
    public static List<Students> GetStudentsByActivityId(int ActivityId)
    {
        var willReturn = new List<Students>();
        var sql = string.Format("SELECT s.* "
                  + " FROM[OgrenciTakip].[dbo].[AssignedActivities] aa inner join Students s on s.Id = aa.StudentId"
                  + " where aa.ActivityId ={0}", ActivityId);
        var dt = DBClass.ExecuteDataTable(sql);

        foreach (DataRow row in dt.Rows)
            willReturn.Add(new Students(row));

        return willReturn;
    }

    //o öğrenciye ait etkinliği kontrol eder
    public static bool CheckActivity(int activityId, int studentId)
    {
        var sql = string.Format("Select Count(*) from AssignedActivities where ActivityId={0} and StudentId={1}", activityId, studentId);

        return Convert.ToInt32(DBClass.ExecuteSclar(sql)) > 0;

    }

    //öğrenciye ait atanan etkinliği tablodan, sistemden siler
    public static bool Delete(int activityId, int studentId)
    {
        var sql = string.Format("Delete from Reports where AssignedActivityId= (Select Id from AssignedActivities where ActivityId={0} and StudentId={1})" +
            "Delete from AssignedActivities where ActivityId={0} and StudentId={1}", activityId, studentId);

        return DBClass.ExecuteNonQuery(sql);
    }
}