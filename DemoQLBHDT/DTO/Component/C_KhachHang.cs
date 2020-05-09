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
    class C_KhachHang
    {
        Sql_KhachHang sqlkhachhang = new Sql_KhachHang();

        public DataTable CreateTbKH()
        {
            return sqlkhachhang.CreateTbKH();
        }

        public DataTable CreateTbKH(EC_KhachHang _kh)
        {
            return sqlkhachhang.CreateTbKH(_kh);
        }

        public void AddKhachHang(EC_KhachHang _khachhang)
        {
            if (!sqlkhachhang.CheckKH(_khachhang.MaKH))
            {
                sqlkhachhang.AddKH(_khachhang);
            }
            else
            {
                MessageBox.Show("Mã này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void UpdateKhachHang(EC_KhachHang _khachhang)
        {
            sqlkhachhang.UpdateKH(_khachhang);
        }
        public void DeleteKhachHang(EC_KhachHang _khachhang)
        {
            sqlkhachhang.DeleteKH(_khachhang);
        }
    }
}
