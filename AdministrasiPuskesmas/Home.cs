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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Data emp = new Data();
            emp.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Data emp = new Data();
            emp.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Profil Prof = new Profil();
            Prof.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Profil Prof = new Profil();
            Prof.Show();
            this.Hide();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Pelayanan Ply = new Pelayanan();
            Ply.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Pelayanan Ply = new Pelayanan();
            Ply.Show();
            this.Hide();
        }
    }
}
