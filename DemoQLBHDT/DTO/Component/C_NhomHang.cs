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
    class C_NhomHang
    {
        Sql_NhomHang sqlnhomhang = new Sql_NhomHang();
        

        public DataTable CreateTbNH()
        {
            return sqlnhomhang.CreateTbNH();
        }

        public DataTable CreateTbNH(EC_NhomHang _nh)
        {
            return sqlnhomhang.CreateTbNH(_nh);
        }

        public void AddNhomHang(EC_NhomHang _nhomhang)
        {
            if (!sqlnhomhang.CheckNhomHang(_nhomhang.MaNhomHang))
            {
                sqlnhomhang.AddNhomHang(_nhomhang);
            }
            else
            {
                MessageBox.Show("Mã này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void UpdateNhomHang(EC_NhomHang _nhomhang)
        {
            sqlnhomhang.UpdateNhomHang(_nhomhang);
        }
        public void DeleteNhomHang(EC_NhomHang _nhomhang)
        {
            sqlnhomhang.DeleteNhomHang(_nhomhang);
        }
    }
}
