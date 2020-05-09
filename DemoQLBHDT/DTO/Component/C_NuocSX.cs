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
    class C_NuocSX
    {
        Sql_NuocSX sqlnuocsx = new Sql_NuocSX();

        public DataTable CreateTbNSX()
        {
            return sqlnuocsx.CreateTbNSX();
        }

        public DataTable CreateTbNSX(EC_NuocSX _nuocsx)
        {
            return sqlnuocsx.CreateTbNSX(_nuocsx);
        }

        public void AddNuocSX(EC_NuocSX _nuocsx)
        {
            if (!sqlnuocsx.CheckNuocSX(_nuocsx.MaNuocSX))
            {
                sqlnuocsx.AddNuocSX(_nuocsx);
            }
            else
            {
                MessageBox.Show("Mã này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void UpdateNuocSX(EC_NuocSX _nuocsx)
        {
            sqlnuocsx.UpdateNuocSX(_nuocsx);
        }
        public void DeleteNuocSX(EC_NuocSX _nuocsx)
        {
            sqlnuocsx.DeleteNuocSX(_nuocsx);
        }
    }
}
