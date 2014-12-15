using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ComputerRepair.BusinessLogicLayer;
using ComputerRepair.DataAccessHelper;

public partial class admin_del_alarm : System.Web.UI.Page
{
    public string Action;
    protected void Page_Load(object sender, EventArgs e)
    {
        Action = Convert.ToString(Request.QueryString["Action"]);

        switch (Action)
        {
            case "DelAlarm":
                DelAlarm();
                break;

            default:
                break;
        }

    }
    /// <summary>
    /// 更新一条数据，设为可用
    /// </summary>
    private void DelAlarm()
    {
        string alarmListID = Convert.ToString(Request.QueryString["AlarmID"]);
        AlarmList alarmlist = new AlarmList();

        alarmlist.LoadData1(alarmListID);
        alarmlist.Delete();
        string strsql = "delete from T_WorkerAlarm where AlarmType_ID='" + alarmListID + "'";
        alarmlist.Delete1(strsql);

        Response.Redirect(Request.UrlReferrer.ToString());
    }
}