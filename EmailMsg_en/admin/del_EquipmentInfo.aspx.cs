using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ComputerRepair.BusinessLogicLayer;
using ComputerRepair.DataAccessHelper;

public partial class admin_del_EquipmentInfo : System.Web.UI.Page
{
    public string Action;
    protected void Page_Load(object sender, EventArgs e)
    {
        Action = Convert.ToString(Request.QueryString["Action"]);

        switch (Action)
        {
            case "DelEquipmentInfo":
                DelEquipmentInfo();
                break;

            default:
                break;
        }
    }
    /// <summary>
    /// 更新一条数据，设为可用
    /// </summary>
    private void DelEquipmentInfo()
    {
        int equipmentinfoListID = Convert.ToInt32(Request.QueryString["ID"]);
        EquipmentInfoList equipmentinfolist = new EquipmentInfoList();

        equipmentinfolist.LoadData(equipmentinfoListID);
        equipmentinfolist.Delete();
        string strsql = "delete from T_WorkerEquipment where Equipment_ID=" + equipmentinfoListID + "";
        equipmentinfolist.Delete1(strsql);

        Response.Redirect(Request.UrlReferrer.ToString());
    }
}