//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AbaHussainWebSite.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BranchDetail
    {
        public int DetailsBranch { get; set; }
        public string imgSrc { get; set; }
        public int FKBranchID { get; set; }
    
        public virtual Branches Branches { get; set; }
    }
}