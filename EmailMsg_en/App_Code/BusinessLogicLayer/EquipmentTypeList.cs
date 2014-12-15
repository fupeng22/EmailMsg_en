using System;
using System.Collections;
using System.Data;

using ComputerRepair.DataAccessLayer;
using ComputerRepair.DataAccessHelper;

/// <summary>
///EquipmentTypeList 的摘要说明
/// </summary>
namespace ComputerRepair.BusinessLogicLayer
{
    public class EquipmentTypeList
    {
        #region 私有成员
        private int _equipmenttypeID;       //设备类型ID
        private string _equipmenttypeName;  //设备类型名称
        private bool _exist;		//是否存在标志

        #endregion 私有成员

        #region 属性
        public int EquipmentTypeID
        {
            set
            {
                this._equipmenttypeID = value;
            }
            get
            {
                return this._equipmenttypeID;
            }
        }
        public string EquipmentTypeName
        {
            set
            {
                this._equipmenttypeName = value;
            }
            get
            {
                return this._equipmenttypeName;
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
        public EquipmentTypeList()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 根据参数equipmenttypeListID，获取文件详细信息
        /// </summary>
        /// <param name="equipmenttypeListID">使用者用户名</param>
        public void LoadData(int equipmenttypeListID)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select ID,EquipmentTypeName From T_EQUIPMENTTYPE where  ID = "
                + Convert.ToInt32(equipmenttypeListID);

            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询用户数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._equipmenttypeID = GetSafeData.ValidateDataRow_N(dr, "ID");
                this._equipmenttypeName = GetSafeData.ValidateDataRow_S(dr, "EquipmentTypeName");

                this._exist = true;
            }
            else
            {
                this._exist = false;
            }
        }

        /// <summary>
        /// 根据参数EquipmentTypeName，获取使用者详细信息IsAllowed=0
        /// </summary>
        /// <param name="EquipmentTypeName">使用者用户名</param>
        public void LoadData(string EquipmentTypeName)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select ID,EquipmentTypeName From T_EQUIPMENTTYPE where  EquipmentTypeName = "
                + SqlStringConstructor.GetQuotedString(EquipmentTypeName);

            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询用户数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._equipmenttypeID = GetSafeData.ValidateDataRow_N(dr, "ID");
                this._equipmenttypeName = GetSafeData.ValidateDataRow_S(dr, "EquipmentTypeName");

                this._exist = true;
            }
            else
            {
                this._exist = false;
            }
        }

        /// <summary>
        /// 按AlarmListID排序,读取所有文件列表
        /// </summary>
        /// <return></return>
        public static DataView QueryEquipmentTypeLists()
        {

            string strSql = "";
            strSql = "Select ID,EquipmentTypeName From T_EQUIPMENTTYPE  order by ID asc";
            //strSql = "Select tWorker.ID,tWorker.WorkerName,tWorker.WorkerEmail,tGroup.GroupName from  T_WORKER as tWorker left join T_GROUP as tGroup on tWorker.Group_ID=tGroup.ID";
            //绑定数据
            Database db = new Database();
            return db.GetDataView(strSql);
        }

        /// <summary>
        /// 增加新的设备类型
        /// </summary>
        /// <return></return>
        public void Add(Hashtable EquipmentTypeLists)
        {
            Database db = new Database();           //实例化一个Database类
            db.Insert("T_EQUIPMENTTYPE", EquipmentTypeLists);
        }

        /// <summary>
        /// 修改设备类型名称
        /// </summary>
        /// <param name="equipmenttypeID"></param>
        public void Update(Hashtable equipmenttypeLists)
        {
            Database db = new Database();           //实例化一个Database类
            string strCond = "where ID = " + this._equipmenttypeID;
            db.Update("T_EQUIPMENTTYPE", equipmenttypeLists, strCond);
        }

        /// <summary>
        /// 删除设备类型
        /// </summary>
        /// <param name="workerListID"></param>
        public void Delete()
        {
            string sql = "";
            sql = "Delete from T_EQUIPMENTTYPE where ID = " + this._equipmenttypeID;
            Database db = new Database();
            db.ExecuteSQL(sql);
        }
        #endregion 方法
    }
}