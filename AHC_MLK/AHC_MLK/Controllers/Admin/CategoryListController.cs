using AHCBL.Dao.Admin;
using AHCBL.Dto.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AHC_MLK.Controllers.Admin
{
    public class CategoryListController : Controller
    {
        // GET: CategoryList
        public ActionResult Index()
        {
            return View(CategoryListDao.Instance.GetCategoryList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CategoryListDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    string result = CategoryListDao.Instance.SaveCategoryList(model, "add");
                    if (result != "OK")
                    {
                        ViewBag.Message = result;
                        ModelState.Clear();
                    }
                    else
                    {
                        //ViewBag.Status = TempData["Dropdown"];
                        ViewBag.Message = "Successfully !!";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch (Exception e)
            {
                ViewBag.Message = "Error : " + e.Message;
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            return View(CategoryListDao.Instance.GetCategoryList().Find(smodel => smodel.id == id));
        }
        [HttpPost]
        public ActionResult Edit(CategoryListDto model)
        {
            try
            {
                string result = CategoryListDao.Instance.SaveCategoryList(model, "edit");
                if (result != "OK")
                {
                    ViewBag.Message = result;
                }
                else
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(CategoryListDto model)
        {
            try
            {
                string result = CategoryListDao.Instance.SaveCategoryList(model, "del");
                if (result == "OK")
                {
                    ViewBag.Message = "Student Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Message = "Error : " + e.Message.ToString();
                return View();
            }
        }
    }
}