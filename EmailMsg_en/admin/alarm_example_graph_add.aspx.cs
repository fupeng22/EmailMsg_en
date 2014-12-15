using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using ComputerRepair.DataAccessHelper;
using System.Data;
using ComputerRepair.BusinessLogicLayer;

public partial class admin_alarm_example_graph_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //获取用户在页面上的输入
        string strExampleGraphId = txtExampleGraphId.Value;
        string strAlarmTypeId = txtAlarmTypeId.Value;

        T_AlarmExampleGraph alarmExampleGraphList = new T_AlarmExampleGraph();
        Hashtable ht = new Hashtable();
        ht.Add("graphId", SqlStringConstructor.GetQuotedString(strExampleGraphId));
        ht.Add("alarmTypeId", SqlStringConstructor.GetQuotedString(strAlarmTypeId));
        alarmExampleGraphList.Add(ht);
        Response.Write("<script language=javascript>alert('Added successfully')</script>");

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("alarm_example_graph_manage.aspx");
    }
}