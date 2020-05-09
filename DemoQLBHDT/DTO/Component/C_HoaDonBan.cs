using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using DemoQLBHDT.DAO;
using DemoQLBHDT.DTO.EntitiesClass;

namespace DemoQLBHDT.DTO.Component
{
    class C_HoaDonBan
    {
        Sql_HoaDonBan sqlhoadonban = new Sql_HoaDonBan();

        public DataTable CreateTbHDB()
        {
            return sqlhoadonban.CreateTbHDB();
        }

        public DataTable CreateTbHDB(EC_HoaDonBan _hdb)
        {
            return sqlhoadonban.CreateTbHDB(_hdb);
        }

        public void AddHDB(EC_HoaDonBan _hoadonban)
        {
            if (!sqlhoadonban.CheckHDB(_hoadonban.SoHDB))
            {
                sqlhoadonban.AddHDB(_hoadonban);
            }
            else
            {
                MessageBox.Show("Mã này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void UpdateHDB(EC_HoaDonBan _hoadonban)
        {
            sqlhoadonban.UpdateHDB(_hoadonban);
        }
        public void DeleteHDB(EC_HoaDonBan _hoadonban)
        {
            sqlhoadonban.DeleteHDB(_hoadonban);
        }

        //Hàng Hóa
        public void LoadMaHH(ComboBox _cbxmahh)
        {
            sqlhoadonban.LoadMaHH(_cbxmahh);
        }
        
        public string LoadTenHH(string _tenhh, string _mahh)
        {
            _tenhh = sqlhoadonban.LoadTenHH(_tenhh, _mahh);
            return _tenhh;
        }

        //ĐVT
        public string LoadTenDonViTinh(string _tendvt, string _madvt)
        {
            _tendvt = sqlhoadonban.LoadTenDonViTinh(_tendvt, _madvt);
            return _tendvt;
        }
        public string LoadMaDonViTinh(string _madvt, string _mahh)
        {
            _madvt = sqlhoadonban.LoadMaDonViTinh(_madvt, _mahh);
            return _madvt;
        }

        //DGB
        public string LoadDGB(string _dgb, string _mahh)
        {
            _dgb = sqlhoadonban.LoadDGB(_dgb, _mahh);
            return _dgb;
        }

        //Khách Hàng
        public void LoadMaKH(ComboBox _cbxmakh)
        {
            sqlhoadonban.LoadMaKH(_cbxmakh);
        }
        public void LoadTenKH(ComboBox _cbxtenkh)
        {
            sqlhoadonban.LoadTenKH(_cbxtenkh);
        }

        public string LoadMaKH(string _makh, string _tenkh)
        {
            _makh = sqlhoadonban.LoadMaKH(_makh, _tenkh);
            return _makh;
        }
        public string LoadTenKH(string _tenkh, string _makh)
        {
            _tenkh = sqlhoadonban.LoadTenKH(_tenkh, _makh);
            return _tenkh;
        }
        public string LoadDiaChi(string _dc, string _makh)
        {
            _dc = sqlhoadonban.LoadDiaChi(_dc, _makh);
            return _dc;
        }

        //Nhân viên
        public void LoadMaNV(ComboBox _cbxmanv)
        {
            sqlhoadonban.LoadMaNV(_cbxmanv);
        }
        public void LoadTenNV(ComboBox _cbxtennv)
        {
            sqlhoadonban.LoadTenNV(_cbxtennv);
        }

        public string LoadMaNV(string _manv, string _tennv)
        {
            _manv = sqlhoadonban.LoadMaNV(_manv, _tennv);
            return _manv;
        }
        public string LoadTenNV(string _tennv, string _manv)
        {
            _tennv = sqlhoadonban.LoadTenNV(_tennv, _manv);
            return _tennv;
        }
    }
}
