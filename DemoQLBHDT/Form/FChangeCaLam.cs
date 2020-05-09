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
    public partial class FChangeCaLam : Form
    {
        public FChangeCaLam()
        {
            InitializeComponent();
        }

        public MainForm main = new MainForm();

        EC_CaLam CaLam = new EC_CaLam();
        C_CaLam Act = new C_CaLam();
        C_AutoID AutoID = new C_AutoID();

        public void AddThongTin(string[] _input)
        {
            labTacVu.Text = _input[0];
            txtMaCa.Text = _input[1];
            txtTenCa.Text = _input[2];
            txtMoTa.Text = _input[3];
            if (labTacVu.Text == "Sửa")
            {
                txtMaCa.Enabled = false;
            }
            else if (labTacVu.Text == "Xóa")
            {
                txtMaCa.Enabled = false;
                txtTenCa.Enabled = false;
                txtMoTa.Enabled = false;
                labLuuY.Text = "Lưu ý: Bạn có chắc muốn xóa!";
            }
            else
            {
                txtMaCa.Text = AutoID.TaoMa(12);
            }
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            if (labTacVu.Text == "Thêm")
            {
                if (txtTenCa.Text != "")
                {
                    if (txtMaCa.Text != "")
                    {
                        try
                        {
                            //byte[] imageData = ReadFile(lbimgpath.Text);
                            CaLam.MaCa = txtMaCa.Text;
                            CaLam.TenCa = txtTenCa.Text;
                            CaLam.MoTa = txtMoTa.Text;
                            Act.AddCa(CaLam);
                            AutoID.UpdateAutoID(12);
                            MessageBox.Show("Đã Thêm Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txtMaCa.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Tên không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txtTenCa.Focus();
                }

               
            }
            else if(labTacVu.Text == "Sửa")
            {
                if (txtTenCa.Text != "")
                {
                    try
                    {
                        //byte[] imageData = ReadFile(lbimgpath.Text);
                        CaLam.MaCa = txtMaCa.Text;
                        CaLam.TenCa = txtTenCa.Text;
                        CaLam.MoTa = txtMoTa.Text;
                        Act.UpdateCa(CaLam);
                        MessageBox.Show("Đã Sửa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txtTenCa.Focus();
                }
            }
            else
            {
                try
                {
                    CaLam.MaCa = txtMaCa.Text;
                    CaLam.TenCa = txtTenCa.Text;
                    CaLam.MoTa = txtMoTa.Text;
                    Act.DeleteCa(CaLam);
                    MessageBox.Show("Đã Xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            
            }

            this.Hide();
            FCaLam fca = new FCaLam();
            fca.MdiParent = main;
            fca.main = main;
            fca.Show();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Hide();
            FCaLam fca = new FCaLam();
            fca.MdiParent = main;
            fca.main = main;
            fca.Show();
        }
    }
}
