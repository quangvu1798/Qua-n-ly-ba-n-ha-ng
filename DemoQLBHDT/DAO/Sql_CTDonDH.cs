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
    class Sql_CTDonDH
    {
        ConnectDataBase Connect = new ConnectDataBase();

        public DataTable CreateTbCTDonDH(string _madondh)
        {
            return Connect.CreateTable("select tb_CTDonDH.mahang,tenhang,tendonvi,tb_CTDonDH.soluong from tb_CTDonDH,tb_Hanghoa, tb_Donvitinh where tb_Hanghoa.madonvi = tb_Donvitinh.madonvi and tb_CTDonDH.mahang = tb_Hanghoa.mahang and tb_CTDonDH.madondh = N'" + _madondh + "'");
        }

        public void AddCTDonDH(EC_CTDonDH _ctdondh)
        {
            try
            {
                Connect.SqlConnect.Open();
                string sqlquery = @"INSERT INTO tb_CTDonDH
					  (madondh, mahang, soluong)
							 VALUES (N'{0}',N'{1}','{2}')";
                sqlquery = string.Format(sqlquery, _ctdondh.MaDonDH, _ctdondh.MaHangHoa, _ctdondh.SoLuong);
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
