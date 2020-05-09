using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoQLBHDT.DTO.Component;
using DemoQLBHDT.DTO.EntitiesClass;

namespace DemoQLBHDT
{
    public partial class FChangeTaiKhoan : Form
    {
        public FChangeTaiKhoan()
        {
            InitializeComponent();
        }

        public MainForm main = new MainForm();

        C_User Act = new C_User();
        EC_User User = new EC_User();

        public void AddThongTin(string[] _input)
        {
            labTacVu.Text = _input[0];
            txtUserName.Text = _input[1];
            txtPass.Text = _input[2];
            cbxQuyen.Text = _input[3];
            labMaNV.Text = _input[4];
            Act.LoadTenNV(cbxTenNV);
            cbxTenNV.Text = Act.LoadTenNV(cbxTenNV.Text, labMaNV.Text);

            if (labTacVu.Text == "Sửa")
            {
                txtUserName.Enabled = false;
            }
            else if (labTacVu.Text == "Xóa")
            {
                txtUserName.Enabled = false;
                txtPass.Enabled = false;
                cbxTenNV.Enabled = false;
                cbxQuyen.Enabled = false;
                labChuY.Text = "Lưu ý: Bạn có chắc muốn xóa!";
            }
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            if(labTacVu.Text == "Thêm")
            {
                if(txtUserName.Text != "")
                {
                    if(txtPass.Text != "")
                    {
                        if(cbxQuyen.Text != "")
                        {
                            try
                            {
                                User.UserName = txtUserName.Text;
                                User.Password = txtPass.Text;
                                User.PhanQuyen = cbxQuyen.Text;
                                if (labMaNV.Text == "---")
                                {
                                    User.MaNV = labMaNV.Text;
                                }
                                Act.AddUser(User);
                                MessageBox.Show("Đã thêm Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Quyền không được để trống", "Chú Ý", MessageBoxButtons.OK);
                            cbxQuyen.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Password không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txtPass.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Username không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txtUserName.Focus();
                }
            }
            else if(labTacVu.Text == "Sửa")
            {
                if (txtPass.Text != "")
                {
                    if (cbxQuyen.Text != "")
                    {
                        try
                        {
                            User.UserName = txtUserName.Text;
                            User.Password = txtPass.Text;
                            User.PhanQuyen = cbxQuyen.Text;
                            if (labMaNV.Text != "---")
                            {
                                User.MaNV = labMaNV.Text;
                            }
                            
                            Act.UpdateUser(User);
                            MessageBox.Show("Đã sửa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Quyền không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        cbxQuyen.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Password không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txtPass.Focus();
                }
            }
            else
            {
                try
                {
                    User.UserName = txtUserName.Text;
                    User.Password = txtPass.Text;
                    User.PhanQuyen = cbxQuyen.Text;
                    if (labMaNV.Text == "---")
                    {
                        User.MaNV = labMaNV.Text;
                    }
                    Act.DeleteUser(User);
                    MessageBox.Show("Đã xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            this.Hide();
            FTaiKhoan fuser = new FTaiKhoan();
            fuser.MdiParent = main;
            fuser.main = main;
            fuser.Show();
            
            //foreach (Form f in MainForm.MdiChildren)
            //{
            //    if (f.GetType() == typeof(FTaiKhoan))
            //    {
            //        f.Activate();
            //        break;
            //    }
            //}
        }

        private void cbxTenNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            labMaNV.Text = Act.LoadMaNV(labMaNV.Text, cbxTenNV.Text);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Hide();
            FTaiKhoan fuser = new FTaiKhoan();
            fuser.MdiParent = main;
            fuser.main = main;
            fuser.Show();
        }
    }
}
