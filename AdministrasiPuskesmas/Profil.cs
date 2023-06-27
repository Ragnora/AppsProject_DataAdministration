using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AdministrasiPuskesmas
{
    public partial class Profil : Form
    {
        public Profil()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Kuliah\S2\PBO\AdministrasiPuskesmas\AdministrasiPuskesmas\PuskesmasDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void fetchempdata()
        {
            Con.Open();
            string query = "select * from Pegawai where Id_pegawai='" + ptgsid.Text + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                idpetugas.Text = dr["Id_pegawai"].ToString();
                namapetugas.Text = dr["Nama"].ToString();
                nohppetugas.Text = dr["Telephone"].ToString();
                alamatpetugas.Text = dr["Address"].ToString();
                emailpetugas.Text = dr["Email"].ToString();
                rekrutpetugas.Text = dr["Rekrut"].ToString();
                idpetugas.Visible = true;
                namapetugas.Visible = true;
                nohppetugas.Visible = true;
                alamatpetugas.Visible = true;
                emailpetugas.Visible = true;
                rekrutpetugas.Visible = true;
            }
            Con.Close();
        }
        private void Profil_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            fetchempdata();
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if(printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("========DATA PETUGAS========", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Red, new Point(180));
            e.Graphics.DrawString("ID Petugas: " + idpetugas.Text + "\t                        Nama " + namapetugas.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(10, 100));
            e.Graphics.DrawString("Telephone: " + nohppetugas.Text + "\t         Alamat " + alamatpetugas.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(10, 140));
            e.Graphics.DrawString("Email         : " + emailpetugas.Text + "\t         Tanggal Rekrut " + rekrutpetugas.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(10, 180));
            e.Graphics.DrawString("====PUSKESMAS SUMBER SARI====", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Red, new Point(180, 240));
        }

    }
}
