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

using ComputerRepair.BusinessLogicLayer;
using ComputerRepair.DataAccessHelper;

public partial class admin_equipmentinfo_manage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["pcrepair"] != null)
        {
            //加载
            if (!IsPostBack)
            {
                //绑定数据
                DataView dvlist = EquipmentInfoList.QueryEquipmentInfoLists();
                AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
                Session["dvlist"] = dvlist;
                bindData();
            }
        }
    }
    void bindData()
    {
        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = AspNetPager1.PageSize;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.DataSource = (DataView)Session["dvlist"];
        GridView1.DataSource = pds;
        GridView1.DataBind();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("equipmentinfo_add.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string mEquipmentName = Convert.ToString(EquipmentName.Text);
        string mEquipmentConType = Convert.ToString(Equipment_Con_Type.Text);
        string strSql = "";
        int iEquipmentConType;
        strSql = "Select tEquipment.ID,tEquipment.EquipmentID,tEquipment.EquipmentName,tEquipment.Equipment_Con_Type,tGroup.GroupName,tEquipmentType.EquipmentTypeName from  T_Equipment as tEquipment left join T_GROUP as tGroup on tEquipment.Group_ID=tGroup.ID left join T_EquipmentType as tEquipmentType on tEquipment.EquipmentType_ID=tEquipmentType.ID where tEquipment.IsFlage=0";
        //strSql = "Select FileListID,UserAccount,Contactor,UpFileName,FileContent,FileSize,FileType,FileClass,DownloadTimes,AddTime,FileURL,URLName From FileLists where FileListID like \'%" + keywords + "%\' or UpFileName like \'%" + keywords + "%\' or FileContent like \'%" + keywords + "%\'or URLName like \'%" + keywords + "%\' or FileClass like \'%" + keywords + "%\' order by FileListID desc,AddTime desc ";
        if (mEquipmentName.Length != 0)
        {
            strSql += "and  tEquipment.EquipmentName like \'%" + mEquipmentName + "%\' ";
        }
        if (mEquipmentConType.Length != 0)
        {
            iEquipmentConType = Int32.Parse(mEquipmentConType);
            strSql += "and  tEquipment.Equipment_Con_Type=" + iEquipmentConType;
        }

        //绑定数据
        DataView dvlist = WorkerList.QueryWorkerLists(strSql);//.QueryUserLists(strSql);
        AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
        Session["dvlist"] = dvlist;
        bindData();
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bindData();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //高亮显示指定行
            e.Row.Attributes.Add("onMouseOver", "Color=this.style.backgroundColor;this.style.backgroundColor='#FFF000'");
            e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=Color;");
            //设置审核状态，并且设置相应的颜色。
            if (e.Row.Cells[5].Text == "0")
            {
                e.Row.Cells[5].Text = StringFormat.HighLight("0:232直连", 1);
            }
            else if (e.Row.Cells[5].Text == "1")
            {
                e.Row.Cells[5].Text = StringFormat.HighLight("1:232转TCP/IP", 1);
            }
            else if (e.Row.Cells[5].Text == "2")
            {
                e.Row.Cells[5].Text = StringFormat.HighLight("2:485直连", 1);
            }
            else if (e.Row.Cells[5].Text == "3")
            {
                e.Row.Cells[5].Text = StringFormat.HighLight("3:485转TCP/IP", 1);
            }
            else if (e.Row.Cells[5].Text == "4")
            {
                e.Row.Cells[5].Text = StringFormat.HighLight("4:设备直发", 1);
            }
            else {
                e.Row.Cells[5].Text = StringFormat.HighLight("其他通信类型", 1);
            }
            //多余字　使用...显示
            //e.Row.Cells[2].Text = StringFormat.Out(e.Row.Cells[2].Text, 18);

        }
    }
}