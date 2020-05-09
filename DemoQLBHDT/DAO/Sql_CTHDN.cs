using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DemoQLBHDT.DTO.EntitiesClass;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DemoQLBHDT.DAO
{
    class Sql_CTHDN
    {
        ConnectDataBase Connect = new ConnectDataBase();

        public DataTable CreateTbCTHDN(string _sohdn)
        {
            return Connect.CreateTable("select tb_CTHDN.mahang,tenhang,tendonvi,dongianhap,tb_CTHDN.soluong,thanhtien from tb_CTHDN,tb_Hanghoa, tb_Donvitinh where tb_Hanghoa.madonvi = tb_Donvitinh.madonvi and tb_CTHDN.mahang = tb_Hanghoa.mahang and tb_CTHDN.sohdn = N'" + _sohdn + "'");
        }

        public void AddCTHDN(EC_CTHDN _cthdn)
        {
            try
            {
                Connect.SqlConnect.Open();
                string sqlquery = @"INSERT INTO tb_CTHDN
					  (sohdn, mahang, soluong, thanhtien)
							 VALUES (N'{0}',N'{1}','{2}', '{3}')";
                sqlquery = string.Format(sqlquery, _cthdn.SoHDN, _cthdn.MaHang, _cthdn.SoLuong, _cthdn.ThanhTien);
                SqlCommand cmd = new SqlCommand(sqlquery, Connect.SqlConnect);
                cmd.ExecuteNonQuery();
                Connect.SqlConnect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
