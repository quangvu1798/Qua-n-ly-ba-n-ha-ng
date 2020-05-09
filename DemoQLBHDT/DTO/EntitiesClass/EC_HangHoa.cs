using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQLBHDT.DTO.EntitiesClass
{
    class EC_HangHoa
    {
        private string _MaHangHoa;
        private string _TenHangHoa;
        private string _MaNhom;
        private string _MaDonVi;
        private string _MaNuoc;
        //private string _SoLuong;
        private string _DonGiaNhap;
        private string _DonGiaBan;
        private string _GhiChu;

        public string MaHangHoa
        {
            get
            {
                return _MaHangHoa;
            }
            set
            {
                _MaHangHoa = value;
                if (_MaHangHoa == "")
                {
                    throw new Exception("Mã không được bỏ trống");
                }
            }
        }
        public string TenHangHoa
        {
            get
            {
                return _TenHangHoa;
            }
            set
            {
                _TenHangHoa = value;
            }
        }
        public string MaNhom
        {
            get
            {
                return _MaNhom;
            }
            set
            {
                _MaNhom = value;
          
            }
        }
        public string MaDonVi
        {
            get
            {
                return _MaDonVi;
            }
            set
            {
                _MaDonVi = value;
                
            }
        }
        
        public string MaNuoc
        {
            get
            {
                return _MaNuoc;
            }
            set
            {
                _MaNuoc = value;
                
            }
        }
        //public string SoLuong
        //{
        //    get
        //    {
        //        return _SoLuong;
        //    }
        //    set
        //    {
        //        _SoLuong = value;
        //    }
        //}
        public string DonGiaNhap
        {
            get
            {
                return _DonGiaNhap;
            }
            set
            {
                _DonGiaNhap = value;
            }
        }
        public string DonGiaBan
        {
            get
            {
                return _DonGiaBan;
            }
            set
            {
                _DonGiaBan = value;
            }
        }
        public string GhiChu
        {
            get
            {
                return _GhiChu;
            }
            set
            {
                _GhiChu = value;
            }
        }
    }
}
