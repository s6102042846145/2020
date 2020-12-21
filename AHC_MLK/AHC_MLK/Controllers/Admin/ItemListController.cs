using AHCBL.Dao.Admin;
using AHCBL.Dto;
using AHCBL.Dto.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace AHC_MLK.Controllers.Admin
{

    public class ItemListController : Controller
    {

        // GET: ItemList
        public ActionResult Index(string search, int? page)
        {
            TempData["search"] = search;
            var list = ItemListDao.Instance.GetData().ToList();            
            return View(list.Where(x => x.name == search || search == null || search == "").ToList().ToPagedList(page ?? 1, 3));
        }
       
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ItemListDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    string result = ItemListDao.Instance.SaveData(model, "add");
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
            return View(ItemListDao.Instance.GetData().Find(smodel => smodel.id == id));
        }
        [HttpPost]
        public ActionResult Edit(ItemListDto model)
        {
            try
            {
                string result = ItemListDao.Instance.SaveData(model, "edit");
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
        public ActionResult Delete(ItemListDto model)
        {
            try
            {
                string result = ItemListDao.Instance.SaveData(model, "del");
                if (result == "OK")
                {
                    ViewBag.Message = "Deleted Successfully";
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