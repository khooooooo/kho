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
    public class ChuCuaHangController : Controller
    {
        private Entities db = new Entities();

        // GET: Admin/ChuCuaHang
        [HasCredential(RoleID = "VIEW_CH")]
        public ActionResult Index()
        {
            var chuCuaHangs = db.ChuCuaHangs.Include(c => c.CuaHang);
            return View(chuCuaHangs.ToList());
        }

        // GET: Admin/ChuCuaHang/Details/5
        [HasCredential(RoleID = "VIEW_CH")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuCuaHang chuCuaHang = db.ChuCuaHangs.Find(id);
            if (chuCuaHang == null)
            {
                return HttpNotFound();
            }
            return View(chuCuaHang);
        }

        // GET: Admin/ChuCuaHang/Create
        [HasCredential(RoleID = "CREATE_CH")]
        public ActionResult Create()
        {
            ViewBag.MaCH = new SelectList(db.CuaHangs, "MaCH", "TenCH");
            return View();
        }

        // POST: Admin/ChuCuaHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HasCredential(RoleID = "CREATE_CH")]
        public ActionResult Create([Bind(Include = "TenTK,FullName,SDT,Email,DiaChi,Pwd,MaCH")] ChuCuaHang chuCuaHang)
        {
            if (ModelState.IsValid)
            {
                db.ChuCuaHangs.Add(chuCuaHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaCH = new SelectList(db.CuaHangs, "MaCH", "TenCH", chuCuaHang.MaCH);
            return View(chuCuaHang);
        }

        // GET: Admin/ChuCuaHang/Edit/5
        [HasCredential(RoleID = "EDIT_CH")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuCuaHang chuCuaHang = db.ChuCuaHangs.Find(id);
            if (chuCuaHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCH = new SelectList(db.CuaHangs, "MaCH", "TenCH", chuCuaHang.MaCH);
            return View(chuCuaHang);
        }

        // POST: Admin/ChuCuaHang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HasCredential(RoleID = "EDIT_CH")]
        public ActionResult Edit([Bind(Include = "TenTK,FullName,SDT,Email,DiaChi,Pwd,MaCH")] ChuCuaHang chuCuaHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chuCuaHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaCH = new SelectList(db.CuaHangs, "MaCH", "TenCH", chuCuaHang.MaCH);
            return View(chuCuaHang);
        }

        // GET: Admin/ChuCuaHang/Delete/5
        [HasCredential(RoleID = "DEL_CH")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuCuaHang chuCuaHang = db.ChuCuaHangs.Find(id);
            if (chuCuaHang == null)
            {
                return HttpNotFound();
            }
            return View(chuCuaHang);
        }

        // POST: Admin/ChuCuaHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [HasCredential(RoleID = "DEL_CH")]
        public ActionResult DeleteConfirmed(string id)
        {
            ChuCuaHang chuCuaHang = db.ChuCuaHangs.Find(id);
            db.ChuCuaHangs.Remove(chuCuaHang);
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
