using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoQLBHDT.DAO;
using DemoQLBHDT.DTO.EntitiesClass;

namespace DemoQLBHDT.DTO.Component
{
    class C_AutoID
    {
        Sql_AutoID SqlAutoID = new Sql_AutoID();
        public string TaoMa(int _maautoid)
        {
            return SqlAutoID.TaoMa(_maautoid);
        }
        
        public void UpdateAutoID(int _maautoid)
        {
            SqlAutoID.UpdateAutoID(_maautoid);
        }
    }
}
