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
    class Sql_CaLam
    {
        ConnectDataBase Connect = new ConnectDataBase();

        public DataTable CreateTbCL()
        {
            string sqlquery = "SELECT maca, tenca, mota FROM tb_Calam";
            return Connect.CreateTable(sqlquery);
        }

        public DataTable CreateTbCL(EC_CaLam _cl)
        {
            string sqlquery = "SELECT * FROM tb_Calam where maca like N'%{0}%' and tenca like N'%{1}%' and like N'%{2}%'";
            sqlquery = string.Format(sqlquery, _cl.MaCa, _cl.TenCa, _cl.MoTa);
            return Connect.CreateTable(sqlquery);
        }

        public bool CheckCaLam(string _maca)
        {
            return Connect.Check("select count(*) from tb_Calam where maca = N'" + _maca + "'");
        }

        public void AddCa(EC_CaLam _newca)
        {
            try
            {
                Connect.SqlConnect.Open();
                string sqlquery = @"INSERT INTO tb_Calam
					  (maca, tenca, mota)
							 VALUES (N'{0}',N'{1}',N'{2}')";
                sqlquery = string.Format(sqlquery, _newca.MaCa, _newca.TenCa, _newca.MoTa);
                SqlCommand cmd = new SqlCommand(sqlquery, Connect.SqlConnect);
                cmd.ExecuteNonQuery();
                Connect.SqlConnect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DeleteCa(EC_CaLam _ca)
        {
            Connect.ExcuteNonQuery("DELETE FROM [tb_Calam] WHERE  maca=N'" + _ca.MaCa + "'");
        }

        public void UpdateCa(EC_CaLam _ca)
        {

            try
            {
                Connect.SqlConnect.Open();
                string sqlquery = @"UPDATE    tb_Calam
				SET tenca =N'{0}', mota = N'{1}' where maca =N'{2}'";
                string.Format(sqlquery, _ca.TenCa, _ca.MoTa, _ca.MaCa);
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
