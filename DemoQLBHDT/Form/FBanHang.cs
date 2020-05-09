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
    public partial class FBanHang : Form
    {
        public FBanHang()
        {
            InitializeComponent();
        }

        //public string Access = "";
        C_HoaDonBan Act = new C_HoaDonBan();
        C_ChiTietHDB ActCTHDB = new C_ChiTietHDB();
        ConnectDataBase Connect = new ConnectDataBase();
        EC_HoaDonBan HoaDonBan = new EC_HoaDonBan();
        
        List<EC_ChiTietHDB> CTHDBs = new List<EC_ChiTietHDB>();
        C_AutoID AutoID = new C_AutoID();
        public EC_User User;
        int TongTien = 0;

        private void FHoaDonBan_Load(object sender, EventArgs e)
        {
            Act.LoadMaHH(cbxMaHH);
            Act.LoadMaKH(cbxMaKH);
            Act.LoadTenKH(cbxTenKH);
            Act.LoadMaNV(cbxMaNV);
            Act.LoadTenNV(cbxTenNV);
            cbxMaNV.Text = User.MaNV;
            cbxTenNV.Text = Act.LoadTenNV(cbxTenNV.Text, User.MaNV);
            txtTongTien.Text = TongTien.ToString();
            txtMaHD.Text = AutoID.TaoMa(2);
        }

        private void cbxMaHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTenHH.Text = Act.LoadTenHH(txtTenHH.Text, cbxMaHH.Text);
            txtDGB.Text = Act.LoadDGB(txtDGB.Text, cbxMaHH.Text);
            labMaDVT.Text = Act.LoadMaDonViTinh(labMaDVT.Text, cbxMaHH.Text);
            txtTenDVT.Text = Act.LoadTenDonViTinh(txtTenDVT.Text, labMaDVT.Text);
        }

        

        private void btnThem_Click(object sender, EventArgs e)
        {
            string thanhtien = Convert.ToString(Convert.ToInt32(txtDGB.Text) * Convert.ToInt32(nudSoLuong.Text));
            TongTien += Convert.ToInt32(thanhtien);
            txtTongTien.Text = TongTien.ToString();
            
            //HoaDonBan.TongTien = txtTongTien.Text;
            //Act.UpdateHDB(HoaDonBan);
            EC_ChiTietHDB CTHDB = new EC_ChiTietHDB();
            CTHDB.SoHDB = txtMaHD.Text;
            CTHDB.MaHang = cbxMaHH.Text;
            CTHDB.SoLuong = nudSoLuong.Value.ToString();
            CTHDB.ThanhTien = thanhtien;
            CTHDBs.Add(CTHDB);
            this.dgvChiTiet.Rows.Add(cbxMaHH.Text, txtTenHH.Text, txtTenDVT.Text, txtDGB.Text, nudSoLuong.Value.ToString(), thanhtien);
            //ActCTHDB.AddCTHDB(CTHDB);
            //dgvChiTiet.DataSource = ActCTHDB.CreateTbCTHDB(txtMaHD.Text);
            
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                HoaDonBan.SoHDB = txtMaHD.Text;
                HoaDonBan.NgayLap = dtpNgayLap.Text;
                HoaDonBan.MaKH = cbxMaKH.Text;
                HoaDonBan.MaNV = cbxMaNV.Text;
                HoaDonBan.TongTien = txtTongTien.Text;

                Act.AddHDB(HoaDonBan);
                AutoID.UpdateAutoID(2);
                for (int i = 0; i < CTHDBs.Count; i++)
                {
                    ActCTHDB.AddCTHDB(CTHDBs[i]);
                }
                MessageBox.Show("Đã Tạo Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
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
