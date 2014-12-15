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

public partial class admin_group_manage : System.Web.UI.Page
{
    Database Obj = new Database();
    TreeNode tSelNode = new TreeNode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            dt = getChindNode("0");      //得到所有父节点,放到DATATABLE中,这里默认根节点的父节点为 0
            BindNode(dt, TreeView1.Nodes);         //绑定所有的父节点

        }
        this.TreeView1.ExpandAll(); //展开所有节点

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("group_add.aspx");
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
    protected void Button2_Click(object sender, EventArgs e)
    {
        //Response.Write("<script> function deleteitem(tree)  </script>");
        string selectItem;
        selectItem = TreeView1.SelectedValue;
        //int node = TreeView1.SelectedNode.Index;
        tSelNode = TreeView1.SelectedNode;
        GroupList grouplist = new GroupList();
        if (TreeView1.SelectedValue == "")
        {
            Response.Write("<script language=javascript>alert('Please select one node for delete !')</script>");
        }
        else
        {
            if (TreeView1.SelectedNode.ChildNodes.Count != 0)
            {
                Response.Write("<script language=javascript>alert('This node has child nodes ！')</script>");
            }
            else
            {
                //判断该节点下是否有设备或工作人员
                WorkerList workerlist = new WorkerList();
                workerlist.LoadDataGroup(selectItem);
                if (workerlist.Exist)
                {
                    Response.Write("<script language=javascript>alert('There has staff belong to this node ！')</script>");
                }
                else
                {
                    EquipmentInfoList equipmentinfolist = new EquipmentInfoList();
                    equipmentinfolist.LoadDataGroup(selectItem);
                    if (equipmentinfolist.Exist)
                    {
                        Response.Write("<script language=javascript>alert('There has equipment belong to this node ！')</script>");
                    }
                    else
                    {
                        this.TreeView1.Nodes[0].ChildNodes.Remove(tSelNode);
                        //TreeView1.Nodes.Remove(tSelNode);//删除节点
                        grouplist.Delete(selectItem);
                        TreeView1.Nodes.Clear();
                        DataTable dt = new DataTable();
                        dt = getChindNode("0");      //得到所有父节点,放到DATATABLE中,这里默认根节点的父节点为 0
                        BindNode(dt, TreeView1.Nodes);         //绑定所有的父节点
                        this.TreeView1.ExpandAll(); //展开所有节点
                    }
                }
            }

        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string selectItem;
        selectItem = TreeView1.SelectedValue;
        tSelNode = TreeView1.SelectedNode;
        GroupList grouplist = new GroupList();
        if (TreeView1.SelectedValue == "")
        {
            Response.Write("<script language=javascript>alert('Please select one node')</script>");
        }
        else
        {
            /*if (TreeView1.SelectedNode.ChildNodes.Count != 0)
            {
                Response.Write("<script language=javascript>alert('该节点存在下一级数据，无法删除！')</script>");
            }
            else
            {
                this.TreeView1.Nodes[0].ChildNodes.Remove(tSelNode);

                //TreeView1.Nodes.Remove(tSelNode);//删除节点
                grouplist.Delete(selectItem);
                TreeView1.Nodes.Clear();
                DataTable dt = new DataTable();
                dt = getChindNode("0");      //得到所有父节点,放到DATATABLE中,这里默认根节点的父节点为 0
                BindNode(dt, TreeView1.Nodes);         //绑定所有的父节点
                this.TreeView1.ExpandAll(); //展开所有节点
            }*/
            Response.Redirect("group_Info.aspx?ID=" + selectItem + "");
        }
    }

    /*public string treeLoad()
    {
        string sql = "select * from T_Group order by GroupUpID,ID";
        Database data1 = new Database();
        DataSet ds = data1.GetDataSet(sql);
        string backHtml = "";
        string id = "";

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (id == "")
            {
                id = dr["GroupUpID"].ToString();
            }
            else if (id != dr["GroupUpID"].ToString())
            {
                backHtml += "obj.closeItem(" + id + ");";
                id = dr["GroupUpID"].ToString();
            }

            backHtml += "obj.insertNewItem(" + dr["GroupUpID"].ToString() + "," + dr["ID"].ToString() + ",'" + dr["GroupName"].ToString() + "',0,0,0,0,'');";
        }

        backHtml += "obj.closeItem(" + id + ");";

        return backHtml;
    }*/
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        tSelNode = TreeView1.SelectedNode;
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("group_root_add.aspx");
    }
}