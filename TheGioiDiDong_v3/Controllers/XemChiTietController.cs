using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheGioiDiDong_v3.Models;
namespace TheGioiDiDong_v3.Controllers
{
    public class XemChiTietController : Controller
    {
        //
        // GET: /XemChiTiet/
        banhangEntities1 db = new banhangEntities1();
        public ActionResult XemChiTiet(string masp)
        {
            SanPham sanpham = db.SanPham.SingleOrDefault(n => n.maSP == masp);
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sanpham);

        }
	}
}