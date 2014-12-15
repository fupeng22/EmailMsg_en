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

public partial class admin_receivemsg_manage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //加载
        if (!IsPostBack)
        {
            //绑定数据
            DataView dvlist = ReceiveMsgList.QueryReceiveMsgLists();
            AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
            Session["dvlist"] = dvlist;
            bindData();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string mBeginTime = this.beginTime.Value.ToString(); //Convert.ToString(beginTime.ToString());
        string mEndTime = this.endTime.Value.ToString();// Convert.ToString(endTime.ToString());
        string strSql = "";
        if (mBeginTime == "" || mEndTime == "")
        {
            Response.Write("<script language=javascript>alert('Set the time period')</script>");
        }
        else
        {
            strSql = "Select ID,ReceiveMsg,ReceiveTime,IsResult,IsResultDes from  V_ReceiveMsg  where ReceiveTime>='" + mBeginTime + "' and ReceiveTime<='" + mEndTime + "'";
            //绑定数据
            DataView dvlist = ReceiveMsgList.QueryReceiveMsgLists(strSql);//.QueryUserLists(strSql);
            AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
            Session["dvlist"] = dvlist;
            bindData();

        }

    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bindData();
    }
    protected void rdoBtnCheckTrue_CheckedChanged(object sender, EventArgs e)
    {
        string mBeginTime = this.beginTime.Value.ToString(); //Convert.ToString(beginTime.ToString());
        string mEndTime = this.endTime.Value.ToString();// Convert.ToString(endTime.ToString());
        string strSql = "";
        if (mBeginTime == "" || mEndTime == "")
        {
            strSql = "Select ID,ReceiveMsg,ReceiveTime,IsResult,IsResultDes from  V_ReceiveMsg  where  IsResult=1";
            //绑定数据
            DataView dvlist = ReceiveMsgList.QueryReceiveMsgLists(strSql);//.QueryUserLists(strSql);
            AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
            Session["dvlist"] = dvlist;
            bindData();
        }
        else
        {
            strSql = "Select ID,ReceiveMsg,ReceiveTime,IsResult,IsResultDes from  V_ReceiveMsg  where ReceiveTime>='" + mBeginTime + "' and ReceiveTime<='" + mEndTime + "' and IsResult=1";
            //绑定数据
            DataView dvlist = ReceiveMsgList.QueryReceiveMsgLists(strSql);//.QueryUserLists(strSql);
            AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
            Session["dvlist"] = dvlist;
            bindData();

        }
    }
    protected void rdoBtnCheckFalse_CheckedChanged(object sender, EventArgs e)
    {
        string mBeginTime = this.beginTime.Value; //Convert.ToString(beginTime.ToString());
        string mEndTime = this.endTime.Value;// Convert.ToString(endTime.ToString());
        string strSql = "";
        if (mBeginTime == "" || mEndTime == "")
        {
            strSql = "Select ID,ReceiveMsg,ReceiveTime,IsResult,IsResultDes from  V_ReceiveMsg  where  IsResult=0";
            //绑定数据
            DataView dvlist = ReceiveMsgList.QueryReceiveMsgLists(strSql);//.QueryUserLists(strSql);
            AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
            Session["dvlist"] = dvlist;
            bindData();
        }
        else
        {
            strSql = "Select ID,ReceiveMsg,ReceiveTime,IsResult,IsResultDes from  V_ReceiveMsg  where ReceiveTime>='" + mBeginTime + "' and ReceiveTime<='" + mEndTime + "' and IsResult=0";
            //绑定数据
            DataView dvlist = ReceiveMsgList.QueryReceiveMsgLists(strSql);//.QueryUserLists(strSql);
            AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
            Session["dvlist"] = dvlist;
            bindData();

        }
    }
    protected void rdoBtnCheckAll_CheckedChanged(object sender, EventArgs e)
    {
        string mBeginTime = this.beginTime.Value.ToString(); //Convert.ToString(beginTime.ToString());
        string mEndTime = this.endTime.Value.ToString();// Convert.ToString(endTime.ToString());
        string strSql = "";
        if (mBeginTime == "" || mEndTime == "")
        {
            strSql = "Select ID,ReceiveMsg,ReceiveTime,IsResult,IsResultDes from  V_ReceiveMsg  ";
            //绑定数据
            DataView dvlist = ReceiveMsgList.QueryReceiveMsgLists(strSql);//.QueryUserLists(strSql);
            AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
            Session["dvlist"] = dvlist;
            bindData();
        }
        else
        {
            strSql = "Select ID,ReceiveMsg,ReceiveTime,IsResult,IsResultDes from  V_ReceiveMsg  where ReceiveTime>='" + mBeginTime + "' and ReceiveTime<='" + mEndTime + "' ";
            //绑定数据
            DataView dvlist = ReceiveMsgList.QueryReceiveMsgLists(strSql);//.QueryUserLists(strSql);
            AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
            Session["dvlist"] = dvlist;
            bindData();

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
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //高亮显示指定行
            e.Row.Attributes.Add("onMouseOver", "Color=this.style.backgroundColor;this.style.backgroundColor='#FFF000'");
            e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=Color;");
            //设置审核状态，并且设置相应的颜色。
            //if (e.Row.Cells[3].Text == "0")
            //{
            //    e.Row.Cells[3].Text = StringFormat.HighLight("未处理", 0);
            //}
            //else
            //{
            //    e.Row.Cells[3].Text = StringFormat.HighLight("已处理", 1);
            //}
            //多余字　使用...显示
            //e.Row.Cells[2].Text = StringFormat.Out(e.Row.Cells[2].Text, 18);

        }
    }
    protected void ButtonDel_Click(object sender, EventArgs e)
    {
        string mBeginTime = this.beginTime.Value.ToString(); //Convert.ToString(beginTime.ToString());
        string mEndTime = this.endTime.Value.ToString();// Convert.ToString(endTime.ToString());
        string strSql = "";
        if (mBeginTime == "" || mEndTime == "")
        {
            Response.Write("<script language=javascript>alert('Set the time period')</script>");
        }
        else
        {
            ReceiveMsgList receivemsglist = new ReceiveMsgList();
            strSql = "Delete from T_ReceiveMsg where  ReceiveTime>='" + mBeginTime + "' and ReceiveTime<='" + mEndTime + "'";
            receivemsglist.Delete1(strSql);//
            Response.Write("<script language=javascript>alert('Record deleted successfully！')</script>");

            /*strSql = "Select ID,ReceiveMsg,ReceiveTime,IsResult from  T_ReceiveMsg  where ReceiveTime>='" + mBeginTime + "' and ReceiveTime<='" + mEndTime + "'";
            //绑定数据
            DataView dvlist = ReceiveMsgList.QueryReceiveMsgLists(strSql);//.QueryUserLists(strSql);
            AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
            Session["dvlist"] = dvlist;
            bindData();*/

        }
    }
    protected void RadioButton4_CheckedChanged(object sender, EventArgs e)
    {
        string mBeginTime = this.beginTime.Value; //Convert.ToString(beginTime.ToString());
        string mEndTime = this.endTime.Value;// Convert.ToString(endTime.ToString());
        string strSql = "";
        if (mBeginTime == "" || mEndTime == "")
        {
            strSql = "Select ID,ReceiveMsg,ReceiveTime,IsResult,IsResultDes from  V_ReceiveMsg  where  IsResult=2";
            //绑定数据
            DataView dvlist = ReceiveMsgList.QueryReceiveMsgLists(strSql);//.QueryUserLists(strSql);
            AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
            Session["dvlist"] = dvlist;
            bindData();
        }
        else
        {
            strSql = "Select ID,ReceiveMsg,ReceiveTime,IsResult,IsResultDes from  V_ReceiveMsg  where ReceiveTime>='" + mBeginTime + "' and ReceiveTime<='" + mEndTime + "' and IsResult=0";
            //绑定数据
            DataView dvlist = ReceiveMsgList.QueryReceiveMsgLists(strSql);//.QueryUserLists(strSql);
            AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
            Session["dvlist"] = dvlist;
            bindData();

        }
    }
    protected void RadioButton5_CheckedChanged(object sender, EventArgs e)
    {
        string mBeginTime = this.beginTime.Value; //Convert.ToString(beginTime.ToString());
        string mEndTime = this.endTime.Value;// Convert.ToString(endTime.ToString());
        string strSql = "";
        if (mBeginTime == "" || mEndTime == "")
        {
            strSql = "Select ID,ReceiveMsg,ReceiveTime,IsResult,IsResultDes from  V_ReceiveMsg  where  IsResult=3";
            //绑定数据
            DataView dvlist = ReceiveMsgList.QueryReceiveMsgLists(strSql);//.QueryUserLists(strSql);
            AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
            Session["dvlist"] = dvlist;
            bindData();
        }
        else
        {
            strSql = "Select ID,ReceiveMsg,ReceiveTime,IsResult,IsResultDes from  V_ReceiveMsg  where ReceiveTime>='" + mBeginTime + "' and ReceiveTime<='" + mEndTime + "' and IsResult=0";
            //绑定数据
            DataView dvlist = ReceiveMsgList.QueryReceiveMsgLists(strSql);//.QueryUserLists(strSql);
            AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
            Session["dvlist"] = dvlist;
            bindData();

        }
    }
    protected void RadioButton6_CheckedChanged(object sender, EventArgs e)
    {
        string mBeginTime = this.beginTime.Value; //Convert.ToString(beginTime.ToString());
        string mEndTime = this.endTime.Value;// Convert.ToString(endTime.ToString());
        string strSql = "";
        if (mBeginTime == "" || mEndTime == "")
        {
            strSql = "Select ID,ReceiveMsg,ReceiveTime,IsResult,IsResultDes from  V_ReceiveMsg  where  IsResult=4";
            //绑定数据
            DataView dvlist = ReceiveMsgList.QueryReceiveMsgLists(strSql);//.QueryUserLists(strSql);
            AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
            Session["dvlist"] = dvlist;
            bindData();
        }
        else
        {
            strSql = "Select ID,ReceiveMsg,ReceiveTime,IsResult,IsResultDes from  V_ReceiveMsg  where ReceiveTime>='" + mBeginTime + "' and ReceiveTime<='" + mEndTime + "' and IsResult=0";
            //绑定数据
            DataView dvlist = ReceiveMsgList.QueryReceiveMsgLists(strSql);//.QueryUserLists(strSql);
            AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
            Session["dvlist"] = dvlist;
            bindData();

        }
    }
}