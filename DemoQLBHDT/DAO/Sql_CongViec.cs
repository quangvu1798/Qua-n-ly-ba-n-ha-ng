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
    class Sql_CongViec
    {
        ConnectDataBase Connect = new ConnectDataBase();

        public bool CheckCV(string _macv)
        {
            return Connect.Check("select count(*) from tb_Congviec where macv = N'" + _macv + "'");
        }

        public DataTable CreateTbCV()
        {
            string sqlquery = "SELECT macv, tencv FROM tb_CongViec";
            return Connect.CreateTable(sqlquery);
        }

        public DataTable CreateTbCV(EC_CongViec _cv)
        {
            string sqlquery = "SELECT * FROM tb_Congviec where macv like N'%{0}%' and tencv like N'%{1}%'";
            sqlquery = string.Format(sqlquery, _cv.MaCV, _cv.TenCV);
            return Connect.CreateTable(sqlquery);
        }

        public void AddCV(EC_CongViec _newcv)
        {
            try
            {
                Connect.SqlConnect.Open();
                string sqlquery = @"INSERT INTO tb_Congviec
					  (macv, tencv)
							 VALUES (N'{0}',N'{1}')";
                sqlquery = string.Format(sqlquery, _newcv.MaCV, _newcv.TenCV);
                SqlCommand cmd = new SqlCommand(sqlquery, Connect.SqlConnect);
                cmd.ExecuteNonQuery();
                Connect.SqlConnect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DeleteCV(EC_CongViec _cv)
        {
            Connect.ExcuteNonQuery("DELETE FROM [tb_Congviec] WHERE  macv=N'" + _cv.MaCV + "'");
        }

        public void UpdateCV(EC_CongViec _cv)
        {
                        
            Connect.ExcuteNonQuery(string.Format("UPDATE    tb_Congviec	SET tencv =N'{0}' where macv =N'{1}'", _cv.TenCV, _cv.MaCV));
        }
    }
}
