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
    public class QuanLyChiTietDonHangController : Controller
    {
        banhangEntities1 db = new banhangEntities1();
        //
        // GET: /QuanLyChiTietDonHang/
       public ActionResult Index(int? page,int? madonhang)
        {
            //var dulieu = from kh in db.KhachHangs
            //             from ct in db.ChiTietDonHang
            //             from ct in db.ChiTietDonHang
            //             where (kh.maKH == ct.maKH) && (ct.madonhang == ct.madonhang)
            //             select new { hoten = kh.ten };
            //ViewBag.HoTen = dulieu;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(db.ChiTietDonHang.Where(n=>n.madonhang==madonhang).ToList().OrderBy(n=>n.madonhang).ToPagedList(pageNumber,pageSize));
        }
       //Thêm mới
      
       //Chỉnh sửa 
       [HttpGet]
       public ActionResult ChinhSua(int? madonhang,string maSP)
       {
           if (madonhang == null)
           {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
           }
           ChiTietDonHang ct = db.ChiTietDonHang.Find(madonhang,maSP);
           if (ct == null)
           {
               Response.StatusCode = 404;
               return null;
           }
           ViewBag.maSP = new SelectList(db.SanPham.ToList().OrderBy(n => n.tenSP), "maSP", "tenSP");
           return View(ct);
       }

       [HttpPost]
       public ActionResult ChinhSua( ChiTietDonHang ct,int? madonhang)
       {
           if (ModelState.IsValid)
           {
               db.Entry(ct).State = System.Data.Entity.EntityState.Modified;
               db.SaveChanges();
               ViewBag.maSP = new SelectList(db.SanPham.ToList().OrderBy(n => n.tenSP), "maSP", "tenSP");
               return RedirectToAction("Index", "QuanLyChiTietDonHang", new {@madonhang=madonhang});
           }
           return View();
       }
       //Hiển thị
       public ActionResult HienThi(int madonhang, string maSP)
       {
            ChiTietDonHang ct = db.ChiTietDonHang.Find(madonhang,maSP);
           if (ct == null)
           {
               Response.StatusCode = 404;
               return null;
           }
           return View(ct);
       }
       //Xoá 
       public ActionResult Xoa(int madonhang,string maSP)
       {
            ChiTietDonHang ct = db.ChiTietDonHang.Find(madonhang,maSP);
           if (ct == null)
           {
               Response.StatusCode = 404;
               return null;
           }
           return View(ct);
       }
       //Xác nhận xoá
       [HttpPost, ActionName("Xoa")]
       public ActionResult XacNhanXoa(int madonhang,string maSP)
       {
            ChiTietDonHang ct = db.ChiTietDonHang.Find(madonhang,maSP);
           if (ct == null)
           {
               Response.StatusCode = 404;
               return null;
           }
           db.ChiTietDonHang.Remove(ct);
           db.SaveChanges();
           return RedirectToAction("Index", "QuanLyChiTietDonHang", new { @madonhang = madonhang });
       }
	}
}