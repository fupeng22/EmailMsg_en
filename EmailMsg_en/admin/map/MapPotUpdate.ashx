<%@ WebHandler Language="C#" Class="MapPotUpdate" %>

using System;
using System.Web;

public class MapPotUpdate : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        string strRet = "{\"result\":\"error\",\"message\":\"Edit equipment failure，The cause is unknown\"}";
        context.Response.ContentType = "text/plain";

        string MapEquipmentId = context.Request.QueryString["MapEquipmentId"].ToString();
        string MapId = context.Request.QueryString["MapId"].ToString();
        string MapPotName = context.Request.QueryString["MapPotName"].ToString();
        string posX = context.Request.QueryString["posX"].ToString();
        string posY = context.Request.QueryString["posY"].ToString();
        string MapPotId = context.Request.QueryString["MapPotId"].ToString();
        string Width = context.Request.QueryString["Width"].ToString();
        string Height = context.Request.QueryString["Height"].ToString();

        try
        {
            if (new T_MapPots().Update(Convert.ToInt32(MapId), Convert.ToInt32(MapEquipmentId), MapPotName, Convert.ToDouble(posX), Convert.ToDouble(posY), Convert.ToInt32(Width), Convert.ToInt32(Height), Convert.ToInt32(MapPotId)))
            {
                strRet = "{\"result\":\"ok\",\"message\":\"Edit equipment OK\"}";
            }
        }
        catch (Exception ex)
        {
            strRet = "{\"result\":\"error\",\"message\":\"Edit equipment failure，because:" + ex.Message.Replace("'", "‘").Replace("\"", "“") + "\"}";
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