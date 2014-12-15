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
using System.Data.SqlClient;

using ComputerRepair.BusinessLogicLayer;
using ComputerRepair.DataAccessHelper;
using ComputerRepair.DataAccessLayer;

public partial class admin_User_add : System.Web.UI.Page
{
    Database dbObj = new Database();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlWorkerNameBind();
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //获取用户在页面上的输入
        string userName = UserName.Text;          //用户名
        string WorkerID = this.ddlWorkerName.SelectedValue.ToString();    //部门名称-ID

        UserList workerlist = new UserList();
        workerlist.LoadData(userName);

        if (workerlist.Exist)
        {
            Response.Write("<Script Language=JavaScript>alert(\"You add a username already exists！\")</Script>");
        }
        else
        {
            Hashtable ht = new Hashtable();
            ht.Add("UserName", SqlStringConstructor.GetQuotedString(UserName.Text));
            ht.Add("Worker_ID", SqlStringConstructor.GetQuotedString(WorkerID));
            ht.Add("UserPassword", SqlStringConstructor.GetQuotedString(UserPassword.Text));

            UserList addUserlist = new UserList();
            addUserlist.Add(ht);
            Response.Write("<script language=javascript>alert('Added successfully')</script>");

        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("user_manage.aspx");
    }
    protected void ddlWorkerName_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public void ddlWorkerNameBind()
    {
        string strSql = "select * from T_WORKER";
        DataTable dsTable = dbObj.GetDataSetStr(strSql, "WorkerName");
        this.ddlWorkerName.DataSource = dsTable.DefaultView;
        this.ddlWorkerName.DataTextField = dsTable.Columns[1].ToString();
        this.ddlWorkerName.DataValueField = dsTable.Columns[0].ToString();
        this.ddlWorkerName.DataBind();
    }
}