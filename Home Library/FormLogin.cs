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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            if (NameText.Text.Trim() == "" || PassText.Text.Trim() == "")
            {
                MessageBox.Show("Empty fields!\nPlease, fill fields", "Error");
            }
            else
            {
                string query = "SELECT * FROM Users WHERE Username=@user AND Password=@pass";
                SQLiteConnection conn = new SQLiteConnection("Data Source=library.db;Version=3;");
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", NameText.Text);
                cmd.Parameters.AddWithValue("@pass", PassText.Text);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    FormMain main = new FormMain();
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login failed", "Error");
                }
                conn.Close();
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btRegister_Click(object sender, EventArgs e)
        {
            FormRegister reg = new FormRegister();
            reg.Show();
            this.Hide();
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
