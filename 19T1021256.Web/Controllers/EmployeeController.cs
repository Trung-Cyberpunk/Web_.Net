using _19T1021256.Businesslayers;
using _19T1021256.DomainModels;
using _19T1021256.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace _19T1021256.Web.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private const int PAGE_SIZE = 10;
        private const string EMPLOYEE_SEARCH = "SearchEmployeeCondition";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //public ActionResult Index(int page = 1, int pageSize = 5, string searchValue = "")
        //{
        //    int rowCount = 0;
        //    var data = CommonDataService.ListOfSuppliers(page, pageSize, searchValue, out rowCount);

        //    int pageCount = rowCount / pageSize;
        //    if (rowCount % pageSize > 0)
        //        pageCount += 1;

        //    ViewBag.Page = page;
        //    ViewBag.PageCount = pageCount;
        //    ViewBag.RowCount = rowCount;
        //    ViewBag.PageSize = pageSize;
        //    ViewBag.SearchValue = searchValue;

        //    return View(data);
        //    //trả về giao diện mà có truyền thêm dữ liệu cho giao diện (data)
        //}

        public ActionResult Index()
        {
            PaginationSearchInput condition = Session[EMPLOYEE_SEARCH] as PaginationSearchInput;

            if (condition == null)
            {
                condition = new PaginationSearchInput()
                {
                    Page = 1,
                    PageSize = PAGE_SIZE,
                    SearchValue = ""
                };
            }
            return View(condition);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public ActionResult Search(PaginationSearchInput condition)
        {

            int rowCount = 0;
            var data = CommonDataService.ListOfEmployee(condition.Page, condition.PageSize, condition.SearchValue, out rowCount);
            var result = new EmployeeSearchOutput()
            {
                Page = condition.Page,
                PageSize = condition.PageSize,
                SearchValue = condition.SearchValue,
                RowCount = rowCount,
                Data = data
            };

            Session[EMPLOYEE_SEARCH] = condition;

            return View(result);
        }

        /// <summary>
        /// Giao dien bo sung nhan vien moi
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            var data = new Employee()
            {
                EmployeeID = 0
            };
            ViewBag.Title = "Bổ Sung Nhân Viên";
            return View("Edit", data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
                return RedirectToAction("Index");

            var data = CommonDataService.GetEmployee(id);
            if (data == null)
                return RedirectToAction("Index");

            ViewBag.Title = "Cập Nhật Nhân Viên";
            return View(data);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Save(Employee data, string birthday, HttpPostedFileBase uploadPhoto)
        {
            try
            {
                DateTime? d = Converter.DMYStringToDateTime(birthday);
                if (d == null)
                    ModelState.AddModelError("BirthDate", "Sai");
                else
                    data.BirthDate = d.Value;

                //Kiểm soát đầu vào
                if (string.IsNullOrWhiteSpace(data.FirstName))
                    ModelState.AddModelError("FirstName", "Họ nhân viên không được để trống");
                if (string.IsNullOrWhiteSpace(data.LastName))
                    ModelState.AddModelError("LastName", "Tên nhân viên không được để trống");
                if (string.IsNullOrWhiteSpace(data.Email))
                    ModelState.AddModelError("Email", "Email không được để trống");

                data.Photo = data.Photo ?? "https://www.w3schools.com/bootstrap4/img_avatar1.png";
                data.Notes = data.Notes ?? "";

                if (ModelState.IsValid == false)    // Kiểm tra dữ liệu đầu vào có hợp lệ hay không
                {
                    ViewBag.Title = data.EmployeeID == 0 ? "Bổ sung Nhân viên" : "Cập nhật Nhân viên";
                    return View("Edit", data);
                }

                if (uploadPhoto != null)
                {
                    string path = Server.MapPath("~/Images/Employees");
                    string fileName = $"{DateTime.Now.Ticks}_{uploadPhoto.FileName}";
                    string filePath = System.IO.Path.Combine(path, fileName);
                    uploadPhoto.SaveAs(filePath);
                    data.Photo = $"Images/Employees/{fileName}";
                }


                if (data.EmployeeID == 0)
                {
                    CommonDataService.AddEmployee(data);
                }
                else
                {
                    CommonDataService.UpdateEmployee(data);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //Ghi lại log lỗi
                return Content("Có lỗi xảy ra. Vui lòng thử lại sau");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete(string id)
        {
            int employeeID = Convert.ToInt32(id);
            if (Request.HttpMethod == "GET")
            {
                var data = CommonDataService.GetEmployee(employeeID);
                return View(data);
            }
            else
            {
                CommonDataService.DeleteEmployee(employeeID);
                return RedirectToAction("Index");

            }
            return View();
        }
    }
}