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
    class Sql_DonDHNCC
    {
        ConnectDataBase Connect = new ConnectDataBase();
        public bool CheckDonDHNCC(string _madondhncc)
        {
            return Connect.Check("select count(*) from tb_DonDHNCC where madhncc = N'" + _madondhncc + "'");
        }

        public DataTable CreateTbDonDHNCC()
        {
            return Connect.CreateTable("select * from tb_DonDHNCC");
        }

        public DataTable CreateTbDonDHNCC(EC_DonDHNCC _dondhncc)
        {
            if (_dondhncc.NgayDat != "%")
            {
                return Connect.CreateTable(string.Format("select * from tb_DonDHNCC where madhncc like N'%{0}%' and mancc like N'%{1}%' and ngaydat = '{2}' and manv like N'%{3}%'", _dondhncc.MaDonDHNCC, _dondhncc.MaNCC, _dondhncc.NgayDat, _dondhncc.MaNV));
            }
            else
            {
                return Connect.CreateTable(string.Format("select * from tb_DonDHNCC where madhncc like N'%{0}%' and mancc like N'%{1}%' and ngaydat like '%{2}%' and manv like N'%{3}%'", _dondhncc.MaDonDHNCC, _dondhncc.MaNCC, _dondhncc.NgayDat, _dondhncc.MaNV));

            }
        }

        public void AddDonDHNCC(EC_DonDHNCC _dondhncc)
        {
            string sqlquery = (@"INSERT INTO tb_DonDHNCC ( madhncc, mancc, ngaydat, manv) 
                VALUES   (N'{0}',N'{1}','{2}',N'{3}')");
            sqlquery = string.Format(sqlquery, _dondhncc.MaDonDHNCC, _dondhncc.MaNCC, _dondhncc.NgayDat, _dondhncc.MaNV);
            Connect.ExcuteNonQuery(sqlquery);

        }

        public void DeleteDonDHNCC(EC_DonDHNCC _dondhncc)
        {
            Connect.ExcuteNonQuery("DELETE FROM [tb_CTDonDHNCC] WHERE  madhncc=N'" + _dondhncc.MaDonDHNCC + "'");
            Connect.ExcuteNonQuery("DELETE FROM [tb_DonDHNCC] WHERE  madhncc=N'" + _dondhncc.MaDonDHNCC + "'");
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

        //NCC
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
