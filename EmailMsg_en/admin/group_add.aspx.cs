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

public partial class admin_group_add : System.Web.UI.Page
{
    Database dbObj = new Database();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    ddlGroupUpNameBind();
        //}
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //获取在页面上的输入
        string groupName = GroupName.Text;          //
        //string GroupID = this.ddlGroupUpName.SelectedValue.ToString();    //部门名称-ID
        string GroupID = this.hid_GroupId.Value.ToString();    //部门名称-ID

        GroupList grouplist = new GroupList();
        grouplist.LoadData(groupName);

        if (grouplist.Exist)
        {
            Response.Write("<Script Language=JavaScript>alert(\"You add the Department already exists！\")</Script>");
        }
        else
        {
            Hashtable ht = new Hashtable();
            ht.Add("groupName", SqlStringConstructor.GetQuotedString(GroupName.Text));
            ht.Add("GroupUpID", SqlStringConstructor.GetQuotedString(GroupID));

            grouplist.Add(ht);
            Response.Write("<script language=javascript>alert('Added successfully')</script>");

        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("group_manage.aspx");
    }
    protected void ddlGroupUpName_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    //public void ddlGroupUpNameBind()
    //{
    //    string strSql = "select * from T_Group";
    //    DataTable dsTable = dbObj.GetDataSetStr(strSql, "ID");
    //    this.ddlGroupUpName.DataSource = dsTable.DefaultView;
    //    this.ddlGroupUpName.DataTextField = dsTable.Columns[1].ToString();
    //    this.ddlGroupUpName.DataValueField = dsTable.Columns[0].ToString();
    //    this.ddlGroupUpName.DataBind();
    //}
}