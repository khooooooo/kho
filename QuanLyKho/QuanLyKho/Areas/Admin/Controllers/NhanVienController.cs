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
    public class NhanVienController : BaseController
    {
        private Entities db = new Entities();

        // GET: Admin/NhanVien
        public ActionResult Index()
        {
            var nhanViens = db.NhanViens.Include(n => n.ChuCuaHang).Include(n => n.PhanQuyen);
            return View(nhanViens.ToList());
        }

        // GET: Admin/NhanVien/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // GET: Admin/NhanVien/Create
        public ActionResult Create()
        {
            ViewBag.TenTK_Chu = new SelectList(db.ChuCuaHangs, "TenTK", "FullName");
            ViewBag.MaPQ = new SelectList(db.PhanQuyens, "MaPQ", "TenPQ");
            return View();
        }

        // POST: Admin/NhanVien/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenTK,FullName,ChucVu,SDT,Email,MaPQ,Pwd,TenTK_Chu")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.NhanViens.Add(nhanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TenTK_Chu = new SelectList(db.ChuCuaHangs, "TenTK", "FullName", nhanVien.TenTK_Chu);
            ViewBag.MaPQ = new SelectList(db.PhanQuyens, "MaPQ", "TenPQ", nhanVien.MaPQ);
            return View(nhanVien);
        }

        // GET: Admin/NhanVien/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.TenTK_Chu = new SelectList(db.ChuCuaHangs, "TenTK", "FullName", nhanVien.TenTK_Chu);
            ViewBag.MaPQ = new SelectList(db.PhanQuyens, "MaPQ", "TenPQ", nhanVien.MaPQ);
            return View(nhanVien);
        }

        // POST: Admin/NhanVien/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TenTK,FullName,ChucVu,SDT,Email,MaPQ,Pwd,TenTK_Chu")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TenTK_Chu = new SelectList(db.ChuCuaHangs, "TenTK", "FullName", nhanVien.TenTK_Chu);
            ViewBag.MaPQ = new SelectList(db.PhanQuyens, "MaPQ", "TenPQ", nhanVien.MaPQ);
            return View(nhanVien);
        }

        // GET: Admin/NhanVien/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: Admin/NhanVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhanVien nhanVien = db.NhanViens.Find(id);
            db.NhanViens.Remove(nhanVien);
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
