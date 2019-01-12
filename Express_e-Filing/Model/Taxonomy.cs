﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Express_e_Filing.Model
{
    public class Taxonomy
    {
        public string code { get; set; }
        public string group { get; set; }
        public string name { get; set; }
        public string taxodesc { get; set; }

        public static List<Taxonomy> GetTaxonomyList(OldForm main_form)
        {
            List<Taxonomy> taxo = new List<Taxonomy>();
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Template/dbd_taxonomy.xml"))
            {
                XDocument xdoc = XDocument.Load(AppDomain.CurrentDomain.BaseDirectory + "/Template/dbd_taxonomy.xml");
                Console.WriteLine(" >>>> xdoc count : " + xdoc.Root.Descendants("Taxonomy").Count());

                foreach (XElement elem in xdoc.Root.Descendants("Taxonomy"))
                {
                    taxo.Add(new Taxonomy()
                    {
                        code = elem.Element("Code").Value,
                        group = elem.Element("Group").Value,
                        name = elem.Element("Name").Value,
                        taxodesc = elem.Element("Taxodesc").Value
                    });
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("ไม่พบไฟล์ dbd_taxonomy.xml", "พบข้อผิดพลาด : ", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return taxo;
        }

        public override string ToString()
        {
            return "[" + this.taxodesc + "]" + " " + this.name;
        }


        public static XDocument GetTaxo()
        {
            XDocument xdoc = XDocument.Load(AppDomain.CurrentDomain.BaseDirectory + "/Template/cal_cmp_2017-12-31.xml");
            return xdoc;
        }
    }
}
