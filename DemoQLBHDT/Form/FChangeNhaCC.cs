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
    public partial class FChangeNhaCC : Form
    {
        public FChangeNhaCC()
        {
            InitializeComponent();
        }

        public MainForm main = new MainForm();

        EC_NhaCC NhaCC = new EC_NhaCC();
        C_NhaCC Act = new C_NhaCC();
        C_AutoID AutoID = new C_AutoID();

        public void AddThongTin(string[] _input)
        {
            labTacVu.Text = _input[0];
            txtMaNhaCC.Text = _input[1];
            txtTenNhaCC.Text = _input[2];
            txtDiaChi.Text = _input[3];
            txtSDT.Text = _input[4];
            if (labTacVu.Text == "Sửa")
            {
                txtMaNhaCC.Enabled = false;
            }
            else if (labTacVu.Text == "Xóa")
            {
                txtMaNhaCC.Enabled = false;
                txtTenNhaCC.Enabled = false;
                txtDiaChi.Enabled = false;
                txtSDT.Enabled = false;
                label1.Text = "Lưu ý: Bạn có chắc muốn xóa!";
            }
            else
            {
                txtMaNhaCC.Text = AutoID.TaoMa(8);
            }
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            if (labTacVu.Text == "Thêm")
            {
                if (txtMaNhaCC.Text != "")
                {
                    if (txtTenNhaCC.Text != "")
                    {
                        if (txtDiaChi.Text != "")
                        {
                            if (txtSDT.Text != "")
                            {
                                try
                                {
                                    //byte[] imageData = ReadFile(lbimgpath.Text);
                                    NhaCC.MaNhaCC = txtMaNhaCC.Text;
                                    NhaCC.TenNhaCC = txtTenNhaCC.Text;
                                    NhaCC.DiaChi = txtDiaChi.Text;
                                    NhaCC.DienThoai = txtSDT.Text;

                                    Act.AddNhaCC(NhaCC);
                                    AutoID.UpdateAutoID(8);
                                    MessageBox.Show("Đã Thêm Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Điện thoại Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                                txtSDT.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Địa Chỉ Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                            txtDiaChi.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tên Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txtTenNhaCC.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txtMaNhaCC.Focus();
                }
            }
            else if (labTacVu.Text == "Sửa")
            {
                if (txtTenNhaCC.Text != "")
                {
                    if (txtDiaChi.Text != "")
                    {
                        if (txtSDT.Text != "")
                        {
                            try
                            {
                                //byte[] imageData = ReadFile(lbimgpath.Text);
                                NhaCC.MaNhaCC = txtMaNhaCC.Text;
                                NhaCC.TenNhaCC = txtTenNhaCC.Text;
                                NhaCC.DiaChi = txtDiaChi.Text;
                                NhaCC.DienThoai = txtSDT.Text;

                                Act.UpdateNhaCC(NhaCC);
                                MessageBox.Show("Đã Sửa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Điện thoại Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                            txtSDT.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Địa chỉ Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txtDiaChi.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Tên không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txtTenNhaCC.Focus();
                }

                
            }
            else
            {
                try
                {
                    NhaCC.MaNhaCC = txtMaNhaCC.Text;
                    NhaCC.TenNhaCC = txtTenNhaCC.Text;
                    NhaCC.DiaChi = txtDiaChi.Text;
                    NhaCC.DienThoai = txtSDT.Text;
                    Act.DeleteNhaCC(NhaCC);
                    MessageBox.Show("Đã Xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            //this.Hide();
            FNhaCC fnhacc = new FNhaCC();
            fnhacc.MdiParent = main;
            fnhacc.main = main;
            fnhacc.Show();
            this.Hide();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            FNhaCC fnhacc = new FNhaCC();
            fnhacc.MdiParent = main;
            fnhacc.main = main;
            fnhacc.Show();
            this.Hide();
        }
    }
}
