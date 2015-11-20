using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyKho.Models.Entities;
namespace QuanLyKho.Models.Model
{
    public class LeftMenu
    {
        QuanLyKho.Models.Entities.Entities db = null;
        public LeftMenu()
        {
            db = new QuanLyKho.Models.Entities.Entities();
        }
        public List<NhomHang> list()
        {
            var q = from p in db.NhomHangs select p;
            var listnh = new List<NhomHang>();
            foreach(var item in q)
            {
                listnh.Add(item);
            }
            return listnh;
        }
    }
}