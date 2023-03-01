using _19T1021256.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021256.Datalayers.SQL_Server
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerAccountDAL : _BaseDAL, IUserAccountDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionsString"></param>
        public CustomerAccountDAL(string connectionsString) : base(connectionsString)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserAccount Authorize(string userName, string password)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
