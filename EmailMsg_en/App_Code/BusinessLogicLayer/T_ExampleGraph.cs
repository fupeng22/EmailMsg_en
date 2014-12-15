using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using ComputerRepair.DataAccessLayer;
using ComputerRepair.BusinessLogicLayer;
using System.Collections;

/// <summary>
///T_ExampleGraph 的摘要说明
/// </summary>
public class T_ExampleGraph
{
    public T_ExampleGraph()
    {
    }

    public int cId
    {
        get;
        set;
    }

    public string graphName
    {
        get;
        set;
    }

    public string graphPath
    {
        get;
        set;
    }

    /// <summary>
    /// 按ID排序,读取所有文件列表
    /// </summary>
    /// <return></return>
    public static DataView QueryExampleGraphLists(string strSql)
    {
        //绑定数据
        Database db = new Database();
        return db.GetDataView(strSql);
    }

    /// <summary>
    /// 按排序,读取所有文件列表
    /// </summary>
    /// <return></return>
    public static DataView QueryExampleGraphs()
    {

        string strSql = "";
        strSql = "Select * from T_ExampleGraph order by graphName asc";
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
    public void Add(Hashtable ExampleGraphLists)
    {
        Database db = new Database();           //实例化一个Database类
        db.Insert("T_ExampleGraph", ExampleGraphLists);
    }

    /// <summary>
    /// 增加新的设备信息
    /// </summary>
    /// <return></return>
    public void Update(Hashtable ExampleGraphInfoLists, string Id)
    {
        Database db = new Database();           //实例化一个Database类
        db.Update("T_ExampleGraph", ExampleGraphInfoLists, " where cId=" + Id);
    }
}