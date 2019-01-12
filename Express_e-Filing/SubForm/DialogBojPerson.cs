using Express_e_Filing.Model;
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
using Newtonsoft.Json;
using System.IO;

namespace Express_e_Filing.SubForm
{
    public partial class DialogBojPerson : Form
    {
        private OldForm main_form;
        private boj5_person boj5_person;
        private nationality_VM selected_nation = null;
        private enum SHARE_HOLDER_TYPE
        {
            C, // Company
            P  // Personal
        }

        public DialogBojPerson(OldForm main_form, boj5_person boj5_person = null)
        {
            this.main_form = main_form;
            this.boj5_person = boj5_person;
            InitializeComponent();
        }

        private void DialogBojPerson_Load(object sender, EventArgs e)
        {
            this.SetDropdownItem();
            if(this.boj5_person == null)
            {
                this.boj5_person = new boj5_person
                {
                    id = -1,
                    addrForeign = string.Empty,
                    addrFull = string.Empty,
                    addrNo = string.Empty,
                    amphur = string.Empty,
                    holderName = string.Empty,
                    itemSeq = -1,
                    moo = string.Empty,
                    nationality = string.Empty,
                    occupation = string.Empty,
                    province = string.Empty,
                    road = string.Empty,
                    shId = string.Empty,
                    shType = string.Empty,
                    soi = string.Empty,
                    surname = string.Empty,
                    title = string.Empty,
                    tumbol = string.Empty
                };
            }

            this.FillForm();
        }

        private void SetDropdownItem()
        {
            this.cShType._Items.Add(new XDropdownListItem { Text = "บุคคลธรรมดา", Value = SHARE_HOLDER_TYPE.P.ToString() });
            this.cShType._Items.Add(new XDropdownListItem { Text = "นิติบุคคล", Value = SHARE_HOLDER_TYPE.C.ToString() });

            string nationality_file_path = AppDomain.CurrentDomain.BaseDirectory + @"Template\nationality.json";

            if (File.Exists(nationality_file_path))
            {
                JsonConvert.DeserializeObject<List<nationality_VM>>(File.ReadAllText(nationality_file_path)).OrderBy(n => n.nationality_code).ToList().ForEach(n =>
                {
                    this.cNationality._Items.Add(new XDropdownListItem { Text = n.nationality_code + " : " + n.nationality_name_th, Value = n });
                });
            }
            else
            {
                XMessageBox.Show("ค้นหาแฟ้ม nationality.json ไม่พบ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                return;
            }
        }

        private void FillForm()
        {
            XDropdownListItem sh_type = this.cShType._Items.Cast<XDropdownListItem>().Where(i => (string)i.Value == this.boj5_person.shType).FirstOrDefault();
            XDropdownListItem nation = this.cNationality._Items.Cast<XDropdownListItem>().Where(i => ((nationality_VM)i.Value).nationality_name_th == this.boj5_person.nationality).FirstOrDefault();

            if (sh_type != null)
                this.cShType._SelectedItem = sh_type;
            if (nation != null)
                this.cNationality._SelectedItem = nation;
            this.cTitle._Text = this.boj5_person.title;
            this.cHolderName._Text = this.boj5_person.holderName;
            this.cSurname._Text = this.boj5_person.surname;
            this.cOccupation._Text = this.boj5_person.occupation;
            this.cShId._Text = this.boj5_person.shId;
            this.cAddrNo._Text = this.boj5_person.addrNo;
            this.cMoo._Text = this.boj5_person.moo;
            this.cSoi._Text = this.boj5_person.soi;
            this.cRoad._Text = this.boj5_person.road;
            this.cTumbol._Text = this.boj5_person.tumbol;
            this.cAmphur._Text = this.boj5_person.amphur;
            this.cProvince._Text = this.boj5_person.province;
            this.cAddrForeign.Text = this.boj5_person.addrForeign;
        }

        private void cShType__SelectedItemChanged(object sender, EventArgs e)
        {
            this.boj5_person.shType = (string)((XDropdownListItem)((XDropdownList)sender)._SelectedItem).Value;
        }

        private void cTitle__TextChanged(object sender, EventArgs e)
        {
            this.boj5_person.title = ((XTextEdit)sender)._Text;
        }

        private void cHolderName__TextChanged(object sender, EventArgs e)
        {
            this.boj5_person.holderName = ((XTextEdit)sender)._Text;
        }

        private void cSurname__TextChanged(object sender, EventArgs e)
        {
            this.boj5_person.surname = ((XTextEdit)sender)._Text;
        }

        private void cNationality__SelectedItemChanged(object sender, EventArgs e)
        {
            this.selected_nation = (nationality_VM)((XDropdownListItem)((XDropdownList)sender)._SelectedItem).Value;
            this.boj5_person.nationality = this.selected_nation.nationality_name_th;
            if(this.selected_nation.nationality_code == "TH")
            {
                this.cAddrNo._ReadOnly = false;
                this.cMoo._ReadOnly = false;
                this.cSoi._ReadOnly = false;
                this.cRoad._ReadOnly = false;
                this.cTumbol._ReadOnly = false;
                this.cAmphur._ReadOnly = false;
                this.cProvince._ReadOnly = false;
                this.cAddrForeign.ReadOnly = true;
                this.cAddrForeign.Text = string.Empty;
            }
            else
            {
                this.cAddrNo._ReadOnly = true;
                this.cMoo._ReadOnly = true;
                this.cSoi._ReadOnly = true;
                this.cRoad._ReadOnly = true;
                this.cTumbol._ReadOnly = true;
                this.cAmphur._ReadOnly = true;
                this.cProvince._ReadOnly = true;
                this.cAddrForeign.ReadOnly = false;
                this.cAddrNo._Text = string.Empty;
                this.cMoo._Text = string.Empty;
                this.cSoi._Text = string.Empty;
                this.cRoad._Text = string.Empty;
                this.cTumbol._Text = string.Empty;
                this.cAmphur._Text = string.Empty;
                this.cProvince._Text = string.Empty;
            }
        }

        private void cOccupation__TextChanged(object sender, EventArgs e)
        {
            this.boj5_person.occupation = ((XTextEdit)sender)._Text;
        }

        private void cShId__TextChanged(object sender, EventArgs e)
        {
            this.boj5_person.shId = ((XNumTextEdit)sender)._Text;
        }

        private void cAddrNo__TextChanged(object sender, EventArgs e)
        {
            this.boj5_person.addrNo = ((XTextEdit)sender)._Text;
            this.make_addrFull();
        }

        private void cMoo__TextChanged(object sender, EventArgs e)
        {
            this.boj5_person.moo = ((XTextEdit)sender)._Text;
            this.make_addrFull();
        }

        private void cSoi__TextChanged(object sender, EventArgs e)
        {
            this.boj5_person.soi = ((XTextEdit)sender)._Text;
            this.make_addrFull();
        }

        private void cRoad__TextChanged(object sender, EventArgs e)
        {
            this.boj5_person.road = ((XTextEdit)sender)._Text;
            this.make_addrFull();
        }

        private void cTumbol__TextChanged(object sender, EventArgs e)
        {
            this.boj5_person.tumbol = ((XTextEdit)sender)._Text;
            this.make_addrFull();
        }

        private void cAmphur__TextChanged(object sender, EventArgs e)
        {
            this.boj5_person.amphur = ((XTextEdit)sender)._Text;
            this.make_addrFull();
        }

        private void cProvince__TextChanged(object sender, EventArgs e)
        {
            this.boj5_person.province = ((XTextEdit)sender)._Text;
            this.make_addrFull();
        }

        private void cAddrForeign_TextChanged(object sender, EventArgs e)
        {
            this.boj5_person.addrForeign = ((TextBox)sender).Text;
            this.make_addrFull();
        }

        private void make_addrFull()
        {
            if (this.selected_nation == null)
                return;

            if(this.selected_nation.nationality_code == "TH")
            {
                this.boj5_person.addrFull = this.boj5_person.addrNo.Trim();
                this.boj5_person.addrFull += this.boj5_person.moo != null && this.boj5_person.moo.Trim().Length > 0 ? " ม." + this.boj5_person.moo.Trim() : "";
                this.boj5_person.addrFull += this.boj5_person.soi != null && this.boj5_person.soi.Trim().Length > 0 ? " ซ." + this.boj5_person.soi.Trim() : "";
                this.boj5_person.addrFull += this.boj5_person.road != null && this.boj5_person.road.Trim().Length > 0 ? " ถ." + this.boj5_person.road.Trim() : "";
                this.boj5_person.addrFull += this.boj5_person.tumbol != null && this.boj5_person.tumbol.Trim().Length > 0 ? " ต." + this.boj5_person.tumbol.Trim() : "";
                this.boj5_person.addrFull += this.boj5_person.amphur != null && this.boj5_person.amphur.Trim().Length > 0 ? " อ." + this.boj5_person.amphur.Trim() : "";
                this.boj5_person.addrFull += this.boj5_person.province != null && this.boj5_person.province.Trim().Length > 0 ? " จ." + this.boj5_person.province.Trim() : "";
            }
            else
            {
                this.boj5_person.addrFull = this.boj5_person.addrForeign.Trim();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(this.boj5_person.shType.Trim().Length == 0)
            {
                XMessageBox.Show("กรุณาระบุประเภทของผู้ถือหุ้น", "", MessageBoxButtons.OK, XMessageBoxIcon.Warning);
                this.cShType.Focus();
                return;
            }

            if(this.boj5_person.holderName.Trim().Length == 0)
            {
                XMessageBox.Show("กรุณาระบุชื่อผู้ถือหุ้น", "", MessageBoxButtons.OK, XMessageBoxIcon.Warning);
                this.cHolderName.Focus();
                return;
            }

            if(this.boj5_person.nationality.Trim().Length == 0)
            {
                XMessageBox.Show("กรุณาระบุสัญชาติของผู้ถือหุ้น", "", MessageBoxButtons.OK, XMessageBoxIcon.Warning);
                this.cNationality.Focus();
                return;
            }

            if(this.boj5_person.shId.Trim().Length == 0)
            {
                XMessageBox.Show("กรุณาระบุเลขนิติบุคคล/บัตรประชาชน", "", MessageBoxButtons.OK, XMessageBoxIcon.Warning);
                this.cShId.Focus();
                return;
            }
            try
            {
                using (LocalDbEntities db = DBX.DataSet(this.main_form.selected_comp))
                {
                    if (this.boj5_person.id > 0) // edit
                    {
                        var data_to_update = db.boj5_person.Find(this.boj5_person.id);
                        if (data_to_update == null)
                        {
                            db.boj5_person.Add(this.boj5_person);
                        }
                        else
                        {
                            data_to_update.addrForeign = this.boj5_person.addrForeign;
                            data_to_update.addrFull = this.boj5_person.addrFull;
                            data_to_update.addrNo = this.boj5_person.addrNo;
                            data_to_update.amphur = this.boj5_person.amphur;
                            data_to_update.holderName = this.boj5_person.holderName;
                            data_to_update.itemSeq = this.boj5_person.itemSeq;
                            data_to_update.moo = this.boj5_person.moo;
                            data_to_update.nationality = this.boj5_person.nationality;
                            data_to_update.occupation = this.boj5_person.occupation;
                            data_to_update.province = this.boj5_person.province;
                            data_to_update.road = this.boj5_person.road;
                            data_to_update.shId = this.boj5_person.shId;
                            data_to_update.shType = this.boj5_person.shType;
                            data_to_update.soi = this.boj5_person.soi;
                            data_to_update.surname = this.boj5_person.surname;
                            data_to_update.title = this.boj5_person.title;
                            data_to_update.tumbol = this.boj5_person.tumbol;
                        }
                    }
                    else // add
                    {
                        db.boj5_person.Add(this.boj5_person);
                    }
                    db.SaveChanges();

                    long? seq = 0;
                    db.boj5_person.ToList().ForEach(p => p.itemSeq = ++seq);
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
    }
}