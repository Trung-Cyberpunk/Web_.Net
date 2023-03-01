using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021256.Datalayers.SQL_Server
{
    /// <summary>
    /// lớp cơ sở cho các xử lý dữ liệu liên quan đến SQL Server
    /// </summary>
    public abstract class _BaseDAL
    {
        /// <summary>
        /// chuỗi tham số kết nối CSDL
        /// </summary>
        protected string _connectionString; //Access Modifler 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionsString"></param>
        public _BaseDAL(string connectionsString)
        {
            _connectionString = connectionsString;
        }

        protected SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();
            return connection;
        }
    }
}
