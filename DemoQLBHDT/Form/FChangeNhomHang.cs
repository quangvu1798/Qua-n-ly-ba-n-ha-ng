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
    public partial class FChangeNhomHang : Form
    {
        public FChangeNhomHang()
        {
            InitializeComponent();
        }

        public MainForm main = new MainForm();

        EC_NhomHang NhomHang = new EC_NhomHang();
        C_NhomHang Act = new C_NhomHang();
        C_AutoID AutoID = new C_AutoID();

        public void AddThongTin(string[] _input)
        {
            labTacVu.Text = _input[0];
            txtMaNhom.Text = _input[1];
            txtTenNhom.Text = _input[2];
            if (labTacVu.Text == "Sửa")
            {
                txtMaNhom.Enabled = false;
            }
            else if (labTacVu.Text == "Xóa")
            {
                txtMaNhom.Enabled = false;
                txtTenNhom.Enabled = false;
                labLuuY.Text = "Lưu ý: Bạn có chắc muốn xóa!";
            }
            else
            {
                txtMaNhom.Text = AutoID.TaoMa(13);
            }
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            if (labTacVu.Text == "Thêm")
            {
                if (txtMaNhom.Text != "")
                {
                    if (txtTenNhom.Text != "")
                    {
                        try
                        {
                            //byte[] imageData = ReadFile(lbimgpath.Text);
                            NhomHang.MaNhomHang = txtMaNhom.Text;
                            NhomHang.TenNhomHang = txtTenNhom.Text;

                            Act.AddNhomHang(NhomHang);
                            AutoID.UpdateAutoID(13);
                            MessageBox.Show("Đã Thêm Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tên không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txtTenNhom.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Mã không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txtMaNhom.Focus();
                }
            } 
            else if(labTacVu.Text == "Sửa")
            {
                if (txtTenNhom.Text != "")
                {
                    try
                    {
                        //byte[] imageData = ReadFile(lbimgpath.Text);
                        NhomHang.MaNhomHang = txtMaNhom.Text;
                        NhomHang.TenNhomHang = txtTenNhom.Text;

                        Act.UpdateNhomHang(NhomHang);
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
                    txtTenNhom.Focus();
                }
            }
            else
            {
                try
                {
                    NhomHang.MaNhomHang = txtMaNhom.Text;
                    NhomHang.TenNhomHang = txtTenNhom.Text;

                    Act.DeleteNhomHang(NhomHang);
                    MessageBox.Show("Đã Xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
            FNhomHang fnhomhang = new FNhomHang();
            fnhomhang.main = main;
            fnhomhang.MdiParent = main;
            this.Hide();
            //fnhomhang.MdiParent = 
            fnhomhang.Show();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            
            FNhomHang fnhomhang = new FNhomHang();
            fnhomhang.main = main;
            fnhomhang.MdiParent = main;
            this.Hide();
            fnhomhang.Show();
        }
    }
}
