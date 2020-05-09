using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQLBHDT.DTO.EntitiesClass
{
    public class EC_User
    {
        private string _UserName;
        private string _Password;
        private string _PhanQuyen;
        private string _MaNV;

        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
                if (_UserName == "")
                {
                    throw new Exception("Tên Đăng Nhập Không Được Để Trống!");
                }
            }
        }
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
                if (_Password == "")
                {
                    throw new Exception("Mật Khẩu Không Được Để Trống!");
                }
            }
        }

        public string PhanQuyen
        {
            get
            {
                return _PhanQuyen;
            }
            set
            {
                _PhanQuyen = value;
                if (_PhanQuyen == "")
                {
                    throw new Exception("Quyền Truy Cập Không Được Để Trống!");
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
    }
}
