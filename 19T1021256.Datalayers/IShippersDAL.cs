using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021256.DomainModels;

namespace _19T1021256.Datalayers.SQL_Server
{


    /// <summary>
    /// 
    /// </summary>
    public class IShippersDAL : _BaseDAL, ICommonDAL<Shippers>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionsString"></param>
        public IShippersDAL(string connectionsString) : base(connectionsString)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>

        public int Add(Shippers data)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>


        public int Count(string searchValue = "")
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Shippers Get(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool InUsed(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public IList<Shippers> List(int page = 1, int pageSize = 0, string searchValue = "")
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Update(Shippers data)
        {
            throw new NotImplementedException();
        }
    }
}