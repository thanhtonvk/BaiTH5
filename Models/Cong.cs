//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BaiTH5.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cong
    {
        public int MaCT { get; set; }
        public int MaNV { get; set; }
        public Nullable<int> SLNgayCong { get; set; }
    
        public virtual NhanVien NhanVien { get; set; }
        public virtual CongTrinh CongTrinh { get; set; }
    }
}
