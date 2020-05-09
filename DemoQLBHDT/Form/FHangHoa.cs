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
    public partial class FHangHoa : Form
    {
        public FHangHoa()
        {
            InitializeComponent();
        }

        public MainForm main = new MainForm();

        public string Access = "";
        ConnectDataBase Connect = new ConnectDataBase();
        C_HangHoa Act = new C_HangHoa();
        EC_HangHoa HangHoa = new EC_HangHoa();

        public void khoitaoluoi()
        {
            //RepositoryItemPictureEdit image = dgvHangHoa.RepositoryItems.Add("PictureEdit") as RepositoryItemPictureEdit;
            dgvHangHoa.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHangHoa.Columns[0].HeaderText = "Mã Hàng";
            dgvHangHoa.Columns[0].Frozen = true;
            dgvHangHoa.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvHangHoa.Columns[1].HeaderText = "Tên Hàng";

            dgvHangHoa.Columns[2].HeaderText = "Mã Nhóm";

            dgvHangHoa.Columns[3].HeaderText = "Mã Đơn Vị";

            dgvHangHoa.Columns[4].HeaderText = "Mã Nước";

            //dgvHangHoa.Columns[5].HeaderText = "Số Lượng";

            dgvHangHoa.Columns[5].HeaderText = "Đơn Giá Nhập";

            dgvHangHoa.Columns[6].HeaderText = "Đơn Giá Bán";

            dgvHangHoa.Columns[7].HeaderText = "Ghi Chú";

        }

        private void FHangHoa_Load(object sender, EventArgs e)
        {
            //txtMaHangHoa.Enabled = false;
            //txtTenHangHoa.Enabled = false;
            //txtSoLuong.Enabled = false;
            //txtDGB.Enabled = false;
            //txtDGN.Enabled = false;
            //txtGhiChu.Enabled = false;
            //cbxTenNuocSX.Enabled = false;
            //cbxTenNhom.Enabled = false;
            //cbxDVT.Enabled = false;
            Act.LoadTenNhom(cbxTenNhom);
            Act.LoadTenDonViTinh(cbxTenDVT);
            Act.LoadTenNuocSX(cbxTenNuocSX);

            dgvHangHoa.DataSource = Act.CreateTbHH();
            khoitaoluoi();
        }

        private void dgvHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaHangHoa.Text = dgvHangHoa.Rows[row].Cells[0].Value.ToString();
                txtTenHangHoa.Text = dgvHangHoa.Rows[row].Cells[1].Value.ToString();
                labMaNhom.Text = dgvHangHoa.Rows[row].Cells[2].Value.ToString();
                labMaDVT.Text = dgvHangHoa.Rows[row].Cells[3].Value.ToString();
                labMaNuocSX.Text = dgvHangHoa.Rows[row].Cells[4].Value.ToString();
                //txtSoLuong.Text = dgvHangHoa.Rows[row].Cells[5].Value.ToString();
                txtDGN.Text = dgvHangHoa.Rows[row].Cells[5].Value.ToString();
                txtDGB.Text = dgvHangHoa.Rows[row].Cells[6].Value.ToString();
                txtGhiChu.Text = dgvHangHoa.Rows[row].Cells[7].Value.ToString();
                cbxTenDVT.Text = Act.LoadTenDonViTinh(cbxTenDVT.Text, labMaDVT.Text);
                cbxTenNhom.Text = Act.LoadTenNhom(cbxTenNhom.Text, labMaNhom.Text);
                cbxTenNuocSX.Text = Act.LoadTenNuocSX(cbxTenNuocSX.Text, labMaNuocSX.Text);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //this.Hide();
            FChangeHangHoa fadd = new FChangeHangHoa();
            fadd.AddThongTin(new string[] { btnAdd.Text, "", "", "", "", "", "", "", "" });
            fadd.MdiParent = main;
            fadd.main = main;
            this.Close();
            fadd.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FChangeHangHoa fadd = new FChangeHangHoa();
            fadd.AddThongTin(new string[] { btnUpdate.Text, txtMaHangHoa.Text, txtTenHangHoa.Text, labMaNhom.Text, labMaDVT.Text,
                labMaNuocSX.Text, txtDGN.Text, txtDGB.Text, txtGhiChu.Text });
            fadd.MdiParent = main;
            fadd.main = main;
            this.Close();
            fadd.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FChangeHangHoa fadd = new FChangeHangHoa();
            fadd.AddThongTin(new string[] { btnDelete.Text, txtMaHangHoa.Text, txtTenHangHoa.Text, labMaNhom.Text, labMaDVT.Text,
                labMaNuocSX.Text, txtDGN.Text, txtDGB.Text, txtGhiChu.Text });
            fadd.MdiParent = main;
            fadd.main = main;
            this.Close();
            fadd.Show();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtMaHangHoa.Text == "---" || txtMaHangHoa.Text == "")
            {
                HangHoa.MaHangHoa = "%";
            }
            else
            {
                HangHoa.MaHangHoa = txtMaHangHoa.Text;
            }

            if (txtTenHangHoa.Text == "---" || txtTenHangHoa.Text == "")
            {
                HangHoa.TenHangHoa = "%";
            }
            else
            {
                HangHoa.TenHangHoa = txtTenHangHoa.Text;
            }

            if (labMaNhom.Text == "---" || labMaNhom.Text == "")
            {
                HangHoa.MaNhom = "%";
            }
            else
            {
                HangHoa.MaNhom = labMaNhom.Text;
            }

            if (labMaDVT.Text == "---" || labMaDVT.Text == "")
            {
                HangHoa.MaDonVi = "%";
            }
            else
            {
                HangHoa.MaDonVi = labMaDVT.Text;
            }

            if (labMaNuocSX.Text == "---" || labMaNuocSX.Text == "")
            {
                HangHoa.MaNuoc = "%";
            }
            else
            {
                HangHoa.MaNuoc = labMaNuocSX.Text;
            }

            
            if (txtGhiChu.Text == "---" || txtGhiChu.Text == "")
            {
                HangHoa.GhiChu = "%";
            }
            else
            {
                HangHoa.GhiChu = txtGhiChu.Text;
            }

            if (txtDGN.Text == "---" || txtDGN.Text == "")
            {
                HangHoa.DonGiaNhap = "%";
            }
            else
            {
                HangHoa.DonGiaNhap = txtDGN.Text;
            }

            if (txtDGB.Text == "---" || txtDGB.Text == "")
            {
                HangHoa.DonGiaBan = "%";
            }
            else
            {
                HangHoa.DonGiaBan = txtDGB.Text;
            }

            dgvHangHoa.DataSource = Act.CreateTbHH(HangHoa);
        }

        private void cbxTenNhom_SelectedIndexChanged(object sender, EventArgs e)
        {
            labMaNhom.Text = Act.LoadMaNhom(labMaNhom.Text, cbxTenNhom.Text);
        }

        private void cbxDVT_SelectedIndexChanged(object sender, EventArgs e)
        {
            labMaDVT.Text = Act.LoadMaDonViTinh(labMaDVT.Text, cbxTenDVT.Text);
        }

        private void cbxTenNuocSX_SelectedIndexChanged(object sender, EventArgs e)
        {
            labMaNuocSX.Text = Act.LoadMaNuocSX(labMaNuocSX.Text, cbxTenNuocSX.Text);
        }
    }
}
