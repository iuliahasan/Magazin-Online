using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Proiect_FIS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (AuthenticateUser(username, password))
            {
                MessageBox.Show("Autentificare reușită!");

                Form1 mainForm = new Form1();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nume de utilizator sau parolă incorecte!");
            }

        }

        private bool AuthenticateUser(string username, string password)
        {
            string[] lines = File.ReadAllLines("users.txt");
            foreach (string line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 2)
                {
                    string fileUsername = parts[0].Trim();
                    string filePassword = parts[1].Trim();
                    if (fileUsername == username && filePassword == password)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
