using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_Plane
{
    public partial class ThemMayBay : Form
    {
        private readonly string _connectionString = "Data Source=Rab-Tur;Initial Catalog=SanBay;Integrated Security=True";
        public ThemMayBay()
        {
            InitializeComponent();
        }

        private void ThemMayBay_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO MayBay (TenMayBay, NamSX, SoGioBay) VALUES (@TenMayBay, @NamSX, @SoGioBay)", conn);
                cmd.Parameters.AddWithValue("@TenMayBay", richTextBox1.Text);
                cmd.Parameters.AddWithValue("@NamSX", int.Parse(richTextBox2.Text));
                cmd.Parameters.AddWithValue("@SoGioBay", int.Parse(richTextBox3.Text));
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Đã thêm máy bay thành công!");
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
