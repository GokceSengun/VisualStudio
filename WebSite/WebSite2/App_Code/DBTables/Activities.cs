using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Activities için özet açıklama
/// </summary>
public class Activities
{
    //properties
    public int Id { get; set; }
    public string Name { get; set; }
    public string Duration { get; set; }
    public string Contents { get; set; }
    public string ClassifyByAge { get; set; }
    public string ClassifyByStage { get; set; }
    public int? Class { get; set; }



    public int? Educater { get; set; }

    public string EducaterName { get; set; }
    public string ClassName { get; set; }

    //etkinliğe ait constructor activities tablosundan satırdaki bilgileri alır
    public Activities(DataRow row)
    {
        Id = Convert.ToInt32(row["Id"]);
        Name = row["Name"].ToString();
        Duration = row["Duration"].ToString();
        Contents = row["Contents"].ToString();
        ClassifyByAge = row["ClassifyByAge"].ToString();
        ClassifyByStage = row["ClassifyByStage"].ToString();

        if (row["Class"] != DBNull.Value)
            Class = Convert.ToInt32(row["Class"]);

        if (row["Educater"] != DBNull.Value)
            Educater = Convert.ToInt32(row["Educater"]);

        EducaterName = row["EducaterName"].ToString();
        ClassName = row["ClassName"].ToString();

    }

    //etkinliğin id sine göre etkinliği alır
    public static Activities GetById(int Id)
    {
        var sql = "Select  a.*, u.Username 'EducaterName',c.Name ClassName  from Activities a "
                  + "left join Users u on u.Role = 2 and u.Id = a.Educater " 
                  +" left join Classes c on c.Id=a.Class"
                  + " where a.Id = " + Id;

        var row = DBClass.ExecuteDataRow(sql);

        return new Activities(row);
    }

    //sql deki activities tablosundan etkinliğe ait verileri güncellemek için kullanılan method
    public static bool Update(int Id, string name, string duration, string content, string age, string stage, int classes, int educater )
    {
        var sql = string.Format("UPDATE [OgrenciTakip].[dbo].[Activities]"
     + "  SET[Name] = '{0}'"
     + " ,[Duration] = '{1}'"
     + " ,[Contents] = '{2}'"
     + " ,[ClassifyByAge] = '{3}'"
     + " ,[ClassifyByStage] = '{4}'"
     + " ,[Class] = '{5}'"
     + " ,[Educater] = '{6}'"
     + "  WHERE Id ={7}", name, duration, content, age, stage, classes, educater,Id);

        return DBClass.ExecuteNonQuery(sql);
    }

    //yeni etkinlik oluşturmak için kullanılan method
    //veriler sqlde tutulur
    public static bool AddNew(string name, string duration, string content, string age, string stage, int classes, int educater)
    {
        var sql = string.Format("INSERT INTO [OgrenciTakip].[dbo].[Activities]"
           + "([Name]"
           + ",[Duration]"
           + ",[Contents]"
           + ",[ClassifyByAge]"
           + ",[ClassifyByStage]"
           + ",[Class]"
           + ",[Educater])"
     + "VALUES"
          + "('{0}'"
          + ",'{1}'"
          + ",'{2}'"
          + ",'{3}'"
          + ",'{4}'"
          + ",'{5}'"
          + ",'{6}')", name, duration, content, age, stage, classes, educater);

        return DBClass.ExecuteNonQuery(sql);
    }


    //sistemdeki etkinlikleri sqldeki tabloları birleştirerek getiren method
    public static List<Activities> GetAll()
    {
        var willReturn = new List<Activities>();
        var sql = "Select  a.*,u.Username 'EducaterName',c.Name ClassName from Activities a left join Users u on u.Role=2 and u.Id=a.Educater " +
                  "left join Classes c on c.Id=a.Class";
        var dt = DBClass.ExecuteDataTable(sql);

        foreach (DataRow row in dt.Rows)
            willReturn.Add(new Activities(row));

        return willReturn;
    }

   //etkinliğin id sine göre etkinliği sistemden siler.
    public static bool DeleteById(int Id)
    {
        var sql = "Delete  from Activities where Id=" + Id +
         " Delete from AssignedActivities where ActivityId=" + Id;
        return DBClass.ExecuteNonQuery(sql);
    }
}