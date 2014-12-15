<%@ WebHandler Language="C#" Class="MapPotViewMain" %>

using System;
using System.Web;
using System.Data;

public class MapPotViewMain : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string strRet = "";
        DataSet ds = null;
        DataTable dt = null;

        string type = context.Request.QueryString["type"];
        string defaultMapSele = context.Request.QueryString["defaultMapSele"];

        switch (type)
        {
            case "1":// 查询默认选择的地图
                ds = new T_BaseDictionary().LoadDefaultSeleMap("DefaultSeleMap", "Admin");
                if (ds != null)
                {
                    dt = ds.Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        strRet = dt.Rows[0]["sValue"].ToString();
                    }
                }
                break;
            case "2"://保存设定的默认地图
                new T_BaseDictionary().AddDefaultSeleMap("DefaultSeleMap", "Admin",defaultMapSele);
                break;
            default:
                break;
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