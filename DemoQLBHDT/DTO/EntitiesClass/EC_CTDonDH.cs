using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQLBHDT.DTO.EntitiesClass
{
    class EC_CTDonDH
    {
        private string _MaDonDH;
        private string _MaHangHoa;
        private string _SoLuong;

        public string MaDonDH
        {
            get
            {
                return _MaDonDH;
            }
            set
            {
                _MaDonDH = value;
                if (_MaDonDH == "")
                {
                    throw new Exception("Mã Đơn Đặt Hàng Nhà Cung Cấp Không Được Trống!");
                }
            }
        }

        public string MaHangHoa
        {
            get
            {
                return _MaHangHoa;
            }
            set
            {
                _MaHangHoa = value;
                if (_MaHangHoa == "")
                {
                    throw new Exception("Mã Đơn Đặt Hàng Nhà Cung Cấp Không Được Trống!");
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
                    throw new Exception("Mã Đơn Đặt Hàng Nhà Cung Cấp Không Được Trống!");
                }
            }
        }
    }
}
