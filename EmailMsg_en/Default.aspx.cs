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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["CheckCode"];
        //判断验证码是否有误
        if (cookie.Value != this.txtVali.Text.Trim())
        {
            Response.Write("<script lanuage=javascript>alert('Verification code error');location='javascript:history.go(-1)'</script>");
        }
        else
        {
            //获取用户在页面上的输入
            string userAccount = this.txtUser.Text;          //用户登陆名
            string userPassword = this.txtPwd.Text;        //用户登陆密码
            UserList userlist = new UserList();
            userlist.LoadData(userAccount);
            if (userlist.Exist)
            {
                if (userlist.UserPassword == userPassword)	        //如果密码正确，转入管理员页面
                {
                    HttpCookie cookie1 = new HttpCookie("pcrepair");                             //定义cookie对象以及名为Info的项
                    DateTime dt = DateTime.Now;                                                 //定义时间对象
                    TimeSpan ts = new TimeSpan(1, 0, 0, 0);                                     //cookie有效作用时间，具体查msdn
                    cookie1.Expires = dt.Add(ts);                                                //添加作用时间
                    cookie1.Values.Add("UserListID", userlist.UserListID.ToString());             //增加属性
                    cookie1.Values.Add("UserAccount", userlist.UserAccount.ToString());          //增加属性
                    cookie1.Values.Add("WorkerID", HttpUtility.UrlEncode(userlist.WorkerID.ToString()));    //增加属性
                    cookie1.Values.Add("LoginTime", HttpUtility.UrlEncode(userlist.LoginTime.ToString()));    //增加属性
                    //cookie1.Values.Add("DepartmentName", HttpUtility.UrlEncode(userlist.DepartmentName.ToString()));    //增加属性
                    //cookie1.Values.Add("Contactor", HttpUtility.UrlEncode(userlist.Contactor.ToString()));              //增加属性
                    //cookie1.Values.Add("Tel", HttpUtility.UrlEncode(userlist.Tel.ToString()));                          //增加属性
                    //cookie1.Values.Add("Address", HttpUtility.UrlEncode(userlist.Address.ToString()));                  //增加属性
       

                    Response.AppendCookie(cookie1);                          //确定写入cookie中
                    Hashtable ht = new Hashtable();
                    ht.Add("LoginTime", SqlStringConstructor.GetQuotedString(dt.ToString()));

                    userlist.Update(ht);
                    Response.Redirect("admin/admin.aspx");


                }
                else		                                        //如果密码错误，给出提示，光标停留在密码框中
                {
                    Response.Write("<Script Language=JavaScript>alert(\"Wrong password, please enter the password again！\")</Script>");
                }
            }
            else
            {
                Response.Write("<Script Language=JavaScript>alert(\"You input the user name does not exist！\")</Script>");
            }

        }
    }
    protected void btnCancle_Click(object sender, EventArgs e)
    {

    }
}