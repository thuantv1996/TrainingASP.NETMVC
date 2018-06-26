using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanDongHo.Models.Service;
using WebsiteBanDongHo.Models.ViewModel;
using WebsiteBanDongHo.Models.Context;

namespace WebsiteBanDongHo.Models.Implement
{
    public class LoginImplement : LoginService
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
        public bool CheckAccount(LoginViewModel login)
        {
            string matKhauMD5 = GetMD5(login.Pass);
            // tìm trong CSDL 
            using (var db = new BANDONGHOEntities())
            {
                TAIKHOAN taikhoan = (from tk in db.TAIKHOANs
                                     where tk.TENDN.Equals(login.Id) &&
                                     tk.MATKHAU == matKhauMD5
                                     select tk).FirstOrDefault();
                if(taikhoan!=null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}