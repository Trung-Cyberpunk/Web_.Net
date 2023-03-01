using _19T1021256.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19T1021256.Web.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class CategorySearchOutput :PaginationSeachOutput
    {
        public List<Category> Data { get; set; }
    }
}