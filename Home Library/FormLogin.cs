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
using System.Security.Cryptography;

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
                string hashPass = "";
                string pass = PassText.Text;
                string query = "SELECT Password FROM Users WHERE Username=@user";
                SQLiteConnection conn = new SQLiteConnection("Data Source=library.db;Version=3;");
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", NameText.Text);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                SQLiteDataReader readerA = cmd.ExecuteReader();
                    if (readerA.HasRows)
                    {
                        while (readerA.Read())
                        {
                            if (readerA.IsDBNull(0))
                            {
                                hashPass = string.Empty;
                                return;
                            }
                            hashPass = Convert.ToString(readerA.GetValue(0));
                        }
                    }
                    readerA.Close();
                    conn.Close();
                    if (String.IsNullOrEmpty(hashPass))
                    {
                        conn.Close();
                        MessageBox.Show("User not found", "Error");
                    }
                    else
                    {
                        bool result = VerifyHashedPassword(hashPass, pass);
                        if (result)
                        {
                            FormMain m1 = new FormMain();
                            m1.Show();
                            this.Hide();
                        }
                        else
                        {
                            conn.Close();
                            MessageBox.Show("Invalid password!", "Error");
                        }
                    }
            }
        }

        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return ByteArraysEqual(buffer3, buffer4);
        }

        private static bool ByteArraysEqual(byte[] firstHash, byte[] secondHash)
        {
            int _minHashLength = firstHash.Length <= secondHash.Length ? firstHash.Length : secondHash.Length;
            var xor = firstHash.Length ^ secondHash.Length;
            for (int i = 0; i < _minHashLength; i++)
                xor |= firstHash[i] ^ secondHash[i];
            return 0 == xor;
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
