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
    class C_NhaCC
    {
        Sql_NhaCC sqlnhacc = new Sql_NhaCC();
        public void AddNhaCC(EC_NhaCC _nhacc)
        {
            if (!sqlnhacc.CheckNhaCC(_nhacc.MaNhaCC))
            {
                sqlnhacc.AddNhaCC(_nhacc);
            }
            else
            {
                MessageBox.Show("Mã này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public DataTable CreateTbNCC()
        {
            return sqlnhacc.CreateTbNCC();
        }

        public DataTable CreateTbNCC(EC_NhaCC _ncc)
        {
            return sqlnhacc.CreateTbNCC(_ncc);
        }

        public void UpdateNhaCC(EC_NhaCC _nhacc)
        {
            sqlnhacc.UpdateNhaCC(_nhacc);
        }
        public void DeleteNhaCC(EC_NhaCC _nhacc)
        {
            sqlnhacc.DeleteNhaCC(_nhacc);
        }
    }
}
