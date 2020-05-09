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
    public partial class FChangeDonViTinh : Form
    {
        public FChangeDonViTinh()
        {
            InitializeComponent();
        }

        public MainForm main = new MainForm();

        EC_DonViTinh DonViTinh = new EC_DonViTinh();
        C_DonViTinh Act = new C_DonViTinh();
        C_AutoID AutoID = new C_AutoID();

        public void AddThongTin(string[] _input)
        {
            labTacVu.Text = _input[0];
            txtMaDonVi.Text = _input[1];
            txtTenDonVi.Text = _input[2];
            if (labTacVu.Text == "Sửa")
            {
                txtMaDonVi.Enabled = false;
            }
            else if (labTacVu.Text == "Xóa")
            {
                txtMaDonVi.Enabled = false;
                txtTenDonVi.Enabled = false;
                labLuuY.Text = "Lưu ý: Bạn có chắc muốn xóa!";
            }
            else
            {
                txtMaDonVi.Text = AutoID.TaoMa(10);
            }
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            if (labTacVu.Text == "Thêm")
            {
                if (txtTenDonVi.Text != "")
                {
                    if (txtMaDonVi.Text != "")
                    {
                        try
                        {
                            //byte[] imageData = ReadFile(lbimgpath.Text);
                            DonViTinh.MaDonViTinh = txtMaDonVi.Text;
                            DonViTinh.TenDonViTinh = txtTenDonVi.Text;

                            Act.AddDonViTinh(DonViTinh);
                            AutoID.UpdateAutoID(10);
                            MessageBox.Show("Đã Thêm Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txtMaDonVi.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Tên Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txtTenDonVi.Focus();
                }

                
            }
            else if(labTacVu.Text == "Sửa")
            {
                if (txtTenDonVi.Text != "")
                {
                    try
                    {
                        //byte[] imageData = ReadFile(lbimgpath.Text);
                        DonViTinh.MaDonViTinh = txtMaDonVi.Text;
                        DonViTinh.TenDonViTinh = txtTenDonVi.Text;

                        Act.UpdateDonViTinh(DonViTinh);
                        MessageBox.Show("Đã sửa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Tên Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txtTenDonVi.Focus();
                }

                
            }
            else
            {
                try
                {
                    DonViTinh.MaDonViTinh = txtMaDonVi.Text;
                    DonViTinh.TenDonViTinh = txtTenDonVi.Text;

                    Act.DeleteDonViTinh(DonViTinh);
                    MessageBox.Show("Đã xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            //this.Hide();
            FDonViTinh fdonvitinh = new FDonViTinh();
            fdonvitinh.MdiParent = main;
            fdonvitinh.main = main;
            fdonvitinh.Show();
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            FDonViTinh fdonvitinh = new FDonViTinh();
            fdonvitinh.MdiParent = main;
            fdonvitinh.main = main;
            fdonvitinh.Show();
            this.Close();
        }
    }
}
