﻿using DevExpress.Xpo.DB.Helpers;
using QuanLy.Model;
using QuanLy.QL_ThietBi;
using QuanLyChungCu;
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

namespace QuanLy.QL_ThongBao
{
    public partial class FrmQLThietBi : Form
    {
        public FrmQLThietBi()
        {
            InitializeComponent();
            FillTable("select * from ThietBi");
        }
        ThietBi model = new ThietBi();
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
                dtgvTB.Columns["Id"].DataPropertyName = "Id";
                dtgvTB.Columns["Ten"].DataPropertyName = "Ten";
                dtgvTB.Columns["NgayCap"].DataPropertyName = "NgayCap";
                dtgvTB.Columns["ViTri"].DataPropertyName = "ViTri";
                dtgvTB.Columns["SoLuong"].DataPropertyName = "SoLuong";
                dtgvTB.Columns["TinhTrang"].DataPropertyName = "TinhTrang";

                dtgvTB.Width = 916;

                dtgvTB.Columns["Id"].AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill;
                dtgvTB.Columns["Ten"].AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill;
                dtgvTB.Columns["NgayCap"].AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill;
                dtgvTB.Columns["ViTri"].AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill;
                dtgvTB.Columns["SoLuong"].AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill;
                dtgvTB.Columns["TinhTrang"].AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill;

                dtgvTB.DataSource = null;
                dtgvTB.DefaultCellStyle.ForeColor = Color.Black;
                dtgvTB.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dtgvTB.MultiSelect = false;
                dtgvTB.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FrmQLThietBi_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            FrmThemThietBi newf = new FrmThemThietBi();
            newf.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            FrmSuaTB newf = new FrmSuaTB(model);
            newf.ShowDialog();
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            FillTable("select * from ThietBi where Ten like N'"+ txtTimKiem.Text + "'");
        }

        private void dtgvTB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dtgvTB.Rows[e.RowIndex];
                model.Id = selectedRow.Cells["Id"].Value.ToString();
                model.Ten = selectedRow.Cells["Ten"].Value.ToString();
                model.NgayCap = DateTime.Parse(selectedRow.Cells["NgayCap"].Value.ToString());
                model.ViTri = selectedRow.Cells["ViTri"].Value.ToString();
                model.SoLuong = selectedRow.Cells["SoLuong"].Value.ToString();
                model.TinhTrang = selectedRow.Cells["TinhTrang"].Value.ToString();

            }
        }
    }
}
