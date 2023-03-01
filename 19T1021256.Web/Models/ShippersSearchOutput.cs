using _19T1021256.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19T1021256.Web.Models
{
    /// <summary>
    /// Hiển thị danh sách người giao hàng dưới dạng phân trang 
    /// </summary>
    public class ShippersSearchOutput : PaginationSeachOutput 
    {
        public List<Shippers> Data { get; set; }
       
    }
}