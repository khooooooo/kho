using QuanLyKho.Areas.Admin.Models;
using QuanLyKho.Areas.Common;
using QuanLyKho.Areas.Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyKho.Areas.Main.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            var db = new KhoDb();
            var result = db.Login(model.Name, Encryptor.MD5Hash(model.Pwd),false);
            if (!ModelState.IsValid)
            {
                if (result == 1)
                {
                    var user = db.GetByID(model.Name);
                    var userSession = new Common.UserLogin();
                    userSession.UserName = user.TenTK;
                    var list = db.GetListCredential(model.Name);
                    Session.Add(Common.Common.SESSION_CREDENTIAL, list);
                    Session.Add(Common.Common.USER_SESSION, userSession);
                    return RedirectToAction("index", "GiaoDich", new { area = "Admin" });
                }
                else
                {
                    if (result == -1)
                        ModelState.AddModelError("", "Nhập sai password");
                    else
                    {
                        if (result == -2)
                            ModelState.AddModelError("", "Bạn không có quyền đăng nhập");
                    }

                }
               
            }
            return View();
        }
    }
}