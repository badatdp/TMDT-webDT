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
    public class QuanLyThongTinLienHeController : Controller
    {
        banhangEntities1 db = new banhangEntities1();
        //
        // GET: /QuanLyThongTinLienHe/
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(db.LienHe.ToList().OrderBy(n => n.makhuvuc).ToPagedList(pageNumber, pageSize));
        }

        //Thêm 
        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(LienHe lh)
        {
            if (ModelState.IsValid)
            {
                db.LienHe.Add(lh);
                db.SaveChanges();
                return RedirectToAction("Index", "QuanLyThongTinLienHe");
            }
            return View();
        }
        //Chỉnh sửa 
        [HttpGet]
        public ActionResult ChinhSua(int? makhuvuc)
        {
            if (makhuvuc == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LienHe lh = db.LienHe.Find(makhuvuc);
            if (lh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(lh);
        }

        [HttpPost]
        public ActionResult ChinhSua(LienHe lh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lh).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        //Hiển thị
        public ActionResult HienThi(int? makhuvuc)
        {
            LienHe lh = db.LienHe.SingleOrDefault(n => n.makhuvuc == makhuvuc);
            if (lh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(lh);
        }
        //Xoá 
        public ActionResult Xoa(int? makhuvuc)
        {
            LienHe lh = db.LienHe.SingleOrDefault(n => n.makhuvuc == makhuvuc);
            if (lh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(lh);
        }
        //Xác nhận xoá
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int? makhuvuc)
        {
            LienHe lh = db.LienHe.SingleOrDefault(n => n.makhuvuc == makhuvuc);
            if (lh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.LienHe.Remove(lh);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
	}
}