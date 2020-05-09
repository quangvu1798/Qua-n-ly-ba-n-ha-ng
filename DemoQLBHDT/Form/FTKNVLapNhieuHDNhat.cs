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
    public partial class FTKNVLapNhieuHDNhat : Form
    {
        public FTKNVLapNhieuHDNhat()
        {
            InitializeComponent();
        }

        public string TieuDe = "";

        C_ThongKe ActTK = new C_ThongKe();
        C_NhanVien ActNV = new C_NhanVien();

        public void khoitaoluoi()
        {
            //RepositoryItemPictureEdit image = dgvHangHoa.RepositoryItems.Add("PictureEdit") as RepositoryItemPictureEdit;
            dgvNhanVien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvNhanVien.Columns[0].HeaderText = "Mã Nhân Viên";
            dgvNhanVien.Columns[0].Frozen = true;
            dgvNhanVien.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvNhanVien.Columns[1].HeaderText = "Tên Nhân Viên";

            dgvNhanVien.Columns[2].HeaderText = "Giới Tính";

            dgvNhanVien.Columns[3].HeaderText = "Ngày Sinh";

            dgvNhanVien.Columns[4].HeaderText = "Điện Thoại";

            dgvNhanVien.Columns[5].HeaderText = "Quê Quán";

            dgvNhanVien.Columns[6].HeaderText = "Ghi Chú";

            dgvNhanVien.Columns[7].HeaderText = "Mã Ca";

            dgvNhanVien.Columns[8].HeaderText = "Mã Công Việc";

        }

        private void FTKNVLapNhieuHDNhat_Load(object sender, EventArgs e)
        {
            labTieuDe.Text = TieuDe;
            if(TieuDe == "Nhân Viên Lập Nhiều Hóa Đơn Bán Nhất")
            {
                dgvNhanVien.DataSource = ActTK.NVLapNhieuHDBNhat();
            }
            else
            {
                dgvNhanVien.DataSource = ActTK.NVLapNhieuHDNNhat();
            }
            khoitaoluoi();
            txtMaNV.Text = dgvNhanVien.Rows[0].Cells[0].Value.ToString();
            txtTenNV.Text = dgvNhanVien.Rows[0].Cells[1].Value.ToString();
            cbxGioiTinh.Text = dgvNhanVien.Rows[0].Cells[2].Value.ToString();
            dtpNgaySinh.Text = dgvNhanVien.Rows[0].Cells[3].Value.ToString();
            txtSDT.Text = dgvNhanVien.Rows[0].Cells[4].Value.ToString(); ;
            txtDiaChi.Text = dgvNhanVien.Rows[0].Cells[5].Value.ToString();
            txtGhiChu.Text = dgvNhanVien.Rows[0].Cells[6].Value.ToString();
            labMaCa.Text = dgvNhanVien.Rows[0].Cells[7].Value.ToString();
            labMaCV.Text = dgvNhanVien.Rows[0].Cells[8].Value.ToString();
            cbxTenCa.Text = ActNV.LoadTenCa(cbxTenCa.Text, labMaCa.Text);
            cbxTenCV.Text = ActNV.LoadTenCV(cbxTenCV.Text, labMaCV.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
