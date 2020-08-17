using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHTAN_v2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSetBill.USP_Menu' table. You can move, or remove it, as needed.
            this.USP_MenuTableAdapter.Fill(this.DataSetBill.USP_Menu);

            this.reportViewer1.RefreshReport();
        }
    }
}
