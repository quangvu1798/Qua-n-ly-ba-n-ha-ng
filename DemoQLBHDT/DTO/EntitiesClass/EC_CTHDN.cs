using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQLBHDT.DTO.EntitiesClass
{
    class EC_CTHDN
    {
        private string _SoHDN;
        private string _MaHang;
        private string _SoLuong;
        private string _ThanhTien;

        public string SoHDN
        {
            get
            {
                return _SoHDN;
            }
            set
            {
                _SoHDN = value;
                if (_SoHDN == "")
                {
                    throw new Exception("Mã Đơn Nhập Hàng Không Được Trống!");
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
