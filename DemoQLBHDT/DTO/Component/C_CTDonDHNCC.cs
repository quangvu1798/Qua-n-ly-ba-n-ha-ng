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
    class C_CTDonDHNCC
    {
        Sql_CTDonDHNCC SqlCTDonDHNCC = new Sql_CTDonDHNCC();

        public DataTable CreateTbCTDonDHNCC(string _dondhncc)
        {
            return SqlCTDonDHNCC.CreateTbCTDonDHNCC(_dondhncc);
        }

        public void AddCTDonDHNCC(EC_CTDonDHNCC _ctdondhncc)
        {
            SqlCTDonDHNCC.AddCTDonDHNCC(_ctdondhncc);
        }
    }
}
