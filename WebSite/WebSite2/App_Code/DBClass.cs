using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// DBClass için özet açıklama
/// SQL tablo işlemlerini yapmak için DataBase sınıfı
/// </summary>
public class DBClass
{

    private static string connectionString = "Data Source=.;" +
                                                "Initial Catalog=OgrenciTakip;" +
                                                "User id=sa;" +
                                                "Password=123456;";

    //sql de sorguda UPDATE ve DELETE gibi geriye veri dönmüyorsa bu method çağırılır
    public static bool ExecuteNonQuery(string sql)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand kmt = new SqlCommand(sql, conn);
            if (kmt.ExecuteNonQuery() == 1)
                return true;
            else
                return false;
        }
    }

    //sqldeki tek bir değeri alır 
    public static object ExecuteSclar(string sql)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand kmt = new SqlCommand(sql, conn);
            return kmt.ExecuteScalar();
        }

    }

    public static DataSet ExecuteDataSet(string sql)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlDataAdapter adap = new SqlDataAdapter(sql, conn);
            DataSet data = new DataSet();
            adap.Fill(data);
            return data;
        }
    }

    //sqldeki tabloyu getirir
    public static DataTable ExecuteDataTable(string sql)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlDataAdapter adap = new SqlDataAdapter(sql, conn);
            DataSet data = new DataSet();
            adap.Fill(data);
            if (data.Tables.Count == 0)
                return null;
            return data.Tables[0];
        }
    }

    //sqldeki bir satırı getirir
    public static DataRow ExecuteDataRow(string sql)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlDataAdapter adap = new SqlDataAdapter(sql, conn);
            DataSet data = new DataSet();
            adap.Fill(data);
            if (data.Tables.Count == 0 || data.Tables[0].Rows.Count == 0)
                return null;
            return data.Tables[0].Rows[0];
        }
    }
}