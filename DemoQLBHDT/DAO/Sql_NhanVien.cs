using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DemoQLBHDT.DTO.EntitiesClass;
using System.Windows.Forms;
using System.Data;

namespace DemoQLBHDT.DAO
{
    class Sql_NhanVien
    {
        ConnectDataBase Connect = new ConnectDataBase();
        //EC_NhanVien NhanVien = new EC_NhanVien();

        public bool CheckNV(string _manv)
        {
            return Connect.Check("select count(*) from [tb_Nhanvien] where manv=N'" + _manv + "'");
        }

        public DataTable CreateTbNV()
        {
            string sqlquery = "SELECT manv, tennv, gioitinh, ngaysinh, dienthoai, quequan, ghichu, maca, macv FROM tb_Nhanvien";
            return Connect.CreateTable(sqlquery);
        }

        public DataTable CreateTbNV(EC_NhanVien _nhanvien)
        {
            if (_nhanvien.NgaySinh != "%")
            {
                string sqlquery = "SELECT * FROM tb_Nhanvien where manv like N'%{0}%' and tennv like N'%{1}%' and gioitinh like N'%{2}%' and ngaysinh = '{3}' and dienthoai like N'%{4}%'" +
                    "and quequan like N'%{5}%' and ghichu like N'%{6}%' and maca like N'%{7}%' and macv like N'%{8}%'";
                sqlquery = string.Format(sqlquery, _nhanvien.MaNhanVien, _nhanvien.TenNhanVien, _nhanvien.GioiTinh, _nhanvien.NgaySinh, _nhanvien.DienThoai, _nhanvien.DiaChi, _nhanvien.GhiChu, _nhanvien.MaCa, _nhanvien.MaCV);
                return Connect.CreateTable(sqlquery);
            }
            else
            {
                string sqlquery = "SELECT * FROM tb_Nhanvien where manv like N'%{0}%' and tennv like N'%{1}%' and gioitinh like N'%{2}%' and ngaysinh like '%{3}%' and dienthoai like N'%{4}%'" +
                    "and quequan like N'%{5}%' and ghichu like N'%{6}%' and maca like N'%{7}%' and macv like N'%{8}%'";
                sqlquery = string.Format(sqlquery, _nhanvien.MaNhanVien, _nhanvien.TenNhanVien, _nhanvien.GioiTinh, _nhanvien.NgaySinh, _nhanvien.DienThoai, _nhanvien.DiaChi, _nhanvien.GhiChu, _nhanvien.MaCa, _nhanvien.MaCV);
                return Connect.CreateTable(sqlquery);
            }
        }

        public void AddNV(EC_NhanVien _nv)
        {
            //_nv.MaNhanVien = Connect.TaoMa(1);
            string sqlquery = @"INSERT INTO tb_Nhanvien
                      (manv, tennv, gioitinh, ngaysinh, dienthoai, quequan, ghichu, maca, macv)
                        VALUES   (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}')";
            sqlquery = string.Format(sqlquery, _nv.MaNhanVien, _nv.TenNhanVien, _nv.GioiTinh, _nv.NgaySinh, _nv.DienThoai,
                _nv.DiaChi, _nv.GhiChu, _nv.MaCa, _nv.MaCV);
            Connect.ExcuteNonQuery(sqlquery);
        }
        public void DeleteNV(EC_NhanVien _nv)
        {
            Connect.ExcuteNonQuery("DELETE FROM [tb_Nhanvien] WHERE manv=N'" + _nv.MaNhanVien + "'");
        }

        public void UpdateNV(EC_NhanVien _nv)
        {
            string sqlquery = (@"UPDATE    tb_Nhanvien
                    SET tennv =N'{0}', gioitinh =N'{1}', ngaysinh =N'{2}', dienthoai =N'{3}', quequan =N'{4}',
                   ghichu =N'{5}', maca =N'{6}', macv =N'{7}'  where manv=N'{8}'");
            sqlquery = string.Format(sqlquery, _nv.TenNhanVien, _nv.GioiTinh, _nv.NgaySinh, _nv.DienThoai,
                _nv.DiaChi, _nv.GhiChu, _nv.MaCa, _nv.MaCV, _nv.MaNhanVien);
            Connect.ExcuteNonQuery(sqlquery);
        }

        //load ca
        public void LoadTenCa(ComboBox _tenca)
        {
            Connect.LoadLenCombobox(_tenca, "SELECT     tenca FROM tb_Calam", 0);
        }
        public string LoadMaCa(string _maca, string _tenca)
        {
            _maca = Connect.LoadLable("SELECT [maca] From [tb_Calam] where tenca= N'" + _tenca + "'");
            return _maca;
        }
        public string LoadTenCa(string _tenca, string _maca)
        {
            _tenca = Connect.LoadLable("SELECT [tenca] From [tb_Calam] where maca= N'" + _maca + "'");
            return _tenca;
        }
        //load cv
        public void LoadTenCV(ComboBox _tencv)
        {
            Connect.LoadLenCombobox(_tencv, "SELECT     tencv FROM tb_Congviec", 0);
        }
        public string LoadMaCV(string _macv, string _tencv)
        {
            _macv = Connect.LoadLable("SELECT [macv] From [tb_Congviec] where tencv= N'" + _tencv + "'");
            return _macv;
        }
        public string LoadTenCV(string _tencv, string _macv)
        {
            _tencv = Connect.LoadLable("SELECT [tencv] From [tb_Congviec] where macv= N'" + _macv + "'");
            return _tencv;
        }
    }
}
