using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System
    .Data.SqlClient;
using System.Windows.Forms;
using DemoQLBHDT.DTO.EntitiesClass;

namespace DemoQLBHDT.DAO
{
    class Sql_AutoID
    {
        ConnectDataBase Connect = new ConnectDataBase();
        EC_AutoID AutoID = new EC_AutoID();
        public string TaoMa(int _maautoid)
        {
            string ketqua = "";
            int giatri;
            try
            {
                Connect.SqlConnect.Open();
                string sql = String.Format("select * from tb_AutoID where Ma= '{0}'", _maautoid);
                SqlCommand cmd = new SqlCommand(sql, Connect.SqlConnect);
                
                SqlDataReader read = cmd.ExecuteReader();
                
                while (read.Read())
                {
                    string tiento = read.GetValue(2).ToString();
                    giatri = (int)read.GetValue(3);
                    AutoID.Ten = read.GetValue(1).ToString();
                    AutoID.TienTo = read.GetValue(2).ToString();
                    if (giatri == 0)
                    {
                        ketqua = tiento + "00001";
                    }
                    else
                    {
                        giatri = giatri + 1;

                        if (giatri < 10)
                            ketqua = String.Format("{0}0000{1}", tiento, giatri);
                        else if (giatri >= 10 && giatri < 100)
                            ketqua = String.Format("{0}000{1}", tiento, giatri);
                        else if (giatri >= 100 && giatri < 1000)
                            ketqua = String.Format("{0}00{1}", tiento, giatri);
                        else if (giatri >= 1000 && giatri < 10000)
                            ketqua = String.Format("{0}0{1}", tiento, giatri);
                        else
                            ketqua = tiento + giatri;
                    }
                    AutoID.GiaTri = Convert.ToString(Convert.ToInt32(read.GetValue(3)) + 1);
                }
                AutoID.Ma = _maautoid.ToString();
                read.Close();
                Connect.SqlConnect.Close();
                //UpdateAutoID(AutoID);
                
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            return ketqua;
        }

        public void UpdateAutoID(int _maautoid)
        {
            Connect.SqlConnect.Open();

            string sql = String.Format("select * from tb_AutoID where Ma= '{0}'", _maautoid);
            SqlCommand cmd = new SqlCommand(sql, Connect.SqlConnect);
            SqlDataReader read = cmd.ExecuteReader();


            while (read.Read())
            {
                string tiento = read.GetValue(2).ToString();
                AutoID.Ten = read.GetValue(1).ToString();
                AutoID.TienTo = read.GetValue(2).ToString();
                AutoID.GiaTri = Convert.ToString(Convert.ToInt32(read.GetValue(3)) + 1);
            }
            AutoID.Ma = _maautoid.ToString();

            Connect.SqlConnect.Close();
            string sqlquery = string.Format("update tb_AutoID set Ten = N'{0}', TienTo = N'{1}'," +
                " GiaTri = '{2}' where Ma = '{3}'", AutoID.Ten, AutoID.TienTo, AutoID.GiaTri, AutoID.Ma);
            Connect.ExcuteNonQuery(sqlquery);
        }

        
    }
}
