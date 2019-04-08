using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Zxw.Framework.NetCore.Models;
using Dapper;
namespace Cms.Admin.Controllers
{
    public class DefaultController : Controller
    {

        public IActionResult Index()
        {
//            DatabaseType dbType = DatabaseType.MSSQL;
//            string strGetAllTables = @"SELECT DISTINCT d.name as TableName, f.value as TableComment
//FROM      sys.syscolumns AS a LEFT OUTER JOIN
//                sys.systypes AS b ON a.xusertype = b.xusertype INNER JOIN
//                sys.sysobjects AS d ON a.id = d.id AND d.xtype = 'U' AND d.name <> 'dtproperties' LEFT OUTER JOIN
//                sys.syscomments AS e ON a.cdefault = e.id LEFT OUTER JOIN
//                sys.extended_properties AS g ON a.id = g.major_id AND a.colid = g.minor_id LEFT OUTER JOIN
//                sys.extended_properties AS f ON d.id = f.major_id AND f.minor_id = 0";
//            List<DbTable> tables = null;
//            using (var conn = new SqlConnection("Data Source=.;Initial Catalog=Sample;Integrated Security=True"))
//            {
//                tables = conn.Query<DbTable>(strGetAllTables).ToList();
//            }
            return View();
        }
        public class CodeGenerator
        {


        }

    }
}