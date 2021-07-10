using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUDDapper.Models
{
    public static class DapperORM
    {
        private static string connectionString = @"Data source=MANOJ\SQLEXPRESS;initial catalog=DapperDB;user id=sa;password=$un$h!ne@0405;";

        public static void ExecuteWithoutReturn(string procedureName, DynamicParameters param=null)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                con.Execute(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }

        //Dapper.ExecuteScalar<int>(_,_);
        public static T ExecuteReturnScalar<T>(string procedureName, DynamicParameters param=null)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                return (T)Convert.ChangeType(con.ExecuteScalar(procedureName, param, commandType: CommandType.StoredProcedure), typeof(T));
            }
        }

        //Dapper.ReturnList<EmployeeModel> <= IEnumerable<EmployeeModel>
        public static IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param=null)
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                return con.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}