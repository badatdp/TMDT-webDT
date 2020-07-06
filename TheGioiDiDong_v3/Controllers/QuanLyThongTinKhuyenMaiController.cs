using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheGioiDiDong_v3.Models;
using PagedList.Mvc;
using PagedList;
using System.Net;
using System.IO;
namespace TheGioiDiDong_v3.Controllers
{
    public class QuanLyThongTinKhuyenMaiController : Controller
    {
        banhangEntities1 db = new banhangEntities1();
        //
        // GET: /QuanLyThongTinKhuyenMai/
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(db.KhuyenMai.ToList().OrderBy(n => n.maKM).ToPagedList(pageNumber, pageSize));
        }

        //Thêm chương trình khuyến mãi
        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(KhuyenMai km, HttpPostedFileBase fileUpload)
        {
            if (fileUpload == null)
            {
                ViewBag.thongbao = "Chọn hình ảnh";
                return View();
            }
            if (ModelState.IsValid)
            {
                //Lưu tên file
                var fileName = Path.GetFileName(fileUpload.FileName);
                //Lưu đường dẫn của file
                var path = Path.Combine(Server.MapPath("~/Content/image"), fileName);
                if (System.IO.File.Exists(path))
                {
                    ViewBag.thongbao = "Hình ảnh đã tồn tại";
                }
                else
                {
                    fileUpload.SaveAs(path);
                }
                km.hinhKM = fileUpload.FileName;
                db.KhuyenMai.Add(km);
                db.SaveChanges();
                return RedirectToAction("Index", "QuanLyThongTinKhuyenMai");
            }
            return View();
        }
        //Chỉnh sửa khuyến mãi
        [HttpGet]
       
        public ActionResult ChinhSua(int? maKM)
        {
            if (maKM == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhuyenMai km = db.KhuyenMai.Find(maKM);
            if (km == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(km);
        }

        [HttpPost] 
        [ValidateInput(false)]
        public ActionResult ChinhSua(KhuyenMai km)
        {
            if (ModelState.IsValid)
            {
                db.Entry(km).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        //Hiển thị
        public ActionResult HienThi(int maKM)
        {
            KhuyenMai km = db.KhuyenMai.SingleOrDefault(n => n.maKM == maKM);
            if (km == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(km);
        }
        //Xoá Khuyến mãi
        public ActionResult Xoa(int maKM)
        {
           KhuyenMai km = db.KhuyenMai.SingleOrDefault(n => n.maKM == maKM);
            if (km == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(km);
        }
        //Xác nhận xoá
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int maKM)
        {
           KhuyenMai km = db.KhuyenMai.SingleOrDefault(n => n.maKM == maKM);
            if (km == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.KhuyenMai.Remove(km);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
	}
}