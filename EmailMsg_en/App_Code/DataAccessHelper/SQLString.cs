using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;


namespace ComputerRepair.DataAccessHelper
{/// <summary>
    ///SQLString 的摘要说明
    /// </summary>
    public class SQLString
    {
        public SQLString()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
    }
    public class SqlStringConstructor
    {
        /// <summary>
        /// 公有静态方法，将文本转换成适合在Sql语句里使用的字符串。
        /// </summary>
        /// <returns>转换后文本</returns>	
        public static String GetQuotedString(String pStr)
        {
            return ("'" + pStr.Replace("'", "''") + "'");
        }
    }
}