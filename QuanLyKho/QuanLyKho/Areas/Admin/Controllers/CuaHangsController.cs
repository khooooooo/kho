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
    public class CuaHangsController : Controller
    {
        private Entities db = new Entities();

        // GET: Admin/CuaHangs
        [HasCredential(RoleID = "VIEW_CH")]
        public ActionResult Index()
        {
            var cuaHangs = db.CuaHangs.Include(c => c.KhoHang);
            return View(cuaHangs.ToList());
        }

        // GET: Admin/CuaHangs/Details/5
        [HasCredential(RoleID = "VIEW_CH")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuaHang cuaHang = db.CuaHangs.Find(id);
            if (cuaHang == null)
            {
                return HttpNotFound();
            }
            return View(cuaHang);
        }

        // GET: Admin/CuaHangs/Create
        [HasCredential(RoleID = "CREATE_CH")]
        public ActionResult Create()
        {
            ViewBag.MaKho = new SelectList(db.KhoHangs, "MaKho", "TenKho");
            return View();
        }

        // POST: Admin/CuaHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HasCredential(RoleID = "CREATE_CH")]
        public ActionResult Create([Bind(Include = "MaCH,TenCH,MaKho")] CuaHang cuaHang)
        {
            if (ModelState.IsValid)
            { 
                var result = db.CuaHangs.Count();
                int id = result + 1;
                CuaHang ch = new CuaHang
                {
                    MaCH = "CH000" + Convert.ToString(id),
                    MaKho=cuaHang.MaKho,
                    TenCH=cuaHang.TenCH
                };
                db.CuaHangs.Add(ch);
                db.SaveChanges();
                return RedirectToAction("Create","ChuCuaHang", new { area = "Admin"});
            }

            ViewBag.MaKho = new SelectList(db.KhoHangs, "MaKho", "TenKho", cuaHang.MaKho);
            return View(cuaHang);
        }

        // GET: Admin/CuaHangs/Edit/5
        [HasCredential(RoleID = "EDIT_CH")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuaHang cuaHang = db.CuaHangs.Find(id);
            if (cuaHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKho = new SelectList(db.KhoHangs, "MaKho", "TenKho", cuaHang.MaKho);
            return View(cuaHang);
        }

        // POST: Admin/CuaHangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HasCredential(RoleID = "EDIT_CH")]
        public ActionResult Edit([Bind(Include = "MaCH,TenCH,MaKho")] CuaHang cuaHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuaHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKho = new SelectList(db.KhoHangs, "MaKho", "TenKho", cuaHang.MaKho);
            return View(cuaHang);
        }

        // GET: Admin/CuaHangs/Delete/5
        [HasCredential(RoleID = "DEL_CH")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuaHang cuaHang = db.CuaHangs.Find(id);
            if (cuaHang == null)
            {
                return HttpNotFound();
            }
            return View(cuaHang);
        }

        // POST: Admin/CuaHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [HasCredential(RoleID = "DEL_CH")]
        public ActionResult DeleteConfirmed(string id)
        {
            CuaHang cuaHang = db.CuaHangs.Find(id);
            db.CuaHangs.Remove(cuaHang);
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
