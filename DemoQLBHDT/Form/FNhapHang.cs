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
    public partial class FNhapHang : Form
    {
        public FNhapHang()
        {
            InitializeComponent();
        }

        C_HDN Act = new C_HDN();
        C_CTHDN ActCT = new C_CTHDN();
        ConnectDataBase Connect = new ConnectDataBase();
        EC_HDN HDN = new EC_HDN();

        List<EC_CTHDN> CTHDNs = new List<EC_CTHDN>();
        C_AutoID AutoID = new C_AutoID();
        public EC_User User;
        int TongTien = 0;

        private void FNhapHang_Load(object sender, EventArgs e)
        {
            Act.LoadMaHH(cbxMaHH);
            Act.LoadMaNCC(cbxMaNCC);
            Act.LoadTenNCC(cbxTenNCC);
            Act.LoadMaNV(cbxMaNV);
            Act.LoadTenNV(cbxTenNV);
            cbxMaNV.Text = User.MaNV;
            cbxTenNV.Text = Act.LoadTenNV(cbxTenNV.Text, User.MaNV);
            txtTongTien.Text = TongTien.ToString();
            txtMaHD.Text = AutoID.TaoMa(4);
        }

        private void cbxMaHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTenHH.Text = Act.LoadTenHH(txtTenHH.Text, cbxMaHH.Text);
            txtDGN.Text = Act.LoadDGN(txtDGN.Text, cbxMaHH.Text);
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            string thanhtien = Convert.ToString(Convert.ToInt32(txtDGN.Text) * Convert.ToInt32(nudSoLuong.Text));
            TongTien += Convert.ToInt32(thanhtien);
            txtTongTien.Text = TongTien.ToString();
            
            EC_CTHDN CTHDN = new EC_CTHDN();
            CTHDN.SoHDN = txtMaHD.Text;
            CTHDN.MaHang = cbxMaHH.Text;
            CTHDN.SoLuong = nudSoLuong.Value.ToString();
            CTHDN.ThanhTien = thanhtien;
            CTHDNs.Add(CTHDN);
            this.dgvChiTiet.Rows.Add(cbxMaHH.Text, txtTenHH.Text, txtTenDVT.Text, txtDGN.Text, nudSoLuong.Value.ToString(), thanhtien);
            //ActCTHDB.AddCTHDB(CTHDB);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                HDN.SoHDN = txtMaHD.Text;
                HDN.NgayNhap = dtpNgayNhap.Text;
                HDN.MaNCC = cbxMaNCC.Text;
                HDN.MaNV = cbxMaNV.Text;
                HDN.TongTien = txtTongTien.Text;

                Act.AddHDN(HDN);
                AutoID.UpdateAutoID(4);
                for (int i = 0; i < CTHDNs.Count; i++)
                {
                    ActCT.AddCTHDN(CTHDNs[i]);
                }
                MessageBox.Show("Đã Tạo Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
        }
    }
}
