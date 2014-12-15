<%@ WebHandler Language="C#" Class="MapAdd" %>

using System;
using System.Web;
using System.IO;

public class MapAdd : IHttpHandler
{
    private const string STR_MAP_FOLDER = "~/admin/map/imgs/";
    public void ProcessRequest(HttpContext context)
    {
        string strRet = "{\"result\":\"error\",\"message\":\"Add map failure，The cause is unknown\"}";
        context.Response.ContentType = "text/plain";

        if (!Directory.Exists(context.Server.MapPath(STR_MAP_FOLDER)))
        {
            Directory.CreateDirectory(context.Server.MapPath(STR_MAP_FOLDER));
        }

        HttpPostedFile mapFile = context.Request.Files["mapFile_Add"];
        string txtMapName_Add = context.Request.Form["txtMapName_Add"].ToString();
        string hid_AreaId_MapAdd = context.Request.Form["hid_AreaId_MapAdd"].ToString();

        string strFileName = "[" + DateTime.Now.ToString("yyyyMMddHHmmss") + (new Random()).Next(10).ToString("00") + "]";
        string strSourceFileNameWithExtension = mapFile.FileName.Substring(mapFile.FileName.LastIndexOf("\\") + 1);
        string strSourceFileNameWithOutExtension = strSourceFileNameWithExtension.Substring(0, strSourceFileNameWithExtension.LastIndexOf("."));
        string strSourceFileNameExtensionName = strSourceFileNameWithExtension.Substring(strSourceFileNameWithExtension.LastIndexOf(".") + 1);
        string strFullFilePath = context.Server.MapPath(STR_MAP_FOLDER + strSourceFileNameWithOutExtension + strFileName + "." + strSourceFileNameExtensionName);

        try
        {
            //保存地图文件
            mapFile.SaveAs(strFullFilePath);
            if (new T_MapHeader().Add(Convert.ToInt32(hid_AreaId_MapAdd), txtMapName_Add, "imgs/" + strSourceFileNameWithOutExtension + strFileName + "." + strSourceFileNameExtensionName))
            {
                strRet = "{\"result\":\"ok\",\"message\":\"Add map OK\"}";
            }
        }
        catch (Exception ex)
        {
            strRet = "{\"result\":\"error\",\"message\":\"Add map failure，because:" + ex.Message.Replace("'", "‘").Replace("\"", "“") + "\"}";
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