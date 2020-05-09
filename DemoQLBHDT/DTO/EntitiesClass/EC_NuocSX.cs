using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQLBHDT.DTO.EntitiesClass
{
    class EC_NuocSX
    {
        private string _MaNuocSX;
        private string _TenNuocSX;

        public string MaNuocSX
        {
            get
            {
                return _MaNuocSX;
            }
            set
            {
                _MaNuocSX = value;
                if (_MaNuocSX == "")
                {
                    throw new Exception("Mã không được bỏ trống");
                }
            }
        }

        public string TenNuocSX
        {
            get
            {
                return _TenNuocSX;
            }
            set
            {
                _TenNuocSX = value;
                if (_TenNuocSX == "")
                {
                    throw new Exception("Mã không được bỏ trống");
                }
            }
        }
    }
}
