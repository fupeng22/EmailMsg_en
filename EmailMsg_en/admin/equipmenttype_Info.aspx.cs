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

public partial class admin_equipmenttype_Info : System.Web.UI.Page
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
        string equipmentTypeName = EquipmentTypeName.Text.ToString();          //设备类型的名称

        EquipmentTypeList equipmenttypelist = new EquipmentTypeList();
        equipmenttypelist.LoadData(equipmentTypeName);

        if (equipmenttypelist.Exist)
        {
            Response.Write("<Script Language=JavaScript>alert(\"You edit the device type name already exists！！\")</Script>");
        }
        else
        {
            equipmenttypelist.EquipmentTypeID = Convert.ToInt32(ShowEquipmentTypeID.Text);

            Hashtable ht = new Hashtable();
            ht.Add("EquipmentTypeName", SqlStringConstructor.GetQuotedString(EquipmentTypeName.Text));

            equipmenttypelist.Update(ht);

            Response.Write("<script language=javascript>alert('Edit successfully')</script>");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("equipmenttype_manage.aspx");
    }
    public void GetGoodsInfo()
    {
        string strSql = "select * from T_EquipmentType where ID=" + Convert.ToInt32(Request["ID"].Trim());
        //SqlCommand myCmd = dbObj.GetCommandStr(strSql);
        DataTable dsTable = dbObj.GetDataSetStr(strSql, "ID");
        this.ShowEquipmentTypeID.Text = dsTable.Rows[0]["ID"].ToString();
        this.EquipmentTypeName.Text = dsTable.Rows[0]["EquipmentTypeName"].ToString();            //
    }
}