using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// SessionObj için özet açıklama
/// </summary>
public class SessionObj
{
    //role management, o anki kullancıyı belirler
    public static string SessionKey = "SESSIONKEY";

    public Users CurrentUser;

    public SessionObj(Users user)
    {
        CurrentUser = user;
    }
}