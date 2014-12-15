using System;
using System.Collections;
using System.Data;

using ComputerRepair.DataAccessLayer;
using ComputerRepair.DataAccessHelper;
using System.Text;
using System.Data.SqlClient;

/// <summary>
///GroupList 的摘要说明
/// </summary>
namespace ComputerRepair.BusinessLogicLayer
{
    public class GroupList
    {
        public const string strFileds = "GroupId,MapName,MapPath,mMemo,GroupName,Id";
        public const string strFileds1 = "GroupId,MapName,MapDes,MapPath,mMemo,GroupName,Id";

        #region 私有成员
        private int _ID;       //ID
        private string _groupName;  //名称
        private int _groupUpID;  //名称
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
        public string GroupName
        {
            set
            {
                this._groupName = value;
            }
            get
            {
                return this._groupName;
            }
        }
        public int GroupUpID
        {
            set
            {
                this._groupUpID = value;
            }
            get
            {
                return this._groupUpID;
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

        public GroupList()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 根据参数，获取使用者详细信息IsAllowed=0
        /// </summary>
        /// <param name="AlarmName">使用者用户名</param>
        public void LoadData(string GroupName)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select ID,GroupName,GroupUpID From T_Group where  GroupName = "
                + SqlStringConstructor.GetQuotedString(GroupName);

            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询用户数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._ID = GetSafeData.ValidateDataRow_N(dr, "ID");
                this._groupName = GetSafeData.ValidateDataRow_S(dr, "GroupName");
                this._groupUpID = GetSafeData.ValidateDataRow_N(dr, "GroupUpID");
                this._exist = true;
            }
            else
            {
                this._exist = false;
            }
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <return></return>
        public void Add(Hashtable GroupLists)
        {
            Database db = new Database();           //实例化一个Database类
            db.Insert("T_Group", GroupLists);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="workerListID"></param>
        public void Delete(string SeleteItem)
        {
            string sql = "";
            sql = "Delete from T_Group where ID = " + Convert.ToInt32(SeleteItem);
            Database db = new Database();
            db.ExecuteSQL(sql);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="AlarmListID"></param>
        public void Update(Hashtable groupLists)
        {
            Database db = new Database();           //实例化一个Database类
            string strCond = "where ID = " + this._ID;
            db.Update("T_Group", groupLists, strCond);
        }

        public string LoadAllGroupInfo()
        {
            Database db = new Database();
            DataTable dt = null;
            DataSet ds = null;
            string strRet = "";
            StringBuilder sb = new StringBuilder("");
            string strSql = "select * from T_Group where GroupUpID=0";
            ds = db.GetDataSet(strSql);
            if (ds != null)
            {
                dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    sb.Append("[");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sb.Append("{");
                        sb.AppendFormat("\"text\":\"{0}\",\"state\":\"open\",\"id\":\"{1}\",", dt.Rows[i]["GroupName"].ToString(), "Dept" + dt.Rows[i]["ID"].ToString());
                        GetChildGroup(dt.Rows[i]["ID"].ToString(), ref sb);
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
            strRet = sb.ToString();
            return strRet;
        }

        public Boolean HasChild(string GroupId)
        {
            DataSet ds = null;
            DataTable dt = null;
            bool bHas = false;
            string strSql = "select count(0) from T_Group where GroupUpID=" + GroupId.ToString();
            Database db = new Database();
            ds = db.GetDataSet(strSql);
            if (ds != null)
            {
                dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dt.Rows[0][0]) > 0)
                    {
                        bHas = true;
                    }
                }
            }
            return bHas;
        }

        public string GetChildGroup(string GroupId, ref StringBuilder sb)
        {
            string strResult = "";
            DataSet ds = null;
            DataTable dt = null;
            string strSQL = "";
            string state = "open";
            strSQL = "select * from T_Group where GroupUpID=" + GroupId;
            ds = new Database().GetDataSet(strSQL);
            if (ds != null)
            {
                dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    sb.Append("\"children\":[");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sb.Append("{");
                        sb.AppendFormat("\"text\":\"{0}\",\"state\":\"" + state + "\",\"id\":\"{1}\",", dt.Rows[i]["GroupName"].ToString(), "Dept" + dt.Rows[i]["ID"].ToString());
                        GetChildGroup(dt.Rows[i]["ID"].ToString(), ref sb);
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

        public string GetData(string order, string page, string rows, string sort, string GroupId)
        {
            StringBuilder sbGroupIds = new StringBuilder("");
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter();
            param[0].SqlDbType = SqlDbType.VarChar;
            param[0].ParameterName = "@TableName";
            param[0].Direction = ParameterDirection.Input;
            param[0].Value = "V_MapHeader_Group";

            param[1] = new SqlParameter();
            param[1].SqlDbType = SqlDbType.VarChar;
            param[1].ParameterName = "@FieldKey";
            param[1].Direction = ParameterDirection.Input;
            param[1].Value = "Id";

            param[2] = new SqlParameter();
            param[2].SqlDbType = SqlDbType.VarChar;
            param[2].ParameterName = "@FieldShow";
            param[2].Direction = ParameterDirection.Input;
            param[2].Value = "*";

            param[3] = new SqlParameter();
            param[3].SqlDbType = SqlDbType.VarChar;
            param[3].ParameterName = "@FieldOrder";
            param[3].Direction = ParameterDirection.Input;
            param[3].Value = sort + " " + order;

            param[4] = new SqlParameter();
            param[4].SqlDbType = SqlDbType.Int;
            param[4].ParameterName = "@PageSize";
            param[4].Direction = ParameterDirection.Input;
            param[4].Value = Convert.ToInt32(rows);

            param[5] = new SqlParameter();
            param[5].SqlDbType = SqlDbType.Int;
            param[5].ParameterName = "@PageCurrent";
            param[5].Direction = ParameterDirection.Input;
            param[5].Value = Convert.ToInt32(page);

            param[6] = new SqlParameter();
            param[6].SqlDbType = SqlDbType.VarChar;
            param[6].ParameterName = "@Where";
            param[6].Direction = ParameterDirection.Input;

            string strWhereTemp = "";
            StringBuilder sbPosition = new StringBuilder("");
            ContactChildGroupIds(GroupId, ref sbGroupIds);
            if (sbGroupIds.ToString().EndsWith(","))
            {
                sbGroupIds = new StringBuilder(sbGroupIds.ToString().Substring(0, sbGroupIds.ToString().Length - 1));
            }

            if (GroupId != "")
            {
                if (strWhereTemp != "")
                {
                    strWhereTemp = strWhereTemp + " and GroupId in (" + sbGroupIds.ToString() + ") ";
                }
                else
                {
                    strWhereTemp = strWhereTemp + "  GroupId in (" + sbGroupIds.ToString() + ") ";
                }
            }

            param[6].Value = strWhereTemp;

            param[7] = new SqlParameter();
            param[7].SqlDbType = SqlDbType.Int;
            param[7].ParameterName = "@RecordCount";
            param[7].Direction = ParameterDirection.Output;

            DataSet ds = SqlServerHelper.RunProcedure("spPageViewByStr", param, "result");
            DataTable dt = ds.Tables["result"];

            StringBuilder sb = new StringBuilder("");
            sb.Append("{");
            sb.AppendFormat("\"total\":{0}", Convert.ToInt32(param[7].Value.ToString()));
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

            return sb.ToString();
        }

        public string GetAllData( string page, string rows)
        {
            StringBuilder sbGroupIds = new StringBuilder("");
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter();
            param[0].SqlDbType = SqlDbType.VarChar;
            param[0].ParameterName = "@TableName";
            param[0].Direction = ParameterDirection.Input;
            param[0].Value = "V_MapHeader_Group";

            param[1] = new SqlParameter();
            param[1].SqlDbType = SqlDbType.VarChar;
            param[1].ParameterName = "@FieldKey";
            param[1].Direction = ParameterDirection.Input;
            param[1].Value = "Id";

            param[2] = new SqlParameter();
            param[2].SqlDbType = SqlDbType.VarChar;
            param[2].ParameterName = "@FieldShow";
            param[2].Direction = ParameterDirection.Input;
            param[2].Value = "*";

            param[3] = new SqlParameter();
            param[3].SqlDbType = SqlDbType.VarChar;
            param[3].ParameterName = "@FieldOrder";
            param[3].Direction = ParameterDirection.Input;
            param[3].Value = " GroupName " + " " + " asc ";

            param[4] = new SqlParameter();
            param[4].SqlDbType = SqlDbType.Int;
            param[4].ParameterName = "@PageSize";
            param[4].Direction = ParameterDirection.Input;
            param[4].Value = Convert.ToInt32(rows);

            param[5] = new SqlParameter();
            param[5].SqlDbType = SqlDbType.Int;
            param[5].ParameterName = "@PageCurrent";
            param[5].Direction = ParameterDirection.Input;
            param[5].Value = Convert.ToInt32(page);

            param[6] = new SqlParameter();
            param[6].SqlDbType = SqlDbType.VarChar;
            param[6].ParameterName = "@Where";
            param[6].Direction = ParameterDirection.Input;

            string strWhereTemp = "";
            param[6].Value = strWhereTemp;

            param[7] = new SqlParameter();
            param[7].SqlDbType = SqlDbType.Int;
            param[7].ParameterName = "@RecordCount";
            param[7].Direction = ParameterDirection.Output;

            DataSet ds = SqlServerHelper.RunProcedure("spPageViewByStr", param, "result");
            DataTable dt = ds.Tables["result"];

            StringBuilder sb = new StringBuilder("");
            sb.Append("{");
            sb.AppendFormat("\"total\":{0}", Convert.ToInt32(param[7].Value.ToString()));
            sb.Append(",\"rows\":[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Append("{");

                string[] strFiledArray = strFileds1.Split(',');
                for (int j = 0; j < strFiledArray.Length; j++)
                {
                    switch (strFiledArray[j])
                    {
                        case "MapDes":
                            if (j != strFiledArray.Length - 1)
                            {
                                sb.AppendFormat("\"{0}\":\"{1}\",", strFiledArray[j], dt.Rows[i]["GroupName"].ToString()+"---"+dt.Rows[i]["MapName"].ToString());
                            }
                            else
                            {
                                sb.AppendFormat("\"{0}\":\"{1}\"", strFiledArray[j], dt.Rows[i]["GroupName"].ToString() + "---" + dt.Rows[i]["MapName"].ToString());
                            }
                            break;
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

            return sb.ToString();
        }

        public void ContactChildGroupIds(string groupId, ref StringBuilder sb)
        {
            string strSQL = "";
            DataSet ds = null;
            DataTable dt = null;
            sb.AppendFormat("{0},", groupId);
            strSQL = "select * from T_Group where GroupUpID=" + groupId;
            ds = SqlServerHelper.Query(strSQL);
            if (ds != null)
            {
                dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ContactChildGroupIds(dt.Rows[i]["ID"].ToString(), ref sb);
                    }
                }
            }
        }

        public DataSet GetGroupInfoByGroupUpId(int GroupUpId)
        {
            DataSet ds = null;
            string strSQL = "";
            strSQL = string.Format(@"select * from T_Group where GroupUpID={0}", GroupUpId);
            ds = SqlServerHelper.Query(strSQL);

            return ds;
        }

        public Boolean ExistGroupInfoByGroupUpId(int GroupUpId)
        {
            DataSet ds = null;
            string strSQL = "";
            strSQL = string.Format(@"select count(0) from T_Group where GroupUpID={0}", GroupUpId);
            ds = SqlServerHelper.Query(strSQL);

            return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString())>0;
        }

        public string GetGroupSubIdsByMapId(int MapId)
        {
            string strRet = "";
            DataSet ds = null;
            DataTable dt = null;
            StringBuilder sb = new StringBuilder("");
            string strSQL = "";
            strSQL = "select * from T_MapHeader where Id="+MapId;
            ds = SqlServerHelper.Query(strSQL);
            if (ds!=null)
            {
                dt=ds.Tables[0];
                if (dt!=null && dt.Rows.Count>0)
                {
                    GetGroupSubIdsByGroupId(ref sb, Convert.ToInt32(dt.Rows[0]["GroupId"].ToString()));
                }
            }
            if (sb.ToString().EndsWith(","))
            {
                sb = new StringBuilder(sb.ToString().Substring(0,sb.ToString().Length-1));
            }
            strRet = sb.ToString();
            return strRet;
        }

        public void GetGroupSubIdsByGroupId(ref StringBuilder sb,int GroupId)
        {
            DataSet ds = null;
            DataTable dt = null;
            sb.AppendFormat("{0},",GroupId);
            ds = SqlServerHelper.Query("select * from T_Group where GroupUpID="+GroupId);
            if (ds!=null)
            {
                dt=ds.Tables[0];
                if (dt!=null && dt.Rows.Count>0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        GetGroupSubIdsByGroupId(ref sb, Convert.ToInt32(dt.Rows[i]["ID"].ToString()));
                    }
                }
            }
        }
    }


}