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

public partial class admin_selectequipment_add : System.Web.UI.Page
{
    Database dbObj = new Database();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlWorkerNameBind();
        }
    }
    protected void ddlWorkerName_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlEquipmentName_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //获取用户在页面上的输入
        string workerID = this.ddlWorkerName.SelectedValue.ToString();          //人员姓名 ID
        string equipmentID = this.txtEuipmentId.Value.ToString();    //设备类型-ID

        SelectEquipmentList selectequipmentlist = new SelectEquipmentList();
        selectequipmentlist.LoadData(workerID, equipmentID);

        if (selectequipmentlist.Exist)
        {
            Response.Write("<Script Language=JavaScript>alert(\"您添加的用户名已经存在！\")</Script>");
        }
        else
        {
            Hashtable ht = new Hashtable();
            ht.Add("Worker_ID", SqlStringConstructor.GetQuotedString(workerID));
            ht.Add("Equipment_ID", SqlStringConstructor.GetQuotedString(equipmentID));

            //SelectAlarmList addworkerlist = new SelectAlarmList();
            selectequipmentlist.Add(ht);
            Response.Write("<script language=javascript>alert('添加成功')</script>");

        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("selectequipment_manage.aspx");
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