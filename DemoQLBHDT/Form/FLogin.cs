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
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();
        }

        //public string Access = "";
        
        public MainForm fmain = new MainForm();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;
            EC_User user = new EC_User();
            C_User active = new C_User();
            try
            {
                user.UserName = username;
                user.Password = password;
                if (active.CheckUser(username, password))
                {
                    MessageBox.Show("Đăng Nhập Thành Công", "Chúc Mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    user.PhanQuyen = active.LoadPhanQuyen(user.PhanQuyen, username);
                    user.MaNV = active.LoadMaNVUser(user.MaNV, user.UserName);
                    fmain.Access = user.PhanQuyen;
                    fmain.User = user;
                    this.Hide();
                    fmain.Show();
                }
                else
                {
                    MessageBox.Show("Tài khoản đăng nhập chưa đúng. Vui lòng kiểm tra lại.", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUser.Text = "";
                    txtPass.Text = "";
                    txtUser.Focus();
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
