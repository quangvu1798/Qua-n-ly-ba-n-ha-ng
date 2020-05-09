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
    class C_DonDHNCC
    {
        Sql_DonDHNCC sqldondhncc = new Sql_DonDHNCC();

        public DataTable CreateTbDonDHNCC()
        {
            return sqldondhncc.CreateTbDonDHNCC();
        }

        public DataTable CreateTbDonDHNCC(EC_DonDHNCC _dondhncc)
        {
            return sqldondhncc.CreateTbDonDHNCC(_dondhncc);
        }

        public void AddDonDHNCC(EC_DonDHNCC _dondhncc)
        {
            if (!sqldondhncc.CheckDonDHNCC(_dondhncc.MaDonDHNCC))
            {
                sqldondhncc.AddDonDHNCC(_dondhncc);
            }
            else
            {
                MessageBox.Show("Mã này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //public void UpdateDonDHNCC(EC_DonDHNCC _dondhncc)
        //{
        //    sqldondhncc.UpdateDonDHNCC(_dondhncc);
        //}
        public void DeleteDonDHNCC(EC_DonDHNCC _dondhncc)
        {
            sqldondhncc.DeleteDonDHNCC(_dondhncc);
        }

        //Hàng Hóa
        public void LoadMaHH(ComboBox _cbxmahh)
        {
            sqldondhncc.LoadMaHH(_cbxmahh);
        }

        public string LoadTenHH(string _tenhh, string _mahh)
        {
            _tenhh = sqldondhncc.LoadTenHH(_tenhh, _mahh);
            return _tenhh;
        }

        //ĐVT
        public string LoadTenDonViTinh(string _tendvt, string _madvt)
        {
            _tendvt = sqldondhncc.LoadTenDonViTinh(_tendvt, _madvt);
            return _tendvt;
        }
        public string LoadMaDonViTinh(string _madvt, string _mahh)
        {
            _madvt = sqldondhncc.LoadMaDonViTinh(_madvt, _mahh);
            return _madvt;
        }

        

        //NCC
        public void LoadMaNCC(ComboBox _cbxmakh)
        {
            sqldondhncc.LoadMaNCC(_cbxmakh);
        }
        public void LoadTenNCC(ComboBox _cbxtenkh)
        {
            sqldondhncc.LoadTenNCC(_cbxtenkh);
        }

        public string LoadMaNCC(string _makh, string _tenkh)
        {
            _makh = sqldondhncc.LoadMaNCC(_makh, _tenkh);
            return _makh;
        }
        public string LoadTenNCC(string _tenkh, string _makh)
        {
            _tenkh = sqldondhncc.LoadTenNCC(_tenkh, _makh);
            return _tenkh;
        }        

        //Nhân viên
        public void LoadMaNV(ComboBox _cbxmanv)
        {
            sqldondhncc.LoadMaNV(_cbxmanv);
        }
        public void LoadTenNV(ComboBox _cbxtennv)
        {
            sqldondhncc.LoadTenNV(_cbxtennv);
        }

        public string LoadMaNV(string _manv, string _tennv)
        {
            _manv = sqldondhncc.LoadMaNV(_manv, _tennv);
            return _manv;
        }
        public string LoadTenNV(string _tennv, string _manv)
        {
            _tennv = sqldondhncc.LoadTenNV(_tennv, _manv);
            return _tennv;
        }
    }
}
