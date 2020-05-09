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
using DemoQLBHDT.DTO.EntitiesClass;
using DemoQLBHDT.DTO.Component;

namespace DemoQLBHDT
{
    public partial class FCongViec : Form
    {
        public FCongViec()
        {
            InitializeComponent();
        }

        public MainForm main = new MainForm();
        public string Access = "";
        ConnectDataBase Connect = new ConnectDataBase();
        EC_CongViec CongViec = new EC_CongViec();
        C_CongViec Act = new C_CongViec();

        public void khoitaoluoi()
        {
            dgvCongViec.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCongViec.Columns[0].HeaderText = "Mã Công Việc";
            dgvCongViec.Columns[0].Frozen = true;
            dgvCongViec.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvCongViec.Columns[1].HeaderText = "Tên Công Việc";
        }

        private void FCongViec_Load(object sender, EventArgs e)
        {


            dgvCongViec.DataSource = Act.CreateTbCV();
            khoitaoluoi();
        }

        private void dgvCongViec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaCV.Text = dgvCongViec.Rows[row].Cells[0].Value.ToString();
                txtTenCV.Text = dgvCongViec.Rows[row].Cells[1].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //this.Hide();
            FChangeCongViec fadd = new FChangeCongViec();
            fadd.AddThongTin(new string[] { btnAdd.Text, "", "" });
            fadd.MdiParent = main;
            fadd.main = main;
            this.Close();
            fadd.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FChangeCongViec fadd = new FChangeCongViec();
            fadd.AddThongTin(new string[] { btnUpdate.Text, txtMaCV.Text, txtTenCV.Text });
            fadd.MdiParent = main;
            fadd.main = main;
            this.Close();
            fadd.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FChangeCongViec fadd = new FChangeCongViec();
            fadd.AddThongTin(new string[] { btnDelete.Text, txtMaCV.Text, txtTenCV.Text });
            fadd.MdiParent = main;
            fadd.main = main;
            this.Close();
            fadd.Show();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtMaCV.Text == "---" || txtMaCV.Text == "")
            {
                CongViec.MaCV = "%";
            }
            else
            {
                CongViec.MaCV = txtMaCV.Text;
            }
            if (txtTenCV.Text == "---" || txtTenCV.Text == "")
            {
                CongViec.TenCV = "%";
            }
            else
            {
                CongViec.TenCV = txtTenCV.Text;
            }

            dgvCongViec.DataSource = Act.CreateTbCV(CongViec);
        }

    }
}
