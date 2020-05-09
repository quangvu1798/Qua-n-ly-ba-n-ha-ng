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
    class C_NhanVien
    {
        Sql_NhanVien sqlnv = new Sql_NhanVien();

        public DataTable CreateTbNV()
        {
            return sqlnv.CreateTbNV();
        }

        public DataTable CreateTbNV(EC_NhanVien _nv)
        {
            return sqlnv.CreateTbNV(_nv);
        }

        public void AddNV(EC_NhanVien _nv)
        {
            if (!sqlnv.CheckNV(_nv.MaNhanVien))
            {
                sqlnv.AddNV(_nv);
            }
            else
            {
                MessageBox.Show("Mã này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void UpdateNV(EC_NhanVien _nv)
        {
            sqlnv.UpdateNV(_nv);
        }
        public void DeleteNV(EC_NhanVien _nv)
        {
            sqlnv.DeleteNV(_nv);
        }
        //load công việc
        public void LoadTenCV(ComboBox _cbxcv)
        {
            sqlnv.LoadTenCV(_cbxcv);
        }
        public string LoadMaCV(string _macv, string _tencv)
        {
            _macv = sqlnv.LoadMaCV(_macv, _tencv);
            return _macv;
        }
        public string LoadTenCV(string _tencv, string _macv)
        {
            _tencv = sqlnv.LoadTenCV(_tencv, _macv);
            return _tencv;
        }
        //load ca
        public void LoadTenCa(ComboBox _cbxca)
        {
            sqlnv.LoadTenCa(_cbxca);
        }
        public string LoadMaCa(string _maca, string _tenca)
        {
            _maca = sqlnv.LoadMaCa(_maca, _tenca);
            return _maca;
        }
        public string LoadTenCa(string _tenca, string _maca)
        {
            _tenca = sqlnv.LoadTenCa(_tenca, _maca);
            return _tenca;
        }
    }
}
