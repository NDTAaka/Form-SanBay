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


namespace Form_Plane
{
    public partial class Form1 : Form
    {
        private readonly string _connectionString = "Data Source=Rab-Tur;Initial Catalog=SanBay;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Tải dữ liệu khi form được mở
            LoadMayBayData();
        }

        private void LoadMayBayData()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM MayBay ORDER BY TenMayBay ASC", conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;  // Gán dữ liệu cho DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
                }
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThemMayBay themForm = new ThemMayBay();
            themForm.FormClosed += (s, args) => LoadMayBayData();
            themForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int maMB = (int)dataGridView1.SelectedRows[0].Cells["MaMB"].Value;
                string tenMayBay = dataGridView1.SelectedRows[0].Cells["TenMayBay"].Value.ToString();
                int namSX = (int)dataGridView1.SelectedRows[0].Cells["NamSX"].Value;
                int soGioBay = (int)dataGridView1.SelectedRows[0].Cells["SoGioBay"].Value;

                SuaMayBay suaForm = new SuaMayBay(maMB, tenMayBay, namSX, soGioBay);
                suaForm.FormClosed += (s, args) => LoadMayBayData();
                suaForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một máy bay để sửa.");
            }
        }
    }
}
