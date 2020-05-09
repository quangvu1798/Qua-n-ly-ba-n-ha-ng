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
    public partial class FDatHang : Form
    {
        public FDatHang()
        {
            InitializeComponent();
        }

        ConnectDataBase Connect = new ConnectDataBase();
        C_AutoID AutoID = new C_AutoID();
        C_DonDH Act = new C_DonDH();
        EC_DonDH DonDH = new EC_DonDH();
        C_CTDonDH ActCT = new C_CTDonDH();
        //C_AutoID AutoID = new C_AutoID();
        List<EC_CTDonDH> CTDonDHs = new List<EC_CTDonDH>();
        

        private void FDatHang_Load(object sender, EventArgs e)
        {
            Act.LoadMaHH(cbxMaHH);
            Act.LoadMaKH(cbxMaKH);
            Act.LoadTenKH(cbxTenKH);          
            
            txtMaDonDH.Text = AutoID.TaoMa(5);
        }

        private void cbxMaHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTenHH.Text = Act.LoadTenHH(txtTenHH.Text, cbxMaHH.Text);
            labMaDVT.Text = Act.LoadMaDonViTinh(labMaDVT.Text, cbxMaHH.Text);
            txtTenDVT.Text = Act.LoadTenDonViTinh(txtTenDVT.Text, labMaDVT.Text);
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            EC_CTDonDH CTDonDH = new EC_CTDonDH();
            CTDonDH.MaDonDH = txtMaDonDH.Text;
            CTDonDH.MaHangHoa = cbxMaHH.Text;
            CTDonDH.SoLuong = nudSoLuong.Value.ToString();
            CTDonDHs.Add(CTDonDH);
            this.dgvChiTiet.Rows.Add(cbxMaHH.Text, txtTenHH.Text, txtTenDVT.Text, nudSoLuong.Value.ToString());
            //ActChiTiet.AddCTDonDHNCC(CTDonDHNCC);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                DonDH.MaDonDH = txtMaDonDH.Text;
                DonDH.MaKH = cbxMaKH.Text;
                DonDH.NgayDat = dtpNgayDat.Text;
                Act.AddDonDH(DonDH);
                for (int i = 0; i < CTDonDHs.Count; i++)
                {
                    ActCT.AddCTDonDH(CTDonDHs[i]);
                }
                MessageBox.Show("Đã Tạo Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AutoID.UpdateAutoID(5);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
        }
    }
}
