using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace Şifre_Yöneticisi
{
    public partial class Form5 : Form
    {
        private string databasePath = "veritabani.db";

        public Form5()
        {
            InitializeComponent();

            // Veritabanı dosyasını kontrol et ve oluştur
            if (!File.Exists(databasePath))
            {
                CreateDatabase();
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                comboBoxNumbers.Items.Add(i);
            }
            comboBoxNumbers.SelectedIndex = 0; // Varsayılan olarak 1'i seçelim
        }

        private void buttonGeneratePassword_Click(object sender, EventArgs e)
        {
            try
            {
                int passwordLength = (int)comboBoxNumbers.SelectedItem;

                string upperCaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                string lowerCaseLetters = "abcdefghijklmnopqrstuvwxyz";
                string specialCharacters = "!@#$%&*";

                string allCharacters = upperCaseLetters + lowerCaseLetters + specialCharacters;

                Random random = new Random();
                StringBuilder password = new StringBuilder();

                for (int i = 0; i < passwordLength; i++)
                {
                    int randomIndex = random.Next(0, allCharacters.Length);
                    password.Append(allCharacters[randomIndex]);
                }

                string generatedPassword = password.ToString();
                listBoxPasswords.Items.Add(generatedPassword);

                // Şifreyi veritabanına kaydet
                SavePasswordToDatabase(generatedPassword);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCopyPassword_Click(object sender, EventArgs e)
        {
            if (listBoxPasswords.SelectedItem != null)
            {
                Clipboard.SetText(listBoxPasswords.SelectedItem.ToString());
                MessageBox.Show("Şifre kopyalandı.");
            }
            else
            {
                MessageBox.Show("Lütfen bir şifre seçin.");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Discord: @vespagnc", "Şaban Birkan Genç !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            MessageBox.Show("https://github.com/SabanGnc", "Şaban Birkan Genç !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (listBoxPasswords.SelectedItem != null)
            {
                listBoxPasswords.Items.Remove(listBoxPasswords.SelectedItem);
            }
            else
            {
                MessageBox.Show("Lütfen silinecek şifreyi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            listBoxPasswords.Items.Clear();
        }

        private void SavePasswordToDatabase(string password)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + databasePath))
                {
                    connection.Open();

                    string createTableQuery = "CREATE TABLE IF NOT EXISTS PasswordsGenerator (Password TEXT)";

                    using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    string insertQuery = "INSERT INTO PasswordsGenerator (Password) VALUES (@Password)";

                    using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Password", password);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına şifre kaydedilirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateDatabase()
        {
            try
            {
                SQLiteConnection.CreateFile(databasePath);

                using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + databasePath))
                {
                    connection.Open();

                    string createTableQuery = "CREATE TABLE IF NOT EXISTS PasswordsGenerator (Password TEXT)";

                    using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı oluşturulurken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
