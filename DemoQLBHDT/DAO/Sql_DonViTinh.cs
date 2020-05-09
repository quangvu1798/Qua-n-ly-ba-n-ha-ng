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
    class Sql_DonViTinh
    {
        ConnectDataBase Connect = new ConnectDataBase();

        public bool CheckDonViTinh(string _madonvi)
        {
            return Connect.Check("select count(*) from tb_Donvitinh where madonvi = N'" + _madonvi + "'");
        }

        public DataTable CreateTbDVT()
        {
            string sqlquery = "SELECT madonvi, tendonvi FROM tb_Donvitinh"; 
            return Connect.CreateTable(sqlquery);
        }

        public DataTable CreateTbDVT(EC_DonViTinh _dvt)
        {
            string sqlquery = "SELECT * FROM tb_Donvitinh where madonvi like N'%{0}%' and tendonvi like N'%{1}%'";
            sqlquery = string.Format(sqlquery, _dvt.MaDonViTinh, _dvt.TenDonViTinh);
            return Connect.CreateTable(sqlquery);
        }

        public void AddDonViTinh(EC_DonViTinh _newdonvi)
        {
            try
            {
                Connect.SqlConnect.Open();
                string sqlquery = @"INSERT INTO tb_Donvitinh
					  (madonvi, tendonvi)
							 VALUES (N'{0}',N'{1}')";
                sqlquery = string.Format(sqlquery, _newdonvi.MaDonViTinh, _newdonvi.TenDonViTinh);
                SqlCommand cmd = new SqlCommand(sqlquery, Connect.SqlConnect);
                cmd.ExecuteNonQuery();
                Connect.SqlConnect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DeleteDonViTinh(EC_DonViTinh _donvi)
        {
            Connect.ExcuteNonQuery("DELETE FROM [tb_Donvitinh] WHERE  madonvi=N'" + _donvi.MaDonViTinh + "'");
        }

        public void UpdateDonViTinh(EC_DonViTinh _donvi)
        {

            try
            {
                Connect.SqlConnect.Open();
                string sqlquery = @"UPDATE    tb_Donvitinh
				SET tendonvi =N'{0}' where madonvi =N'{1}'";
                string.Format(sqlquery, _donvi.TenDonViTinh, _donvi.MaDonViTinh);
                SqlCommand cmd = new SqlCommand(sqlquery, Connect.SqlConnect);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Connect.SqlConnect.Close();
            }
        }
    }
}
