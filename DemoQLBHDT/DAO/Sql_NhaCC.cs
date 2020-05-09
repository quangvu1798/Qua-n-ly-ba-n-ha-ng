using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DemoQLBHDT.DTO.EntitiesClass;

namespace DemoQLBHDT.DAO
{
    class Sql_NhaCC
    {
        ConnectDataBase Connect = new ConnectDataBase();
        public bool CheckNhaCC(string _manhacc)
        {
            return Connect.Check("select count(*) from [tb_NCC] where mancc=N'" + _manhacc + "'");
        }

        public DataTable CreateTbNCC()
        {
            string sqlquery = "SELECT mancc, tenncc, diachi, lienhe FROM tb_NCC";
            return Connect.CreateTable(sqlquery);
        }

        public DataTable CreateTbNCC(EC_NhaCC _ncc)
        {
            string sqlquery = "SELECT * FROM tb_NCC where mancc like N'%{0}%' and tenncc like N'%{1}%' and diachi like N'%{2}%' and lienhe like N'%{3}%'";
            sqlquery = string.Format(sqlquery, _ncc.MaNhaCC, _ncc.TenNhaCC, _ncc.DiaChi, _ncc.DienThoai);
            return Connect.CreateTable(sqlquery);
        }

        public void AddNhaCC(EC_NhaCC _nhacc)
        {
            string sqlquery = (@"INSERT INTO tb_NCC
                      (mancc, tenncc, diachi,lienhe) 
                VALUES   (N'{0}',N'{1}',N'{2}',N'{3}')");
            sqlquery = string.Format(sqlquery, _nhacc.MaNhaCC, _nhacc.TenNhaCC, _nhacc.DiaChi, _nhacc.DienThoai);
            Connect.ExcuteNonQuery(sqlquery);

        }
        public void DeleteNhaCC(EC_NhaCC _nhacc)
        {
            Connect.ExcuteNonQuery("DELETE FROM [tb_NCC] WHERE mancc=N'" + _nhacc.MaNhaCC + "'");
        }

        public void UpdateNhaCC(EC_NhaCC _nhacc)
        {
            string sqlquery = (@"UPDATE    tb_NCC
                    SET tenncc =N'{0}', diachi =N'{1}', lienhe =N'{2}' where mancc=N'{3}'");
            sqlquery = string.Format(sqlquery, _nhacc.TenNhaCC, _nhacc.DiaChi, _nhacc.DienThoai, _nhacc.MaNhaCC);
            Connect.ExcuteNonQuery(sqlquery);
        }
    }
}
