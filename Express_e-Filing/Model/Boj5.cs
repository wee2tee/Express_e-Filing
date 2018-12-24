using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Express_e_Filing.Model
{
    public class boj5_header
    {
        public int id { get; set; }
        public string userId { get; set; }
        public string accSource { get; set; }
        public string meetingType { get; set; }
        public string meetingNo { get; set; }
        public DateTime sourceDate { get; set; }
        public decimal totalCapital { get; set; }
        public int totalShare { get; set; }
        public decimal parValue { get; set; }
        public int thaiShareholder { get; set; }
        public int totalThaiShare { get; set; }
        public int foreignShareholder { get; set; }
        public int totalForeignShare { get; set; }
        public string headerStatus { get { return "A"; } }
        public DateTime yearEnd { get; set; }
    }

    public class boj5_person
    {
        public boj5_person()
        {
            //this.boj5_detail = new HashSet<boj5_detail>();
        }

        public int id { get; set; }
        public string addrForeign { get; set; }
        public string addrFull { get; set; }
        public string addrNo { get; set; }
        public string amphur { get; set; }
        public string holderName { get; set; }
        public int itemSeq { get; set; }
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

        //public virtual ICollection<boj5_detail> boj5_detail { get; set; }
    }

    public class boj5_detail
    {
        public int id { get; set; }
        public int itemNo { get; set; }
        public string userId { get; set; }
        public int shareNumber { get; set; }
        public string shareType { get; set; }
        public decimal paidAmount { get; set; }
        public decimal asPaidAmount { get; set; }
        public string shareDocId { get; set; }
        public DateTime shareDocDate { get; set; }
        public DateTime shareRegExist { get; set; }
        public DateTime shareRegOmit { get; set; }
        public int boj5_person_id { get; set; }

        //public virtual boj5_person boj5_person { get; set; }
    }
}
