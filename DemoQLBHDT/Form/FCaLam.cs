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
    public partial class FCaLam : Form
    {
        public FCaLam()
        {
            InitializeComponent();
        }

        public MainForm main = new MainForm();

        public string Access = "";
        ConnectDataBase Connect = new ConnectDataBase();
        EC_CaLam CaLam = new EC_CaLam();
        C_CaLam Act = new C_CaLam();

        public void khoitaoluoi()
        {
            dgvCaLam.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCaLam.Columns[0].HeaderText = "Mã Ca";
            dgvCaLam.Columns[0].Frozen = true;
            dgvCaLam.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvCaLam.Columns[1].HeaderText = "Tên Ca";

            dgvCaLam.Columns[2].HeaderText = "Mô Tả";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //this.Hide();
            FChangeCaLam fadd = new FChangeCaLam();
            fadd.AddThongTin(new string[] { btnAdd.Text, "", "", "" });
            fadd.MdiParent = main;
            fadd.main = main;
            this.Close();
            fadd.Show();
        }

        private void dgvDonViTinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaCa.Text = dgvCaLam.Rows[row].Cells[0].Value.ToString();
                txtTenCa.Text = dgvCaLam.Rows[row].Cells[1].Value.ToString();
                txtMoTa.Text = dgvCaLam.Rows[row].Cells[2].Value.ToString();
            }
        }

        private void FCaLam_Load(object sender, EventArgs e)
        {
            dgvCaLam.DataSource = Act.CreateTbCL();
            khoitaoluoi();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FChangeCaLam fadd = new FChangeCaLam();
            fadd.AddThongTin(new string[] { btnUpdate.Text, txtMaCa.Text, txtTenCa.Text, txtMoTa.Text });
            fadd.MdiParent = main;
            fadd.main = main;
            this.Close();
            fadd.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FChangeCaLam fadd = new FChangeCaLam();
            fadd.AddThongTin(new string[] { btnDelete.Text, txtMaCa.Text, txtTenCa.Text, txtMoTa.Text });
            fadd.MdiParent = main;
            fadd.main = main;
            this.Close();
            fadd.Show();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtMaCa.Text == "---")
            {
                CaLam.MaCa = "";
            }
            else
            {
                CaLam.MaCa = txtMaCa.Text;
            }
            if (txtTenCa.Text == "---")
            {
                CaLam.TenCa = "";
            }
            else
            {
                CaLam.TenCa = txtTenCa.Text;
            }
            if (txtMoTa.Text == "---")
            {
                CaLam.MoTa = "";
            }
            else
            {
                CaLam.MoTa = txtMoTa.Text;
            }

            dgvCaLam.DataSource = Act.CreateTbCL(CaLam);
        }
    }
}
