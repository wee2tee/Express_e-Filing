using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Express_e_Filing.Model;
using Express_e_Filing.SubForm;
using CC;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace Express_e_Filing.Misc
{
    public enum FORM_MODE
    {
        READ,
        EDIT
    }

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

        public static string AddIndent(this string str, int indent_space)
        {
            string ret_str = string.Empty;
            for (int i = 0; i < indent_space; i++)
            {
                ret_str += " ";
            }

            return ret_str += str;
        }

        public static void SetControlState(this Component comp, FORM_MODE[] form_mode_to_enable, FORM_MODE form_mode, string accessibility_by_scacclv = null)
        {
            if (form_mode_to_enable.ToList().Where(fm => fm == form_mode).Count() > 0)
            {
                if (comp is ToolStripButton)
                {
                    ((ToolStripButton)comp).Enabled = true;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((ToolStripButton)comp).Enabled = false;

                    return;
                }
                if (comp is ToolStripSplitButton)
                {
                    ((ToolStripSplitButton)comp).Enabled = true;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((ToolStripSplitButton)comp).Enabled = false;

                    return;
                }
                if (comp is ToolStripDropDownButton)
                {
                    ((ToolStripDropDownButton)comp).Enabled = true;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((ToolStripDropDownButton)comp).Enabled = false;

                    return;
                }
                if (comp is ToolStripMenuItem)
                {
                    ((ToolStripMenuItem)comp).Enabled = true;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((ToolStripMenuItem)comp).Enabled = false;

                    return;
                }
                if (comp is TabControl)
                {
                    ((TabControl)comp).Enabled = true;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((TabControl)comp).Enabled = false;

                    return;
                }
                if (comp is Button)
                {
                    ((Button)comp).Enabled = true;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((Button)comp).Enabled = false;

                    return;
                }
                if (comp is DataGridView)
                {
                    ((DataGridView)comp).Enabled = true;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((DataGridView)comp).Enabled = false;

                    return;
                }
                if (comp is XTextEdit)
                {
                    ((XTextEdit)comp)._ReadOnly = false;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((XTextEdit)comp)._ReadOnly = true;

                    return;
                }
                if (comp is XDropdownList)
                {
                    ((XDropdownList)comp)._ReadOnly = false;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((XDropdownList)comp)._ReadOnly = true;

                    return;
                }
                if (comp is XDatePicker)
                {
                    ((XDatePicker)comp)._ReadOnly = false;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((XDatePicker)comp)._ReadOnly = true;

                    return;
                }
                if (comp is XBrowseBox)
                {
                    ((XBrowseBox)comp)._ReadOnly = false;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((XBrowseBox)comp)._ReadOnly = true;

                    return;
                }
            }
            else
            {
                if (comp is ToolStripButton)
                {
                    ((ToolStripButton)comp).Enabled = false; return;
                }
                if (comp is ToolStripSplitButton)
                {
                    ((ToolStripSplitButton)comp).Enabled = false; return;
                }
                if (comp is ToolStripDropDownButton)
                {
                    ((ToolStripDropDownButton)comp).Enabled = false; return;
                }
                if (comp is ToolStripMenuItem)
                {
                    ((ToolStripMenuItem)comp).Enabled = false; return;
                }
                if (comp is TabControl)
                {
                    ((TabControl)comp).Enabled = false; return;
                }
                if (comp is Button)
                {
                    ((Button)comp).Enabled = false; return;
                }
                if (comp is DataGridView)
                {
                    ((DataGridView)comp).Enabled = false; return;
                }
                if (comp is XTextEdit)
                {
                    ((XTextEdit)comp)._ReadOnly = true; return;
                }
                if (comp is XDropdownList)
                {
                    ((XDropdownList)comp)._ReadOnly = true; return;
                }
                if (comp is XDatePicker)
                {
                    ((XDatePicker)comp)._ReadOnly = true; return;
                }
                if (comp is XBrowseBox)
                {
                    ((XBrowseBox)comp)._ReadOnly = true; return;
                }
            }
        }

        public static void SetControlVisibility(this Component comp, FORM_MODE[] form_mode_to_visible, FORM_MODE form_mode)
        {
            if (form_mode_to_visible.Where(fm => fm == form_mode).Count() > 0)
            {
                if (comp is Control)
                {
                    ((Control)comp).Visible = true; return;
                }
            }
            else
            {
                if (comp is Control)
                {
                    ((Control)comp).Visible = false; return;
                }
            }
        }

        public static void SetInlineControlPosition(this Control inline_control, DataGridView dgv, int row_index, int column_index)
        {
            if (inline_control != null)
            {
                Rectangle rect = dgv.GetCellDisplayRectangle(column_index, row_index, true);
                inline_control.SetBounds(rect.X, rect.Y + 1, rect.Width - 1, rect.Height - 3);
            }
        }
    }
}
