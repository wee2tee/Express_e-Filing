namespace Express_e_Filing
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnOpenFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRegist = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAsset = new System.Windows.Forms.TabPage();
            this.dgv1 = new CC.XDatagrid();
            this.tabLiability = new System.Windows.Forms.TabPage();
            this.dgv2 = new CC.XDatagrid();
            this.tabEquity = new System.Windows.Forms.TabPage();
            this.dgv3 = new CC.XDatagrid();
            this.tabRevenue = new System.Windows.Forms.TabPage();
            this.dgv4 = new CC.XDatagrid();
            this.tabExpense = new System.Windows.Forms.TabPage();
            this.dgv5 = new CC.XDatagrid();
            this.label1 = new System.Windows.Forms.Label();
            this.cCompName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cDataPath = new System.Windows.Forms.Label();
            this.cLangTh = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cLangEn = new System.Windows.Forms.RadioButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblProgramPath = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabAsset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.tabLiability.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.tabEquity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv3)).BeginInit();
            this.tabRevenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv4)).BeginInit();
            this.tabExpense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv5)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpenFolder,
            this.toolStripSeparator1,
            this.btnEdit,
            this.btnSave,
            this.btnStop,
            this.toolStripSeparator2,
            this.btnRegist});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(927, 43);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpenFolder.Image = global::Express_e_Filing.Properties.Resources.icon_folder;
            this.btnOpenFolder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnOpenFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(36, 40);
            this.btnOpenFolder.Text = "toolStripButton1";
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // btnEdit
            // 
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEdit.Image = global::Express_e_Filing.Properties.Resources.edit;
            this.btnEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(36, 40);
            this.btnEdit.Text = "toolStripButton4";
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::Express_e_Filing.Properties.Resources.save;
            this.btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(36, 40);
            this.btnSave.Text = "toolStripButton2";
            // 
            // btnStop
            // 
            this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStop.Image = global::Express_e_Filing.Properties.Resources.stop;
            this.btnStop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(36, 40);
            this.btnStop.Text = "toolStripButton3";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 43);
            // 
            // btnRegist
            // 
            this.btnRegist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRegist.Image = global::Express_e_Filing.Properties.Resources.key_register;
            this.btnRegist.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRegist.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRegist.Name = "btnRegist";
            this.btnRegist.Size = new System.Drawing.Size(36, 40);
            this.btnRegist.Text = "toolStripButton5";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabAsset);
            this.tabControl1.Controls.Add(this.tabLiability);
            this.tabControl1.Controls.Add(this.tabEquity);
            this.tabControl1.Controls.Add(this.tabRevenue);
            this.tabControl1.Controls.Add(this.tabExpense);
            this.tabControl1.Location = new System.Drawing.Point(6, 132);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(915, 437);
            this.tabControl1.TabIndex = 1;
            // 
            // tabAsset
            // 
            this.tabAsset.Controls.Add(this.dgv1);
            this.tabAsset.Location = new System.Drawing.Point(4, 25);
            this.tabAsset.Name = "tabAsset";
            this.tabAsset.Size = new System.Drawing.Size(907, 408);
            this.tabAsset.TabIndex = 0;
            this.tabAsset.Text = "สินทรัพย์";
            this.tabAsset.UseVisualStyleBackColor = true;
            // 
            // dgv1
            // 
            this.dgv1.AllowSortByColumnHeaderClicked = false;
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AllowUserToResizeColumns = false;
            this.dgv1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(207)))), ((int)(((byte)(179)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv1.EnableHeadersVisualStyles = false;
            this.dgv1.FillEmptyRow = false;
            this.dgv1.FocusedRowBorderRedLine = false;
            this.dgv1.Location = new System.Drawing.Point(0, 0);
            this.dgv1.MultiSelect = false;
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.RowTemplate.Height = 26;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(907, 408);
            this.dgv1.StandardTab = true;
            this.dgv1.TabIndex = 0;
            // 
            // tabLiability
            // 
            this.tabLiability.Controls.Add(this.dgv2);
            this.tabLiability.Location = new System.Drawing.Point(4, 25);
            this.tabLiability.Name = "tabLiability";
            this.tabLiability.Size = new System.Drawing.Size(865, 386);
            this.tabLiability.TabIndex = 1;
            this.tabLiability.Text = "หนี้สิน";
            this.tabLiability.UseVisualStyleBackColor = true;
            // 
            // dgv2
            // 
            this.dgv2.AllowSortByColumnHeaderClicked = false;
            this.dgv2.AllowUserToAddRows = false;
            this.dgv2.AllowUserToDeleteRows = false;
            this.dgv2.AllowUserToResizeColumns = false;
            this.dgv2.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(207)))), ((int)(((byte)(179)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv2.EnableHeadersVisualStyles = false;
            this.dgv2.FillEmptyRow = false;
            this.dgv2.FocusedRowBorderRedLine = false;
            this.dgv2.Location = new System.Drawing.Point(0, 0);
            this.dgv2.MultiSelect = false;
            this.dgv2.Name = "dgv2";
            this.dgv2.ReadOnly = true;
            this.dgv2.RowHeadersVisible = false;
            this.dgv2.RowTemplate.Height = 26;
            this.dgv2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv2.Size = new System.Drawing.Size(865, 386);
            this.dgv2.StandardTab = true;
            this.dgv2.TabIndex = 1;
            // 
            // tabEquity
            // 
            this.tabEquity.Controls.Add(this.dgv3);
            this.tabEquity.Location = new System.Drawing.Point(4, 25);
            this.tabEquity.Name = "tabEquity";
            this.tabEquity.Size = new System.Drawing.Size(865, 386);
            this.tabEquity.TabIndex = 2;
            this.tabEquity.Text = "ทุน";
            this.tabEquity.UseVisualStyleBackColor = true;
            // 
            // dgv3
            // 
            this.dgv3.AllowSortByColumnHeaderClicked = false;
            this.dgv3.AllowUserToAddRows = false;
            this.dgv3.AllowUserToDeleteRows = false;
            this.dgv3.AllowUserToResizeColumns = false;
            this.dgv3.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(207)))), ((int)(((byte)(179)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv3.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv3.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv3.EnableHeadersVisualStyles = false;
            this.dgv3.FillEmptyRow = false;
            this.dgv3.FocusedRowBorderRedLine = false;
            this.dgv3.Location = new System.Drawing.Point(0, 0);
            this.dgv3.MultiSelect = false;
            this.dgv3.Name = "dgv3";
            this.dgv3.ReadOnly = true;
            this.dgv3.RowHeadersVisible = false;
            this.dgv3.RowTemplate.Height = 26;
            this.dgv3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv3.Size = new System.Drawing.Size(865, 386);
            this.dgv3.StandardTab = true;
            this.dgv3.TabIndex = 1;
            // 
            // tabRevenue
            // 
            this.tabRevenue.Controls.Add(this.dgv4);
            this.tabRevenue.Location = new System.Drawing.Point(4, 25);
            this.tabRevenue.Name = "tabRevenue";
            this.tabRevenue.Size = new System.Drawing.Size(865, 386);
            this.tabRevenue.TabIndex = 3;
            this.tabRevenue.Text = "รายได้";
            this.tabRevenue.UseVisualStyleBackColor = true;
            // 
            // dgv4
            // 
            this.dgv4.AllowSortByColumnHeaderClicked = false;
            this.dgv4.AllowUserToAddRows = false;
            this.dgv4.AllowUserToDeleteRows = false;
            this.dgv4.AllowUserToResizeColumns = false;
            this.dgv4.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(207)))), ((int)(((byte)(179)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv4.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv4.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgv4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv4.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv4.EnableHeadersVisualStyles = false;
            this.dgv4.FillEmptyRow = false;
            this.dgv4.FocusedRowBorderRedLine = false;
            this.dgv4.Location = new System.Drawing.Point(0, 0);
            this.dgv4.MultiSelect = false;
            this.dgv4.Name = "dgv4";
            this.dgv4.ReadOnly = true;
            this.dgv4.RowHeadersVisible = false;
            this.dgv4.RowTemplate.Height = 26;
            this.dgv4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv4.Size = new System.Drawing.Size(865, 386);
            this.dgv4.StandardTab = true;
            this.dgv4.TabIndex = 1;
            // 
            // tabExpense
            // 
            this.tabExpense.Controls.Add(this.dgv5);
            this.tabExpense.Location = new System.Drawing.Point(4, 25);
            this.tabExpense.Name = "tabExpense";
            this.tabExpense.Size = new System.Drawing.Size(865, 386);
            this.tabExpense.TabIndex = 4;
            this.tabExpense.Text = "ค่าใช้จ่าย";
            this.tabExpense.UseVisualStyleBackColor = true;
            // 
            // dgv5
            // 
            this.dgv5.AllowSortByColumnHeaderClicked = false;
            this.dgv5.AllowUserToAddRows = false;
            this.dgv5.AllowUserToDeleteRows = false;
            this.dgv5.AllowUserToResizeColumns = false;
            this.dgv5.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(207)))), ((int)(((byte)(179)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv5.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgv5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv5.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgv5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv5.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv5.EnableHeadersVisualStyles = false;
            this.dgv5.FillEmptyRow = false;
            this.dgv5.FocusedRowBorderRedLine = false;
            this.dgv5.Location = new System.Drawing.Point(0, 0);
            this.dgv5.MultiSelect = false;
            this.dgv5.Name = "dgv5";
            this.dgv5.ReadOnly = true;
            this.dgv5.RowHeadersVisible = false;
            this.dgv5.RowTemplate.Height = 26;
            this.dgv5.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv5.Size = new System.Drawing.Size(865, 386);
            this.dgv5.StandardTab = true;
            this.dgv5.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "ชื่อข้อมูล";
            // 
            // cCompName
            // 
            this.cCompName.BackColor = System.Drawing.Color.White;
            this.cCompName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cCompName.Location = new System.Drawing.Point(116, 57);
            this.cCompName.Name = "cCompName";
            this.cCompName.Size = new System.Drawing.Size(582, 21);
            this.cCompName.TabIndex = 3;
            this.cCompName.Text = "_data code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "ที่เก็บข้อมูล";
            // 
            // cDataPath
            // 
            this.cDataPath.BackColor = System.Drawing.Color.White;
            this.cDataPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cDataPath.Location = new System.Drawing.Point(116, 82);
            this.cDataPath.Name = "cDataPath";
            this.cDataPath.Size = new System.Drawing.Size(582, 21);
            this.cDataPath.TabIndex = 3;
            this.cDataPath.Text = "_data code";
            // 
            // cLangTh
            // 
            this.cLangTh.AutoSize = true;
            this.cLangTh.Location = new System.Drawing.Point(10, 19);
            this.cLangTh.Name = "cLangTh";
            this.cLangTh.Size = new System.Drawing.Size(50, 20);
            this.cLangTh.TabIndex = 4;
            this.cLangTh.TabStop = true;
            this.cLangTh.Text = "ไทย";
            this.cLangTh.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cLangEn);
            this.groupBox1.Controls.Add(this.cLangTh);
            this.groupBox1.Location = new System.Drawing.Point(763, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 45);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "แสดงชื่อบัญชีเป็นภาษา";
            // 
            // cLangEn
            // 
            this.cLangEn.AutoSize = true;
            this.cLangEn.Location = new System.Drawing.Point(84, 19);
            this.cLangEn.Name = "cLangEn";
            this.cLangEn.Size = new System.Drawing.Size(51, 20);
            this.cLangEn.TabIndex = 4;
            this.cLangEn.TabStop = true;
            this.cLangEn.Text = "Eng.";
            this.cLangEn.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblProgramPath});
            this.statusStrip1.Location = new System.Drawing.Point(0, 575);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(927, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblProgramPath
            // 
            this.lblProgramPath.Name = "lblProgramPath";
            this.lblProgramPath.Size = new System.Drawing.Size(37, 17);
            this.lblProgramPath.Text = "          ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(80, 17);
            this.toolStripStatusLabel1.Text = "ที่เก็บโปรแกรม : ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 597);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cDataPath);
            this.Controls.Add(this.cCompName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabAsset.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.tabLiability.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.tabEquity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv3)).EndInit();
            this.tabRevenue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv4)).EndInit();
            this.tabExpense.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv5)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnOpenFolder;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnRegist;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAsset;
        private System.Windows.Forms.TabPage tabLiability;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label cCompName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label cDataPath;
        private System.Windows.Forms.RadioButton cLangTh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton cLangEn;
        private System.Windows.Forms.TabPage tabEquity;
        private System.Windows.Forms.TabPage tabRevenue;
        private System.Windows.Forms.TabPage tabExpense;
        private CC.XDatagrid dgv1;
        private CC.XDatagrid dgv2;
        private CC.XDatagrid dgv3;
        private CC.XDatagrid dgv4;
        private CC.XDatagrid dgv5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblProgramPath;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

