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

public partial class admin_alarm_Info : System.Web.UI.Page
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
        string alarmTypeName = AlarmTypeName.Text;          //报警类型的名称

        AlarmList alarmlist = new AlarmList();
        alarmlist.LoadData(alarmTypeName);

        if (alarmlist.Exist)
        {
            Response.Write("<Script Language=JavaScript>alert(\"You edit the alarm type name already exists！\")</Script>");
        }
        else
        {
            alarmlist.AlarmID = Convert.ToString(ShowAlarmID.Text);

            Hashtable ht = new Hashtable();
            ht.Add("AlarmTypeName", SqlStringConstructor.GetQuotedString(AlarmTypeName.Text));

            alarmlist.Update(ht);

            Response.Write("<script language=javascript>alert('Edit successfully')</script>");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("alarm_manage.aspx");

    }
    public void GetGoodsInfo()
    {
        string strSql = "select * from T_AlarmType where cID='"+Convert.ToString(Request["ID"].Trim())+"'"  ;
        //SqlCommand myCmd = dbObj.GetCommandStr(strSql);
        DataTable dsTable = dbObj.GetDataSetStr(strSql, "cID");
        this.ShowAlarmID.Text = Convert.ToString(Request["ID"].Trim());
        this.AlarmTypeName.Text = dsTable.Rows[0]["AlarmTypeName"].ToString();            //
    }
}