using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQLBHDT.DTO.EntitiesClass
{
    class EC_HDN
    {
        private string _SoHDN;
        private string _MaNV;
        private string _NgayNhap;
        private string _MaNCC;
        private string _TongTien;

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
                    throw new Exception("Mã Không Được Để Trống!");
                }
            }
        }

        public string MaNV
        {
            get
            {
                return _MaNV;
            }
            set
            {
                _MaNV = value;
                
            }
        }

        public string NgayNhap
        {
            get
            {
                return _NgayNhap;
            }
            set
            {
                _NgayNhap = value;
                
            }
        }

        public string MaNCC
        {
            get
            {
                return _MaNCC;
            }
            set
            {
                _MaNCC = value;
                
            }
        }

        public string TongTien
        {
            get
            {
                return _TongTien;
            }
            set
            {
                _TongTien = value;
            }
        }
    }
}
