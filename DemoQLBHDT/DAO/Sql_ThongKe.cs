using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace DemoQLBHDT.DAO
{
    class Sql_ThongKe
    {
        ConnectDataBase Connect = new ConnectDataBase();
        public DataTable SPBanChayNhat()
        {
            string sqlquery = @"SELECT mahang, tenhang,manhom,madonvi, manuoc, dongiaban,dongianhap,ghichu
                FROM tb_Hanghoa	
                WHERE tb_Hanghoa.mahang = (SELECT TOP 1 mahang FROM tb_CTHDB
                GROUP BY mahang
                ORDER BY SUM(soluong) DESC)";
            return Connect.CreateTable(sqlquery);
        }

        public DataTable SPBanChamNhat()
        {
            string sqlquery = @"SELECT mahang, tenhang,manhom,madonvi, manuoc, dongiaban,dongianhap,ghichu
                FROM tb_Hanghoa	
                WHERE tb_Hanghoa.mahang = (SELECT TOP 1 mahang FROM tb_CTHDB
                GROUP BY mahang
                ORDER BY SUM(soluong) ASC)";
            return Connect.CreateTable(sqlquery);
        }

        public DataTable KHTiemNang()
        {
            string sqlquery = @"select tb_Khachhang.makh, tenkh,diachi,dienthoai
                from tb_HDB, tb_Khachhang
                where tb_HDB.makh = tb_Khachhang.makh
                and sohdb in (select top (5) sohdb from tb_HDB order by tongtien desc)";
            return Connect.CreateTable(sqlquery);
        }

        public string GTTBCuaHD(string _nam)
        {
            string sqlquery = @"select avg(giatri.tongtien)
                from tb_HDB giatri
                where year(giatri.ngaylap)= {0}";
            return Connect.LoadLable(string.Format(sqlquery, _nam));
        }

        public DataTable KHMuaHDGTNhat()
        {
            string sqlquery = @"select kh.makh,kh.tenkh,dienthoai, diachi
                                from tb_Khachhang kh, tb_HDB
                                where tb_HDB.makh = kh.makh 
                                and tb_HDB.tongtien in (select top 5 (tongtien) 
                                from tb_HDB )";
            return Connect.CreateTable(sqlquery);
        }

        public DataTable KHMuaNhieuLanNhat()
        {
            string sqlquery = @"select top 5 tb_HDB.makh, kh.tenkh, kh.diachi, kh.dienthoai
                                from tb_HDB, tb_Khachhang kh
                                where  tb_HDB.makh = kh.makh
                                    group by tb_HDB.makh, kh.tenkh, kh.diachi, kh.dienthoai
                                    order by count (tb_HDB.makh) desc";
            return Connect.CreateTable(sqlquery);
        }

        public DataTable SPChuaBan()
        {
            string sqlquery = @"select * from tb_Hanghoa
                where not exists (select mahang from tb_CTHDB where mahang = tb_Hanghoa.mahang)";
            return Connect.CreateTable(sqlquery);
        }

        public DataTable DoanhThuTheoThang(string _nam)
        {
            string sqlquery = @"select month(hd.ngaylap) 'Tháng' , sum(hd.tongtien) 'Doanh Thu'
                from tb_HDB hd 
                where year(hd.ngaylap) = {0}
                group by month (hd.ngaylap)";
            return Connect.CreateTable(string.Format(sqlquery,_nam));
        }

        public DataTable NVLapNhieuHDBNhat()
        {
            string sqlquery = @"select * from tb_Nhanvien
                where manv = (SELECT TOP 1 manv FROM tb_HDB
                GROUP BY manv
                ORDER BY Count(sohdb) DESC)";
            return Connect.CreateTable(sqlquery);
        }

        public DataTable NVLapNhieuHDNNhat()
        {
            string sqlquery = @"select * from tb_Nhanvien
                where manv = (SELECT TOP 1 manv FROM tb_HDN
                GROUP BY manv
                ORDER BY Count(sohdn) DESC)";
            return Connect.CreateTable(sqlquery);
        }
    }
}
