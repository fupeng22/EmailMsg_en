using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_map_MapView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hid_MapId.Value = Request.QueryString["MapId"];
            hid_MapName.Value = Request.QueryString["MapName"];
            hid_MapPath.Value = Request.QueryString["MapPath"];
            hid_GroupName.Value = Request.QueryString["GroupName"];
        }
    }
}