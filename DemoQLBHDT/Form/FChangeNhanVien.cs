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
    public partial class FChangeNhanVien : Form
    {
        public FChangeNhanVien()
        {
            InitializeComponent();
        }

        public MainForm main = new MainForm();

        EC_NhanVien NhanVien = new EC_NhanVien();
        C_NhanVien Act = new C_NhanVien();
        C_AutoID AutoID = new C_AutoID();

        public void AddThongTin(string[] _input)
        {
            labTacVu.Text = _input[0];
            txtMaNV.Text = _input[1];
            txtTenNV.Text = _input[2];
            cbxGioiTinh.Text = _input[4];
            dtpNgaySinh.Text = _input[3];
            txtSDT.Text = _input[5];
            txtDiaChi.Text = _input[6];
            txtGhiChu.Text = _input[7];
            labMaCa.Text = _input[8];
            labMaCV.Text = _input[9];
            if (labTacVu.Text == "Sửa")
            {
                txtMaNV.Enabled = false;
            }
            else if (labTacVu.Text == "Xóa")
            {
                txtMaNV.Enabled = false;
                txtTenNV.Enabled = false;
                cbxGioiTinh.Enabled = false;
                dtpNgaySinh.Enabled = false;
                txtSDT.Enabled = false;
                txtDiaChi.Enabled = false;
                txtGhiChu.Enabled = false;
                cbxTenCa.Enabled = false;
                cbxTenCV.Enabled = false;
                labLuuY.Text = "Lưu ý: Bạn có chắc muốn xóa!";
            }
            else
            {
                txtMaNV.Text = AutoID.TaoMa(1);
            }
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            if (labTacVu.Text == "Thêm")
            {
                if (txtMaNV.Text != "")
                {
                    if (txtTenNV.Text != "")
                    {
                        if (cbxTenCa.Text != "")
                        {
                            if (cbxTenCV.Text != "")
                            {
                                if (dtpNgaySinh.Text != "")
                                {
                                    if (cbxGioiTinh.Text != "")
                                    {
                                        if (txtSDT.Text != "")
                                        {
                                            if (txtDiaChi.Text != "")
                                            {
                                                try
                                                {
                                                    //byte[] imageData = ReadFile(lbimgpath.Text);
                                                    NhanVien.MaNhanVien = txtMaNV.Text;
                                                    NhanVien.TenNhanVien = txtTenNV.Text;
                                                    NhanVien.DiaChi = txtDiaChi.Text;
                                                    NhanVien.DienThoai = txtSDT.Text;
                                                    NhanVien.GioiTinh = cbxGioiTinh.Text;
                                                    NhanVien.NgaySinh = dtpNgaySinh.Text;
                                                    NhanVien.MaCa = labMaCa.Text;
                                                    NhanVien.MaCV = labMaCV.Text;
                                                    NhanVien.GhiChu = txtGhiChu.Text;
                                                    
                                                    Act.AddNV(NhanVien);
                                                    AutoID.UpdateAutoID(1);
                                                    MessageBox.Show("Đã Thêm Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                                catch (Exception ex)
                                                {
                                                    MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Điện thoại không được để trống", "Chú Ý", MessageBoxButtons.OK);
                                                txtDiaChi.Focus();
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Điện thoại không được để trống", "Chú Ý", MessageBoxButtons.OK);
                                            txtSDT.Focus();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Ngày sinh không được để trống", "Chú Ý", MessageBoxButtons.OK);
                                        cbxGioiTinh.Focus();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Ngày sinh không được để trống", "Chú Ý", MessageBoxButtons.OK);
                                    dtpNgaySinh.Focus();
                                }
                            }

                            else
                            {
                                MessageBox.Show("Mã không được để trống", "Chú Ý", MessageBoxButtons.OK);
                                cbxTenCV.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mã không được để trống", "Chú Ý", MessageBoxButtons.OK);
                            cbxTenCa.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tên không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        txtTenNV.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Mã không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txtMaNV.Focus();
                }
            }
            else if(labTacVu.Text == "Sửa")
            {
                if (txtTenNV.Text != "")
                {
                    if (cbxTenCa.Text != "")
                    {
                        if (cbxTenCV.Text != "")
                        {
                            if (dtpNgaySinh.Text != "")
                            {
                                if (cbxGioiTinh.Text != "")
                                {
                                    if (txtSDT.Text != "")
                                    {
                                        if (txtDiaChi.Text != "")
                                        {
                                            try
                                            {
                                                //byte[] imageData = ReadFile(lbimgpath.Text);
                                                NhanVien.MaNhanVien = txtMaNV.Text;
                                                NhanVien.TenNhanVien = txtTenNV.Text;
                                                NhanVien.DiaChi = txtDiaChi.Text;
                                                NhanVien.DienThoai = txtSDT.Text;
                                                NhanVien.GioiTinh = cbxGioiTinh.Text;
                                                NhanVien.NgaySinh = dtpNgaySinh.Text;
                                                NhanVien.MaCa = labMaCa.Text;
                                                NhanVien.MaCV = labMaCV.Text;
                                                NhanVien.GhiChu = txtGhiChu.Text;

                                                Act.UpdateNV(NhanVien);
                                                MessageBox.Show("Đã Sửa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Điện thoại không được để trống", "Chú Ý", MessageBoxButtons.OK);
                                            txtDiaChi.Focus();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Điện thoại không được để trống", "Chú Ý", MessageBoxButtons.OK);
                                        txtSDT.Focus();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Ngày sinh không được để trống", "Chú Ý", MessageBoxButtons.OK);
                                    cbxGioiTinh.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Ngày sinh không được để trống", "Chú Ý", MessageBoxButtons.OK);
                                dtpNgaySinh.Focus();
                            }
                        }

                        else
                        {
                            MessageBox.Show("Mã không được để trống", "Chú Ý", MessageBoxButtons.OK);
                            cbxTenCV.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        cbxTenCa.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Tên không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txtTenNV.Focus();
                }
            }
            else
            {
                try
                {
                    NhanVien.MaNhanVien = txtMaNV.Text;
                    NhanVien.TenNhanVien = txtTenNV.Text;
                    NhanVien.DiaChi = txtDiaChi.Text;
                    NhanVien.DienThoai = txtSDT.Text;
                    NhanVien.GioiTinh = cbxGioiTinh.Text;
                    NhanVien.NgaySinh = dtpNgaySinh.Text;
                    NhanVien.MaCa = labMaCa.Text;
                    NhanVien.MaCV = labMaCV.Text;
                    NhanVien.GhiChu = txtGhiChu.Text;

                    Act.DeleteNV(NhanVien);
                    MessageBox.Show("Đã Xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            this.Hide();
            FNhanVien fhanghoa = new FNhanVien();
            fhanghoa.MdiParent = main;
            fhanghoa.main = main;
            fhanghoa.Show();
        }

        private void FAddNhanVien_Load(object sender, EventArgs e)
        {
            //txtMaNV.Text = AutoID.TaoMa(1);
            Act.LoadTenCa(cbxTenCa);
            Act.LoadTenCV(cbxTenCV);
            cbxTenCa.Text = Act.LoadTenCa(cbxTenCa.Text, labMaCa.Text);
            cbxTenCV.Text = Act.LoadTenCV(cbxTenCV.Text, labMaCV.Text);
        }

        private void cbxMaCa_SelectedIndexChanged(object sender, EventArgs e)
        {
            labMaCa.Text = Act.LoadMaCa(labMaCa.Text, cbxTenCa.Text);
        }

        private void cbxCV_SelectedIndexChanged(object sender, EventArgs e)
        {
            labMaCV.Text = Act.LoadMaCV(labMaCV.Text, cbxTenCV.Text);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Hide();
            FNhanVien fhanghoa = new FNhanVien();
            fhanghoa.MdiParent = main;
            fhanghoa.main = main;
            fhanghoa.Show();
        }
    }
}
