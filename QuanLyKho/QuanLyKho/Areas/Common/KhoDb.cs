using QuanLyKho.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyKho.Areas.Common
{
    public class KhoDb
    {
        Entities db = new Entities();
        public NhanVien GetByID(string id)
        {
            return db.NhanViens.FirstOrDefault(c => c.TenTK.Equals(id));
        }
        public bool Login(string id, string pass)
        {
            var q = db.NhanViens.Count(c => c.TenTK == id && c.Pwd == pass);
            if (q >0 ) return true;
            else return false;
        }
    }
}