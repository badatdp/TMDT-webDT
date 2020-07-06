using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheGioiDiDong_v3.Models;
using PagedList.Mvc;
using PagedList;
namespace TheGioiDiDong_v3.Controllers
{
    public class QuanLyTaiKhoanKhachHangController : Controller
    {
        banhangEntities1 db = new banhangEntities1();
        //
        // GET: /QuanLyTaiKhoanKhachHang/
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(db.KhachHang.ToList().Where(n=>n.role!=1).OrderBy(n => n.maKH).ToPagedList(pageNumber,pageSize));
        }
      
        //Thêm khách hàng
        [HttpGet]
        public ActionResult ThemKhachHang()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemKhachHang(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                db.KhachHang.Add(kh);
                db.SaveChanges();
                return RedirectToAction("Index", "QuanLyTaiKhoanKhachHang");
            }
            return View();
        }
        //Chỉnh sửa tài khoản khách hàng
        [HttpGet]
        public ActionResult ChinhSua(int? maKH)
        {
            if (maKH == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang kh = db.KhachHang.Find(maKH);
            if(kh==null)
            {
                Response.StatusCode=404;
                return null;
            }
            return View(kh);
        }

        [HttpPost]
        public ActionResult ChinhSua(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kh).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        //Hiển thị
        public ActionResult HienThi(int maKH)
        {
            KhachHang kh = db.KhachHang.SingleOrDefault(n => n.maKH == maKH);
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(kh);
        }
        //Xoá Khách hàng
        public ActionResult Xoa(int maKH)
        {
            KhachHang kh = db.KhachHang.SingleOrDefault(n => n.maKH == maKH);
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(kh);
        }
        //Xác nhận xoá
        [HttpPost,ActionName("Xoa")]
        public ActionResult XacNhanXoa(int maKH)
        {
            KhachHang kh = db.KhachHang.SingleOrDefault(n=>n.maKH==maKH);
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.KhachHang.Remove(kh);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
	}
}