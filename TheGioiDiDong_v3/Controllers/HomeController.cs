using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheGioiDiDong_v3.Models;
using PagedList;
using PagedList.Mvc;
namespace TheGioiDiDong_v3.Controllers
{
    public class HomeController : Controller
    {
        banhangEntities1 db = new banhangEntities1();
        public ActionResult Index()
        {
            ViewBag.HangMayTinh = new SelectList(db.SanPham.Where(n => n.loaiSP == "Máy tính"), "hangSX", "hangSX");
            var sanpham = db.SanPham.ToList();
            return View(sanpham);
        }
        public ActionResult maytinh(int? page)
        {
            //tạo biến số sản phẩm trên trang
            int pageSize = 8;
            //tạo biến số trang
            int pageNumber = (page ?? 1);
            var sanpham = db.SanPham.Where(n=>n.loaiSP=="Điện thoại Android").OrderBy(n=>n.maSP).ToPagedList(pageNumber, pageSize);
            return View(sanpham);
        }
        public ActionResult dienthoai(int? page)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            var sanpham = db.SanPham.Where(n => n.loaiSP == "Điện thoại Apple").OrderBy(n => n.maSP).ToPagedList(pageNumber, pageSize);
            return View(sanpham);
        }
        public ActionResult tablet(int? page)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            var sanpham = db.SanPham.Where(n => n.loaiSP == "Điện thoại Gaming").OrderBy(n => n.maSP).ToPagedList(pageNumber, pageSize);
            return View(sanpham);
        }
        public ActionResult khuyenmai(int?page)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            var km = db.KhuyenMai.OrderBy(n => n.maKM).ToPagedList(pageNumber,pageSize);
            return View(km);
        }
        public ActionResult tuyendung(int ?page)
        {
            int pageSize = 22;
            int pageNumber = (page ?? 1);
            var td = db.TuyenDung.OrderBy(n => n.ma).ToPagedList(pageNumber, pageSize);
            int dem = db.TuyenDung.Count();
            ViewBag.dem = dem.ToString();
            return View(td);
           
        }
        public ActionResult lienhe()
        {

            var lh = db.LienHe.ToList();
            return View(lh);
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult SanPhamTheoHangSX(string hangSX)
        {
            ////tạo biến số sản phẩm trên trang
            //int pageSize = 8;
            ////tạo biến số trang
            //int pageNumber = (page ?? 1);
            return View(db.SanPham.Where(n=>n.hangSX==hangSX).ToList());
        }
    }
}