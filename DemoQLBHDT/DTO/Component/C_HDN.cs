
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
    class C_HDN
    {
        Sql_HDN sqlhdn = new Sql_HDN();

        public DataTable CreateTbHDN()
        {
            return sqlhdn.CreateTbHDN();
        }

        public DataTable CreateTbHDN(EC_HDN _hdn)
        {
            return sqlhdn.CreateTbHDN(_hdn);
        }

        public void AddHDN(EC_HDN _hdn)
        {
            if (!sqlhdn.CheckHDN(_hdn.SoHDN))
            {
                sqlhdn.AddHDN(_hdn);
            }
            else
            {
                MessageBox.Show("Mã này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void UpdateHDN(EC_HDN _hdn)
        {
            sqlhdn.UpdateHDN(_hdn);
        }
        public void DeleteHDN(EC_HDN _hdn)
        {
            sqlhdn.DeleteHDN(_hdn);
        }

        //Hàng Hóa
        public void LoadMaHH(ComboBox _cbxmahh)
        {
            sqlhdn.LoadMaHH(_cbxmahh);
        }

        public string LoadTenHH(string _tenhh, string _mahh)
        {
            _tenhh = sqlhdn.LoadTenHH(_tenhh, _mahh);
            return _tenhh;
        }

        //ĐVT
        public string LoadTenDonViTinh(string _tendvt, string _madvt)
        {
            _tendvt = sqlhdn.LoadTenDonViTinh(_tendvt, _madvt);
            return _tendvt;
        }
        public string LoadMaDonViTinh(string _madvt, string _mahh)
        {
            _madvt = sqlhdn.LoadMaDonViTinh(_madvt, _mahh);
            return _madvt;
        }

        //DGB
        public string LoadDGN(string _dgn, string _mahh)
        {
            _dgn = sqlhdn.LoadDGN(_dgn, _mahh);
            return _dgn;
        }

        //NCC
        public void LoadMaNCC(ComboBox _cbxmakh)
        {
            sqlhdn.LoadMaNCC(_cbxmakh);
        }
        public void LoadTenNCC(ComboBox _cbxtenkh)
        {
            sqlhdn.LoadTenNCC(_cbxtenkh);
        }

        public string LoadMaNCC(string _makh, string _tenkh)
        {
            _makh = sqlhdn.LoadMaNCC(_makh, _tenkh);
            return _makh;
        }
        public string LoadTenNCC(string _tenkh, string _makh)
        {
            _tenkh = sqlhdn.LoadTenNCC(_tenkh, _makh);
            return _tenkh;
        }

        //Nhân viên
        public void LoadMaNV(ComboBox _cbxmanv)
        {
            sqlhdn.LoadMaNV(_cbxmanv);
        }
        public void LoadTenNV(ComboBox _cbxtennv)
        {
            sqlhdn.LoadTenNV(_cbxtennv);
        }

        public string LoadMaNV(string _manv, string _tennv)
        {
            _manv = sqlhdn.LoadMaNV(_manv, _tennv);
            return _manv;
        }
        public string LoadTenNV(string _tennv, string _manv)
        {
            _tennv = sqlhdn.LoadTenNV(_tennv, _manv);
            return _tennv;
        }
    }
}
