/**********************************************************
 * 说明：使用者列表类FileList
 * 作者：chshnren1
 * 创建日期：02/13/2009
 * E-mail：chshnren@163.com
 *********************************************************/

using System;
using System.Collections;
using System.Data;
using System.IO;

using ComputerRepair.DataAccessLayer;
using ComputerRepair.DataAccessHelper;
//using ComputerRepair.CommonComponent;

namespace ComputerRepair.BusinessLogicLayer
{
    /// <summary>
    /// FileList 的摘要说明。
    /// </summary>
    public class WorkerList
    {
        #region 私有成员

        private int _fileListID;		    //文件列表ID
        private string _userAccount;	    //发布人帐号
        private string _contactor;	        //发布人
        private string _upFileName;	        //文件名称
        private string _fileContent;	    //文件说明
        private string _fileSize;	        //文件大小
        private string _fileType;	        //文件类型
        private string _fileClasses;	    //文件分类 
        private int _downloadTimes;		    //下载次数
        private DateTime _addTime;          //上传时间

        private int     _WorkerID;
        private string  _WorkerName;
        private string  _WorkerEmial;
        private string  _GroupName;
        private int _GroupID;


        private bool _exist;		//是否存在标志

        #endregion 私有成员

        #region 属性

        public int FileListID
        {
            set
            {
                this._fileListID = value;
            }
            get
            {
                return this._fileListID;
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
        public string UpFileName
        {
            set
            {
                this._upFileName = value;
            }
            get
            {
                return this._upFileName;
            }
        }
        public string FileContent
        {
            set
            {
                this._fileContent = value;
            }
            get
            {
                return this._fileContent;
            }
        }
        public string FileSize
        {
            set
            {
                this._fileSize = value;
            }
            get
            {
                return this._fileSize;
            }
        }
        public string FileType
        {
            set
            {
                this._fileType = value;
            }
            get
            {
                return this._fileType;
            }
        }
        public string FileClasses
        {
            set
            {
                this._fileClasses = value;
            }
            get
            {
                return this._fileClasses;
            }
        }
        public int DownloadTimes
        {
            set
            {
                this._downloadTimes = value;
            }
            get
            {
                return this._downloadTimes;
            }
        }
        public DateTime AddTime
        {
            set
            {
                this._addTime = value;
            }
            get
            {
                return this._addTime;
            }
        }
        public bool Exist
        {
            get
            {
                return this._exist;
            }
        }

        public int WorkerID
        {
            set
            {
                this._WorkerID = value;
            }
            get
            {
                return this._WorkerID;
            }
        }
        public string WorkerName
        {
            set
            {
                this._WorkerName = value;
            }
            get
            {
                return this._WorkerName;
            }
        }
        public string WorkerEmail
        {
            set
            {
                this._WorkerEmial = value;
            }
            get
            {
                return this._WorkerEmial;
            }
        }
        public string GroupName
        {
            set
            {
                this._GroupName = value;
            }
            get
            {
                return this._GroupName;
            }
        }
        public int GroupID
        {
            set
            {
                this._GroupID = value;
            }
            get
            {
                return this._GroupID;
            }
        }

        #endregion 属性

        #region 方法

        /// <summary>
        /// 根据参数fileListID，获取文件详细信息
        /// </summary>
        /// <param name="fileListID">使用者用户名</param>
        public void LoadData(int workerListID)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select ID,WorkerName,WorkerEmail,Group_ID From T_WORKER where  ID = "
                + Convert.ToInt32(workerListID);

            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询用户数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._WorkerID = GetSafeData.ValidateDataRow_N(dr, "ID");
                this._WorkerName = GetSafeData.ValidateDataRow_S(dr, "WorkerName");
                this._WorkerEmial = GetSafeData.ValidateDataRow_S(dr, "WorkerEmail");
                this._GroupID = GetSafeData.ValidateDataRow_N(dr, "Group_ID");

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
        public void LoadData(string userAccount, string GroupID)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            //sql = "Select tWorker.ID,tWorker.WorkerName,tWorker.WorkerEmail,tGroup.GroupName,tWorker.Group_ID from  T_WORKER as tWorker left join T_GROUP as tGroup on tWorker.Group_ID=tGroup.ID where tWorker.WorkerName="
               // + SqlStringConstructor.GetQuotedString(userAccount) + " and tGroup.GroupID= " + SqlStringConstructor.GetQuotedString(GroupID);
            sql = "Select ID,WorkerName,WorkerEmail,Group_ID From T_WORKER where  WorkerName = " + SqlStringConstructor.GetQuotedString(userAccount) + " and Group_ID= " + SqlStringConstructor.GetQuotedString(GroupID);

            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询用户数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._WorkerID = GetSafeData.ValidateDataRow_N(dr, "ID");
                this._WorkerName = GetSafeData.ValidateDataRow_S(dr, "WorkerName");
                this._WorkerEmial = GetSafeData.ValidateDataRow_S(dr, "WorkerEmail");
                this._GroupID = GetSafeData.ValidateDataRow_N(dr, "Group_ID");

                this._exist = true;
            }
            else
            {
                //sql = "Select ID from T_GROUP where GroupName=" + SqlStringConstructor.GetQuotedString(GroupName);
                //dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询用户数据
                //if (dr != null)
                //{
                    //this._GroupID = GetSafeData.ValidateDataRow_N(dr, "ID");
                //}
                this._exist = false;
            }
        }

        /// <summary>
        /// 根据参数
        /// </summary>
        /// <param name="">使用</param>
        public void LoadDataGroup(string GroupID)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select ID,WorkerName,WorkerEmail,Group_ID From T_WORKER where  Group_ID= " + SqlStringConstructor.GetQuotedString(GroupID);

            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询用户数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._exist = true;
            }
            else
            {
                this._exist = false;
            }
        }

        /// <summary>
        /// 根据参数fileName，获取文件详细信息
        /// </summary>
        /// <param name="fileName">使用者用户名</param>
        public void LoadDataFileName(string fileName)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select FileListID,UserAccount,Contactor,UpFileName,FileContent,FileSize,FileType,FileClasses,DownloadTimes,AddTime From FileLists where UpFileName = "
                + SqlStringConstructor.GetQuotedString(fileName);

            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询用户数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._fileListID = GetSafeData.ValidateDataRow_N(dr, "FileListID");
                this._userAccount = GetSafeData.ValidateDataRow_S(dr, "UserAccount");
                this._contactor = GetSafeData.ValidateDataRow_S(dr, "Contactor");
                this._upFileName = GetSafeData.ValidateDataRow_S(dr, "UpFileName");
                this._fileContent = GetSafeData.ValidateDataRow_S(dr, "FileContent");
                this._fileSize = GetSafeData.ValidateDataRow_S(dr, "FileSize");
                this._fileType = GetSafeData.ValidateDataRow_S(dr, "FileType");
                this._fileClasses = GetSafeData.ValidateDataRow_S(dr, "FileClasses");
                this._downloadTimes = GetSafeData.ValidateDataRow_N(dr, "DownloadTimes");
                this._addTime = GetSafeData.ValidateDataRow_T(dr, "AddTime");

                this._exist = true;
            }
            else
            {
                this._exist = false;
            }
        }

        /// <summary>
        /// 按FileListID排序,读取所有文件列表
        /// </summary>
        /// <return></return>
        public static DataView QueryWorkerLists(string strSql)
        {
            //绑定数据
            Database db = new Database();
            return db.GetDataView(strSql);
        }

        /// <summary>
        /// 按FileListID排序,读取所有文件列表
        /// </summary>
        /// <return></return>
        public static DataView QueryWorkerLists()
        {

            string strSql = "";
            strSql = "Select tWorker.ID,tWorker.WorkerName,tWorker.WorkerEmail,tGroup.GroupName from  T_WORKER as tWorker left join T_GROUP as tGroup on tWorker.Group_ID=tGroup.ID";
            //绑定数据
            Database db = new Database();
            return db.GetDataView(strSql);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <return></return>
        public void Add(Hashtable WorkerLists)
        {
            Database db = new Database();           //实例化一个Database类
            db.Insert("T_WORKER", WorkerLists);
        }

        /// <summary>
        /// 修改员工数据
        /// </summary>
        /// <param name="workerListID"></param>
        public void Update(Hashtable workerLists)
        {
            Database db = new Database();           //实例化一个Database类
            string strCond = "where ID = " + this._WorkerID;
            db.Update("T_WORKER", workerLists, strCond);
        }

        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="workerListID"></param>
        public void Delete()
        {
            string sql = "";
            sql = "Delete from T_WORKER where ID = " + this._WorkerID;
            Database db = new Database();
            db.ExecuteSQL(sql);
        }
        #endregion 方法
    }
}