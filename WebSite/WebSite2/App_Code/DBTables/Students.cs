using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Students için özet açıklama
/// </summary>
public class Students
{
    //properties
    public enum PaymentTypes
    {
        Cash = 1,
        CreditCard = 2,
    }
    #region Tablo Alanları
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string NameSurname { get; set; }
    public string ParentName { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }
    public string Mail { get; set; }
    public string Adress { get; set; }
    public PaymentTypes PaymentType { get; set; }
    public double Amount { get; set; }

    #endregion

    #region Yardımcı Alanlar
    public string ActivityName { get; set; }
    public string ActivityId { get; set; }
    #endregion Yardımcı Alanlar Sonu

    //öğrenciye ait constructor Students tablosundan satırdaki bilgileri alır
    public Students(DataRow row)
    {
        Id = Convert.ToInt32(row["Id"]);
        Name = row["Name"].ToString();
        Surname = row["Surname"].ToString();
        NameSurname = row["NameSurname"].ToString();
        ParentName = row["ParentName"].ToString();

        Age = Convert.ToInt32(row["Age"]);

        Phone = row["Phone"].ToString();
        Mail = row["Mail"].ToString();
        Adress = row["Adress"].ToString();

        PaymentType = (PaymentTypes)Convert.ToInt32(row["PaymentType"]);
        Amount = Convert.ToDouble(row["Amount"]);
    }

    //id ye göre öğrenciyi alır
    public static Students GetById(int Id)
    {
        var sql = "Select  *  from Students where Id=" + Id;
        var row = DBClass.ExecuteDataRow(sql);

        return new Students(row);
    }

    //sql Students tablosundaki seçili öğrenciye ait verileri getirir ve bu verileri günceller.
    public static bool Update(int Id, string name, string surname, string parentname, int age, long? phone, string mail, string address, string paymentType, int amount)
    {
        var sql = string.Format("UPDATE [OgrenciTakip].[dbo].[Students]"
     + "  SET[Name] = '{0}'"
     + " ,[Surname] = '{1}'"
     + " ,[ParentName] = '{2}'"
     + " ,[Age] = '{3}'"
     + " ,[Phone] = '{4}'"
     + " ,[Mail] = '{5}'"
     + " ,[Adress] = '{6}'"
     + " ,[PaymentType] = '{7}'"
     + " ,[Amount] = '{8}'"
     + "  WHERE Id ={9}", name, surname, parentname, age, phone, mail, address, paymentType, amount, Id);

        return DBClass.ExecuteNonQuery(sql);
    }
    //yeni öğrenci, kayıt ekler; bunu sql deki Students tablosuna kaydeder
    public static bool AddNew(string name, string surname, string parentname, int age, long? phone, string mail, string address, string paymentType, int amount)
    {
        var sql = string.Format("INSERT INTO [OgrenciTakip].[dbo].[Students]"
            + "([Name]"
            + ",[Surname]"
            + ",[ParentName]"
            + ",[Age]"
            + ",[Phone]"
            + ",[Mail]"
            + ",[Adress]"
            + ",[PaymentType]"
            + ",[Amount])"
      + "VALUES"
           + "('{0}'"
           + ",'{1}'"
           + ",'{2}'"
           + ",'{3}'"
           + ",'{4}'"
           + ",'{5}'"
           + ",'{6}'"
           + ",'{7}'"
           + ",'{8}')", name, surname, parentname, age, phone, mail, address, paymentType, amount);

        return DBClass.ExecuteNonQuery(sql);
    }

    //tüm öğrencileri getirir
    public static List<Students> GetAll()
    {
        var willReturn = new List<Students>();

        var sql = "Select  *  from Students";
        var dt = DBClass.ExecuteDataTable(sql);

        foreach (DataRow row in dt.Rows)
            willReturn.Add(new Students(row));
        return willReturn;
    }

    //eğitmene ait etkinliği alan öğrencileri getirir
    public static List<Students> GetStudentsForEducater(int educaterId)
    {
        var willReturn = new List<Students>();

        var sql = string.Format("SELECT  s.*,a.Name 'ActivityName', a.Id 'ActivityId' "
        + "  FROM[OgrenciTakip].[dbo].[Students] s"
        + "       left join AssignedActivities aa on aa.StudentId = s.Id"
        + "       left join Activities a on a.Id = aa.ActivityId"
        + "       left join Users u on u.Role = 2 and u.Id = a.Educater"
        + "       where u.Id ={0}", educaterId);


        var dt = DBClass.ExecuteDataTable(sql);

        foreach (DataRow row in dt.Rows)
        {
            var nStudent = new Students(row);
            nStudent.ActivityName = row["ActivityName"].ToString();
            nStudent.ActivityId = row["ActivityId"].ToString();
            willReturn.Add(nStudent);

        }
        return willReturn;
    }


    //öğrenci idsine göre öğrenciyi ait ekinliği siler
    public static bool DeleteById(int Id)
    {
        var sql = string.Format("Delete from [Reports] where AssignedActivityId in" +
                "(Select Id from AssignedActivities where StudentId = {0})" +
                "Delete from AssignedActivities where StudentId = {0}" +
                "Delete from Students where Id = {0}", Id);

        return DBClass.ExecuteNonQuery(sql);
    }
}