using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

using ComputerRepair.BusinessLogicLayer;
using ComputerRepair.DataAccessHelper;
using ComputerRepair.DataAccessLayer;

public partial class admin_alarm_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //获取用户在页面上的输入
        string alarmTypeName = AlarmTypeName.Text;          //报警类型的名称
        string alarmTypeID = ID.Text;

        AlarmList alarmlist = new AlarmList();
        alarmlist.LoadData(alarmTypeName);

        if (alarmlist.Exist)
        {
            Response.Write("<Script Language=JavaScript>alert(\"You add the alarm type name already exists！\")</Script>");
        }
        else
        {
            alarmlist.LoadData(alarmTypeID);
            if (alarmlist.Exist)
            {
                Response.Write("<Script Language=JavaScript>alert(\"You add the alarm type ID number already exists！\")</Script>");
            }
            else
            {
                Hashtable ht = new Hashtable();
                ht.Add("cID", SqlStringConstructor.GetQuotedString(ID.Text));
                ht.Add("AlarmTypeName", SqlStringConstructor.GetQuotedString(AlarmTypeName.Text));
                AlarmList addalarmlist = new AlarmList();
                addalarmlist.Add(ht);
                Response.Write("<script language=javascript>alert('Added successfully')</script>");
            }

        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("alarm_manage.aspx");
    }
}