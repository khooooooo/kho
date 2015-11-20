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
    public class GiaoDichController : Controller
    {
        private Entities db = new Entities();

        // GET: Admin/GiaoDich
        public ActionResult Index()
        {
            var hoaDons = db.HoaDons.Include(h => h.DoiTac).Include(h => h.NhanVien);
            return View(hoaDons.ToList());
        }

        // GET: Admin/GiaoDich/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // GET: Admin/GiaoDich/Create
        public ActionResult Create()
        {
            ViewBag.MADT = new SelectList(db.DoiTacs, "MaDT", "MaSoThue");
            ViewBag.TenTK_NV = new SelectList(db.NhanViens, "TenTK", "FullName");
            return View();
        }

        // POST: Admin/GiaoDich/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                HoaDon newHD = new HoaDon
                {
                    MaHD = hoaDon.MaHD,
                    LoaiHD = hoaDon.LoaiHD,
                    MADT = hoaDon.MADT,
                    TinhTrang = hoaDon.TinhTrang,
                    TienTra = hoaDon.TienTra,
                    TenTK_NV = hoaDon.TenTK_NV,
                    NgayTao = DateTime.Now
                };
                db.HoaDons.Add(newHD);
                db.SaveChanges();
            }

            ViewBag.MADT = new SelectList(db.DoiTacs, "MaDT", "MaSoThue", hoaDon.MADT);
            ViewBag.TenTK_NV = new SelectList(db.NhanViens, "TenTK", "FullName", hoaDon.TenTK_NV);
            return View(hoaDon);
        }

        // GET: Admin/GiaoDich/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MADT = new SelectList(db.DoiTacs, "MaDT", "MaSoThue", hoaDon.MADT);
            ViewBag.TenTK_NV = new SelectList(db.NhanViens, "TenTK", "FullName", hoaDon.TenTK_NV);
            return View(hoaDon);
        }

        // POST: Admin/GiaoDich/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHD,NgayTao,TinhTrang,TienTra,LoaiHD,TenTK_NV,MADT")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MADT = new SelectList(db.DoiTacs, "MaDT", "MaSoThue", hoaDon.MADT);
            ViewBag.TenTK_NV = new SelectList(db.NhanViens, "TenTK", "FullName", hoaDon.TenTK_NV);
            return View(hoaDon);
        }

        // GET: Admin/GiaoDich/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // POST: Admin/GiaoDich/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            db.HoaDons.Remove(hoaDon);
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
    }
}
