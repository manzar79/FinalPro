//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MeatMe.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CookCut
    {
        public int CutId { get; set; }
        public int CookId { get; set; }
        public Nullable<bool> Good_Bad { get; set; }
        public int CookCutId { get; set; }
    
        public virtual CookType CookType { get; set; }
        public virtual CutName CutName { get; set; }
    }
}
