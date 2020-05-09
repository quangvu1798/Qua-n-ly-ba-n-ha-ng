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
    public partial class FTKSPBanChayNhat : Form
    {
        public FTKSPBanChayNhat()
        {
            InitializeComponent();
        }

        public string TieuDe = "";

        C_HangHoa ActHH = new C_HangHoa();
        C_ThongKe ActTK = new C_ThongKe();

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

        private void FTKSPBanChayNhat_Load(object sender, EventArgs e)
        {
            labTieuDe.Text = TieuDe;
            if (TieuDe == "Sản Phẩm Bán Chạy Nhất")
            {
                dgvHangHoa.DataSource = ActTK.SPBanChayNhat();
            }
            else if(TieuDe == "Sản Phẩm Bán Chậm Nhất")
            {
                dgvHangHoa.DataSource = ActTK.SPBanChamNhat();
            }
            else
            {
                dgvHangHoa.DataSource = ActTK.SPChuaBan();
            }
            khoitaoluoi();
            txtMaHangHoa.Text = dgvHangHoa.Rows[0].Cells[0].Value.ToString();
            txtTenHangHoa.Text = dgvHangHoa.Rows[0].Cells[1].Value.ToString();
            labMaNhom.Text = dgvHangHoa.Rows[0].Cells[2].Value.ToString();
            labMaDVT.Text = dgvHangHoa.Rows[0].Cells[3].Value.ToString();
            labMaNuocSX.Text = dgvHangHoa.Rows[0].Cells[4].Value.ToString();
            txtDGN.Text = dgvHangHoa.Rows[0].Cells[5].Value.ToString();
            txtDGB.Text = dgvHangHoa.Rows[0].Cells[6].Value.ToString();
            txtGhiChu.Text = dgvHangHoa.Rows[0].Cells[7].Value.ToString();
            cbxTenNhom.Text = ActHH.LoadTenNhom(cbxTenNhom.Text, labMaNhom.Text);
            cbxTenDVT.Text = ActHH.LoadTenDonViTinh(cbxTenDVT.Text, labMaDVT.Text);
            cbxTenNuocSX.Text = ActHH.LoadTenNuocSX(cbxTenNuocSX.Text, labMaNuocSX.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
                cbxTenDVT.Text = ActHH.LoadTenDonViTinh(cbxTenDVT.Text, labMaDVT.Text);
                cbxTenNhom.Text = ActHH.LoadTenNhom(cbxTenNhom.Text, labMaNhom.Text);
                cbxTenNuocSX.Text = ActHH.LoadTenNuocSX(cbxTenNuocSX.Text, labMaNuocSX.Text);
            }
        }
    }
}
