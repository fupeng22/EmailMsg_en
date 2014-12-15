using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComputerRepair.BusinessLogicLayer;
using System.Data;

public partial class admin_map_MapPotView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = null;
        DataTable dt = null;

        if (!IsPostBack)
        {
            string MapId_Org = Request.QueryString["MapId"];
            string EquipmentId = Request.QueryString["EquipmentId"];
            string MapPotId = "";
            string MapId = "";

            if (!string.IsNullOrEmpty(EquipmentId))
            {
                ds = new T_MapPots().GetMapIdByEquipmentId(Convert.ToInt32(EquipmentId));
                if (ds!=null)
                {
                    dt=ds.Tables[0];
                    if (dt!=null && dt.Rows.Count>0)
                    {
                        MapId_Org = dt.Rows[0]["MapId"].ToString();
                        MapPotId = dt.Rows[0]["Id"].ToString();
                        hid_MapPotId.Value = MapPotId;
                    }
                }
            }

            MapId = MapId_Org;
            if (string.IsNullOrEmpty(MapId))
            {
                //RegisterStartupScript("key", "<script type='text/javascript'>alert('输入参数不正确');</script>");
            }
            else
            {
                ds = null;
                dt = null;
                ds = new T_MapHeader().LoadMapInfoByMapId(Convert.ToInt32(MapId));
                if (ds != null)
                {
                    dt = ds.Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        hid_MapId.Value = dt.Rows[0]["Id"].ToString();
                        hid_MapName.Value = dt.Rows[0]["MapName"].ToString();
                        hid_MapPath.Value = dt.Rows[0]["MapPath"].ToString();
                        hid_GroupName.Value = dt.Rows[0]["GroupName"].ToString();
                    }
                }

            }

        }
    }
}