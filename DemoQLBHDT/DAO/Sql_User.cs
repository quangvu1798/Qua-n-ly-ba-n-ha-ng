using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using DemoQLBHDT.DTO.EntitiesClass;

namespace DemoQLBHDT.DAO
{
    class Sql_User
    {
        ConnectDataBase Connect = new ConnectDataBase();

        public bool CheckUser(EC_User _user)
        {
            string sqlquery = "select count(*) from tb_User where Username ='" + _user.UserName + "' and Password = '" + _user.Password + "'";
            return Connect.CheckUsername(sqlquery);
        }

        public bool CheckUserName(string _username)
        {
            string sqlquery = "select count(*) from tb_User where Username ='" + _username + "'";
            return Connect.CheckUsername(sqlquery);
        }

        public DataTable CreateTbUser()
        {
            return Connect.CreateTable("select * from tb_User");
        }

        public void AddTK(EC_User _user)
        {
            string sqlquery = @"INSERT INTO tb_User
                      (Username, Password, phanquyen, manv)
                        VALUES   (N'{0}',N'{1}',N'{2}',N'{3}')";
            sqlquery = string.Format(sqlquery, _user.UserName, _user.Password, _user.PhanQuyen, _user.MaNV);
            Connect.ExcuteNonQuery(sqlquery);
        }

        public void UpdateTK(EC_User _user)
        {
            string sqlquery = (@"UPDATE    tb_User
                    SET Password =N'{0}', phanquyen =N'{1}', manv =N'{2}' where Username =N'{3}'");
            sqlquery = string.Format(sqlquery, _user.Password, _user.PhanQuyen, _user.MaNV, _user.UserName);
            Connect.ExcuteNonQuery(sqlquery);
        }

        public void DeleteTK(EC_User _user)
        {
            Connect.ExcuteNonQuery("DELETE FROM [tb_User] WHERE Username=N'" + _user.UserName + "'");
        }

        public string LoadPhanQuyen(string _access, string _username)
        {
            _access = Connect.LoadLable("SELECT [phanquyen] From [tb_User] where Username= N'" + _username + "'");
            return _access;
        }

        public void LoadTenNV(ComboBox _cbxtennv)
        {
            Connect.LoadLenCombobox(_cbxtennv, "SELECT     tennv FROM tb_Nhanvien", 0);
        }

        public string LoadMaNV(string _manv, string _tennv)
        {
            _manv = Connect.LoadLable("SELECT [manv] From [tb_Nhanvien] where tennv= N'" + _tennv + "'");
            return _manv;
        }

        public string LoadMaNVUser(string _manv, string _username)
        {
            _manv = Connect.LoadLable("SELECT [manv] From [tb_User] where Username= N'" + _username + "'");
            return _manv;
        }

        public string LoadTenNV(string _tennv, string _manv)
        {
            _tennv = Connect.LoadLable("SELECT [tennv] From [tb_Nhanvien] where manv= N'" + _manv + "'");
            return _tennv;
        }
    }
}
