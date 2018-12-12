using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CC;
using Express_e_Filing.Model;
using Express_e_Filing.Misc;

namespace Express_e_Filing.SubForm
{
    public partial class DialogSelectComp : Form
    {
        public SccompDbf selected_comp = null;

        private MainForm main_form;
        private BindingList<SccompDbfVM> sccomp_list;
        private enum SORT_TYPE
        {
            COMPNAM,
            COMPCOD
        }
        private SORT_TYPE sort_type = SORT_TYPE.COMPNAM;

        public DialogSelectComp(MainForm main_form)
        {
            this.main_form = main_form;
            InitializeComponent();
        }

        private void DialogSelectComp_Load(object sender, EventArgs e)
        {
            this.sccomp_list = new BindingList<SccompDbfVM>(DbfTable.GetSccompList().ToViewModel());

            this.dgv.DataSource = this.sccomp_list;
        }

        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            if(((XDatagrid)sender).CurrentCell == null)
            {
                this.selected_comp = null;
                return;
            }

            this.selected_comp = (SccompDbf)((XDatagrid)sender).Rows[((XDatagrid)sender).CurrentCell.RowIndex].Cells[this.col_sccomp.Name].Value;
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (this.dgv.CurrentCell == null)
                return;

            string focused_compnam = (string)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_compnam.Name].Value;

            if(this.sort_type == SORT_TYPE.COMPCOD)
            {
                this.sccomp_list = new BindingList<SccompDbfVM>(DbfTable.GetSccompList().ToViewModel().OrderBy(s => s.compnam).ToList());
                this.dgv.DataSource = this.sccomp_list;
                this.sort_type = SORT_TYPE.COMPNAM;

                var selected_row = this.dgv.Rows.Cast<DataGridViewRow>().Where(r => (string)r.Cells[this.col_compnam.Name].Value == focused_compnam).FirstOrDefault();
                if (selected_row != null)
                    selected_row.Cells[this.dgv.FirstDisplayedScrollingColumnIndex].Selected = true;
                return;
            }

            if(this.sort_type == SORT_TYPE.COMPNAM)
            {
                this.sccomp_list = new BindingList<SccompDbfVM>(DbfTable.GetSccompList().ToViewModel().OrderBy(s => s.compcod).ToList());
                this.dgv.DataSource = this.sccomp_list;
                this.sort_type = SORT_TYPE.COMPCOD;

                var selected_row = this.dgv.Rows.Cast<DataGridViewRow>().Where(r => (string)r.Cells[this.col_compnam.Name].Value == focused_compnam).FirstOrDefault();
                if (selected_row != null)
                    selected_row.Cells[this.dgv.FirstDisplayedScrollingColumnIndex].Selected = true; return;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DialogInlineSearch search = new DialogInlineSearch();
            search.SetBounds(this.PointToScreen(Point.Empty).X, this.btnOK.PointToScreen(Point.Empty).Y - 15, search.Bounds.Width, search.Bounds.Height);
            if(search.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine(" => " + search.keyword);
            }
        }

        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e.RowIndex == -1)
            {
                if(this.sort_type == SORT_TYPE.COMPNAM && ((XDatagrid)sender).Columns[e.ColumnIndex].Name == this.col_compnam.Name)
                {
                    e.CellStyle.BackColor = Color.Peru;
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    using (Pen p = new Pen(Color.LightGray))
                    {
                        Point p1 = new Point(e.CellBounds.X + e.CellBounds.Width - 18, e.CellBounds.Y + 18);
                        Point p2 = new Point(e.CellBounds.X + e.CellBounds.Width - 11, e.CellBounds.Y + 18);
                        Point p3 = new Point(e.CellBounds.X + e.CellBounds.Width - 15, e.CellBounds.Y + 10);
                        e.Graphics.DrawPolygon(p, new Point[] { p1, p2, p3 });
                    }
                    e.Handled = true;
                }

                if(this.sort_type == SORT_TYPE.COMPCOD && ((XDatagrid)sender).Columns[e.ColumnIndex].Name == this.col_compcod.Name)
                {
                    e.CellStyle.BackColor = Color.Peru;
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    using (Pen p = new Pen(Color.LightGray))
                    {
                        Point p1 = new Point(e.CellBounds.X + e.CellBounds.Width - 18, e.CellBounds.Y + 18);
                        Point p2 = new Point(e.CellBounds.X + e.CellBounds.Width - 11, e.CellBounds.Y + 18);
                        Point p3 = new Point(e.CellBounds.X + e.CellBounds.Width - 15, e.CellBounds.Y + 10);
                        e.Graphics.DrawPolygon(p, new Point[] { p1, p2, p3 });
                    }
                    e.Handled = true;
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void DialogSelectComp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString().Length > 0)
            {
                DialogInlineSearch search = new DialogInlineSearch(e.KeyChar.ToString());
                search.SetBounds(this.PointToScreen(Point.Empty).X, this.btnOK.PointToScreen(Point.Empty).Y - 15, search.Bounds.Width, search.Bounds.Height);

                if (search.ShowDialog() == DialogResult.OK)
                {
                    Console.WriteLine(" ==> " + search.keyword);
                }
            }
        }
    }
}
