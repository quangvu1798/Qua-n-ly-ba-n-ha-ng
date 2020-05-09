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
    class C_CTDonDH
    {
        Sql_CTDonDH SqlCTDonDH = new Sql_CTDonDH();

        public DataTable CreateTbCTDonDH(string _dondh)
        {
            return SqlCTDonDH.CreateTbCTDonDH(_dondh);
        }

        public void AddCTDonDH(EC_CTDonDH _ctdondh)
        {
            SqlCTDonDH.AddCTDonDH(_ctdondh);
        }
    }
}
