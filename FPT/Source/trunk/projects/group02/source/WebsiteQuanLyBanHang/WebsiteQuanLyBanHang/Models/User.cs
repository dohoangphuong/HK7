﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebsiteQuanLyBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.ReturnGoods = new HashSet<ReturnGood>();
            this.SalesOrders = new HashSet<SalesOrder>();
            this.SalesOrders1 = new HashSet<SalesOrder>();
            this.Stocks = new HashSet<Stock>();
        }

        [Required(ErrorMessage = "Phải nhập trường này")]
        [Display(Name = "Tên tài khoản")]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [MinLength(8, ErrorMessage = "Mật khẩu phải dài hơn 8 kí tự")]
        [MaxLength(20, ErrorMessage = "Mật khẩu phải nhỏ hơn 20 kí tự")]
        public string Password { get; set; }

        public string Salt { get; set; }

        [Display(Name = "Chức vụ")]
        [Required(ErrorMessage = "Phải nhập trường này")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Phải chọn dữ liệu cho trường này")]
        public string IDPerson { get; set; }

        [Display(Name = "Mail")]
        public string Email { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReturnGood> ReturnGoods { get; set; }
        public virtual SalesMan SalesMan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesOrder> SalesOrders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesOrder> SalesOrders1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}