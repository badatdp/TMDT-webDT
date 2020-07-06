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
    public class TimKiemController : Controller
    {
        banhangEntities1 db = new banhangEntities1();
        //
        // GET: /TimKiem/
        //Tìm kiếm sản phẩm
        [HttpPost]
        public ActionResult KetQuaTimKiem(FormCollection f,int? page)
        {
            string sTuKhoa = f["txtTimKiem"].ToString();
            List<SanPham> lstKQTK = db.SanPham.Where(n => n.tenSP.Contains(sTuKhoa)).ToList();
            ViewBag.TuKhoa = sTuKhoa;
           //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            if(lstKQTK.Count==0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
                return View(db.SanPham.OrderBy(n => n.tenSP).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy <b style=\"color:red;\">"+lstKQTK.Count+"</b> kết quả";
            return View(lstKQTK.OrderBy(n=>n.tenSP).ToPagedList(pageNumber,pageSize));
        }
        [HttpGet]
        public ActionResult KetQuaTimKiem( int? page,string sTuKhoa)
        {
            ViewBag.TuKhoa = sTuKhoa;
            List<SanPham> lstKQTK = db.SanPham.Where(n => n.tenSP.Contains(sTuKhoa)).ToList();
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
                return View(db.SanPham.OrderBy(n => n.tenSP).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy <b style=\"color:red;\">" + lstKQTK.Count + "</b> kết quả";
            return View(lstKQTK.OrderBy(n => n.tenSP).ToPagedList(pageNumber, pageSize));
        }
        //Tìm kiếm nâng cao
        [HttpPost]
        public ActionResult KetQuaTimKiemNangCao(FormCollection f, int? page)
        {
            //string sTenSP = f["txtTenSP"].ToString();
            string sLoaiSP = f["txtLoaiSP"].ToString();
            string sHangSX = f["txtHangSX"].ToString();
            int iGiaTu = Convert.ToInt32(f["txtGiaTu"].ToString());
            int iGiaDen = Convert.ToInt32(f["txtGiaDen"].ToString());
                List<SanPham> lstKQTK = db.SanPham.Where(n =>n.loaiSP == sLoaiSP && n.hangSX == sHangSX
                    && n.gia >= iGiaTu && n.gia <= iGiaDen).ToList();
            //ViewBag.TenSP = sTenSP;
            ViewBag.HangSX = sHangSX;
            ViewBag.LoaiSP = sLoaiSP;
            ViewBag.GiaTu = iGiaTu;
            ViewBag.GiaDen = iGiaDen;
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
                return View(db.SanPham.OrderBy(n => n.tenSP).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy <b style=\"color:red;\">" + lstKQTK.Count + "</b> kết quả";
            return View(lstKQTK.OrderBy(n => n.tenSP).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult KetQuaTimKiemNangCao(int? page, string sLoaiSP, string sHangSX, int? iGiaTu, int? iGiaDen)
        {
            //ViewBag.TenSP = sTenSP;
            ViewBag.HangSX = sHangSX;
            ViewBag.LoaiSP = sLoaiSP;
            ViewBag.GiaTu = iGiaTu;
            ViewBag.GiaDen = iGiaDen;
            //List<SanPham> lstKQTK = db.SanPham.Where(n => n.hangSX.Contains(sHangSX)).ToList();
            //List<SanPham> lstKQTK = db.SanPham.Where(n => n.gia>=iGiaTu&& n.gia<=iGiaDen).ToList();   
             List<SanPham> lstKQTK = db.SanPham.Where(n=> n.loaiSP==sLoaiSP && n.hangSX==sHangSX
                    && n.gia >= iGiaTu && n.gia <= iGiaDen).ToList();
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
                return View(db.SanPham.OrderBy(n => n.tenSP).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy <b style=\"color:red;\">" + lstKQTK.Count + "</b> kết quả";
            return View(lstKQTK.OrderBy(n => n.tenSP).ToPagedList(pageNumber, pageSize));
        }
        //Tìm kiếm khuyến mãi
        [HttpPost]
        public ActionResult KetQuaTimKiemKhuyenMai(FormCollection f, int? page)
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
        public ActionResult KetQuaTimKiemKhuyenMai(int? page, string sTuKhoa)
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
        public ActionResult KetQuaTimKiemTuyenDung(FormCollection f, int? page)
        {
            string sTuKhoa = f["txtTimKiem"].ToString();
            List<TuyenDung> lstTuyenDung = db.TuyenDung.Where(n => n.vitri.Contains(sTuKhoa)).ToList();
            ViewBag.TuKhoa = sTuKhoa;
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 22;
            if (lstTuyenDung.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy vị trí tuyển dụng nào";
                return View(db.TuyenDung.OrderBy(n => n.vitri).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy <b style=\"color:red;\">" + lstTuyenDung.Count + "</b> kết quả";
            return View(lstTuyenDung.OrderBy(n => n.vitri).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult KetQuaTimKiemTuyenDung(int? page, string sTuKhoa)
        {
            ViewBag.TuKhoa = sTuKhoa;
            List<TuyenDung> lstTuyenDung = db.TuyenDung.Where(n => n.vitri.Contains(sTuKhoa)).ToList();
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 22;
            if (lstTuyenDung.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy vị trí tuyển dụng nào";
                return View(db.TuyenDung.OrderBy(n => n.vitri).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy <b style=\"color:red;\">" + lstTuyenDung.Count + "</b> kết quả";
            return View(lstTuyenDung.OrderBy(n => n.vitri).ToPagedList(pageNumber, pageSize));
        }
	}
}