using AHCBL.Dao.Admin;
using AHCBL.Dto.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AHC_MLK.Controllers.Admin
{
    public class BoardListController : Controller
    {
        // GET: BoardList
        public ActionResult Index()
        {
            return View(BoardListDao.Instance.GetDataList());
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BoardListDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    string result = BoardListDao.Instance.SaveDataList(model, "add");
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

        // GET: ContentList/Edit/5
        public ActionResult Edit(int id)
        {
            return View(BoardListDao.Instance.GetDataList().Find(smodel => smodel.id == id));
        }

        // POST: ContentList/Edit/5
        [HttpPost]
        public ActionResult Edit(BoardListDto model)
        {
            try
            {
                string result = BoardListDao.Instance.SaveDataList(model, "edit");
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

        public ActionResult Delete(BoardListDto model)
        {
            try
            {
                string result = BoardListDao.Instance.SaveDataList(model, "del");
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
