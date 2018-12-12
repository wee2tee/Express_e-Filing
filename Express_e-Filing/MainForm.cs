using System;
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

namespace Express_e_Filing
{
    public partial class MainForm : Form
    {
        private SccompDbf selected_comp = null;
        private List<GlaccDbf> glacc_list;

        private BindingList<GlaccTaxonomyVM> glacc1;
        private BindingList<GlaccTaxonomyVM> glacc2;
        private BindingList<GlaccTaxonomyVM> glacc3;
        private BindingList<GlaccTaxonomyVM> glacc4;
        private BindingList<GlaccTaxonomyVM> glacc5;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if(this.selected_comp == null)
            {
                this.btnOpenFolder.PerformClick();
            }
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            DialogSelectComp selcomp = new DialogSelectComp(this);
            if (selcomp.ShowDialog() != DialogResult.OK)
                return;

            this.selected_comp = selcomp.selected_comp;
            this.glacc_list = DbfTable.GetGlaccList(this.selected_comp);

            this.FillForm();
        }

        private void FillForm()
        {
            this.cCompName.Text = this.selected_comp.compnam;
            this.cDataPath.Text = this.selected_comp.path;
            this.lblProgramPath.Text = AppDomain.CurrentDomain.BaseDirectory;

            this.glacc1 = new BindingList<GlaccTaxonomyVM>(this.glacc_list.Where(g => g.group == "1").ToViewModel());

            this.dgv1.DataSource = this.glacc1;
        }
    }
}
