using AHCBL.Component.Common;
using AHCBL.Dao;
using AHCBL.Dto;
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
                string pCenter = string.Empty;
                string pChannel = string.Empty;
                string pUid = Util.NVLString(model.username);
                if(pUid=="" || pUid == null)
                {
                    
                }
                string pPwd = Util.NVLString(model.password);

                bool beAdmin = LoginDao.Instance.isAdmin(pUid);
                if (flgLogin)
                //if (true)
                {
                    if (beAdmin)
                    {
                        EUser user = new EUser();
                        user.UserIP = GetUserIP();
                        user.member_id = 1;
                        user.UserID = "ADMIN";
                        user.UserName = "ADMIN";
                        user.IbcCode = "AHC";
                        user.IS_Admin = true;
                        user.Login = DateTime.Now;
                        Varible.User = user;
                        Varible.User.System = "Application Management";
                        Response.Redirect("~/MemberList", false);
                    }
                    else if (LoginDao.Instance.ChkAuthDB(pUid, ref member_id,ref pUName, ref pCenter, ref pChannel) || LoginDao.Instance.ChkAuthDB(pUid, DataCryptography.Encrypt(pPwd), ref member_id, ref pUName, ref pCenter, ref pChannel))
                    {
                        EUser user = new EUser();
                        user.UserIP = GetUserIP();
                        user.member_id = member_id;
                        user.UserID = pUid;
                        user.UserName = pUName;
                        user.IbcCode = pCenter;
                        user.Login = DateTime.Now;
                        user.Channel = pChannel;

                        Varible.User = user;

                        DataRow dto = LoginDao.Instance.GetUserByID(user.UserID);
                        if (dto != null)
                        {
                            user.lelvel = Util.NVLBool(dto["member_lelvel"]);
                            //เช็ค User Active อยู่หรือไม่
                            if (!Util.NVLBool(dto["status"]))
                            {
                                ViewBag.Message = "Apologize User Inactive.";
                                //return;
                            }

                            //เช็ค User Expire หรือไม่
                            //if (dto["EXPIRE_DATETIME"] != null)
                            //{
                            //    DateTime sysDate = Util.NVLDate(DateTime.Now, "dd/MM/yyyy");
                            //    DateTime baseDate = Util.NVLDate(dto["EXPIRE_DATETIME"], "dd/MM/yyyy");
                            //    int daysDiff = ((TimeSpan)(sysDate - baseDate)).Days;
                            //    if (daysDiff > 0)
                            //    {
                            //        lbDisplay.Text = "ขออภัย User ของท่าน Expire แล้ว ท่านไม่ได้รับอนุญาตให้เข้าใช้งานระบบ";
                            //        UserDao.Instance.SaveUserLog("Log in", "Log in", "ขออภัย User ของท่าน Expire แล้ว ท่านไม่ได้รับอนุญาตให้เข้าใช้งานระบบ");
                            //        return;
                            //    }
                            //}
                        }

                        //check password for temp user
                        
                            //เช็ค password ถูกหรือไม่
                            string pass = DataCryptography.Decrypt(dto["password"].ToString().Trim());
                            if (model.password != pass)
                            {
                                ViewBag.Message = "Username or Password Incorrect";
                                //UserDao.Instance.SaveUserLog("Log in", "Log in", "ขออภัย User ของท่านระบุ Password ไม่ถูกต้อง");
                                //return;
                            }
                        

                        try
                        {
                            //for dev, allow multi-login 
                            string nokick = System.Configuration.ConfigurationManager.AppSettings["nokick"];
                            if (!(string.IsNullOrEmpty(nokick)))
                            {
                                //if (user.System == "REGISTRAR")
                                //{
                                //    UserDao.Instance.SetLoggedInStatus(user, this.Session.SessionID, true, 32);
                                //    UserDao.Instance.LogLogin("Login Success(Dev)");
                                //    Response.Redirect("~/Module/Home.aspx", false);
                                //}
                                //else if (user.System == "BOND_REPRESENTATIVE")
                                //{
                                //    UserDao.Instance.SetLoggedInStatus(user, this.Session.SessionID, true, 32);
                                //    UserDao.Instance.LogLogin("Login Success(Dev)");
                                //    Response.Redirect("~/Module/BR_Home.aspx", false);
                                //}
                                //else if (user.System == "TEMP")
                                //{
                                //    UserDao.Instance.SetLoggedInStatus(user, this.Session.SessionID, true, 32);
                                //    UserDao.Instance.LogLogin("Login Success(Dev)");
                                //    Response.Redirect("~/Module/CT_Home.aspx", false);
                                //}
                                Varible.User.System = "Application Management";
                                //UserDao.Instance.SetLoggedInStatus(user, this.Session.SessionID, true, 32);
                                //UserDao.Instance.LogLogin("Login Success(Dev)");
                                Response.Redirect("~/Admin/MemberList", false);
                            }
                        }
                        catch { }

                        ////user.UserIP = "127.0.0.2";
                        //int option = UserDao.Instance.GetOptionUserInfo(user.UserID, user.UserIP, this.Session.SessionID);

                        //if (option == 3)
                        //{
                        //    //string script = @"<script>if(confirm('userนี้เข้าสู่ระบบไปแล้วโดยใช้เครื่องอื่น คุณต้องการเข้าสู่ระบบโดยให้ล้างล็อกอินเครื่องอื่นหรือไม่?'))
                        //    //{window.location.href='LoginRedirect.aspx?option=31&sessionID=" + this.Session.SessionID + "'}" +
                        //    //"else {window.location.href='LoginRedirect.aspx?option=32&sessionID=" + this.Session.SessionID + "'}" +
                        //    //"</script>";
                        //    string script = @"<script>if(confirm('userนี้เข้าสู่ระบบไปแล้วโดยใช้เครื่องอื่น คุณต้องการเข้าสู่ระบบโดยให้ล้างล็อกอินเครื่องอื่นหรือไม่?'))
                        //                          {window.location.href='LoginRedirect.aspx?option=31&sessionID=" + this.Session.SessionID + "'}" +
                        //                    "</script>";
                        //    Page.RegisterStartupScript("loginScript1", script);
                        //}
                        //else
                        //{
                        //    //if (user.System == "REGISTRAR")
                        //    //{
                        //    //    UserDao.Instance.SetLoggedInStatus(user, this.Session.SessionID, true, option);
                        //    //    UserDao.Instance.LogLogin("Login Success");
                        //    //    Response.Redirect("~/Module/Home.aspx", false);
                        //    //}
                        //    //else if (user.System == "BOND_REPRESENTATIVE")
                        //    //{
                        //    //    UserDao.Instance.SetLoggedInStatus(user, this.Session.SessionID, true, option);
                        //    //    UserDao.Instance.LogLogin("Login Success");
                        //    //    Response.Redirect("~/Module/BR_Home.aspx", false);
                        //    //}
                        //    //else if (user.System == "TEMP")
                        //    //{
                        //    //    UserDao.Instance.SetLoggedInStatus(user, this.Session.SessionID, true, option);
                        //    //    UserDao.Instance.LogLogin("Login Success");
                        //    //    Response.Redirect("~/Module/CT_Home.aspx", false);
                        //    //}
                        //    Varible.User.System = "IPO Application Management";
                        //    UserDao.Instance.SetLoggedInStatus(user, this.Session.SessionID, true, option);
                        //    UserDao.Instance.LogLogin("Login Success");
                        //    Response.Redirect("~/Module/CT_Home.aspx", false);
                        //}
                    }
                    else
                    {
                        ViewBag.Message = "Username or Password Incorrect";
                        //UserDao.Instance.SaveUserLog("Log in", "Log in Error", "Log in Error, User not have authorization");
                    }
                }
                else
                {
                    ViewBag.Message = "Username or Password Incorrect";
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