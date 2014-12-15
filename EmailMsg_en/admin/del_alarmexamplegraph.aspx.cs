using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_del_alarmexamplegraph : System.Web.UI.Page
{
    public string Action;
    protected void Page_Load(object sender, EventArgs e)
    {
        DelAlramExampleGraph();
    }
    /// <summary>
    /// 更新一条数据，设为可用
    /// </summary>
    private void DelAlramExampleGraph()
    {
        int alarmExampleGraphId = Convert.ToInt32(Request.QueryString["cId"]);
        string strsql = "delete from T_AlarmExampleGraph where cId=" + alarmExampleGraphId + "";
        new T_AlarmExampleGraph().Delete1(strsql);

        Response.Redirect(Request.UrlReferrer.ToString());
    }
}