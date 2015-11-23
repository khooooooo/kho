using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyKho.Models.Entities;

namespace QuanLyKho.Areas.Admin.Controllers
{
    public class TonKhoController : Controller
    {
        private Entities db = new Entities();

        // GET: Admin/TonKho
        public ActionResult Index()
        {
            var hangHoas = db.HangHoas.Include(h => h.LoaiHang).Include(h => h.NhomHang);
            return View(hangHoas.Where(x => x.SoLuong>0).ToList());
        }

        // GET: Admin/TonKho/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangHoa hangHoa = db.HangHoas.Find(id);
            if (hangHoa == null)
            {
                return HttpNotFound();
            }
            return View(hangHoa);
        }   

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
