<%@ WebHandler Language="C#" Class="GetAvailableEquipmentByGroupId_Update" %>

using System;
using System.Web;
using ComputerRepair.BusinessLogicLayer;

public class GetAvailableEquipmentByGroupId_Update : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        string strRet = "{\"result\":\"error\",\"message\":\"Add map failed for an unknown reason\"}";
        context.Response.ContentType = "text/plain";

        string hid_MapId = context.Request.QueryString["hid_MapId"].ToString();
        string EquipmentId = context.Request.QueryString["EquipmentId"].ToString();
        strRet = new EquipmentInfoList().LoadAvialableEquipmentByMapId_Update(Convert.ToInt32(hid_MapId), Convert.ToInt32(EquipmentId));
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