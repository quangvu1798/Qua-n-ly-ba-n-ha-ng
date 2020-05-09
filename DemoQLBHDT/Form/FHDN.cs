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
using DemoQLBHDT.DTO.Component;
using DemoQLBHDT.DTO.EntitiesClass;

namespace DemoQLBHDT
{
    public partial class FHDN : Form
    {
        public FHDN()
        {
            InitializeComponent();
        }

        public MainForm main = new MainForm();

        ConnectDataBase Connect = new ConnectDataBase();
        C_HDN Act = new C_HDN();
        EC_HDN HDN = new EC_HDN();

        public void khoitaoluoi()
        {
            //RepositoryItemPictureEdit image = dgvHangHoa.RepositoryItems.Add("PictureEdit") as RepositoryItemPictureEdit;
            dgvHDN.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHDN.Columns[0].HeaderText = "Mã Hóa Đơn";
            dgvHDN.Columns[0].Frozen = true;
            dgvHDN.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvHDN.Columns[1].HeaderText = "Mã Nhân Viên";

            dgvHDN.Columns[2].HeaderText = "Ngày Nhập";

            dgvHDN.Columns[3].HeaderText = "Mã Nhà Cung Cấp";

            dgvHDN.Columns[4].HeaderText = "Tổng Tiền";

        }

        private void FHDN_Load(object sender, EventArgs e)
        {
            Act.LoadMaNCC(cbxMaNCC);
            Act.LoadTenNCC(cbxTenNCC);
            Act.LoadMaNV(cbxMaNV);
            Act.LoadTenNV(cbxTenNV);
            //cbxMaNV.Text = cbxMaNV.Text;
            cbxTenNV.Text = Act.LoadTenNV(cbxTenNV.Text, cbxMaNV.Text);
            dgvHDN.DataSource = Act.CreateTbHDN();
            khoitaoluoi();
        }

        private void dgvHDN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaHD.Text = dgvHDN.Rows[row].Cells[0].Value.ToString();
                cbxMaNV.Text = dgvHDN.Rows[row].Cells[1].Value.ToString();
                dtpNgayNhap.Text = dgvHDN.Rows[row].Cells[2].Value.ToString();
                cbxMaNCC.Text = dgvHDN.Rows[row].Cells[3].Value.ToString();
                txtTongTien.Text = dgvHDN.Rows[row].Cells[4].Value.ToString();
                cbxTenNCC.Text = Act.LoadTenNCC(cbxTenNCC.Text, cbxMaNCC.Text);                
                cbxTenNV.Text = Act.LoadTenNV(cbxTenNV.Text, cbxMaNV.Text);
            }
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            FCTHDN fchitiet = new FCTHDN();
            fchitiet.AddThongTin(new string[] { txtTongTien.Text, txtMaHD.Text, cbxMaNCC.Text, dtpNgayNhap.Text, cbxMaNV.Text });
            fchitiet.MdiParent = main;
            fchitiet.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa!", "Chú ý", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                HDN.SoHDN = txtMaHD.Text;
                HDN.MaNCC = cbxMaNCC.Text;
                HDN.NgayNhap = dtpNgayNhap.Text;
                HDN.MaNV = cbxMaNV.Text;
                HDN.TongTien = txtTongTien.Text;

                Act.DeleteHDN(HDN);
                MessageBox.Show("Đã Xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvHDN.DataSource = Act.CreateTbHDN();
            }
        }

        private void dtpNgayNhap_ValueChanged(object sender, EventArgs e)
        {
            txtNgayNhap.Text = dtpNgayNhap.Text;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text == "---" || txtMaHD.Text == "")
            {
                HDN.SoHDN = "%";
            }
            else
            {
                HDN.SoHDN = txtMaHD.Text;
            }

            if (txtNgayNhap.Text == "---" || txtNgayNhap.Text == "")
            {
                HDN.NgayNhap = "%";
            }
            else
            {
                HDN.NgayNhap = txtNgayNhap.Text;
            }

            if (txtTongTien.Text == "---" || txtTongTien.Text == "")
            {
                HDN.TongTien = "%";
            }
            else
            {
                HDN.TongTien = txtTongTien.Text;
            }

            if (cbxMaNV.Text == "---" || cbxMaNV.Text == "")
            {
                HDN.MaNV = "%";
            }
            else
            {
                HDN.MaNV = cbxMaNV.Text;
            }

            if(cbxMaNCC.Text == "---" || cbxMaNCC.Text == "")
            {
                HDN.MaNCC = "%";
            }
            else
            {
                HDN.MaNCC = cbxMaNCC.Text;
            }

            dgvHDN.DataSource = Act.CreateTbHDN(HDN);
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
