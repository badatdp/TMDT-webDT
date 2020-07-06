using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheGioiDiDong_v3.Models;
namespace TheGioiDiDong_v3.Controllers
{
    public class KhachHangController : Controller
    {
        banhangEntities1 db = new banhangEntities1();
        //get
        [HttpGet]// load lại trang hoặc truyền tham số QueryString
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(KhachHang kh)//post các value của các control
        {
           if(db.KhachHang.Any(n=>n.tenDN==kh.tenDN))
           {
               ModelState.AddModelError("tenDN", "Tên đăng nhập đã tồn tại");
           }
            if (ModelState.IsValid)
            {
                 //insert dữ liệu vào bảng KhachHang
                db.KhachHang.Add(kh);
                //lưu vào CSDL
                db.SaveChanges();
                Response.Redirect("~/KhachHang/DangKyThanhCong?ten=" + kh.ten);
                
            }
            return View();
        }
        //Kiểm tra tính duy nhất của tenDN
        //sử dụng JsonResult để validation xảy ra ở Client side
        //[HttpPost]
        //public JsonResult IsUserExists(string sTenDN)
        //{
        //    //check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method.
        //    return Json(!db.KhachHang.Any(x => x.tenDN == sTenDN), JsonRequestBehavior.AllowGet);
        //}
        public ActionResult DangKyThanhCong()
        {
            string s = Request.QueryString[0];
            string chuoi = "";
            chuoi += "<h1>Chúc mừng bạn<b style=\"color:red\">" + s + "</b> đã đăng ký tài khoản thành công!!</h1>";
            ViewBag.dangky = chuoi;
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string sTenDN = f["txtTenDN"].ToString();
            string sMatKhau = f.Get("txtMatKhau").ToString();
            KhachHang kh = db.KhachHang.SingleOrDefault(n => n.tenDN == sTenDN && n.matkhau == sMatKhau);
            if (kh == null)
            {
                return RedirectToAction("DangNhap", "KhachHang");
            }
            else
            {
                if (kh.role == 1)
                {
                    Session["TaiKhoan"] = kh.ten;      
                    return RedirectToAction("Index", "QuanLySanPham");
                }
                else
                {
                    Session["KhachHang"] = kh;
                    Session["TaiKhoan"] = kh.ten;      
                    return RedirectToAction("Index", "Home");;
                }
                
            }
                           
        }
        //Đăng xuất hệ thống
        public ActionResult DangXuat()
        {
            if (Session["TaiKhoan"] != null)
            {
                Session["TaiKhoan"] = null;

            }
            return RedirectToAction("Index", "Home");
        }
	}
}