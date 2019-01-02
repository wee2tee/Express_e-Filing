using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Express_e_Filing.Misc;

namespace Express_e_Filing.Model
{
    public class boj5_detail_VM
    {
        public boj5_detail boj5_detail { get; set; }
        public long? itemNo { get { return this.boj5_detail.itemNo; } }
        public string holderName { get { return this.boj5_detail.boj5_person.title + " " + this.boj5_detail.boj5_person.holderName + " " + this.boj5_detail.boj5_person.surname; } }
        public long? shareNumber { get { return this.boj5_detail.shareNumber; } }
        public double? paidAmount { get { return this.boj5_detail.paidAmount; } }
        public double? asPaidAmount { get { return this.boj5_detail.asPaidAmount; } }
        public string shareDocId { get { return this.boj5_detail.shareDocId; } }
        public DateTime? shareDocDate { get { return this.boj5_detail.shareDocDate; } }
        public DateTime? shareRegExist { get { return this.boj5_detail.shareRegExist; } }
        public DateTime? shareRegOmit { get { return this.boj5_detail.shareRegOmit; } }
    }

    public class boj5_person_VM
    {
        public boj5_person boj5_person { get; set; }
        public bool selected { get; set; }
        public long? itemSeq { get { return this.boj5_person.itemSeq; } }
        public string holderName { get { return (this.boj5_person.title + " " + this.boj5_person.holderName + " " + this.boj5_person.surname).Trim(); } }
        public string nationality { get { return this.boj5_person.nationality; } }
        public string addrFull { get { return this.boj5_person.addrFull; } }
    }

    public class nationality_VM
    {
        public string nationality_code { get; set; }
        public string nationality_name_th { get; set; }
        public string nationality_name_en { get; set; }

    }
}
