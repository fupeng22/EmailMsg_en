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

public partial class admin_worker_Info : System.Web.UI.Page
{
    Database dbObj = new Database();
    protected void Page_Load(object sender, EventArgs e)
    {
        //加载
        if (!IsPostBack)
        {
            //绑定数据
            ddlGroupBind();
            GetGoodsInfo();//指定信息
        }

    }
    public void ddlGroupBind()
    {
        string strSql = "select * from T_GROUP";
        DataTable dsTable = dbObj.GetDataSetStr(strSql, "GroupName");
        this.ddlGroupName.DataSource = dsTable.DefaultView;
        this.ddlGroupName.DataTextField = dsTable.Columns[1].ToString();
        this.ddlGroupName.DataValueField = dsTable.Columns[0].ToString();
        this.ddlGroupName.DataBind();
    }
    public void GetGoodsInfo()
    {
        string strSql = "select * from T_Worker where ID=" + Convert.ToInt32(Request["ID"].Trim());
        //SqlCommand myCmd = dbObj.GetCommandStr(strSql);
        DataTable dsTable = dbObj.GetDataSetStr(strSql, "ID");
        this.ShowWorkerID.Text = dsTable.Rows[0]["ID"].ToString();
        this.ddlGroupName.SelectedValue = dsTable.Rows[0]["Group_ID"].ToString();//
        this.WorkerName.Text = dsTable.Rows[0]["WorkerName"].ToString();            //
        this.Email.Text = dsTable.Rows[0]["WorkerEmail"].ToString();            //
        this.Tel.Text = dsTable.Rows[0]["WorkerPhone"].ToString();          //
        this.Address.Text = dsTable.Rows[0]["WorkerAddress"].ToString();      //
        this.DropDownList1.SelectedValue = dsTable.Rows[0]["WorkerSex"].ToString();     //
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        WorkerList workerlist = new WorkerList();
        workerlist.WorkerID = Convert.ToInt32(ShowWorkerID.Text);

        Hashtable ht = new Hashtable();
        //ht.Add("ID", SqlStringConstructor.GetQuotedString(ShowWorkerID.Text));
        ht.Add("WorkerName", SqlStringConstructor.GetQuotedString(WorkerName.Text));
        ht.Add("Group_ID", SqlStringConstructor.GetQuotedString(this.ddlGroupName.SelectedValue.ToString()));
        ht.Add("WorkerEmail", SqlStringConstructor.GetQuotedString(Email.Text));
        ht.Add("WorkerPhone", SqlStringConstructor.GetQuotedString(Tel.Text));
        ht.Add("WorkerSex", SqlStringConstructor.GetQuotedString(DropDownList1.SelectedItem.Value.ToString()));
        ht.Add("WorkerAddress", SqlStringConstructor.GetQuotedString(Address.Text));

        workerlist.Update(ht);

        Response.Write("<script language=javascript>alert('Edit Successfully')</script>");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("worker_manage.aspx");
    }
}