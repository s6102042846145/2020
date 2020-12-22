using AHCBL.Component.Common;
using AHCBL.Dao;
using AHCBL.Dto;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AHC_MLK.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginDto model)
        {
            try
            {
                bool flgLogin = true;
                int member_id=0;
                string pUName = string.Empty;
                string member_level = string.Empty;
                string password = string.Empty;
                string pUid = Util.NVLString(model.username);
                string pAss = Util.NVLString(model.password);
                if (pUid == "" || pUid == null)
                {
                    //ViewBag.Message = "Username or Password Incorrect";
                    return View();
                }
                if (pAss == "" || pAss == null)
                {
                    //ViewBag.Message = "Username or Password Incorrect";
                    return View();
                }
                //LoginDao.Instance.ChkAuthDB(pUid, DataCryptography.Encrypt(pPwd), ref member_id, ref pUName, ref pCenter, ref pChannel);



                if (LoginDao.Instance.ChkAuthDB(pUid, ref member_id, ref pUName, ref member_level, ref password))
                {
                    EUser user = new EUser();
                    user.UserIP = GetUserIP();
                    user.member_id = member_id;
                    user.UserID = pUid;
                    user.UserName = pUName;
                    user.Login = DateTime.Now;

                    Varible.User = user;
                    Varible.User.member_id = member_id;

                    //เช็ค password ถูกหรือไม่
                    string pass = DataCryptography.Decrypt(password.ToString().Trim());
                    if (model.password != pass)
                    {
                        ViewBag.Message = "Username or Password Incorrect";
                        //UserDao.Instance.SaveUserLog("Log in", "Log in", "ขออภัย User ของท่านระบุ Password ไม่ถูกต้อง");
                        //return;
                        return View();
                    }
                    Varible.User.System = "Application Management";
                    Response.Redirect("MemberList", false);
                }
                return View();
            }
            catch (Exception e)
            {
                //ViewBag.Message = "Error : " + e.Message;
                return View();
            }
        }
        
        private string GetUserIP()
        {
            string ipList = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipList))
            {
                return ipList.Split(',')[0];
            }

            return Request.ServerVariables["REMOTE_ADDR"];
        }
    }
}