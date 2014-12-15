using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

using ComputerRepair.BusinessLogicLayer;
using ComputerRepair.DataAccessHelper;

public partial class admin_del_equipmenttype : System.Web.UI.Page
{
    public string Action;
    protected void Page_Load(object sender, EventArgs e)
    {
        Action = Convert.ToString(Request.QueryString["Action"]);

        switch (Action)
        {
            case "DelEquipmentType":
                DelEquipmentType();
                break;

            default:
                break;
        }
    }
    /// <summary>
    /// 更新一条数据，设为可用
    /// </summary>
    private void DelEquipmentType()
    {
        int equipmenttypeListID = Convert.ToInt32(Request.QueryString["EquipmentTypeID"]);
        EquipmentInfoList equipmentinfolist = new EquipmentInfoList();
        equipmentinfolist.LoadDataEquipmentType(equipmenttypeListID);
        if (equipmentinfolist.Exist)
        {
            if (DialogResult.OK == (MessageBox.Show("您删除设备类型有设备信息，无法删除！", "提示警告框", MessageBoxButtons.OKCancel)))
            {
                Response.Redirect(Request.UrlReferrer.ToString());
            }
            else
            {
                Response.Redirect(Request.UrlReferrer.ToString());
            }
        }
        else
        {
            EquipmentTypeList equipmenttypelist = new EquipmentTypeList();

            equipmenttypelist.LoadData(equipmenttypeListID);
            equipmenttypelist.Delete();
            Response.Redirect(Request.UrlReferrer.ToString());
        }
        

        
    }
}