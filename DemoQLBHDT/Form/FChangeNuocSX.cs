using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoQLBHDT.DTO.EntitiesClass;
using DemoQLBHDT.DTO.Component;

namespace DemoQLBHDT
{
    public partial class FChangeNuocSX : Form
    {
        public FChangeNuocSX()
        {
            InitializeComponent();
        }

        public MainForm main = new MainForm();

        EC_NuocSX NuocSX = new EC_NuocSX();
        C_NuocSX Act = new C_NuocSX();
        C_AutoID AutoID = new C_AutoID();

        public void AddThongTin(string[] _input)
        {
            labTacVu.Text = _input[0];
            txtMaNuocSX.Text = _input[1];
            txtTenNuocSX.Text = _input[2];
            if (labTacVu.Text == "Sửa")
            {
                txtMaNuocSX.Enabled = false;
            }
            else if (labTacVu.Text == "Xóa")
            {
                txtMaNuocSX.Enabled = false;
                txtTenNuocSX.Enabled = false;
                labLuuY.Text = "Lưu ý: Bạn có chắc muốn xóa!";
            }
            else
            {
                txtMaNuocSX.Text = AutoID.TaoMa(9);
            }
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            if (labTacVu.Text == "Thêm")
            {
                if (txtMaNuocSX.Text != "")
                {
                    if (txtTenNuocSX.Text != "")
                    {
                        try
                        {
                            //byte[] imageData = ReadFile(lbimgpath.Text);
                            NuocSX.MaNuocSX = txtMaNuocSX.Text;
                            NuocSX.TenNuocSX = txtTenNuocSX.Text;

                            Act.AddNuocSX(NuocSX);
                            AutoID.UpdateAutoID(9);
                            MessageBox.Show("Đã thêm Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tên không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txtTenNuocSX.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Mã không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txtMaNuocSX.Focus();
                }
            }
            else if(labTacVu.Text == "Sửa")
            {
                if (txtTenNuocSX.Text != "")
                {
                    try
                    {
                        //byte[] imageData = ReadFile(lbimgpath.Text);
                        NuocSX.MaNuocSX = txtMaNuocSX.Text;
                        NuocSX.TenNuocSX = txtTenNuocSX.Text;

                        Act.UpdateNuocSX(NuocSX);
                        MessageBox.Show("Đã sửa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Tên không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txtTenNuocSX.Focus();
                }
            }
            else
            {
                try
                {
                    NuocSX.MaNuocSX = txtMaNuocSX.Text;
                    NuocSX.TenNuocSX = txtTenNuocSX.Text;

                    Act.DeleteNuocSX(NuocSX);
                    MessageBox.Show("Đã xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            this.Hide();
            FNuocSX fnuocsx = new FNuocSX();
            fnuocsx.main = main;
            fnuocsx.MdiParent = main;
            fnuocsx.Show();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Hide();
            FNuocSX fnuocsx = new FNuocSX();
            fnuocsx.main = main;
            fnuocsx.MdiParent = main;
            fnuocsx.Show();
        }
    }
}
