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

public partial class admin_group_Info : System.Web.UI.Page
{
    Database dbObj = new Database();
    protected void Page_Load(object sender, EventArgs e)
    {
        //加载
        if (!IsPostBack)
        {
            GetGoodsInfo();//指定信息
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //获取用户在页面上的输入
        string groupName = GroupName.Text;          //

        GroupList grouplist = new GroupList();
        grouplist.LoadData(groupName);

        if (grouplist.Exist)
        {
            Response.Write("<Script Language=JavaScript>alert(\"The name you modify already exists！\")</Script>");
        }
        else
        {
            grouplist.ID = Convert.ToInt32(ShowGroupID.Text);

            Hashtable ht = new Hashtable();
            ht.Add("GroupName", SqlStringConstructor.GetQuotedString(GroupName.Text));

            grouplist.Update(ht);

            Response.Write("<script language=javascript>alert('Edit Successfully')</script>");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("group_manage.aspx");
    }
    public void GetGoodsInfo()
    {
        string strSql = "select * from T_Group where ID=" + Convert.ToInt32(Request["ID"].Trim());
        //SqlCommand myCmd = dbObj.GetCommandStr(strSql);
        DataTable dsTable = dbObj.GetDataSetStr(strSql, "ID");
        this.ShowGroupID.Text = dsTable.Rows[0]["ID"].ToString();
        this.GroupName.Text = dsTable.Rows[0]["GroupName"].ToString();            
    }
}