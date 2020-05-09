using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQLBHDT.DTO.EntitiesClass
{
    class EC_KhachHang
    {
        private string _MaKH;
        private string _TenKH;
        private string _DiaChi;
        private string _DienThoai;

        public string MaKH
        {
            get
            {
                return _MaKH;
            }
            set
            {
                _MaKH = value;
                if (_MaKH == "")
                {
                    throw new Exception("Mã không được bỏ trống");
                }
            }
        }
        public string TenKH
        {
            get
            {
                return _TenKH;
            }
            set
            {
                _TenKH = value;
                if (_TenKH == "")
                {
                    throw new Exception("Tên không được bỏ trống");
                }
            }
        }
        public string DiaChi
        {
            get
            {
                return _DiaChi;
            }
            set
            {
                _DiaChi = value;
                if (_DiaChi == "")
                {
                    throw new Exception("Địa chỉ không được bỏ trống");
                }
            }
        }
        public string DienThoai
        {
            get
            {
                return _DienThoai;
            }
            set
            {
                _DienThoai = value;
                if (_DienThoai == "")
                {
                    throw new Exception("Địa chỉ không được bỏ trống");
                }
            }
        }
    }
}
