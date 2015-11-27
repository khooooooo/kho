using QuanLyKho.Areas.Common;
using QuanLyKho.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyKho.Areas.Sale.Controllers
{
    public class SaleController : Controller
    {
        
        private Entities db = new Entities();
        // GET: Sale/Sale
        public ActionResult Index()
        {
          
            return View(db.HinhAnhs.ToList());
        }
       
    }
}