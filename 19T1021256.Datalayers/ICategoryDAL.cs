using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021256.DomainModels;

namespace _19T1021256.Datalayers
{
    public interface ICategoryDAL
    {
        /// <summary>
        /// tìm kiếm và lấy danh sách các loại hàng dưới dạng phân trang
        /// </summary>
        /// <param name="page">Trang cần hiển thị</param>
        /// <param name="pageSize">Số dòng hiển thị trên mỗi trang (0 tức là không yêu cầu phân trang)</param>
        /// <param name="searchValue">tên cần tìm kiếm (chuỗi rỗng nếu không tìm kiếm theo tên)</param>
        /// <returns></returns>
        IList<Category> List();
        /// <summary>
        /// đếm số loại hàng tìm được
        /// </summary>
        /// <param name="searchValue">Tên cần tìm kiếm (chuỗi rỗng nếu không tìm kiếm theo tên)</param>
        /// <returns></returns>
        int Count(string searchValue = "");
        /// <summary>
        /// Bổ sung thêm một loại hàng
        /// </summary>
        /// <param name="data">Lớp chứa đối tượng bổ sung</param>
        /// <returns>ID của loại hàng được tạo mới</returns>
        int Add(Category data);
        /// <summary>
        /// cập nhật thông tin của loại hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(Category data);
        /// <summary>
        /// xóa một loại hàng dựa vào mã của loại hàng
        /// </summary>
        /// <param name="categoryID">mã của loại hàng cần xóa</param>
        /// <returns></returns>
        bool Delete(int categoryID);
        /// <summary>
        /// Lấy thông tin của 1 loại hàng dựa vào mã của loại hàng
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        Category Get(int categoryID);
        /// <summary>
        /// Kiểm tra xem loại hàng hiện có dữ liệu liên quan hay không
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        bool InUsed(int categoryID);
    }
}
