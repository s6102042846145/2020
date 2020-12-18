using AHCBL.Dao.Admin;
using AHCBL.Dto.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AHC_MLK.Controllers.Admin
{
    public class FAQController : Controller
    {
        // GET: FAQ
        public ActionResult Index()
        {
            return View(FAQDao.Instance.GetFAQ());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FAQDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    string result = FAQDao.Instance.SaveFAQ(model, "add");
                    if (result != "OK")
                    {
                        ViewBag.Message = result;
                        ModelState.Clear();
                    }
                    else
                    {
                        //ViewBag.Status = TempData["Dropdown"];
                        ViewBag.Message = "Successfully !!";
                        //KRPBL.Component.Common.Form.SetAlertMessage(this,"ไม่พบ User ID ที่ระบุ กรุณาตรวจสอบ");
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
            return View(FAQDao.Instance.GetFAQ().Find(smodel => smodel.id == id));
        }

        [HttpPost]
        public ActionResult Edit(FAQDto model)
        {
            try
            {
                string result = FAQDao.Instance.SaveFAQ(model, "edit");
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
        public ActionResult Delete(FAQDto model)
        {
            try
            {
                string result = FAQDao.Instance.SaveFAQ(model, "del");
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