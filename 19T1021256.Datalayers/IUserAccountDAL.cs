using _19T1021256.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021256.Datalayers
{
    /// <summary>
    /// Định nghĩa các phép xử lý liên quan đến dữ liệu tài khoản người dùng
    /// </summary>
    public interface IUserAccountDAL
    {
        /// <summary>
        /// Kiểm tra tên đăng nhập và mật khẩu có hợp lệ hay không 
        /// Nếu hợp lệ thì trả về thông tin của tài khoản, ngược lại trả về null
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        UserAccount Authorize(string userName, string password);
        /// <summary>
        /// Đổi mật khẩu
        /// </summary>
        /// <param name="username"></param>
        /// <param name="oldpassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        bool ChangePassword(string userName, string oldPassword, string newPassword);
    }
}
