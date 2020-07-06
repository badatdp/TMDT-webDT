using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheGioiDiDong_v3.Models;
using PagedList.Mvc;
using PagedList;
using System.Net;
namespace TheGioiDiDong_v3.Controllers
{
    public class QuanLyDonHangController : Controller
    {
        banhangEntities1 db = new banhangEntities1();
        //
        // GET: /QuanLyDonHang/
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(db.DonHang.ToList().OrderBy(n=>n.madonhang).ToPagedList(pageNumber,pageSize));
        }
        //Thêm mới
        [HttpGet]
        public ActionResult ThemMoi()
        {
            ViewBag.maKH = new SelectList(db.KhachHang.Where(n => n.role != 1).ToList().OrderBy(n => n.ten), "maKH", "ten");
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(DonHang dh)
        {
            if (ModelState.IsValid)
            {
                db.DonHang.Add(dh);
                db.SaveChanges();
                ViewBag.maKH = new SelectList(db.KhachHang.Where(n=>n.role!=1).ToList().OrderBy(n=>n.ten), "maKH","ten");
                return RedirectToAction("Index");
            }
            return View();
        }
        //Chỉnh sửa 
        [HttpGet]
        public ActionResult ChinhSua(int? madonhang)
        {
            if (madonhang == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang dh = db.DonHang.Find(madonhang);
            if (dh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.maKH = new SelectList(db.KhachHang.Where(n => n.role != 1).ToList().OrderBy(n => n.ten), "maKH", "ten");
            return View(dh);
        }

        [HttpPost]
        public ActionResult ChinhSua(DonHang dh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dh).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                ViewBag.maKH = new SelectList(db.KhachHang.Where(n => n.role != 1).ToList().OrderBy(n => n.ten), "maKH", "ten");
                return RedirectToAction("Index");
            }
            return View();
        }
        //Hiển thị
        public ActionResult HienThi(int madonhang)
        {
            DonHang dh = db.DonHang.SingleOrDefault(n => n.madonhang ==madonhang);
            if (dh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dh);
        }
        //Xoá 
        public ActionResult Xoa(int madonhang)
        {
            DonHang dh = db.DonHang.SingleOrDefault(n => n.madonhang ==madonhang);
            if (dh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dh);
        }
        //Xác nhận xoá
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int madonhang)
        {
            DonHang dh = db.DonHang.SingleOrDefault(n => n.madonhang ==madonhang);
            if (dh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.DonHang.Remove(dh);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
	}
}