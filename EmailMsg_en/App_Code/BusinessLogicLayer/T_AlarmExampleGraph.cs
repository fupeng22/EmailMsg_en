using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using ComputerRepair.DataAccessLayer;
using System.Collections;

/// <summary>
///T_AlarmExampleGraph 的摘要说明
/// </summary>
public class T_AlarmExampleGraph
{
	public T_AlarmExampleGraph()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public int cId
    {
        get;
        set;
    }

    public int graphId
    {
        get;
        set;
    }

    public string alarmTypeId
    {
        get;
        set;
    }

    /// <summary>
    /// 按ID排序,读取所有文件列表
    /// </summary>
    /// <return></return>
    public static DataView QueryAlarmExampleGraphLists(string strSql)
    {
        //绑定数据
        Database db = new Database();
        return db.GetDataView(strSql);
    }

    /// <summary>
    /// 按排序,读取所有文件列表
    /// </summary>
    /// <return></return>
    public static DataView QueryAlarmExampleGraphLists()
    {

        string strSql = "";
        strSql = @"SELECT  TAEG.cId ,
                            TAEG.graphId ,
                            TAEG.alarmTypeId ,
                            TAT.AlarmTypeName ,
                            TE.graphName ,
                            TE.graphPath
                    FROM    dbo.T_AlarmExampleGraph TAEG
                            INNER JOIN dbo.T_ExampleGraph TE ON TAEG.graphId = TE.cId
                            INNER JOIN dbo.T_AlarmType TAT ON TAEG.alarmTypeId = TAT.cID";
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
    /// 增加新的设备类型
    /// </summary>
    /// <return></return>
    public void Add(Hashtable AlarmExampleGraphList)
    {
        Database db = new Database();           //实例化一个Database类
        db.Insert("T_AlarmExampleGraph", AlarmExampleGraphList);
    }

    /// <summary>
    /// 增加新的设备信息
    /// </summary>
    /// <return></return>
    public void Update(Hashtable AlarmExampleGraphList, string Id)
    {
        Database db = new Database();           //实例化一个Database类
        db.Update("T_AlarmExampleGraph", AlarmExampleGraphList, " where cId=" + Id);
    }
}