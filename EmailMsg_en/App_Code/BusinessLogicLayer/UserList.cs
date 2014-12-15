/**********************************************************
 * 说明：使用者列表类UserList
 * 作者：chshnren1
 * 创建日期：02/06/2009
 * E-mail：chshnren@163.com
 *********************************************************/

using System;
using System.Collections;
using System.Data;

using ComputerRepair.DataAccessLayer;
using ComputerRepair.DataAccessHelper;
//using ComputerRepair.CommonComponent;

namespace ComputerRepair.BusinessLogicLayer
{
    /// <summary>
    /// UserList 的摘要说明。
    /// </summary>
    public class UserList
    {
        #region 私有成员

        private int _userListID;		    //使用者ID
        private string _userAccount;	    //使用者帐号
        private string _userPassword;	    //使用者密码
        private string _departmentName;	    //部门名称
        private string _contactor;	        //联系人
        private string _tel;	            //联系电话
        private string _email;	            //E-mail
        private string _address;	        //联系地址 
        private int _userLevel;		        //使用者级别
        private int _workerID;		        //人员ID
        private string _logintime;		        //登陆时间

        private bool _exist;		//是否存在标志

        #endregion 私有成员

        #region 属性

        public int UserListID
        {
            set
            {
                this._userListID = value;
            }
            get
            {
                return this._userListID;
            }
        }
        public string UserAccount
        {
            set
            {
                this._userAccount = value;
            }
            get
            {
                return this._userAccount;
            }
        }
        public string UserPassword
        {
            set
            {
                this._userPassword = value;
            }
            get
            {
                return this._userPassword;
            }
        }
        public string DepartmentName
        {
            set
            {
                this._departmentName = value;
            }
            get
            {
                return this._departmentName;
            }
        }
        public string Contactor
        {
            set
            {
                this._contactor = value;
            }
            get
            {
                return this._contactor;
            }
        }
        public string Tel
        {
            set
            {
                this._tel = value;
            }
            get
            {
                return this._tel;
            }
        }
        public string Email
        {
            set
            {
                this._email = value;
            }
            get
            {
                return this._email;
            }
        }
        public string Address
        {
            set
            {
                this._address = value;
            }
            get
            {
                return this._address;
            }
        }
        public int UserLevel
        {
            set
            {
                this._userLevel = value;
            }
            get
            {
                return this._userLevel;
            }
        }
        public int WorkerID
        {
            set
            {
                this._workerID = value;
            }
            get
            {
                return this._workerID;
            }
        }
        public string LoginTime
        {
            set
            {
                this._logintime = value;
            }
            get
            {
                return this._logintime;
            }
        }
        public bool Exist
        {
            get
            {
                return this._exist;
            }
        }

        #endregion 属性

        #region 方法

        /// <summary>
        /// 根据参数userListID，获取文件详细信息
        /// </summary>
        /// <param name="userListID">使用者用户名</param>
        public void LoadData(int userListID)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select ID,UserName,UserPassword,Worker_ID,LoginTime From T_USER where  ID = "
                + Convert.ToInt32(userListID);

            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询用户数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._userListID = GetSafeData.ValidateDataRow_N(dr, "ID");
                this._userAccount = GetSafeData.ValidateDataRow_S(dr, "UserName");
                this._userPassword = GetSafeData.ValidateDataRow_S(dr, "UserPassword");
                this._workerID = GetSafeData.ValidateDataRow_N(dr, "Worker_ID");
                this._logintime = GetSafeData.ValidateDataRow_S(dr, "LoginTime");

                this._exist = true;
            }
            else
            {
                this._exist = false;
            }
        }

        /// <summary>
        /// 根据参数userAccount，获取使用者详细信息IsAllowed=0
        /// </summary>
        /// <param name="userAccount">使用者用户名</param>
        public void LoadData(string userAccount)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select ID,UserName,UserPassword,Worker_ID,LoginTime From T_USER where  UserName = "
                + SqlStringConstructor.GetQuotedString(userAccount);

            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询用户数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._userListID = GetSafeData.ValidateDataRow_N(dr, "ID");
                this._userAccount = GetSafeData.ValidateDataRow_S(dr, "UserName");
                this._userPassword = GetSafeData.ValidateDataRow_S(dr, "UserPassword");
                this._workerID = GetSafeData.ValidateDataRow_N(dr, "Worker_ID");
                this._logintime = GetSafeData.ValidateDataRow_S(dr, "LoginTime");
                this._exist = true;
            }
            else
            {
                this._exist = false;
            }
        }

        /// <summary>
        /// 按UserListID排序,读取所有用户
        /// </summary>
        /// <return></return>
        public static DataView QueryUserLists(string strSql)
        {
            //绑定数据
            Database db = new Database();
            return db.GetDataView(strSql);
        }

        /// <summary>
        /// 按UserListID排序,读取所有用户
        /// </summary>
        /// <return></return>
        public static DataView QueryAllUserLists()
        {

            string strSql = "";
            strSql = "Select UserListID,UserAccount,UserPassword,DepartmentName,Contactor,Tel,Email,Address,UserLevel,IsAllowed From UserLists order by UserLevel desc,UserListID desc";

            //绑定数据
            Database db = new Database();
            return db.GetDataView(strSql);
        }

        /// <summary>
        ///
        /// </summary>
        /// <return></return>
        public static DataView QueryUserLists()
        {

            string strSql = "";
            strSql = "Select tUser.ID,tUser.UserName,tUser.LoginTime,tWorker.WorkerName from  T_USER as tUser left join T_WORKER as tWorker on tUser.Worker_ID=tWorker.ID order by tUser.ID desc";

            //绑定数据
            Database db = new Database();
            return db.GetDataView(strSql);
        }

        /// <summary>
        /// 按UserListID排序,读取所有用户UserLevel=1
        /// </summary>
        /// <return></return>
        public static DataView QueryUserLists1()
        {

            string strSql = "";
            strSql = "Select UserListID,UserAccount,UserPassword,DepartmentName,Contactor,Tel,Email,Address,UserLevel From UserLists where UserLevel=1 order by UserListID desc";

            //绑定数据
            Database db = new Database();
            return db.GetDataView(strSql);
        }

        /// <summary>
        /// 增加新的用户
        /// </summary>
        /// <return></return>
        public void Add(Hashtable userLists)
        {
            Database db = new Database();           //实例化一个Database类
            db.Insert("T_USER", userLists);
        }

        /// <summary>
        /// 修改用户数据
        /// </summary>
        /// <param name="userListID"></param>
        public void Update(Hashtable userLists)
        {
            Database db = new Database();           //实例化一个Database类
            string strCond = "where ID = " + this._userListID;
            db.Update("T_USER", userLists, strCond);
        }

        /// <summary>
        /// 删除用户数据
        /// </summary>
        /// <param name="userListID"></param>
        public void Delete()
        {
            string sql = "";
            sql = "Delete from T_USER where ID = " + this._userListID;

            Database db = new Database();
            db.ExecuteSQL(sql);
        }

        #endregion 方法
    }
}