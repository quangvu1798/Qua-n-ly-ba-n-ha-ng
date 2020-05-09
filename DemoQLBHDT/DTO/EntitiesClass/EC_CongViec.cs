using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQLBHDT.DTO.EntitiesClass
{
    class EC_CongViec
    {
        private string _MaCV;
        private string _TenCV;

        public string MaCV
        {
            get
            {
                return _MaCV;
            }
            set
            {
                _MaCV = value;
                if (_MaCV == "")
                {
                    throw new Exception("Mã không được bỏ trống");
                }
            }
        }

        public string TenCV
        {
            get
            {
                return _TenCV;
            }
            set
            {
                _TenCV = value;
                if (_TenCV == "")
                {
                    throw new Exception("Mã không được bỏ trống");
                }
            }
        }
    }
}
