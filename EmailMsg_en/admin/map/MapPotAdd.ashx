<%@ WebHandler Language="C#" Class="MapPotAdd" %>

using System;
using System.Web;

public class MapPotAdd : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        string strRet = "{\"result\":\"error\",\"message\":\"Add equipment failure，The cause is unknown\"}";
        context.Response.ContentType = "text/plain";

        string MapEquipmentId = context.Request.QueryString["MapEquipmentId"].ToString();
        string MapId = context.Request.QueryString["MapId"].ToString();
        string MapPotName = context.Request.QueryString["MapPotName"].ToString();
        string posX = context.Request.QueryString["posX"].ToString();
        string posY = context.Request.QueryString["posY"].ToString();
        string Width = context.Request.QueryString["Width"].ToString();
        string Height = context.Request.QueryString["Height"].ToString();

        try
        {
            if (new T_MapPots().Add(Convert.ToInt32(MapId), Convert.ToInt32(MapEquipmentId), MapPotName, Convert.ToDouble(posX), Convert.ToDouble(posY), Convert.ToInt32(Width),Convert.ToInt32(Height)))
            {
                strRet = "{\"result\":\"ok\",\"message\":\"Add equipment OK\"}";
            }
        }
        catch (Exception ex)
        {
            strRet = "{\"result\":\"error\",\"message\":\"Add equipment failure，because:" + ex.Message.Replace("'", "‘").Replace("\"", "“") + "\"}";
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