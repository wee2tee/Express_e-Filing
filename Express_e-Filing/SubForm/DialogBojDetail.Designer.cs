namespace Express_e_Filing.SubForm
{
    partial class DialogBojDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.cShareDocId = new CC.XTextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.cShareNumber = new CC.XNumEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cShareType = new CC.XDropdownList();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cPaidAmount = new CC.XNumEdit();
            this.cAsPaidAmount = new CC.XNumEdit();
            this.cShareDocDate = new CC.XDatePicker();
            this.cShareRegExist = new CC.XDatePicker();
            this.cShareRegOmit = new CC.XDatePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgvPerson = new CC.XDatagrid();
            this.col_boj5_person = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_itemSeq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_holderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_nationality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_addrFull = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDeleteHolder = new System.Windows.Forms.Button();
            this.btnEditHolder = new System.Windows.Forms.Button();
            this.btnAddHolder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "เลขที่ใบหุ้น";
            // 
            // cShareDocId
            // 
            this.cShareDocId._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cShareDocId._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cShareDocId._ForeColor = System.Drawing.SystemColors.WindowText;
            this.cShareDocId._MaxLength = 50;
            this.cShareDocId._PasswordChar = '\0';
            this.cShareDocId._ReadOnly = false;
            this.cShareDocId._SelectionLength = 0;
            this.cShareDocId._SelectionStart = 0;
            this.cShareDocId._Text = "";
            this.cShareDocId._TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.cShareDocId.BackColor = System.Drawing.Color.White;
            this.cShareDocId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cShareDocId.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cShareDocId.Location = new System.Drawing.Point(97, 15);
            this.cShareDocId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cShareDocId.Name = "cShareDocId";
            this.cShareDocId.Size = new System.Drawing.Size(230, 22);
            this.cShareDocId.TabIndex = 1;
            this.cShareDocId._TextChanged += new System.EventHandler(this.cShareDocId__TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(308, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "จำนวน";
            // 
            // cShareNumber
            // 
            this.cShareNumber._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cShareNumber._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cShareNumber._DecimalDigit = 0;
            this.cShareNumber._ForeColor = System.Drawing.SystemColors.WindowText;
            this.cShareNumber._ForeColorReadOnlyState = System.Drawing.SystemColors.ControlText;
            this.cShareNumber._MaximumValue = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            0});
            this.cShareNumber._MaxLength = 30;
            this.cShareNumber._PasswordChar = '\0';
            this.cShareNumber._ReadOnly = false;
            this.cShareNumber._SelectionLength = 0;
            this.cShareNumber._SelectionStart = 1;
            this.cShareNumber._Text = "0";
            this.cShareNumber._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cShareNumber._UseThoundsandSeparate = true;
            this.cShareNumber._Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cShareNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cShareNumber.BackColor = System.Drawing.Color.White;
            this.cShareNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cShareNumber.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cShareNumber.Location = new System.Drawing.Point(361, 192);
            this.cShareNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cShareNumber.Name = "cShareNumber";
            this.cShareNumber.Size = new System.Drawing.Size(164, 22);
            this.cShareNumber.TabIndex = 4;
            this.cShareNumber._ValueChanged += new System.EventHandler(this.cShareNumber__ValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(530, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "หุ้น";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "ประเภท";
            // 
            // cShareType
            // 
            this.cShareType._DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cShareType._DroppedDown = false;
            this.cShareType._ReadOnly = false;
            this.cShareType._SelectedItem = null;
            this.cShareType._Text = "";
            this.cShareType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cShareType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cShareType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cShareType.Location = new System.Drawing.Point(97, 192);
            this.cShareType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cShareType.Name = "cShareType";
            this.cShareType.Size = new System.Drawing.Size(168, 22);
            this.cShareType.TabIndex = 3;
            this.cShareType._SelectedItemChanged += new System.EventHandler(this.cShareType__SelectedItemChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "มูลค่าหุ้นที่ชำระแล้ว";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 242);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "มูลค่าหุ้นที่ถือว่าชำระแล้ว";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 268);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "วันที่ออกเลขที่ใบหุ้น";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 293);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "วันที่ลงทะเบียนผู้ถือหุ้น";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 320);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "วันที่ขาดทะเบียนผู้ถือหุ้น";
            // 
            // cPaidAmount
            // 
            this.cPaidAmount._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cPaidAmount._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cPaidAmount._DecimalDigit = 2;
            this.cPaidAmount._ForeColor = System.Drawing.SystemColors.WindowText;
            this.cPaidAmount._ForeColorReadOnlyState = System.Drawing.SystemColors.ControlText;
            this.cPaidAmount._MaximumValue = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            262144});
            this.cPaidAmount._MaxLength = 30;
            this.cPaidAmount._PasswordChar = '\0';
            this.cPaidAmount._ReadOnly = false;
            this.cPaidAmount._SelectionLength = 0;
            this.cPaidAmount._SelectionStart = 4;
            this.cPaidAmount._Text = "0.00";
            this.cPaidAmount._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cPaidAmount._UseThoundsandSeparate = true;
            this.cPaidAmount._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.cPaidAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cPaidAmount.BackColor = System.Drawing.Color.White;
            this.cPaidAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cPaidAmount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cPaidAmount.Location = new System.Drawing.Point(176, 217);
            this.cPaidAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cPaidAmount.Name = "cPaidAmount";
            this.cPaidAmount.Size = new System.Drawing.Size(208, 22);
            this.cPaidAmount.TabIndex = 5;
            this.cPaidAmount._ValueChanged += new System.EventHandler(this.cPaidAmount__ValueChanged);
            // 
            // cAsPaidAmount
            // 
            this.cAsPaidAmount._BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cAsPaidAmount._CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cAsPaidAmount._DecimalDigit = 2;
            this.cAsPaidAmount._ForeColor = System.Drawing.SystemColors.WindowText;
            this.cAsPaidAmount._ForeColorReadOnlyState = System.Drawing.SystemColors.ControlText;
            this.cAsPaidAmount._MaximumValue = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            262144});
            this.cAsPaidAmount._MaxLength = 30;
            this.cAsPaidAmount._PasswordChar = '\0';
            this.cAsPaidAmount._ReadOnly = false;
            this.cAsPaidAmount._SelectionLength = 0;
            this.cAsPaidAmount._SelectionStart = 4;
            this.cAsPaidAmount._Text = "0.00";
            this.cAsPaidAmount._TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cAsPaidAmount._UseThoundsandSeparate = true;
            this.cAsPaidAmount._Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.cAsPaidAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cAsPaidAmount.BackColor = System.Drawing.Color.White;
            this.cAsPaidAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cAsPaidAmount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cAsPaidAmount.Location = new System.Drawing.Point(176, 242);
            this.cAsPaidAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cAsPaidAmount.Name = "cAsPaidAmount";
            this.cAsPaidAmount.Size = new System.Drawing.Size(208, 22);
            this.cAsPaidAmount.TabIndex = 6;
            this.cAsPaidAmount._ValueChanged += new System.EventHandler(this.cAsPaidAmount__ValueChanged);
            // 
            // cShareDocDate
            // 
            this.cShareDocDate._ReadOnly = false;
            this.cShareDocDate._SelectedDate = null;
            this.cShareDocDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cShareDocDate.BackColor = System.Drawing.Color.White;
            this.cShareDocDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cShareDocDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cShareDocDate.Location = new System.Drawing.Point(176, 267);
            this.cShareDocDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cShareDocDate.Name = "cShareDocDate";
            this.cShareDocDate.Size = new System.Drawing.Size(103, 23);
            this.cShareDocDate.TabIndex = 7;
            this.cShareDocDate._SelectedDateChanged += new System.EventHandler(this.cShareDocDate__SelectedDateChanged);
            // 
            // cShareRegExist
            // 
            this.cShareRegExist._ReadOnly = false;
            this.cShareRegExist._SelectedDate = null;
            this.cShareRegExist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cShareRegExist.BackColor = System.Drawing.Color.White;
            this.cShareRegExist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cShareRegExist.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cShareRegExist.Location = new System.Drawing.Point(176, 293);
            this.cShareRegExist.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cShareRegExist.Name = "cShareRegExist";
            this.cShareRegExist.Size = new System.Drawing.Size(103, 23);
            this.cShareRegExist.TabIndex = 8;
            this.cShareRegExist._SelectedDateChanged += new System.EventHandler(this.cShareRegExist__SelectedDateChanged);
            // 
            // cShareRegOmit
            // 
            this.cShareRegOmit._ReadOnly = false;
            this.cShareRegOmit._SelectedDate = null;
            this.cShareRegOmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cShareRegOmit.BackColor = System.Drawing.Color.White;
            this.cShareRegOmit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cShareRegOmit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cShareRegOmit.Location = new System.Drawing.Point(176, 319);
            this.cShareRegOmit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cShareRegOmit.Name = "cShareRegOmit";
            this.cShareRegOmit.Size = new System.Drawing.Size(103, 23);
            this.cShareRegOmit.TabIndex = 9;
            this.cShareRegOmit._SelectedDateChanged += new System.EventHandler(this.cShareRegOmit__SelectedDateChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "ผู้ถือหุ้น";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Location = new System.Drawing.Point(309, 353);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(106, 30);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "บันทึก <F9>";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(421, 353);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 30);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "ยกเลิก <Esc>";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // dgvPerson
            // 
            this.dgvPerson.AllowSortByColumnHeaderClicked = false;
            this.dgvPerson.AllowUserToAddRows = false;
            this.dgvPerson.AllowUserToDeleteRows = false;
            this.dgvPerson.AllowUserToResizeColumns = false;
            this.dgvPerson.AllowUserToResizeRows = false;
            this.dgvPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(207)))), ((int)(((byte)(179)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPerson.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPerson.ColumnHeadersHeight = 28;
            this.dgvPerson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPerson.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_boj5_person,
            this.col_selected,
            this.col_itemSeq,
            this.col_holderName,
            this.col_nationality,
            this.col_addrFull});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPerson.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPerson.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPerson.EnableHeadersVisualStyles = false;
            this.dgvPerson.FillEmptyRow = false;
            this.dgvPerson.FocusedRowBorderRedLine = true;
            this.dgvPerson.Location = new System.Drawing.Point(97, 42);
            this.dgvPerson.MultiSelect = false;
            this.dgvPerson.Name = "dgvPerson";
            this.dgvPerson.ReadOnly = true;
            this.dgvPerson.RowHeadersVisible = false;
            this.dgvPerson.RowTemplate.Height = 26;
            this.dgvPerson.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPerson.Size = new System.Drawing.Size(643, 142);
            this.dgvPerson.StandardTab = true;
            this.dgvPerson.TabIndex = 12;
            this.dgvPerson.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPerson_CellMouseClick);
            this.dgvPerson.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvPerson_CellPainting);
            this.dgvPerson.CurrentCellChanged += new System.EventHandler(this.dgvPerson_CurrentCellChanged);
            // 
            // col_boj5_person
            // 
            this.col_boj5_person.DataPropertyName = "boj5_person";
            this.col_boj5_person.HeaderText = "Boj5Person";
            this.col_boj5_person.Name = "col_boj5_person";
            this.col_boj5_person.ReadOnly = true;
            this.col_boj5_person.Visible = false;
            // 
            // col_selected
            // 
            this.col_selected.DataPropertyName = "selected";
            this.col_selected.HeaderText = "เลือก";
            this.col_selected.MinimumWidth = 40;
            this.col_selected.Name = "col_selected";
            this.col_selected.ReadOnly = true;
            this.col_selected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_selected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_selected.Width = 40;
            // 
            // col_itemSeq
            // 
            this.col_itemSeq.DataPropertyName = "itemSeq";
            this.col_itemSeq.HeaderText = "ลำดับ";
            this.col_itemSeq.MinimumWidth = 45;
            this.col_itemSeq.Name = "col_itemSeq";
            this.col_itemSeq.ReadOnly = true;
            this.col_itemSeq.Width = 45;
            // 
            // col_holderName
            // 
            this.col_holderName.DataPropertyName = "holderName";
            this.col_holderName.HeaderText = "ชื่อ";
            this.col_holderName.MinimumWidth = 220;
            this.col_holderName.Name = "col_holderName";
            this.col_holderName.ReadOnly = true;
            this.col_holderName.Width = 220;
            // 
            // col_nationality
            // 
            this.col_nationality.DataPropertyName = "nationality";
            this.col_nationality.HeaderText = "สัญชาติ";
            this.col_nationality.MinimumWidth = 120;
            this.col_nationality.Name = "col_nationality";
            this.col_nationality.ReadOnly = true;
            this.col_nationality.Width = 120;
            // 
            // col_addrFull
            // 
            this.col_addrFull.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_addrFull.DataPropertyName = "addrFull";
            this.col_addrFull.HeaderText = "ที่อยู่";
            this.col_addrFull.MinimumWidth = 200;
            this.col_addrFull.Name = "col_addrFull";
            this.col_addrFull.ReadOnly = true;
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.Image = global::Express_e_Filing.Properties.Resources.arrow_go_down;
            this.btnDown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDown.Location = new System.Drawing.Point(744, 159);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(84, 25);
            this.btnDown.TabIndex = 13;
            this.btnDown.Text = "  เลื่อนลง";
            this.btnDown.UseVisualStyleBackColor = true;
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.Image = global::Express_e_Filing.Properties.Resources.arrow_go_up;
            this.btnUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUp.Location = new System.Drawing.Point(744, 131);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(84, 25);
            this.btnUp.TabIndex = 13;
            this.btnUp.Text = "  เลื่อนขึ้น";
            this.btnUp.UseVisualStyleBackColor = true;
            // 
            // btnDeleteHolder
            // 
            this.btnDeleteHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteHolder.Image = global::Express_e_Filing.Properties.Resources.cancel_121;
            this.btnDeleteHolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteHolder.Location = new System.Drawing.Point(744, 95);
            this.btnDeleteHolder.Name = "btnDeleteHolder";
            this.btnDeleteHolder.Size = new System.Drawing.Size(84, 25);
            this.btnDeleteHolder.TabIndex = 9;
            this.btnDeleteHolder.TabStop = false;
            this.btnDeleteHolder.Text = "  ลบ";
            this.btnDeleteHolder.UseVisualStyleBackColor = true;
            this.btnDeleteHolder.Click += new System.EventHandler(this.btnDeleteHolder_Click);
            // 
            // btnEditHolder
            // 
            this.btnEditHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditHolder.Image = global::Express_e_Filing.Properties.Resources.edit_16;
            this.btnEditHolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditHolder.Location = new System.Drawing.Point(744, 67);
            this.btnEditHolder.Name = "btnEditHolder";
            this.btnEditHolder.Size = new System.Drawing.Size(84, 25);
            this.btnEditHolder.TabIndex = 9;
            this.btnEditHolder.TabStop = false;
            this.btnEditHolder.Text = "  แก้ไข";
            this.btnEditHolder.UseVisualStyleBackColor = true;
            this.btnEditHolder.Click += new System.EventHandler(this.btnEditHolder_Click);
            // 
            // btnAddHolder
            // 
            this.btnAddHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddHolder.Image = global::Express_e_Filing.Properties.Resources.add_16;
            this.btnAddHolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddHolder.Location = new System.Drawing.Point(744, 39);
            this.btnAddHolder.Name = "btnAddHolder";
            this.btnAddHolder.Size = new System.Drawing.Size(84, 25);
            this.btnAddHolder.TabIndex = 9;
            this.btnAddHolder.TabStop = false;
            this.btnAddHolder.Text = "  เพิ่ม";
            this.btnAddHolder.UseVisualStyleBackColor = true;
            this.btnAddHolder.Click += new System.EventHandler(this.btnAddHolder_Click);
            // 
            // DialogBojDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 401);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.dgvPerson);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnDeleteHolder);
            this.Controls.Add(this.btnEditHolder);
            this.Controls.Add(this.btnAddHolder);
            this.Controls.Add(this.cShareRegOmit);
            this.Controls.Add(this.cShareRegExist);
            this.Controls.Add(this.cShareDocDate);
            this.Controls.Add(this.cAsPaidAmount);
            this.Controls.Add(this.cPaidAmount);
            this.Controls.Add(this.cShareType);
            this.Controls.Add(this.cShareNumber);
            this.Controls.Add(this.cShareDocId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(850, 440);
            this.Name = "DialogBojDetail";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "รายละเอียดใบหุ้น";
            this.Load += new System.EventHandler(this.DialogBojDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerson)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private CC.XTextEdit cShareDocId;
        private System.Windows.Forms.Label label3;
        private CC.XNumEdit cShareNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private CC.XDropdownList cShareType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private CC.XNumEdit cPaidAmount;
        private CC.XNumEdit cAsPaidAmount;
        private CC.XDatePicker cShareDocDate;
        private CC.XDatePicker cShareRegExist;
        private CC.XDatePicker cShareRegOmit;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnAddHolder;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private CC.XDatagrid dgvPerson;
        private System.Windows.Forms.Button btnEditHolder;
        private System.Windows.Forms.Button btnDeleteHolder;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_boj5_person;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_itemSeq;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_holderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_nationality;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_addrFull;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
    }
}