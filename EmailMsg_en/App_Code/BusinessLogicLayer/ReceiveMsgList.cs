using System;
using System.Collections;
using System.Data;
using System.IO;

using ComputerRepair.DataAccessLayer;
using ComputerRepair.DataAccessHelper;

namespace ComputerRepair.BusinessLogicLayer
{
    /// <summary>
    ///ReceiveMsgList 的摘要说明
    /// </summary>
    public class ReceiveMsgList
    {
        #region 私有成员

        private int _ReceiveMsgID;
        private string _ReceiveMsg;
        private string _ReceiveTime;
        private int _IsResult;

        private bool _exist;		//是否存在标志

        #endregion 私有成员

        #region 属性
        public int ReceiveMsgID
        {
            set
            {
                this._ReceiveMsgID = value;
            }
            get
            {
                return this._ReceiveMsgID;
            }
        }
        public string ReceiveMsg
        {
            set
            {
                this._ReceiveMsg = value;
            }
            get
            {
                return this._ReceiveMsg;
            }
        }
        public string ReceiveTime
        {
            set
            {
                this._ReceiveTime = value;
            }
            get
            {
                return this._ReceiveTime;
            }
        }
        public int IsResult
        {
            set
            {
                this._IsResult = value;
            }
            get
            {
                return this._IsResult;
            }
        }
        #endregion 属性
        public ReceiveMsgList()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 按ID排序,读取所有文件列表
        /// </summary>
        /// <return></return>
        public static DataView QueryReceiveMsgLists(string strSql)
        {
            //绑定数据
            Database db = new Database();
            return db.GetDataView(strSql);
        }

        /// <summary>
        /// 按排序,读取所有文件列表
        /// </summary>
        /// <return></return>
        public static DataView QueryReceiveMsgLists()
        {

            string strSql = "";
            strSql = "Select ID,ReceiveMsg,ReceiveTime,IsResult,IsResultDes from V_ReceiveMsg order by ID asc";
            //绑定数据
            Database db = new Database();
            return db.GetDataView(strSql);
        }

        public void Delete1(string sql)
        {
            Database db = new Database();
            db.ExecuteSQL(sql);
        }

        /// <summary>
        /// 根据报警记录ID复位
        /// </summary>
        /// <param name="ReceiveMsgId"></param>
        /// <returns></returns>
        public Boolean ResetAlarmToNormal(int ReceiveMsgId)
        {
            string strSql = "";
            bool bOK = false;
            strSql = string.Format(@"UPDATE T_ReceiveMsg
                                   SET ReadFlag=1
                                 WHERE  Id={0}", ReceiveMsgId);
            if (SqlServerHelper.ExecuteSql(strSql) > 0)
            {
                bOK = true;
            }
            return bOK;
        }

        /// <summary>
        /// 根据设备ID复位(该设备最新报警的记录)
        /// </summary>
        /// <param name="ReceiveMsgId"></param>
        /// <returns></returns>
        public Boolean ResetAlarmToNormalByEquipmentId(int EquipmentId)
        {
            string strSql = "";
            bool bOK = false;
            strSql = string.Format(@"UPDATE  dbo.T_ReceiveMsg
                                    SET     ReadFlag = 1
                                    WHERE   ID IN ( SELECT  MAX(ID)
                                                    FROM    dbo.T_ReceiveMsg
                                                    WHERE   EquipmentId IS NOT NULL
                                                    GROUP BY EquipmentId )
                                            AND T_ReceiveMsg.EquipmentId = {0}", EquipmentId);
            if (SqlServerHelper.ExecuteSql(strSql) > 0)
            {
                bOK = true;
            }
            return bOK;
        }
    }
}