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

public partial class admin_worker_manage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["pcrepair"] != null)
        {
            //加载
            if (!IsPostBack)
            {
                //绑定数据
                DataView dvlist = WorkerList.QueryWorkerLists();
                AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
                Session["dvlist"] = dvlist;
                bindData();
            }
        }

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("worker_add.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string mWorkerName = Convert.ToString(WorkerName.Text);
        string mGroupName = Convert.ToString(GroupName.Text);
        string strSql = "";
        strSql = "Select tWorker.ID,tWorker.WorkerName,tWorker.WorkerEmail,tGroup.GroupName from  T_WORKER as tWorker left join T_GROUP as tGroup on tWorker.Group_ID=tGroup.ID where tWorker.IsFlage=0";
        //strSql = "Select FileListID,UserAccount,Contactor,UpFileName,FileContent,FileSize,FileType,FileClass,DownloadTimes,AddTime,FileURL,URLName From FileLists where FileListID like \'%" + keywords + "%\' or UpFileName like \'%" + keywords + "%\' or FileContent like \'%" + keywords + "%\'or URLName like \'%" + keywords + "%\' or FileClass like \'%" + keywords + "%\' order by FileListID desc,AddTime desc ";
        if (mWorkerName.Length!= 0)
        {
            strSql += "and  tWorker.WorkerName like \'%" + mWorkerName + "%\' ";
        }
        if (mGroupName.Length != 0)
        {
            strSql += "and  tGroup.GroupName like \'%" + mGroupName + "%\' ";
        }
        
        //绑定数据
        DataView dvlist = WorkerList.QueryWorkerLists(strSql);//.QueryUserLists(strSql);
        AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
        Session["dvlist"] = dvlist;
        bindData();

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
}