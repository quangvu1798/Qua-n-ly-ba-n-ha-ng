using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DemoQLBHDT.DTO.EntitiesClass;
using System.Windows.Forms;

namespace DemoQLBHDT.DAO
{
    class Sql_NuocSX
    {
        ConnectDataBase Connect = new ConnectDataBase();

        public bool CheckNuocSX(string _manuoxsx)
        {
            return Connect.Check("select count(*) from tb_Nuocsx where manuoc = N'" + _manuoxsx + "'");
        }

        public DataTable CreateTbNSX()
        {
            string sqlquery = "SELECT manuoc, tennuoc FROM tb_Nuocsx";
            return Connect.CreateTable(sqlquery);
        }

        public DataTable CreateTbNSX(EC_NuocSX _nuocsx)
        {
            string sqlquery = "SELECT * FROM tb_Nuocsx where manuoc like N'%{0}%' and tennuoc like N'%{1}%'";
            sqlquery = string.Format(sqlquery, _nuocsx.MaNuocSX, _nuocsx.TenNuocSX);
            return Connect.CreateTable(sqlquery);
        }

        public void AddNuocSX(EC_NuocSX _newnuoxsx)
        {
            try
            {
                Connect.SqlConnect.Open();
                string sqlquery = @"INSERT INTO tb_Nuocsx
					  (manuoc, tennuoc)
							 VALUES (N'{0}',N'{1}')";
                sqlquery = string.Format(sqlquery, _newnuoxsx.MaNuocSX, _newnuoxsx.TenNuocSX);
                SqlCommand cmd = new SqlCommand(sqlquery, Connect.SqlConnect);
                cmd.ExecuteNonQuery();
                Connect.SqlConnect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DeleteNuocSX(EC_NuocSX _nuocsx)
        {
            Connect.ExcuteNonQuery("DELETE FROM [tb_Nuocsx] WHERE  manuoc=N'" + _nuocsx.MaNuocSX + "'");
        }

        public void UpdateNuocSX(EC_NuocSX _nuocsx)
        {

            try
            {
                Connect.SqlConnect.Open();
                string sqlquery = @"UPDATE    tb_Nuocsx
				SET tennuoc =N'{0}' where manuoc =N'{1}'";
                string.Format(sqlquery, _nuocsx.TenNuocSX, _nuocsx.MaNuocSX);
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
