using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQLBHDT.DTO.EntitiesClass
{
    class EC_HoaDonBan
    {
        private string _SoHDB;
        private string _MaNV;
        private string _NgayLap;
        private string _MaKH;
        private string _TongTien;

        public string SoHDB
        {
            get
            {
                return _SoHDB;
            }
            set
            {
                _SoHDB = value;
                if(_SoHDB == "")
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
                if (_MaNV == "")
                {
                    throw new Exception("Mã Không Được Để Trống!");
                }
            }
        }

        public string NgayLap
        {
            get
            {
                return _NgayLap;
            }
            set
            {
                _NgayLap = value;
                if (_NgayLap == "")
                {
                    throw new Exception("Mã Không Được Để Trống!");
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
                if (_MaKH == "")
                {
                    throw new Exception("Mã Không Được Để Trống!");
                }
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
