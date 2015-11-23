using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyKho.Models.Entities;
using System.IO;
using QuanLyKho.Areas.Admin.Models;

namespace QuanLyKho.Areas.Admin.Controllers
{
    public class HinhAnhController : Controller
    {
        private Entities db = new Entities();

        // GET: Admin/HinhAnh
        public ActionResult Index()
        {
            var hinhAnhs = db.HinhAnhs.Include(h => h.HangHoa);
            return View(hinhAnhs.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Picture ptr,HttpPostedFileBase file)
        {
            if (file.ContentLength>0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Image"), fileName);
                file.SaveAs(path);
            }
            return RedirectToAction("Index");
        }

        // GET: Admin/HinhAnh/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HinhAnh hinhAnh = db.HinhAnhs.Find(id);
            if (hinhAnh == null)
            {
                return HttpNotFound();
            }
            return View(hinhAnh);
        }

        // GET: Admin/HinhAnh/Create
        public ActionResult Create()
        {
            ViewBag.MaHH = new SelectList(db.HangHoas, "MaHH", "TenHH");
            return View();
        }

        // POST: Admin/HinhAnh/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaIMG,TenIMG,MaHH,PathFile")] HinhAnh hinhAnh)
        {
            if (ModelState.IsValid)
            {
                db.HinhAnhs.Add(hinhAnh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHH = new SelectList(db.HangHoas, "MaHH", "TenHH", hinhAnh.MaHH);
            return View(hinhAnh);
        }

        // GET: Admin/HinhAnh/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HinhAnh hinhAnh = db.HinhAnhs.Find(id);
            if (hinhAnh == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHH = new SelectList(db.HangHoas, "MaHH", "TenHH", hinhAnh.MaHH);
            return View(hinhAnh);
        }

        // POST: Admin/HinhAnh/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaIMG,TenIMG,MaHH,PathFile")] HinhAnh hinhAnh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hinhAnh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHH = new SelectList(db.HangHoas, "MaHH", "TenHH", hinhAnh.MaHH);
            return View(hinhAnh);
        }

        // GET: Admin/HinhAnh/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HinhAnh hinhAnh = db.HinhAnhs.Find(id);
            if (hinhAnh == null)
            {
                return HttpNotFound();
            }
            return View(hinhAnh);
        }

        // POST: Admin/HinhAnh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HinhAnh hinhAnh = db.HinhAnhs.Find(id);
            db.HinhAnhs.Remove(hinhAnh);
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
