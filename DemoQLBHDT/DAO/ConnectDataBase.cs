using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DemoQLBHDT.DAO
{
    class ConnectDataBase
    {
        public SqlConnection SqlConnect = new SqlConnection("Data Source= KID; Initial Catalog = QL_BanHangDienTu_Demo; Integrated Security=SSPI;");
        SqlCommand SqlCmd;
        SqlDataReader SqlDr;

        public ConnectDataBase()
        {
           

        }

        public bool Check(string strsql)
        {
            SqlConnect.Open();
            SqlCmd = new SqlCommand(strsql, SqlConnect);
            int tontai = Convert.ToInt32(SqlCmd.ExecuteScalar());
            SqlConnect.Close();
            if (tontai > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool CheckUsername(string strsql)
        {
            SqlConnect.Open();
            SqlCmd = new SqlCommand(strsql, SqlConnect);
            int tontai = Convert.ToInt32(SqlCmd.ExecuteScalar());
            SqlConnect.Close();
            if (tontai > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public void ExcuteNonQuery(string sql)
        {
            
            SqlCmd = new SqlCommand(sql, SqlConnect);
            SqlConnect.Open();
            SqlCmd.ExecuteNonQuery();
            SqlConnect.Close();
            //SqlConnect.Dispose();
        }

        public void LoadLenCombobox(ComboBox cb, string SQL, int chiso)
        {
            cb.Items.Clear();           
            SqlConnect.Open();
            SqlCmd = new SqlCommand(SQL, SqlConnect);
            SqlDr = SqlCmd.ExecuteReader();
            while (SqlDr.Read())
            {
                cb.Items.Add(SqlDr[chiso].ToString());
            }
            SqlConnect.Close();
        }

        public string LoadLable(string sql)
        {
            string ketqua = "";
            
            SqlCmd = new SqlCommand(sql, SqlConnect);
            SqlConnect.Open();
            SqlDr = SqlCmd.ExecuteReader();
            while (SqlDr.Read())
            {
                ketqua = SqlDr[0].ToString();
            }
            SqlConnect.Close();
            return ketqua;
        }

        public DataTable CreateTable(string _sql)
        {
            SqlConnect.Open();
            SqlDataAdapter ad = new SqlDataAdapter(_sql, SqlConnect);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            SqlConnect.Close();
            return dt;
        }        
    }
}
