using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ComputerRepair.DataAccessLayer;

public partial class admin_group_select : System.Web.UI.Page
{
    Database Obj = new Database();
    TreeNode tSelNode = new TreeNode();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadTreeData();
        }
        this.TreeView1.ExpandAll();
    }

    protected void LoadTreeData()
    {
        DataTable dt = new DataTable();
        dt = getChindNode("0");      //得到所有父节点,放到DATATABLE中,这里默认根节点的父节点为 0
        BindNode(dt, TreeView1.Nodes);         //绑定所有的父节点
    }

    /**/
    /// <summary>
    /// 调用存储过程，得到父节点的子节点,放到DataTable中
    /// </summary>
    /// <param name="ParentID"></param>
    /// <returns></returns>
    private DataTable getChindNode(string ParentID)
    {
        DataTable dt = new DataTable();
        dt = Obj.ExecuteSql1("TreeViewGetData", ParentID);
        return dt;
    }

    /**/
    /// <summary>
    /// 填充节点
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="Node"></param>
    private void BindNode(DataTable dt, TreeNodeCollection Node)
    {
        DataView dv = new DataView(dt);
        TreeNode NewNode;
        foreach (DataRowView dr in dv)
        {
            NewNode = new TreeNode();
            NewNode.Text = dr["GroupName"].ToString();
            NewNode.Value = dr["ID"].ToString();
            NewNode.NavigateUrl = "javascript:toFather('" + NewNode.Value + "','" + NewNode.Text + "'); ";
            Node.Add(NewNode);
            //NewNode.Expanded = true;
            //是否动态添加结点。
            NewNode.PopulateOnDemand = Convert.ToInt32(dr["ChildNodeCount"].ToString()) > 0;
        }
    }
    /// <summary>
    /// 填充节点事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void TreeView1_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        getDataNode(e.Node.Value, e.Node);     //点加号展开时调用.得到数据并绑定.传入点击结点ID,和点击节点对像.
    }

    private void getDataNode(string ParentID, TreeNode Node)
    {
        BindNode(getChindNode(ParentID), Node.ChildNodes);       //向结点填充数据.
    }
}