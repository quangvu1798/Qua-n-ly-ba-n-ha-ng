using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQLBHDT.DTO.EntitiesClass
{
    class EC_CaLam
    {
        private string _MaCa;
        private string _TenCa;
        private string _MoTa;

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

        public string TenCa
        {
            get
            {
                return _TenCa;
            }
            set
            {
                _TenCa = value;
                if (_TenCa == "")
                {
                    throw new Exception("Mã không được bỏ trống");
                }
            }
        }

        public string MoTa { get => _MoTa; set => _MoTa = value; }
    }
}
