using _19T1021256.Businesslayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _19T1021256.DomainModels;
using _19T1021256.Web.Models;

namespace _19T1021256.Web.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private const int PAGE_SIZE = 5;
        private const string CUSTOMER_SEARCH = "SearchCustomerCondition";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        /* public ActionResult Index(int page = 1, int pageSize = 20, string searchValue = "")
         {
             int rowCount = 0;
             var model = CommonDataService.ListOfCustomer(page, pageSize, searchValue, out rowCount);


             int pageCount = rowCount / pageSize;
             if (rowCount % pageSize > 0)
                 pageCount += 1;

             ViewBag.Page = page;
             ViewBag.PageCount = pageCount;
             ViewBag.RowCount = rowCount;
             ViewBag.PageSize = pageSize;
             ViewBag.SearchValue = searchValue;
             return View(model);

         }*/



        public ActionResult Index()
        {

            PaginationSearchInput condition = Session[CUSTOMER_SEARCH] as PaginationSearchInput;
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
            var data = CommonDataService.ListOfCustomer(condition.Page,
                condition.PageSize,
                condition.SearchValue,
                out rowCount);
            var result = new CustomerSearchOutput()
            {
                Page = condition.Page,
                PageSize = condition.PageSize,
                SearchValue = condition.SearchValue,
                RowCount = rowCount,
                Data = data

            };
            Session[CUSTOMER_SEARCH] = condition;
            return View(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            var data = new Customer()
            {
                CustomerID = 0
            };
            ViewBag.Title = "Bổ sung khách hàng";
            return View("Edit", data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
                return RedirectToAction("Index");

            var data = CommonDataService.GetCustomer(id);
            if (data == null)
                return RedirectToAction("Index");

            ViewBag.Title = "Cập nhật khác hàng";
            return View(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer data)
        {
            try
            {
                //Kiểm soát đầu vào 
                if (string.IsNullOrWhiteSpace(data.CustomerName))
                    ModelState.AddModelError("CustomerName", "Tên khách hàng không được để trống");
                if (string.IsNullOrWhiteSpace(data.ContactName))
                    ModelState.AddModelError("ContactName", "Tên giao dịch không được để trống");
                if (string.IsNullOrWhiteSpace(data.Email))
                    ModelState.AddModelError("Email", "Vui lòng nhập email");
                if (string.IsNullOrWhiteSpace(data.Password))
                    ModelState.AddModelError("Password", "Mật khẩu không được trống");
                if (string.IsNullOrWhiteSpace(data.Address))
                    ModelState.AddModelError("Address", "Vui lòng nhập địa chỉ");
                if (string.IsNullOrWhiteSpace(data.City))
                    ModelState.AddModelError("City", "Vui lòng chọn thành phố");
                if (string.IsNullOrWhiteSpace(data.PostalCode))
                    ModelState.AddModelError("PostalCode", "Vui lòng chọn thành phố");
                if (string.IsNullOrWhiteSpace(data.Country))
                    ModelState.AddModelError("Country", "Vui lòng chọn quốc gia");
                //...

                if (!ModelState.IsValid)
                {
                    ViewBag.Titel = data.CustomerID == 0 ? "Bổ sung khách hàng " : "Cập nhật khách hàng";
                    return View("Edit", data);
                }

                if (data.CustomerID == 0)
                {
                    CommonDataService.AddCustomer(data);
                }
                else
                {
                    CommonDataService.UpdateCustomer(data);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //Ghi lại log lỗi
                return Content("Có lỗi xảy ra. Vui lòng thử lại sau!");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete(string id)
        {
            int customerID = Convert.ToInt32(id);
            if (Request.HttpMethod == "GET")
            {
                var data = CommonDataService.GetCustomer(customerID);
                return View(data);
            }
            else
            {
                CommonDataService.DeleteCustomer(customerID);
                return RedirectToAction("Index");
            }
        }

    }
}