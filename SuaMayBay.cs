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
    public partial class SuaMayBay : Form
    {
        private readonly string _connectionString = "Data Source=Rab-Tur;Initial Catalog=SanBay;Integrated Security=True";
        private int _maMB;
        public SuaMayBay(int maMB, string tenMayBay, int namSX, int soGioBay)
        {
            InitializeComponent();
            _maMB = maMB;
            richTextBox1.Text = tenMayBay;
            richTextBox2.Text = namSX.ToString();
            richTextBox3.Text = soGioBay.ToString();
        }

        private void SuaMayBay_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE MayBay SET TenMayBay = @TenMayBay, NamSX = @NamSX, SoGioBay = @SoGioBay WHERE MaMB = @MaMB", conn);
                cmd.Parameters.AddWithValue("@MaMB", _maMB);
                cmd.Parameters.AddWithValue("@TenMayBay", richTextBox1.Text);
                cmd.Parameters.AddWithValue("@NamSX", int.Parse(richTextBox2.Text));
                cmd.Parameters.AddWithValue("@SoGioBay", int.Parse(richTextBox3.Text));
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Đã cập nhật máy bay thành công!");
            this.Close();
        }
    }
}
