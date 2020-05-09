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
    public partial class FKhachHang : Form
    {
        public FKhachHang()
        {
            InitializeComponent();
        }

        public MainForm main = new MainForm();
        public string Access = "";
        ConnectDataBase Connect = new ConnectDataBase();
        EC_KhachHang KhachHang = new EC_KhachHang();
        C_KhachHang Act = new C_KhachHang();

        public void khoitaoluoi()
        {
            dgvKhachHang.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvKhachHang.Columns[0].HeaderText = "Mã Khách Hàng";
            dgvKhachHang.Columns[0].Frozen = true;
            dgvKhachHang.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvKhachHang.Columns[1].HeaderText = "Tên Khách Hàng";
            dgvKhachHang.Columns[2].HeaderText = "Địa Chỉ";
            dgvKhachHang.Columns[3].HeaderText = "Điện Thoại";
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaKH.Text = dgvKhachHang.Rows[row].Cells[0].Value.ToString();
                txtTenKH.Text = dgvKhachHang.Rows[row].Cells[1].Value.ToString();
                txtDiaChi.Text = dgvKhachHang.Rows[row].Cells[2].Value.ToString();
                txtSDT.Text = dgvKhachHang.Rows[row].Cells[3].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //this.Hide();
            FChangeKhachHang fadd = new FChangeKhachHang();
            fadd.AddThongTin(new string[5] { btnAdd.Text, "", "", "", "" });
            fadd.MdiParent = main;
            fadd.main = main;
            this.Close();
            fadd.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FChangeKhachHang fadd = new FChangeKhachHang();
            fadd.AddThongTin(new string[5] { btnUpdate.Text, txtMaKH.Text, txtTenKH.Text, txtDiaChi.Text, txtSDT.Text });
            fadd.MdiParent = main;
            fadd.main = main;
            this.Close();
            fadd.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FChangeKhachHang fadd = new FChangeKhachHang();
            fadd.AddThongTin(new string[5] { btnDelete.Text, txtMaKH.Text, txtTenKH.Text, txtDiaChi.Text, txtSDT.Text });
            fadd.MdiParent = main;
            fadd.main = main;
            this.Close();
            fadd.Show();
        }

        private void FKhachHang_Load(object sender, EventArgs e)
        {
            //txtMaKH.Enabled = false;
            //txtTenKH.Enabled = false;
            //txtDiaChi.Enabled = false;
            //txtSDT.Enabled = false;

            dgvKhachHang.DataSource = Act.CreateTbKH();
            khoitaoluoi();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text == "---" || txtMaKH.Text == "")
            {
                KhachHang.MaKH = "%";
            }
            else
            {
                KhachHang.MaKH = txtMaKH.Text;
            }
            if (txtTenKH.Text == "---" || txtTenKH.Text == "")
            {
                KhachHang.TenKH = "%";
            }
            else
            {
                KhachHang.TenKH = txtTenKH.Text;
            }
            if (txtDiaChi.Text == "---" || txtDiaChi.Text == "")
            {
                KhachHang.DiaChi = "%";
            }
            else
            {
                KhachHang.DiaChi = txtDiaChi.Text;
            }
            if (txtSDT.Text == "---" || txtSDT.Text == "")
            {
                KhachHang.DienThoai = "%";
            }
            else
            {
                KhachHang.DienThoai = txtSDT.Text;
            }

            dgvKhachHang.DataSource = Act.CreateTbKH(KhachHang);
        }
    }
}
