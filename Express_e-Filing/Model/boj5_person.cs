//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Express_e_Filing.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class boj5_person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public boj5_person()
        {
            this.boj5_detail = new HashSet<boj5_detail>();
        }
    
        public long id { get; set; }
        public string addrForeign { get; set; }
        public string addrFull { get; set; }
        public string addrNo { get; set; }
        public string amphur { get; set; }
        public string holderName { get; set; }
        public Nullable<long> itemSeq { get; set; }
        public string moo { get; set; }
        public string nationality { get; set; }
        public string occupation { get; set; }
        public string province { get; set; }
        public string road { get; set; }
        public string shId { get; set; }
        public string shType { get; set; }
        public string soi { get; set; }
        public string surname { get; set; }
        public string title { get; set; }
        public string tumbol { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<boj5_detail> boj5_detail { get; set; }
    }
}
