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
    public partial class FNuocSX : Form
    {
        public FNuocSX()
        {
            InitializeComponent();
        }

        public MainForm main = new MainForm();

        ConnectDataBase Connect = new ConnectDataBase();
        C_NuocSX Act = new C_NuocSX();
        EC_NuocSX NuocSX = new EC_NuocSX();
        public string Access = "";

        public void khoitaoluoi()
        {
            dgvNuocSX.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvNuocSX.Columns[0].HeaderText = "Mã Nước";
            dgvNuocSX.Columns[0].Frozen = true;
            dgvNuocSX.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvNuocSX.Columns[1].HeaderText = "Tên Nước";
        }

        private void FNuocSX_Load(object sender, EventArgs e)
        {

            dgvNuocSX.DataSource = Act.CreateTbNSX();
            khoitaoluoi();
        }

        private void dgvNuocSX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaNuoc.Text = dgvNuocSX.Rows[row].Cells[0].Value.ToString();
                txtTenNuocSX.Text = dgvNuocSX.Rows[row].Cells[1].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //this.Hide();
            FChangeNuocSX fadd = new FChangeNuocSX();
            fadd.AddThongTin(new string[] { btnAdd.Text, "", "" });
            fadd.MdiParent = main;
            fadd.main = main;
            this.Close();
            fadd.Show();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if(txtMaNuoc.Text =="---" || txtMaNuoc.Text == "")
            {
                NuocSX.MaNuocSX = "%";
            }
            else
            {
                NuocSX.MaNuocSX = txtMaNuoc.Text;
            }
            if (txtTenNuocSX.Text == "---" || txtTenNuocSX.Text == "")
            {
                NuocSX.TenNuocSX = "%";
            }
            else
            {
                NuocSX.TenNuocSX = txtTenNuocSX.Text;
            }
            
            dgvNuocSX.DataSource = Act.CreateTbNSX(NuocSX);
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FChangeNuocSX fadd = new FChangeNuocSX();
            fadd.AddThongTin(new string[] { btnUpdate.Text, txtMaNuoc.Text, txtTenNuocSX.Text });
            fadd.MdiParent = main;
            fadd.main = main;
            this.Close();
            fadd.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FChangeNuocSX fadd = new FChangeNuocSX();
            fadd.AddThongTin(new string[] { btnDelete.Text, txtMaNuoc.Text, txtTenNuocSX.Text });
            fadd.MdiParent = main;
            fadd.main = main;
            this.Close();
            fadd.Show();
        }

    }
}
