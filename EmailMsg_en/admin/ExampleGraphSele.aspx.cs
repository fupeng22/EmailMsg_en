using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class admin_ExampleGraphSele : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //加载
        if (!IsPostBack)
        {
            //绑定数据
            DataView dvlist = T_ExampleGraph.QueryExampleGraphs();
            AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
            Session["dvlist"] = dvlist;
            bindData();
        }
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bindData();
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
}