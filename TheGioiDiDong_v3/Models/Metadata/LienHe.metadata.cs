using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheGioiDiDong_v3.Models
{
    [MetadataType(typeof(LienHeMetaData))]
    public partial class LienHe
    {
        internal sealed class LienHeMetaData{
            public int makhuvuc { get; set; }
            [Display(Name = "Tên khu vực")]
            [Required(ErrorMessage = "Tên khu vực không được để trống")]
            public string tenkhuvuc { get; set; }
            [Display(Name = "Địa chỉ")]
            [Required(ErrorMessage = "Địa chỉ không được để trống")]
            public string diachi { get; set; }
            [Display(Name = "Điện thoại")]
            [Required(ErrorMessage = "Điện thoại không được để trống")]
            public string dienthoai { get; set; }
        }
    }
}