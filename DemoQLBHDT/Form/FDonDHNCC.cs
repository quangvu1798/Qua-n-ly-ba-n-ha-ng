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
using DemoQLBHDT.DAO;
using DemoQLBHDT.DTO.EntitiesClass;

namespace DemoQLBHDT
{
    public partial class FDonDHNCC : Form
    {
        public FDonDHNCC()
        {
            InitializeComponent();
        }

        public MainForm main = new MainForm();

        ConnectDataBase Connect = new ConnectDataBase();
        C_DonDHNCC Act = new C_DonDHNCC();
        EC_DonDHNCC DonDHNCC = new EC_DonDHNCC();

        public void khoitaoluoi()
        {
            //RepositoryItemPictureEdit image = dgvHangHoa.RepositoryItems.Add("PictureEdit") as RepositoryItemPictureEdit;
            dgvDonDHNCC.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDonDHNCC.Columns[0].HeaderText = "Mã Đơn";
            dgvDonDHNCC.Columns[0].Frozen = true;
            dgvDonDHNCC.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDonDHNCC.Columns[1].HeaderText = "Mã Nhà Cung Cấp";

            dgvDonDHNCC.Columns[2].HeaderText = "Ngày Đặt";

            dgvDonDHNCC.Columns[3].HeaderText = "Mã Nhân Viên";

        }

        private void FDonDHNCC_Load(object sender, EventArgs e)
        {
            Act.LoadMaNCC(cbxMaNCC);
            Act.LoadMaNV(cbxMaNV);
            Act.LoadTenNCC(cbxTenNCC);
            Act.LoadTenNV(cbxTenNV);
            cbxTenNV.Text = Act.LoadTenNV(cbxTenNV.Text, cbxMaNV.Text);
            dgvDonDHNCC.DataSource = Act.CreateTbDonDHNCC();
            khoitaoluoi();
        }

        private void dgvDonDHNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaDonDHNCC.Text = dgvDonDHNCC.Rows[row].Cells[0].Value.ToString();
                cbxMaNCC.Text = dgvDonDHNCC.Rows[row].Cells[1].Value.ToString();
                dtpNgayDat.Text = dgvDonDHNCC.Rows[row].Cells[2].Value.ToString();
                cbxMaNV.Text = dgvDonDHNCC.Rows[row].Cells[3].Value.ToString();
                cbxTenNCC.Text = Act.LoadTenNCC(cbxTenNCC.Text, cbxMaNCC.Text);
                cbxTenNV.Text = Act.LoadTenNV(cbxTenNV.Text, cbxMaNV.Text);
            }
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            FCTDonDHNCC fchitiet = new FCTDonDHNCC();
            fchitiet.AddThongTin(new string[] { txtMaDonDHNCC.Text, cbxMaNCC.Text, txtNgayDat.Text, cbxMaNV.Text });
            fchitiet.MdiParent = main;
            fchitiet.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa!", "Chú ý", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DonDHNCC.MaDonDHNCC = txtMaDonDHNCC.Text;
                DonDHNCC.MaNCC = cbxMaNCC.Text;
                DonDHNCC.NgayDat = dtpNgayDat.Text;
                DonDHNCC.MaNV = cbxMaNV.Text;
                

                Act.DeleteDonDHNCC(DonDHNCC);
                MessageBox.Show("Đã Xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvDonDHNCC.DataSource = Act.CreateTbDonDHNCC();
            }
        }

        private void dtpNgayDat_ValueChanged(object sender, EventArgs e)
        {
            txtNgayDat.Text = dtpNgayDat.Text;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtMaDonDHNCC.Text == "---" || txtMaDonDHNCC.Text == "")
            {
                DonDHNCC.MaDonDHNCC = "%";
            }
            else
            {
                DonDHNCC.MaDonDHNCC = txtMaDonDHNCC.Text;
            }

            if (txtNgayDat.Text == "---" || txtNgayDat.Text == "")
            {
                DonDHNCC.NgayDat = "%";
            }
            else
            {
                DonDHNCC.NgayDat = txtNgayDat.Text;
            }

            if (cbxMaNCC.Text == "---" || cbxMaNCC.Text == "")
            {
                DonDHNCC.MaNCC = "%";
            }
            else
            {
                DonDHNCC.MaNCC = cbxMaNCC.Text;
            }

            if(cbxMaNV.Text == "---"||cbxMaNV.Text == "")
            {
                DonDHNCC.MaNV = "%";
            }
            else
            {
                DonDHNCC.MaNV = cbxMaNV.Text;
            }

            dgvDonDHNCC.DataSource = Act.CreateTbDonDHNCC(DonDHNCC);
        }

        private void cbxMaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxTenNCC.Text = Act.LoadTenNCC(cbxTenNCC.Text, cbxMaNCC.Text);
        }

        private void cbxTenNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxMaNCC.Text = Act.LoadMaNCC(cbxMaNCC.Text, cbxTenNCC.Text);
        }

        private void cbxMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxTenNV.Text = Act.LoadTenNV(cbxTenNV.Text, cbxMaNV.Text);
        }

        private void cbxTenNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxMaNV.Text = Act.LoadMaNV(cbxMaNV.Text, cbxTenNV.Text);
        }
    }
}
