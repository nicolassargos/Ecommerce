using EcommerceMVC.Helper;
using EcommerceMVC.Models;
using EcommerceMVC.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EcommerceMVC.Controllers
{
    public class CategoryController : Controller
    {
        CategoryService categoryService = new CategoryService(new UrlBuilder());

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: Category
        public async Task<ActionResult> Index()
        {
            var result = await categoryService.GetAllCategories();

            return View("Index", result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: Category/Create
        public ActionResult Create()
        {
            return View(new CategoryModel());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        // POST: Category/Create
        [HttpPost]
        public async Task<ActionResult> Create(CategoryModel category)
        {
            try
            {
                var result = await categoryService.CreateCategory(category);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Category/Edit/5
        public async  Task<ActionResult> Edit(int id)
        {
            var result = await categoryService.GetCategoryById(id);

            return View(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int Id, FormCollection collection)
        {
            try
            {
                CategoryModel category = new CategoryModel() { id = Id, parentCategoryId = int.Parse(collection.GetValue("parentCategoryId").AttemptedValue), name = collection.GetValue("name").AttemptedValue };

                var result = categoryService.UpdateCategory(category);

                return RedirectToAction("Index");
            }
            catch
            {
                throw;
                //return View();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
                return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        // POST: Category/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            HttpResponseMessage result = new HttpResponseMessage();

            try
            {
                result = await categoryService.DeleteCategory(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(result);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Category/GetCategoryHierarchy/{id}")]
        public async Task<JsonResult> GetCategoryHierarchy(int id)
        {
            var result = await categoryService.GetCategoryHierarchy(id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("Category/GetCategories")]
        [HttpGet]
        public async Task<JsonResult> GetCategories()
        {
            var result = await categoryService.GetAllCategories();

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> GetProductsByCategory(int id)
        {
            var result = await categoryService.GetProductsByCategory(id);

            if (result.Count() > 0)
                ViewBag.CategoryName = result.First().categoryName ?? "";

            return View(result);
        }
    }
}
