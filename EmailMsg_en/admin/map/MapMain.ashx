<%@ WebHandler Language="C#" Class="MapMain" %>

using System;
using System.Web;
using ComputerRepair.BusinessLogicLayer;
using System.Data;

public class MapMain : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        string strRet = "";

        DataSet ds = null;
        DataTable dt = null;
        
        string type = context.Request.QueryString["type"];
        string order = context.Request.QueryString["order"];
        string page = "1";// context.Request.QueryString["page"];
        string rows = "100";// context.Request.QueryString["rows"];
        string sort = context.Request.QueryString["sort"];
        string GroupId = context.Request.QueryString["GroupId"];
        string MapId = context.Request.QueryString["MapId"];
        context.Response.ContentType = "text/plain";
        switch (type)
        {
            case "0":
                strRet = new GroupList().LoadAllGroupInfo();
                break;
            case "1"://加载指定区域的地图信息
                strRet = new GroupList().GetData(order, page, rows, sort, GroupId);
                break;
            case "2"://加载所有区域的地图信息
                strRet = new GroupList().GetAllData(page, rows);
                break;
            case "3"://加载指定地图的所有报警设备
                ds = new T_MapPots().GetAlrmPotInfoByMapId(Convert.ToInt32(MapId));
                if (ds != null)
                {
                    dt = ds.Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        strRet = "{\"AlarmsPots\":[";
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            strRet = strRet + "{";
                            strRet = strRet + string.Format("\"PotId\":\"{0}\",\"EquipmentId\":\"{1}\",\"ReceiveMsgID\":\"{2}\"", dt.Rows[i]["Id"].ToString(), dt.Rows[i]["EquipmentId"].ToString(), dt.Rows[i]["ReceiveMsgID"].ToString());
                            strRet = strRet + "}";
                            if (i != dt.Rows.Count - 1)
                            {
                                strRet = strRet + ",";
                            }
                        }
                        strRet = strRet + "]}";
                    }
                    else
                    {
                        strRet = "{\"AlarmsPots\":[]}";
                    }
                   
                }
                else
                {
                    strRet = "{\"AlarmsPots\":[]}";
                }
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