using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Express_e_Filing.Model
{
    public class bs_tmpl
    {

    }

    public class bs_item
    {
        public int id { get; set; }
        public bool is_label { get; set; }
        public bool is_readonly { get; set; }
        public int level { get; set; }
        public string name_th { get; set; }
        public string name_en { get; set; }
        public decimal? amount_1 { get; set; }
        public decimal? amount_2 { get; set; }
        public int? parent_id { get; set; }
        public int? summaryline_id { get; set; }
    }
}
