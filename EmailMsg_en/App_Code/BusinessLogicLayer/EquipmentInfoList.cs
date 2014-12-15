using System;
using System.Collections;
using System.Data;
using System.IO;

using ComputerRepair.DataAccessLayer;
using ComputerRepair.DataAccessHelper;
using System.Text;
using System.Data.SqlClient;

/// <summary>
///EquipmentInfoList 的摘要说明
/// </summary>
namespace ComputerRepair.BusinessLogicLayer
{
    public class EquipmentInfoList
    {
        #region 私有成员

        private int _ID;
        private string _EquipmentID;
        private string _EquipmentName;
        private string _GroupName;
        private string _EquipmentTypeName;
        private int _Equipment_Con_Type;


        private bool _exist;		//是否存在标志

        #endregion 私有成员

        #region 属性

        public int ID
        {
            set
            {
                this._ID = value;
            }
            get
            {
                return this._ID;
            }
        }
        public string EquipmentID
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
        public string EquipmentName
        {
            set
            {
                this._EquipmentName = value;
            }
            get
            {
                return this._EquipmentName;
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
        public string EquipmentTypeName
        {
            set
            {
                this._EquipmentTypeName = value;
            }
            get
            {
                return this._EquipmentTypeName;
            }
        }
        public int Equipment_Con_Type
        {
            set
            {
                this._Equipment_Con_Type = value;
            }
            get
            {
                return this._Equipment_Con_Type;
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

        public const string strFileds = "EquipmentName,ID";

        public EquipmentInfoList()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 根据参数equipmentinfoListID，获取文件详细信息
        /// </summary>
        /// <param name="equipmenttypeListID">使用者用户名</param>
        public void LoadData(int equipmentinfoListID)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select * From T_Equipment where  ID = "
                + Convert.ToInt32(equipmentinfoListID);

            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询用户数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._ID = GetSafeData.ValidateDataRow_N(dr, "ID");
                this._EquipmentID = GetSafeData.ValidateDataRow_S(dr, "EquipmentID");
                this._EquipmentName = GetSafeData.ValidateDataRow_S(dr, "EquipmentName");
                this._Equipment_Con_Type = GetSafeData.ValidateDataRow_N(dr, "Equipment_Con_Type");

                this._exist = true;
            }
            else
            {
                this._exist = false;
            }
        }

        /// <summary>
        /// 根据参数，
        /// </summary>
        /// <param name="">使用者用户名</param>
        public void LoadDataEquipmentType(int equipmenttypeListID)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select * From T_Equipment where  EquipmentType_ID = "
                + Convert.ToInt32(equipmenttypeListID);

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
        /// 根据参数
        /// </summary>
        /// <param name="">使用</param>
        public void LoadDataGroup(string GroupID)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select * From T_Equipment where  Group_ID = "
                + Convert.ToInt32(GroupID);

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
        /// 读取所有文件列表
        /// </summary>
        /// <return></return>
        public static DataView QueryEquipmentInfoLists()
        {

            string strSql = "";
            strSql = "Select tEquipment.ID,tEquipment.EquipmentID,tEquipment.EquipmentName,tEquipment.Equipment_Con_Type,tGroup.GroupName,tEquipmentType.EquipmentTypeName from  T_Equipment as tEquipment left join T_GROUP as tGroup on tEquipment.Group_ID=tGroup.ID left join T_EquipmentType as tEquipmentType on tEquipment.EquipmentType_ID=tEquipmentType.ID";
            //绑定数据
            Database db = new Database();
            return db.GetDataView(strSql);
        }

        /// <summary>
        /// 增加新的设备信息
        /// </summary>
        /// <return></return>
        public void Add(Hashtable EquipmentInfoLists)
        {
            Database db = new Database();           //实例化一个Database类
            db.Insert("T_Equipment", EquipmentInfoLists);
        }

        /// <summary>
        /// 增加新的设备信息
        /// </summary>
        /// <return></return>
        public void Update(Hashtable EquipmentInfoLists, string Id)
        {
            Database db = new Database();           //实例化一个Database类
            db.Update("T_Equipment", EquipmentInfoLists, " where ID=" + Id);
        }

        /// <summary>
        /// 删除设备信息
        /// </summary>
        /// <param name="workerListID"></param>
        public void Delete()
        {
            string sql = "";
            sql = "Delete from T_Equipment where ID = " + this.ID;
            Database db = new Database();
            db.ExecuteSQL(sql);
        }

        public void Delete1(string sql)
        {
            Database db = new Database();
            db.ExecuteSQL(sql);
        }

        public string LoadAvialableEquipmentByMapId(int MapId)
        {
            StringBuilder sb = new StringBuilder("");
            DataSet ds = null;
            DataTable dt = null;
            string strSubGroupIds = "";
            try
            {
                //                ds = SqlServerHelper.Query(string.Format(@"SELECT  *
                //                                                            FROM    dbo.T_Equipment
                //                                                            WHERE   Group_ID IN ( SELECT    GroupId
                //                                                                                  FROM      dbo.T_MapHeader
                //                                                                                  WHERE     Id = {0} )
                //                                                                    AND ID NOT IN ( SELECT  EquipmentId
                //                                                                                    FROM    dbo.T_MapPots
                //                                                                                    WHERE   MapId IN ( SELECT   MapId
                //                                                                                                       FROM     dbo.T_MapHeader
                //                                                                                                       WHERE    GroupId IN ( SELECT
                //                                                                                                                          Group_ID
                //                                                                                                                          FROM
                //                                                                                                                          dbo.T_MapHeader
                //                                                                                                                          WHERE
                //                                                                                                                          Id = {0} ) ) )", MapId));
                strSubGroupIds = new GroupList().GetGroupSubIdsByMapId(MapId);
                if (strSubGroupIds != null)
                {
                    ds = SqlServerHelper.Query(string.Format(@"SELECT  *
                                                                FROM    dbo.T_Equipment
                                                                WHERE   Group_ID IN ( {0})
                                                                        AND ID NOT IN ( SELECT  EquipmentId
                                                                                        FROM    dbo.T_MapPots
                                                                                        WHERE   MapId IN ( SELECT   Id
                                                                                                           FROM     dbo.T_MapHeader
                                                                                                           WHERE    GroupId IN ({0} ) ) ) AND ID not in (SELECT  DISTINCT TE.ID FROM dbo.T_Equipment TE INNER JOIN
                                                                                                                dbo.T_MapPots TMP ON TE.ID=TMP.EquipmentId
                                                                                                                INNER JOIN dbo.T_MapHeader TMH ON tmh.Id=TMP.MapId )", strSubGroupIds));

                    dt = ds.Tables[0];


                    sb.Append("{");
                    sb.AppendFormat("\"total\":{0}", Convert.ToInt32(dt.Rows.Count));
                    sb.Append(",\"rows\":[");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sb.Append("{");

                        string[] strFiledArray = strFileds.Split(',');
                        for (int j = 0; j < strFiledArray.Length; j++)
                        {
                            switch (strFiledArray[j])
                            {
                                default:
                                    if (j != strFiledArray.Length - 1)
                                    {
                                        sb.AppendFormat("\"{0}\":\"{1}\",", strFiledArray[j], dt.Rows[i][strFiledArray[j]] == DBNull.Value ? "" : (dt.Rows[i][strFiledArray[j]].ToString().Replace("\n", "&nbsp;").Replace("\r\n", "&nbsp;")).Replace("\"", "&quot;").Replace("'", "&apos;"));
                                    }
                                    else
                                    {
                                        sb.AppendFormat("\"{0}\":\"{1}\"", strFiledArray[j], dt.Rows[i][strFiledArray[j]] == DBNull.Value ? "" : (dt.Rows[i][strFiledArray[j]].ToString().Replace("\n", "&nbsp;").Replace("\r\n", "&nbsp;")).Replace("\"", "&quot;").Replace("'", "&apos;"));
                                    }
                                    break;
                            }
                        }

                        if (i == dt.Rows.Count - 1)
                        {
                            sb.Append("}");
                        }
                        else
                        {
                            sb.Append("},");
                        }
                    }
                    dt = null;
                    if (sb.ToString().EndsWith(","))
                    {
                        sb = new StringBuilder(sb.ToString().Substring(0, sb.ToString().Length - 1));
                    }
                    sb.Append("]");
                    sb.Append("}");

                    sb = new StringBuilder(sb.ToString().Replace("\\", "/"));
                }

            }
            catch (Exception ex)
            {

            }

            return sb.ToString();
        }

        public string LoadAvialableEquipmentByMapId_Update(int MapId, int EquipmentId)
        {
            StringBuilder sb = new StringBuilder("");
            DataSet ds = null;
            DataTable dt = null;
            string strSubGroupIds = "";
            try
            {
                //                ds = SqlServerHelper.Query(string.Format(@"SELECT  [ID] ,
                //                                                                    [EquipmentID] ,
                //                                                                    [EquipmentName] ,
                //                                                                    [EquipmentIP] ,
                //                                                                    [Group_ID] ,
                //                                                                    [EquipmentType_ID] ,
                //                                                                    [Equipment_PORT] ,
                //                                                                    [Equipment_Con_Type] ,
                //                                                                    [IsFlage]
                //                                                            FROM    dbo.T_Equipment
                //                                                            WHERE   Group_ID IN ( SELECT    GroupId
                //                                                                                  FROM      dbo.T_MapHeader
                //                                                                                  WHERE     Id = {0} )
                //                                                                    AND ID NOT IN ( SELECT  EquipmentId
                //                                                                                    FROM    dbo.T_MapPots
                //                                                                                    WHERE   MapId IN ( SELECT   MapId
                //                                                                                                       FROM     dbo.T_MapHeader
                //                                                                                                       WHERE    GroupId IN ( SELECT
                //                                                                                                                          Group_ID
                //                                                                                                                          FROM
                //                                                                                                                          dbo.T_MapHeader
                //                                                                                                                          WHERE
                //                                                                                                                          Id = {0} ) ) )
                //                                                            UNION
                //                                                            SELECT  [ID] ,
                //                                                                    [EquipmentID] ,
                //                                                                    [EquipmentName] ,
                //                                                                    [EquipmentIP] ,
                //                                                                    [Group_ID] ,
                //                                                                    [EquipmentType_ID] ,
                //                                                                    [Equipment_PORT] ,
                //                                                                    [Equipment_Con_Type] ,
                //                                                                    [IsFlage]
                //                                                            FROM    dbo.T_Equipment
                //                                                            WHERE   ID = {1}", MapId, EquipmentId));
                strSubGroupIds = new GroupList().GetGroupSubIdsByMapId(MapId);
                if (strSubGroupIds != null)
                {
                    ds = SqlServerHelper.Query(string.Format(@"SELECT  [ID] ,
                                                                    [EquipmentID] ,
                                                                    [EquipmentName] ,
                                                                    [EquipmentIP] ,
                                                                    [Group_ID] ,
                                                                    [EquipmentType_ID] ,
                                                                    [Equipment_PORT] ,
                                                                    [Equipment_Con_Type] ,
                                                                    [IsFlage]
                                                            FROM    dbo.T_Equipment
                                                            WHERE   Group_ID IN ( {0})
                                                                        AND ID NOT IN ( SELECT  EquipmentId
                                                                                        FROM    dbo.T_MapPots
                                                                                        WHERE   MapId IN ( SELECT   Id
                                                                                                           FROM     dbo.T_MapHeader
                                                                                                           WHERE    GroupId IN ({0} ) ) )
                                                                        and ID not in (SELECT  DISTINCT
                                                                                                TE.ID
                                                                                        FROM    dbo.T_Equipment TE
                                                                                                INNER JOIN dbo.T_MapPots TMP ON TE.ID = TMP.EquipmentId
                                                                                                INNER JOIN dbo.T_MapHeader TMH ON tmh.Id = TMP.MapId )
                                                            UNION
                                                            SELECT  [ID] ,
                                                                    [EquipmentID] ,
                                                                    [EquipmentName] ,
                                                                    [EquipmentIP] ,
                                                                    [Group_ID] ,
                                                                    [EquipmentType_ID] ,
                                                                    [Equipment_PORT] ,
                                                                    [Equipment_Con_Type] ,
                                                                    [IsFlage]
                                                            FROM    dbo.T_Equipment
                                                            WHERE   ID = {1}", strSubGroupIds, EquipmentId));
                    dt = ds.Tables[0];


                    sb.Append("{");
                    sb.AppendFormat("\"total\":{0}", Convert.ToInt32(dt.Rows.Count));
                    sb.Append(",\"rows\":[");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sb.Append("{");

                        string[] strFiledArray = strFileds.Split(',');
                        for (int j = 0; j < strFiledArray.Length; j++)
                        {
                            switch (strFiledArray[j])
                            {
                                default:
                                    if (j != strFiledArray.Length - 1)
                                    {
                                        sb.AppendFormat("\"{0}\":\"{1}\",", strFiledArray[j], dt.Rows[i][strFiledArray[j]] == DBNull.Value ? "" : (dt.Rows[i][strFiledArray[j]].ToString().Replace("\n", "&nbsp;").Replace("\r\n", "&nbsp;")).Replace("\"", "&quot;").Replace("'", "&apos;"));
                                    }
                                    else
                                    {
                                        sb.AppendFormat("\"{0}\":\"{1}\"", strFiledArray[j], dt.Rows[i][strFiledArray[j]] == DBNull.Value ? "" : (dt.Rows[i][strFiledArray[j]].ToString().Replace("\n", "&nbsp;").Replace("\r\n", "&nbsp;")).Replace("\"", "&quot;").Replace("'", "&apos;"));
                                    }
                                    break;
                            }
                        }

                        if (i == dt.Rows.Count - 1)
                        {
                            sb.Append("}");
                        }
                        else
                        {
                            sb.Append("},");
                        }
                    }
                    dt = null;
                    if (sb.ToString().EndsWith(","))
                    {
                        sb = new StringBuilder(sb.ToString().Substring(0, sb.ToString().Length - 1));
                    }
                    sb.Append("]");
                    sb.Append("}");

                    sb = new StringBuilder(sb.ToString().Replace("\\", "/"));
                }
            }
            catch (Exception ex)
            {

            }

            return sb.ToString();
        }

        public DataSet LoadMapPotInfoByEquipmentId(int EquipmentId)
        {
            DataSet ds = null;
            string strSQL = "";
            strSQL = string.Format(@"SELECT  DISTINCT
                                            TMH.Id ,
                                            TMH.GroupId ,
                                            TMH.MapName ,
                                            tmh.MapPath ,
                                            TG.GroupName ,
                                            TMP.Id AS MapPotId 
                                    FROM    dbo.T_MapHeader TMH
                                            INNER  JOIN dbo.T_Group TG ON TMH.GroupId = TG.ID
                                            INNER JOIN dbo.T_MapPots TMP ON TMP.MapId = TMH.Id
                                            INNER JOIN ( SELECT MapId ,
                                                                EquipmentId
                                                         FROM   dbo.T_MapPots
                                                         WHERE  EquipmentId = {0}
                                                       ) T ON T.MapId = TMH.Id
                                    WHERE   T.EquipmentId = TMP.EquipmentId", EquipmentId);
            ds = SqlServerHelper.Query(strSQL);

            return ds;
        }

        public string GetData(string state)
        {
            string strResult = "";
            StringBuilder sb = new StringBuilder("");
            GroupList group = null;
            DataSet ds = null;
            DataTable dt = null;

            group = new GroupList();
            ds = group.GetGroupInfoByGroupUpId(0);
            if (ds != null)
            {
                dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    sb.Append("[");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sb.Append("{");
                        sb.AppendFormat("\"text\":\"{0}\",\"state\":\"open\",\"id\":\"{1}\",", dt.Rows[i]["GroupName"].ToString(), "Group_" + dt.Rows[i]["ID"].ToString());
                        CreateGroupJSON(dt.Rows[i]["ID"].ToString(), ref sb, state);
                        if (sb.ToString().EndsWith(","))
                        {
                            sb = new StringBuilder(sb.ToString().Substring(0, sb.ToString().Length - 1));
                        }
                        if (i == dt.Rows.Count - 1)
                        {
                            sb.Append("}");
                        }
                        else
                        {
                            sb.Append("},");
                        }

                    }
                    sb.Append("]");

                }
            }

            strResult = sb.ToString();
            return strResult;
        }

        protected string CreateGroupJSON(string GroupUpId, ref StringBuilder sb, string state)
        {
            string strResult = "";
            DataSet ds = null;
            DataTable dt = null;

            ds = new GroupList().GetGroupInfoByGroupUpId(Convert.ToInt32(GroupUpId));
            if (ds != null)
            {
                dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    sb.Append("\"children\":[");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sb.Append("{");
                        sb.AppendFormat("\"text\":\"{0}\",\"state\":\"" + state + "\",\"id\":\"{1}\",", dt.Rows[i]["GroupName"].ToString(), "Group_" + dt.Rows[i]["ID"].ToString());
                        CreateGroupJSON(dt.Rows[i]["ID"].ToString(), ref sb, state);
                        if (sb.ToString().EndsWith(","))
                        {
                            sb = new StringBuilder(sb.ToString().Substring(0, sb.ToString().Length - 1));
                        }
                        if (i == dt.Rows.Count - 1)
                        {
                            sb.Append("}");
                        }
                        else
                        {
                            sb.Append("},");
                        }
                    }

                    sb.Append("]");
                }
            }
            return strResult;
        }

        //public string GetDataWithUsers(string state)
        //{
        //    string strResult = "";
        //    StringBuilder sb = new StringBuilder("");
        //    GroupList group = null;
        //    DataSet ds = null;
        //    DataTable dt = null;

        //    DataSet dsEquipmentInfo = null;
        //    DataTable dtEquipmentInfo = null;

        //    group = new GroupList();
        //    ds = group.GetGroupInfoByGroupUpId(0);
        //    if (ds != null)
        //    {
        //        dt = ds.Tables[0];
        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            sb.Append("[");
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                sb.Append("{");
        //                sb.AppendFormat("\"text\":\"{0}\",\"state\":\"open\",\"id\":\"{1}\",\"iconCls\":\"icon-department\",", dt.Rows[i]["GroupName"].ToString(), "Group_" + dt.Rows[i]["ID"].ToString());

        //                //加载员工
        //                dsEquipmentInfo = GetEquipmentByGroupId(Convert.ToInt32(dt.Rows[i]["ID"].ToString()));
        //                if (dsEquipmentInfo != null)
        //                {
        //                    dtEquipmentInfo = dsEquipmentInfo.Tables[0];
        //                    if (dtEquipmentInfo != null && dtEquipmentInfo.Rows.Count > 0)
        //                    {
        //                        sb.Append("\"children\":[");
        //                        for (int j = 0; j < dtEquipmentInfo.Rows.Count; j++)
        //                        {
        //                            sb.Append("{");
        //                            sb.AppendFormat("\"text\":\"{0}[<font style=\'color:red;font-weight:bold\'>设备</font>]\",\"state\":\"" + state + "\",\"id\":\"{1}\",\"iconCls\":\"icon-man\",\"EquipmentName\":\"{2}\"", dtEquipmentInfo.Rows[j]["EquipmentName"].ToString(), "Equipment_" + dtEquipmentInfo.Rows[j]["ID"].ToString(), dtEquipmentInfo.Rows[j]["EquipmentName"].ToString());
        //                            sb.Append(",\"attributes\":{\"EquipmentId\":\"" + dtEquipmentInfo.Rows[j]["ID"].ToString() + "\",\"EquipmentName\":\"" + dtEquipmentInfo.Rows[j]["EquipmentName"].ToString() + "\"}");
        //                            if (j == dtEquipmentInfo.Rows.Count - 1)
        //                            {
        //                                sb.Append("}");
        //                            }
        //                            else
        //                            {
        //                                sb.Append("},");
        //                            }
        //                            //sb.Append("},");
        //                        }
        //                        sb.Append("],");
        //                    }
        //                }

        //                CreateGroupJSONWithUsers(dt.Rows[i]["ID"].ToString(), ref sb, state);
        //                if (sb.ToString().EndsWith(","))
        //                {
        //                    sb = new StringBuilder(sb.ToString().Substring(0, sb.ToString().Length - 1));
        //                }
        //                if (i == dt.Rows.Count - 1)
        //                {
        //                    sb.Append("}");
        //                }
        //                else
        //                {
        //                    sb.Append("},");
        //                }

        //            }
        //            sb.Append("]");

        //        }
        //    }

        //    strResult = sb.ToString();
        //    return strResult;
        //}

        //protected string CreateGroupJSONWithUsers(string GroupId, ref StringBuilder sb, string state)
        //{
        //    string strResult = "";
        //    DataSet ds = null;
        //    DataTable dt = null;

        //    DataSet dsEquipmentInfo = null;
        //    DataTable dtEquipmentInfo = null;

        //    ds = new GroupList().GetGroupInfoByGroupUpId(Convert.ToInt32(GroupId));
        //    if (ds != null)
        //    {
        //        dt = ds.Tables[0];
        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            sb.Append("\"children\":[");

        //            //加载员工
        //            dsEquipmentInfo = GetEquipmentByGroupId(Convert.ToInt32(GroupId));
        //            if (dsEquipmentInfo != null)
        //            {
        //                dtEquipmentInfo = dsEquipmentInfo.Tables[0];
        //                if (dtEquipmentInfo != null && dtEquipmentInfo.Rows.Count > 0)
        //                {
        //                    //sb.Append("\"children\":[");
        //                    for (int j = 0; j < dtEquipmentInfo.Rows.Count; j++)
        //                    {
        //                        sb.Append("{");
        //                        sb.AppendFormat("\"text\":\"{0}[<font style=\'color:red;font-weight:bold\'>设备</font>]\",\"state\":\"" + state + "\",\"id\":\"{1}\",\"iconCls\":\"icon-man\",\"EquipmentName\":\"{2}\"", dtEquipmentInfo.Rows[j]["EquipmentName"].ToString(), "Equipment_" + dtEquipmentInfo.Rows[j]["ID"].ToString(), dtEquipmentInfo.Rows[j]["EquipmentName"].ToString());
        //                        sb.Append(",\"attributes\":{\"EquipmentId\":\"" + dtEquipmentInfo.Rows[j]["ID"].ToString() + "\",\"EquipmentName\":\"" + dtEquipmentInfo.Rows[j]["EquipmentName"].ToString() + "\"}");
        //                        //if (j == dtUserInfo.Rows.Count - 1)
        //                        //{
        //                        //    sb.Append("}");
        //                        //}
        //                        //else
        //                        //{
        //                        //    sb.Append("},");
        //                        //}
        //                        sb.Append("},");
        //                    }
        //                    //sb.Append("],");
        //                }
        //            }

        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                //加载子部门
        //                sb.Append("{");
        //                sb.AppendFormat("\"text\":\"{0}\",\"state\":\"" + state + "\",\"id\":\"{1}\",\"iconCls\":\"icon-department\",", dt.Rows[i]["GroupName"].ToString(), "Group_" + dt.Rows[i]["ID"].ToString());

        //                //加载员工
        //                dsEquipmentInfo = GetEquipmentByGroupId(Convert.ToInt32(GroupId));
        //                if (dsEquipmentInfo != null)
        //                {
        //                    dtEquipmentInfo = dsEquipmentInfo.Tables[0];
        //                    if (dtEquipmentInfo != null && dtEquipmentInfo.Rows.Count > 0)
        //                    {
        //                        sb.Append("\"children\":[");
        //                        for (int j = 0; j < dtEquipmentInfo.Rows.Count; j++)
        //                        {
        //                            sb.Append("{");
        //                            sb.AppendFormat("\"text\":\"{0}[<font style=\'color:red;font-weight:bold\'>设备</font>]\",\"state\":\"" + state + "\",\"id\":\"{1}\",\"iconCls\":\"icon-man\",\"EquipmentName\":\"{2}\"", dtEquipmentInfo.Rows[j]["EquipmentName"].ToString(), "Equipment_" + dtEquipmentInfo.Rows[j]["ID"].ToString(), dtEquipmentInfo.Rows[j]["EquipmentName"].ToString());
        //                            sb.Append(",\"attributes\":{\"EquipmentId\":\"" + dtEquipmentInfo.Rows[j]["ID"].ToString() + "\",\"EquipmentName\":\"" + dtEquipmentInfo.Rows[j]["EquipmentName"].ToString() + "\"}");
        //                            if (j == dtEquipmentInfo.Rows.Count - 1)
        //                            {
        //                                sb.Append("}");
        //                            }
        //                            else
        //                            {
        //                                sb.Append("},");
        //                            }
        //                            //sb.Append("},");
        //                        }
        //                        sb.Append("],");
        //                    }
        //                }

        //                CreateGroupJSONWithUsers(dt.Rows[i]["ID"].ToString(), ref sb, state);
        //                if (sb.ToString().EndsWith(","))
        //                {
        //                    sb = new StringBuilder(sb.ToString().Substring(0, sb.ToString().Length - 1));
        //                }
        //                if (i == dt.Rows.Count - 1)
        //                {
        //                    sb.Append("}");
        //                }
        //                else
        //                {
        //                    sb.Append("},");
        //                }
        //            }

        //            sb.Append("]");
        //        }
        //    }
        //    return strResult;
        //}

        public string GetDataWithUsers(string state)
        {
            string strResult = "";
            StringBuilder sb = new StringBuilder("");
            GroupList group = null;
            DataSet ds = null;
            DataTable dt = null;

            DataSet dsEquipmentInfo = null;
            DataTable dtEquipmentInfo = null;

            group = new GroupList();
            ds = group.GetGroupInfoByGroupUpId(0);
            if (ds != null)
            {
                dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    sb.Append("[");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sb.Append("{");
                        sb.AppendFormat("\"text\":\"{0}\",\"state\":\"open\",\"id\":\"{1}\",\"iconCls\":\"icon-department\"", dt.Rows[i]["GroupName"].ToString(), "Group_" + dt.Rows[i]["ID"].ToString());

                        ////加载员工
                        //dsEquipmentInfo = GetEquipmentByGroupId(Convert.ToInt32(dt.Rows[i]["ID"].ToString()));
                        //if (dsEquipmentInfo != null)
                        //{
                        //    dtEquipmentInfo = dsEquipmentInfo.Tables[0];
                        //    if (dtEquipmentInfo != null && dtEquipmentInfo.Rows.Count > 0)
                        //    {
                        //        sb.Append("\"children\":[");
                        //        for (int j = 0; j < dtEquipmentInfo.Rows.Count; j++)
                        //        {
                        //            sb.Append("{");
                        //            sb.AppendFormat("\"text\":\"{0}[<font style=\'color:red;font-weight:bold\'>设备</font>]\",\"state\":\"" + state + "\",\"id\":\"{1}\",\"iconCls\":\"icon-man\",\"EquipmentName\":\"{2}\"", dtEquipmentInfo.Rows[j]["EquipmentName"].ToString(), "Equipment_" + dtEquipmentInfo.Rows[j]["ID"].ToString(), dtEquipmentInfo.Rows[j]["EquipmentName"].ToString());
                        //            sb.Append(",\"attributes\":{\"EquipmentId\":\"" + dtEquipmentInfo.Rows[j]["ID"].ToString() + "\",\"EquipmentName\":\"" + dtEquipmentInfo.Rows[j]["EquipmentName"].ToString() + "\"}");
                        //            if (j == dtEquipmentInfo.Rows.Count - 1)
                        //            {
                        //                sb.Append("}");
                        //            }
                        //            else
                        //            {
                        //                sb.Append("},");
                        //            }
                        //            //sb.Append("},");
                        //        }
                        //        sb.Append("],");
                        //    }
                        //}

                        CreateGroupJSONWithUsers(dt.Rows[i]["ID"].ToString(), ref sb, state);
                        if (sb.ToString().EndsWith(","))
                        {
                            sb = new StringBuilder(sb.ToString().Substring(0, sb.ToString().Length - 1));
                        }
                        if (i == dt.Rows.Count - 1)
                        {
                            sb.Append("}");
                        }
                        else
                        {
                            sb.Append("},");
                        }

                    }
                    sb.Append("]");

                }
            }

            strResult = sb.ToString();
            return strResult;
        }

        protected string CreateGroupJSONWithUsers(string GroupId, ref StringBuilder sb, string state)
        {
            string strResult = "";
            DataSet ds = null;
            DataTable dt = null;

            DataSet dsEquipmentInfo = null;
            DataTable dtEquipmentInfo = null;


            if (new GroupList().ExistGroupInfoByGroupUpId(Convert.ToInt32(GroupId)) || ExistEquipmentByGroupId(Convert.ToInt32(GroupId)))
            {
                sb.Append(",\"children\":[");

                //加载员工
                dsEquipmentInfo = GetEquipmentByGroupId(Convert.ToInt32(GroupId));
                if (dsEquipmentInfo != null)
                {
                    dtEquipmentInfo = dsEquipmentInfo.Tables[0];
                    if (dtEquipmentInfo != null && dtEquipmentInfo.Rows.Count > 0)
                    {
                        for (int j = 0; j < dtEquipmentInfo.Rows.Count; j++)
                        {
                            sb.Append("{");
                            sb.AppendFormat("\"text\":\"{0}[<font style=\'color:red;font-weight:bold\'>设备</font>]\",\"state\":\"" + state + "\",\"id\":\"{1}\",\"iconCls\":\"icon-man\",\"EquipmentName\":\"{2}\"", dtEquipmentInfo.Rows[j]["EquipmentName"].ToString(), "Equipment_" + dtEquipmentInfo.Rows[j]["ID"].ToString(), dtEquipmentInfo.Rows[j]["EquipmentName"].ToString());
                            sb.Append(",\"attributes\":{\"EquipmentId\":\"" + dtEquipmentInfo.Rows[j]["ID"].ToString() + "\",\"EquipmentName\":\"" + dtEquipmentInfo.Rows[j]["EquipmentName"].ToString() + "\"}");
                            sb.Append("},");
                        }
                    }
                }

                ds = new GroupList().GetGroupInfoByGroupUpId(Convert.ToInt32(GroupId));
                if (ds != null)
                {
                    dt = ds.Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            //加载子部门
                            sb.Append("{");
                            sb.AppendFormat("\"text\":\"{0}\",\"state\":\"" + state + "\",\"id\":\"{1}\",\"iconCls\":\"icon-department\"", dt.Rows[i]["GroupName"].ToString(), "Group_" + dt.Rows[i]["ID"].ToString());

                            //加载员工
                            //dsEquipmentInfo = GetEquipmentByGroupId(Convert.ToInt32(dt.Rows[i]["ID"].ToString()));
                            //if (dsEquipmentInfo != null)
                            //{
                            //    dtEquipmentInfo = dsEquipmentInfo.Tables[0];
                            //    if (dtEquipmentInfo != null && dtEquipmentInfo.Rows.Count > 0)
                            //    {
                            //        sb.Append("\"children\":[");
                            //        for (int j = 0; j < dtEquipmentInfo.Rows.Count; j++)
                            //        {
                            //            sb.Append("{");
                            //            sb.AppendFormat("\"text\":\"{0}[<font style=\'color:red;font-weight:bold\'>设备</font>]\",\"state\":\"" + state + "\",\"id\":\"{1}\",\"iconCls\":\"icon-man\",\"EquipmentName\":\"{2}\"", dtEquipmentInfo.Rows[j]["EquipmentName"].ToString(), "Equipment_" + dtEquipmentInfo.Rows[j]["ID"].ToString(), dtEquipmentInfo.Rows[j]["EquipmentName"].ToString());
                            //            sb.Append(",\"attributes\":{\"EquipmentId\":\"" + dtEquipmentInfo.Rows[j]["ID"].ToString() + "\",\"EquipmentName\":\"" + dtEquipmentInfo.Rows[j]["EquipmentName"].ToString() + "\"}");
                            //            if (j == dtEquipmentInfo.Rows.Count - 1)
                            //            {
                            //                sb.Append("}");
                            //            }
                            //            else
                            //            {
                            //                sb.Append("},");
                            //            }
                            //            //sb.Append("},");
                            //        }

                            //        CreateGroupJSONWithUsers(dt.Rows[i]["ID"].ToString(), ref sb, state);

                            //        //if (i == dt.Rows.Count - 1)
                            //        //{
                            //        //    sb.Append("}");
                            //        //}
                            //        //else
                            //        //{
                            //        //    sb.Append("},");
                            //        //}
                            //        if (i == dt.Rows.Count - 1)
                            //        {
                            //            sb.Append("}");
                            //        }
                            //        else
                            //        {
                            //            sb.Append("},");
                            //        }
                            //    }
                            //}
                            CreateGroupJSONWithUsers(dt.Rows[i]["ID"].ToString(), ref sb, state);
                            if (i == dt.Rows.Count - 1)
                            {
                                sb.Append("}");
                            }
                            else
                            {
                                sb.Append("},");
                            }

                        }

                       
                    }
                    if (sb.ToString().EndsWith(","))
                    {
                        sb = new StringBuilder(sb.ToString().Substring(0, sb.ToString().Length - 1));
                    }
                    sb.Append("]");
                }
            }


            return strResult;
        }

        public DataSet GetEquipmentByGroupId(int groupId)
        {
            DataSet ds = null;
            string strSQL = "";
            strSQL = string.Format(@"select * from T_Equipment where Group_ID={0}", groupId);
            ds = SqlServerHelper.Query(strSQL);

            return ds;
        }

        public Boolean ExistEquipmentByGroupId(int groupId)
        {
            DataSet ds = null;
            string strSQL = "";
            strSQL = string.Format(@"select count(0) from T_Equipment where Group_ID={0}", groupId);
            ds = SqlServerHelper.Query(strSQL);

            return Convert.ToInt32(ds.Tables[0].Rows[0][0]) > 0;
        }
    }
}