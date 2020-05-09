using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQLBHDT.DTO.EntitiesClass
{
    class EC_ChiTietHDB
    {
        private string _SoHDB;
        private string _MaHang;
        private string _SoLuong;
        private string _ThanhTien;

        public string SoHDB
        {
            get
            {
                return _SoHDB;
            }
            set
            {
                _SoHDB = value;
                if (_SoHDB == "")
                {
                    throw new Exception("Mã Đơn Bán Hàng Không Được Trống!");
                }
            }
        }
        public string MaHang
        {
            get
            {
                return _MaHang;
            }
            set
            {
                _MaHang = value;
                if (_MaHang == "")
                {
                    throw new Exception("Mã Hàng Hóa Không Được Trống!");
                }
            }
        }

        public string SoLuong
        {
            get
            {
                return _SoLuong;
            }
            set
            {
                _SoLuong = value;
                if (_SoLuong == "")
                {
                    throw new Exception("Số Lượng Không Được Trống!");
                }
            }
        }

        public string ThanhTien
        {
            get
            {
                return _ThanhTien;
            }
            set
            {
                _ThanhTien = value;
            }
        }

    }
}
