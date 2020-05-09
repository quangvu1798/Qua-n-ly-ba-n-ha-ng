using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using DemoQLBHDT.DTO.EntitiesClass;
using DemoQLBHDT.DAO;

namespace DemoQLBHDT.DTO.Component
{
    public class C_User
    {
        EC_User User = new EC_User();
        Sql_User sql = new Sql_User();
        public bool CheckUser(string _username, string _userpass)
        {
            User.UserName = _username;
            User.Password = _userpass;
            return sql.CheckUser(User);
        }

        public DataTable CreateTbUser()
        {
            return sql.CreateTbUser();
        }

        public void AddUser(EC_User _user)
        {
            if (!sql.CheckUserName(_user.UserName))
            {
                sql.AddTK(_user);
            }
            else
            {
                MessageBox.Show("User này đã tồn tại!", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void UpdateUser(EC_User _user)
        {
            sql.UpdateTK(_user);
        }

        public void DeleteUser(EC_User _user)
        {
            sql.DeleteTK(_user);
        }

        public string LoadPhanQuyen(string _access, string _username)
        {
            _access = sql.LoadPhanQuyen(_access, _username);
            return _access;
        }

        public void LoadTenNV(ComboBox _cbxtennv)
        {
            sql.LoadTenNV(_cbxtennv);
        }

        public string LoadMaNV(string _manv, string _tennv)
        {
            return sql.LoadMaNV(_manv, _tennv);
        }

        public string LoadMaNVUser(string _manv, string _username)
        {
            return sql.LoadMaNVUser(_manv, _username);
        }

        public string LoadTenNV(string _tennv, string _manv)
        {
            return sql.LoadTenNV(_tennv, _manv);
        }
    }
}
