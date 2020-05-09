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
    public partial class FDonViTinh : Form
    {
        public FDonViTinh()
        {
            InitializeComponent();
        }
        public MainForm main = new MainForm();
        public string Access = "";

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //this.Hide();
            FChangeDonViTinh fadd = new FChangeDonViTinh();
            fadd.AddThongTin(new string[] { btnAdd.Text, "", "" });
            fadd.MdiParent = main;
            fadd.main = main;
            this.Close();
            fadd.Show();
        }

        ConnectDataBase Connect = new ConnectDataBase();
        EC_DonViTinh DonViTinh = new EC_DonViTinh();
        C_DonViTinh Act = new C_DonViTinh();

        public void khoitaoluoi()
        {
            dgvDonViTinh.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDonViTinh.Columns[0].HeaderText = "Mã Đơn Vị";
            dgvDonViTinh.Columns[0].Frozen = true;
            dgvDonViTinh.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDonViTinh.Columns[1].HeaderText = "Tên Đơn Vị";
        }

        private void FDonViTinh_Load(object sender, EventArgs e)
        {
            dgvDonViTinh.DataSource = Act.CreateTbDVT();
            khoitaoluoi();
        }

        private void dgvDonViTinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaDVT.Text = dgvDonViTinh.Rows[row].Cells[0].Value.ToString();
                txtTenDonVi.Text = dgvDonViTinh.Rows[row].Cells[1].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FChangeDonViTinh fadd = new FChangeDonViTinh();
            fadd.AddThongTin(new string[] { btnUpdate.Text, txtMaDVT.Text, txtTenDonVi.Text });
            fadd.MdiParent = main;
            fadd.main = main;
            this.Close();
            fadd.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FChangeDonViTinh fadd = new FChangeDonViTinh();
            fadd.AddThongTin(new string[] { btnDelete.Text, txtMaDVT.Text, txtTenDonVi.Text });
            fadd.MdiParent = main;
            fadd.main = main;
            this.Close();
            fadd.ShowDialog();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtMaDVT.Text == "---" || txtMaDVT.Text =="")
            {
                DonViTinh.MaDonViTinh = "%";
            }
            else
            {
                DonViTinh.MaDonViTinh = txtMaDVT.Text;
            }
            if (txtTenDonVi.Text == "---" || txtTenDonVi.Text == "")
            {
                DonViTinh.TenDonViTinh = "%";
            }
            else
            {
                DonViTinh.TenDonViTinh = txtTenDonVi.Text;
            }

            dgvDonViTinh.DataSource = Act.CreateTbDVT(DonViTinh);
        }
    }
}
