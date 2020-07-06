using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using 2 thư viện thiết kế class metadata
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace TheGioiDiDong_v3.Models
{
    [MetadataType(typeof(DonHangMetadata))]
    public partial class DonHang
    {
        internal sealed class DonHangMetadata
        {
            [Display(Name = "Mã đơn hàng")]
            public int madonhang { get; set; }
            [Display(Name = "Ngày giao")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            public Nullable<System.DateTime> ngaygiao { get; set; }
            [Display(Name = "Ngày đặt")]
            [DataType(DataType.Date)]

            [Required(ErrorMessage = "Ngày đặt không được để trống")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            public Nullable<System.DateTime> ngaydat { get; set; }
             [Display(Name = "Tình trạng thanh toán")]
            public string dathanhtoan { get; set; }
             [Display(Name = "Tình trạng giao hàng")]
            public string tinhtranggiaohang { get; set; }
             [Display(Name = "Mã khách hàng")]
            public int maKH { get; set; }
        }
    }
}