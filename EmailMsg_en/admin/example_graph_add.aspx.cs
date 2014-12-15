using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComputerRepair.BusinessLogicLayer;
using System.Collections;
using System.IO;
using ComputerRepair.DataAccessHelper;

public partial class admin_example_graph_add : System.Web.UI.Page
{
    private const string STR_MAP_FOLDER = "~/images/tmp/";

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //获取用户在页面上的输入
        string exampleGraphName = ExampleGraphName.Text;

        T_ExampleGraph exampleGraphList = new T_ExampleGraph();

        if (!Directory.Exists(Server.MapPath(STR_MAP_FOLDER)))
        {
            Directory.CreateDirectory(Server.MapPath(STR_MAP_FOLDER));
        }

        HttpPostedFile graphFile = ExamplePath.PostedFile;

        string strFileName = "[" + DateTime.Now.ToString("yyyyMMddHHmmss") + (new Random()).Next(10).ToString("00") + "]";
        string strSourceFileNameWithExtension = graphFile.FileName.Substring(graphFile.FileName.LastIndexOf("\\") + 1);
        string strSourceFileNameWithOutExtension = strSourceFileNameWithExtension.Substring(0, strSourceFileNameWithExtension.LastIndexOf("."));
        string strSourceFileNameExtensionName = strSourceFileNameWithExtension.Substring(strSourceFileNameWithExtension.LastIndexOf(".") + 1);
        string strFullFilePath = Server.MapPath(STR_MAP_FOLDER + strSourceFileNameWithOutExtension + strFileName + "." + strSourceFileNameExtensionName);

        try
        {
            graphFile.SaveAs(strFullFilePath);
            Hashtable ht = new Hashtable();
            ht.Add("graphName", SqlStringConstructor.GetQuotedString(exampleGraphName));
            ht.Add("graphPath", SqlStringConstructor.GetQuotedString("../images/tmp/" + strSourceFileNameWithOutExtension + strFileName + "." + strSourceFileNameExtensionName));
            exampleGraphList.Add(ht);
            Response.Write("<script language=javascript>alert('Added successfully')</script>");
        }
        catch (Exception ex)
        {
            Response.Write("<script language=javascript>alert('Added failure')</script>");
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("example_graph_manage.aspx");
    }
}