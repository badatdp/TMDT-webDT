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
    public class QuanLyThongTinTuyenDungController : Controller
    {
        banhangEntities1 db = new banhangEntities1();
        //
        // GET: /QuanLyThongTinTuyenDung/
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(db.TuyenDung.ToList().OrderBy(n => n.ma).ToPagedList(pageNumber, pageSize));
        }

        //Thêm 
        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(TuyenDung td)
        {
            if (ModelState.IsValid)
            {
                db.TuyenDung.Add(td);
                db.SaveChanges();
                return RedirectToAction("Index", "QuanLyThongTinTuyenDung");
            }
            return View();
        }
        //Chỉnh sửa 
        [HttpGet]
        public ActionResult ChinhSua(int? ma)
        {
            if (ma == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TuyenDung td = db.TuyenDung.Find(ma);
            if (td == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(td);
        }

        [HttpPost]
        public ActionResult ChinhSua(TuyenDung td)
        {
            if (ModelState.IsValid)
            {
                db.Entry(td).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        //Hiển thị
        public ActionResult HienThi(int ma)
        {
            TuyenDung td = db.TuyenDung.SingleOrDefault(n => n.ma == ma);
            if (td== null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(td);
        }
        //Xoá 
        public ActionResult Xoa(int ma)
        {
            TuyenDung td = db.TuyenDung.SingleOrDefault(n => n.ma == ma);
            if (td == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(td);
        }
        //Xác nhận xoá
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int ma)
        {
            TuyenDung td = db.TuyenDung.SingleOrDefault(n => n.ma == ma);
            if (td == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.TuyenDung.Remove(td);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
	}
}