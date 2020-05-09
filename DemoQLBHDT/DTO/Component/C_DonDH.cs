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
    class C_DonDH
    {
        Sql_DonDH sqldondh = new Sql_DonDH();

        public DataTable CreateTbDonDH()
        {
            return sqldondh.CreateTbDonDH();
        }

        public DataTable CreateTbDonDH(EC_DonDH _dondh)
        {
            return sqldondh.CreateTbDonDH(_dondh);
        }

        public void AddDonDH(EC_DonDH _dondh)
        {
            if (!sqldondh.CheckDonDH(_dondh.MaDonDH))
            {
                sqldondh.AddDonDH(_dondh);
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
        public void DeleteDonDH(EC_DonDH _dondh)
        {
            sqldondh.DeleteDonDH(_dondh);
        }

        //Hàng Hóa
        public void LoadMaHH(ComboBox _cbxmahh)
        {
            sqldondh.LoadMaHH(_cbxmahh);
        }

        public string LoadTenHH(string _tenhh, string _mahh)
        {
            _tenhh = sqldondh.LoadTenHH(_tenhh, _mahh);
            return _tenhh;
        }

        //ĐVT
        public string LoadTenDonViTinh(string _tendvt, string _madvt)
        {
            _tendvt = sqldondh.LoadTenDonViTinh(_tendvt, _madvt);
            return _tendvt;
        }
        public string LoadMaDonViTinh(string _madvt, string _mahh)
        {
            _madvt = sqldondh.LoadMaDonViTinh(_madvt, _mahh);
            return _madvt;
        }

        //Khách Hàng
        public void LoadMaKH(ComboBox _cbxmakh)
        {
            sqldondh.LoadMaKH(_cbxmakh);
        }
        public void LoadTenKH(ComboBox _cbxtenkh)
        {
            sqldondh.LoadTenKH(_cbxtenkh);
        }

        public string LoadMaKH(string _makh, string _tenkh)
        {
            _makh = sqldondh.LoadMaKH(_makh, _tenkh);
            return _makh;
        }
        public string LoadTenKH(string _tenkh, string _makh)
        {
            _tenkh = sqldondh.LoadTenKH(_tenkh, _makh);
            return _tenkh;
        }
        public string LoadDiaChi(string _dc, string _makh)
        {
            _dc = sqldondh.LoadDiaChi(_dc, _makh);
            return _dc;
        }
    }
}
