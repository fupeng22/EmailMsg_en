<%@ WebHandler Language="C#" Class="MapDele" %>

using System;
using System.Web;
using System.IO;

public class MapDele : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        string strRet = "{\"result\":\"error\",\"message\":\"Delete map failure，The cause is unknown\"}";
        context.Response.ContentType = "text/plain";

        string Id = context.Request.QueryString["Id"].ToString();

        try
        {
            if (new T_MapHeader().Delete(Convert.ToInt32(Id)))
            {
                strRet = "{\"result\":\"ok\",\"message\":\"Delete map OK\"}";
            }
        }
        catch (Exception ex)
        {
            strRet = "{\"result\":\"error\",\"message\":\"Delete map failure，because:" + ex.Message.Replace("'", "‘").Replace("\"", "“") + "\"}";
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