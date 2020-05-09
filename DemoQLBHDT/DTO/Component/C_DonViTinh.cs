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
    class C_DonViTinh
    {
        Sql_DonViTinh sqldonvi = new Sql_DonViTinh();

        public DataTable CreateTbDVT()
        {
            return sqldonvi.CreateTbDVT();
        }

        public DataTable CreateTbDVT(EC_DonViTinh _dvt)
        {
            return sqldonvi.CreateTbDVT(_dvt);
        }

        public void AddDonViTinh(EC_DonViTinh _donvi)
        {
            if (!sqldonvi.CheckDonViTinh(_donvi.MaDonViTinh))
            {
                sqldonvi.AddDonViTinh(_donvi);
            }
            else
            {
                MessageBox.Show("Mã này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void UpdateDonViTinh(EC_DonViTinh _donvi)
        {
            sqldonvi.UpdateDonViTinh(_donvi);
        }
        public void DeleteDonViTinh(EC_DonViTinh _donvi)
        {
            sqldonvi.DeleteDonViTinh(_donvi);
        }
    }
}
