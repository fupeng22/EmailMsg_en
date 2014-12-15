<%@ WebHandler Language="C#" Class="LoadMapPotDetail" %>

using System;
using System.Web;

public class LoadMapPotDetail : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        string strRet = "{\"result\":\"error\",\"message\":\"Get equipment failure,the cause is unknown\",\"data\":\"[]\"}";
        context.Response.ContentType = "text/plain";

        string MapId = context.Request.QueryString["MapId"].ToString();

        try
        {
            strRet = "{\"result\":\"ok\",\"message\":\"Get equipment OK\",\"data\":" + new T_MapPots().LoadMapPotDetailByMapId(Convert.ToInt32(MapId)) + "}";
        }
        catch (Exception ex)
        {
            strRet = "{\"result\":\"error\",\"message\":\"Get equipment failure，because:" + ex.Message.Replace("'", "‘").Replace("\"", "“") + "\",\"data\":\"[]\"}";
        }

        context.Response.Write(strRet);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}