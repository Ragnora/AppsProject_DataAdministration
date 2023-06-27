using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdministrasiPuskesmas
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (un.Text == "" || pw.Text == "")
            {
                MessageBox.Show("Masukkan Username Dan Password!");
            }else if(un.Text == "Admin" && pw.Text == "Admin1")
            {
                this.Hide();
                Home home = new Home();
                home.Show();
            }
            else
            {
                MessageBox.Show("Username Atau Password Salah!");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
