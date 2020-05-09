using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoQLBHDT.DAO;
using DemoQLBHDT.DTO.EntitiesClass;
using DemoQLBHDT.DTO.Component;

namespace DemoQLBHDT
{
    public partial class FNhomHang : Form
    {
        public FNhomHang()
        {
            InitializeComponent();
        }

        public MainForm main = new MainForm();

        public string Access = "";
        ConnectDataBase Connect = new ConnectDataBase();
        EC_NhomHang NhomHang = new EC_NhomHang();
        C_NhomHang Act = new C_NhomHang();

        public void khoitaoluoi()
        {
            dgvNhomHang.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvNhomHang.Columns[0].HeaderText = "Mã Nhóm Hàng";
            dgvNhomHang.Columns[0].Frozen = true;
            dgvNhomHang.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvNhomHang.Columns[1].HeaderText = "Tên Nhóm Hàng";
        }        

        


        private void FNhomHang_Load(object sender, EventArgs e)
        {
            //txtMaNhom.Enabled = false;
            //txtTenNhom.Enabled = false;

            dgvNhomHang.DataSource = Act.CreateTbNH();
            khoitaoluoi();
        }

        private void dgvNhomHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaNhom.Text = dgvNhomHang.Rows[row].Cells[0].Value.ToString();
                txtTenNhom.Text = dgvNhomHang.Rows[row].Cells[1].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //this.Hide();
            FChangeNhomHang fadd = new FChangeNhomHang();
            fadd.AddThongTin(new string[] { btnAdd.Text, "", "" });
            fadd.MdiParent = main;
            fadd.main = main;
            //fadd.fnhomhang.MdiParent = main;
            this.Close();
            fadd.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FChangeNhomHang fadd = new FChangeNhomHang();
            fadd.AddThongTin(new string[] { btnUpdate.Text, txtMaNhom.Text, txtTenNhom.Text });
            fadd.MdiParent = main;
            fadd.main = main;
            this.Close();
            fadd.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FChangeNhomHang fadd = new FChangeNhomHang();
            fadd.AddThongTin(new string[] { btnDelete.Text, txtMaNhom.Text, txtTenNhom.Text });
            fadd.MdiParent = main;
            fadd.main = main;
            this.Close();
            fadd.Show();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtMaNhom.Text == "---" || txtMaNhom.Text == "")
            {
                NhomHang.MaNhomHang = "%";
            }
            else
            {
                NhomHang.MaNhomHang = txtMaNhom.Text;
            }
            if (txtTenNhom.Text == "---" || txtTenNhom.Text == "")
            {
                NhomHang.TenNhomHang = "%";
            }
            else
            {
                NhomHang.TenNhomHang = txtTenNhom.Text;
            }

            dgvNhomHang.DataSource = Act.CreateTbNH(NhomHang);
        }
    }
}
