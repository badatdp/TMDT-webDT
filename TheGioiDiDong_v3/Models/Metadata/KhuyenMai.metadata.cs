using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using 2 thu vien thiết kế class metadata
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace TheGioiDiDong_v3.Models
{
    [MetadataType(typeof(KhuyenMaiMetadata))]
    public partial class KhuyenMai
    {
        internal sealed class KhuyenMaiMetadata
        {
            public int maKM { get; set; }
            [Display(Name = "Tên khuyến mãi")]
            [Required(ErrorMessage = "Tên khuyến mãi không được để trống")]
            public string tenKM { get; set; }
            [Display(Name = "Hình")]
            public string hinhKM { get; set; }
            [Display(Name = "Thời hạn")]
            [Required(ErrorMessage = "Thời hạn không được để trống")]
            public string thoihan { get; set; }
            [Display(Name = "Chi tiết")]
            public string chitiet { get; set; }
        }
    }
}