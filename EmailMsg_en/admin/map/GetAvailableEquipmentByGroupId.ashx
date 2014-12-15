<%@ WebHandler Language="C#" Class="GetAvailableEquipmentByGroupId" %>

using System;
using System.Web;
using ComputerRepair.BusinessLogicLayer;

public class GetAvailableEquipmentByGroupId : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        string strRet = "{\"result\":\"error\",\"message\":\"Add map failed for an unknown reason\"}";
        context.Response.ContentType = "text/plain";

        string hid_MapId = context.Request.QueryString["hid_MapId"].ToString();
        strRet = new EquipmentInfoList().LoadAvialableEquipmentByMapId(Convert.ToInt32(hid_MapId));
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