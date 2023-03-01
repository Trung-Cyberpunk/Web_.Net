using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _19T1021256.DomainModels;
using _19T1021256.Businesslayers;
using _19T1021256.Web.Models;

namespace _19T1021256.Web.Controllers
{
    [Authorize]
    public class ShipperController : Controller
    {
        private const int PAGE_SIZE = 5;
        private const string SHIPPER_SEARCH = "SearchShipperCondition";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /*public ActionResult Index(int page = 1, int pageSize = 20, string searchValue = "")
        {
            int rowCount = 0;
            var model = CommonDataService.ListOfShippers(page, pageSize, searchValue, out rowCount);


            int pageCount = rowCount / pageSize;
            if (rowCount % pageSize > 0)
                pageCount += 1;

            ViewBag.Page = page;
            ViewBag.PageCount = pageCount;
            ViewBag.RowCount = rowCount;
            ViewBag.PageSize = pageSize;
            ViewBag.SearchValue = searchValue;
            return View(model);
            ;
            return View();
        }*/
        public ActionResult Index()
        {

            PaginationSearchInput condition = Session[SHIPPER_SEARCH] as PaginationSearchInput;
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
        public ActionResult Search(PaginationSearchInput condition)
        {
            int rowCount = 0;
            var data = CommonDataService.ListOfShippers(condition.Page,
                condition.PageSize,
                condition.SearchValue,
                out rowCount);
            var result = new ShippersSearchOutput()
            {
                Page = condition.Page,
                PageSize = condition.PageSize,
                SearchValue = condition.SearchValue,
                RowCount = rowCount,
                Data = data

            };
            Session[SHIPPER_SEARCH] = condition;
            return View(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            var data = new Shippers()
            {
                ShipperID = 0
            };
            ViewBag.Title = "Bổ sung người giao hàng";
            return View("Edit");
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

            var data = CommonDataService.GetShippers(id);
            if (data == null)
                return RedirectToAction("Index");



            ViewBag.Title = "Cập nhật nhà cung cấp";
            return View(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Shippers data)
        {
            try {
                //Kiểm soát đầu vào 
                if (string.IsNullOrWhiteSpace(data.ShipperName))
                    ModelState.AddModelError("ShipperName", "Tên không được để trống");
                if (string.IsNullOrWhiteSpace(data.Phone))
                    ModelState.AddModelError("Phone", "Vui lòng nhập số điện thoại");
                //...
                if (!ModelState.IsValid)
                {
                    ViewBag.Titel = data.ShipperID == 0 ? "Bổ sung nhà cung cấp" : "Cập nhật nhà cung cấp";
                    return View("Edit", data);
                }
                if (data.ShipperID == 0)
                {
                    CommonDataService.AddShippers(data);
                }
                else
                {

                }
                {
                    CommonDataService.UpdateShippers(data);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //Ghi lại log lỗi
                return Content("Có lỗi xảy ra. Vui lòng thử lại sau!");
            }
        }
        public ActionResult Delete(string id)
        {

            int shipperID = Convert.ToInt32(id);
            if (Request.HttpMethod == "GET")
            {
                var data = CommonDataService.GetShippers(shipperID);
                return View(data);
            }
            else
            {
                CommonDataService.DeleteShippers(shipperID);
                return RedirectToAction("Index");
            }


        }

    }
}