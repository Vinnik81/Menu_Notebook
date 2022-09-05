using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsAppNotebook
{
    public partial class Form1 : Form
    {
        public FormFind formFind = new FormFind();
        public FormReplacement formReplacement = new FormReplacement();
        public string Copy { get; set; }
        public Form1()
        {
            InitializeComponent();
            Bitmap bitmap = new Bitmap(toolStripButton2.Width, toolStripButton2.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.Black);
            toolStripButton2.Image = bitmap;

            toolStripStatusLabel1.Text = "Simbol: 0";
            toolStripStatusLabel2.Text = "Line: 0";
            toolStripStatusLabel3.Text = "Zoom: " + richTextBox1.ZoomFactor * 100;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog print = new PrintDialog();
            print.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var color = new ColorDialog();
            var result = color.ShowDialog();
            if (result == DialogResult.OK)
            {
                richTextBox1.SelectionColor = color.Color;
                Bitmap bitmap = new Bitmap(toolStripButton2.Width, toolStripButton2.Height);
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.Clear(color.Color);
                toolStripButton2.Image = bitmap;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var font = new FontDialog();
            var result = font.ShowDialog();
            if (result == DialogResult.OK)
            {
                richTextBox1.SelectionFont = font.Font;
                toolStripButton1.Text = font.Font.Name;
                toolStripButton1.Font = new Font(font.Font.FontFamily, 14, font.Font.Style);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = $"Simbol: {richTextBox1.Text.Length}";
            toolStripStatusLabel2.Text = $"Line: {richTextBox1.Text.Count(x=> x=='\n')+1}";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var save = new SaveFileDialog();
            save.Filter = "Text files (*.txt | *.txt | RTF files (*.rtf) | *.rtf";
            var result = save.ShowDialog();
            if (result == DialogResult.OK)
            {
                string text = "";
                switch (Path.GetExtension(save.FileName))
                {
                    case ".txt": text = richTextBox1.Text; break;
                    case ".rtf": text = richTextBox1.Rtf; break;
                    default:
                        break;
                }
                File.WriteAllText(save.FileName, text);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Хотите сохранить данные?", "Notebook", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                saveToolStripMenuItem_Click(sender, e);
                Form1 form1 = new Form1();
                this.Hide();
                form1.ShowDialog();
                this.Close();
            }
            else if (result == DialogResult.No)
            {
                Form1 form1 = new Form1();
                this.Hide();
                form1.ShowDialog();
                this.Close();
            }
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton1_Click(sender, e);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            Copy = richTextBox1.SelectedText;
            
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != null)
            {
                string del = richTextBox1.SelectedText;
                int i = richTextBox1.SelectionStart;
                richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.Text.IndexOf(del), del.Length);
                richTextBox1.SelectionStart = i;
            }
        }

        private void increaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float zoom = richTextBox1.ZoomFactor;
            richTextBox1.ZoomFactor = zoom * 2;
        }

        private void decreaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float zoom = richTextBox1.ZoomFactor;
            richTextBox1.ZoomFactor = zoom / 2;
        }

        private void restoreDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.ZoomFactor = 1;
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            float zoom = richTextBox1.ZoomFactor;
            if ((zoom * 2 < 64) && (zoom / 2 > 0))
            {
                if (e.KeyCode == Keys.Add && e.Control)
                {
                    richTextBox1.ZoomFactor = zoom * 2;
                }
                if (e.KeyCode == Keys.Subtract && e.Control)
                {
                    richTextBox1.ZoomFactor = zoom / 2;
                }
            }
            toolStripStatusLabel3.Text = "Zoom: " + richTextBox1.ZoomFactor * 100;
        }

        private void cutOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != null)
            {
                int i = richTextBox1.SelectionStart;
                Copy = richTextBox1.SelectedText;
                richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.Text.IndexOf(Copy), Copy.Length);
                richTextBox1.SelectionStart = i;
            }
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = richTextBox1.SelectionStart;
            richTextBox1.Text = richTextBox1.Text.Insert(i, Copy);
            richTextBox1.SelectionStart = i + Copy.Length;
        }

        
        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formFind.ShowDialog();
            int start = (richTextBox1.Text.Length > richTextBox1.SelectionStart ? richTextBox1.SelectionStart + 1 : 0);
            if (formFind.IsFindNext && formFind.DialogResult == DialogResult.OK)
            {    
                    if (formFind.textBoxFind.Text.Length > 0 && start >= 0)
                    {
                        richTextBox1.Find(formFind.textBoxFind.Text, start, RichTextBoxFinds.None);
                        richTextBox1.Focus();
                    }
                    if ((richTextBox1.Find(formFind.textBoxFind.Text, start, RichTextBoxFinds.None)) == -1)
                        MessageBox.Show($"Не удаётся найти {formFind.textBoxFind.Text}", "Warning", MessageBoxButtons.OK);
            }
            
        }

        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int start = (richTextBox1.Text.Length > richTextBox1.SelectionStart ? richTextBox1.SelectionStart + 1 : 0);
            if (formFind.textBoxFind.Text.Length > 0 && start >= 0)
            {
                richTextBox1.Find(formFind.textBoxFind.Text, start, RichTextBoxFinds.None);
                richTextBox1.Focus();
            }
            if ((richTextBox1.Find(formFind.textBoxFind.Text, start, RichTextBoxFinds.None)) == -1)
                MessageBox.Show($"Не удаётся найти {formFind.textBoxFind.Text}", "Warning", MessageBoxButtons.OK);
        }

        private void repToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formReplacement.ShowDialog();
            if (!richTextBox1.Text.Contains(formReplacement.textBoxWhatR.Text))
            {
                MessageBox.Show($"Не удаётся найти {formReplacement.textBoxWhatR.Text}", "Warning", MessageBoxButtons.OK);
                return;
            }
            richTextBox1.Text = richTextBox1.Text.Replace(formReplacement.textBoxWhatR.Text, $"{formReplacement.textBoxThan.Text}");
        }
    }
}
