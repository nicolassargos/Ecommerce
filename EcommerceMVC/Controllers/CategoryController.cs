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
        public ActionResult Create()
        {
            CategoryService categoryService = new CategoryService(new UrlBuilder());

            ViewBag.Categories = categoryService.GetAllCategories();

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
        /// <returns></returns>
        public ActionResult ListBox2()
        {
            CategoryService categoryService = new CategoryService(new UrlBuilder());

            var result = categoryService.GetAllCategories();

            List<SelectListItem> categoryItems = new List<SelectListItem>();

            foreach (var ctg in result.Result)
            {
                categoryItems.Add(new SelectListItem() { Value = ctg.id.ToString(), Text = ctg.name });
            }

            ViewBag.categories = categoryItems;

            return View();
        }
        public async Task<ActionResult> ListBox()
        {
            CategoryService categoryService = new CategoryService(new UrlBuilder());

            ViewBag.Categories = await categoryService.GetAllCategories();

            return View();
        }

            // GET: Category/Edit/5
            public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
    }
}
