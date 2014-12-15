using System;
using System.Collections;
using System.Data;

using ComputerRepair.DataAccessLayer;
using ComputerRepair.DataAccessHelper;

/// <summary>
///AlarmList 的摘要说明
/// </summary>
namespace ComputerRepair.BusinessLogicLayer
{
    public class AlarmList
    {
        #region 私有成员
        private string _alarmID;       //报警类型ID
        private string _alarmName;  //报警类型名称
        private bool _exist;		//是否存在标志

        #endregion 私有成员

        #region 属性
        public string AlarmID
        {
            set
            {
                this._alarmID = value;
            }
            get
            {
                return this._alarmID;
            }
        }
        public string AlarmName
        {
            set
            {
                this._alarmName = value;
            }
            get
            {
                return this._alarmName;
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
        public AlarmList()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

        }

        /// <summary>
        /// 根据参数alarmListID，获取文件详细信息
        /// </summary>
        /// <param name="fileListID">使用者用户名</param>
        public void LoadData1(string alarmListID)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select cID,AlarmTypeName From T_ALARMTYPE where  cID ='"+Convert.ToString(alarmListID)+"' "
                ;

            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询用户数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._alarmID = GetSafeData.ValidateDataRow_S(dr, "cID");
                this._alarmName = GetSafeData.ValidateDataRow_S(dr, "AlarmTypeName");

                this._exist = true;
            }
            else
            {
                this._exist = false;
            }
        }

        /// <summary>
        /// 根据参数AlarmName，获取使用者详细信息IsAllowed=0
        /// </summary>
        /// <param name="AlarmName">使用者用户名</param>
        public void LoadData(string AlarmName)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select cID,AlarmTypeName From T_ALARMTYPE where  AlarmTypeName = "
                + SqlStringConstructor.GetQuotedString(AlarmName);

            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询用户数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._alarmID = GetSafeData.ValidateDataRow_S(dr, "cID");
                this._alarmName = GetSafeData.ValidateDataRow_S(dr, "AlarmTypeName");

                this._exist = true;
            }
            else
            {
                this._exist = false;
            }
        }

        /// <summary>
        /// 按AlarmListID排序,读取所有用户
        /// </summary>
        /// <return></return>
        public static DataView QueryAlarmLists(string strSql)
        {
            //绑定数据
            Database db = new Database();
            return db.GetDataView(strSql);
        }

        /// <summary>
        /// 按AlarmListID排序,读取所有文件列表
        /// </summary>
        /// <return></return>
        public static DataView QueryAlarmLists()
        {

            string strSql = "";
            strSql = "Select cID,AlarmTypeName From T_ALARMTYPE  ";
            //strSql = "Select tWorker.ID,tWorker.WorkerName,tWorker.WorkerEmail,tGroup.GroupName from  T_WORKER as tWorker left join T_GROUP as tGroup on tWorker.Group_ID=tGroup.ID";
            //绑定数据
            Database db = new Database();
            return db.GetDataView(strSql);
        }

        /// <summary>
        /// 增加新的报警类型
        /// </summary>
        /// <return></return>
        public void Add(Hashtable AlarmLists)
        {
            Database db = new Database();           //实例化一个Database类
            db.Insert("T_ALARMTYPE", AlarmLists);
        }

        /// <summary>
        /// 修改报警名称
        /// </summary>
        /// <param name="AlarmListID"></param>
        public void Update(Hashtable alarmLists)
        {
            Database db = new Database();           //实例化一个Database类
            string strCond = "where cID ='"+this._alarmID+"' ";
            db.Update("T_ALARMTYPE", alarmLists, strCond);
        }

        /// <summary>
        /// 删除报警类型
        /// </summary>
        /// <param name="workerListID"></param>
        public void Delete()
        {
            string sql = "";
            sql = "Delete from T_ALARMTYPE where cID ='"+this._alarmID+"'  ";
            Database db = new Database();
            db.ExecuteSQL(sql);
        }

        public void Delete1(string sql)
        {
            Database db = new Database();
            db.ExecuteSQL(sql);
        }

        #endregion 方法
    }
}