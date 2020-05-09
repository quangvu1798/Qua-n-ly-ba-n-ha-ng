using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DemoQLBHDT.DTO.EntitiesClass;
using System.Windows.Forms;

namespace DemoQLBHDT.DAO
{
    class Sql_HDN
    {
        ConnectDataBase Connect = new ConnectDataBase();
        public bool CheckHDN(string _sohdn)
        {
            return Connect.Check("select count(*) from tb_HDN where sohdn = N'" + _sohdn + "'");
        }

        public DataTable CreateTbHDN()
        {
            return Connect.CreateTable("select * from tb_HDN");
        }

        public DataTable CreateTbHDN(EC_HDN _hdn)
        {
            if (_hdn.NgayNhap != "%")
            {
                return Connect.CreateTable(string.Format("select * from tb_HDN where sohdn like N'%{0}%' and mancc like N'%{1}%' and ngaynhap = '{2}' and manv like N'%{3}%' and tongtien like '%{4}%'", _hdn.SoHDN, _hdn.MaNCC, _hdn.NgayNhap, _hdn.MaNV, _hdn.TongTien));
            }
            else
            {
                return Connect.CreateTable(string.Format("select * from tb_HDN where sohdn like N'%{0}%' and mancc like N'%{1}%' and ngaynhap like '%{2}%' and manv like N'%{3}%' and tongtien like '%{4}%'", _hdn.SoHDN, _hdn.MaNCC, _hdn.NgayNhap, _hdn.MaNV, _hdn.TongTien));

            }
        }

        public void AddHDN(EC_HDN _hdn)
        {
            string sqlquery = (@"INSERT INTO tb_HDN ( sohdn, mancc, ngaynhap, manv, tongtien) 
                VALUES   (N'{0}',N'{1}','{2}',N'{3}','{4}')");
            sqlquery = string.Format(sqlquery, _hdn.SoHDN, _hdn.MaNCC, _hdn.NgayNhap, _hdn.MaNV, _hdn.TongTien);
            Connect.ExcuteNonQuery(sqlquery);

        }

        public void DeleteHDN(EC_HDN _hdn)
        {
            Connect.ExcuteNonQuery("DELETE FROM [tb_CTHDN] WHERE  sohdn=N'" + _hdn.SoHDN + "'");
            Connect.ExcuteNonQuery("DELETE FROM [tb_HDN] WHERE  sohdn=N'" + _hdn.SoHDN + "'");
        }

        public void UpdateHDN(EC_HDN _hdn)
        {
            string sqlquery = (@"UPDATE    tb_HDN
                    SET mancc =N'{0}', ngaynhap ='{1}', manv =N'{2}', tongtien ='{3}' where sohdn=N'{4}'");
            sqlquery = string.Format(sqlquery, _hdn.MaNCC, _hdn.NgayNhap, _hdn.MaNV, _hdn.TongTien, _hdn.SoHDN);
            Connect.ExcuteNonQuery(sqlquery);
        }

        //Hàng Hóa
        public void LoadMaHH(ComboBox _cbxmahh)
        {
            Connect.LoadLenCombobox(_cbxmahh, "SELECT     mahang FROM tb_Hanghoa", 0);
        }
        public string LoadTenHH(string _tenhh, string _mahh)
        {
            _tenhh = Connect.LoadLable("SELECT [tenhang] From [tb_Hanghoa] where mahang= N'" + _mahh + "'");
            return _tenhh;
        }

        //ĐVT        
        public string LoadTenDonViTinh(string _tendv, string _madv)
        {
            _tendv = Connect.LoadLable("SELECT [tendonvi] From [tb_Donvitinh] where madonvi= N'" + _madv + "'");
            return _tendv;
        }

        public string LoadMaDonViTinh(string _madv, string _mahh)
        {
            _madv = Connect.LoadLable("SELECT [madonvi] From [tb_Hanghoa] where mahang= N'" + _mahh + "'");
            return _madv;
        }

        //ĐGN
        public string LoadDGN(string _dgn, string _mahh)
        {
            _dgn = Connect.LoadLable("Select dongianhap from tb_Hanghoa where mahang = N'" + _mahh + "'");
            return _dgn;
        }

        //Nhà CC
        public void LoadMaNCC(ComboBox _cbxmancc)
        {
            Connect.LoadLenCombobox(_cbxmancc, "SELECT     mancc FROM tb_NCC", 0);
        }
        public void LoadTenNCC(ComboBox _cbxtenncc)
        {
            Connect.LoadLenCombobox(_cbxtenncc, "SELECT     tenncc FROM tb_NCC", 0);
        }
        public string LoadTenNCC(string _tenncc, string _mancc)
        {
            _tenncc = Connect.LoadLable("SELECT [tenncc] From [tb_NCC] where mancc= N'" + _mancc + "'");
            return _tenncc;
        }
        public string LoadMaNCC(string _mancc, string _tenncc)
        {
            _mancc = Connect.LoadLable("SELECT [mancc] From [tb_NCC] where tenncc= N'" + _tenncc + "'");
            return _mancc;
        }

        //Nhân Viên
        public void LoadMaNV(ComboBox _cbxmanv)
        {
            Connect.LoadLenCombobox(_cbxmanv, "SELECT     manv FROM tb_Nhanvien", 0);
        }
        public void LoadTenNV(ComboBox _cbxtennv)
        {
            Connect.LoadLenCombobox(_cbxtennv, "SELECT     tennv FROM tb_Nhanvien", 0);
        }
        public string LoadTenNV(string _tennv, string _manv)
        {
            _tennv = Connect.LoadLable("SELECT [tennv] From [tb_Nhanvien] where manv= N'" + _manv + "'");
            return _tennv;
        }
        public string LoadMaNV(string _manv, string _tennv)
        {
            _manv = Connect.LoadLable("SELECT [manv] From [tb_Nhanvien] where tennv= N'" + _tennv + "'");
            return _manv;
        }
    }
}
