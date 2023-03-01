using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021256.Datalayers;
using _19T1021256.DomainModels;
using System.Configuration;


namespace _19T1021256.Businesslayers
{
    /// <summary>
    /// các chức năng nghiệp vụ liên quan đến : nhà cung cấp, khách hàng,
    /// người giao hàng, nhân viên, loại hàng
    /// </summary>
    public static class CommonDataService
    {
        private static ICountryDAL countryDB;
        private static ICommonDAL<Supplier> supplierDB;
        private static ICommonDAL<Shippers> shipperDB;
        private static ICommonDAL<Customer> customerDB;
        private static ICommonDAL<Employee> employeeDB;
        private static ICommonDAL<Category> categoryDB;
        /// <summary>
        /// Ctor
        /// </summary>
        static CommonDataService()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

            countryDB = new Datalayers.SQL_Server.CountryDAL(connectionString);
            supplierDB = new Datalayers.SQL_Server.SupplierDAL(connectionString);
            shipperDB = new Datalayers.SQL_Server.ShipperDAL(connectionString);
            customerDB = new Datalayers.SQL_Server.CustomerDAL(connectionString);
            employeeDB = new Datalayers.SQL_Server.EmployeeDAL(connectionString);
            categoryDB = new Datalayers.SQL_Server.CategoryDAL(connectionString);
            
        }
        /// <summary>
        /// lấy danh sách các quốc gia
        /// </summary>
        /// <returns></returns>
        public static List<Country> ListOfCountries()
        {
            return countryDB.List().ToList();
        }
        // Các nghiệp vụ liên quan đến quốc gia
        //#region Các ghiệp vụ liên quan đến nhà cung cấp
        /// <summary>
        /// Tìm kiếm, lấy danh sách các nhà cung cấp dưới dạng phân dạng
        /// </summary>
        /// <param name="page">Trang cần xem</param>
        /// <param name="pageSize">Số dòng trên mỗi trang</param>
        /// <param name="searchValue">Giá trị tìm kiếm</param>
        /// <param name="rowCount">Output: Tổng số dòng tìm được</param>
        /// <returns></returns>
        public static List<Supplier> ListOfSuppliers(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = supplierDB.Count(searchValue);
            return supplierDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Supplier> ListOfSuppliers(string searchValue)
        {
            return supplierDB.List(1, 0, searchValue).ToList();
        }
        /// <summary>
        /// Bổ sung nhà cung cấp
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddSuppliers(Supplier data)
        {
            return supplierDB.Add(data);
        }
        /// <summary>
        /// Cập nhật nhà cung cấp
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdataSuppliers(Supplier data)
        {
            return supplierDB.Update(data);
        }
        /// <summary>
        /// Kiểm tra xem mã nhà cung cấp, rồi trả về thông tin nhà cung cấp
        /// </summary>
        /// <param name="SupplierID"></param>
        /// <returns></returns>
        public static Supplier GetSupplier(int SupplierID)
        {
            return supplierDB.Get(SupplierID);
        }
        /// <summary>
        /// Xoá nhà cung cấp
        /// </summary>
        /// <param name="SupplierID"></param>
        /// <returns></returns>
        public static bool DeleteSupplier(int SupplierID)
        {
            return supplierDB.Delete(SupplierID);
        }
        /// <summary>
        /// Kiểm tra xem nhà cung cấp có dữ liệu liên quan hay không
        /// </summary>
        /// <param name="SupplierID"></param>
        /// <returns></returns>
        public static bool InUsedSupplier(int SupplierID)
        {
            return supplierDB.InUsed(SupplierID);
        }
        //--------------------------------Shipper------------------------------------------------------


        // Các nghiệp vụ liên quan đến quốc gia
        //#region Các ghiệp vụ liên quan đến nhà cung cấp
        /// <summary>
        /// Tìm kiếm, lấy danh sách các người giao hàng dưới dạng phân dạng
        /// </summary>
        /// <param name="page">Trang cần xem</param>
        /// <param name="pageSize">Số dòng trên mỗi trang</param>
        /// <param name="searchValue">Giá trị tìm kiếm</param>
        /// <param name="rowCount">Output: Tổng số dòng tìm được</param>
        /// <returns></returns>
        public static List<Shippers> ListOfShippers(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = shipperDB.Count(searchValue);
            return shipperDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Shippers> ListOfShippers(string searchValue)
        {
            return shipperDB.List(1, 0, searchValue).ToList();
        }
        /// <summary>
        /// Bổ sung người giao hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddShippers(Shippers data)
        {
            return shipperDB.Add(data);
        }
        /// <summary>
        /// Cập nhật người giao hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateShippers(Shippers data)
        {
            return shipperDB.Update(data);
        }
        /// <summary>
        /// Kiểm tra xem mã nhà giao hàng, rồi trả về thông tin người giao hàng
        /// </summary>
        /// <param name="SupplierID"></param>
        /// <returns></returns>
        public static Shippers GetShippers(int ShipperID)
        {
            return shipperDB.Get(ShipperID);
        }
        /// <summary>
        /// Xoá người giao hàng
        /// </summary>
        /// <param name="ShipperID"></param>
        /// <returns></returns>
        public static bool DeleteShippers(int ShipperID)
        {
            return shipperDB.Delete(ShipperID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ShipperID"></param>
        /// <returns></returns>
        public static bool InUsedShippers(int ShipperID)
        {
            return shipperDB.InUsed(ShipperID);
        }
        //-------------------------Customer----------------------------------
        // Các nghiệp vụ liên quan đến quốc gia
        //#region Các ghiệp vụ liên quan đến nhà cung cấp
        /// <summary>
        /// Tìm kiếm, lấy danh sách các người giao hàng dưới dạng phân dạng
        /// </summary>
        /// <param name="page">Trang cần xem</param>
        /// <param name="pageSize">Số dòng trên mỗi trang</param>
        /// <param name="searchValue">Giá trị tìm kiếm</param>
        /// <param name="rowCount">Output: Tổng số dòng tìm được</param>
        /// <returns></returns>
        public static List<Customer> ListOfCustomer(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = customerDB.Count(searchValue);
            return customerDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Customer> ListOfCustomer(string searchValue)
        {
            return customerDB.List(1, 0, searchValue).ToList();
        }
        /// <summary>
        /// Bổ sung người giao hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddCustomer(Customer data)
        {
            return customerDB.Add(data);
        }
        /// <summary>
        /// Cập nhật người giao hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateCustomer(Customer data)
        {
            return customerDB.Update(data);
        }
        /// <summary>
        /// Kiểm tra xem mã nhà giao hàng, rồi trả về thông tin người giao hàng
        /// </summary>
        /// <param name="SupplierID"></param>
        /// <returns></returns>
        public static Customer GetCustomer(int CustomerID)
        {
            return customerDB.Get(CustomerID);
        }
  /// <summary>
  /// 
  /// </summary>
  /// <param name="CustomerID"></param>
  /// <returns></returns>
        public static bool DeleteCustomer(int CustomerID)
        {
            return customerDB.Delete(CustomerID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ShipperID"></param>
        /// <returns></returns>
        public static bool InUsedCustomer(int CustomerID)
        {
            return customerDB.InUsed(CustomerID);
        }
        /*------------------------employee-----------------------------*/
        // Các nghiệp vụ liên quan đến quốc gia
        //#region Các ghiệp vụ liên quan đến nhà cung cấp
        /// <summary>
        /// Tìm kiếm, lấy danh sách các người giao hàng dưới dạng phân dạng
        /// </summary>
        /// <param name="page">Trang cần xem</param>
        /// <param name="pageSize">Số dòng trên mỗi trang</param>
        /// <param name="searchValue">Giá trị tìm kiếm</param>
        /// <param name="rowCount">Output: Tổng số dòng tìm được</param>
        /// <returns></returns>
        public static List<Employee> ListOfEmployee(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = employeeDB.Count(searchValue);
            return employeeDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Employee> ListOfEmployee(string searchValue)
        {
            return employeeDB.List(1, 0, searchValue).ToList();
        }
        /// <summary>
        /// Bổ sung người giao hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddEmployee(Employee data)
        {
            return employeeDB.Add(data);
        }
        /// <summary>
        /// Cập nhật người giao hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateEmployee(Employee data)
        {
            return employeeDB.Update(data);
        }
        /// <summary>
        /// Kiểm tra xem mã nhà giao hàng, rồi trả về thông tin người giao hàng
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <returns></returns>
        public static Employee GetEmployee(int EmployeeID)
        {
            return employeeDB.Get(EmployeeID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <returns></returns>
        public static bool DeleteEmployee(int EmployeeID)
        {
            return employeeDB.Delete(EmployeeID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ShipperID"></param>
        /// <returns></returns>
        public static bool InUsedEmployee(int EmployeeID)
        {
            return employeeDB.InUsed(EmployeeID);
        }
        //  ------------------------------category------------------------------------
        //-------------------------Category----------------------------------

        // Các nghiệp vụ liên quan đến quốc gia
        //#region Các ghiệp vụ liên quan đến nhà cung cấp
        /// <summary>
        /// Tìm kiếm, lấy danh sách các người giao hàng dưới dạng phân dạng
        /// </summary>
        /// <param name="page">Trang cần xem</param>
        /// <param name="pageSize">Số dòng trên mỗi trang</param>
        /// <param name="searchValue">Giá trị tìm kiếm</param>
        /// <param name="rowCount">Output: Tổng số dòng tìm được</param>
        /// <returns></returns>
        public static List<Category> ListOfCategory(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = categoryDB.Count(searchValue);
            return categoryDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Category> ListOfCategory(string searchValue)
        {
            return categoryDB.List(1, 0, searchValue).ToList();
        }
        /// <summary>
        /// Bổ sung người giao hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddCategory(Category data)
        {
            return categoryDB.Add(data);
        }
        /// <summary>
        /// Cập nhật người giao hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateCategory(Category data)
        {
            return categoryDB.Update(data);
        }
        /// <summary>
        /// Kiểm tra xem mã nhà giao hàng, rồi trả về thông tin người giao hàng
        /// </summary>
        /// <param name="SupplierID"></param>
        /// <returns></returns>
        public static Category GetCategory(int CategoryID)
        {
            return categoryDB.Get(CategoryID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Category"></param>
        /// <returns></returns>
        public static bool DeleteCategory(int CategoryID)
        {
            return categoryDB.Delete(CategoryID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public static bool InUsedCategory(int CategoryID)
        {
            return categoryDB.InUsed(CategoryID);
        }

    }
}



