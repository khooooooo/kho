using QuanLyKho.Areas.Common;
using QuanLyKho.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyKho.Areas.Sale.Controllers
{
    public class CartController : Controller
    {
        Entities db = new Entities();
        
        // GET: Sale/Cart
        public ActionResult Index()
        {
            var cart = Session[Common.Common.CartSession];
            var list = new List<HangHoaList>();
            if (cart != null)
            {
                list = (List<HangHoaList>)cart;
            }
            return View(list);
        }
        public ActionResult AddCart(string id, float soLuong, float tienTra, float donGia)
        {
            var kho = new KhoDb();
            var product = kho.ViewDetail(id);
            var session = Session[Common.Common.CartSession];
            if (session != null)
            {
                var list = (List<HangHoaList>)session;
                if (list.Exists(x => x.Product.MaHH == id))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.MaHH == id) item.SoLuong += soLuong;
                    }
                }
                else
                {
                    var item = new HangHoaList();
                    item.Product = product;
                    item.SoLuong = soLuong;
                    list.Add(item);
                }
            }
            else
            {
                //add hang vao list
                var item = new HangHoaList();
                item.Product= product;
                item.SoLuong = soLuong;
                var list = new List<HangHoaList>();
                list.Add(item);
                Session[Common.Common.CartSession] = list;
                // add hang vao DB
                // tao Ma Hoa Don
                string maHD = "";
                if (db.HoaDons.Count() != 0)
                {
                    var Nh = (from p in db.HoaDons
                              orderby p.MaHD descending
                              select p).Skip(0).Take(1);
                    string numberString = Nh.ToList()[0].MaHD.Substring(2);
                    int number = Convert.ToInt32(numberString);
                    number++;
                    numberString = number.ToString();
                    while (numberString.Length < 5)
                    {
                        numberString = "0" + numberString;
                    }
                    maHD = "HD" + numberString;
                }
                else
                {
                    maHD = "HD00001";
                }
                // Them HoaDon
                HoaDon hd = new HoaDon
                {
                    MaHD = maHD,
                    LoaiHD = true,
                    NgayTao = DateTime.Now,
                    TinhTrang = true,
                    TenTK_NV = Main.Controllers.AccountController.ID_NV,
                    TienTra = tienTra,

                };
                db.HoaDons.Add(hd);
                db.SaveChanges();
                //Them CT_HoaDon
              
                CT_HoaDon ct = new CT_HoaDon
                {
                    MaHD = maHD,
                    DonGia = donGia,
                    MaHH = id,
                    SoLuong = soLuong,
                   
                };
                db.CT_HoaDon.Add(ct);
                db.SaveChanges();
            }
            return RedirectToAction("Index","Cart");
        }
    }
}