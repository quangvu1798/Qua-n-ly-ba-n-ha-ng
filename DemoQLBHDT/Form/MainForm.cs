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

namespace DemoQLBHDT
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }        

        public string Access = "";
        public EC_User User;

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Access != "admin")
            {
                this.tàiKhoảnToolStripMenuItem.Enabled = false;
                this.nhânViênToolStripMenuItem.Enabled = false;
            }
        }

        private Form CheckTonTai(Type _formtype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == _formtype)
                    return f;
            }
            return null;
        }

        private void sảnPhẩmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = CheckTonTai(typeof(FHangHoa));
            if (form != null)
                form.Activate();
            else
            {
                FHangHoa newform = new FHangHoa();
                newform.MdiParent = this;
                newform.main = this;
                newform.Show();
            }
        }

        private void nhómHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = CheckTonTai(typeof(FNhomHang));
            if (form != null)
            {
                form.Activate();
                //form.Show();                
            }
            else
            {
                FNhomHang newform = new FNhomHang();
                newform.MdiParent = this;
                newform.main = this;
                newform.Show();
            }
        }

        private void đơnVịTínhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = CheckTonTai(typeof(FDonViTinh));
            if (form != null)
                form.Activate();
            else
            {
                FDonViTinh newform = new FDonViTinh();
                newform.MdiParent = this;
                newform.main = this;
                newform.Show();
            }
        }

        private void nướcSảnXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = CheckTonTai(typeof(FNuocSX));
            if (form != null)
                form.Activate();
            else
            {
                FNuocSX newform = new FNuocSX();
                newform.MdiParent = this;
                newform.main = this;
                newform.Show();
            }
        }

        private void caLàmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = CheckTonTai(typeof(FCaLam));
            if (form != null)
                form.Activate();
            else
            {
                FCaLam newform = new FCaLam();
                newform.MdiParent = this;
                newform.main = this;
                newform.Show();
            }
        }

        private void côngViệcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = CheckTonTai(typeof(FCongViec));
            if (form != null)
                form.Activate();
            else
            {
                FCongViec newform = new FCongViec();
                newform.MdiParent = this;
                newform.main = this;
                newform.Show();
            }
        }

        private void nhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = CheckTonTai(typeof(FNhanVien));
            if (form != null)
                form.Activate();
            else
            {
                FNhanVien newform = new FNhanVien();
                newform.MdiParent = this;
                newform.main = this;
                newform.Show();
            }
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = CheckTonTai(typeof(FKhachHang));
            if (form != null)
                form.Activate();
            else
            {
                FKhachHang newform = new FKhachHang();
                newform.MdiParent = this;
                newform.main = this;
                newform.Show();
            }
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = CheckTonTai(typeof(FNhaCC));
            if (form != null)
                form.Activate();
            else
            {
                FNhaCC newform = new FNhaCC();
                newform.MdiParent = this;
                newform.main = this;
                newform.Show();
            }
        }        

        private void hóaĐơnXuấtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = CheckTonTai(typeof(FBanHang));
            if (form != null)
                form.Activate();
            else
            {
                FBanHang newform = new FBanHang();
                newform.MdiParent = this;
                newform.User = User;
                newform.Show();
            }
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = CheckTonTai(typeof(FTaiKhoan));
            if (form != null)
                form.Activate();
            else
            {
                FTaiKhoan newform = new FTaiKhoan();
                newform.MdiParent = this;
                newform.main = this;
                newform.Show();
            }
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FLogin newform = new FLogin();
            newform.Show();
            this.Close();
        }

        private void danhMụcHóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = CheckTonTai(typeof(FHoaDonBan));
            if (form != null)
                form.Activate();
            else
            {
                FHoaDonBan newform = new FHoaDonBan();
                newform.MdiParent = this;
                newform.main = this;
                newform.Show();
            }
        }

        private void đặtHàngNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = CheckTonTai(typeof(FDatHangNCC));
            if (form != null)
                form.Activate();
            else
            {
                FDatHangNCC newform = new FDatHangNCC();
                newform.MdiParent = this;
                newform.User = User;
                newform.Show();
            }
        }

        private void danhMụcĐơnĐặtHàngNCCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = CheckTonTai(typeof(FDonDHNCC));
            if (form != null)
                form.Activate();
            else
            {
                FDonDHNCC newform = new FDonDHNCC();
                newform.MdiParent = this;
                newform.main = this;
                //newform.User = User;
                newform.Show();
            }
        }

        private void hóaĐơnNhậpHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = CheckTonTai(typeof(FNhapHang));
            if (form != null)
                form.Activate();
            else
            {
                FNhapHang newform = new FNhapHang();
                newform.MdiParent = this;
                newform.User = User;
                newform.Show();
            }
        }

        private void danhMụcHóaĐơnNhậpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = CheckTonTai(typeof(FHDN));
            if (form != null)
                form.Activate();
            else
            {
                FHDN newform = new FHDN();
                newform.MdiParent = this;
                newform.main = this;
                //newform.User = User;
                newform.Show();
            }
        }

        private void đơnĐặtHàngCủaKháchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = CheckTonTai(typeof(FDatHang));
            if (form != null)
                form.Activate();
            else
            {
                FDatHang newform = new FDatHang();
                newform.MdiParent = this;
                //newform.User = User;
                newform.Show();
            }
        }

        private void danhMụcĐơnĐặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = CheckTonTai(typeof(FDonDH));
            if (form != null)
                form.Activate();
            else
            {
                FDonDH newform = new FDonDH();
                newform.MdiParent = this;
                newform.main = this;
                //newform.User = User;
                newform.Show();
            }
        }

        private void sảnPhẩmBánChạyNhấtToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FTKSPBanChayNhat newform = new FTKSPBanChayNhat();
            newform.MdiParent = this;
            newform.TieuDe = "Sản Phẩm Bán Chạy Nhất";
            //newform.main = this;
            //newform.User = User;
            newform.Show();

        }

        private void sảnPhẩmBánChậmNhấtToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FTKSPBanChayNhat newform = new FTKSPBanChayNhat();
            newform.MdiParent = this;
            newform.TieuDe = "Sản Phẩm Bán Chậm Nhất";
            //newform.main = this;
            //newform.User = User;
            newform.Show();

        }

        private void top5KháchHàngTiềmNăngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = CheckTonTai(typeof(FTKKHTiemNang));
            if (form != null)
                form.Activate();
            else
            {
                FTKKHTiemNang newform = new FTKKHTiemNang();
                newform.MdiParent = this;                
                newform.Show();
            }
        }

        private void giáTrịTrungBìnhCủaMỗiHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = CheckTonTai(typeof(FTKGTTBHDB));
            if (form != null)
                form.Activate();
            else
            {
                FTKGTTBHDB newform = new FTKGTTBHDB();
                newform.MdiParent = this;
                newform.Show();
            }
        }

        private void thôngTinKháchHàngMuaHóaĐơnGiáTrịCaoNhấtToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FTKKHMuaHDGTNhat newform = new FTKKHMuaHDGTNhat();
            newform.MdiParent = this;
            newform.TieuDe = "TOP 5 KHÁCH HÀNG CÓ HÓA ĐƠN GIÁ TRỊ NHẤT";
            newform.Show();

        }

        private void kháchHàngMuaNhiềuLầnNhấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                FTKKHMuaHDGTNhat newform = new FTKKHMuaHDGTNhat();
                newform.MdiParent = this;
                newform.TieuDe = "TOP 5 KHÁCH HÀNG CÓ SỐ LẦN MUA NHIỀU NHẤT";
                newform.Show();
            
        }

        private void danhSáchSảnPhẩmChưaBánĐượcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FTKSPBanChayNhat newform = new FTKSPBanChayNhat();
            newform.MdiParent = this;
            newform.TieuDe = "Sản Phẩm Chưa Bán Được";
            //newform.main = this;
            //newform.User = User;
            newform.Show();
        }

        private void doanhThuBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = CheckTonTai(typeof(FTKDoanhThuTheoThang));
            if (form != null)
                form.Activate();
            else
            {
                FTKDoanhThuTheoThang newform = new FTKDoanhThuTheoThang();
                newform.MdiParent = this;
                newform.Show();
            }
        }

        private void nhânViênLậpNhiềuHóaĐơnBánNhấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FTKNVLapNhieuHDNhat newform = new FTKNVLapNhieuHDNhat();
            newform.MdiParent = this;
            newform.TieuDe = "Nhân Viên Lập Nhiều Hóa Đơn Bán Nhất";
            newform.Show();
        }

        private void nToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FTKNVLapNhieuHDNhat newform = new FTKNVLapNhieuHDNhat();
            newform.MdiParent = this;
            newform.TieuDe = "Nhân Viên Lập Nhiều Hóa Đơn Nhập Nhất";
            newform.Show();
        }
    }
}
