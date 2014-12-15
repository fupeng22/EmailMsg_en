using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComputerRepair.BusinessLogicLayer;
using System.Data;

public partial class admin_map_MapPotPostionView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string EquipmentId = Request.QueryString["EquipmentId"];
            if (string.IsNullOrEmpty(EquipmentId))
            {
                //RegisterStartupScript("key", "<script type='text/javascript'>alert('输入参数不正确');</script>");
            }
            else
            {
                DataSet ds = null;
                DataTable dt = null;

                ds = new EquipmentInfoList().LoadMapPotInfoByEquipmentId(Convert.ToInt32(EquipmentId));
                if (ds!=null)
                {
                    dt = ds.Tables[0];
                    if (dt!=null && dt.Rows.Count>0)
                    {
                        hid_MapId.Value = dt.Rows[0]["Id"].ToString();
                        hid_MapName.Value = dt.Rows[0]["MapName"].ToString();
                        hid_MapPath.Value = dt.Rows[0]["MapPath"].ToString();
                        hid_GroupName.Value = dt.Rows[0]["GroupName"].ToString();
                        hid_MapPotId.Value = dt.Rows[0]["MapPotId"].ToString();
                    }
                }
             
            }

        }
    }
}