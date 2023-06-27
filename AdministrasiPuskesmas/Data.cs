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
    public partial class Data : Form
    {
        public Data()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Kuliah\S2\PBO\AdministrasiPuskesmas\AdministrasiPuskesmas\PuskesmasDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Data_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'puskesmasDbDataSet.Pegawai' table. You can move, or remove it, as needed.
            this.pegawaiTableAdapter.Fill(this.puskesmasDbDataSet.Pegawai);
            populate();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (idptgs.Text == "" || namaptgs.Text == "" || nohpptgs.Text == "" || alamatptgs.Text == "" || emailptgs.Text == "" || rekrutptgs.Text == "")
            {
                MessageBox.Show("Data Tidak Ada!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into Pegawai values ('"+idptgs.Text+"', '"+namaptgs.Text+"', '"+nohpptgs.Text+"', '"+alamatptgs.Text+"', '"+emailptgs.Text+"', '"+rekrutptgs.Text+"')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Ditambahkan!");
                    Con.Close();
                    populate();

                }catch(Exception Ex)
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
            string query = "select * from Pegawai";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DataDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if(idptgs.Text == "")
            {
                MessageBox.Show("Masukkan ID Pegawai");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from Pegawai where Id_pegawai='" + idptgs.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Dihapus!");
                    Con.Close();
                    populate();
                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DataDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idptgs.Text = DataDGV.SelectedRows[0].Cells[0].Value.ToString();
            namaptgs.Text = DataDGV.SelectedRows[0].Cells[1].Value.ToString();
            nohpptgs.Text = DataDGV.SelectedRows[0].Cells[2].Value.ToString();
            alamatptgs.Text = DataDGV.SelectedRows[0].Cells[3].Value.ToString();
            emailptgs.Text = DataDGV.SelectedRows[0].Cells[4].Value.ToString();
            rekrutptgs.Text = DataDGV.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (idptgs.Text == "" || namaptgs.Text == "" || nohpptgs.Text == "" || alamatptgs.Text == "" || emailptgs.Text == "" || rekrutptgs.Text == "")
            {
                MessageBox.Show("Data Tidak Ada!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update Pegawai set Nama='" + namaptgs.Text + "', Telephone='" + nohpptgs.Text + "', Address='" + alamatptgs.Text + "', Email='" + emailptgs.Text + "', Rekrut='" + rekrutptgs.Text + "' where Id_pegawai='" + idptgs.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Diupdate!");
                    Con.Close();
                    populate();
                }catch(Exception Ex)
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
