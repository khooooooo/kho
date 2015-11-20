using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyKho.Models.Entities;
using QuanLyKho.Models.Model;

namespace QuanLyKho.Areas.Admin.Controllers
{
    public class HangHoaController : Controller
    {
        private Entities db = new Entities();

        // GET: Admin/HangHoa
        public ActionResult Index()
        {
            var hangHoas = db.HangHoas.Include(h => h.LoaiHang).Include(h => h.NhomHang);
            return View(hangHoas.ToList());
        }

        // GET: Admin/HangHoa/Details/5
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

        // GET: Admin/HangHoa/Create
        public ActionResult Create()
        {
            ViewBag.MaLH = new SelectList(db.LoaiHangs, "MaLH", "TenLH");
            ViewBag.MaNH = new SelectList(db.NhomHangs, "MaNH", "TenNH");
            return View();
        }

        // POST: Admin/HangHoa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHH,TenHH,SoLuong,KichThuoc,KhoiLuong,NgaySX,HanSD,LoSX,GiaBan,GiaNhap,TrinhTrang,DinhMuc,MaNH,MaLH")] HangHoa hangHoa)
        {
            if (ModelState.IsValid)
            {
                db.HangHoas.Add(hangHoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLH = new SelectList(db.LoaiHangs, "MaLH", "TenLH", hangHoa.MaLH);
            ViewBag.MaNH = new SelectList(db.NhomHangs, "MaNH", "TenNH", hangHoa.MaNH);
            return View(hangHoa);
        }

        // GET: Admin/HangHoa/Edit/5
        public ActionResult Edit(string id)
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
            ViewBag.MaLH = new SelectList(db.LoaiHangs, "MaLH", "TenLH", hangHoa.MaLH);
            ViewBag.MaNH = new SelectList(db.NhomHangs, "MaNH", "TenNH", hangHoa.MaNH);
            return View(hangHoa);
        }

        // POST: Admin/HangHoa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHH,TenHH,SoLuong,KichThuoc,KhoiLuong,NgaySX,HanSD,LoSX,GiaBan,GiaNhap,TrinhTrang,DinhMuc,MaNH,MaLH")] HangHoa hangHoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hangHoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLH = new SelectList(db.LoaiHangs, "MaLH", "TenLH", hangHoa.MaLH);
            ViewBag.MaNH = new SelectList(db.NhomHangs, "MaNH", "TenNH", hangHoa.MaNH);
            return View(hangHoa);
        }

        // GET: Admin/HangHoa/Delete/5
        public ActionResult Delete(string id)
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

        // POST: Admin/HangHoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HangHoa hangHoa = db.HangHoas.Find(id);
            db.HangHoas.Remove(hangHoa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [ChildActionOnly]
        public ActionResult _NhomHang()
        {
            var menu = new LeftMenu().list(); ;

            return PartialView(menu);
        }
    }
}
