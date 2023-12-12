using DevExpress.Xpo.DB.Helpers;
using QuanLyChungCu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLy.QL_CongViec
{
    public partial class FrmBaoTri : Form
    {
        
        public FrmBaoTri()
        {
            InitializeComponent();
            FillTable("select * from BaoTri");
        }
        public void FillTable(string query)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                using (SqlConnection sqlConnection = ConnectDb.GetConnection())
                {
                    sqlConnection.Open();
                    adapter = new SqlDataAdapter(query, sqlConnection);
                    adapter.Fill(table);
                    sqlConnection.Close();
                }
                dtgvBaoTri.Columns["Id"].DataPropertyName = "Id";
                dtgvBaoTri.Columns["MaTB"].DataPropertyName = "IdTB";
                dtgvBaoTri.Columns["NgayBT"].DataPropertyName = "NgayBaoTri";
                dtgvBaoTri.Columns["NgayKT"].DataPropertyName = "NgayKetThuc";
                dtgvBaoTri.Columns["GhiChu"].DataPropertyName = "GhiChu";
                dtgvBaoTri.Columns["TrangThai"].DataPropertyName = "TrangThai";

                dtgvBaoTri.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dtgvBaoTri.Columns["MaTB"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dtgvBaoTri.Columns["NgayBT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dtgvBaoTri.Columns["NgayKT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dtgvBaoTri.Columns["GhiChu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dtgvBaoTri.Columns["TrangThai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dtgvBaoTri.DataSource = null;
                dtgvBaoTri.DefaultCellStyle.ForeColor = Color.Black;
                dtgvBaoTri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dtgvBaoTri.MultiSelect = false;
                dtgvBaoTri.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Tab_DanhSach_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            FillTable("select * from BaoTri where Id = '"+txtTimKiem.Text+"'");
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
