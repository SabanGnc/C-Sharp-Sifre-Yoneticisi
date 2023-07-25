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

namespace Şifre_Yöneticisi
{
    public partial class Form1 : Form
    {
        private string databasePath = "veritabani.db";

        public Form1()
        {
            InitializeComponent();
            // refresh butonu için
            this.buttonRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.buttonRefresh.Text = "Yenile";
            this.buttonRefresh.Location = new System.Drawing.Point(10, 10);
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            this.Controls.Add(this.buttonRefresh);
            RefreshDataGridView();
            LoadCategories();
        }

        private void RefreshDataGridView()
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + databasePath))
            {
                connection.Open();

                // Tabloyu oluşturmak için SQL sorgusu (Tablo zaten varsa tekrar oluşturulmayacak)
                string createTableQuery = "CREATE TABLE IF NOT EXISTS UserTable (Username TEXT, Password TEXT, Category TEXT)";

                using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Category sütununu kontrol etmek için var mı diye sorgulama yapalım
                bool categoryColumnExists = false;
                using (DataTable schemaTable = connection.GetSchema("Columns"))
                {
                    foreach (DataRow row in schemaTable.Rows)
                    {
                        string tableName = row["TABLE_NAME"].ToString();
                        string columnName = row["COLUMN_NAME"].ToString();
                        if (tableName == "UserTable" && columnName == "Category")
                        {
                            categoryColumnExists = true;
                            break;
                        }
                    }
                }

                // Eğer Category sütunu yoksa ekleyelim
                if (!categoryColumnExists)
                {
                    string addCategoryColumnQuery = "ALTER TABLE UserTable ADD COLUMN Category TEXT";
                    using (SQLiteCommand command = new SQLiteCommand(addCategoryColumnQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                string selectQuery = "SELECT * FROM UserTable";

                using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(selectQuery, connection))
                {
                    // DataTable oluştur ve verileri yükle
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // DataGridView'e verileri yükle
                    dataGridView1.DataSource = dataTable;

                    // Sütun başlıklarını görüntüle
                    dataGridView1.ColumnHeadersVisible = true;

                    // Sütun başlık hücre stilini özelleştir
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 15, FontStyle.Bold);

                    // Satır hücre stilini özelleştir
                    dataGridView1.RowsDefaultCellStyle.Font = new Font("Arial", 9);
                }
            }
        }

        private void LoadCategories()
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + databasePath))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM Categories";

                using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(selectQuery, connection))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // ComboBox'a kategorileri yükle
                    List<string> categoriesList = new List<string>();

                    // Boş seçeneği ekle
                    categoriesList.Add("");

                    // Veritabanından kategorileri al ve listeye ekle
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string categoryName = row["CategoryName"].ToString();
                        categoriesList.Add(categoryName);
                    }

                    comboBoxCategory.DataSource = categoriesList;
                    comboBoxCategory.SelectedIndex = -1; // ComboBox'ta seçimi temizle
                }
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateCategoriesTable();
            RefreshDataGridView();
            LoadCategories();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text.Trim();
            string category = comboBoxCategory.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Lütfen kullanıcı adı ve şifre alanlarını doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (IsUsernameExists(username))
            {
                MessageBox.Show("Bu kullanıcı adı zaten mevcut. Lütfen farklı bir kullanıcı adı seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + databasePath))
            {
                // Veritabanını aç
                connection.Open();

                // Kullanıcı adı, şifre ve kategori bilgilerini tabloya ekleme
                string insertQuery = "INSERT INTO UserTable (Username, Password, Category) VALUES (@Username, @Password, @Category)";

                using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Category", category);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Kullanıcı bilgileri başarıyla kaydedildi.");

            // DataGridView'i yenile
            RefreshDataGridView();

            // TextBox'ları temizle
            textBoxUsername.Text = "";
            textBoxPassword.Text = "";
            comboBoxCategory.SelectedIndex = -1; // ComboBox'ta seçimi temizle
        }

        private bool IsUsernameExists(string username)
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + databasePath))
            {
                connection.Open();

                string selectQuery = "SELECT COUNT(*) FROM UserTable WHERE Username = @Username";

                using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    return count > 0;
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + databasePath))
                {
                    // Veritabanını aç
                    connection.Open();

                    string deleteQuery = "DELETE FROM UserTable WHERE Username = @Username";

                    using (SQLiteCommand command = new SQLiteCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Username", textBoxDeleteUsername.Text);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Kullanıcı bilgisi başarıyla silindi.");

                // DataGridView'i yenile
                RefreshDataGridView();

                // TextBox'ı temizle
                textBoxDeleteUsername.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataGridView();
            LoadCategories(); // ComboBox'ı yenile

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Uygulama kapatıldığında Form2'yi de kapat
            Form2 form2 = Application.OpenForms["Form2"] as Form2;
            form2?.Close();
        }

        private void buttonOpenForm2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void CreateCategoriesTable()
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + databasePath))
            {
                connection.Open();

                // Tabloyu oluşturmak için SQL sorgusu
                string createTableQuery = "CREATE TABLE IF NOT EXISTS Categories (CategoryName TEXT)";

                using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Discord: @vespagnc", "Şaban Birkan Genç !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            MessageBox.Show("https://github.com/SabanGnc", "Şaban Birkan Genç !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.ShowDialog();
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            
        }
        
            

        private void textBoxPassword_TextChanged_1(object sender, EventArgs e)
        {
            
        }
    }
}
