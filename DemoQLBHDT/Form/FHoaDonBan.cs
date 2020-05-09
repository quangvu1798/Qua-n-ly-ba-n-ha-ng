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
    public partial class FHoaDonBan : Form
    {
        public FHoaDonBan()
        {
            InitializeComponent();
        }

        public MainForm main = new MainForm();

        ConnectDataBase Connect = new ConnectDataBase();
        C_HoaDonBan Act = new C_HoaDonBan();
        EC_HoaDonBan HDB = new EC_HoaDonBan();

        public void khoitaoluoi()
        {
            //RepositoryItemPictureEdit image = dgvHangHoa.RepositoryItems.Add("PictureEdit") as RepositoryItemPictureEdit;
            dgvHDB.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHDB.Columns[0].HeaderText = "Mã Hóa Đơn";
            dgvHDB.Columns[0].Frozen = true;
            dgvHDB.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvHDB.Columns[1].HeaderText = "Mã Nhân Viên";

            dgvHDB.Columns[2].HeaderText = "Ngày Lập";

            dgvHDB.Columns[3].HeaderText = "Mã Khách Hàng";

            dgvHDB.Columns[4].HeaderText = "Tổng Tiền";

        }

        private void FHoaDonBan_Load(object sender, EventArgs e)
        {
            Act.LoadMaKH(cbxMaKH);
            Act.LoadTenKH(cbxTenKH);
            Act.LoadMaNV(cbxMaNV);
            Act.LoadTenNV(cbxTenNV);
            //cbxMaNV.Text = cbxMaNV.Text;
            cbxTenNV.Text = Act.LoadTenNV(cbxTenNV.Text, cbxMaNV.Text);
            dgvHDB.DataSource = Act.CreateTbHDB();
            khoitaoluoi();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc muốn xóa!","Chú ý",MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                HDB.SoHDB = txtMaHD.Text;
                HDB.MaNV = cbxMaNV.Text;
                HDB.NgayLap = dtpNgayLap.Text;
                HDB.MaKH = cbxMaKH.Text;
                HDB.TongTien = txtTongTien.Text;
                
                Act.DeleteHDB(HDB);                
                MessageBox.Show("Đã Xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvHDB.DataSource = Act.CreateTbHDB();
            }
        }

        private void dgvHDB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if(row >= 0)
            {
                txtMaHD.Text = dgvHDB.Rows[row].Cells[0].Value.ToString();
                cbxMaNV.Text = dgvHDB.Rows[row].Cells[1].Value.ToString();
                dtpNgayLap.Text = dgvHDB.Rows[row].Cells[2].Value.ToString();
                cbxMaKH.Text = dgvHDB.Rows[row].Cells[3].Value.ToString();
                txtTongTien.Text = dgvHDB.Rows[row].Cells[4].Value.ToString();
                cbxTenKH.Text = Act.LoadTenKH(cbxTenKH.Text, cbxMaKH.Text);
                txtDiaChi.Text = Act.LoadDiaChi(txtDiaChi.Text, cbxMaKH.Text);
                cbxTenNV.Text = Act.LoadTenNV(cbxTenNV.Text, cbxMaNV.Text);
            }
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            FChangeHDB fchitiet = new FChangeHDB();
            fchitiet.AddThongTin(new string[] { txtTongTien.Text, txtMaHD.Text, cbxMaNV.Text, dtpNgayLap.Text, cbxMaKH.Text });
            fchitiet.MdiParent = main;
            fchitiet.Show();
        }

        private void dtpNgayLap_ValueChanged(object sender, EventArgs e)
        {
            txtNgayLap.Text = dtpNgayLap.Text;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text == "---" || txtMaHD.Text == "")
            {
                HDB.SoHDB = "%";
            }
            else
            {
                HDB.SoHDB = txtMaHD.Text;
            }

            if (txtNgayLap.Text == "---" || txtNgayLap.Text == "")
            {
                HDB.NgayLap = "%";
            }
            else
            {
                HDB.NgayLap = txtNgayLap.Text;
            }

            if (txtTongTien.Text == "---" || txtTongTien.Text == "")
            {
                HDB.TongTien = "%";
            }
            else
            {
                HDB.TongTien = txtTongTien.Text;
            }

            if (cbxMaNV.Text == "---" || cbxMaNV.Text == "")
            {
                HDB.MaNV = "%";
            }
            else
            {
                HDB.MaNV = cbxMaNV.Text;
            }

            if (cbxMaKH.Text == "---" || cbxMaKH.Text == "")
            {
                HDB.MaKH = "%";
            }
            else
            {
                HDB.MaKH = cbxMaKH.Text;
            }

            dgvHDB.DataSource = Act.CreateTbHDB(HDB);
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
