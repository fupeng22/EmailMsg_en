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

public partial class admin_NVRInfo_update : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string strNVRInfoId = Request.QueryString["cId"];
            if (string.IsNullOrEmpty(strNVRInfoId))
            {
                Response.Write("<script language=javascript>alert('Invalid parameters')</script>");
                return;
            }

            string strSql = @"SELECT  TN.cId ,
                        TN.NVRName ,
                        TN.NVRIP ,
                        TN.NVRPort ,
                        TN.GroupId ,
                        TN.UserName ,
                        TN.UserPwd ,
                        TG.GroupName
                FROM    dbo.T_NVRInfo TN
                        INNER JOIN dbo.T_Group TG ON TN.GroupId = TG.ID where TN.cId=" + strNVRInfoId;
            DataSet ds = null;
            DataTable dt = null;
            ds = SqlServerHelper.Query(strSql);
            if (ds != null)
            {
                dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count >= 0)
                {
                    NVRName.Text = dt.Rows[0]["NVRName"].ToString();
                    NVRIP.Text = dt.Rows[0]["NVRIP"].ToString();
                    NVRPort.Text = dt.Rows[0]["NVRPort"].ToString();
                    GroupName.Value = dt.Rows[0]["GroupName"].ToString();
                    hd_GroupId.Value = dt.Rows[0]["GroupId"].ToString();
                    UserName.Text = dt.Rows[0]["UserName"].ToString();
                    UserPwd.Text = dt.Rows[0]["UserPwd"].ToString();

                    hid_NVRInfoId.Value = dt.Rows[0]["cId"].ToString();
                }
            }
        }
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

        T_NVRInfo NVRInfoList = new T_NVRInfo();
        Hashtable ht = new Hashtable();
        ht.Add("NVRName", SqlStringConstructor.GetQuotedString(strNVRName));
        ht.Add("NVRIP", SqlStringConstructor.GetQuotedString(strNVRIP));
        ht.Add("NVRPort", SqlStringConstructor.GetQuotedString(strNVRPort));
        ht.Add("GroupId", SqlStringConstructor.GetQuotedString(strGroupId));
        ht.Add("UserName", SqlStringConstructor.GetQuotedString(strUserName));
        ht.Add("UserPwd", SqlStringConstructor.GetQuotedString(strUserPwd));
        NVRInfoList.Update(ht,hid_NVRInfoId.Value);
        Response.Write("<script language=javascript>alert('Edit successfully')</script>");

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("NVRInfo_manage.aspx");
    }
}