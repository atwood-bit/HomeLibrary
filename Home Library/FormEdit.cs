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

namespace Home_Library
{
    public partial class FormEdit : Form
    {
        string active = "";
        SQLiteConnection conn = new SQLiteConnection("Data Source=library.db;Version=3;");
        public FormEdit()
        {
            InitializeComponent();
        }

        private void LoadData(string table)
        {
            string query = "SELECT * FROM " + table;
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            navigator.BindingSource = bs;
            switch (table)
            {
                case "Books":
                    gridBooks.DataSource = bs;
                    gridBooks.AutoResizeColumns();
                    break;
                case "Authors":
                    gridAuthors.DataSource = bs;
                    gridAuthors.AutoResizeColumns();
                    break;
                case "Country":
                    gridCountry.DataSource = bs;
                    gridCountry.AutoResizeColumns();
                    break;
                case "Genre":
                    gridGenre.DataSource = bs;
                    gridGenre.AutoResizeColumns();
                    break;
                case "Publishers":
                    gridPublishers.DataSource = bs;
                    gridPublishers.AutoResizeColumns();
                    break;
                case "Users":
                    gridUsers.DataSource = bs;
                    gridUsers.AutoResizeColumns();
                    break;
            }
            conn.Close();
        }

        private void DeleteItem(string table, string id)
        {
            if (id == "")
            {
                MessageBox.Show("Please enter ID of field", "Error");
            }
            else
            {
                Convert.ToInt32(id);
                string query = "DELETE FROM " + table + " WHERE ID = @item_id";
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@item_id", id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void mainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMain main = new FormMain();
            main.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pgBooks_Enter(object sender, EventArgs e)
        {
            active = "Books";
            LoadData(active);
        }

        private void pgAuthors_Enter(object sender, EventArgs e)
        {
            active = "Authors";
            LoadData(active);
        }

        private void pgGenre_Enter(object sender, EventArgs e)
        {
            active = "Genre";
            LoadData(active);
        }

        private void pgCountry_Enter(object sender, EventArgs e)
        {
            active = "Country";
            LoadData(active);
        }

        private void pgPublishers_Enter(object sender, EventArgs e)
        {
            active = "Publishers";
            LoadData(active);
        }

        private void pgUsers_Enter(object sender, EventArgs e)
        {
            active = "Users";
            LoadData(active);
        }

        private void bookDel_Click(object sender, EventArgs e)
        {
                DeleteItem(active, bookID.Text);
                LoadData(active);
                ClearTextBoxes(tabControl1.SelectedTab);
        }

        private void authorDel_Click(object sender, EventArgs e)
        {
                DeleteItem(active, authorID.Text);
                LoadData(active);
                ClearTextBoxes(tabControl1.SelectedTab);
        }

        private void genreDel_Click(object sender, EventArgs e)
        {
                DeleteItem(active, genreID.Text);
                LoadData(active);
                ClearTextBoxes(tabControl1.SelectedTab);
        }

        private void countryDel_Click(object sender, EventArgs e)
        {
                DeleteItem(active, countryID.Text);
                LoadData(active);
                ClearTextBoxes(tabControl1.SelectedTab);
        }

        private void publisherDel_Click(object sender, EventArgs e)
        {
                DeleteItem(active, publisherID.Text);
                LoadData(active);
                ClearTextBoxes(tabControl1.SelectedTab);
        }

        private void userDel_Click(object sender, EventArgs e)
        {
                DeleteItem(active, userID.Text);
                LoadData(active);
                ClearTextBoxes(tabControl1.SelectedTab);
        }

        private void bookAdd_Click(object sender, EventArgs e)
        {
            if (bookName.Text == "" || bookYear.Text == "" || bookAuthor.Text == "" || bookPublisher.Text == "" || bookGenre.Text == "" || bookCountry.Text == "")
            {
                MessageBox.Show("Please, fill all fields", "Error");
            }
            else
            {
                string query = "INSERT INTO Books (Name, Year, id_author, id_publisher, id_genre, id_country) VALUES (@name, @year, @id_a, @id_p, @id_g, @id_c)";
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", bookName.Text);
                cmd.Parameters.AddWithValue("@year", bookYear.Text);
                cmd.Parameters.AddWithValue("@id_a", bookAuthor.Text);
                cmd.Parameters.AddWithValue("@id_p", bookPublisher.Text);
                cmd.Parameters.AddWithValue("@id_g", bookGenre.Text);
                cmd.Parameters.AddWithValue("@id_c", bookCountry.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                LoadData(active);
                ClearTextBoxes(tabControl1.SelectedTab);
            }
        }

        private void AddOnlyNameInTable(string table, string name)
        {
            string field = "";
            if (table == "Authors")
            {
                field = "FIO";
            }
            else
            {
                field = "Name";
            }
            if (name == "")
            {
                MessageBox.Show("Please enter Name of field", "Error");
            }
            else
            {
                string query = "INSERT INTO " + table + "(" + field + ") VALUES (@name)";
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void UpdateNameInTable(string table, string name, string id)
        {
            string field = "";
            if (table == "Authors")
            {
                field = "FIO";
            }
            else if (table == "Users")
            {
                field = "Username";
            }
            else
            {
                field = "Name";
            }
            if (name == "" || id == "")
            {
                MessageBox.Show("Please enter Name of field", "Error");
            }
            else
            {
                Convert.ToInt32(id);
                string query = "UPDATE " + table + " SET " + field + "=@name WHERE ID=@id";
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void authorAdd_Click(object sender, EventArgs e)
        {
            AddOnlyNameInTable(active, authorName.Text);
            LoadData(active);
            ClearTextBoxes(tabControl1.SelectedTab);
        }

        private void genreAdd_Click(object sender, EventArgs e)
        {
            AddOnlyNameInTable(active, genreName.Text);
            LoadData(active);
            ClearTextBoxes(tabControl1.SelectedTab);
        }

        private void countryAdd_Click(object sender, EventArgs e)
        {
            AddOnlyNameInTable(active, countryName.Text);
            LoadData(active);
            ClearTextBoxes(tabControl1.SelectedTab);
        }

        private void publisherAdd_Click(object sender, EventArgs e)
        {
            if (publisherAddress.Text != "")
            {
                string query = "INSERT INTO Publishers (Name, Address) VALUES (@name, @adrs)";
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", publisherName.Text);
                cmd.Parameters.AddWithValue("@adrs", publisherAddress.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                AddOnlyNameInTable(active, publisherName.Text);
            }
            LoadData(active);
            ClearTextBoxes(tabControl1.SelectedTab);
        }

        private void bookUpd_Click(object sender, EventArgs e)
        {
            if (bookName.Text == "" || bookYear.Text == "" || bookAuthor.Text == "" || bookPublisher.Text == "" || bookGenre.Text == "" || bookCountry.Text == "" || bookID.Text == "")
            {
                MessageBox.Show("Please, fill all fields", "Error");
            }
            else
            {
                string query = "UPDATE Books set Name=@name, Year=@year, id_author=@id_a, id_publisher=@id_p, id_genre=@id_g, id_country=@id_c WHERE ID=@id";
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", bookID.Text);
                cmd.Parameters.AddWithValue("@name", bookName.Text);
                cmd.Parameters.AddWithValue("@year", bookYear.Text);
                cmd.Parameters.AddWithValue("@id_a", bookAuthor.Text);
                cmd.Parameters.AddWithValue("@id_p", bookPublisher.Text);
                cmd.Parameters.AddWithValue("@id_g", bookGenre.Text);
                cmd.Parameters.AddWithValue("@id_c", bookCountry.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                LoadData(active);
                ClearTextBoxes(tabControl1.SelectedTab);
            }
        }

        private void authorUpd_Click(object sender, EventArgs e)
        {
            UpdateNameInTable(active, authorName.Text, authorID.Text);
            LoadData(active);
            ClearTextBoxes(tabControl1.SelectedTab);
        }

        private void genreUpd_Click(object sender, EventArgs e)
        {
            UpdateNameInTable(active, genreName.Text, genreID.Text);
            LoadData(active);
            ClearTextBoxes(tabControl1.SelectedTab);
        }

        private void countryUpd_Click(object sender, EventArgs e)
        {
            UpdateNameInTable(active, countryName.Text, countryID.Text);
            LoadData(active);
            ClearTextBoxes(tabControl1.SelectedTab);
        }

        private void userUpd_Click(object sender, EventArgs e)
        {
            UpdateNameInTable(active, userName.Text, userID.Text);
            LoadData(active);
            ClearTextBoxes(tabControl1.SelectedTab);
        }

        private void publisherUpd_Click(object sender, EventArgs e)
        {
            if (publisherAddress.Text != "")
            {
                string query = "UPDATE Publisher SET Name=@name, Address=@adrs WHERE ID=@id";
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", publisherID.Text);
                cmd.Parameters.AddWithValue("@name", publisherName.Text);
                cmd.Parameters.AddWithValue("@adrs", publisherAddress.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                UpdateNameInTable(active, publisherName.Text, publisherID.Text);
            }
            LoadData(active);
            ClearTextBoxes(tabControl1.SelectedTab);
        }

        void ClearTextBoxes(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                TextBox textBox = child as TextBox;
                if (textBox == null)
                    ClearTextBoxes(child);
                else
                    textBox.Text = string.Empty;
            }
        }

        private void FormEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void gridBooks_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            bookID.Text = gridBooks.SelectedRows[0].Cells[0].Value.ToString();
            bookName.Text = gridBooks.SelectedRows[0].Cells[1].Value.ToString();
            bookYear.Text = gridBooks.SelectedRows[0].Cells[2].Value.ToString();
            bookAuthor.Text = gridBooks.SelectedRows[0].Cells[3].Value.ToString();
            bookPublisher.Text = gridBooks.SelectedRows[0].Cells[4].Value.ToString();
            bookGenre.Text = gridBooks.SelectedRows[0].Cells[5].Value.ToString();
            bookCountry.Text = gridBooks.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void gridAuthors_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            authorID.Text = gridAuthors.SelectedRows[0].Cells[0].Value.ToString();
            authorName.Text = gridAuthors.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void gridGenre_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            genreID.Text = gridGenre.SelectedRows[0].Cells[0].Value.ToString();
            genreName.Text = gridGenre.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void gridCountry_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            countryID.Text = gridCountry.SelectedRows[0].Cells[0].Value.ToString();
            countryName.Text = gridCountry.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void gridPublishers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            publisherID.Text = gridPublishers.SelectedRows[0].Cells[0].Value.ToString();
            publisherName.Text = gridPublishers.SelectedRows[0].Cells[1].Value.ToString();
            publisherAddress.Text = gridPublishers.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void gridUsers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            userID.Text = gridUsers.SelectedRows[0].Cells[0].Value.ToString();
            userName.Text = gridUsers.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout ab = new FormAbout();
            ab.Show();
        }
    }
}
