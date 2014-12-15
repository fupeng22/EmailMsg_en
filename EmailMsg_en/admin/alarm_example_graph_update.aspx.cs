using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ComputerRepair.BusinessLogicLayer;
using System.Collections;
using ComputerRepair.DataAccessHelper;

public partial class admin_alarm_example_graph_update : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string strAlarmExampleGraphId = Request.QueryString["cId"];
            if (string.IsNullOrEmpty(strAlarmExampleGraphId))
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
                            INNER JOIN dbo.T_AlarmType TAT ON TAEG.alarmTypeId = TAT.cID where TAEG.cId=" + strAlarmExampleGraphId;
            DataSet ds = null;
            DataTable dt = null;
            ds = SqlServerHelper.Query(strSql);
            if (ds != null)
            {
                dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count >= 0)
                {
                    ExampleGraphName.Value = dt.Rows[0]["graphName"].ToString();
                    AlarmTypeName.Value = dt.Rows[0]["AlarmTypeName"].ToString();
                    txtExampleGraphId.Value = dt.Rows[0]["graphId"].ToString();
                    txtAlarmTypeId.Value = dt.Rows[0]["alarmTypeId"].ToString();
                    hd_cId.Value = dt.Rows[0]["cId"].ToString();

                }
            }
        }
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
        alarmExampleGraphList.Update(ht,hd_cId.Value);
        Response.Write("<script language=javascript>alert('Edit successfully')</script>");

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("alarm_example_graph_manage.aspx");
    }
}