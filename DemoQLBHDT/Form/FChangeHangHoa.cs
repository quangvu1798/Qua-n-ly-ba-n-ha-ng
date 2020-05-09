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
    public partial class FChangeHangHoa : Form
    {
        public FChangeHangHoa()
        {
            InitializeComponent();
        }

        public MainForm main = new MainForm();

        EC_HangHoa HangHoa = new EC_HangHoa();
        C_HangHoa Act = new C_HangHoa();
        C_AutoID AutoID = new C_AutoID();

        public void AddThongTin(string[] _input)
        {
            labTacVu.Text = _input[0];
            txtMaHangHoa.Text = _input[1];
            txtTenHangHoa.Text = _input[2];
            labMaNhom.Text = _input[3];
            labMaDVT.Text = _input[4];
            labMaNuocSX.Text = _input[5];
            //txtSoLuong.Text = _input[6];
            txtDGN.Text = _input[6];
            txtDGB.Text = _input[7];
            txtGhiChu.Text = _input[8];
            cbxTenNuocSX.Text = Act.LoadTenNuocSX(cbxTenNuocSX.Text, labMaNuocSX.Text);
            cbxTenNhom.Text = Act.LoadTenNhom(cbxTenNhom.Text, labMaNhom.Text);
            cbxTenDVT.Text = Act.LoadTenDonViTinh(cbxTenDVT.Text, labMaDVT.Text);
            if (labTacVu.Text == "Sửa")
            {
                txtMaHangHoa.Enabled = false;
            }
            else if (labTacVu.Text == "Xóa")
            {
                txtMaHangHoa.Enabled= false;
                txtTenHangHoa.Enabled = false;
                cbxTenNhom.Enabled = false;
                cbxTenDVT.Enabled = false;
                cbxTenNuocSX.Enabled = false;
                //txtSoLuong.Enabled = false;
                txtDGN.Enabled = false;
                txtDGB.Enabled = false;
                txtGhiChu.Enabled = false;
                labLuuY.Text = "Lưu ý: Bạn có chắc muốn xóa!";
            }
            else
            {
                txtMaHangHoa.Text = AutoID.TaoMa(6);
            }
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            if (labTacVu.Text == "Thêm")
            {
                if (txtMaHangHoa.Text != "")
                {
                    if (cbxTenNhom.Text != "")
                    {
                        if (cbxTenDVT.Text != "")
                        {
                            if (txtTenHangHoa.Text!= "")
                            {
                                try
                                {
                                    //byte[] imageData = ReadFile(lbimgpath.Text);
                                    HangHoa.MaHangHoa = txtMaHangHoa.Text;
                                    HangHoa.TenHangHoa = txtTenHangHoa.Text;
                                    HangHoa.MaNhom = labMaNhom.Text;
                                    HangHoa.MaDonVi = labMaDVT.Text;
                                    HangHoa.MaNuoc = labMaNuocSX.Text;
                                    //HangHoa.SoLuong = txtSoLuong.Text;
                                    HangHoa.DonGiaNhap = txtDGN.Text;
                                    HangHoa.DonGiaBan = txtDGB.Text;
                                    HangHoa.GhiChu = txtGhiChu.Text;

                                    Act.AddSP(HangHoa);
                                    AutoID.UpdateAutoID(6);
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
                                txtTenHangHoa.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mã không được để trống", "Chú Ý", MessageBoxButtons.OK);
                            cbxTenDVT.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        cbxTenNhom.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Mã không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txtMaHangHoa.Focus();
                }

            }
            else if(labTacVu.Text=="Sửa")
            {
                if (cbxTenNhom.Text != "")
                {
                    if (cbxTenDVT.Text != "")
                    {
                        if (txtTenHangHoa.Text != "")
                        {
                            try
                            {
                                //byte[] imageData = ReadFile(lbimgpath.Text);
                                HangHoa.MaHangHoa = txtMaHangHoa.Text;
                                HangHoa.TenHangHoa = txtTenHangHoa.Text;
                                HangHoa.MaNhom = labMaNhom.Text;
                                HangHoa.MaDonVi = labMaDVT.Text;
                                HangHoa.MaNuoc = labMaNuocSX.Text;
                                //HangHoa.SoLuong = txtSoLuong.Text;
                                HangHoa.DonGiaNhap = txtDGN.Text;
                                HangHoa.DonGiaBan = txtDGB.Text;
                                HangHoa.GhiChu = txtGhiChu.Text;

                                Act.UpdateSP(HangHoa);
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
                            txtTenHangHoa.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        cbxTenDVT.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Mã không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    cbxTenNhom.Focus();
                }
            }
            else
            {
                HangHoa.MaHangHoa = txtMaHangHoa.Text;
                HangHoa.TenHangHoa = txtTenHangHoa.Text;
                HangHoa.MaNhom = labMaNhom.Text;
                HangHoa.MaDonVi = labMaDVT.Text;
                HangHoa.MaNuoc = labMaNuocSX.Text;
                //HangHoa.SoLuong = txtSoLuong.Text;
                HangHoa.DonGiaNhap = txtDGN.Text;
                HangHoa.DonGiaBan = txtDGB.Text;
                HangHoa.GhiChu = txtGhiChu.Text;
                try
                {
                    Act.DeleteSP(HangHoa);
                    MessageBox.Show("Đã xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Không Thế Xóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            this.Hide();
            FHangHoa fhanghoa = new FHangHoa();
            fhanghoa.MdiParent = main;
            fhanghoa.main = main;
            fhanghoa.Show();
        }

        private void FAddHangHoa_Load(object sender, EventArgs e)
        {
            Act.LoadTenNhom(cbxTenNhom);
            Act.LoadTenDonViTinh(cbxTenDVT);
            Act.LoadTenNuocSX(cbxTenNuocSX);
        }

        private void cbxMaNhom_SelectedIndexChanged(object sender, EventArgs e)
        {
            labMaNhom.Text = Act.LoadMaNhom(labMaNhom.Text, cbxTenNhom.Text);
        }

        private void cbxDVT_SelectedIndexChanged(object sender, EventArgs e)
        {
            labMaDVT.Text = Act.LoadMaDonViTinh(labMaDVT.Text, cbxTenDVT.Text);
        }

        private void cbxNuocSX_SelectedIndexChanged(object sender, EventArgs e)
        {
            labMaNuocSX.Text = Act.LoadMaNuocSX(labMaNuocSX.Text, cbxTenNuocSX.Text);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Hide();
            FHangHoa fhanghoa = new FHangHoa();
            fhanghoa.MdiParent = main;
            fhanghoa.main = main;
            fhanghoa.Show();
        }
    }
}
