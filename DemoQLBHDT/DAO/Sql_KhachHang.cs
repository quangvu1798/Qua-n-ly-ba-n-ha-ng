using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DemoQLBHDT.DAO;
using DemoQLBHDT.DTO.EntitiesClass;


namespace DemoQLBHDT.DAO
{
    class Sql_KhachHang
    {
        ConnectDataBase Connect = new ConnectDataBase();
        public bool CheckKH(string _makh)
        {
            return Connect.Check("select count(*) from [tb_Khachhang] where makh=N'" + _makh + "'");
        }

        public DataTable CreateTbKH()
        {
            string sqlquery = "SELECT makh, tenkh, diachi, dienthoai FROM tb_Khachhang";
            return Connect.CreateTable(sqlquery);
        }

        public DataTable CreateTbKH(EC_KhachHang _kh)
        {
            string sqlquery = "SELECT * FROM tb_Khachhang where makh like N'%{0}%' and tenkh like N'%{1}%' and diachi like N'%{2}%' and dienthoai like N'%{3}%'";
            sqlquery = string.Format(sqlquery, _kh.MaKH, _kh.TenKH, _kh.DiaChi, _kh.DienThoai);
            return Connect.CreateTable(sqlquery);
        }

        public void AddKH(EC_KhachHang _kh)
        {
            string sqlquery = (@"INSERT INTO tb_Khachhang ( makh, tenkh, diachi, dienthoai) 
                VALUES   (N'{0}',N'{1}',N'{2}',N'{3}')");
            sqlquery = string.Format(sqlquery, _kh.MaKH, _kh.TenKH, _kh.DiaChi, _kh.DienThoai);
            Connect.ExcuteNonQuery(sqlquery);

        }
        public void DeleteKH(EC_KhachHang _kh)
        {
            Connect.ExcuteNonQuery("DELETE FROM [tb_Khachhang] WHERE  makh=N'" + _kh.MaKH + "'");
        }

        public void UpdateKH(EC_KhachHang _kh)
        {
            string sqlquery = (@"UPDATE    tb_Khachhang
                    SET tenkh =N'{0}', diachi =N'{1}', dienthoai =N'{2}' where makh=N'{3}'");
            sqlquery = string.Format(sqlquery, _kh.TenKH, _kh.DiaChi, _kh.DienThoai, _kh.MaKH);
            Connect.ExcuteNonQuery(sqlquery);
        }
    }
}
