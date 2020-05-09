using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoQLBHDT.DTO.Component;

namespace DemoQLBHDT
{
    public partial class FTKGTTBHDB : Form
    {
        public FTKGTTBHDB()
        {
            InitializeComponent();
        }

        C_ThongKe ActTK = new C_ThongKe();

        private void cbxNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGT.Text = ActTK.GTTBCuaHDB(cbxNam.Text);
        }
    }
}
