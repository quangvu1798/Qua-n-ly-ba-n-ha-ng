using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DemoQLBHDT.DAO;

namespace DemoQLBHDT.DTO.Component
{
    class C_ThongKe
    {
        Sql_ThongKe sqlthongke = new Sql_ThongKe();
        
        public DataTable SPBanChayNhat()
        {
            return sqlthongke.SPBanChayNhat();
        }

        public DataTable SPBanChamNhat()
        {
            return sqlthongke.SPBanChamNhat();
        }

        public DataTable KHTiemNang()
        {
            return sqlthongke.KHTiemNang();
        }

        public string GTTBCuaHDB(string _nam)
        {
            return sqlthongke.GTTBCuaHD(_nam);
        }

        public DataTable KHMuaHDGTNhat()
        {
            return sqlthongke.KHMuaHDGTNhat();
        }

        public DataTable KHMuaNhieuLanNhat()
        {
            return sqlthongke.KHMuaNhieuLanNhat();
        }

        public DataTable SPChuaBan()
        {
            return sqlthongke.SPChuaBan();
        }

        public DataTable DoanhThuThang(string _nam)
        {
            return sqlthongke.DoanhThuTheoThang(_nam);
        }

        public DataTable NVLapNhieuHDBNhat()
        {
            return sqlthongke.NVLapNhieuHDBNhat();
        }

        public DataTable NVLapNhieuHDNNhat()
        {
            return sqlthongke.NVLapNhieuHDNNhat();
        }
    }
}
