<%@ WebHandler Language="C#" Class="LoadMapPotProperty" %>

using System;
using System.Web;

public class LoadMapPotProperty : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string MapPotId = context.Request.QueryString["MapPotId"];
        context.Response.Write(new T_MapPots().LoadMapPotDetailByPotId(Convert.ToInt32(MapPotId)));
            
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}