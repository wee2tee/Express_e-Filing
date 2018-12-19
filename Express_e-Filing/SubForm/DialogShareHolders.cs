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
        private FORM_MODE form_mode;
            
        public DialogShareHolders(MainForm main_form)
        {
            this.main_form = main_form;
            InitializeComponent();
        }
    }
}
