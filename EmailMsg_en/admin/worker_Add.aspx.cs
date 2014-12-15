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

public partial class admin_worker_Add : System.Web.UI.Page
{
    Database dbObj = new Database();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    ddlGroupNameBind();
        //}
    }
    //public void ddlGroupNameBind()
    //{
    //    string strSql = "select * from T_GROUP";
    //    DataTable dsTable = dbObj.GetDataSetStr(strSql, "GroupName");
    //    this.ddlGroupName.DataSource = dsTable.DefaultView;
    //    this.ddlGroupName.DataTextField = dsTable.Columns[1].ToString();
    //    this.ddlGroupName.DataValueField = dsTable.Columns[0].ToString();
    //    this.ddlGroupName.DataBind();
    //}
    protected void Button1_Click(object sender, EventArgs e)
    {
        //获取用户在页面上的输入
        string userAccount = WorkerName.Text;          //用户名
        string groupID = this.hid_GroupId.Value.ToString();    //部门名称-ID

        WorkerList workerlist = new WorkerList();
        workerlist.LoadData(userAccount, groupID);

        if (workerlist.Exist)
        {
            Response.Write("<Script Language=JavaScript>alert(\"You add the staff name already exists！\")</Script>");
        }
        else
        {
            Hashtable ht = new Hashtable();
            ht.Add("WorkerName", SqlStringConstructor.GetQuotedString(WorkerName.Text));
            ht.Add("Group_ID", SqlStringConstructor.GetQuotedString(groupID));
            ht.Add("WorkerEmail", SqlStringConstructor.GetQuotedString(Email.Text));
            ht.Add("WorkerPhone", SqlStringConstructor.GetQuotedString(Tel.Text));
            ht.Add("WorkerSex", SqlStringConstructor.GetQuotedString(DropDownList1.SelectedItem.Value.ToString()));
            ht.Add("WorkerAddress", SqlStringConstructor.GetQuotedString(Address.Text));
            //ht.Add("UserLevel", SqlStringConstructor.GetQuotedString(UserLevel.SelectedItem.Value));

            WorkerList addworkerlist = new WorkerList();
            addworkerlist.Add(ht);
            Response.Write("<script language=javascript>alert('Added successfully')</script>");

        }
    }
    protected void ddlGroupName_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("worker_manage.aspx");

    }
}