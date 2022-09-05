
namespace WinFormsAppNotebook
{
    partial class FormReplacement
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCancelR = new System.Windows.Forms.Button();
            this.buttonReplace = new System.Windows.Forms.Button();
            this.textBoxThan = new System.Windows.Forms.TextBox();
            this.textBoxWhatR = new System.Windows.Forms.TextBox();
            this.labelThan = new System.Windows.Forms.Label();
            this.labelWhatR = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonCancelR);
            this.panel1.Controls.Add(this.buttonReplace);
            this.panel1.Controls.Add(this.textBoxThan);
            this.panel1.Controls.Add(this.textBoxWhatR);
            this.panel1.Controls.Add(this.labelThan);
            this.panel1.Controls.Add(this.labelWhatR);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(672, 137);
            this.panel1.TabIndex = 0;
            // 
            // buttonCancelR
            // 
            this.buttonCancelR.Location = new System.Drawing.Point(568, 67);
            this.buttonCancelR.Name = "buttonCancelR";
            this.buttonCancelR.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelR.TabIndex = 5;
            this.buttonCancelR.Text = "Cancel";
            this.buttonCancelR.UseVisualStyleBackColor = true;
            this.buttonCancelR.Click += new System.EventHandler(this.buttonCancelR_Click);
            // 
            // buttonReplace
            // 
            this.buttonReplace.Location = new System.Drawing.Point(568, 26);
            this.buttonReplace.Name = "buttonReplace";
            this.buttonReplace.Size = new System.Drawing.Size(75, 23);
            this.buttonReplace.TabIndex = 4;
            this.buttonReplace.Text = "Replace:";
            this.buttonReplace.UseVisualStyleBackColor = true;
            this.buttonReplace.Click += new System.EventHandler(this.buttonReplace_Click);
            // 
            // textBoxThan
            // 
            this.textBoxThan.Location = new System.Drawing.Point(103, 68);
            this.textBoxThan.Name = "textBoxThan";
            this.textBoxThan.Size = new System.Drawing.Size(380, 23);
            this.textBoxThan.TabIndex = 3;
            // 
            // textBoxWhatR
            // 
            this.textBoxWhatR.Location = new System.Drawing.Point(103, 26);
            this.textBoxWhatR.Name = "textBoxWhatR";
            this.textBoxWhatR.Size = new System.Drawing.Size(380, 23);
            this.textBoxWhatR.TabIndex = 2;
            // 
            // labelThan
            // 
            this.labelThan.AutoSize = true;
            this.labelThan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelThan.Location = new System.Drawing.Point(23, 70);
            this.labelThan.Name = "labelThan";
            this.labelThan.Size = new System.Drawing.Size(47, 21);
            this.labelThan.TabIndex = 1;
            this.labelThan.Text = "Than:";
            // 
            // labelWhatR
            // 
            this.labelWhatR.AutoSize = true;
            this.labelWhatR.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelWhatR.Location = new System.Drawing.Point(23, 29);
            this.labelWhatR.Name = "labelWhatR";
            this.labelWhatR.Size = new System.Drawing.Size(50, 21);
            this.labelWhatR.TabIndex = 0;
            this.labelWhatR.Text = "What:";
            // 
            // FormReplacement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 137);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormReplacement";
            this.Text = "Replacement";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonCancelR;
        private System.Windows.Forms.Button buttonReplace;
        public System.Windows.Forms.TextBox textBoxThan;
        public System.Windows.Forms.TextBox textBoxWhatR;
        private System.Windows.Forms.Label labelThan;
        private System.Windows.Forms.Label labelWhatR;
    }
}