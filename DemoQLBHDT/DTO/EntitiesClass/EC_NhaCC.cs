using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQLBHDT.DTO.EntitiesClass
{
    class EC_NhaCC
    {
        private string _MaNhaCC;
        private string _TenNhaCC;
        private string _DiaChi;
        private string _DienThoai;

        public string MaNhaCC
        {
            get
            {
                return _MaNhaCC;
            }
            set
            {
                _MaNhaCC = value;
                if (_MaNhaCC == "")
                {
                    throw new Exception("Mã không được bỏ trống");
                }
            }
        }
        public string TenNhaCC
        {
            get
            {
                return _TenNhaCC;
            }
            set
            {
                _TenNhaCC = value;
                if (_TenNhaCC == "")
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
                    throw new Exception("Điện Thoại không được bỏ trống");
                }
            }
        }
    }
}
