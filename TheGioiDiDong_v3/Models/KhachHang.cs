//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TheGioiDiDong_v3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            this.DonHang = new HashSet<DonHang>();
        }
    
        public int maKH { get; set; }
        public string ten { get; set; }
        public Nullable<System.DateTime> ngaysinh { get; set; }
        public string email { get; set; }
        public string tenDN { get; set; }
        public string matkhau { get; set; }
        public string xacnhanMK { get; set; }
        public string dienthoai { get; set; }
        public Nullable<bool> gioitinh { get; set; }
        public string diachi { get; set; }
        public Nullable<int> role { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHang { get; set; }
    }
}