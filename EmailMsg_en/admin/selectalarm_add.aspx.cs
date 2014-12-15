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

public partial class admin_selectalarm_add : System.Web.UI.Page
{
    Database dbObj = new Database();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlWorkerNameBind();
            ddlAlarmNameBind();
        }
    }
    protected void ddlWorkerName_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlAlarmName_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //获取用户在页面上的输入
        string workerID= this.ddlWorkerName.SelectedValue.ToString();          //人员姓名 ID
        string alarmID = this.ddlAlarmName.SelectedValue.ToString();    //报警类型-ID

        SelectAlarmList selectalarmlist = new SelectAlarmList();
        selectalarmlist.LoadData(workerID, alarmID);

        if (selectalarmlist.Exist)
        {
            Response.Write("<Script Language=JavaScript>alert(\"您添加的用户名已经存在！\")</Script>");
        }
        else
        {
            Hashtable ht = new Hashtable();
            ht.Add("Worker_ID", SqlStringConstructor.GetQuotedString(workerID));
            ht.Add("AlarmType_ID", SqlStringConstructor.GetQuotedString(alarmID));

            //SelectAlarmList addworkerlist = new SelectAlarmList();
            selectalarmlist.Add(ht);
            Response.Write("<script language=javascript>alert('添加成功')</script>");

        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("selectalarm_manage.aspx");
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
    public void ddlAlarmNameBind()
    {
        string strSql = "select cID,AlarmTypeName from T_ALARMTYPE";
        DataTable dsTable = dbObj.GetDataSetStr(strSql, "AlarmTypeName");
        this.ddlAlarmName.DataSource = dsTable.DefaultView;
        this.ddlAlarmName.DataTextField = dsTable.Columns[1].ToString();
        this.ddlAlarmName.DataValueField = dsTable.Columns[0].ToString();
        this.ddlAlarmName.DataBind();
    }
}