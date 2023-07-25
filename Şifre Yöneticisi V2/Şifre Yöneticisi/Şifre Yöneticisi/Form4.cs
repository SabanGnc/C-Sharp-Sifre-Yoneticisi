using System;
using System.Windows.Forms;

namespace Şifre_Yöneticisi
{
    public partial class Form4 : Form
    {
        // Şifre ve kullanıcı adı
        private const string correctUsername = "Admin";
        private const string correctPassword = "SabanGnc";

        public Form4()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string enteredUsername = textBoxUsername.Text.Trim();
            string enteredPassword = textBoxPassword.Text.Trim();

            if (enteredUsername == correctUsername && enteredPassword == correctPassword)
            {
                // Doğru giriş yapıldı, Form1'i açalım ve Form4'ü gizleyelim
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
            else
            {
                // Hatalı giriş, hata mesajı gösterelim
                MessageBox.Show("Hatalı kullanıcı adı veya şifre!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Varsayılan Kullanıcı Adı: Admin", "Kullanıcı Adı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            MessageBox.Show("Varsayılan Şifre: SabanGnc", "Şifre!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            MessageBox.Show("Discord: @vespagnc", "Şaban Birkan Genç!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            MessageBox.Show("https://github.com/SabanGnc", "Şaban Birkan Genç!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
