﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Express_e_Filing.SubForm;
using Express_e_Filing.Model;
using Express_e_Filing.Misc;
using System.Data.OleDb;
using CC;
using System.Data.SQLite;
using System.Data.SQLite.EF6;
using System.IO;
using System.Globalization;
using System.Xml.Linq;

namespace Express_e_Filing
{
    public partial class OldForm : Form
    {
        public SccompDbf selected_comp = null;

        private List<GlaccDbf> glacc_list;
        private BindingList<GlaccTaxonomyVM> glacc1;
        private BindingList<GlaccTaxonomyVM> glacc2;
        private BindingList<GlaccTaxonomyVM> glacc3;
        private BindingList<GlaccTaxonomyVM> glacc4;
        private BindingList<GlaccTaxonomyVM> glacc5;

        public List<tagXml> tag_xml;
        public DirectoryInfo eFilingTmpDir = null;

        private enum LANG_ACCNUM
        {
            TH,
            EN
        }
        private LANG_ACCNUM lang_accnum = LANG_ACCNUM.TH;
        private FORM_MODE form_mode = FORM_MODE.READ;

        public OldForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.HideInlineForm();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (this.selected_comp == null)
            {
                this.btnOpenFolder.PerformClick();
            }

            //if (this.selected_comp != null)
            //{
            //    SQLiteDbPrepare.EnsureDbCreated(this.selected_comp);
            //    options opt = HelperClass.GetOptions(OPTIONS.EFILING_TMP_DIR, this.selected_comp);
            //    if (opt.value_str != null && opt.value_str.Trim().Length > 0 && File.Exists(opt.value_str.Trim()))
            //    {
            //        this.cZipFilePath.Text = opt.value_str.Trim();
            //    }
            //    else
            //    {
            //        this.cZipFilePath.Text = string.Empty;
            //    }
            //}
        }

        private void FillForm()
        {
            this.cCompName.Text = this.selected_comp.compnam;
            this.cDataPath.Text = this.selected_comp.path;
            this.lblProgramPath.Text = AppDomain.CurrentDomain.BaseDirectory;

            this.glacc1 = new BindingList<GlaccTaxonomyVM>(this.glacc_list.Where(g => g.group == "1").ToViewModel());
            this.glacc2 = new BindingList<GlaccTaxonomyVM>(this.glacc_list.Where(g => g.group == "2").ToViewModel());
            this.glacc3 = new BindingList<GlaccTaxonomyVM>(this.glacc_list.Where(g => g.group == "3").ToViewModel());
            this.glacc4 = new BindingList<GlaccTaxonomyVM>(this.glacc_list.Where(g => g.group == "4").ToViewModel());
            this.glacc5 = new BindingList<GlaccTaxonomyVM>(this.glacc_list.Where(g => g.group == "5").ToViewModel());

            this.dgv1.DataSource = this.glacc1;
            this.dgv2.DataSource = this.glacc2;
            this.dgv3.DataSource = this.glacc3;
            this.dgv4.DataSource = this.glacc4;
            this.dgv5.DataSource = this.glacc5;
        }

        private void ResetFormState(FORM_MODE form_mode)
        {
            this.form_mode = form_mode;

            this.btnOpenFolder.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnEdit.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnSave.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.btnStop.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.btnRegist.SetControlState(new FORM_MODE[] { FORM_MODE.READ, FORM_MODE.EDIT }, this.form_mode);
        }

        private void HideInlineForm()
        {
            this.inlineTaxonomy1.SetBounds(-9999, -9999, 0, 0);
            this.inlineTaxonomy2.SetBounds(-9999, -9999, 0, 0);
        }

        private void ShowInlineForm()
        {
            if (this.tabControl1.SelectedTab == this.tabAsset)
            {
                this.tabAsset.Controls.Add(this.inlineTaxonomy1);
                this.tabAsset.Controls.Add(this.inlineTaxonomy2);
                this.SetInlineFromPosition(this.dgv1.Rows[this.dgv1.CurrentCell.RowIndex]);
            }

            if (this.tabControl1.SelectedTab == this.tabLiability)
            {
                this.tabLiability.Controls.Add(this.inlineTaxonomy1);
                this.tabLiability.Controls.Add(this.inlineTaxonomy2);
                this.SetInlineFromPosition(this.dgv2.Rows[this.dgv2.CurrentCell.RowIndex]);
            }

            if (this.tabControl1.SelectedTab == this.tabEquity)
            {
                this.tabEquity.Controls.Add(this.inlineTaxonomy1);
                this.tabEquity.Controls.Add(this.inlineTaxonomy2);
                this.SetInlineFromPosition(this.dgv3.Rows[this.dgv3.CurrentCell.RowIndex]);
            }

            if (this.tabControl1.SelectedTab == this.tabRevenue)
            {
                this.tabRevenue.Controls.Add(this.inlineTaxonomy1);
                this.tabRevenue.Controls.Add(this.inlineTaxonomy2);
                this.SetInlineFromPosition(this.dgv4.Rows[this.dgv4.CurrentCell.RowIndex]);
            }

            if (this.tabControl1.SelectedTab == this.tabExpense)
            {
                this.tabExpense.Controls.Add(this.inlineTaxonomy1);
                this.tabExpense.Controls.Add(this.inlineTaxonomy2);
                this.SetInlineFromPosition(this.dgv5.Rows[this.dgv5.CurrentCell.RowIndex]);
            }
            
            this.inlineTaxonomy1.BringToFront();
            this.inlineTaxonomy2.BringToFront();

            this.inlineTaxonomy1.Focus();
        }

        private void SetInlineFromPosition(DataGridViewRow row)
        {
            int col1 = 0;
            int col2 = 0;
            
            if(this.tabControl1.SelectedTab == this.tabAsset)
            {
                col1 = this.dgv1.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col1_taxonomy1.Name).First().Index;
                col2 = this.dgv1.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col1_taxonomy2.Name).First().Index;
            }

            if (this.tabControl1.SelectedTab == this.tabLiability)
            {
                col1 = this.dgv2.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col2_taxonomy1.Name).First().Index;
                col2 = this.dgv2.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col2_taxonomy2.Name).First().Index;
            }

            if (this.tabControl1.SelectedTab == this.tabEquity)
            {
                col1 = this.dgv3.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col3_taxonomy1.Name).First().Index;
                col2 = this.dgv3.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col3_taxonomy2.Name).First().Index;
            }

            if (this.tabControl1.SelectedTab == this.tabRevenue)
            {
                col1 = this.dgv4.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col4_taxonomy1.Name).First().Index;
                col2 = this.dgv4.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col4_taxonomy2.Name).First().Index;
            }

            if (this.tabControl1.SelectedTab == this.tabExpense)
            {
                col1 = this.dgv5.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col5_taxonomy1.Name).First().Index;
                col2 = this.dgv5.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col5_taxonomy2.Name).First().Index;
            }

            this.inlineTaxonomy1.SetInlineControlPosition(row.DataGridView, row.Index, col1);
            this.inlineTaxonomy2.SetInlineControlPosition(row.DataGridView, row.Index, col2);

        }

        private void cLangTh_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                this.lang_accnum = LANG_ACCNUM.TH;
                this.dgv1.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col1_accnam2.Name).First().Visible = false;
                this.dgv1.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col1_accnam.Name).First().Visible = true;
                this.dgv2.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col2_accnam2.Name).First().Visible = false;
                this.dgv2.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col2_accnam.Name).First().Visible = true;
                this.dgv3.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col3_accnam2.Name).First().Visible = false;
                this.dgv3.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col3_accnam.Name).First().Visible = true;
                this.dgv4.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col4_accnam2.Name).First().Visible = false;
                this.dgv4.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col4_accnam.Name).First().Visible = true;
                this.dgv5.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col5_accnam2.Name).First().Visible = false;
                this.dgv5.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col5_accnam.Name).First().Visible = true;
            }
        }

        private void cLangEn_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                this.lang_accnum = LANG_ACCNUM.EN;
                this.dgv1.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col1_accnam.Name).First().Visible = false;
                this.dgv1.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col1_accnam2.Name).First().Visible = true;
                this.dgv2.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col2_accnam.Name).First().Visible = false;
                this.dgv2.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col2_accnam2.Name).First().Visible = true;
                this.dgv3.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col3_accnam.Name).First().Visible = false;
                this.dgv3.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col3_accnam2.Name).First().Visible = true;
                this.dgv4.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col4_accnam.Name).First().Visible = false;
                this.dgv4.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col4_accnam2.Name).First().Visible = true;
                this.dgv5.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col5_accnam.Name).First().Visible = false;
                this.dgv5.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col5_accnam2.Name).First().Visible = true;
            }
        }

        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string acctyp = "";

                if (((XDatagrid)sender).Name == this.dgv1.Name)
                    acctyp = this.glacc1[e.RowIndex].glacc.acctyp;

                if (((XDatagrid)sender).Name == this.dgv2.Name)
                    acctyp = this.glacc2[e.RowIndex].glacc.acctyp;

                if (((XDatagrid)sender).Name == this.dgv3.Name)
                    acctyp = this.glacc3[e.RowIndex].glacc.acctyp;

                if (((XDatagrid)sender).Name == this.dgv4.Name)
                    acctyp = this.glacc4[e.RowIndex].glacc.acctyp;

                if (((XDatagrid)sender).Name == this.dgv5.Name)
                    acctyp = this.glacc5[e.RowIndex].glacc.acctyp;

                if (acctyp == "1")
                {
                    e.CellStyle.ForeColor = Color.DarkGray;
                    e.CellStyle.SelectionForeColor = Color.DarkGray;
                    e.CellStyle.BackColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.WhiteSmoke;

                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    e.Handled = true;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Black;
                    e.CellStyle.SelectionForeColor = Color.Black;
                    e.CellStyle.BackColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.White;

                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    e.Handled = true;
                }
            }
        }

        private void dgv_Paint(object sender, PaintEventArgs e)
        {
            if (((XDatagrid)sender).CurrentCell == null)
                return;

            string acctyp = "";
            if (((XDatagrid)sender).Name == this.dgv1.Name)
                acctyp = ((GlaccDbf)((XDatagrid)sender).Rows[((XDatagrid)sender).CurrentCell.RowIndex].Cells[this.col1_glacc.Name].Value).acctyp;

            if (((XDatagrid)sender).Name == this.dgv2.Name)
                acctyp = ((GlaccDbf)((XDatagrid)sender).Rows[((XDatagrid)sender).CurrentCell.RowIndex].Cells[this.col2_glacc.Name].Value).acctyp;

            if (((XDatagrid)sender).Name == this.dgv3.Name)
                acctyp = ((GlaccDbf)((XDatagrid)sender).Rows[((XDatagrid)sender).CurrentCell.RowIndex].Cells[this.col3_glacc.Name].Value).acctyp;

            if (((XDatagrid)sender).Name == this.dgv4.Name)
                acctyp = ((GlaccDbf)((XDatagrid)sender).Rows[((XDatagrid)sender).CurrentCell.RowIndex].Cells[this.col4_glacc.Name].Value).acctyp;

            if (((XDatagrid)sender).Name == this.dgv5.Name)
                acctyp = ((GlaccDbf)((XDatagrid)sender).Rows[((XDatagrid)sender).CurrentCell.RowIndex].Cells[this.col5_glacc.Name].Value).acctyp;

            Rectangle rect = ((XDatagrid)sender).GetRowDisplayRectangle(((XDatagrid)sender).CurrentCell.RowIndex, true);
            if (acctyp == "0")
            {
                using (Pen p = new Pen(Color.Red))
                {
                    e.Graphics.DrawLine(p, new Point(rect.X, rect.Y), new Point(rect.X + rect.Width, rect.Y));
                    e.Graphics.DrawLine(p, new Point(rect.X, rect.Y + rect.Height - 2), new Point(rect.X + rect.Width, rect.Y + rect.Height - 2));
                }
            }
            else
            {
                using (Pen p = new Pen(Color.LightCoral))
                {
                    e.Graphics.DrawLine(p, new Point(rect.X, rect.Y), new Point(rect.X + rect.Width, rect.Y));
                    e.Graphics.DrawLine(p, new Point(rect.X, rect.Y + rect.Height - 2), new Point(rect.X + rect.Width, rect.Y + rect.Height - 2));
                }
            }
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            DialogSelectComp selcomp = new DialogSelectComp(this);
            if (selcomp.ShowDialog() != DialogResult.OK)
            {
                if(this.selected_comp == null)
                {
                    Application.Exit();
                }
                return;
            }

            this.selected_comp = selcomp.selected_comp;
            this.glacc_list = DbfTable.GetGlaccList(this.selected_comp);

            if (this.selected_comp != null)
            {
                SQLiteDbPrepare.EnsureDbCreated(this.selected_comp);
                options opt = HelperClass.GetOptions(OPTIONS.EFILING_TMP_DIR, this.selected_comp);
                if (opt.value_str != null && opt.value_str.Trim().Length > 0 && File.Exists(opt.value_str.Trim()))
                {
                    this.cZipFilePath.Text = opt.value_str.Trim();
                }
                else
                {
                    this.cZipFilePath.Text = string.Empty;
                }
            }

            this.FillForm();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(this.tag_xml == null || this.tag_xml.Count == 0)
            {
                XMessageBox.Show("กรุณาระบุที่เก็บไฟล์รูปแบบงบการเงินก่อน", "", MessageBoxButtons.OK, XMessageBoxIcon.Warning);
                this.btnBrowseZipFile.PerformClick();
                return;
            }

            if (this.form_mode == FORM_MODE.EDIT)
                return;

            if (this.tabControl1.SelectedTab == this.tabAsset)
            {
                if (this.dgv1.CurrentCell == null)
                    return;

                string acctyp = ((GlaccDbf)this.dgv1.Rows[this.dgv1.CurrentCell.RowIndex].Cells[this.col1_glacc.Name].Value).acctyp;
                if (acctyp == "1")
                    return;

                this.ShowInlineForm();
            }

            if (this.tabControl1.SelectedTab == this.tabLiability)
            {
                if (this.dgv2.CurrentCell == null)
                    return;

                string acctyp = ((GlaccDbf)this.dgv2.Rows[this.dgv2.CurrentCell.RowIndex].Cells[this.col2_glacc.Name].Value).acctyp;
                if (acctyp == "1")
                    return;

                this.ShowInlineForm();
            }

            if (this.tabControl1.SelectedTab == this.tabEquity)
            {
                if (this.dgv3.CurrentCell == null)
                    return;

                string acctyp = ((GlaccDbf)this.dgv3.Rows[this.dgv3.CurrentCell.RowIndex].Cells[this.col3_glacc.Name].Value).acctyp;
                if (acctyp == "1")
                    return;

                this.ShowInlineForm();
            }

            if (this.tabControl1.SelectedTab == this.tabRevenue)
            {
                if (this.dgv4.CurrentCell == null)
                    return;

                string acctyp = ((GlaccDbf)this.dgv4.Rows[this.dgv4.CurrentCell.RowIndex].Cells[this.col4_glacc.Name].Value).acctyp;
                if (acctyp == "1")
                    return;

                this.ShowInlineForm();
            }

            if (this.tabControl1.SelectedTab == this.tabExpense)
            {
                if (this.dgv5.CurrentCell == null)
                    return;

                string acctyp = ((GlaccDbf)this.dgv5.Rows[this.dgv5.CurrentCell.RowIndex].Cells[this.col5_glacc.Name].Value).acctyp;
                if (acctyp == "1")
                    return;

                this.ShowInlineForm();
            }

            this.ResetFormState(FORM_MODE.EDIT);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var taxo = Taxonomy.GetTaxonomyList(this);
            foreach (var item in taxo)
            {
                Console.WriteLine(" ==> " + item.taxodesc);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.ResetFormState(FORM_MODE.READ);
            this.HideInlineForm();
        }

        private void btnRegist_Click(object sender, EventArgs e)
        {
            
        }

        private void btnExportStatement_Click(object sender, EventArgs e)
        {
            DialogShareHolders ds = new DialogShareHolders(this);
            ds.ShowDialog();
        }

        private void btnShareHolder_Click(object sender, EventArgs e)
        {
            DialogShareHolders ds = new DialogShareHolders(this);
            ds.ShowDialog();
        }

        private void btnBrowseZipFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = this.selected_comp.GetAbsolutePath();
            ofd.Filter = "Zip File|*.zip|All File|*.*";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                if(HelperClass.GetFileNameListInZip(ofd.FileName).Where(f => f.ToLower() == "dimension_static.xml").Count() < 1)
                {
                    XMessageBox.Show("Zip file ที่ท่านเลือกไม่ใช่ไฟล์รูปแบบงบการเงิน กรุณาเลือกใหม่ให้ถูกต้อง", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                    return;
                }

                this.cZipFilePath.Text = ofd.FileName;
            }
        }

        private void cZipFilePath_TextChanged(object sender, EventArgs e)
        {
            if (((Label)sender).Text.Trim().Length == 0)
            {
                this.eFilingTmpDir = null;
                return;
            }

            string tmpDir = this.selected_comp.GetAbsolutePath() + @"\eFiling_temp";

            if (!Directory.Exists(tmpDir))
            {
                Directory.CreateDirectory(tmpDir);
            }

            if(!Directory.Exists(tmpDir + @"\" + Path.GetFileNameWithoutExtension(((Label)sender).Text)))
            {
                this.eFilingTmpDir = Directory.CreateDirectory(tmpDir + @"\" + Path.GetFileNameWithoutExtension(((Label)sender).Text));
            }
            else
            {
                this.eFilingTmpDir =  new DirectoryInfo(tmpDir + @"\" + Path.GetFileNameWithoutExtension(((Label)sender).Text));
            }

            if (!File.Exists(this.eFilingTmpDir.FullName + @"\dimension_static.xml"))
                HelperClass.ExtractZipFile(((Label)sender).Text, "", this.eFilingTmpDir.FullName);

            var option = OPTIONS.EFILING_TMP_DIR.GetOptions(this.selected_comp);
            option.value_str = ((Label)sender).Text;
            option.SaveOptions(this.selected_comp);

            this.tag_xml = GetTagIdList(this.eFilingTmpDir.FullName);
            this.tag_xml.ForEach(t =>
            {
                
            });
        }

        public static List<tagXml> GetTagIdList(string xml_file_path)
        {
            var tags = new List<tagXml>();

            string xml_file_th = string.Empty;
            string xml_file_en = string.Empty;

            DirectoryInfo d_info = new DirectoryInfo(xml_file_path);
            d_info.GetFiles().ToList().ForEach(f =>
            {
                if(f.Name.StartsWith("lab") && f.Name.EndsWith("th.xml") && !f.Name.Contains("rol"))
                {
                    xml_file_th = f.Name;
                }
                if (f.Name.StartsWith("lab") && f.Name.EndsWith("en.xml") && !f.Name.Contains("rol"))
                {
                    xml_file_en = f.Name;
                }
            });

            XElement elem = XElement.Load(xml_file_path + @"\" + xml_file_th);

            XElement elem2 = XElement.Parse(elem.Nodes().ElementAt(1).NodesAfterSelf().ToList()[2].ToString());
            elem2.Elements().ToList().Where(n => n.ToString().StartsWith("<link:label ")).ToList().ForEach(n =>
            {
                tags.Add(new tagXml
                {
                    tagId = n.Attribute("id").Value,
                    accnam_th = n.Value,
                    accnam_en = string.Empty
                });
            });

            elem = XElement.Load(xml_file_path + @"\" + xml_file_en);

            elem2 = XElement.Parse(elem.Nodes().ElementAt(1).NodesAfterSelf().ToList()[2].ToString());
            elem2.Elements().ToList().Where(n => n.ToString().StartsWith("<link:label ")).ToList().ForEach(n =>
            {
                var x = tags.Where(t => t.tagId == n.Attribute("id").Value).FirstOrDefault();
                x.accnam_en = n.Value;
            });

            return tags;
        }
    }
}
