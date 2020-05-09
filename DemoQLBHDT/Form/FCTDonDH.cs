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
    public partial class FCTDonDH : Form
    {
        public FCTDonDH()
        {
            InitializeComponent();
        }

        //public MainForm main = new MainForm();

        ConnectDataBase Connect = new ConnectDataBase();
        C_DonDH Act = new C_DonDH();
        C_CTDonDH ActCT = new C_CTDonDH();

        public void AddThongTin(string[] _input)
        {
            //labTacVu.Text = _input[0];
            txtMaDonDH.Text = _input[0];
            cbxMaKH.Text = _input[1];
            txtNgayDat.Text = _input[2];    
        }

        private void FCTDonDH_Load(object sender, EventArgs e)
        {
            cbxTenKH.Text = Act.LoadTenKH(cbxTenKH.Text, cbxMaKH.Text);
            txtDiaChi.Text = Act.LoadDiaChi(txtDiaChi.Text, cbxMaKH.Text);

            dgvChiTiet.DataSource = ActCT.CreateTbCTDonDH(txtMaDonDH.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
