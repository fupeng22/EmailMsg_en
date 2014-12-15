using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_del_NVRInfo : System.Web.UI.Page
{
    public string Action;
    protected void Page_Load(object sender, EventArgs e)
    {
        DelNVRInfo();
    }
    /// <summary>
    /// 更新一条数据，设为可用
    /// </summary>
    private void DelNVRInfo()
    {
        int NVRInfoId = Convert.ToInt32(Request.QueryString["cId"]);
        string strsql = "delete from T_NVRInfo where cId=" + NVRInfoId + "";
        new T_NVRInfo().Delete1(strsql);

        Response.Redirect(Request.UrlReferrer.ToString());
    }
}