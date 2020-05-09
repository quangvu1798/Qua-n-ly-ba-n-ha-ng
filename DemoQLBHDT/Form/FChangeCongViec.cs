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
    public partial class FChangeCongViec : Form
    {
        public FChangeCongViec()
        {
            InitializeComponent();
        }

        public MainForm main = new MainForm();

        EC_CongViec CongViec = new EC_CongViec();
        C_CongViec Act = new C_CongViec();
        C_AutoID AutoID = new C_AutoID();

        public void AddThongTin(string[] _input)
        {
            labTacVu.Text = _input[0];
            txtMaCV.Text = _input[1];
            txtTenCV.Text = _input[2];
            if (labTacVu.Text == "Sửa")
            {
                txtMaCV.Enabled = false;
            }
            else if (labTacVu.Text == "Xóa")
            {
                txtMaCV.Enabled = false;
                txtTenCV.Enabled = false;
                labLuuY.Text = "Lưu ý: Bạn có chắc muốn xóa!";
            }
            else
            {
                txtMaCV.Text = AutoID.TaoMa(11);
            }
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            if (labTacVu.Text == "Thêm")
            {
                if (txtTenCV.Text != "")
                {
                    if (txtMaCV.Text != "")
                    {
                        try
                        {
                            //byte[] imageData = ReadFile(lbimgpath.Text);
                            CongViec.MaCV = txtMaCV.Text;
                            CongViec.TenCV = txtTenCV.Text;

                            Act.AddCV(CongViec);
                            AutoID.UpdateAutoID(11);
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
                        txtMaCV.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Tên Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txtTenCV.Focus();
                }

                
            }
            else if (labTacVu.Text == "Sửa")
            {
                if (txtTenCV.Text != "")
                {

                    try
                    {
                        //byte[] imageData = ReadFile(lbimgpath.Text);
                        CongViec.MaCV = txtMaCV.Text;
                        CongViec.TenCV = txtTenCV.Text;

                        Act.UpdateCV(CongViec);
                        MessageBox.Show("Đã Sửa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Tên Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txtTenCV.Focus();
                }
                
            }
            else
            {
                try
                {
                    CongViec.MaCV = txtMaCV.Text;
                    CongViec.TenCV = txtTenCV.Text;

                    Act.DeleteCV(CongViec);
                    MessageBox.Show("Đã Xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            this.Hide();
            FCongViec fcv = new FCongViec();
            fcv.MdiParent = main;
            fcv.main = main;
            fcv.Show();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Hide();
            FCongViec fcv = new FCongViec();
            fcv.MdiParent = main;
            fcv.main = main;
            fcv.Show();
        }
    }
}
