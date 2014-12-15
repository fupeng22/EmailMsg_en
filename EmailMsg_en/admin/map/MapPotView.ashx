<%@ WebHandler Language="C#" Class="MapPotView" %>

using System;
using System.Web;
using ComputerRepair.BusinessLogicLayer;

public class MapPotView : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string strRet = "{\"result\":\"error\",\"message\":\"Reset failure\"}";
        string ReceiveMsgId = context.Request.QueryString["ReceiveMsgId"];
        string EquipmentId = context.Request.QueryString["EquipmentId"];

        if (string.IsNullOrEmpty(EquipmentId))
        {
            if (new ReceiveMsgList().ResetAlarmToNormal(Convert.ToInt32(ReceiveMsgId)))
            {
                strRet = "{\"result\":\"ok\",\"message\":\"Reset OK\"}";
            }
            else
            {
                strRet = "{\"result\":\"error\",\"message\":\"Reset failure\"}";
            }
        
        }
        else
        {
            if (new ReceiveMsgList().ResetAlarmToNormalByEquipmentId(Convert.ToInt32(EquipmentId)))
            {
                strRet = "{\"result\":\"ok\",\"message\":\"Reset OK\"}";
            }
            else
            {
                strRet = "{\"result\":\"error\",\"message\":\"Reset failure,<font style='color:red;font-weight:bold'>(The device is not alarm, can go to [view the equipment real-time monitoring)\"}";
            }
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