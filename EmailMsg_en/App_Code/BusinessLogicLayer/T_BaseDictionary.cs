using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using ComputerRepair.BusinessLogicLayer;

/// <summary>
///T_BaseDictionary 的摘要说明
/// </summary>
public class T_BaseDictionary
{
	public T_BaseDictionary()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public DataSet LoadDefaultSeleMap(string cType, string cName)
    {
        DataSet ds = null;
        string strSQL = "";
        strSQL = string.Format(@"SELECT * from T_BaseDictionary where cType='{0}' and cName='{1}'", cType,cName);
        ds = SqlServerHelper.Query(strSQL);

        return ds;
    }

    public void AddDefaultSeleMap(string cType, string cName,string sValue)
    {
        string strSQL = "";

        strSQL = string.Format(@"delete from T_BaseDictionary where cName='{0}' and cType='{1}'",cName,cType);

        SqlServerHelper.ExecuteSql(strSQL);

        strSQL = string.Format(@"INSERT INTO [T_BaseDictionary]
                                ([cName]
                                ,[sValue]
                                ,[cType]) values('{0}','{1}','{2}')", cName, sValue,cType);
        SqlServerHelper.ExecuteSql(strSQL);
    }
}