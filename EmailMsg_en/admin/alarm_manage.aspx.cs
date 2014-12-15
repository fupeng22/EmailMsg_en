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

public partial class admin_alarm_manage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["pcrepair"] != null)
        {
            //加载
            if (!IsPostBack)
            {
                //绑定数据
                DataView dvlist = AlarmList.QueryAlarmLists();
                AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
                Session["dvlist"] = dvlist;
                bindData();
            }
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string mAlarmTypeName = Convert.ToString(AlarmTypeName.Text);
        string mAlarmTypeID = Convert.ToString(AlarmTypeID.Text);
        string strSql = "";
        strSql = "Select cID,AlarmTypeName from  T_ALARMTYPE  where IsFlage=0";
        //strSql = "Select FileListID,UserAccount,Contactor,UpFileName,FileContent,FileSize,FileType,FileClass,DownloadTimes,AddTime,FileURL,URLName From FileLists where FileListID like \'%" + keywords + "%\' or UpFileName like \'%" + keywords + "%\' or FileContent like \'%" + keywords + "%\'or URLName like \'%" + keywords + "%\' or FileClass like \'%" + keywords + "%\' order by FileListID desc,AddTime desc ";
        if (mAlarmTypeName.Length != 0)
        {
            strSql += "and  AlarmTypeName like \'%" + mAlarmTypeName + "%\' ";
        }
        if (mAlarmTypeID.Length != 0)
        {
            strSql += "and  cID like \'%" + mAlarmTypeID + "%\' ";
        }

        //绑定数据
        DataView dvlist = WorkerList.QueryWorkerLists(strSql);//.QueryUserLists(strSql);
        AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
        Session["dvlist"] = dvlist;
        bindData();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("alarm_add.aspx");
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