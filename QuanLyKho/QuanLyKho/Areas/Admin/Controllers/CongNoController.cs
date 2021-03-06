﻿using System;
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
    public class CongNoController : BaseController
    {
        private Entities db = new Entities();

        // GET: Admin/CongNoes
        [HasCredential(RoleID = "VIEW_CONGNO")]
        public ActionResult Index()
        {
            var congNoes = db.CongNoes.Include(c => c.DoiTac).Include(c => c.HoaDon);
            return View(congNoes.ToList());
        }

        // GET: Admin/CongNoes/Details/5
        [HasCredential(RoleID = "VIEW_CONGNO")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongNo congNo = db.CongNoes.Find(id);
            if (congNo == null)
            {
                return HttpNotFound();
            }
            return View(congNo);
        }

        // GET: Admin/CongNoes/Create
        [HasCredential(RoleID = "CREATE_CONGNO")]
        public ActionResult Create()
        {
            ViewBag.MaDT = new SelectList(db.DoiTacs, "MaDT", "MaSoThue");
            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "TenTK_NV");
            return View();
        }

        // POST: Admin/CongNoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HasCredential(RoleID = "CREATE_CONGNO")]
        public ActionResult Create([Bind(Include = "MaCN,MaDT,LoaiCN,MaHD,GiaTri")] CongNo congNo)
        {
            if (ModelState.IsValid)
            {
                db.CongNoes.Add(congNo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDT = new SelectList(db.DoiTacs, "MaDT", "MaSoThue", congNo.MaDT);
            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "TenTK_NV", congNo.MaHD);
            return View(congNo);
        }

        // GET: Admin/CongNoes/Edit/5
        [HasCredential(RoleID = "EDIT_CONGNO")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongNo congNo = db.CongNoes.Find(id);
            if (congNo == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDT = new SelectList(db.DoiTacs, "MaDT", "MaSoThue", congNo.MaDT);
            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "TenTK_NV", congNo.MaHD);
            return View(congNo);
        }

        // POST: Admin/CongNoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HasCredential(RoleID = "EDIT_CONGNO")]
        public ActionResult Edit([Bind(Include = "MaCN,MaDT,LoaiCN,MaHD,GiaTri")] CongNo congNo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(congNo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDT = new SelectList(db.DoiTacs, "MaDT", "MaSoThue", congNo.MaDT);
            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "TenTK_NV", congNo.MaHD);
            return View(congNo);
        }

        // GET: Admin/CongNoes/Delete/
        [HasCredential(RoleID = "DEL_CONGNO")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongNo congNo = db.CongNoes.Find(id);
            if (congNo == null)
            {
                return HttpNotFound();
            }
            return View(congNo);
        }

        // POST: Admin/CongNoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [HasCredential(RoleID = "DEL_CONGNO")]
        public ActionResult DeleteConfirmed(string id)
        {
            CongNo congNo = db.CongNoes.Find(id);
            db.CongNoes.Remove(congNo);
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
