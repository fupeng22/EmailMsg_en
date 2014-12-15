using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComputerRepair.BusinessLogicLayer;

public partial class admin_del_examplegraph : System.Web.UI.Page
{
    public string Action;
    protected void Page_Load(object sender, EventArgs e)
    {
        DelExampleGraph();
    }
    /// <summary>
    /// 更新一条数据，设为可用
    /// </summary>
    private void DelExampleGraph()
    {
        int exampleGraphId = Convert.ToInt32(Request.QueryString["cId"]);
        string strsql = "delete from T_ExampleGraph where cId=" + exampleGraphId + "";
        new T_ExampleGraph().Delete1(strsql);
      
        Response.Redirect(Request.UrlReferrer.ToString());
    }
}