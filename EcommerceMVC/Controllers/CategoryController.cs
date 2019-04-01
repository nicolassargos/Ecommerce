using EcommerceMVC.Helper;
using EcommerceMVC.Models;
using EcommerceMVC.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EcommerceMVC.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public async Task<ActionResult> Index()
        {
            CategoryService categoryService = new CategoryService(new UrlBuilder());

            var result = await categoryService.GetAllCategories();

            return View("Index", result);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public async Task<ActionResult> Create()
        {
            CategoryService categoryService = new CategoryService(new UrlBuilder());

            var result = await categoryService.GetAllCategories();

            ViewBag.categories = result ?? new List<CategoryModel>();

            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(CategoryModel category)
        {
            try
            {
                CategoryService categoryService = new CategoryService(new UrlBuilder());

                var result = categoryService.CreateCategory(category);

                return RedirectToAction("CreateProduct");
            }
            catch
            {
                return View("CreateProduct");
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int Id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                CategoryModel category = new CategoryModel() { id = Id, parentCategoryId = int.Parse(collection.GetValue("parentCategoryId").AttemptedValue), name = collection.GetValue("name").AttemptedValue };

                CategoryService categoryService = new CategoryService(new UrlBuilder());

                var result = categoryService.UpdateCategory(category);

                return RedirectToAction("Index");
            }
            catch
            {
                throw;
                //return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
            CategoryService categoryService = new CategoryService(new UrlBuilder());

            var result = await categoryService.GetCategoryHierarchy(id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //[Route("category/{id}")]
        public async Task<ActionResult> GetProductsByCategory(int id)
        {
            CategoryService categoryService = new CategoryService(new UrlBuilder());

            var result = await categoryService.GetProductsByCategory(id);

            if (result.Count() > 0)
                ViewBag.CategoryName = result.First().categoryName ?? "";

            return View(result);
        }
    }
}
