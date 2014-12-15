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

public partial class admin_equipmenttype_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //获取用户在页面上的输入
        string equipmentTypeName = EquipmentTypeName.Text;          //设备类型的名称

        EquipmentTypeList equipmenttypelist = new EquipmentTypeList();
        equipmenttypelist.LoadData(equipmentTypeName);

        if (equipmenttypelist.Exist)
        {
            Response.Write("<Script Language=JavaScript>alert(\"You add the device type name already exists！\")</Script>");
        }
        else
        {
            Hashtable ht = new Hashtable();
            ht.Add("EquipmentTypeName", SqlStringConstructor.GetQuotedString(EquipmentTypeName.Text));
            EquipmentTypeList addalarmlist = new EquipmentTypeList();
            equipmenttypelist.Add(ht);
            Response.Write("<script language=javascript>alert('Added successfully')</script>");

        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("equipmenttype_manage.aspx");
    }
}