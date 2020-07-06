using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheGioiDiDong_v3.Models;
using System.ComponentModel.DataAnnotations;
namespace TheGioiDiDong_v3.Models
{
    public class GioHang
    {
        banhangEntities1 db = new banhangEntities1();
        public string sMaSP { get; set; }
        public string sTenSP { get; set; }
        public string sHinh { get; set; }
        public double dGia { get; set; }
        public string sLoaiSP { get; set; }
        public string sHangSX { get; set; }
        public int iSoLuong { get; set; }
        public double ThanhTien
        {
            get
            {
                return iSoLuong * dGia;
            }
        }
        public GioHang(string masp)
        {
            sMaSP = masp;
            SanPham sp = db.SanPham.Single(n => n.maSP == sMaSP);
            sTenSP = sp.tenSP;
            sHinh = sp.hinh;
            dGia = double.Parse(sp.gia.ToString());
            sLoaiSP = sp.loaiSP;
            sHangSX = sp.hangSX;
            iSoLuong = 1;
        }
    }
}