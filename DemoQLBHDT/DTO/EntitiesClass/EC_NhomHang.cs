using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQLBHDT.DTO.EntitiesClass
{
    class EC_NhomHang
    {
        private string _MaNhomHang;
        private string _TenNhomHang;

        public string MaNhomHang
        {
            get
            {
                return _MaNhomHang;
            }
            set
            {
                _MaNhomHang = value;
                if (_MaNhomHang == "")
                {
                    throw new Exception("Mã không được bỏ trống");
                }
            }
        }

        public string TenNhomHang { get => _TenNhomHang; set => _TenNhomHang = value; }
    }
}
