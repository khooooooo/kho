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
                    if ((q.MaPQ == CommonConstant.Admin_Group) || (q.MaPQ == CommonConstant.Mod_Group))
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
    }
}