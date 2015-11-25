﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyKho.Models.Entities;
using QuanLyKho.Models.Model;
using QuanLyKho.Areas.Common;

namespace QuanLyKho.Areas.Admin.Controllers
{
    public class NCCController : BaseController
    {
        private Entities db = new Entities();

        // GET: Admin/DoiTac
        [HasCredential(RoleID = "VIEW_KH")]
        public ActionResult Index()
        {
            return View(db.DoiTacs.Where(x => x.KieuDT == "NCC").ToList());
        }

        // GET: Admin/DoiTac/Details/5
        [HasCredential(RoleID = "VIEW_KH")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoiTac doiTac = db.DoiTacs.Where(x => x.KieuDT == "NCC" && x.MaDT == id).FirstOrDefault();
            if (doiTac == null)
            {
                return HttpNotFound();
            }
            return View(doiTac);
        }

        // GET: Admin/DoiTac/Create
        [HasCredential(RoleID = "CREATE_KH")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DoiTac/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDT,MaSoThue,FullName,SDT,Email,DiaChi,KieuDT")] DoiTac doiTac)
        {
            if (ModelState.IsValid)
            {
                db.DoiTacs.Add(doiTac);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doiTac);
        }

        // GET: Admin/DoiTac/Edit/5
        [HasCredential(RoleID = "CREATE_KH")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoiTac doiTac = db.DoiTacs.Where(x => x.KieuDT == "NCC" && x.MaDT == id).FirstOrDefault();
            if (doiTac == null)
                if (doiTac == null)
            {
                return HttpNotFound();
            }
            return View(doiTac);
        }

        // POST: Admin/DoiTac/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HasCredential(RoleID = "EDIT_KH")]
        public ActionResult Edit([Bind(Include = "MaDT,MaSoThue,FullName,SDT,Email,DiaChi,KieuDT")] DoiTac doiTac)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doiTac).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doiTac);
        }

        // GET: Admin/DoiTac/Delete/5
        [HasCredential(RoleID = "DEL_KH")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoiTac doiTac = db.DoiTacs.Find(id);
            if (doiTac == null)
            {
                return HttpNotFound();
            }
            return View(doiTac);
        }

        // POST: Admin/DoiTac/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [HasCredential(RoleID = "DEL_KH")]
        public ActionResult DeleteConfirmed(string id)
        {
            DoiTac doiTac = db.DoiTacs.Find(id);
            db.DoiTacs.Remove(doiTac);
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
