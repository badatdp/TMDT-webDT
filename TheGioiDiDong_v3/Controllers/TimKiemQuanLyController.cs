using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheGioiDiDong_v3.Models;
using PagedList.Mvc;
using PagedList;
namespace TheGioiDiDong_v3.Controllers
{
    public class TimKiemQuanLyController : Controller
    {
        banhangEntities1 db = new banhangEntities1();
        //
        // GET: /TimKiemQuanLy/
        //Tìm kiếm sản phẩm
        [HttpPost]
        public ActionResult TimKiemSanPham(FormCollection f, int? page)
        {
            string sTuKhoa = f["txtTimKiem"].ToString();
            List<SanPham> lstSanPham = db.SanPham.Where(n => n.tenSP.Contains(sTuKhoa)).ToList();
            ViewBag.TuKhoa = sTuKhoa;
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            if (lstSanPham.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
                return View(db.SanPham.OrderBy(n => n.tenSP).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy <b style=\"color:red;\">" + lstSanPham.Count + "</b> kết quả";
            return View(lstSanPham.OrderBy(n => n.tenSP).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult TimKiemSanPham(int? page, string sTuKhoa)
        {
            ViewBag.TuKhoa = sTuKhoa;
            List<SanPham> lstSanPham = db.SanPham.Where(n => n.tenSP.Contains(sTuKhoa)).ToList();
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            if (lstSanPham.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
                return View(db.SanPham.OrderBy(n => n.tenSP).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy <b style=\"color:red;\">" + lstSanPham.Count + "</b> kết quả";
            return View(lstSanPham.OrderBy(n => n.tenSP).ToPagedList(pageNumber, pageSize));
        }
        //Tìm kiếm tài khoản khách hàng
        [HttpPost]
        public ActionResult TimKiemKhachHang(FormCollection f, int? page)
        {
            string sTuKhoa = f["txtTimKiem"].ToString();
            List<KhachHang> lstKhachHang = db.KhachHang.Where(n => n.ten.Contains(sTuKhoa)).ToList();
            ViewBag.TuKhoa = sTuKhoa;
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            if (lstKhachHang.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy khách hàng nào";
                return View(db.KhachHang.OrderBy(n => n.ten).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy <b style=\"color:red;\">" + lstKhachHang.Count + "</b> kết quả";
            return View(lstKhachHang.OrderBy(n => n.ten).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult TimKiemKhachHang(int? page, string sTuKhoa)
        {
            ViewBag.TuKhoa = sTuKhoa;
            List<KhachHang> lstKhachHang = db.KhachHang.Where(n => n.ten.Contains(sTuKhoa)).ToList();
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            if (lstKhachHang.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy khách hàng nào";
                return View(db.KhachHang.OrderBy(n => n.ten).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy <b style=\"color:red;\">" + lstKhachHang.Count + "</b> kết quả";
            return View(lstKhachHang.OrderBy(n => n.ten).ToPagedList(pageNumber, pageSize));
        }
        //Tìm kiếm đơn hàng
        [HttpPost]
        public ActionResult TimKiemDonHang(FormCollection f, int? page)
        {
           int iTuKhoa = Convert.ToInt32(f["txtTimKiem"].ToString());
            List<DonHang> lstDonHang = db.DonHang.Where(n => n.madonhang==iTuKhoa).ToList();
            ViewBag.TuKhoa = iTuKhoa;
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            if (lstDonHang.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy đơn hàng nào";
                return View(db.DonHang.OrderBy(n => n.madonhang).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy <b style=\"color:red;\">" + lstDonHang.Count + "</b> kết quả";
            return View(lstDonHang.OrderBy(n => n.madonhang).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult TimKiemDonHang(int? page, int? iTuKhoa)
        {
            ViewBag.TuKhoa = iTuKhoa;
            List<DonHang> lstDonHang = db.DonHang.Where(n => n.madonhang==iTuKhoa).ToList();
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            if (lstDonHang.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy đơn hàng nào";
                return View(db.DonHang.OrderBy(n => n.madonhang).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy <b style=\"color:red;\">" + lstDonHang.Count + "</b> kết quả";
            return View(lstDonHang.OrderBy(n => n.madonhang).ToPagedList(pageNumber, pageSize));
        }
        //Tìm kiếm chi tiết đơn hàng
        [HttpPost]
        public ActionResult TimKiemChiTietDonHang(FormCollection f, int? page)
        {
            string sTuKhoa = f["txtTimKiem"].ToString();
            List<ChiTietDonHang> lstCTDonHang = db.ChiTietDonHang.Where(n => n.maSP.Contains(sTuKhoa)).ToList();
            ViewBag.TuKhoa = sTuKhoa;
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            if (lstCTDonHang.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy chi tiết đơn hàng nào";
                return View(db.ChiTietDonHang.OrderBy(n => n.maSP).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy <b style=\"color:red;\">" + lstCTDonHang.Count + "</b> kết quả";
            return View(lstCTDonHang.OrderBy(n => n.maSP).ToPagedList(pageNumber, pageSize));
        }

        private new ActionResult View(object p)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public ActionResult TimKiemChiTietDonHang(int? page, string sTuKhoa)
        {
            ViewBag.TuKhoa = sTuKhoa;
            List<ChiTietDonHang> lstCTDonHang = db.ChiTietDonHang.Where(n => n.maSP.Contains(sTuKhoa)).ToList();
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            if (lstCTDonHang.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy chi tiết đơn hàng nào";
                return View(db.ChiTietDonHang.OrderBy(n => n.maSP).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy <b style=\"color:red;\">" + lstCTDonHang.Count + "</b> kết quả";
            return View(lstCTDonHang.OrderBy(n => n.maSP).ToPagedList(pageNumber, pageSize));
        }
        //Tìm kiếm khuyến mãi
        [HttpPost]
        public ActionResult TimKiemThongTinKhuyenMai(FormCollection f, int? page)
        {
            string sTuKhoa = f["txtTimKiem"].ToString();
            List<KhuyenMai> lstKhuyenMai = db.KhuyenMai.Where(n => n.tenKM.Contains(sTuKhoa)).ToList();
            ViewBag.TuKhoa = sTuKhoa;
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            if (lstKhuyenMai.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy khuyến mãi nào";
                return View(db.KhuyenMai.OrderBy(n => n.tenKM).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy <b style=\"color:red;\">" + lstKhuyenMai.Count + "</b> kết quả";
            return View(lstKhuyenMai.OrderBy(n => n.maKM).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult TimKiemThongTinKhuyenMai(int? page, string sTuKhoa)
        {
            ViewBag.TuKhoa = sTuKhoa;
            List<KhuyenMai> lstKhuyenMai = db.KhuyenMai.Where(n => n.tenKM.Contains(sTuKhoa)).ToList();
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            if (lstKhuyenMai.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy khuyến mãi nào";
                return View(db.KhuyenMai.OrderBy(n => n.tenKM).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy <b style=\"color:red;\">" + lstKhuyenMai.Count + "</b> kết quả";
            return View(lstKhuyenMai.OrderBy(n => n.maKM).ToPagedList(pageNumber, pageSize));
        }
        //Tìm kiếm tuyển dụng
        [HttpPost]
        public ActionResult TimKiemThongTinTuyenDung(FormCollection f, int? page)
        {
            string sTuKhoa = f["txtTimKiem"].ToString();
            List<TuyenDung> lstTuyenDung = db.TuyenDung.Where(n => n.vitri.Contains(sTuKhoa)).ToList();
            ViewBag.TuKhoa = sTuKhoa;
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            if (lstTuyenDung.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy vị trí tuyển dụng nào";
                return View(db.TuyenDung.OrderBy(n => n.vitri).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy <b style=\"color:red;\">" + lstTuyenDung.Count + "</b> kết quả";
            return View(lstTuyenDung.OrderBy(n => n.vitri).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult TimKiemThongTinTuyenDung(int? page, string sTuKhoa)
        {
            ViewBag.TuKhoa = sTuKhoa;
            List<TuyenDung> lstTuyenDung = db.TuyenDung.Where(n => n.vitri.Contains(sTuKhoa)).ToList();
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            if (lstTuyenDung.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy vị trí tuyển dụng nào";
                return View(db.TuyenDung.OrderBy(n => n.vitri).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy <b style=\"color:red;\">" + lstTuyenDung.Count + "</b> kết quả";
            return View(lstTuyenDung.OrderBy(n => n.vitri).ToPagedList(pageNumber, pageSize));
        }
        //Tìm kiếm liên hệ
        [HttpPost]
        public ActionResult TimKiemThongTinLienHe(FormCollection f, int? page)
        {
            string sTuKhoa = f["txtTimKiem"].ToString();
            List<LienHe> lstLienHe = db.LienHe.Where(n => n.tenkhuvuc.Contains(sTuKhoa)).ToList();
            ViewBag.TuKhoa = sTuKhoa;
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            if (lstLienHe.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy khu vực này";
                return View(db.LienHe.OrderBy(n => n.tenkhuvuc).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy <b style=\"color:red;\">" + lstLienHe.Count + "</b> kết quả";
            return View(lstLienHe.OrderBy(n => n.tenkhuvuc).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult TimKiemThongTinLienHe(int? page, string sTuKhoa)
        {
            ViewBag.TuKhoa = sTuKhoa;
            List<LienHe> lstLienHe = db.LienHe.Where(n => n.tenkhuvuc.Contains(sTuKhoa)).ToList();
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            if (lstLienHe.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy khu vực này";
                return View(db.LienHe.OrderBy(n => n.tenkhuvuc).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy <b style=\"color:red;\">" + lstLienHe.Count + "</b> kết quả";
            return View(lstLienHe.OrderBy(n => n.tenkhuvuc).ToPagedList(pageNumber, pageSize));
        }
	}
}