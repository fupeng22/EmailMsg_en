using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComputerRepair.DataAccessLayer;
using System.Data;
using System.Collections;
using ComputerRepair.DataAccessHelper;
using ComputerRepair.BusinessLogicLayer;

public partial class admin_equipmentinfo_update : System.Web.UI.Page
{
    Database dbObj = new Database();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string strEquipmentId=Request.QueryString["EquipmentId"];
            if (string.IsNullOrEmpty(strEquipmentId))
            {
                Response.Write("<script language=javascript>alert('Invalid parameters')</script>");
                return;
            }
            ddlEquipmentTypeBind();

            string strSql = @"select TE.*,TG.ID AS tgId,TG.GroupName from T_Equipment TE INNER JOIN
                                dbo.T_Group TG ON TE.Group_ID=TG.ID  where  TE.ID=" + strEquipmentId;
            DataSet ds = null;
            DataTable dt = null;
            ds = SqlServerHelper.Query(strSql);
            if (ds!=null)
            {
                dt=ds.Tables[0];
                if (dt!=null && dt.Rows.Count>=0)
                {
                    EquipmentName.Text=dt.Rows[0]["EquipmentName"].ToString();
                    EquipmentID.Text = dt.Rows[0]["EquipmentID"].ToString();
                    EquipmentIP.Text = dt.Rows[0]["EquipmentIP"].ToString();
                    EquipmentPort.Text = dt.Rows[0]["Equipment_PORT"].ToString();
                    hid_GroupId.Value = dt.Rows[0]["tgId"].ToString();
                    txtGroupName.Value = dt.Rows[0]["GroupName"].ToString();
                    hid_EquipmentId.Value = strEquipmentId;
                    try
                    {
                        ddlEquipmentType.SelectedValue =dt.Rows[0]["EquipmentType_ID"].ToString();
                        DropDownList2.SelectedValue = dt.Rows[0]["Equipment_Con_Type"].ToString();
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
            }
        }
    }

    public void ddlEquipmentTypeBind()
    {
        string strSql = "select * from T_EquipmentType";
        DataTable dsTable = dbObj.GetDataSetStr(strSql, "ID");
        this.ddlEquipmentType.DataSource = dsTable.DefaultView;
        this.ddlEquipmentType.DataTextField = dsTable.Columns[1].ToString();
        this.ddlEquipmentType.DataValueField = dsTable.Columns[0].ToString();
        this.ddlEquipmentType.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        ht.Add("EquipmentName", SqlStringConstructor.GetQuotedString(EquipmentName.Text));
        ht.Add("Equipment_Con_Type", SqlStringConstructor.GetQuotedString(DropDownList2.SelectedItem.Value.ToString()));
        ht.Add("EquipmentID", SqlStringConstructor.GetQuotedString(EquipmentID.Text));
        ht.Add("EquipmentIP", SqlStringConstructor.GetQuotedString(EquipmentIP.Text));
        ht.Add("Equipment_PORT", SqlStringConstructor.GetQuotedString(EquipmentPort.Text));
        ht.Add("Group_ID", SqlStringConstructor.GetQuotedString(this.hid_GroupId.Value.ToString()));
        ht.Add("EquipmentType_ID", SqlStringConstructor.GetQuotedString(ddlEquipmentType.SelectedItem.Value.ToString()));
       
        EquipmentInfoList addEquipmentInfolist = new EquipmentInfoList();
        addEquipmentInfolist.Update(ht, hid_EquipmentId.Value);
        Response.Write("<script language=javascript>alert('Edit successfully')</script>");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("equipmentinfo_manage.aspx");
    }
    protected void ddlGroupName_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlEquipmentType_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}