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

public partial class admin_user_password : System.Web.UI.Page
{
    public string userName;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["pcrepair"] != null)
        {
            userName = Convert.ToString(Request.Cookies["pcrepair"].Values["UserAccount"]);

            //加载
            if (!IsPostBack)
            {
                //绑定数据
                bindData();
            }
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["pcrepair"] != null)
        {
            UserList userlist = new UserList();
            userlist.UserListID = Convert.ToInt32(Request.Cookies["pcrepair"].Values["UserListID"]);

            Hashtable ht = new Hashtable();
            ht.Add("UserPassword", SqlStringConstructor.GetQuotedString(UserPassword.Text));

            userlist.Update(ht);

            Response.Write("<script language=javascript>alert('Update successfully')</script>");
        }
    }
    void bindData()
    {
        UserList userlist = new UserList();
        userlist.LoadData(userName);

        if (userlist.Exist)
        {
            this.ShowUserName.Text = userlist.UserAccount;
            this.UserPassword.Text = userlist.UserPassword;
        }
    }
}