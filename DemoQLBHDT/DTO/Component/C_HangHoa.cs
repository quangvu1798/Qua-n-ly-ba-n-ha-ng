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
    class C_HangHoa
    {
        Sql_HangHoa sqlhanghoa = new Sql_HangHoa();

        public DataTable CreateTbHH()
        {
            return sqlhanghoa.CreateTbHH();
        }

        public DataTable CreateTbHH(EC_HangHoa _hh)
        {
            return sqlhanghoa.CreateTbHH(_hh);
        }
        
        public void AddSP(EC_HangHoa _sp)
        {
            if (!sqlhanghoa.CheckHangHoa(_sp.MaHangHoa))
            {
                sqlhanghoa.AddHangHoa(_sp);
            }
            else
            {
                MessageBox.Show("Mã này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void UpdateSP(EC_HangHoa _sp)
        {
            sqlhanghoa.UpdateHangHoa(_sp);
        }
        public void DeleteSP(EC_HangHoa _sp)
        {
            sqlhanghoa.DeleteHangHoa(_sp);
        }
        //load nhóm
        public void LoadTenNhom(ComboBox _cbnh)
        {
            sqlhanghoa.LoadTenNhom(_cbnh);
        }
        public string LoadMaNhom(string _manhom, string _tennhom)
        {
            _manhom = sqlhanghoa.LoadMaNhom(_manhom, _tennhom);
            return _manhom;
        }
        public string LoadTenNhom(string _tennhom, string _manhom)
        {
            _tennhom = sqlhanghoa.LoadTenNhom(_tennhom, _manhom);
            return _tennhom;
        }
        //load loại

        //load dvt
        public void LoadTenDonViTinh(ComboBox _cbdvt)
        {
            sqlhanghoa.LoadTenDonViTinh(_cbdvt);
        }
        public string LoadTenDonViTinh(string _tendvt, string _madvt)
        {
            _tendvt = sqlhanghoa.LoadTenDonViTinh(_tendvt, _madvt);
            return _tendvt;
        }
        public string LoadMaDonViTinh(string _madvt, string _tendvt)
        {
            _madvt = sqlhanghoa.LoadMaDonViTinh(_madvt, _tendvt);
            return _madvt;
        }
        //load sx
        public void LoadTenNuocSX(ComboBox _cbnsx)
        {
            sqlhanghoa.LoadTenNuocSX(_cbnsx);
        }
        public string LoadTenNuocSX(string _tennsx, string _mansx)
        {
            _tennsx = sqlhanghoa.LoadTenNuocSX(_tennsx, _mansx);
            return _tennsx;
        }
        public string LoadMaNuocSX(string _mansx, string _tennsx)
        {
            _mansx = sqlhanghoa.LoadMaNuocSX(_mansx, _tennsx);
            return _mansx;
        }
    }
}
