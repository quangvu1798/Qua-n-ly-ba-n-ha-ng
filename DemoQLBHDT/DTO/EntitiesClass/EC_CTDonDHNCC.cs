using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQLBHDT.DTO.EntitiesClass
{
    class EC_CTDonDHNCC
    {
        private string _MaDonDHNCC;
        private string _MaHangHoa;
        private string _SoLuong;

        public string MaDonDHNCC
        {
            get
            {
                return _MaDonDHNCC;
            }
            set
            {
                _MaDonDHNCC = value;
                if (_MaDonDHNCC == "")
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
