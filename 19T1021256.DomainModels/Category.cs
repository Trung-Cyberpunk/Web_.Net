using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021256.DomainModels
{
    /// <summary>
    /// 
    /// </summary>
    public class Category
    {
        /// <summary>
        /// 
        /// </summary>
        public int CategoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String CategoryName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ParentCategoryID { get; set; }
    }
}
