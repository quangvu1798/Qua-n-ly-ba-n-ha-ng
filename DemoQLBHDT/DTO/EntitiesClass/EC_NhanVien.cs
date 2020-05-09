using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQLBHDT.DTO.EntitiesClass
{
    class EC_NhanVien
    {
        private string _MaNhanVien;
        private string _TenNhanVien;
        private string _GioiTinh;
        private string _NgaySinh;
        private string _DienThoai;
        private string _DiaChi;
        private string _MaCa;
        private string _MaCV;
        private string _GhiChu;

        public string MaNhanVien
        {
            get
            {
                return _MaNhanVien;
            }
            set
            {
                _MaNhanVien = value;
                if (_MaNhanVien == "")
                {
                    throw new Exception("Mã không được bỏ trống");
                }
            }
        }
        public string TenNhanVien
        {
            get
            {
                return _TenNhanVien;
            }
            set
            {
                _TenNhanVien = value;
                if (_TenNhanVien == "")
                {
                    throw new Exception("Mã không được bỏ trống");
                }
            }
        }
        public string GioiTinh
        {
            get
            {
                return _GioiTinh;
            }
            set
            {
                _GioiTinh = value;
                if (_GioiTinh == "")
                {
                    throw new Exception("Mã không được bỏ trống");
                }
            }
        }
        public string NgaySinh
        {
            get
            {
                return _NgaySinh;
            }
            set
            {
                _NgaySinh = value;
                if (_NgaySinh == "")
                {
                    throw new Exception("Mã không được bỏ trống");
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
                    throw new Exception("Mã không được bỏ trống");
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
                    throw new Exception("Mã không được bỏ trống");
                }
            }
        }
        public string MaCa
        {
            get
            {
                return _MaCa;
            }
            set
            {
                _MaCa = value;
                if (_MaCa == "")
                {
                    throw new Exception("Mã không được bỏ trống");
                }
            }
        }
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
