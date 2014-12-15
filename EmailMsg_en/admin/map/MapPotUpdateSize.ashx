<%@ WebHandler Language="C#" Class="MapPotUpdateSize" %>

using System;
using System.Web;

public class MapPotUpdateSize : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        string strRet = "{\"result\":\"error\",\"message\":\"Edit the size of equipment failure，The cause is unknown\"}";
        context.Response.ContentType = "text/plain";

        string Width = context.Request.QueryString["Width"].ToString();
        string Height = context.Request.QueryString["Height"].ToString();
        string MapPotId = context.Request.QueryString["MapPotId"].ToString();

        try
        {
            if (new T_MapPots().UpdateSize(Convert.ToInt32(Width), Convert.ToInt32(Height), Convert.ToInt32(MapPotId)))
            {
                strRet = "{\"result\":\"ok\",\"message\":\"Edit the size of equipment OK\"}";
            }
        }
        catch (Exception ex)
        {
            strRet = "{\"result\":\"error\",\"message\":\"Edit the size of equipment failure，because:" + ex.Message.Replace("'", "‘").Replace("\"", "“") + "\"}";
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