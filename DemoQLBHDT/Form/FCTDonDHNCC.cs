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
    public partial class FCTDonDHNCC : Form
    {
        public FCTDonDHNCC()
        {
            InitializeComponent();
        }

        ConnectDataBase Connect = new ConnectDataBase();
        C_DonDHNCC Act = new C_DonDHNCC();
        C_CTDonDHNCC ActCT = new C_CTDonDHNCC();

        public void AddThongTin(string[] _input)
        {
            //labTacVu.Text = _input[0];
            txtMaDonDHNCC.Text = _input[0];
            cbxMaNCC.Text = _input[1];
            txtNgayDat.Text = _input[2];
            cbxMaNV.Text = _input[3];
        }

        private void FCTDonDHNCC_Load(object sender, EventArgs e)
        {
            cbxTenNV.Text = Act.LoadTenNV(cbxTenNV.Text, cbxMaNV.Text);
            cbxTenNCC.Text = Act.LoadTenNCC(cbxTenNCC.Text, cbxMaNCC.Text);
            
            dgvChiTiet.DataSource = ActCT.CreateTbCTDonDHNCC(txtMaDonDHNCC.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
