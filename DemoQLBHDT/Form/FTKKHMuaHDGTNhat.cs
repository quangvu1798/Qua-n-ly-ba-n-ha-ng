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

namespace DemoQLBHDT
{
    public partial class FTKKHMuaHDGTNhat : Form
    {
        public FTKKHMuaHDGTNhat()
        {
            InitializeComponent();
        }

        public string TieuDe = "";

        C_ThongKe ActTK = new C_ThongKe();

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

        private void FTKKHMuaHDGTNhat_Load(object sender, EventArgs e)
        {
            labTieuDe.Text = TieuDe;
            if (TieuDe == "TOP 5 KHÁCH HÀNG CÓ HÓA ĐƠN GIÁ TRỊ NHẤT")
            {
                dgvKhachHang.DataSource = ActTK.KHMuaHDGTNhat();
            }
            else
            {
                dgvKhachHang.DataSource = ActTK.KHMuaNhieuLanNhat();
            }
            khoitaoluoi();
            txtMaKH.Text = dgvKhachHang.Rows[0].Cells[0].Value.ToString();
            txtTenKH.Text = dgvKhachHang.Rows[0].Cells[1].Value.ToString();
            txtSDT.Text = dgvKhachHang.Rows[0].Cells[2].Value.ToString();
            txtDiaChi.Text = dgvKhachHang.Rows[0].Cells[3].Value.ToString();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
