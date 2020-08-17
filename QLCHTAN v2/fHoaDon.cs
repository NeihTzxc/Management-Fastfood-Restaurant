using QLCHTAN_v2.DTO;
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
    public partial class Bill : Form
    {
        public Bill(DataRow dataRow)
        {
            InitializeComponent();
        }

        public int ID { get; internal set; }

        private void Bill_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSetBill.USP_Menu' table. You can move, or remove it, as needed.
            this.USP_MenuTableAdapter.Fill(this.DataSetBill.USP_Menu);
            // TODO: This line of code loads data into the 'DataSetBill.USP_Bill' table. You can move, or remove it, as needed.
            //    string i = "1";
            //    this.USP_BillTableAdapter.Fill(this.DataSetBill.USP_Bill,i);

                this.reportViewer1.RefreshReport();
            //
        }
        }
    }
