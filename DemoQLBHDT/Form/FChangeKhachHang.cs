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
    public partial class FChangeKhachHang : Form
    {
        public FChangeKhachHang()
        {
            InitializeComponent();
        }

        public MainForm main = new MainForm();

        EC_KhachHang KhachHang = new EC_KhachHang();
        C_KhachHang Act = new C_KhachHang();
        C_AutoID AutoID = new C_AutoID();

        public void AddThongTin(string[] _input)
        {
            labTacVu.Text = _input[0]; 
            txtMaKH.Text = _input[1];
            txtTenKH.Text = _input[2];
            txtDiaChi.Text = _input[3];
            txtSDT.Text = _input[4];
            if(labTacVu.Text=="Sửa")
            {
                txtMaKH.Enabled = false;
            }
            else if(labTacVu.Text == "Xóa")
            {
                txtMaKH.Enabled = false;
                txtTenKH.Enabled = false;
                txtDiaChi.Enabled = false;
                txtSDT.Enabled = false;
                label1.Text = "Lưu ý: Bạn có chắc muốn xóa!";
            }
            else
            {
                txtMaKH.Text = AutoID.TaoMa(7);
            }
        }


        private void btnThucHien_Click(object sender, EventArgs e)
        {
            if(labTacVu.Text == "Thêm")
            {
                if (txtMaKH.Text != "")
                {
                    if (txtTenKH.Text != "")
                    {
                        if (txtDiaChi.Text != "")
                        {

                            try
                            {
                                //byte[] imageData = ReadFile(lbimgpath.Text);
                                KhachHang.MaKH = txtMaKH.Text;
                                KhachHang.TenKH = txtTenKH.Text;
                                KhachHang.DiaChi = txtDiaChi.Text;
                                KhachHang.DienThoai = txtSDT.Text;

                                Act.AddKhachHang(KhachHang);
                                AutoID.UpdateAutoID(7);
                                MessageBox.Show("Đã Thêm Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        txtTenKH.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txtMaKH.Focus();
                }

                

            }
            else if(labTacVu.Text == "Sửa")
            {
                if (txtTenKH.Text != "")
                {
                    if (txtDiaChi.Text != "")
                    {

                        try
                        {
                            //byte[] imageData = ReadFile(lbimgpath.Text);
                            KhachHang.MaKH = txtMaKH.Text;
                            KhachHang.TenKH = txtTenKH.Text;
                            KhachHang.DiaChi = txtDiaChi.Text;
                            KhachHang.DienThoai = txtSDT.Text;

                            Act.UpdateKhachHang(KhachHang);
                            MessageBox.Show("Đã Sửa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    txtTenKH.Focus();
                }

                
            }
            else
            {
                try
                {
                    KhachHang.MaKH = txtMaKH.Text;
                    KhachHang.TenKH = txtTenKH.Text;
                    KhachHang.DiaChi = txtDiaChi.Text;
                    KhachHang.DienThoai = txtSDT.Text;
                    Act.DeleteKhachHang(KhachHang);
                    MessageBox.Show("Đã Xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
                       
            FKhachHang fkhachhang = new FKhachHang();
            this.Hide();
            fkhachhang.MdiParent = main;
            fkhachhang.main = main;
            fkhachhang.Show();
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            FKhachHang fkhachhang = new FKhachHang();
            this.Hide();
            fkhachhang.MdiParent = main;
            fkhachhang.main = main;
            fkhachhang.Show();
        }
    }
}
