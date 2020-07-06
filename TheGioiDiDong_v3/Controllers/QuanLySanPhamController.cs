using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheGioiDiDong_v3.Models;
using PagedList.Mvc;
using PagedList;
using System.IO;
namespace TheGioiDiDong_v3.Controllers
{
    public class QuanLySanPhamController : Controller
    {
        banhangEntities1 db = new banhangEntities1();
        //
        // GET: /QuanLySanPham/
        [ValidateInput(false)]
        public ActionResult Index(int? page)
        {
            //string ten=Request.QueryString[0].ToString();
            //ViewBag.ten = ten;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(db.SanPham.ToList().OrderBy(n => n.maSP).ToPagedList(pageNumber, pageSize));
        }
        //Thêm mới
        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(SanPham sanpham, HttpPostedFileBase fileUpload)
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
                sanpham.hinh = fileUpload.FileName;
                db.SanPham.Add(sanpham);
                db.SaveChanges();
                return RedirectToAction("Index", "QuanLySanPham");
            }
            return View();
        }
        //Chỉnh sửa
        [HttpGet]
        public ActionResult ChinhSua(string maSP)
        {

            //lấy đối tượng sp theo mã
            SanPham sp = db.SanPham.SingleOrDefault(n => n.maSP == maSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sp);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(SanPham sp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //Thêm vào cơ sở dữ liệu
            return View();
        }
        //Hiển thị sản phẩm
        public ActionResult HienThi(string maSP)
        {
            SanPham sp = db.SanPham.SingleOrDefault(n => n.maSP == maSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sp);
        }
        //Xoá sản phẩm
        public ActionResult Xoa(string maSP)
        {
            SanPham sp = db.SanPham.SingleOrDefault(n => n.maSP == maSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sp);
        }
        //Xác nhân xoá
        [HttpPost,ActionName("Xoa")]
        public ActionResult XacNhanXoa(string maSP)
        {
            SanPham sp = db.SanPham.SingleOrDefault(n => n.maSP == maSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.SanPham.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
