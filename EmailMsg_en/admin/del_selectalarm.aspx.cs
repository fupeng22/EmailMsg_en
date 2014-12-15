using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using ComputerRepair.BusinessLogicLayer;
using ComputerRepair.DataAccessHelper;

public partial class admin_del_selectalarm : System.Web.UI.Page
{
    public string Action;
    protected void Page_Load(object sender, EventArgs e)
    {
        Action = Convert.ToString(Request.QueryString["Action"]);

        switch (Action)
        {
            case "DelSelectAlarm":
                DelSelectAlarm();
                break;

            default:
                break;
        }
    }
    /// <summary>
    /// 更新一条数据，设为可用
    /// </summary>
    private void DelSelectAlarm()
    {
        int selectalarmListID = Convert.ToInt32(Request.QueryString["SelectAlarmID"]);
        SelectAlarmList selectalarmlist = new SelectAlarmList();

        selectalarmlist.LoadData(selectalarmListID);
        selectalarmlist.Delete();

        Response.Redirect(Request.UrlReferrer.ToString());
    }
}