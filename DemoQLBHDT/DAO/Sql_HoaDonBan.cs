using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DemoQLBHDT.DTO.EntitiesClass;
using System.Windows.Forms;

namespace DemoQLBHDT.DAO
{
    class Sql_HoaDonBan
    {
        ConnectDataBase Connect = new ConnectDataBase();
        public bool CheckHDB(string _sohdb)
        {
            return Connect.Check("select count(*) from tb_HDB where sohdb = N'" + _sohdb + "'");
        }

        public DataTable CreateTbHDB()
        {
            return Connect.CreateTable("select * from tb_HDB");
        }

        public DataTable CreateTbHDB(EC_HoaDonBan _hdb)
        {
            if (_hdb.NgayLap == "%")
            {
                string sqlquery = "SELECT * FROM tb_HDB where sohdb like N'%{0}%' and manv like N'%{1}%' and ngaylap like '%{2}%' and makh like '%{3}%' and tongtien like '%{4}%'";
                sqlquery = string.Format(sqlquery, _hdb.SoHDB, _hdb.MaNV, _hdb.NgayLap, _hdb.MaKH, _hdb.TongTien);
                return Connect.CreateTable(sqlquery);
            }
            else
            {
                string sqlquery = "SELECT * FROM tb_HDB where sohdb like N'%{0}%' and manv like N'%{1}%' and ngaylap = '{2}' and makh like '%{3}%' and tongtien like '%{4}%'";
                sqlquery = string.Format(sqlquery, _hdb.SoHDB, _hdb.MaNV, _hdb.NgayLap, _hdb.MaKH, _hdb.TongTien);
                return Connect.CreateTable(sqlquery);
            }
        }

        public void AddHDB(EC_HoaDonBan _hd)
        {
            string sqlquery = (@"INSERT INTO tb_HDB ( sohdb, manv, ngaylap, makh, tongtien) 
                VALUES   (N'{0}',N'{1}','{2}',N'{3}','{4}')");
            sqlquery = string.Format(sqlquery, _hd.SoHDB, _hd.MaNV, _hd.NgayLap, _hd.MaKH, _hd.TongTien);
            Connect.ExcuteNonQuery(sqlquery);

        }

        public void DeleteHDB(EC_HoaDonBan _hd)
        {
            Connect.ExcuteNonQuery("DELETE FROM [tb_CTHDB] WHERE  sohdb=N'" + _hd.SoHDB + "'");
            Connect.ExcuteNonQuery("DELETE FROM [tb_HDB] WHERE  sohdb=N'" + _hd.SoHDB + "'");
        }

        public void UpdateHDB(EC_HoaDonBan _hd)
        {
            string sqlquery = (@"UPDATE    tb_HDB
                    SET manv =N'{0}', ngaylap ='{1}', makh =N'{2}', tongtien ='{3}' where sohdb=N'{4}'");
            sqlquery = string.Format(sqlquery, _hd.MaNV, _hd.NgayLap, _hd.MaKH, _hd.TongTien, _hd.SoHDB);
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

        //ĐGB
        public string LoadDGB(string _dgb, string _mahh)
        {
            _dgb = Connect.LoadLable("Select dongiaban from tb_Hanghoa where mahang = N'" + _mahh + "'");
            return _dgb;
        }

        //Khách Hàng
        public void LoadMaKH(ComboBox _cbxmakh)
        {
            Connect.LoadLenCombobox(_cbxmakh, "SELECT     makh FROM tb_Khachhang", 0);
        }
        public void LoadTenKH(ComboBox _cbxtenkh)
        {
            Connect.LoadLenCombobox(_cbxtenkh, "SELECT     tenkh FROM tb_Khachhang", 0);
        }
        public string LoadTenKH(string _tenkh, string _makh)
        {
            _tenkh = Connect.LoadLable("SELECT [tenkh] From [tb_Khachhang] where makh= N'" + _makh + "'");
            return _tenkh;
        }
        public string LoadMaKH(string _makh, string _tenkh)
        {
            _makh = Connect.LoadLable("SELECT [makh] From [tb_Khachhang] where tenkh= N'" + _tenkh + "'");
            return _makh;
        }
        public string LoadDiaChi(string _dc, string _makh)
        {
            _dc = Connect.LoadLable("SELECT [diachi] From [tb_Khachhang] where makh= N'" + _makh + "'");
            return _dc;
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
