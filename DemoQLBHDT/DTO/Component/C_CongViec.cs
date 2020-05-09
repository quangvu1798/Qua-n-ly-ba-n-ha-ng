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
    class C_CongViec
    {
        Sql_CongViec sqlcv = new Sql_CongViec();

        public DataTable CreateTbCV()
        {
            return sqlcv.CreateTbCV();
        }

        public DataTable CreateTbCV(EC_CongViec _cv)
        {
            return sqlcv.CreateTbCV(_cv);
        }

        public void AddCV(EC_CongViec _cv)
        {
            if (!sqlcv.CheckCV(_cv.MaCV))
            {
                sqlcv.AddCV(_cv);
            }
            else
            {
                MessageBox.Show("Mã này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void UpdateCV(EC_CongViec _cv)
        {
            sqlcv.UpdateCV(_cv);
        }
        public void DeleteCV(EC_CongViec _cv)
        {
            sqlcv.DeleteCV(_cv);
        }
    }
}
