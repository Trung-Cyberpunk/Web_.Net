using _19T1021256.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19T1021256.Web.Models
{
    /// <summary>
    /// Kết quả tìm kiếm khách hàng dưới dạng phân trang
    /// </summary>
    public class CustomerSearchOutput : PaginationSeachOutput
    {
        public List<Customer> Data { get; set; }

       
    }
}