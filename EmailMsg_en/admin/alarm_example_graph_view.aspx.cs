using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class admin_alarm_example_graph_view : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string strAlarmTypeId = Request.QueryString["AlarmTypeId"];
            if (string.IsNullOrEmpty(strAlarmTypeId))
            {
                Response.Write("<script language=javascript>alert('Invalid parameters')</script>");
                return;
            }
            string strSql = @"SELECT  TAEG.cId ,
                            TAEG.graphId ,
                            TAEG.alarmTypeId ,
                            TAT.AlarmTypeName ,
                            TE.graphName ,
                            TE.graphPath
                    FROM    dbo.T_AlarmExampleGraph TAEG
                            INNER JOIN dbo.T_ExampleGraph TE ON TAEG.graphId = TE.cId
                            INNER JOIN dbo.T_AlarmType TAT ON TAEG.alarmTypeId = TAT.cID where TAEG.alarmTypeId='" + strAlarmTypeId + "'";
            DataView dv = T_AlarmExampleGraph.QueryAlarmExampleGraphLists(strSql);
            rpt_ExampleGraph.DataSource = dv;
            rpt_ExampleGraph.DataBind();

            try
            {
                lblAlarmTypeId.Text = dv.Table.Rows[0]["alarmTypeId"].ToString();
                lblAlarmTypeName.Text = dv.Table.Rows[0]["AlarmTypeName"].ToString();
            }
            catch (Exception)
            {

            }
        }
    }
}