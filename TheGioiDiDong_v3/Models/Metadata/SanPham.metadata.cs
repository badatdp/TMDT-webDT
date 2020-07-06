using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using 2 thu vien thiết kế class metadata
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace TheGioiDiDong_v3.Models
{
    //Định kiểu cho thuộc tính SanPhamMetadata
    [MetadataType(typeof(SanPhamMetadata))]
    public partial class SanPham
    {
        internal sealed class SanPhamMetadata{
        [Display(Name="Mã sản phẩm")]
        [Required(ErrorMessage = "Mã sản phẩm không được để trống")]
        public string maSP { get; set; }
        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(255, ErrorMessage = "Tên sản phẩm không quá 255 ký tự")]
        public string tenSP { get; set; }
        [Display(Name = "Chi tiết")]
        [Required(ErrorMessage = "Chi tiết sản phẩm không được để trống")]
        //[StringLength(2000, ErrorMessage = "Chi tiết sản phẩm không quá 2000 ký tự")]
        public string chitiet { get; set; }
        [Display(Name = "Hình")]
        public string hinh { get; set; }
        [Display(Name = "Giá")]
        [Required(ErrorMessage = "Giá sản phẩm không được để trống")]
        public Nullable<int> gia { get; set; }
        [Display(Name = "Số lượng còn tồn")]
        public Nullable<int> sl_duocmua { get; set; }
        [Display(Name = "Loại sản phẩm")]
        [Required(ErrorMessage = "Loại sản phẩm không được để trống")]
        [StringLength(255, ErrorMessage = "Loai sản phẩm không quá 255 ký tự")]
        public string loaiSP { get; set; }
        [Display(Name = "Hãng sản xuất")]
        public string hangSX { get; set; }
         [Display(Name = "Tình trạng sản phẩm")]
        public string tinhtrangSP { get; set; }
    
        }
    }
}