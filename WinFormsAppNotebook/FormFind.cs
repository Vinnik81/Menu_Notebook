using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsAppNotebook
{
    public partial class FormFind : Form
    {
        public bool IsFindNext { get; set; }
       
        public FormFind()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonFindNext_Click(object sender, EventArgs e)
        {
            IsFindNext = true;
            this.DialogResult = DialogResult.OK;
        }

        private void textBoxFind_TextChanged(object sender, EventArgs e)
        {
            var find = textBoxFind.Text;
        }

    }
}
