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
    public partial class DialogShareHolders : Form
    {
        private MainForm main_form;
        private FORM_MODE form_mode = FORM_MODE.READ;
        private IsinfoDbf isinfo;
        private boj5_header boj5_header;
        private List<boj5_detail> boj5_detail;
        private BindingList<boj5_detail_VM> boj5_detail_bindinglist;
        
        private boj5_header tmp_boj5_header = null;
        private boj5_detail tmp_boj5_detail = null;

        private enum ACC_SOURCE
        {
            B, // Book
            M  // Meeting
        }
        private enum MEETING_TYPE
        {
            B, // จากสมุดทะเบียนรายชื่อผู้ถือหุ้น
            E, // ประชุมจัดตั้งบริษัท
            C, // ประชุมสามัญ
            S  // ประชุมวิสามัญ
        }
        private enum SHAREHOLDER_TYPE
        {
            P, // บุคคลธรรมดา
            C  // นิติบุคคล
        }
        private enum SHARE_TYPE : int
        {
            COMMON_SHARE = 0,
            PREFERRED_SHARE = 1
        }
            
        public DialogShareHolders(MainForm main_form)
        {
            this.main_form = main_form;
            InitializeComponent();
        }

        private void ResetFormState(FORM_MODE form_mode)
        {
            this.form_mode = form_mode;
            this.cAccSource.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.cSourceDate.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.cYearEnd.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.cTotalCapital.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.cTotalShare.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.cParValue.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.cThaiShareHolder.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.cTotalThaiShare.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.cForeignShareHolder.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.cTotalForeignShare.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.cMeetingNo.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.cMeetingTypeC.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.cMeetingTypeE.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.cMeetingTypeS.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.btnEdit.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnSave.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.btnStop.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.btnAddItem.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnEditItem.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnDeleteItem.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.dgv.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);

            if(this.form_mode == FORM_MODE.EDIT)
            {
                this.cMeetingTypeC.Enabled = this.tmp_boj5_header.accSource == ACC_SOURCE.M.ToString() ? true : false;
                this.cMeetingTypeS.Enabled = this.tmp_boj5_header.accSource == ACC_SOURCE.M.ToString() ? true : false;
                this.cMeetingTypeE.Enabled = this.tmp_boj5_header.accSource == ACC_SOURCE.M.ToString() ? true : false;
                this.cMeetingNo._ReadOnly = this.tmp_boj5_header.accSource == ACC_SOURCE.M.ToString() ? false : true;
            }
        }

        private void DialogShareHolders_Load(object sender, EventArgs e)
        {
            this.SetDropDownListItem();
            this.GetBojData();
            this.FillForm(this.boj5_header, this.boj5_detail);
        }

        private void SetDropDownListItem()
        {
            this.cAccSource._Items.Add(new XDropdownListItem { Text = "คัดจากสมุดทะเบียนผู้ถือหุ้น", Value = "B" });
            this.cAccSource._Items.Add(new XDropdownListItem { Text = "ณ วันประชุมผู้ถือหุ้น", Value = "M" });
        }

        private void GetBojData()
        {
            this.isinfo = DbfTable.GetIsinfo(this.main_form.selected_comp);
            using (LocalDbEntities db = DBX.DataSet(this.main_form.selected_comp))
            {
                this.boj5_header = db.boj5_header.FirstOrDefault();
                if(this.boj5_header == null)
                {
                    db.boj5_header.Add(new boj5_header
                    {
                        accSource = ACC_SOURCE.B.ToString(),
                        foreignShareholder = 0,
                        headerStatus = "A",
                        meetingNo = "",
                        meetingType = MEETING_TYPE.B.ToString(),
                        parValue = 0,
                        sourceDate = null,
                        thaiShareholder = 0,
                        totalCapital = 0,
                        totalForeignShare = 0,
                        totalShare = 0,
                        totalThaiShare = 0,
                        userId = "",
                        yearEnd = null
                    });
                    db.SaveChanges();

                    this.boj5_header = db.boj5_header.First();
                }

                this.boj5_detail = db.boj5_detail.Include("boj5_person").OrderBy(d => d.itemNo).ToList();
            }
        }

        private void FillForm(boj5_header boj5_header_to_fill, List<boj5_detail> boj5_detail_to_fill)
        {
            if(this.isinfo != null)
            {
                this.cCompNam._Text = this.isinfo.thinam;
                this.cTaxId._Text = this.isinfo.taxid;
            }

            if (boj5_header_to_fill != null)
            {
                var selected_accsource = this.cAccSource._Items.Cast<XDropdownListItem>().Where(i => (string)i.Value == boj5_header_to_fill.accSource).FirstOrDefault();
                if (selected_accsource != null)
                    this.cAccSource._SelectedItem = selected_accsource;

                this.cSourceDate._SelectedDate = boj5_header_to_fill.sourceDate;
                this.cYearEnd._SelectedDate = boj5_header_to_fill.yearEnd;
                this.cTotalCapital._Value = Convert.ToDecimal(boj5_header_to_fill.totalCapital);
                this.cTotalShare._Value = Convert.ToDecimal(boj5_header_to_fill.totalShare);
                this.cParValue._Value = Convert.ToDecimal(boj5_header_to_fill.parValue);
                this.cThaiShareHolder._Value = Convert.ToDecimal(boj5_header_to_fill.thaiShareholder);
                this.cTotalThaiShare._Value = Convert.ToDecimal(boj5_header_to_fill.totalThaiShare);
                this.cForeignShareHolder._Value = Convert.ToDecimal(boj5_header_to_fill.foreignShareholder);
                this.cTotalForeignShare._Value = Convert.ToDecimal(boj5_header_to_fill.totalForeignShare);
                this.cMeetingTypeE.Checked = boj5_header_to_fill.meetingType == MEETING_TYPE.E.ToString() ? true : false;
                this.cMeetingTypeC.Checked = boj5_header_to_fill.meetingType == MEETING_TYPE.C.ToString() ? true : false;
                this.cMeetingTypeS.Checked = boj5_header_to_fill.meetingType == MEETING_TYPE.S.ToString() ? true : false;
                this.cMeetingNo._Text = boj5_header_to_fill.meetingNo;

            }

            if(boj5_detail_to_fill != null)
            {
                this.boj5_detail_bindinglist = new BindingList<boj5_detail_VM>(this.boj5_detail.ToViewModel());
                this.dgv.DataSource = this.boj5_detail_bindinglist;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (LocalDbEntities db = DBX.DataSet(this.main_form.selected_comp))
            {
                this.tmp_boj5_header = db.boj5_header.First();
                this.FillForm(this.tmp_boj5_header, this.boj5_detail);
            }

            this.ResetFormState(FORM_MODE.EDIT);
            this.cAccSource.Focus();

            //using (LocalDbEntities db = DBX.DataSet(this.main_form.selected_comp))
            //{
            //    db.glacc_match.Add(new glacc_match { accnum = "1234-56", depcod = "ขาย 2", taxodesc = "TAXO 1", taxodesc2 = "TAXO 2" });
            //    db.boj5_person.Add(new boj5_person { holderName = "วีรวัฒน์ ตรุเจตนารมย์", addrFull = "kanasiri" });
            //    db.boj5_person.Add(new boj5_person { holderName = "รฐา ตรุเจตนารมย์", addrFull = "kanasiri" });
            //    db.SaveChanges();
            //    var a = db.glacc_match.ToList();
            //    var b = db.boj5_detail.ToList();
            //    var c = db.boj5_header.ToList();
            //    var d = db.boj5_person.ToList();
            //    Console.WriteLine(" ==> ok");
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.tmp_boj5_header == null)
                return;
            try
            {
                using (LocalDbEntities db = DBX.DataSet(this.main_form.selected_comp))
                {
                    var header_to_update = db.boj5_header.Find(1);
                    header_to_update.accSource = this.tmp_boj5_header.accSource;
                    header_to_update.foreignShareholder = this.tmp_boj5_header.foreignShareholder;
                    header_to_update.headerStatus = this.tmp_boj5_header.headerStatus;
                    header_to_update.meetingNo = this.tmp_boj5_header.meetingNo;
                    header_to_update.meetingType = this.tmp_boj5_header.meetingType;
                    header_to_update.parValue = this.tmp_boj5_header.parValue;
                    header_to_update.sourceDate = this.tmp_boj5_header.sourceDate;
                    header_to_update.thaiShareholder = this.tmp_boj5_header.thaiShareholder;
                    header_to_update.totalCapital = this.tmp_boj5_header.totalCapital;
                    header_to_update.totalForeignShare = this.tmp_boj5_header.totalForeignShare;
                    header_to_update.totalShare = this.tmp_boj5_header.totalShare;
                    header_to_update.totalThaiShare = this.tmp_boj5_header.totalThaiShare;
                    header_to_update.userId = this.tmp_boj5_header.userId;
                    header_to_update.yearEnd = this.tmp_boj5_header.yearEnd;

                    db.SaveChanges();
                }

                this.tmp_boj5_header = null;
                this.ResetFormState(FORM_MODE.READ);
                this.GetBojData();
                this.FillForm(this.boj5_header, this.boj5_detail);
            }
            catch (Exception ex)
            {
                XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if(XMessageBox.Show("ยกเลิกการแก้ไขข้อมูล, ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question) == DialogResult.OK)
            {
                this.tmp_boj5_header = null;
                this.GetBojData();
                this.FillForm(this.boj5_header, this.boj5_detail);
                this.ResetFormState(FORM_MODE.READ);
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            DialogBojDetail d = new DialogBojDetail(this.main_form);
            d.ShowDialog();
            this.GetBojData();
            this.FillForm(this.boj5_header, this.boj5_detail);
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            if (this.dgv.CurrentCell == null)
                return;

            boj5_detail detail = (boj5_detail)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_boj5_detail.Name].Value;
            DialogBojDetail d = new DialogBojDetail(this.main_form, detail);
            d.ShowDialog();
            this.GetBojData();
            this.FillForm(this.boj5_header, this.boj5_detail);
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (this.dgv.CurrentCell == null)
                return;

            this.dgv.Rows[this.dgv.CurrentCell.RowIndex].DrawDeletingRowOverlay();
            if (XMessageBox.Show("ลบรายการที่เลือก, ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question) != DialogResult.OK)
            {
                this.dgv.Rows[this.dgv.CurrentCell.RowIndex].ClearDeletingRowOverlay();
                return;
            }

            var deleting_id = ((boj5_detail)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_boj5_detail.Name].Value).id;

            try
            {
                using (LocalDbEntities db = DBX.DataSet(this.main_form.selected_comp))
                {
                    var deleting_data = db.boj5_detail.Find(deleting_id);
                    if (deleting_data != null)
                    {
                        db.boj5_detail.Remove(deleting_data);
                        db.SaveChanges();

                        long? seq = 0;
                        db.boj5_detail.Include("boj5_person").OrderBy(d => d.boj5_person.itemSeq).ToList().ForEach(d => d.itemNo = ++seq);
                        db.SaveChanges();

                        this.GetBojData();
                        this.FillForm(this.boj5_header, this.boj5_detail);
                    }
                    else
                    {
                        XMessageBox.Show("ค้นหารายการที่ต้องการลบไม่พบ", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                    }
                }
            }
            catch (Exception ex)
            {
                XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
            }
        }

        /* Form's Control */

        private void cAccSource__SelectedItemChanged(object sender, EventArgs e)
        {
            if (this.tmp_boj5_header == null)
                return;

            string acc_src = (string)((XDropdownListItem)((XDropdownList)sender)._SelectedItem).Value;
            if(acc_src == ACC_SOURCE.B.ToString())
            {
                this.cMeetingTypeC.Checked = false;
                this.cMeetingTypeE.Checked = false;
                this.cMeetingTypeS.Checked = false;
                this.cMeetingTypeC.Enabled = false;
                this.cMeetingTypeE.Enabled = false;
                this.cMeetingTypeS.Enabled = false;
                this.cMeetingNo._ReadOnly = true;
                this.cMeetingNo._Text = string.Empty;
                this.tmp_boj5_header.accSource = ACC_SOURCE.B.ToString();
                this.tmp_boj5_header.meetingType = ACC_SOURCE.B.ToString();
                return;
            }

            if(acc_src == ACC_SOURCE.M.ToString())
            {
                this.cMeetingTypeC.Enabled = true;
                this.cMeetingTypeE.Enabled = true;
                this.cMeetingTypeS.Enabled = true;
                this.cMeetingNo._ReadOnly = false;
                this.tmp_boj5_header.accSource = ACC_SOURCE.M.ToString();
                this.cMeetingTypeC.Checked = true;
                return;
            }
        }

        private void cYearEnd__SelectedDateChanged(object sender, EventArgs e)
        {
            if (this.tmp_boj5_header == null)
                return;

            this.tmp_boj5_header.yearEnd = ((XDatePicker)sender)._SelectedDate;
        }

        private void cMeetingTypeE_CheckedChanged(object sender, EventArgs e)
        {
            if (this.tmp_boj5_header == null)
                return;

            if (((RadioButton)sender).Checked)
            {
                this.tmp_boj5_header.meetingType = MEETING_TYPE.E.ToString();
            }
        }

        private void cMeetingTypeC_CheckedChanged(object sender, EventArgs e)
        {
            if (this.tmp_boj5_header == null)
                return;

            if (((RadioButton)sender).Checked)
            {
                this.tmp_boj5_header.meetingType = MEETING_TYPE.C.ToString();
            }
        }

        private void cMeetingTypeS_CheckedChanged(object sender, EventArgs e)
        {
            if (this.tmp_boj5_header == null)
                return;

            if (((RadioButton)sender).Checked)
            {
                this.tmp_boj5_header.meetingType = MEETING_TYPE.S.ToString();
            }
        }

        private void cMeetingNo__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_boj5_header == null)
                return;

            this.tmp_boj5_header.meetingNo = ((XTextEdit)sender)._Text;
        }

        private void cSourceDate__SelectedDateChanged(object sender, EventArgs e)
        {
            if (this.tmp_boj5_header == null)
                return;

            this.tmp_boj5_header.sourceDate = ((XDatePicker)sender)._SelectedDate;
        }

        private void cTotalCapital__ValueChanged(object sender, EventArgs e)
        {
            if (this.tmp_boj5_header == null)
                return;

            this.tmp_boj5_header.totalCapital = Convert.ToDouble(((XNumEdit)sender)._Value);
        }

        private void cTotalShare__ValueChanged(object sender, EventArgs e)
        {
            if (this.tmp_boj5_header == null)
                return;

            this.tmp_boj5_header.totalShare = (long)((XNumEdit)sender)._Value;
        }

        private void cParValue__ValueChanged(object sender, EventArgs e)
        {
            if (this.tmp_boj5_header == null)
                return;

            this.tmp_boj5_header.parValue = Convert.ToDouble(((XNumEdit)sender)._Value);
        }

        private void cThaiShareHolder__ValueChanged(object sender, EventArgs e)
        {
            if (this.tmp_boj5_header == null)
                return;

            this.tmp_boj5_header.thaiShareholder = (long)((XNumEdit)sender)._Value;
        }

        private void cTotalThaiShare__ValueChanged(object sender, EventArgs e)
        {
            if (this.tmp_boj5_header == null)
                return;

            this.tmp_boj5_header.totalThaiShare = (long)((XNumEdit)sender)._Value;
        }

        private void cForeignShareHolder__ValueChanged(object sender, EventArgs e)
        {
            if (this.tmp_boj5_header == null)
                return;

            this.tmp_boj5_header.foreignShareholder = (long)((XNumEdit)sender)._Value;
        }

        private void cTotalForeignShare__ValueChanged(object sender, EventArgs e)
        {
            if (this.tmp_boj5_header == null)
                return;

            this.tmp_boj5_header.totalForeignShare = (long)((XNumEdit)sender)._Value;
        }

        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e.RowIndex == -1 && ((XDatagrid)sender).Columns[e.ColumnIndex].Name == this.col_Amount.Name){
                e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentBackground);

                Rectangle rect = ((XDatagrid)sender).GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                Rectangle rect1 = new Rectangle(rect.X, rect.Y, rect.Width, (int)Math.Floor((decimal)(rect.Height / 2)));
                Rectangle rect2 = new Rectangle(rect.X, rect.Y + rect1.Height, rect.Width, (int)Math.Floor((decimal)(rect.Height / 2)));
                using (StringFormat sf = new StringFormat() { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center })
                {
                    using (SolidBrush b = new SolidBrush(((XDatagrid)sender).ColumnHeadersDefaultCellStyle.ForeColor))
                    {
                        using (Font f = new Font(((XDatagrid)sender).ColumnHeadersDefaultCellStyle.Font.Name, 8, FontStyle.Regular))
                        {
                            e.Graphics.DrawString("มูลค่าหุ้นที่ชำระแล้ว", f, b, rect1, sf);
                            e.Graphics.DrawString("มูลค่าหุ้นที่ถือว่าชำระแล้ว", f, b, rect2, sf);
                            using (Pen p = new Pen(Color.DarkGray))
                            {
                                e.Graphics.DrawLine(p, rect2.X, rect2.Y, rect2.X + rect2.Width, rect2.Y);
                            }
                        }
                    }
                }
                e.Handled = true;
                return;
            }

            if(e.RowIndex > -1 && ((XDatagrid)sender).Columns[e.ColumnIndex].Name == this.col_Amount.Name){
                e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentBackground);

                Rectangle rect = ((XDatagrid)sender).GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                Rectangle rect1 = new Rectangle(rect.X, rect.Y, rect.Width, (int)Math.Floor((decimal)(rect.Height / 2)));
                Rectangle rect2 = new Rectangle(rect.X, rect.Y + rect1.Height, rect.Width, (int)Math.Floor((decimal)(rect.Height / 2)));
                using (StringFormat sf = new StringFormat() { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center })
                {
                    using (SolidBrush b = new SolidBrush(((XDatagrid)sender).DefaultCellStyle.ForeColor))
                    {
                        using (Font f = new Font(((XDatagrid)sender).DefaultCellStyle.Font.Name, 8, FontStyle.Regular))
                        {
                            e.Graphics.DrawString(String.Format("{0:#,0.00}", this.boj5_detail[e.RowIndex].paidAmount), f, b, rect1, sf);
                            e.Graphics.DrawString(String.Format("{0:#,0.00}", this.boj5_detail[e.RowIndex].asPaidAmount), f, b, rect2, sf);
                            using (Pen p = new Pen(Color.DarkGray))
                            {
                                e.Graphics.DrawLine(p, rect2.X, rect2.Y, rect2.X + rect2.Width, rect2.Y);
                            }
                        }
                    }
                }
                e.Handled = true;
                return;
            }
        }
    }
}
