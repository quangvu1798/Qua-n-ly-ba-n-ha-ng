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
    class Sql_NhomHang
    {
        ConnectDataBase Connect = new ConnectDataBase();

        public DataTable CreateTbNH()
        {
            string sqlquery = "SELECT manhom, tennhom FROM tb_Nhomhang";
            return Connect.CreateTable(sqlquery);
        }

        public DataTable CreateTbNH(EC_NhomHang _nh)
        {
            string sqlquery = "SELECT * FROM tb_Nhomhang where manhom like N'%{0}%' and tennhom like N'%{1}%'";
            sqlquery = string.Format(sqlquery, _nh.MaNhomHang, _nh.TenNhomHang);
            return Connect.CreateTable(sqlquery);
        }

        public bool CheckNhomHang(string _manhomhang)
        {
            return Connect.Check("select count(*) from tb_Nhomhang where manhom = N'" + _manhomhang + "'");
        }

        public void AddNhomHang(EC_NhomHang _newnhomhang)
        {
            try
            {
                Connect.SqlConnect.Open();
                string sqlquery = @"INSERT INTO tb_Nhomhang
					  (manhom, tennhom)
							 VALUES (N'{0}',N'{1}')";
                sqlquery = string.Format(sqlquery, _newnhomhang.MaNhomHang, _newnhomhang.TenNhomHang);
                SqlCommand cmd = new SqlCommand(sqlquery, Connect.SqlConnect);
                cmd.ExecuteNonQuery();
                Connect.SqlConnect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DeleteNhomHang(EC_NhomHang _nhomhang)
        {
            Connect.ExcuteNonQuery("DELETE FROM [tb_Nhomhang] WHERE  manhom=N'" + _nhomhang.MaNhomHang + "'");
        }

        public void UpdateNhomHang(EC_NhomHang _nhomhang)
        {

            try
            {
                Connect.SqlConnect.Open();
                string sqlquery = @"UPDATE    tb_Nhomhang
				SET tennhom =N'{0}' where manhom =N'{1}'";
                string.Format(sqlquery, _nhomhang.TenNhomHang, _nhomhang.MaNhomHang);
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
