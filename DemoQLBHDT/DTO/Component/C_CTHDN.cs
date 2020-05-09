using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DemoQLBHDT.DAO;
using DemoQLBHDT.DTO.EntitiesClass;


namespace DemoQLBHDT.DTO.Component
{
    class C_CTHDN
    {
        Sql_CTHDN SqlCTHDN = new Sql_CTHDN();

        public DataTable CreateTbCTHDN(string _sohdn)
        {
            return SqlCTHDN.CreateTbCTHDN(_sohdn);
        }

        public void AddCTHDN(EC_CTHDN _cthdn)
        {
            SqlCTHDN.AddCTHDN(_cthdn);
        }
    }
}
