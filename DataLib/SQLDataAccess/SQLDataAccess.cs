using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
namespace DataLib.SQLDataAccess
{
    public static class SQLDataAccess
    {
        public static List<T> loaddata<T>(string SQL,string ConnectionString)
        {
            using(IDbConnection CN = new SqlConnection(ConnectionString))
            {
                return CN.Query<T>(SQL).ToList();
            }
        }

        public static void SaveData<T>(string SQL,T data,string ConnectionString)
        {
            using (IDbConnection CN = new SqlConnection(ConnectionString))
            {
                CN.Execute(SQL, data);
            }
        }
    }
}
