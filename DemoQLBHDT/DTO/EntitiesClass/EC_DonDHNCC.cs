using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQLBHDT.DTO.EntitiesClass
{
    class EC_DonDHNCC
    {
        private string _MaDonDHNCC;
        private string _MaNCC;
        private string _NgayDat;
        private string _MaNV;

        public string MaDonDHNCC
        {
            get
            {
                return _MaDonDHNCC;
            }
            set
            {
                _MaDonDHNCC = value;
                if(_MaDonDHNCC == "")
                {
                    throw new Exception("Mã Đơn Đặt Hàng Nhà Cung Cấp Không Được Trống!");
                }
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
    }
}
