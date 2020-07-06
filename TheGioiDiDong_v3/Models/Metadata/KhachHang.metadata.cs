using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using 2 thư viện thiết kế class metadata
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace TheGioiDiDong_v3.Models
{
    [MetadataType(typeof(KhachHangMetadata))]
    public partial class KhachHang
    {
        internal sealed class KhachHangMetadata {
            public int maKH { get; set; }
            [Display(Name = "Họ và tên")]
            [Required(ErrorMessage = "Họ và tên không được để trống")]
            [StringLength(100, ErrorMessage = "Tên không quá 100 ký tự")]
            public string ten { get; set; }
            [Display(Name = "Ngày sinh")]
            [Required(ErrorMessage = "Ngày sinh không được để trống")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            public Nullable<System.DateTime> ngaysinh { get; set; }
            [Display(Name = "Email")]
            [Required(ErrorMessage = "Email không được để trống")]
            [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Định dạng Email sai")]
            public string email { get; set; }
            [Display(Name = "Tên đăng nhập")]
            [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
            [StringLength(100, ErrorMessage = "Tên đăng nhập không quá 100 ký tự")]
            //[System.Web.Mvc.Remote("IsUserExists", "KhachHang", HttpMethod = "POST", ErrorMessage = "Tên đăng nhập đã có người sử dụng")]
            public string tenDN { get; set; }
            [Display(Name = "Mật khẩu")]
            [Required(ErrorMessage = "Mật khẩu không được để trống")]
            [StringLength(60, ErrorMessage = "Mật khẩu không quá 60 ký tự")]
            public string matkhau { get; set; }
            [Display(Name = "Nhập lại Mật khẩu")]
            [Required(ErrorMessage = "Mật khẩu nhập lại không được để trống")]
            [Compare("matkhau", ErrorMessage = "Mật khẩu nhập lại không khớp")]

            public string xacnhanMK { get; set; }
            [Display(Name = "Điện thoại")]
            [Required(ErrorMessage = "Điện thoại không được để trống")]
            public string dienthoai { get; set; }
            [Display(Name = "Giới tính")]
            [Required(ErrorMessage = "Giới tính không được để trống")]
            public Nullable<bool> gioitinh { get; set; }
            [Display(Name = "Địa chỉ")]
            [Required(ErrorMessage = "Địa chỉ không được để trống")]
            public string diachi { get; set; }
             [Display(Name = "Quyền")]
            public Nullable<int> role { get; set; }
    
        }
    }
}