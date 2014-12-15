using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ComputerRepair.BusinessLogicLayer;
using ComputerRepair.DataAccessHelper;

public partial class admin_del_user : System.Web.UI.Page
{
    public string Action;
    protected void Page_Load(object sender, EventArgs e)
    {
        Action = Convert.ToString(Request.QueryString["Action"]);

        switch (Action)
        {
            case "DelUser":
                DelUser();
                break;

            default:
                break;
        }

    }
    /// <summary>
    /// 更新一条数据，设为可用
    /// </summary>
    private void DelUser()
    {
        int userListID = Convert.ToInt32(Request.QueryString["UserID"]);
        UserList userlist = new UserList();
        userlist.LoadData(userListID);
        if (userlist.UserAccount == "admin" || 1 == userListID || userlist.UserAccount == "Admin")
        {
            Response.Write("<script language=javascript>alert('无法删除')</script>");
        }
        else
        {
            userlist.Delete();
            Response.Redirect(Request.UrlReferrer.ToString());
        }
    }
}