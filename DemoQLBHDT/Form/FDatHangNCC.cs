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
    public partial class FDatHangNCC : Form
    {
        public FDatHangNCC()
        {
            InitializeComponent();
        }

        ConnectDataBase Connect = new ConnectDataBase();
        C_AutoID AutoID = new C_AutoID();
        C_DonDHNCC Act = new C_DonDHNCC();
        EC_DonDHNCC DonDHNCC = new EC_DonDHNCC();
        C_CTDonDHNCC ActChiTiet = new C_CTDonDHNCC();
        
        List<EC_CTDonDHNCC> CTDonDHNCCs = new List<EC_CTDonDHNCC>();
        public EC_User User;

        private void FDatHangNCC_Load(object sender, EventArgs e)
        {
            Act.LoadMaHH(cbxMaHH);
            Act.LoadMaNCC(cbxMaNCC);
            Act.LoadMaNV(cbxMaNV);
            Act.LoadTenNCC(cbxTenNCC);
            Act.LoadTenNV(cbxTenNV);
            cbxMaNV.Text = User.MaNV;
            cbxTenNV.Text = Act.LoadTenNV(cbxTenNV.Text, cbxMaNV.Text);
            txtMaDonDHNCC.Text = AutoID.TaoMa(3);
        }

        private void cbxMaHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTenHH.Text = Act.LoadTenHH(txtTenHH.Text, cbxMaHH.Text);
            labMaDVT.Text = Act.LoadMaDonViTinh(labMaDVT.Text, cbxMaHH.Text);
            txtTenDVT.Text = Act.LoadTenDonViTinh(txtTenDVT.Text, labMaDVT.Text);
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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                DonDHNCC.MaDonDHNCC = txtMaDonDHNCC.Text;
                DonDHNCC.MaNCC = cbxMaNCC.Text;
                DonDHNCC.NgayDat = dtpNgayDat.Text;
                DonDHNCC.MaNV = cbxMaNV.Text;
                Act.AddDonDHNCC(DonDHNCC);
                for (int i = 0; i < CTDonDHNCCs.Count; i++)
                {
                    ActChiTiet.AddCTDonDHNCC(CTDonDHNCCs[i]);
                }
                MessageBox.Show("Đã Tạo Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AutoID.UpdateAutoID(3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            EC_CTDonDHNCC CTDonDHNCC = new EC_CTDonDHNCC();
            CTDonDHNCC.MaDonDHNCC = txtMaDonDHNCC.Text;
            CTDonDHNCC.MaHangHoa = cbxMaHH.Text;
            CTDonDHNCC.SoLuong = nudSoLuong.Value.ToString();
            CTDonDHNCCs.Add(CTDonDHNCC);
            this.dgvChiTiet.Rows.Add(cbxMaHH.Text, txtTenHH.Text, txtTenDVT.Text, nudSoLuong.Value.ToString());
            //ActChiTiet.AddCTDonDHNCC(CTDonDHNCC);
            //dgvChiTiet.DataSource = ActChiTiet.CreateTbCTDonDHNCC(txtMaDonDHNCC.Text);
        }

       
    }
}
