
using System.Collections.Generic;
using System.Linq;
using WebsiteBanDongHo.Models.Context;
using WebsiteBanDongHo.Models.Service;

namespace WebsiteBanDongHo.Models.Implement
{
    public class HomeImplement : HomeService
    {
        // Phương thức Lấy về danh sách sản phẩm mới nhất
        // @number là số lượng sản phẩm lấy về
        public List<SANPHAM> GetNewProducts(int number)
        {
            List<SANPHAM> Result = new List<SANPHAM>();
            // Mã Linq lấy về danh sách sản phẩm sắp xếp theo Mã
            IEnumerable<SANPHAM> sanpham = null;
            using (var db = new BANDONGHOEntities())
            {
                sanpham = from sp in db.SANPHAMs
                          orderby sp.MASP descending
                          select sp;
                // Cắt ra @number phần tử
                if (sanpham != null)
                {
                    Result = sanpham.Take(number).ToList();
                }
            }
            
            return Result;
                
        }

        // Phương thức Lấy về danh sách sản phẩm rẻ nhất
        // @number là số lượng sản phẩm lấy về
        public List<SANPHAM> GetSaveProducts(int number)
        {
            List<SANPHAM> Result = new List<SANPHAM>();
            // Mã Linq lấy về danh sách sản phẩm sắp xếp theo Giá
            IEnumerable<SANPHAM> sanpham = null;
            using (var db = new BANDONGHOEntities())
            {
                sanpham = (from sp in db.SANPHAMs
                          orderby sp.DONGIA descending
                          select sp);
                // Cắt ra @number phần tử
                if (sanpham != null)
                {
                    Result = sanpham.Take(number).ToList();
                }
            }
            
            return Result;
        }
    }
}