using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyKho.Models.Entities;
using QuanLyKho.Areas.Common;

namespace QuanLyKho.Areas.Admin.Controllers
{
    public class NhomHangsController : Controller
    {
        private Entities db = new Entities();

        // GET: Admin/NhomHangs
        [HasCredential(RoleID = "VIEW_NH")]
        public ActionResult Index()
        {
            var nhomHangs = db.NhomHangs.Include(n => n.LoaiHang);
            return View(nhomHangs.ToList());
        }

        [HttpGet]
        public ActionResult GetsNhomHang()
        {
            return PartialView("_NhomHang", db.NhomHangs);
        }

        // GET: Admin/NhomHangs/Details/5
        [HasCredential(RoleID = "VIEW_NH")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhomHang nhomHang = db.NhomHangs.Find(id);
            if (nhomHang == null)
            {
                return HttpNotFound();
            }
            return View(nhomHang);
        }

        // GET: Admin/NhomHangs/Create
        [HasCredential(RoleID = "CREATE_NH")]
        public ActionResult Create()
        {
            ViewBag.MaLH = new SelectList(db.LoaiHangs, "MaLH", "TenLH");
            return View();
        }

        // POST: Admin/NhomHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HasCredential(RoleID = "CREATE_NH")]
        public ActionResult Create([Bind(Include = "MaNH,TenNH,MaLH")] NhomHang nhomHang)
        {
            if (ModelState.IsValid)
            {
                db.NhomHangs.Add(nhomHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLH = new SelectList(db.LoaiHangs, "MaLH", "TenLH", nhomHang.MaLH);
            return View(nhomHang);
        }

        // GET: Admin/NhomHangs/Edit/5
        [HasCredential(RoleID = "EDIT_NH")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhomHang nhomHang = db.NhomHangs.Find(id);
            if (nhomHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLH = new SelectList(db.LoaiHangs, "MaLH", "TenLH", nhomHang.MaLH);
            return View(nhomHang);
        }

        // POST: Admin/NhomHangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HasCredential(RoleID = "EDIT_NH")]
        public ActionResult Edit([Bind(Include = "MaNH,TenNH,MaLH")] NhomHang nhomHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhomHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLH = new SelectList(db.LoaiHangs, "MaLH", "TenLH", nhomHang.MaLH);
            return View(nhomHang);
        }

        // GET: Admin/NhomHangs/Delete/5
        [HasCredential(RoleID = "DEL_NH")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhomHang nhomHang = db.NhomHangs.Find(id);
            if (nhomHang == null)
            {
                return HttpNotFound();
            }
            return View(nhomHang);
        }

        // POST: Admin/NhomHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [HasCredential(RoleID = "DEL_NH")]
        public ActionResult DeleteConfirmed(string id)
        {
            NhomHang nhomHang = db.NhomHangs.Find(id);
            db.NhomHangs.Remove(nhomHang);
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
