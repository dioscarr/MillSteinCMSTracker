//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Investment
    {
        public int Id { get; set; }
        public string HeaderContent { get; set; }
        public string ContentTitle1 { get; set; }
        public string Content1 { get; set; }
        public string ContentTitle2 { get; set; }
        public string Content2 { get; set; }
        public string Picture { get; set; }
        public string PictureContent { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime Modified { get; set; }
        public bool isDeleted { get; set; }
    }
}
