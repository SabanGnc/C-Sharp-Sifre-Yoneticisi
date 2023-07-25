using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Şifre_Yöneticisi
{
    public partial class Form3 : Form
    {
        private string databasePath = "veritabani.db";

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // DataGridView özelliklerini düzenle
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 15, System.Drawing.FontStyle.Bold);
            dataGridView1.RowsDefaultCellStyle.Font = new System.Drawing.Font("Arial", 9);

            // ComboBox'ı doldur
            LoadCategoriesToComboBox();

            // DataGridView'i güncelle
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + databasePath))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM UserTable WHERE Username LIKE @Username AND (@Category = '' OR Category = @Category)";

                using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(selectQuery, connection))
                {
                    // Sadece başında veya sonunda eşleşme yapacak şekilde arama yapalım.
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@Username", "%" + textBoxSearch.Text + "%");

                    // ComboBox'ta seçilen kategori değiştikçe DataGridView'i güncelle
                    if (!string.IsNullOrEmpty(comboBoxCategoryFilter.Text) && comboBoxCategoryFilter.Text != "Boş")
                        dataAdapter.SelectCommand.Parameters.AddWithValue("@Category", comboBoxCategoryFilter.Text);
                    else
                        dataAdapter.SelectCommand.Parameters.AddWithValue("@Category", "");

                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            // TextBox'ta arama yapılacak kullanıcı adı değiştikçe DataGridView'i güncelle
            RefreshDataGridView();
        }

        private void LoadCategoriesToComboBox()
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + databasePath))
            {
                connection.Open();

                string selectQuery = "SELECT DISTINCT Category FROM UserTable";

                using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(selectQuery, connection))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // ComboBox'a "Boş" öğesini ekle
                    DataRow emptyRow = dataTable.NewRow();
                    emptyRow["Category"] = "Boş";
                    dataTable.Rows.InsertAt(emptyRow, 0);

                    comboBoxCategoryFilter.DataSource = dataTable;
                    comboBoxCategoryFilter.DisplayMember = "Category";
                    comboBoxCategoryFilter.ValueMember = "Category"; // ValueMember'ı belirtiyoruz
                    comboBoxCategoryFilter.SelectedIndex = 0; // Başlangıçta "Boş" seçili olsun
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // DataGridView'i ve ComboBox'ı yenile
            RefreshDataGridView();
            LoadCategoriesToComboBox();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Discord: @vespagnc", "Şaban Birkan Genç !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            MessageBox.Show("https://github.com/SabanGnc", "Şaban Birkan Genç !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
