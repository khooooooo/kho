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
        // Get Staff ID
        public NhanVien GetByID(string id)
        {
            return db.NhanViens.FirstOrDefault(c => c.TenTK.Equals(id));
        }

        //Get Admin ID
        public ChuCuaHang GetByIDAdmin(string id)
        {
            return db.ChuCuaHangs.FirstOrDefault(c => c.TenTK.Equals(id));
        }
        //Admin login
        public int LoginAdmin(string id, string pass, bool isLoginAdmin)
        {
            var q = db.ChuCuaHangs.SingleOrDefault(c => c.TenTK == id);
            if (q == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    if (q.MaPQ == CommonConstant.Admin_Group)
                    {
                        if (q.Pwd == pass)
                        {
                            return 1;
                        }
                        else { return -1; }
                    }
                    else return -2;
                }
                else
                {
                    if (q.Pwd == pass)
                    {
                        return 1;
                    }
                    else { return -1; }
                }
            }
        }


        // Staff login
        public int Login(string id, string pass, bool isLoginAdmin)
        {
            var q = db.NhanViens.SingleOrDefault(c => c.TenTK == id);
            if (q == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    if ((q.MaPQ == CommonConstant.Kho_Group) || (q.MaPQ == CommonConstant.Sale_Group))
                    {
                        if (q.Pwd == pass)
                        {
                            return 1;
                        }
                        else { return -1; }
                    }
                    else return -2;
                }
                else
                {
                    if (q.Pwd == pass)
                    {
                        return 1;
                    }
                    else { return -1; }
                }
            }
        }
        public List<string> GetListCredential(string userName)
        {
            var user = db.NhanViens.Single(x => x.TenTK == userName);
            var a = from p in db.Credentials
                    join q in db.PhanQuyens on p.UserGroupID equals q.MaPQ
                    join e in db.Roles on p.RoleID equals e.ID
                    where q.MaPQ == user.MaPQ
                    select  p.RoleID;
            return a.ToList();
        }
        public List<string> GetListCredentialbyAdmin(string userName)
        {
            var user = db.ChuCuaHangs.Single(x => x.TenTK == userName);
            var a = from p in db.Credentials
                    join q in db.PhanQuyens on p.UserGroupID equals q.MaPQ
                    join e in db.Roles on p.RoleID equals e.ID
                    where q.MaPQ == user.MaPQ
                    select p.RoleID;
            return a.ToList();
        }
        public HangHoa ViewDetail(string id)
        {
            HangHoa hoadon = db.HangHoas.SingleOrDefault(x=> x.MaHH == id);
            return hoadon;
        }
    }
}