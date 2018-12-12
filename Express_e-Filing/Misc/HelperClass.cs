using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Express_e_Filing.Model;
using Express_e_Filing.SubForm;
using CC;
using System.IO;

namespace Express_e_Filing.Misc
{
    public static class HelperClass
    {
        public static string GetAbsolutePath(this SccompDbf sccomp)
        {
            
                string path_txt = string.Empty;

                string p = sccomp.path;
                if (sccomp.path.Contains("("))
                    p = sccomp.path.Substring(0, sccomp.path.IndexOf("("));

                if (p.Contains(@":\") || p.StartsWith(@"\\"))
                {
                    path_txt = p.Trim();
                }
                else
                {
                    DirectoryInfo dir_info = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                    string absolute_path = dir_info.Parent.FullName + @"\" + p.Trim();
                    path_txt = absolute_path;
                }

                return path_txt.TrimEnd('\\') + @"\";
        }

        public static SccompDbfVM ToViewModel(this SccompDbf sccomp)
        {
            if (sccomp == null)
                return null;

            SccompDbfVM s = new SccompDbfVM
            {
                sccomp = sccomp
            };

            return s;
        }

        public static List<SccompDbfVM> ToViewModel(this IEnumerable<SccompDbf> sccomp)
        {
            List<SccompDbfVM> s = new List<SccompDbfVM>();

            foreach (var item in sccomp)
            {
                s.Add(item.ToViewModel());
            }

            return s;
        }

        public static GlaccTaxonomyVM ToViewModel(this GlaccDbf glacc)
        {
            if (glacc == null)
                return null;

            GlaccTaxonomyVM g = new GlaccTaxonomyVM
            {
                glacc = glacc,
                accnam = glacc.accnam,
                accnam2 = glacc.accnam2,
                accnum = glacc.accnum,
                taxonomy1 = string.Empty,
                taxonomy2 = string.Empty
            };

            return g;
        }

        public static List<GlaccTaxonomyVM> ToViewModel(this IEnumerable<GlaccDbf> glacc)
        {
            List<GlaccTaxonomyVM> g = new List<GlaccTaxonomyVM>();

            foreach (var item in glacc)
            {
                g.Add(item.ToViewModel());
            }

            return g;
        }
    }
}
