using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQLBHDT.DTO.EntitiesClass
{
    class EC_DonDH
    {
        private string _MaDonDH;
        private string _MaKH;
        private string _NgayDat;
        private string _DiaChi;

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

        public string MaKH
        {
            get
            {
                return _MaKH;
            }
            set
            {
                _MaKH = value;
            }
        }

        public string NgayDat
        {
            get
            {
                return _NgayDat;
            }
            set
            {
                _NgayDat = value;
            }
        }

        //public string DiaChi
        //{
        //    get
        //    {
        //        return _DiaChi;
        //    }
        //    set
        //    {
        //        _DiaChi = value;
        //        if (_DiaChi == "")
        //        {
        //            throw new Exception("Mã Đơn Đặt Hàng Nhà Cung Cấp Không Được Trống!");
        //        }
        //    }
        //}
    }
}
