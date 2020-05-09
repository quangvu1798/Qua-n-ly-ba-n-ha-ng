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
    public partial class FChangeHDB : Form
    {
        public FChangeHDB()
        {
            InitializeComponent();
        }

        ConnectDataBase Connect = new ConnectDataBase();
        C_ChiTietHDB ActCTHDB = new C_ChiTietHDB();
        C_HoaDonBan Act = new C_HoaDonBan();

        public void AddThongTin(string[] _input)
        {
            //labTacVu.Text = _input[0];
            txtMaHD.Text = _input[1];
            cbxMaNV.Text = _input[2];
            txtNgayLap.Text = _input[3];
            cbxMaKH.Text = _input[4];
            txtTongTien.Text = _input[0];            
        }

        private void FChangeHDB_Load(object sender, EventArgs e)
        {
            cbxTenNV.Text = Act.LoadTenNV(cbxTenNV.Text, cbxMaNV.Text);
            cbxTenKH.Text = Act.LoadTenKH(cbxTenKH.Text, cbxMaKH.Text);
            txtDiaChi.Text = Act.LoadDiaChi(txtDiaChi.Text, cbxMaKH.Text);
            dgvChiTiet.DataSource = ActCTHDB.CreateTbCTHDB(txtMaHD.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
