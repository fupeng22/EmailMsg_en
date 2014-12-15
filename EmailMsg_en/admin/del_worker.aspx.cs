using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ComputerRepair.BusinessLogicLayer;
using ComputerRepair.DataAccessHelper;

public partial class admin_del_worker : System.Web.UI.Page
{
    public string Action;
    protected void Page_Load(object sender, EventArgs e)
    {
        Action = Convert.ToString(Request.QueryString["Action"]);

        switch (Action)
        {
            case "DelWorker":
                DelWorker();
                break;

            default:
                break;
        }

    }
    /// <summary>
    /// 更新一条数据，设为可用
    /// </summary>
    private void DelWorker()
    {
        int workerListID = Convert.ToInt32(Request.QueryString["WorkerID"]);
        WorkerList workerlist = new WorkerList();

        workerlist.LoadData(workerListID);
        workerlist.Delete();

        Response.Redirect(Request.UrlReferrer.ToString());
    }
}