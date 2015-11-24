using QuanLyKho.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyKho.Areas.Main.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Main/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}