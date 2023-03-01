using _19T1021256.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19T1021256.Web.Models
{
    /// <summary>
    /// Kết quả tìm kiếm nhà cung cấp dưới dạng phân trang
    /// </summary>
    public class SupplierSearchOutput : PaginationSeachOutput
    {
        public List<Supplier> Data { get; set; }
    }
}