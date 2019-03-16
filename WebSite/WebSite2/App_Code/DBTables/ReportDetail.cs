using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// ReportDetail için özet açıklama
/// </summary>
public class ReportDetail
{

    public string StudentName { get; set; }
    public string ActivityName { get; set; }
    public string EducaterName { get; set; }

    public ReportDetail(DataRow row)
    {
        //rapor detayı için alınan bilgiler
        StudentName = row["StudentName"].ToString();
        ActivityName = row["ActivityName"].ToString();
        EducaterName = row["EducaterName"].ToString();
    }

}