using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Express_e_Filing.SubForm
{
    public partial class DialogInlineSearch : Form
    {
        public string keyword = string.Empty;

        public DialogInlineSearch()
        {
            InitializeComponent();
        }

        public DialogInlineSearch(string keyword)
            : this()
        {
            this.keyword = keyword;
        }

        private void DialogInlineSearch_Load(object sender, EventArgs e)
        {
            
        }

        private void DialogInlineSearch_Shown(object sender, EventArgs e)
        {
            this.textBox1.Text = this.keyword;
            this.textBox1.SelectionStart = this.keyword.Length;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.keyword = ((TextBox)sender).Text;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter)
            {
                this.btnOK.PerformClick();
                return true;
            }

            if(keyData == Keys.Escape)
            {
                this.btnCancel.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
