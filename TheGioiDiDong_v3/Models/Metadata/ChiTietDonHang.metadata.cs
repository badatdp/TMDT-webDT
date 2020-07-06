using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using 2 thư viện thiết kế class metadata
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace TheGioiDiDong_v3.Models
{
     [MetadataType(typeof(ChiTietDonHangMetadata))]
    public partial class ChiTietDonHang
    {
         internal sealed class ChiTietDonHangMetadata
         {
             [Display(Name = "Mã đơn hàng")]
             public int madonhang { get; set; }
               [Display(Name = "Mã sản phẩm")]
             public string maSP { get; set; }
             [Display(Name = "Số lượng")]
             public Nullable<int> soluong { get; set; }
             [Display(Name = "Đơn giá")]
             public Nullable<int> dongia { get; set; }
         }
    }
}