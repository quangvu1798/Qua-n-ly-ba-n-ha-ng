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
    class C_CaLam
    {
        Sql_CaLam sqlca = new Sql_CaLam();

        public DataTable CreateTbCL()
        {
            return sqlca.CreateTbCL();
        }

        public DataTable CreateTbCL(EC_CaLam _cl)
        {
            return sqlca.CreateTbCL(_cl);
        }

        public void AddCa(EC_CaLam _ca)
        {
            if (!sqlca.CheckCaLam(_ca.MaCa))
            {
                sqlca.AddCa(_ca);
            }
            else
            {
                MessageBox.Show("Mã này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void UpdateCa(EC_CaLam _ca)
        {
            sqlca.UpdateCa(_ca);
        }
        public void DeleteCa(EC_CaLam _ca)
        {
            sqlca.DeleteCa(_ca);
        }
    }
}
