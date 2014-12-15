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

public partial class admin_receivemsg_Info : System.Web.UI.Page
{
    Database dbObj = new Database();
    protected void Page_Load(object sender, EventArgs e)
    {
        //加载
        if (!IsPostBack)
        {
            //绑定数据
            GetGoodsInfo();//指定信息
        }
    }
    public void GetGoodsInfo()
    {
        string strSql = "select * from V_ReceiveMsg where ID=" + Convert.ToInt32(Request["ID"].Trim());
        //SqlCommand myCmd = dbObj.GetCommandStr(strSql);
        DataTable dsTable = dbObj.GetDataSetStr(strSql, "ID");
        this.ShowReceivemsgID.Text = dsTable.Rows[0]["ID"].ToString();
        //this.ddlGroupName.SelectedValue = dsTable.Rows[0]["Group_ID"].ToString();//
        this.ReceiveMsg.Text = dsTable.Rows[0]["ReceiveMsg"].ToString();            //
        this.ReceiveTime.Text = dsTable.Rows[0]["ReceiveTime"].ToString();            //
        //if (dsTable.Rows[0]["IsResult"].ToString() == "0")
        //{
        //    this.IsResult.Text = "未处理";
        //}
        //else
        //{
        //    this.IsResult.Text = "已处理";
        //}
        this.IsResult.Text = dsTable.Rows[0]["IsResultDes"].ToString();      
       // this.IsResult.Text = dsTable.Rows[0]["IsResult"].ToString();          //
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("receivemsg_manage.aspx");
    }
}