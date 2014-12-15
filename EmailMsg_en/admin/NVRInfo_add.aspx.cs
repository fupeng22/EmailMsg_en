using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using ComputerRepair.DataAccessHelper;

public partial class admin_NVRInfo_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //获取用户在页面上的输入
        string strNVRName = NVRName.Text;
        string strNVRIP = NVRIP.Text;
        string strNVRPort = NVRPort.Text;
        string strGroupId = hd_GroupId.Value;
        string strUserName = UserName.Text;
        string strUserPwd = UserPwd.Text;
        
        T_NVRInfo NVRInfoList = new  T_NVRInfo();
        Hashtable ht = new Hashtable();
        ht.Add("NVRName", SqlStringConstructor.GetQuotedString(strNVRName));
        ht.Add("NVRIP", SqlStringConstructor.GetQuotedString(strNVRIP));
        ht.Add("NVRPort", SqlStringConstructor.GetQuotedString(strNVRPort));
        ht.Add("GroupId", SqlStringConstructor.GetQuotedString(strGroupId));
        ht.Add("UserName", SqlStringConstructor.GetQuotedString(strUserName));
        ht.Add("UserPwd", SqlStringConstructor.GetQuotedString(strUserPwd));
        NVRInfoList.Add(ht);
        Response.Write("<script language=javascript>alert('Added successfully')</script>");

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("NVRInfo_manage.aspx");
    }
}