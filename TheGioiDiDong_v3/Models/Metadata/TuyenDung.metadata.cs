using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheGioiDiDong_v3.Models
{
    [MetadataType(typeof(TuyenDungMetadata))]
    public partial class TuyenDung
    {
        internal sealed class TuyenDungMetadata {
            public int ma { get; set; }
            [Display(Name = "Vị trí")]
            [Required(ErrorMessage = "Vị trí tuyển dụng không được để trống")]
            public string vitri { get; set; }
            [Display(Name = "Mức lương")]
            [Required(ErrorMessage = "Mức lương không được để trống")]
            public string mucluong { get; set; }
            [Display(Name = "Số lượng")]
            [Required(ErrorMessage = "Số lượng không được để trống")]
            public Nullable<int> soluong { get; set; }
            [Display(Name = "Nơi làm việc")]
            [Required(ErrorMessage = "Nơi làm việc không được để trống")]
            public string noilamviec { get; set; }
        }
    }
}