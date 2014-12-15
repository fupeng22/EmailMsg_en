using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using ComputerRepair.DataAccessLayer;
using System.Collections;

/// <summary>
///T_NVRInfo 的摘要说明
/// </summary>
public class T_NVRInfo
{
	public T_NVRInfo()
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

    public string NVRName
    {
        get;
        set;
    }

    public string NVRIP
    {
        get;
        set;
    }

    public int NVRPort
    {
        get;
        set;
    }

    public int GroupId
    {
        get;
        set;
    }

    public string UserName
    {
        get;
        set;
    }

    public string UserPwd
    {
        get;
        set;
    }

    /// <summary>
    /// 按ID排序,读取所有文件列表
    /// </summary>
    /// <return></return>
    public static DataView QueryNVRInfoLists(string strSql)
    {
        //绑定数据
        Database db = new Database();
        return db.GetDataView(strSql);
    }

    /// <summary>
    /// 按排序,读取所有文件列表
    /// </summary>
    /// <return></return>
    public static DataView QueryNVRInfoLists()
    {

        string strSql = "";
        strSql = @"SELECT  TN.cId ,
                        TN.NVRName ,
                        TN.NVRIP ,
                        TN.NVRPort ,
                        TN.GroupId ,
                        TN.UserName ,
                        TN.UserPwd ,
                        TG.GroupName
                FROM    dbo.T_NVRInfo TN
                        INNER JOIN dbo.T_Group TG ON TN.GroupId = TG.ID";
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
    public void Add(Hashtable NVRInfoList)
    {
        Database db = new Database();           //实例化一个Database类
        db.Insert("T_NVRInfo", NVRInfoList);
    }

    /// <summary>
    /// 增加新的设备信息
    /// </summary>
    /// <return></return>
    public void Update(Hashtable NVRInfoList, string Id)
    {
        Database db = new Database();           //实例化一个Database类
        db.Update("T_NVRInfo", NVRInfoList, " where cId=" + Id);
    }
}