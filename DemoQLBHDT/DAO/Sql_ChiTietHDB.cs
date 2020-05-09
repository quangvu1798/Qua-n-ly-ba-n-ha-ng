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
    class Sql_ChiTietHDB
    {
        ConnectDataBase Connect = new ConnectDataBase();

        public DataTable CreateTbCTHDB(string _sohdb)
        {
            return Connect.CreateTable("select tb_CTHDB.mahang,tenhang,tendonvi,dongiaban,tb_CTHDB.soluong,thanhtien from tb_CTHDB,tb_Hanghoa, tb_Donvitinh where tb_Hanghoa.madonvi = tb_Donvitinh.madonvi and tb_CTHDB.mahang = tb_Hanghoa.mahang and tb_CTHDB.sohdb = N'" + _sohdb + "'");
        }

        public void AddCTHDB(EC_ChiTietHDB _cthdb)
        {
            try
            {
                Connect.SqlConnect.Open();
                string sqlquery = @"INSERT INTO tb_CTHDB
					  (sohdb, mahang, soluong, thanhtien)
							 VALUES (N'{0}',N'{1}','{2}', '{3}')";
                sqlquery = string.Format(sqlquery, _cthdb.SoHDB, _cthdb.MaHang, _cthdb.SoLuong, _cthdb.ThanhTien);
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
