using _19T1021256.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19T1021256.Web.Models
{
    /// <summary>
    /// Kết quả tìm kiếm Nhân viên dưới dạng phân trang 
    /// </summary>
    public class EmployeeSearchOutput : PaginationSeachOutput
    {
        public List<Employee> Data { get; set; }
    }
}