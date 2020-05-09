using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoQLBHDT.DTO.Component;
using DemoQLBHDT.DTO.EntitiesClass;
using DemoQLBHDT.DAO;

namespace DemoQLBHDT
{
    public partial class FTaiKhoan : Form
    {
        public FTaiKhoan()
        {
            InitializeComponent();
        }

        public MainForm main = new MainForm();

        C_User Act = new C_User();
        EC_User User = new EC_User();
        ConnectDataBase Connect = new ConnectDataBase();

        public void khoitaoluoi()
        {
            dgvTK.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTK.Columns[0].HeaderText = "Username";
            dgvTK.Columns[0].Frozen = true;
            dgvTK.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvTK.Columns[1].HeaderText = "Password";
            dgvTK.Columns[2].HeaderText = "Phân Quyền";
            dgvTK.Columns[3].HeaderText = "Mã Nhân Viên";
        }

        private void FTaiKhoan_Load(object sender, EventArgs e)
        {
            Act.LoadTenNV(cbxTenNV);
            dgvTK.DataSource = Act.CreateTbUser();
            khoitaoluoi();
        }

        private void dgvTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtUserName.Text = dgvTK.Rows[row].Cells[0].Value.ToString();
                txtPass.Text = dgvTK.Rows[row].Cells[1].Value.ToString();
                cbxQuyen.Text = dgvTK.Rows[row].Cells[2].Value.ToString();
                labMaNV.Text = dgvTK.Rows[row].Cells[3].Value.ToString();
                cbxTenNV.Text = Act.LoadTenNV(cbxTenNV.Text, labMaNV.Text);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FChangeTaiKhoan fadd = new FChangeTaiKhoan();
            fadd.AddThongTin(new string[] { "Thêm", "", "", "", "" });
            fadd.MdiParent = main;
            fadd.main = main;
            this.Close();
            fadd.Show();
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FChangeTaiKhoan fupdate = new FChangeTaiKhoan();
            fupdate.AddThongTin(new string[] { "Sửa", txtUserName.Text, txtPass.Text, cbxQuyen.Text, labMaNV.Text });
            fupdate.MdiParent = main;
            fupdate.main = main;
            this.Close();
            fupdate.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FChangeTaiKhoan fdelete = new FChangeTaiKhoan();
            fdelete.AddThongTin(new string[] { "Xóa", txtUserName.Text, txtPass.Text, cbxQuyen.Text, labMaNV.Text });
            fdelete.MdiParent = main;
            fdelete.main = main;
            this.Close();
            fdelete.Show();
        }
    }
}
