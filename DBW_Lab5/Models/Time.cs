//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBW_Lab5.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Time
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Time()
        {
            this.Facts = new HashSet<Fact>();
        }
    
        public int time_id { get; set; }
        public Nullable<int> year { get; set; }
        public Nullable<int> quarter { get; set; }
        public Nullable<int> month { get; set; }
        public Nullable<int> week { get; set; }
        public Nullable<int> day_of_the_week { get; set; }
        public Nullable<System.DateTime> date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fact> Facts { get; set; }
    }
}