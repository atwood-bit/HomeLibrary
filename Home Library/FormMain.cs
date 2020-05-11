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
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace Home_Library
{
    public partial class FormMain : Form
    {
        SQLiteConnection conn = new SQLiteConnection("Data Source=library.db;Version=3;");
        int id_author = -1, id_genre = -1, id_publisher = -1, id_country = -1, c = 0, delete_id = -1;
        DataTable dt = new DataTable();

        public FormMain()
        {
            InitializeComponent();
        }
        
        private void LoadData()
        {
            dt.Clear();
            string query = "SELECT b.id, b.name, b.year, g.name, a.fio, c.name, p.name FROM Books b left join Authors a on b.id_author = a.id join Genre g on b.id_genre = g.id join Publishers p on b.id_publisher = p.id join Country c on b.id_country = c.id";
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            da.Fill(dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            navigator.BindingSource = bs;
            grid.DataSource = bs;
            conn.Close();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
            grid.Columns[0].HeaderText = "#";
            grid.Columns[1].HeaderText = "Name of book";
            grid.Columns[2].HeaderText = "Year";
            grid.Columns[3].HeaderText = "Genre";
            grid.Columns[4].HeaderText = "Author";
            grid.Columns[5].HeaderText = "Country";
            grid.Columns[6].HeaderText = "Publisher";
            grid.AutoResizeColumns();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void menuEdit_Click(object sender, EventArgs e)
        {
            FormEdit edit = new FormEdit();
            edit.Show();
            this.Hide();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (NameText.Text == "" || YearText.Text == "" || authorText.Text == "" || publisherText.Text == "" || genreText.Text == "" || countryText.Text == "")
            {
                MessageBox.Show("Please, fill all fields", "Error");
            }
            else
            {
                FindID();
                AddField();
                if (c > 0)
                {
                    FindID();
                }
                    string query = "INSERT INTO Books (Name, Year, id_author, id_publisher, id_genre, id_country) VALUES (@name, @year, @id_a, @id_p, @id_g, @id_c)";
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", NameText.Text);
                    cmd.Parameters.AddWithValue("@year", YearText.Text);
                    cmd.Parameters.AddWithValue("@id_a", id_author);
                    cmd.Parameters.AddWithValue("@id_p", id_publisher);
                    cmd.Parameters.AddWithValue("@id_g", id_genre);
                    cmd.Parameters.AddWithValue("@id_c", id_country);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                delete_id = -1;
                id_author = -1;
                id_genre = -1;
                id_publisher = -1;
                id_country = -1;
                c = 0;
                LoadData();
            }
        }

        private void FindID()
        {
            string authorID = "SELECT ID FROM Authors WHERE FIO=@nameA";
            string genreID = "SELECT ID FROM Genre WHERE Name=@nameG";
            string publisherID = "SELECT ID FROM Publishers WHERE Name=@nameP";
            string countryID = "SELECT ID FROM Country WHERE Name=@nameC";
            conn.Open();

                SQLiteCommand authorCMD = new SQLiteCommand(authorID, conn);
                authorCMD.Parameters.AddWithValue("@nameA", authorText.Text);
                SQLiteDataReader readerA = authorCMD.ExecuteReader();
                if (readerA.HasRows)
                {
                    while (readerA.Read())
                    {
                        id_author = Convert.ToInt32(readerA.GetValue(0));
                    }
                }
                readerA.Close();


                    SQLiteCommand genreCMD = new SQLiteCommand(genreID, conn);
                    genreCMD.Parameters.AddWithValue("@nameG", genreText.Text);
                    SQLiteDataReader readerG = genreCMD.ExecuteReader();
                    if (readerG.HasRows)
                    {
                        while (readerG.Read())
                        {
                            id_genre = Convert.ToInt32(readerG.GetValue(0));
                        }
                    }
                    readerG.Close();

                        SQLiteCommand publCMD = new SQLiteCommand(publisherID, conn);
                        publCMD.Parameters.AddWithValue("@nameP", publisherText.Text);
                        SQLiteDataReader readerP = publCMD.ExecuteReader();
                        if (readerP.HasRows)
                        {
                            while (readerP.Read())
                            {
                                id_publisher = Convert.ToInt32(readerP.GetValue(0));
                            }
                        }
                        readerP.Close();

                            SQLiteCommand countryCMD = new SQLiteCommand(countryID, conn);
                            countryCMD.Parameters.AddWithValue("@nameC", countryText.Text);
                            SQLiteDataReader readerC = countryCMD.ExecuteReader();
                            if (readerC.HasRows)
                            {
                                while (readerC.Read())
                                {
                                    id_country = Convert.ToInt32(readerC.GetValue(0));
                                }
                            }
                            readerC.Close();

            conn.Close();
        }

        private void AddField()
        {
            conn.Open();
                if (id_author < 0)
                {
                    string query = "INSERT INTO Authors (FIO) VALUES (@name)";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", authorText.Text);
                    cmd.ExecuteNonQuery();
                    ++c;
                }

                if (id_genre < 0)
                {
                    string query = "INSERT INTO Genre (Name) VALUES (@name)";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", genreText.Text);
                    cmd.ExecuteNonQuery();
                    ++c;
                }

                if (id_country < 0)
                {
                    string query = "INSERT INTO Country (Name) VALUES (@name)";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", countryText.Text);
                    cmd.ExecuteNonQuery();
                    ++c;
                }

                if (id_publisher < 0)
                {
                    string query = "INSERT INTO Publishers (Name) VALUES (@name)";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", publisherText.Text);
                    cmd.ExecuteNonQuery();
                    ++c;
                }
            conn.Close();
        }

        private void Search(string field, string word)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Format(field + " like '%{0}%'", word);
            grid.DataSource = dv.ToTable();
        }

        private void searchBook_TextChanged(object sender, EventArgs e)
        {
            string w = searchBook.Text.Trim();
            Search("Name", w);
        }

        private void searchAuthor_TextChanged(object sender, EventArgs e)
        {
            string w = searchAuthor.Text.Trim();
            Search("FIO", w);
        }

        private void SaveTable(string path)
        {
            Excel.Application excelapp = new Excel.Application();
            Excel.Workbook workbook = excelapp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;

            for (int i = 1; i < grid.RowCount; i++)
            {
                for (int j = 1; j <= grid.ColumnCount; j++)
                {
                    worksheet.Rows[i+1].Columns[j] = grid.Rows[i - 1].Cells[j - 1].Value;
                }
            }
            worksheet.Rows[1].Columns[1] = "#";
            worksheet.Rows[1].Columns[2] = "Book name";
            worksheet.Rows[1].Columns[3] = "Year";
            worksheet.Rows[1].Columns[4] = "Genre";
            worksheet.Rows[1].Columns[5] = "Author";
            worksheet.Rows[1].Columns[6] = "Country";
            worksheet.Rows[1].Columns[7] = "Publisher";
            worksheet.Columns.EntireColumn.AutoFit();
            excelapp.AlertBeforeOverwriting = false;
            workbook.SaveAs(path);
            excelapp.Quit();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName + ".xlsx";
            SaveTable(filename);
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            FormAbout ab = new FormAbout();
            ab.Show();
        }

        private void grid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            delete_id = Convert.ToInt32(grid.SelectedRows[0].Cells[0].Value.ToString());
            NameText.Text = grid.SelectedRows[0].Cells[1].Value.ToString();
            YearText.Text = grid.SelectedRows[0].Cells[2].Value.ToString();
            genreText.Text = grid.SelectedRows[0].Cells[3].Value.ToString();
            authorText.Text = grid.SelectedRows[0].Cells[4].Value.ToString();
            countryText.Text = grid.SelectedRows[0].Cells[5].Value.ToString();
            publisherText.Text = grid.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (delete_id > 0)
            {
                string query = "DELETE FROM Books WHERE ID = @item_id";
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@item_id", delete_id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                MessageBox.Show("You need select book!");
            }
            LoadData();
            delete_id = -1;
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            if (NameText.Text == "" || YearText.Text == "" || authorText.Text == "" || publisherText.Text == "" || genreText.Text == "" || countryText.Text == "")
            {
                MessageBox.Show("Please, fill all fields", "Error");
            }
            else if (delete_id < 0)
            {
                MessageBox.Show("You need select book!");
            }
            else
            {
                FindID();
                AddField();
                if (c > 0)
                {
                    FindID();
                }
                    string query = "UPDATE Books SET Name=@name, Year=@year, id_author=@id_a, id_publisher=@id_p, id_genre=@id_g, id_country=@id_c WHERE ID=@id";
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", NameText.Text);
                    cmd.Parameters.AddWithValue("@year", YearText.Text);
                    cmd.Parameters.AddWithValue("@id_a", id_author);
                    cmd.Parameters.AddWithValue("@id_p", id_publisher);
                    cmd.Parameters.AddWithValue("@id_g", id_genre);
                    cmd.Parameters.AddWithValue("@id_c", id_country);
                    cmd.Parameters.AddWithValue("@id", delete_id);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                delete_id = -1;
                id_author = -1;
                id_genre = -1;
                id_publisher = -1;
                id_country = -1;
                c = 0;
                LoadData();
            }
        }
    }
}
