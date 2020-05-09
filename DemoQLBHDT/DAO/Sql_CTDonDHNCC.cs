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
    class Sql_CTDonDHNCC
    {
        ConnectDataBase Connect = new ConnectDataBase();

        public DataTable CreateTbCTDonDHNCC(string _madondhncc)
        {
            return Connect.CreateTable("select tb_CTDonDHNCC.mahang,tenhang,tendonvi,tb_CTDonDHNCC.soluong from tb_CTDonDHNCC,tb_Hanghoa, tb_Donvitinh where tb_Hanghoa.madonvi = tb_Donvitinh.madonvi and tb_CTDonDHNCC.mahang = tb_Hanghoa.mahang and tb_CTDonDHNCC.madhncc = N'" + _madondhncc + "'");
        }

        public void AddCTDonDHNCC(EC_CTDonDHNCC _ctdondhncc)
        {
            try
            {
                Connect.SqlConnect.Open();
                string sqlquery = @"INSERT INTO tb_CTDonDHNCC
					  (madhncc, mahang, soluong)
							 VALUES (N'{0}',N'{1}','{2}')";
                sqlquery = string.Format(sqlquery, _ctdondhncc.MaDonDHNCC, _ctdondhncc.MaHangHoa, _ctdondhncc.SoLuong);
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
