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
    class Sql_DonDH
    {
        ConnectDataBase Connect = new ConnectDataBase();
        public bool CheckDonDH(string _madondh)
        {
            return Connect.Check("select count(*) from tb_DonDH where madondh = N'" + _madondh + "'");
        }

        public DataTable CreateTbDonDH()
        {
            return Connect.CreateTable("select * from tb_DonDH");
        }

        public DataTable CreateTbDonDH(EC_DonDH _dondh)
        {
            if (_dondh.NgayDat != "%")
            {
                return Connect.CreateTable(string.Format("select * from tb_DonDH where madondh like N'%{0}' and makh like N'%{1}%' and ngaydat = '{2}'", _dondh.MaDonDH, _dondh.MaKH, _dondh.NgayDat));
            }
            else
            {
                return Connect.CreateTable(string.Format("select * from tb_DonDH where madondh like N'%{0}' and makh like N'%{1}%' and ngaydat like '%{2}%'", _dondh.MaDonDH, _dondh.MaKH, _dondh.NgayDat));
            }
        }

        public void AddDonDH(EC_DonDH _dondh)
        {
            string sqlquery = (@"INSERT INTO tb_DonDH ( madondh, makh, ngaydat) 
                VALUES   (N'{0}',N'{1}','{2}')");
            sqlquery = string.Format(sqlquery, _dondh.MaDonDH, _dondh.MaKH, _dondh.NgayDat);
            Connect.ExcuteNonQuery(sqlquery);

        }

        public void DeleteDonDH(EC_DonDH _dondh)
        {
            Connect.ExcuteNonQuery("DELETE FROM [tb_CTDonDH] WHERE  madondh=N'" + _dondh.MaDonDH + "'");
            Connect.ExcuteNonQuery("DELETE FROM [tb_DonDH] WHERE  madondh=N'" + _dondh.MaDonDH + "'");
        }

        //public void UpdateHDB(EC_DonDHNCC _dondhncc)
        //{
        //    string sqlquery = (@"UPDATE    tb_DonDHNCC
        //            SET mancc =N'{0}', ngaydat ='{1}', manv =N'{2}' where madhncc=N'{3}'");
        //    sqlquery = string.Format(sqlquery, _dondhncc.MaNCC, _dondhncc.NgayDat, _dondhncc.MaNV, _dondhncc.MaDonDHNCC);
        //    Connect.ExcuteNonQuery(sqlquery);
        //}

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
    }
}
