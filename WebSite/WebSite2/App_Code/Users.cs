using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Users için özet açıklama
/// </summary>
public class Users
{
    public int Id { get; set; }
    public string Username { get; set; }
    private string Password { get; set; }
    public UserRoles Role { get; set; }

    public enum UserRoles
    {
        //kullancıya ait roller
        Student = 0,
        Admin = 1,
        Teacher = 2,
        Register = 3
    }

    public Users(DataRow row)
    {
        //sql Users tablosundan verileri çeker
        Id = Convert.ToInt32(row["Id"]);
        Username = row["Username"].ToString();
        Password = row["Password"].ToString();
        Role = (UserRoles)Convert.ToInt16(row["Role"]);
    }

    //tüm kullanıcıları getiren method
    public static List<Users> GetAll()
    {
        var willReturn = new List<Users>();

        var sql = "Select  *  from Users";
        var dt = DBClass.ExecuteDataTable(sql);

        foreach (DataRow row in dt.Rows)
            willReturn.Add(new Users(row));
        return willReturn;
    }

    //giriş için Users tablosundan kullanıcı adı ve şifre tablodan seçilir
    public static Users Login(string Username, string Password)
    {
        var sql = string.Format("Select top 1 * from Users where Username='{0}' and Password = '{1}'", Username, Password);
        var row = DBClass.ExecuteDataRow(sql);

        if (row != null)
            return new Users(row);
        return null;
    }
}