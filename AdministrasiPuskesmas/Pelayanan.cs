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
    public partial class Pelayanan : Form
    {
        public Pelayanan()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Kuliah\S2\PBO\AdministrasiPuskesmas\AdministrasiPuskesmas\PuskesmasDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void Pelayanan_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (idpsn.Text == "" || namapsn.Text == "" || usiapsn.Text == "" || alamatpsn.Text == "" || nohppsn.Text == "" || kunjunganpsn.Text == "")
            {
                MessageBox.Show("Data Tidak Ada!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into Pelayanan values ('" + idpsn.Text + "', '" + namapsn.Text + "', '" + usiapsn.Text + "', '" + alamatpsn.Text + "', '" + nohppsn.Text + "', '" + kunjunganpsn.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Ditambahkan!");
                    Con.Close();
                    populate();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
private void populate()
        {
            Con.Open();
            string query = "select * from Pelayanan";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            PelayananDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (idpsn.Text == "")
            {
                MessageBox.Show("Masukkan ID Pasien");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from Pelayanan where Id_pasien='" + idpsn.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Dihapus!");
                    Con.Close();
                    populate();
                }catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void PelayananDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                idpsn.Text = PelayananDGV.SelectedRows[0].Cells[0].Value.ToString();
                namapsn.Text = PelayananDGV.SelectedRows[0].Cells[1].Value.ToString();
                usiapsn.Text = PelayananDGV.SelectedRows[0].Cells[2].Value.ToString();
                alamatpsn.Text = PelayananDGV.SelectedRows[0].Cells[3].Value.ToString();
                nohppsn.Text = PelayananDGV.SelectedRows[0].Cells[4].Value.ToString();
                kunjunganpsn.Text = PelayananDGV.SelectedRows[0].Cells[5].Value.ToString();
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (idpsn.Text == "" || namapsn.Text == "" || usiapsn.Text == "" || alamatpsn.Text == "" || nohppsn.Text == "" || kunjunganpsn.Text == "")
            {
                MessageBox.Show("Data Tidak Ada!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update Pelayanan set Nama='" + namapsn.Text + "', Usia='" + usiapsn.Text + "', Address='" + alamatpsn.Text + "', Telephone='" + nohppsn.Text + "', Kunjungan='" + kunjunganpsn.Text + "' where Id_pasien='" + idpsn.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Diupdate!");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
