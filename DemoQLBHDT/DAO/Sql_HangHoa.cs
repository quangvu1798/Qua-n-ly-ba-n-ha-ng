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
    class Sql_HangHoa
    {
        ConnectDataBase Connect = new ConnectDataBase();
        public bool CheckHangHoa(string _mahanghoa)
        {
            return Connect.Check("select count(*) from tb_Hanghoa where mahang = N'" + _mahanghoa + "'");
        }

        public DataTable CreateTbHH()
        {
            string sqlquery = "SELECT mahang, tenhang, manhom, madonvi, manuoc, dongianhap, dongiaban, ghichu FROM tb_Hanghoa";
            return Connect.CreateTable(sqlquery);
        }

        public DataTable CreateTbHH(EC_HangHoa _hh)
        {
            string sqlquery = "SELECT * FROM tb_Hanghoa where mahang like N'%{0}%' and tenhang like N'%{1}%' and manhom like N'%{2}%' and madonvi like N'%{3}%' and" +
                " manuoc like N'%{4}%' and dongianhap like N'%{5}%' and dongiaban like N'%{6}%' and ghichu like N'%{7}%'";
            sqlquery = string.Format(sqlquery, _hh.MaHangHoa, _hh.TenHangHoa, _hh.MaNhom, _hh.MaDonVi, _hh.MaNuoc, _hh.DonGiaNhap, _hh.DonGiaBan, _hh.GhiChu);
            return Connect.CreateTable(sqlquery);
        }

        public void AddHangHoa(EC_HangHoa _newhanghoa)
        {
            try
            {
                Connect.SqlConnect.Open(); 
                string sqlquery = @"INSERT INTO tb_Hanghoa
					  (mahang, tenhang, manhom,  madonvi, manuoc, dongianhap, dongiaban, ghichu)
							 VALUES (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}','{5}','{6}','{7}')";
                sqlquery = string.Format(sqlquery, _newhanghoa.MaHangHoa, _newhanghoa.TenHangHoa, _newhanghoa.MaNhom, _newhanghoa.MaDonVi,
                     _newhanghoa.MaNuoc, _newhanghoa.DonGiaNhap, _newhanghoa.DonGiaBan, _newhanghoa.GhiChu);
                SqlCommand cmd = new SqlCommand(sqlquery, Connect.SqlConnect);
                //cmd.Parameters.Add(new SqlParameter("@hinhanh", (object)_newhanghoa.HinhAnh));
                cmd.ExecuteNonQuery();
                //Connect.ExcuteNonQuery(sqlquery);
                Connect.SqlConnect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }

        public void DeleteHangHoa(EC_HangHoa _hanghoa)
        {
            Connect.ExcuteNonQuery("DELETE FROM [tb_Hanghoa] WHERE  mahang=N'" + _hanghoa.MaHangHoa + "'");
        }

        public void UpdateHangHoa(EC_HangHoa _newhanghoa)
        {
            
            try
            {
                //Connect.SqlConnect.Open();
                //string sqlquery = "UPDATE    tb_Hanghoa" +
                //    "	SET tenhang =N'{0}', manhom =N'{1}', madonvi =N'{2}', manuoc =N'{3}', dongianhap ='{4}', dongiaban ='{5}', ghichu =N'6}' where mahang=N'{7}'";
                //sqlquery = string.Format(sqlquery, _newhanghoa.TenHangHoa, _newhanghoa.MaNhom, _newhanghoa.MaDonVi,
                //    _newhanghoa.MaNuoc, _newhanghoa.DonGiaNhap, _newhanghoa.DonGiaBan, _newhanghoa.GhiChu, _newhanghoa.MaHangHoa);
                Connect.ExcuteNonQuery(string.Format("UPDATE    tb_Hanghoa" +
                    "	SET tenhang =N'{0}', manhom =N'{1}', madonvi =N'{2}', manuoc =N'{3}', dongianhap ='{4}', dongiaban ='{5}', ghichu ='{6}' where mahang=N'{7}'", _newhanghoa.TenHangHoa, _newhanghoa.MaNhom, _newhanghoa.MaDonVi,
                    _newhanghoa.MaNuoc, _newhanghoa.DonGiaNhap, _newhanghoa.DonGiaBan, _newhanghoa.GhiChu, _newhanghoa.MaHangHoa));
                //cmd.Parameters.Add(new SqlParameter("@hinhanh", (object)_hanghoa.HinhAnh));
                
                //Connect.SqlConnect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }
        // nhóm
        public void LoadTenNhom(ComboBox _cbxtennhom)
        {
            Connect.LoadLenCombobox(_cbxtennhom, "SELECT     tennhom FROM tb_Nhomhang", 0);
        }

        public string LoadTenNhom(string _tennhom, string _manhom)
        {
            _tennhom = Connect.LoadLable("SELECT [tennhom] From [tb_Nhomhang] where manhom= N'" + _manhom + "'");
            return _tennhom;
        }

        public string LoadMaNhom(string _manhom, string _tennhom)
        {
            _manhom = Connect.LoadLable("SELECT [manhom] From [tb_Nhomhang] where tennhom= N'" + _tennhom + "'");
            return _manhom;
        }
        //loại
        public void LoadTenloai(ComboBox _tenloai)
        {
            Connect.LoadLenCombobox(_tenloai, "SELECT     tenloai FROM tb_Loaihang", 0);
        }

        public string LoadTenLoai(string _tenloai, string _maloai)
        {
            _tenloai = Connect.LoadLable("SELECT [tenloai] From [tb_Loaihang] where maloai= N'" + _maloai + "'");
            return _tenloai;
        }

        public string LoadMaLoai(string _maloai, string _tenloai)
        {
            _maloai = Connect.LoadLable("SELECT [maloai] From [tb_Loaihang] where tenloai= N'" + _tenloai + "'");
            return _maloai;
        }
        // Đơn vị tính
        public void LoadTenDonViTinh(ComboBox _tendv)
        {
            Connect.LoadLenCombobox(_tendv, "SELECT     tendonvi FROM tb_Donvitinh", 0);
        }

        public string LoadTenDonViTinh(string _tendv, string _madv)
        {
            _tendv = Connect.LoadLable("SELECT [tendonvi] From [tb_Donvitinh] where madonvi= N'" + _madv + "'");
            return _tendv;
        }

        public string LoadMaDonViTinh(string _madv, string _tendv)
        {
            _madv = Connect.LoadLable("SELECT [madonvi] From [tb_Donvitinh] where tendonvi= N'" + _tendv + "'");
            return _madv;
        }
        //Nhà Sản xuất
        public void LoadTenNuocSX(ComboBox _tennsx)
        {
            Connect.LoadLenCombobox(_tennsx, "SELECT     tennuoc FROM tb_Nuocsx", 0);
        }

        public string LoadTenNuocSX(string _tennsx, string _mansx)
        {
            _tennsx = Connect.LoadLable("SELECT [tennuoc] From [tb_Nuocsx] where manuoc= N'" + _mansx + "'");
            return _tennsx;
        }

        public string LoadMaNuocSX(string _mansx, string _tennsx)
        {
            _mansx = Connect.LoadLable("SELECT [manuoc] From [tb_Nuocsx] where tennuoc= N'" + _tennsx + "'");
            return _mansx;
        }
    }
}
