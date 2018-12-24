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
        private boj5_header boj5_header;
        private List<boj5_person> boj5_detail;
        //private BindingList<>
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
        }

        private void DialogShareHolders_Load(object sender, EventArgs e)
        {
            this.SetDropDownListItem();
            this.GetBojData();
        }

        private void SetDropDownListItem()
        {
            this.cAccSource._Items.Add(new XDropdownListItem { Text = "คัดจากสมุดทะเบียนผู้ถือหุ้น", Value = "B" });
            this.cAccSource._Items.Add(new XDropdownListItem { Text = "ณ วันประชุมผู้ถือหุ้น", Value = "M" });
        }

        private void GetBojData()
        {
            using (SQLiteDbContext db = new SQLiteDbContext(this.main_form.selected_comp))
            {
                this.boj5_header = db.boj5_header.ToList().FirstOrDefault();
                this.boj5_detail = db.boj5_person.ToList();
            }
        }

        private void FillForm()
        {
            if(this.boj5_header != null)
            {
                var selected_accsource = this.cAccSource._Items.Cast<XDropdownListItem>().Where(i => (string)i.Value == this.boj5_header.accSource).FirstOrDefault();
                if (selected_accsource != null)
                    this.cAccSource._SelectedItem = selected_accsource;

                this.cSourceDate._SelectedDate = boj5_header.sourceDate;
                this.cYearEnd._SelectedDate = boj5_header.yearEnd;
                this.cTotalCapital._Value = boj5_header.totalCapital;
                this.cTotalShare._Value = boj5_header.totalShare;
                this.cParValue._Value = boj5_header.parValue;
                this.cThaiShareHolder._Value = boj5_header.thaiShareholder;
                this.cTotalThaiShare._Value = boj5_header.totalThaiShare;
                this.cForeignShareHolder._Value = boj5_header.foreignShareholder;
                this.cTotalForeignShare._Value = boj5_header.totalForeignShare;
                this.cMeetingTypeE.Checked = boj5_header.meetingType == MEETING_TYPE.E.ToString() ? true : false;
                this.cMeetingTypeC.Checked = boj5_header.meetingType == MEETING_TYPE.C.ToString() ? true : false;
                this.cMeetingTypeS.Checked = boj5_header.meetingType == MEETING_TYPE.S.ToString() ? true : false;
                this.cMeetingNo.Text = boj5_header.meetingNo;
                
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.ResetFormState(FORM_MODE.EDIT);
            this.cAccSource.Focus();

        }

        private void btnStop_Click(object sender, EventArgs e)
        {

        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {

        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {

        }
    }
}
