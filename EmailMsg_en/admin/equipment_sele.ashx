<%@ WebHandler Language="C#" Class="equipment_sele" %>

using System;
using System.Web;
using ComputerRepair.BusinessLogicLayer;

public class equipment_sele : IHttpHandler
{
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string strRet = "";
        
        string state=context.Request.QueryString["state"];
        if (!string.IsNullOrEmpty(state))
        {
            strRet = new EquipmentInfoList().GetDataWithUsers(state);
        }
        
        context.Response.Write(strRet);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}