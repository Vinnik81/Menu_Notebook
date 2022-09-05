using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsAppNotebook
{
    public partial class FormReplacement : Form
    {
        public bool IsReplace { get; set; }
        public FormReplacement()
        {
            InitializeComponent();
        }

        private void buttonCancelR_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonReplace_Click(object sender, EventArgs e)
        {
            IsReplace = true;
            this.DialogResult = DialogResult.OK;
        }
    }
}
