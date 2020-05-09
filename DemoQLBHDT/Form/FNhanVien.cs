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
using System.Data.SqlClient;

namespace DemoQLBHDT
{
    public partial class FNhanVien : Form
    {
        public FNhanVien()
        {
            InitializeComponent();
        }

        public MainForm main = new MainForm();
        public string Access = "";
        ConnectDataBase Connect = new ConnectDataBase();
        C_NhanVien Act = new C_NhanVien();
        EC_NhanVien NhanVien = new EC_NhanVien();

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

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaNV.Text = dgvNhanVien.Rows[row].Cells[0].Value.ToString();
                txtTenNV.Text = dgvNhanVien.Rows[row].Cells[1].Value.ToString();
                dtpNgaySinh.Text = dgvNhanVien.Rows[row].Cells[3].Value.ToString();
                cbxGioiTinh.Text = dgvNhanVien.Rows[row].Cells[2].Value.ToString();
                txtSDT.Text = dgvNhanVien.Rows[row].Cells[4].Value.ToString();
                txtDiaChi.Text = dgvNhanVien.Rows[row].Cells[5].Value.ToString();
                txtGhiChu.Text = dgvNhanVien.Rows[row].Cells[6].Value.ToString();
                labMaCa.Text = dgvNhanVien.Rows[row].Cells[7].Value.ToString();
                labMaCV.Text = dgvNhanVien.Rows[row].Cells[8].Value.ToString();
                cbxTenCa.Text = Act.LoadTenCa(cbxTenCa.Text, labMaCa.Text);
                cbxTenCV.Text = Act.LoadTenCV(cbxTenCV.Text, labMaCV.Text);
            }
            else
            { }
        }

        private void FNhanVien_Load(object sender, EventArgs e)
        {
            //txtMaNV.Enabled = false;
            //txtTenNV.Enabled = false;
            //dtpNgaySinh.Enabled = false;
            //cbxGioiTinh.Enabled = false;
            //txtSDT.Enabled = false;
            //txtGhiChu.Enabled = false;
            //cbxTenCa.Enabled = false;
            //cbxTenCV.Enabled = false;
            //txtDiaChi.Enabled = false;
            Act.LoadTenCa(cbxTenCa);
            Act.LoadTenCV(cbxTenCV);            
            
            dgvNhanVien.DataSource = Act.CreateTbNV();
            khoitaoluoi();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //this.Hide();
            FChangeNhanVien fadd = new FChangeNhanVien();
            fadd.AddThongTin(new string[] { btnAdd.Text, "", "", "", "", "", "", "", "", "" });
            this.Close();
            fadd.MdiParent = main;
            fadd.main = main;
            fadd.Show();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "---" || txtMaNV.Text == "")
            {
                NhanVien.MaNhanVien = "%";
            }
            else
            {
                NhanVien.MaNhanVien = txtMaNV.Text;
            }

            if (txtTenNV.Text == "---" || txtTenNV.Text == "")
            {
                NhanVien.TenNhanVien = "%";
            }
            else
            {
                NhanVien.TenNhanVien = txtTenNV.Text;
            }

            if (cbxGioiTinh.Text == "---" || cbxGioiTinh.Text == "")
            {
                NhanVien.GioiTinh = "%";
            }
            else
            {
                NhanVien.GioiTinh = cbxGioiTinh.Text;
            }

            if (txtNgaySinh.Text == "" ||txtNgaySinh.Text == "---")
            {
                NhanVien.NgaySinh = "%";
            }
            else
            {
                NhanVien.NgaySinh = txtNgaySinh.Text;
            }

            if (txtSDT.Text == "---" || txtSDT.Text == "")
            {
                NhanVien.DienThoai = "%";
            }
            else
            {
                NhanVien.DienThoai = txtSDT.Text;
            }

            if (txtDiaChi.Text == "---" || txtDiaChi.Text == "")
            {
                NhanVien.DiaChi = "%";
            }
            else
            {
                NhanVien.DiaChi = txtDiaChi.Text;
            }

            if (txtGhiChu.Text == "---" || txtGhiChu.Text == "")
            {
                NhanVien.GhiChu = "%";
            }
            else
            {
                NhanVien.GhiChu = txtGhiChu.Text;
            }

            if (labMaCa.Text == "---" || labMaCa.Text == "")
            {
                NhanVien.MaCa = "%";
            }
            else
            {
                NhanVien.MaCa = labMaCa.Text;
            }

            if (labMaCV.Text == "---" || labMaCV.Text == "")
            {
                NhanVien.MaCV = "%";
            }
            else
            {
                NhanVien.MaCV = labMaCV.Text;
            }
             dgvNhanVien.DataSource = Act.CreateTbNV(NhanVien);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FChangeNhanVien fadd = new FChangeNhanVien();
            fadd.AddThongTin(new string[] { btnUpdate.Text, txtMaNV.Text, txtTenNV.Text, dtpNgaySinh.Text,
                cbxGioiTinh.Text, txtSDT.Text, txtDiaChi.Text, txtGhiChu.Text, labMaCa.Text, labMaCV.Text });
            this.Close();
            fadd.MdiParent = main;
            fadd.main = main;
            fadd.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FChangeNhanVien fadd = new FChangeNhanVien();
            fadd.AddThongTin(new string[] { btnDelete.Text, txtMaNV.Text, txtTenNV.Text, dtpNgaySinh.Text,
                cbxGioiTinh.Text, txtSDT.Text, txtDiaChi.Text, txtGhiChu.Text, labMaCa.Text, labMaCV.Text });
            this.Close();
            fadd.MdiParent = main;
            fadd.main = main;
            fadd.Show();
        }

        private void cbxTenCa_SelectedIndexChanged(object sender, EventArgs e)
        {
            labMaCa.Text = Act.LoadMaCa(labMaCa.Text, cbxTenCa.Text);
        }

        private void cbxTenCV_SelectedIndexChanged(object sender, EventArgs e)
        {
            labMaCV.Text = Act.LoadMaCV(labMaCV.Text, cbxTenCV.Text);
        }

        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e)
        {
            txtNgaySinh.Text = dtpNgaySinh.Text;
        }
    }
}
