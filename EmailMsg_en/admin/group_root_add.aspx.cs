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

public partial class admin_group_root_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //获取在页面上的输入
        string groupName = GroupName.Text;          //

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
            ht.Add("GroupUpID", SqlStringConstructor.GetQuotedString("0"));

            grouplist.Add(ht);
            Response.Write("<script language=javascript>alert('Add successfully')</script>");

        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("group_manage.aspx");
    }
}