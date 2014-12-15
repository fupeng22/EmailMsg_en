using System;
using System.Collections;
using System.Data;

using ComputerRepair.DataAccessLayer;
using ComputerRepair.DataAccessHelper;

/// <summary>
///SelectAlarmList 的摘要说明
/// </summary>
namespace ComputerRepair.BusinessLogicLayer
{
    public class SelectAlarmList
    {
        #region 私有成员
        private int _selectalarmID;       //ID
        private string _workerName;  //人员名称
        private string _emailName;  //邮箱账号
        private int _workerID;
        private int _alarmtypeID;
        private bool _exist;		//是否存在标志

        #endregion 私有成员

        #region 属性
        public int SelectAlarmID
        {
            set
            {
                this._selectalarmID = value;
            }
            get
            {
                return this._selectalarmID;
            }
        }
        public string WorkerName
        {
            set
            {
                this._workerName = value;
            }
            get
            {
                return this._workerName;
            }
        }
        public string EmailName
        {
            set
            {
                this._emailName = value;
            }
            get
            {
                return this._emailName;
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
        public int AlarmTypeID
        {
            set
            {
                this._alarmtypeID = value;
            }
            get
            {
                return this._alarmtypeID;
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
        public SelectAlarmList()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 根据参数ListID，获取文件详细信息
        /// </summary>
        /// <param name="fileListID">使用者用户名</param>
        public void LoadData(int selectalarmListID)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select ID,Worker_ID,AlarmType_ID From T_WORKERALARM  where  ID = "
                + Convert.ToInt32(selectalarmListID);

            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询用户数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._selectalarmID = GetSafeData.ValidateDataRow_N(dr, "ID");
                this._workerID = GetSafeData.ValidateDataRow_N(dr, "Worker_ID");
                this._alarmtypeID = GetSafeData.ValidateDataRow_N(dr, "AlarmType_ID");

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
        public void LoadData(string WorkerID, string AlarmID)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            //sql = "Select tWorker.ID,tWorker.WorkerName,tWorker.WorkerEmail,tGroup.GroupName,tWorker.Group_ID from  T_WORKER as tWorker left join T_GROUP as tGroup on tWorker.Group_ID=tGroup.ID where tWorker.WorkerName="
            // + SqlStringConstructor.GetQuotedString(userAccount) + " and tGroup.GroupID= " + SqlStringConstructor.GetQuotedString(GroupID);
            sql = "Select ID,Worker_ID,AlarmType_ID From T_WORKERALARM where  Worker_ID = " + SqlStringConstructor.GetQuotedString(WorkerID) + " and AlarmType_ID= " + SqlStringConstructor.GetQuotedString(AlarmID);

            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询用户数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._selectalarmID = GetSafeData.ValidateDataRow_N(dr, "ID");
                this._workerID = GetSafeData.ValidateDataRow_N(dr, "Worker_ID");
                this._alarmtypeID = GetSafeData.ValidateDataRow_N(dr, "AlarmType_ID");

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
        /// 按ID排序,读取所有文件列表
        /// </summary>
        /// <return></return>
        public static DataView QuerySelectAlarmLists()
        {
            string strSql = "";
            strSql = "Select tWorkAlarm.ID,tWorker.WorkerName,tWorker.WorkerEmail,tAlarm.AlarmTypeName From T_WORKERALARM  as tWorkAlarm left join T_WORKER as tWorker on  tWorkAlarm.Worker_ID=tWorker.ID left join T_ALARMTYPE as tAlarm on tWorkAlarm.AlarmType_ID=tAlarm.cID  order by tWorkAlarm.ID asc  ";
            //strSql = "Select tWorker.ID,tWorker.WorkerName,tWorker.WorkerEmail,tGroup.GroupName from  T_WORKER as tWorker left join T_GROUP as tGroup on tWorker.Group_ID=tGroup.ID";
            //绑定数据
            Database db = new Database();
            return db.GetDataView(strSql);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <return></return>
        public void Add(Hashtable selectalarmLists)
        {
            Database db = new Database();           //实例化一个Database类
            db.Insert("T_WORKERALARM", selectalarmLists);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="workerListID"></param>
        public void Update(Hashtable selectalarmLists)
        {
            Database db = new Database();           //实例化一个Database类
            string strCond = "where ID = " + this._selectalarmID;
            db.Update("T_WORKERALARM", selectalarmLists, strCond);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="workerListID"></param>
        public void Delete()
        {
            string sql = "";
            sql = "Delete from T_WORKERALARM where ID = " + this._selectalarmID;
            Database db = new Database();
            db.ExecuteSQL(sql);
        }
        #endregion 方法
    }
}