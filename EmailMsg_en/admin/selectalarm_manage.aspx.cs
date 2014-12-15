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

public partial class admin_selectalarm_manage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["pcrepair"] != null)
        {
            //加载
            if (!IsPostBack)
            {
                //绑定数据
                DataView dvlist = SelectAlarmList.QuerySelectAlarmLists();
                AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
                Session["dvlist"] = dvlist;
                bindData();
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string mWorkerName = Convert.ToString(WorkerName.Text);
        string mAlarmName = Convert.ToString(AlarmName.Text);
        string strSql = "";
        strSql = "Select tWorkAlarm.ID,tWorker.WorkerName,tWorker.WorkerEmail,tAlarm.AlarmTypeName From T_WORKERALARM  as tWorkAlarm left join T_WORKER as tWorker on  tWorkAlarm.Worker_ID=tWorker.ID left join T_ALARMTYPE as tAlarm on tWorkAlarm.AlarmType_ID=tAlarm.cID where tWorkAlarm.IsFlage=0  ";
        //strSql = "Select FileListID,UserAccount,Contactor,UpFileName,FileContent,FileSize,FileType,FileClass,DownloadTimes,AddTime,FileURL,URLName From FileLists where FileListID like \'%" + keywords + "%\' or UpFileName like \'%" + keywords + "%\' or FileContent like \'%" + keywords + "%\'or URLName like \'%" + keywords + "%\' or FileClass like \'%" + keywords + "%\' order by FileListID desc,AddTime desc ";
        if (mWorkerName.Length != 0)
        {
            strSql += "and  tWorker.WorkerName like \'%" + mWorkerName + "%\' ";
        }
        if (mAlarmName.Length != 0)
        {
            strSql += "and  tAlarm.AlarmTypeName like \'%" + mAlarmName + "%\' ";
        }
        strSql += " order by tWorkAlarm.ID asc";

        //绑定数据
        DataView dvlist = WorkerList.QueryWorkerLists(strSql);//.QueryUserLists(strSql);
        AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
        Session["dvlist"] = dvlist;
        bindData();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("selectalarm_add.aspx");
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bindData();
    }
    void bindData()
    {
        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = AspNetPager1.PageSize;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.DataSource = (DataView)Session["dvlist"];
        GridView1.DataSource = pds;
        GridView1.DataBind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}