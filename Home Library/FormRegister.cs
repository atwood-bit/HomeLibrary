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
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void btReg_Click(object sender, EventArgs e)
        {
            if (NameText.Text.Trim() == "" || PassText.Text.Trim() == "")
            {
                MessageBox.Show("Empty fields!\nPlease, fill fields", "Error");
            }
            else
            {
                string query1 = "SELECT * FROM Users WHERE Username=@user";
                SQLiteConnection conn = new SQLiteConnection("Data Source=library.db;Version=3;");
                conn.Open();
                SQLiteCommand cmd1 = new SQLiteCommand(query1, conn);
                cmd1.Parameters.AddWithValue("@user", NameText.Text);
                SQLiteDataAdapter da1 = new SQLiteDataAdapter(cmd1);
                DataTable dt = new DataTable();
                da1.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("User already exists, please entry another name", "Failed");
                }
                else
                {
                    string query = "insert into Users (Username, Password) values (@user, @pass) ";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", NameText.Text);
                    cmd.Parameters.AddWithValue("@pass", PassText.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("You're registered!");
                    FormLogin log = new FormLogin();
                    log.Show();
                    this.Hide();
                }
            }
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            FormLogin log = new FormLogin();
            log.Show();
            this.Hide();
        }

        private void FormRegister_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
