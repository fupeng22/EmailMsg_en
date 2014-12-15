using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComputerRepair.DataAccessLayer;
using System.Data;
using ComputerRepair.BusinessLogicLayer;
using System.Collections;
using ComputerRepair.DataAccessHelper;
using System.IO;

public partial class admin_example_graph_update : System.Web.UI.Page
{
    private const string STR_MAP_FOLDER = "~/images/tmp/";
    Database dbObj = new Database();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string strExampleGraphcId = Request.QueryString["ExampleGraphcId"];
            if (string.IsNullOrEmpty(strExampleGraphcId))
            {
                Response.Write("<script language=javascript>alert('Invalid parameters')</script>");
                return;
            }

            hid_ExamleGroupcId.Value = strExampleGraphcId;

            string strSql = @"select * from T_ExampleGraph  where  cId=" + strExampleGraphcId;
            DataSet ds = null;
            DataTable dt = null;
            ds = SqlServerHelper.Query(strSql);
            if (ds != null)
            {
                dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count >= 0)
                {
                    ExampGraphName.Text = dt.Rows[0]["graphName"].ToString();
                }
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();

        if (!Directory.Exists(Server.MapPath(STR_MAP_FOLDER)))
        {
            Directory.CreateDirectory(Server.MapPath(STR_MAP_FOLDER));
        }

        HttpPostedFile graphFile = ExampleGraphPath.PostedFile;

        if (graphFile.FileName != "")
        {
            string strFileName = "[" + DateTime.Now.ToString("yyyyMMddHHmmss") + (new Random()).Next(10).ToString("00") + "]";
            string strSourceFileNameWithExtension = graphFile.FileName.Substring(graphFile.FileName.LastIndexOf("\\") + 1);
            string strSourceFileNameWithOutExtension = strSourceFileNameWithExtension.Substring(0, strSourceFileNameWithExtension.LastIndexOf("."));
            string strSourceFileNameExtensionName = strSourceFileNameWithExtension.Substring(strSourceFileNameWithExtension.LastIndexOf(".") + 1);
            string strFullFilePath = Server.MapPath(STR_MAP_FOLDER + strSourceFileNameWithOutExtension + strFileName + "." + strSourceFileNameExtensionName);

            try
            {
                graphFile.SaveAs(strFullFilePath);

                ht.Add("graphName", SqlStringConstructor.GetQuotedString(ExampGraphName.Text.Trim()));
                ht.Add("graphPath", SqlStringConstructor.GetQuotedString("../images/tmp/" + strSourceFileNameWithOutExtension + strFileName + "." + strSourceFileNameExtensionName));
                new T_ExampleGraph().Update(ht,hid_ExamleGroupcId.Value);
                Response.Write("<script language=javascript>alert('Edit successfully')</script>");
            }
            catch(Exception ex)
            {
                Response.Write("<script language=javascript>alert('Edit failure')</script>");
            }
        }
        else
        {
            ht.Add("graphName", SqlStringConstructor.GetQuotedString(ExampGraphName.Text));
            T_ExampleGraph update_ExampleGraph = new T_ExampleGraph();
            update_ExampleGraph.Update(ht, hid_ExamleGroupcId.Value);
            Response.Write("<script language=javascript>alert('Edit successfully')</script>");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("example_graph_manage.aspx");
    }

}