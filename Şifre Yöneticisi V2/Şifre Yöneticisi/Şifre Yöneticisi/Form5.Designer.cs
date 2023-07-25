namespace Şifre_Yöneticisi
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.comboBoxNumbers = new Guna.UI2.WinForms.Guna2ComboBox();
            this.listBoxPasswords = new System.Windows.Forms.ListBox();
            this.buttonGeneratePassword = new Guna.UI2.WinForms.Guna2Button();
            this.buttonCopyPassword = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // comboBoxNumbers
            // 
            this.comboBoxNumbers.BackColor = System.Drawing.Color.Transparent;
            this.comboBoxNumbers.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.comboBoxNumbers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxNumbers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNumbers.FillColor = System.Drawing.Color.PaleVioletRed;
            this.comboBoxNumbers.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxNumbers.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxNumbers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxNumbers.ForeColor = System.Drawing.Color.Black;
            this.comboBoxNumbers.ItemHeight = 30;
            this.comboBoxNumbers.Location = new System.Drawing.Point(18, 190);
            this.comboBoxNumbers.Name = "comboBoxNumbers";
            this.comboBoxNumbers.Size = new System.Drawing.Size(321, 36);
            this.comboBoxNumbers.TabIndex = 0;
            // 
            // listBoxPasswords
            // 
            this.listBoxPasswords.BackColor = System.Drawing.Color.PaleVioletRed;
            this.listBoxPasswords.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBoxPasswords.FormattingEnabled = true;
            this.listBoxPasswords.ItemHeight = 16;
            this.listBoxPasswords.Location = new System.Drawing.Point(0, 0);
            this.listBoxPasswords.Name = "listBoxPasswords";
            this.listBoxPasswords.Size = new System.Drawing.Size(586, 148);
            this.listBoxPasswords.TabIndex = 1;
            // 
            // buttonGeneratePassword
            // 
            this.buttonGeneratePassword.Animated = true;
            this.buttonGeneratePassword.BorderColor = System.Drawing.Color.HotPink;
            this.buttonGeneratePassword.BorderRadius = 15;
            this.buttonGeneratePassword.BorderThickness = 3;
            this.buttonGeneratePassword.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonGeneratePassword.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonGeneratePassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonGeneratePassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonGeneratePassword.FillColor = System.Drawing.Color.PaleVioletRed;
            this.buttonGeneratePassword.Font = new System.Drawing.Font("LEMON MILK Bold", 9F, System.Drawing.FontStyle.Bold);
            this.buttonGeneratePassword.ForeColor = System.Drawing.Color.White;
            this.buttonGeneratePassword.Location = new System.Drawing.Point(362, 181);
            this.buttonGeneratePassword.Name = "buttonGeneratePassword";
            this.buttonGeneratePassword.Size = new System.Drawing.Size(212, 45);
            this.buttonGeneratePassword.TabIndex = 2;
            this.buttonGeneratePassword.Text = "Oluştur";
            this.buttonGeneratePassword.Click += new System.EventHandler(this.buttonGeneratePassword_Click);
            // 
            // buttonCopyPassword
            // 
            this.buttonCopyPassword.Animated = true;
            this.buttonCopyPassword.BorderColor = System.Drawing.Color.HotPink;
            this.buttonCopyPassword.BorderRadius = 15;
            this.buttonCopyPassword.BorderThickness = 3;
            this.buttonCopyPassword.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonCopyPassword.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonCopyPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonCopyPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonCopyPassword.FillColor = System.Drawing.Color.PaleVioletRed;
            this.buttonCopyPassword.Font = new System.Drawing.Font("LEMON MILK Bold", 9F, System.Drawing.FontStyle.Bold);
            this.buttonCopyPassword.ForeColor = System.Drawing.Color.White;
            this.buttonCopyPassword.Location = new System.Drawing.Point(362, 232);
            this.buttonCopyPassword.Name = "buttonCopyPassword";
            this.buttonCopyPassword.Size = new System.Drawing.Size(212, 45);
            this.buttonCopyPassword.TabIndex = 3;
            this.buttonCopyPassword.Text = "Kopyala";
            this.buttonCopyPassword.Click += new System.EventHandler(this.buttonCopyPassword_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("LEMON MILK Bold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 36);
            this.label1.TabIndex = 4;
            this.label1.Text = "Şifre Basamak Sayısı";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("LEMON MILK Bold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.linkLabel1.LinkColor = System.Drawing.Color.PaleVioletRed;
            this.linkLabel1.Location = new System.Drawing.Point(458, 397);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(116, 24);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "SabanGnc";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // guna2Button1
            // 
            this.guna2Button1.Animated = true;
            this.guna2Button1.BorderColor = System.Drawing.Color.HotPink;
            this.guna2Button1.BorderRadius = 15;
            this.guna2Button1.BorderThickness = 3;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.PaleVioletRed;
            this.guna2Button1.Font = new System.Drawing.Font("LEMON MILK Bold", 9F, System.Drawing.FontStyle.Bold);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(362, 283);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(212, 45);
            this.guna2Button1.TabIndex = 6;
            this.guna2Button1.Text = "SİL";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // guna2Button2
            // 
            this.guna2Button2.Animated = true;
            this.guna2Button2.BorderColor = System.Drawing.Color.HotPink;
            this.guna2Button2.BorderRadius = 15;
            this.guna2Button2.BorderThickness = 3;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.PaleVioletRed;
            this.guna2Button2.Font = new System.Drawing.Font("LEMON MILK Bold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Location = new System.Drawing.Point(362, 334);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(212, 45);
            this.guna2Button2.TabIndex = 7;
            this.guna2Button2.Text = "Tümünü Sil";
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightPink;
            this.ClientSize = new System.Drawing.Size(586, 430);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCopyPassword);
            this.Controls.Add(this.buttonGeneratePassword);
            this.Controls.Add(this.listBoxPasswords);
            this.Controls.Add(this.comboBoxNumbers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form5";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Şifre Oluşturucu";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox comboBoxNumbers;
        private System.Windows.Forms.ListBox listBoxPasswords;
        private Guna.UI2.WinForms.Guna2Button buttonGeneratePassword;
        private Guna.UI2.WinForms.Guna2Button buttonCopyPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
    }
}