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

public partial class admin_user_manage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["pcrepair"] != null)
        {
            //加载
            if (!IsPostBack)
            {
                //绑定数据
                DataView dvlist = UserList.QueryUserLists();
                AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
                Session["dvlist"] = dvlist;
                bindData();
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string mWorkerName = Convert.ToString(WorkerName.Text);
        string mUserName = Convert.ToString(UserName.Text);
        string strSql = "";
        strSql = "Select tUser.ID,tUser.UserName,tUser.LoginTime,tWorker.WorkerName from  T_USER as tUser left join T_WORKER as tWorker on tUser.Worker_ID=tWorker.ID where tUser.IsFlage=0";
        //strSql = "Select FileListID,UserAccount,Contactor,UpFileName,FileContent,FileSize,FileType,FileClass,DownloadTimes,AddTime,FileURL,URLName From FileLists where FileListID like \'%" + keywords + "%\' or UpFileName like \'%" + keywords + "%\' or FileContent like \'%" + keywords + "%\'or URLName like \'%" + keywords + "%\' or FileClass like \'%" + keywords + "%\' order by FileListID desc,AddTime desc ";
        if (mWorkerName.Length != 0)
        {
            strSql += "and  tWorker.WorkerName like \'%" + mWorkerName + "%\' ";
        }
        if (mUserName.Length != 0)
        {
            strSql += "and  tUser.UserName like \'%" + mUserName + "%\' ";
        }

        //绑定数据
        DataView dvlist = UserList.QueryUserLists(strSql);//.QueryUserLists(strSql);
        AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
        Session["dvlist"] = dvlist;
        bindData();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("User_add.aspx");
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