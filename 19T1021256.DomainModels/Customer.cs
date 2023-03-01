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
   public  class Customer
    {
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public int CustomerID { get; set; }
        /// <summary>
        /// Tên khách khàng
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Tên giao dich
        /// </summary>
        public string ContactName { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Thành phố
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Mã Bưu Chính
        /// </summary>
        public string PostalCode { get; set; }
        /// <summary>
        /// Nước
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Mật khẩu
        /// </summary>
        public string Password { get; set; }
    }
}
