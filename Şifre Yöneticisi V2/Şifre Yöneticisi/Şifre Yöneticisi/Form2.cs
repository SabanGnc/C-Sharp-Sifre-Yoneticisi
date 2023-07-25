using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Şifre_Yöneticisi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            string databasePath = "veritabani.db";

            using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + databasePath))
            {
                connection.Open();

                // Tabloyu oluşturmak için SQL sorgusu (Tablo zaten varsa tekrar oluşturulmayacak)
                string createTableQuery = "CREATE TABLE IF NOT EXISTS Categories (CategoryName TEXT)";

                using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                string selectQuery = "SELECT * FROM Categories";

                using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(selectQuery, connection))
                {
                    // DataTable oluştur ve verileri yükle
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // DataGridView'e verileri yükle
                    dataGridView1.DataSource = dataTable;

                    // Sütun başlıklarını görüntüle
                    dataGridView1.ColumnHeadersVisible = false;
                }
            }
        }

        private bool IsCategoryExists(string categoryName)
        {
            string databasePath = "veritabani.db";

            using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + databasePath))
            {
                connection.Open();

                string selectQuery = "SELECT COUNT(*) FROM Categories WHERE CategoryName = @CategoryName";

                using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@CategoryName", categoryName);
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    return count > 0;
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string categoryName = textBoxCategory.Text.Trim();

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                MessageBox.Show("Lütfen bir kategori adı girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (IsCategoryExists(categoryName))
            {
                MessageBox.Show("Bu kategori zaten mevcut. Lütfen farklı bir kategori adı girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string databasePath = "veritabani.db";

            using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + databasePath))
            {
                // Veritabanını aç
                connection.Open();

                // Kategori adını tabloya ekleme
                string insertQuery = "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)";

                using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@CategoryName", categoryName);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Kategori başarıyla oluşturuldu.");

            // DataGridView'i yenile
            RefreshDataGridView();

            // TextBox'ı temizle
            textBoxCategory.Text = "";
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    string databasePath = "veritabani.db";

                    using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + databasePath))
                    {
                        // Veritabanını aç
                        connection.Open();

                        string deleteQuery = "DELETE FROM Categories WHERE CategoryName = @CategoryName";

                        using (SQLiteCommand command = new SQLiteCommand(deleteQuery, connection))
                        {
                            command.Parameters.AddWithValue("@CategoryName", dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Kategori başarıyla silindi.");

                    // DataGridView'i yenile
                    RefreshDataGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz kategoriyi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Discord: @vespagnc", "Şaban Birkan Genç !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            MessageBox.Show("https://github.com/SabanGnc", "Şaban Birkan Genç !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
