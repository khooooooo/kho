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
using QuanLyKho.Areas.Common;

namespace QuanLyKho.Areas.Admin.Controllers
{
    public class HinhAnhController : BaseController
    {
        string fileName;
        string path;
        private Entities db = new Entities();

        // GET: Admin/HinhAnh
        [HasCredential(RoleID = "VIEW_HH")]
        public ActionResult Index()
        {
            var hinhAnhs = db.HinhAnhs.Include(h => h.HangHoa);
            return View(hinhAnhs.ToList());
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HasCredential(RoleID = "VIEW_HH")]
        public ActionResult Index(HinhAnh hinhAnh, HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                fileName = Path.GetFileName(file.FileName);
                 path = Path.Combine(Server.MapPath("~/Content/Image"), fileName);
                file.SaveAs(path);
                if (ModelState.IsValid)
                {
                    var result = db.HinhAnhs.Count();
                    HinhAnh img = new HinhAnh
                    {
                        MaHH = hinhAnh.MaHH,
                        MaIMG = "HA000" + result,
                        TenIMG = fileName,
                        PathFile = string.Join("/", "~/Content/Image", fileName)
                    };
                    db.HinhAnhs.Add(img);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
              
            }
            return View();
        }

        // GET: Admin/HinhAnh/Details/5
        [HasCredential(RoleID = "VIEW_HH")]
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
        [HasCredential(RoleID = "CREATE_HH")]
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
        [HasCredential(RoleID = "CREATE_HH")]
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
        [HasCredential(RoleID = "EDIT_HH")]
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
        [HasCredential(RoleID = "EDIT_HH")]
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
        [HasCredential(RoleID = "DEL_HH")]
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
