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

namespace DemoQLBHDT
{
    public partial class FCTHDN : Form
    {
        public FCTHDN()
        {
            InitializeComponent();
        }

        ConnectDataBase Connect = new ConnectDataBase();
        C_CTHDN ActCT = new C_CTHDN();
        C_HDN Act = new C_HDN();

        public void AddThongTin(string[] _input)
        {
            //labTacVu.Text = _input[0];
            txtMaHD.Text = _input[1];
            cbxMaNCC.Text = _input[2];
            txtNgayNhap.Text = _input[3];
            cbxMaNV.Text = _input[4];
            txtTongTien.Text = _input[0];
        }

        private void FCTHDN_Load(object sender, EventArgs e)
        {
            cbxTenNV.Text = Act.LoadTenNV(cbxTenNV.Text, cbxMaNV.Text);
            cbxTenNCC.Text = Act.LoadTenNCC(cbxTenNCC.Text, cbxMaNCC.Text);            
            dgvChiTiet.DataSource = ActCT.CreateTbCTHDN(txtMaHD.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
