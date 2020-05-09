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
    public partial class FNhaCC : Form
    {
        public FNhaCC()
        {
            InitializeComponent();
        }

        public MainForm main = new MainForm();
        public string Access = "";
        ConnectDataBase Connect = new ConnectDataBase();
        EC_NhaCC NhaCC = new EC_NhaCC();
        C_NhaCC Act = new C_NhaCC();

        public void khoitaoluoi()
        {
            dgvNhaCC.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvNhaCC.Columns[0].HeaderText = "Mã Nhà CC";
            dgvNhaCC.Columns[0].Frozen = true;
            dgvNhaCC.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvNhaCC.Columns[1].HeaderText = "Tên Nhà CC";
            dgvNhaCC.Columns[2].HeaderText = "Địa Chỉ";
            dgvNhaCC.Columns[3].HeaderText = "Liên Hệ";
        }

        private void FNhaCC_Load(object sender, EventArgs e)
        {
            //txtMaNhaCC.Enabled = false;
            //txtTenNhaCC.Enabled = false;
            //txtDiaChi.Enabled = false;
            //txtSDT.Enabled = false;

            dgvNhaCC.DataSource = Act.CreateTbNCC();
            khoitaoluoi();
        }

        private void dgvNhaCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaNhaCC.Text = dgvNhaCC.Rows[row].Cells[0].Value.ToString();
                txtTenNhaCC.Text = dgvNhaCC.Rows[row].Cells[1].Value.ToString();
                txtDiaChi.Text = dgvNhaCC.Rows[row].Cells[2].Value.ToString();
                txtSDT.Text = dgvNhaCC.Rows[row].Cells[3].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //this.Hide();
            FChangeNhaCC fadd = new FChangeNhaCC();
            fadd.AddThongTin(new string[5] { btnAdd.Text, "", "", "", "" });
            fadd.MdiParent = main;
            fadd.main = main;
            this.Close();
            fadd.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FChangeNhaCC fadd = new FChangeNhaCC();
            fadd.AddThongTin(new string[5] { btnUpdate.Text, txtMaNhaCC.Text, txtTenNhaCC.Text, txtDiaChi.Text, txtSDT.Text });
            fadd.MdiParent = main;
            fadd.main = main;
            this.Close();
            fadd.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FChangeNhaCC fadd = new FChangeNhaCC();
            fadd.AddThongTin(new string[5] { btnDelete.Text, txtMaNhaCC.Text, txtTenNhaCC.Text, txtDiaChi.Text, txtSDT.Text });
            fadd.MdiParent = main;
            fadd.main = main;
            this.Close();
            fadd.Show();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if(txtMaNhaCC.Text == "---" || txtMaNhaCC.Text == "")
            {
                NhaCC.MaNhaCC = "%";
            }
            else
            {
                NhaCC.MaNhaCC = txtMaNhaCC.Text;
            }
            if(txtTenNhaCC.Text == "---" || txtTenNhaCC.Text == "")
            {
                NhaCC.TenNhaCC = "%";
            }
            else
            {
                NhaCC.TenNhaCC = txtTenNhaCC.Text;
            }
            if(txtDiaChi.Text=="---" || txtDiaChi.Text == "")
            {
                NhaCC.DiaChi = "%";
            }
            else
            {
                NhaCC.DiaChi = txtDiaChi.Text;
            }
            if (txtSDT.Text == "---" || txtSDT.Text == "")
            {
                NhaCC.DienThoai = "%";
            }
            else
            {
                NhaCC.DienThoai = txtSDT.Text;
            }

            dgvNhaCC.DataSource = Act.CreateTbNCC(NhaCC);
        }
    }
}
