using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Classes için özet açıklama
/// </summary>
public class Classes
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Classes(DataRow row)
    {
        //sql tablosundan sınıf id si ve adını çeker
        Id = Convert.ToInt32(row["Id"]);
        Name = row["Name"].ToString();
    }

    //sistemdeki tüm sınıfları getiren method
    public static List<Classes> GetAll()
    {
        var willReturn = new List<Classes>();

        var sql = "Select  *  from Classes";
        var dt = DBClass.ExecuteDataTable(sql);

        foreach (DataRow row in dt.Rows)
            willReturn.Add(new Classes(row));
        return willReturn;
    }
}