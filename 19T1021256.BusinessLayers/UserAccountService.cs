using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021256.Datalayers;
using _19T1021256.DomainModels;

namespace _19T1021256.BusinessLayers
{
    /// <summary>
    /// Các chức năng liên quan đến tài khoản
    /// </summary>
    public static class UserAccountService
    {
        private static IUserAccountDAL employeeAccountDB;
        private static IUserAccountDAL customerAccountDB;


        /// <summary>
        /// 
        /// </summary>
        static UserAccountService()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

            employeeAccountDB = new Datalayers.SQL_Server.EmployeeAccountDAL(connectionString);
            customerAccountDB = new Datalayers.SQL_Server.CustomerAccountDAL(connectionString);
        }

        public static UserAccount Authorize(AccountTypes accountType, string userName, string password)
        {
            if (accountType == AccountTypes.Employee)
                return employeeAccountDB.Authorize(userName, password);
            else
                return customerAccountDB.Authorize(userName, password);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountType"></param>
        /// <param name="userName"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public static bool ChangePassword(AccountTypes accountType, string userName, string oldPassword, string newPassword)
        {
            if (accountType == AccountTypes.Employee)
                return employeeAccountDB.ChangePassword(userName, oldPassword, newPassword);
            else
                return customerAccountDB.ChangePassword(userName, oldPassword, newPassword);

        }

    }
}