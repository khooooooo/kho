using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyKho.Areas.Admin.Controllers
{
    public class TongQuanController : BaseController
    {
        // GET: Admin/TongQuan
        public ActionResult Index()
        {
            return View();
        }
    }
}