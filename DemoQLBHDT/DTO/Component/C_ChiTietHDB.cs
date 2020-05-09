using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using DemoQLBHDT.DAO;
using DemoQLBHDT.DTO.EntitiesClass;

namespace DemoQLBHDT.DTO.Component
{
    class C_ChiTietHDB
    {
        Sql_ChiTietHDB SqlCTHDB = new Sql_ChiTietHDB();

        public DataTable CreateTbCTHDB(string _sohdb)
        {
            return SqlCTHDB.CreateTbCTHDB(_sohdb);
        }

        public void AddCTHDB(EC_ChiTietHDB _cthdb)
        {
            SqlCTHDB.AddCTHDB(_cthdb);
        }
    }
}
