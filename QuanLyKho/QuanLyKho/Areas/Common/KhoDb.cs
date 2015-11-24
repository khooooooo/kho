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
        public int Login(string id, string pass)
        {
            var q = db.NhanViens.SingleOrDefault(c => c.TenTK == id);
            if (q == null )
            {
                return 0;
            }
            else
            {
                if(q.Pwd == pass)
                {
                    return 1;
                }
                else { return -1; }
            }
        }
    }
}