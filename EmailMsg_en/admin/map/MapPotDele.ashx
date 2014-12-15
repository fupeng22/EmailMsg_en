<%@ WebHandler Language="C#" Class="MapPotDele" %>

using System;
using System.Web;

public class MapPotDele : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        string strRet = "{\"result\":\"error\",\"message\":\"Delete equipment failure，The cause is unknown\"}";
        context.Response.ContentType = "text/plain";

        string Id = context.Request.QueryString["mapPotId"].ToString();

        try
        {
            if (new T_MapPots().Dele(Convert.ToInt32(Id)))
            {
                strRet = "{\"result\":\"ok\",\"message\":\"Delete equipment OK\"}";
            }
        }
        catch (Exception ex)
        {
            strRet = "{\"result\":\"error\",\"message\":\"Delete equipment failure，because:" + ex.Message.Replace("'", "‘").Replace("\"", "“") + "\"}";
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