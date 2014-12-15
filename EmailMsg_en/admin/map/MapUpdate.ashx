<%@ WebHandler Language="C#" Class="MapUpdate" %>

using System;
using System.Web;
using System.IO;

public class MapUpdate : IHttpHandler
{
    private const string STR_MAP_FOLDER = "~/admin/map/imgs/";
    public void ProcessRequest(HttpContext context)
    {
        string strRet = "{\"result\":\"error\",\"message\":\"Edit map failure，The cause is unknown\"}";
        context.Response.ContentType = "text/plain";

        if (!Directory.Exists(context.Server.MapPath(STR_MAP_FOLDER)))
        {
            Directory.CreateDirectory(context.Server.MapPath(STR_MAP_FOLDER));
        }

        HttpPostedFile mapFile = context.Request.Files["mapFile_Update"];
        string txtMapName_Update = context.Request.Form["txtMapName_Update"].ToString();
        string hid_AreaId_MapUpdate = context.Request.Form["hid_AreaId_MapUpdate"].ToString();
        string hid_MapId_MapUpdate = context.Request.Form["hid_MapId_MapUpdate"].ToString();
        string mapFilePath_Old = context.Request.Form["mapFilePath_Old"].ToString();

        string strFileName = "";
        string strSourceFileNameWithExtension = "";
        string strSourceFileNameWithOutExtension = "";
        string strSourceFileNameExtensionName = "";
        string strFullFilePath = "";

        if (mapFile.ContentLength == 0)
        {
            strFullFilePath = mapFilePath_Old;
            if (new T_MapHeader().Update(Convert.ToInt32(hid_AreaId_MapUpdate), txtMapName_Update, strFullFilePath, Convert.ToInt32(hid_MapId_MapUpdate)))
            {
                strRet = "{\"result\":\"ok\",\"message\":\"Edit map OK\"}";
            }
        }
        else
        {
            strFileName = "[" + DateTime.Now.ToString("yyyyMMddHHmmss") + (new Random()).Next(10).ToString("00") + "]";
            strSourceFileNameWithExtension = mapFile.FileName.Substring(mapFile.FileName.LastIndexOf("\\") + 1);
            strSourceFileNameWithOutExtension = strSourceFileNameWithExtension.Substring(0, strSourceFileNameWithExtension.LastIndexOf("."));
            strSourceFileNameExtensionName = strSourceFileNameWithExtension.Substring(strSourceFileNameWithExtension.LastIndexOf(".") + 1);
            strFullFilePath = context.Server.MapPath(STR_MAP_FOLDER + strSourceFileNameWithOutExtension + strFileName + "." + strSourceFileNameExtensionName);

            try
            {
                //保存地图文件
                mapFile.SaveAs(strFullFilePath);
                if (new T_MapHeader().Update(Convert.ToInt32(hid_AreaId_MapUpdate), txtMapName_Update, "imgs/" + strSourceFileNameWithOutExtension + strFileName + "." + strSourceFileNameExtensionName, Convert.ToInt32(hid_MapId_MapUpdate)))
                {
                    strRet = "{\"result\":\"ok\",\"message\":\"Edit map OK\"}";
                }
            }
            catch (Exception ex)
            {
                strRet = "{\"result\":\"error\",\"message\":\"Edit map failure,because:" + ex.Message.Replace("'", "‘").Replace("\"", "“") + "\"}";
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