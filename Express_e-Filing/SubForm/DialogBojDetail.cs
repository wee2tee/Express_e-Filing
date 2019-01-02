using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Express_e_Filing.Misc;
using Express_e_Filing.Model;
using CC;

namespace Express_e_Filing.SubForm
{
    public partial class DialogBojDetail : Form
    {
        private MainForm main_form;
        private boj5_detail boj5_detail;
        private BindingList<boj5_person_VM> person_list;
        private IsinfoDbf isinfo;
        private enum SHARE_TYPE : int
        {
            COMMON_SHARE = 0,
            PREFERRED_SHARE = 1
        }

        public DialogBojDetail(MainForm main_form, boj5_detail boj5_detail = null)
        {
            this.main_form = main_form;
            this.boj5_detail = boj5_detail;
            InitializeComponent();
        }

        private void DialogBojDetail_Load(object sender, EventArgs e)
        {
            this.isinfo = DbfTable.GetIsinfo(this.main_form.selected_comp);

            if (this.boj5_detail == null)
            {
                this.boj5_detail = new boj5_detail
                {
                    asPaidAmount = 0,
                    boj5_person_id = -1,
                    itemNo = -1,
                    paidAmount = 0,
                    shareDocDate = null,
                    shareDocId = string.Empty,
                    shareNumber = 0,
                    shareRegExist = null,
                    shareRegOmit = null,
                    shareType = ((int)SHARE_TYPE.COMMON_SHARE).ToString(),
                    userId = this.isinfo.taxid
                };
            }

            this.SetDropDownItem();
            this.LoadPersonToDatagrid();
            //using (LocalDbEntities db = DBX.DataSet(this.main_form.selected_comp))
            //{
            //    this.person_list = new BindingList<boj5_person_VM>(db.boj5_person.ToList().ToViewModel());
            //    this.person_list.ToList().ForEach(i =>
            //    {
            //        if(i.boj5_person.id == this.boj5_detail.boj5_person_id)
            //        {
            //            i.selected = true;
            //        }
            //    });
            //    this.dgvPerson.DataSource = this.person_list;
            //}

            this.FillForm();
        }

        private void LoadPersonToDatagrid()
        {
            using (LocalDbEntities db = DBX.DataSet(this.main_form.selected_comp))
            {
                this.person_list = new BindingList<boj5_person_VM>(db.boj5_person.ToList().ToViewModel());
                this.person_list.ToList().ForEach(i =>
                {
                    if (i.boj5_person.id == this.boj5_detail.boj5_person_id)
                    {
                        i.selected = true;
                    }
                });
                this.dgvPerson.DataSource = this.person_list;
            }
        }

        private void SetDropDownItem()
        {
            this.cShareType._Items.Add(new XDropdownListItem { Text = "หุ้นสามัญ", Value = ((int)SHARE_TYPE.COMMON_SHARE).ToString() });
            this.cShareType._Items.Add(new XDropdownListItem { Text = "หุ้นบุริมสิทธิ์", Value = ((int)SHARE_TYPE.PREFERRED_SHARE).ToString() });
        }

        private void FillForm()
        {
            XDropdownListItem share_type = this.cShareType._Items.Cast<XDropdownListItem>().Where(c => (string)c.Value == this.boj5_detail.shareType).FirstOrDefault();
            DataGridViewRow holder_row = this.dgvPerson.Rows.Cast<DataGridViewRow>().Where(r => (bool)r.Cells[this.col_selected.Name].Value == true).FirstOrDefault();

            this.cShareDocId._Text = this.boj5_detail.shareDocId;
            if (holder_row != null)
                holder_row.Cells[this.dgvPerson.FirstDisplayedScrollingColumnIndex].Selected = true;
            if (share_type != null)
                this.cShareType._SelectedItem = share_type;
            this.cShareNumber._Value = Convert.ToDecimal(this.boj5_detail.shareNumber);
            this.cPaidAmount._Value = Convert.ToDecimal(this.boj5_detail.paidAmount);
            this.cAsPaidAmount._Value = Convert.ToDecimal(this.boj5_detail.asPaidAmount);
            this.cShareDocDate._SelectedDate = this.boj5_detail.shareDocDate;
            this.cShareRegExist._SelectedDate = this.boj5_detail.shareRegExist;
            this.cShareRegOmit._SelectedDate = this.boj5_detail.shareRegOmit;
        }

        private void cShareDocId__TextChanged(object sender, EventArgs e)
        {
            this.boj5_detail.shareDocId = ((XTextEdit)sender)._Text;
        }

        private void cShareType__SelectedItemChanged(object sender, EventArgs e)
        {
            this.boj5_detail.shareType = (string)((XDropdownListItem)((XDropdownList)sender)._SelectedItem).Value;
        }

        private void cShareNumber__ValueChanged(object sender, EventArgs e)
        {
            this.boj5_detail.shareNumber = (long)((XNumEdit)sender)._Value;
        }

        private void cPaidAmount__ValueChanged(object sender, EventArgs e)
        {
            this.boj5_detail.paidAmount = Convert.ToDouble(((XNumEdit)sender)._Value);
        }

        private void cAsPaidAmount__ValueChanged(object sender, EventArgs e)
        {
            this.boj5_detail.asPaidAmount = Convert.ToDouble(((XNumEdit)sender)._Value);
        }

        private void cShareDocDate__SelectedDateChanged(object sender, EventArgs e)
        {
            this.boj5_detail.shareDocDate = ((XDatePicker)sender)._SelectedDate;
        }

        private void cShareRegExist__SelectedDateChanged(object sender, EventArgs e)
        {
            this.boj5_detail.shareRegExist = ((XDatePicker)sender)._SelectedDate;
        }

        private void cShareRegOmit__SelectedDateChanged(object sender, EventArgs e)
        {
            this.boj5_detail.shareRegOmit = ((XDatePicker)sender)._SelectedDate;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(this.boj5_detail.shareDocId.Trim().Length == 0)
            {
                XMessageBox.Show("กรุณาระบุหมายเลขใบหุ้น", "", MessageBoxButtons.OK, XMessageBoxIcon.Warning);
                this.cShareDocId.Focus();
                return;
            }

            if(this.boj5_detail.boj5_person_id == -1)
            {
                XMessageBox.Show("กรุณาระบุผู้ถือหุ้น", "", MessageBoxButtons.OK, XMessageBoxIcon.Warning);
                //this.cHolderId.Focus();
                this.dgvPerson.Focus();
                return;
            }

            if(this.boj5_detail.shareNumber == 0)
            {
                XMessageBox.Show("กรุณาระบุจำนวนหุ้น", "", MessageBoxButtons.OK, XMessageBoxIcon.Warning);
                this.cShareNumber.Focus();
                return;
            }

            if (!this.boj5_detail.shareDocDate.HasValue)
            {
                XMessageBox.Show("กรุณาระบุวันที่ออกเลขที่ใบหุ้น", "", MessageBoxButtons.OK, XMessageBoxIcon.Warning);
                this.cShareDocDate.Focus();
                return;
            }

            if (!this.boj5_detail.shareRegExist.HasValue)
            {
                XMessageBox.Show("กรุณาระบุวันที่ลงทะเบียนผู้ถือหุ้น", "", MessageBoxButtons.OK, XMessageBoxIcon.Warning);
                this.cShareRegExist.Focus();
                return;
            }

            try
            {
                using (LocalDbEntities db = DBX.DataSet(this.main_form.selected_comp))
                {
                    if (this.boj5_detail.id > 0) // edit
                    {
                        var data_to_update = db.boj5_detail.Find(this.boj5_detail.id);
                        if(data_to_update == null)
                        {
                            db.boj5_detail.Add(this.boj5_detail);
                        }
                        else
                        {
                            data_to_update.asPaidAmount = this.boj5_detail.asPaidAmount;
                            data_to_update.boj5_person_id = this.boj5_detail.boj5_person_id;
                            data_to_update.paidAmount = this.boj5_detail.paidAmount;
                            data_to_update.shareDocDate = this.boj5_detail.shareDocDate;
                            data_to_update.shareDocId = this.boj5_detail.shareDocId;
                            data_to_update.shareNumber = this.boj5_detail.shareNumber;
                            data_to_update.shareRegExist = this.boj5_detail.shareRegExist;
                            data_to_update.shareRegOmit = this.boj5_detail.shareRegOmit;
                            data_to_update.shareType = this.boj5_detail.shareType;
                        }
                    }
                    else // add
                    {
                        db.boj5_detail.Add(this.boj5_detail);
                    }

                    db.SaveChanges();

                    long? seq = 0;
                    db.boj5_detail.Include("boj5_person").OrderBy(d => d.boj5_person.itemSeq).ToList().ForEach(d => d.itemNo = ++seq);
                    db.SaveChanges();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
            }
        }

        private void btnAddHolder_Click(object sender, EventArgs e)
        {
            DialogBojPerson p = new DialogBojPerson(this.main_form);
            if(p.ShowDialog() == DialogResult.OK)
            {
                this.LoadPersonToDatagrid();
            }
            
        }

        private void btnEditHolder_Click(object sender, EventArgs e)
        {
            if (this.dgvPerson.CurrentCell == null)
                return;

            var person = (boj5_person)this.dgvPerson.Rows[this.dgvPerson.CurrentCell.RowIndex].Cells[this.col_boj5_person.Name].Value;
            DialogBojPerson p = new DialogBojPerson(this.main_form, person);
            if(p.ShowDialog() == DialogResult.OK)
            {
                this.LoadPersonToDatagrid();
            }
        }

        private void btnDeleteHolder_Click(object sender, EventArgs e)
        {
            if (this.dgvPerson.CurrentCell == null)
                return;

            this.dgvPerson.Rows[this.dgvPerson.CurrentCell.RowIndex].DrawDeletingRowOverlay();
            
            try
            {
                using (LocalDbEntities db = DBX.DataSet(this.main_form.selected_comp))
                {
                    var deleting_id = ((boj5_person)this.dgvPerson.Rows[this.dgvPerson.CurrentCell.RowIndex].Cells[this.col_boj5_person.Name].Value).id;
                    boj5_person person_to_delete;

                    if (db.boj5_detail.Where(d => d.boj5_person_id == deleting_id).Count() > 0)
                    {
                        if(XMessageBox.Show("มีรายการใบหุ้นของผู้ถือหุ้นรายนี้อยู่\n - เลือก \"ตกลง\" เพื่อให้ลบทั้งรายการใบหุ้น และ ชื่อผู้ถือหุ้นรายนี้\n - เลือก \"ยกเลิก\" เพื่อยกเลิกการทำงานนี้", "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question) == DialogResult.OK)
                        {
                            person_to_delete = db.boj5_person.Find(deleting_id);
                            if(person_to_delete != null)
                            {
                                db.boj5_detail.RemoveRange(db.boj5_detail.Where(d => d.boj5_person_id == deleting_id));
                                db.boj5_person.Remove(db.boj5_person.Find(deleting_id));
                                db.SaveChanges();

                                long? seq = 0;
                                db.boj5_person.ToList().ForEach(p => p.itemSeq = ++seq);
                                db.SaveChanges();

                                this.LoadPersonToDatagrid();
                            }
                            else
                            {
                                XMessageBox.Show("ค้นหารายการที่ต้องการลบไม่พบ", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                                this.LoadPersonToDatagrid();
                            }
                        }
                        else
                        {
                            this.dgvPerson.Rows[this.dgvPerson.CurrentCell.RowIndex].ClearDeletingRowOverlay();
                        }
                        return;
                    }
                    else
                    {
                        if (XMessageBox.Show("ลบรายการที่เลือก, ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question) != DialogResult.OK)
                            this.dgvPerson.Rows[this.dgvPerson.CurrentCell.RowIndex].ClearDeletingRowOverlay();

                        person_to_delete = db.boj5_person.Find(deleting_id);
                        if (person_to_delete != null)
                        {
                            db.boj5_person.Remove(person_to_delete);
                            db.SaveChanges();

                            long? seq = 0;
                            db.boj5_person.ToList().ForEach(p => p.itemSeq = ++seq);
                            db.SaveChanges();
                            this.LoadPersonToDatagrid();
                        }
                        else
                        {
                            XMessageBox.Show("ค้นหารายการที่ต้องการลบไม่พบ", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                            this.LoadPersonToDatagrid();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.F9)
            {
                this.btnOK.PerformClick();
                return true;
            }

            if(keyData == Keys.Escape)
            {
                this.btnCancel.PerformClick();
                return true;
            }

            if(keyData == Keys.Enter)
            {
                if(!(this.btnOK.Focused || this.btnCancel.Focused))
                {
                    SendKeys.Send("{TAB}");
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgvPerson_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                if((bool)((XDatagrid)sender).Rows[e.RowIndex].Cells[this.col_selected.Name].Value == true)
                {
                    e.CellStyle.ForeColor = Color.Blue;
                    e.CellStyle.SelectionForeColor = Color.Blue;
                    e.CellStyle.Font = new Font(((XDatagrid)sender).DefaultCellStyle.Font.Name, ((XDatagrid)sender).DefaultCellStyle.Font.Size, FontStyle.Bold);
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    e.Handled = true;
                }
            }
        }

        private void dgvPerson_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                if(((XDatagrid)sender).Columns[e.ColumnIndex].Name == this.col_selected.Name)
                {
                    int cnt = 0;
                    
                    this.person_list.ToList().ForEach(i =>
                    {
                        if(e.RowIndex == cnt)
                        {
                            i.selected = true;
                            this.boj5_detail.boj5_person_id = this.person_list[cnt].boj5_person.id;
                        }
                        else
                        {
                            i.selected = false;
                        }

                        cnt++;
                    });
                    ((XDatagrid)sender).Refresh();
                }
            }
        }

        private void dgvPerson_CurrentCellChanged(object sender, EventArgs e)
        {
            if(((XDatagrid)sender).CurrentCell == null)
            {
                this.btnUp.Enabled = false;
                this.btnDown.Enabled = false;
                this.btnEditHolder.Enabled = false;
                this.btnDeleteHolder.Enabled = false;
            }
            else
            {
                this.btnEditHolder.Enabled = true;
                this.btnDeleteHolder.Enabled = true;
                this.btnUp.Enabled = ((XDatagrid)sender).CurrentCell.RowIndex == 0 ? false : true;
                this.btnDown.Enabled = ((XDatagrid)sender).CurrentCell.RowIndex == this.person_list.Count - 1 ? false : true;
            }

        }
    }
}
