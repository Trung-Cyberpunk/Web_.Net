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
    public class CategoryController : Controller
    {
        private const int PAGE_SIZE = 5;
        private const string CATEGORY_SEARCH = "SearchcategoryCondition";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /* public ActionResult Index(int page = 1, int pageSize = 20, string searchValue = "")
         {
             int rowCount = 0;
             var model = CommonDataService.ListOfSuppliers(page, pageSize, searchValue, out rowCount);


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

            PaginationSearchInput condition = Session[CATEGORY_SEARCH] as PaginationSearchInput;
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
            var data = CommonDataService.ListOfCategory(condition.Page,
                condition.PageSize,
                condition.SearchValue,
                out rowCount);
            var result = new CategorySearchOutput()
            {
                Page = condition.Page,
                PageSize = condition.PageSize,
                SearchValue = condition.SearchValue,
                RowCount = rowCount,
                Data = data

            };
            Session[CATEGORY_SEARCH] = condition;
            return View(result);
        }
        /// <summary>
        /// Giao diện bổ sung nhà cung cấp mới
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            var data = new Category()
            {
                CategoryID = 0
            };
            ViewBag.Title = "Bổ sung nhà cung cấp mới";
            return View("Edit", data);
        }
        /// <summary>
        /// Cập nhật nhà cung cấp
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
                return RedirectToAction("Index");


            var data = CommonDataService.GetCategory(id);
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

        public ActionResult Save(Category data)
        {
            try
            {
                //Kiểm soát đầu vào 
                if (string.IsNullOrWhiteSpace(data.CategoryName))
                    ModelState.AddModelError("CategoryName","Tên không được để trống");
                if (string.IsNullOrWhiteSpace(data.Description))
                    ModelState.AddModelError("Description", "Vui lòng nhập mô tả loại hàng");
                //...

                if (!ModelState.IsValid)
                {
                    ViewBag.Titel = data.CategoryID == 0 ? "Bổ sung loại hàng" : "Cập nhật loại hàng";
                    return View("Edit", data);
                }

                if (data.CategoryID == 0)
            {
                CommonDataService.AddCategory(data);
            }
            else
            {
                CommonDataService.UpdateCategory(data);
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
    /// 

    public ActionResult Delete(string id)
        {
            int categoryID = Convert.ToInt32(id);
            if (Request.HttpMethod == "GET")
            {
                var data = CommonDataService.GetCategory(categoryID);
                return View(data);
            }
            else
            {
                CommonDataService.DeleteCategory(categoryID);
                return RedirectToAction("Index");
            }
           
        }
    }
}
