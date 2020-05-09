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
    public partial class FDonDH : Form
    {
        public FDonDH()
        {
            InitializeComponent();
        }

        public MainForm main = new MainForm();

        ConnectDataBase Connect = new ConnectDataBase();
        C_DonDH Act = new C_DonDH();
        EC_DonDH DonDH = new EC_DonDH();

        public void khoitaoluoi()
        {
            //RepositoryItemPictureEdit image = dgvHangHoa.RepositoryItems.Add("PictureEdit") as RepositoryItemPictureEdit;
            dgvDonDH.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDonDH.Columns[0].HeaderText = "Mã Đơn";
            dgvDonDH.Columns[0].Frozen = true;
            dgvDonDH.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDonDH.Columns[1].HeaderText = "Mã Khách Hàng";

            dgvDonDH.Columns[2].HeaderText = "Ngày Đặt";
        }

        private void FDonDH_Load(object sender, EventArgs e)
        {
            Act.LoadTenKH(cbxTenKH);
            Act.LoadMaKH(cbxMaKH);
            
            dgvDonDH.DataSource = Act.CreateTbDonDH();
            //var topLeftHeaderCell = dgvDonDH.TopLeftHeaderCell;
            khoitaoluoi();
        }

        private void dgvDonDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaDonDH.Text = dgvDonDH.Rows[row].Cells[0].Value.ToString();
                cbxMaKH.Text = dgvDonDH.Rows[row].Cells[1].Value.ToString();
                dtpNgayDat.Text = dgvDonDH.Rows[row].Cells[2].Value.ToString();
                cbxTenKH.Text = Act.LoadTenKH(cbxTenKH.Text, cbxMaKH.Text);
                txtDiaChi.Text = Act.LoadDiaChi(txtDiaChi.Text, cbxMaKH.Text);
            }
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            FCTDonDH fchitiet = new FCTDonDH();
            fchitiet.AddThongTin(new string[] { txtMaDonDH.Text, cbxMaKH.Text, txtNgayDat.Text });
            fchitiet.MdiParent = main;
            fchitiet.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa!", "Chú ý", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                DonDH.MaDonDH = txtMaDonDH.Text;
                DonDH.MaKH = cbxMaKH.Text;
                DonDH.NgayDat = dtpNgayDat.Text;
                try
                {
                    Act.DeleteDonDH(DonDH);
                    MessageBox.Show("Đã Xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvDonDH.DataSource = Act.CreateTbDonDH();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void dtpNgayDat_ValueChanged(object sender, EventArgs e)
        {
            txtNgayDat.Text = dtpNgayDat.Text;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if(txtMaDonDH.Text == "---"||txtMaDonDH.Text =="")
            {
                DonDH.MaDonDH = "%";
            }
            else
            {
                DonDH.MaDonDH = txtMaDonDH.Text;
            }

            if (txtNgayDat.Text == "---" || txtNgayDat.Text == "") 
            {
                DonDH.NgayDat = "%";
            }
            else
            {
                DonDH.NgayDat = txtNgayDat.Text;
            }

            if(cbxMaKH.Text == "---"|| cbxMaKH.Text == "")
            {
                DonDH.MaKH = "%";
            }
            else
            {
                DonDH.MaKH = cbxMaKH.Text;
            }

            dgvDonDH.DataSource = Act.CreateTbDonDH(DonDH);
        }

        private void cbxMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxTenKH.Text = Act.LoadTenKH(cbxTenKH.Text, cbxMaKH.Text);
            txtDiaChi.Text = Act.LoadDiaChi(txtDiaChi.Text, cbxMaKH.Text);
        }

        private void cbxTenKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxMaKH.Text = Act.LoadMaKH(cbxMaKH.Text, cbxTenKH.Text);
        }
    }
}
