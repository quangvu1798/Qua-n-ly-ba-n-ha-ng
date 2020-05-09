using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQLBHDT.DTO.EntitiesClass
{
    class EC_DonViTinh
    {
        private string _MaDonViTinh;
        private string _TenDonViTinh;

        public string MaDonViTinh
        {
            get
            {
                return _MaDonViTinh;
            }
            set
            {
                _MaDonViTinh = value;
                if (_MaDonViTinh == "")
                {
                    throw new Exception("Mã không được bỏ trống");
                }
            }
        }

        public string TenDonViTinh
        {
            get
            {
                return _TenDonViTinh;
            }
            set
            {
                _TenDonViTinh = value;
                if (_TenDonViTinh == "")
                {
                    throw new Exception("Mã không được bỏ trống");
                }
            }
        }
    }
}
