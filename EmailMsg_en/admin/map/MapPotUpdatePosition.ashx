<%@ WebHandler Language="C#" Class="MapPotUpdatePosition" %>

using System;
using System.Web;

public class MapPotUpdatePosition : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        string strRet = "{\"result\":\"error\",\"message\":\"Edit the postion of equipment failure，The cause is unknown\"}";
        context.Response.ContentType = "text/plain";

        string posX = context.Request.QueryString["posX"].ToString();
        string posY = context.Request.QueryString["posY"].ToString();
        string MapPotId = context.Request.QueryString["MapPotId"].ToString();

        try
        {
            if (new T_MapPots().UpdatePostion(Convert.ToDouble(posX), Convert.ToDouble(posY), Convert.ToInt32(MapPotId)))
            {
                strRet = "{\"result\":\"ok\",\"message\":\"Edit the postion of equipment OK\"}";
            }
        }
        catch (Exception ex)
        {
            strRet = "{\"result\":\"error\",\"message\":\"Edit the postion of equipment failure，because:" + ex.Message.Replace("'", "‘").Replace("\"", "“") + "\"}";
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