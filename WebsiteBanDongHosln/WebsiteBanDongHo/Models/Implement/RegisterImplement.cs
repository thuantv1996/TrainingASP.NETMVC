using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanDongHo.Models.Context;
using WebsiteBanDongHo.Models.Service;
using WebsiteBanDongHo.Models.ViewModel;

namespace WebsiteBanDongHo.Models.Implement
{
    public class RegisterImplement : RegisterService
    {
        private string GetMD5(string txt)
        {
            String str = "";
            Byte[] buffer = System.Text.Encoding.UTF8.GetBytes(txt);
            System.Security.Cryptography.MD5CryptoServiceProvider md5 =
                new System.Security.Cryptography.MD5CryptoServiceProvider();
            buffer = md5.ComputeHash(buffer);
            foreach (Byte b in buffer)
            {
                str += b.ToString("X2");
            }
            return str;
        }

        public bool Register(RegisterViewModel register)
        {
            using (var db = new BANDONGHOEntities())
            {
                try
                {
                    TAIKHOAN tk = new TAIKHOAN { TENDN = register.Username, MATKHAU = GetMD5(register.Password), NGAYDANGKY = DateTime.Now, TRANGTHAI = true, MALOAITK = "LK00002" };
                    db.TAIKHOANs.Add(tk);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
               
            }         
        }

        public bool isExistAccount(string account)
        {
            using (var db = new BANDONGHOEntities())
            {
                TAIKHOAN taikhoan = (from tk in db.TAIKHOANs
                                     where tk.TENDN.Equals(account)
                                     select tk).SingleOrDefault();
                if (taikhoan != null)
                {
                    return true;
                }
                return false;
            }             
        }
    }
}