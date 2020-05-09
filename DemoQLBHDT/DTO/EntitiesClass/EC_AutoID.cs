using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQLBHDT.DTO.EntitiesClass
{
    class EC_AutoID
    {
        private string _Ma;
        private string _GiaTri;
        private string _Ten;
        private string _TienTo;

        public string Ma
        {
            get
            {
                return _Ma;
            }
            set
            {
                _Ma = value;
            }
        }

        public string GiaTri
        {
            get
            {
                return _GiaTri;
            }
            set
            {
                _GiaTri = value;
            }
        }

        public string Ten
        {
            get
            {
                return _Ten;
            }
            set
            {
                _Ten = value;
            }
        }

        public string TienTo
        {
            get
            {
                return _TienTo;
            }
            set
            {
                _TienTo = value;
            }
        }
    }
}
