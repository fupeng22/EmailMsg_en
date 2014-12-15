using System;
using System.Collections;
using System.Data;

using ComputerRepair.DataAccessLayer;
using ComputerRepair.DataAccessHelper;

/// <summary>
///SelectEquipmentList 的摘要说明
/// </summary>
namespace ComputerRepair.BusinessLogicLayer
{
    public class SelectEquipmentList
    {
        #region 私有成员
        private int _selectID;       //ID
        private string _workerName;  //人员名称
        private string _emailName;  //邮箱账号
        private int _workerID;
        private int _EquipmentID;
        private string _GroupName;
        private bool _exist;		//是否存在标志

        #endregion 私有成员

        #region 属性
        public int SelectID
        {
            set
            {
                this._selectID = value;
            }
            get
            {
                return this._selectID;
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
        public int EquipmentID
        {
            set
            {
                this._EquipmentID = value;
            }
            get
            {
                return this._EquipmentID;
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
        public bool Exist
        {
            get
            {
                return this._exist;
            }
        }
        #endregion 属性
        public SelectEquipmentList()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 按ID排序,读取所有文件列表
        /// </summary>
        /// <return></return>
        public static DataView QuerySelectEquipmentLists()
        {
            string strSql = "";
            strSql = "Select tWorkEquipment.ID,tWorker.WorkerName,tWorker.WorkerEmail,tEquipment.EquipmentName,tGroup.GroupName From T_WorkerEquipment  as tWorkEquipment left join T_WORKER as tWorker on  tWorkEquipment.Worker_ID=tWorker.ID left join T_Equipment as tEquipment on tWorkEquipment.Equipment_ID=tEquipment.ID left join T_Group as tGroup on tGroup.ID=tEquipment.Group_ID  order by tWorkEquipment.ID asc  ";
            //strSql = "Select tWorker.ID,tWorker.WorkerName,tWorker.WorkerEmail,tGroup.GroupName from  T_WORKER as tWorker left join T_GROUP as tGroup on tWorker.Group_ID=tGroup.ID";
            //绑定数据
            Database db = new Database();
            return db.GetDataView(strSql);
        }

        /// <summary>
        /// 根据参数ListID，获取文件详细信息
        /// </summary>
        /// <param name="">使用者用户名</param>
        public void LoadData(int selectEquipmentListID)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select ID,Worker_ID,Equipment_ID From T_WorkerEquipment  where  ID = "
                + Convert.ToInt32(selectEquipmentListID);

            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询用户数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._selectID = GetSafeData.ValidateDataRow_N(dr, "ID");
                this._workerID = GetSafeData.ValidateDataRow_N(dr, "Worker_ID");
                this._EquipmentID = GetSafeData.ValidateDataRow_N(dr, "Equipment_ID");

                this._exist = true;
            }
            else
            {
                this._exist = false;
            }
        }

        /// <summary>
        /// 根据参数，获取使用者详细信息IsAllowed=0
        /// </summary>
        /// <param name="">使用名</param>
        public void LoadData(string WorkerID, string EquipmentID)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            //sql = "Select tWorker.ID,tWorker.WorkerName,tWorker.WorkerEmail,tGroup.GroupName,tWorker.Group_ID from  T_WORKER as tWorker left join T_GROUP as tGroup on tWorker.Group_ID=tGroup.ID where tWorker.WorkerName="
            // + SqlStringConstructor.GetQuotedString(userAccount) + " and tGroup.GroupID= " + SqlStringConstructor.GetQuotedString(GroupID);
            sql = "Select ID,Worker_ID,Equipment_ID From T_WorkerEquipment where  Worker_ID = " + SqlStringConstructor.GetQuotedString(WorkerID) + " and Equipment_ID= " + SqlStringConstructor.GetQuotedString(EquipmentID);

            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询用户数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._selectID = GetSafeData.ValidateDataRow_N(dr, "ID");
                this._workerID = GetSafeData.ValidateDataRow_N(dr, "Worker_ID");
                this._EquipmentID = GetSafeData.ValidateDataRow_N(dr, "Equipment_ID");

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
        /// 增加
        /// </summary>
        /// <return></return>
        public void Add(Hashtable selectequipmentLists)
        {
            Database db = new Database();           //实例化一个Database类
            db.Insert("T_WorkerEquipment", selectequipmentLists);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ID"></param>
        public void Delete()
        {
            string sql = "";
            sql = "Delete from T_WorkerEquipment where ID = " + this._selectID;
            Database db = new Database();
            db.ExecuteSQL(sql);
        }
    }
}