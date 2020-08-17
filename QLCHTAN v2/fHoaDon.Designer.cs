namespace QLCHTAN_v2
{
    partial class Bill
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.USP_MenuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetBill = new QLCHTAN_v2.DataSetBill();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.USP_BillBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.USP_BillTableAdapter = new QLCHTAN_v2.DataSetBillTableAdapters.USP_BillTableAdapter();
            this.USP_MenuTableAdapter = new QLCHTAN_v2.DataSetBillTableAdapters.USP_MenuTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.USP_MenuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_BillBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // USP_MenuBindingSource
            // 
            this.USP_MenuBindingSource.DataMember = "USP_Menu";
            this.USP_MenuBindingSource.DataSource = this.DataSetBill;
            // 
            // DataSetBill
            // 
            this.DataSetBill.DataSetName = "DataSetBill";
            this.DataSetBill.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.USP_MenuBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLCHTAN_v2.Menu1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(748, 320);
            this.reportViewer1.TabIndex = 0;
            // 
            // USP_BillBindingSource
            // 
            this.USP_BillBindingSource.DataMember = "USP_Bill";
            this.USP_BillBindingSource.DataSource = this.DataSetBill;
            // 
            // USP_BillTableAdapter
            // 
            this.USP_BillTableAdapter.ClearBeforeFill = true;
            // 
            // USP_MenuTableAdapter
            // 
            this.USP_MenuTableAdapter.ClearBeforeFill = true;
            // 
            // Bill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Bill";
            this.Text = "HoaDon";
            this.Load += new System.EventHandler(this.Bill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.USP_MenuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_BillBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource USP_BillBindingSource;
        private DataSetBill DataSetBill;
        private DataSetBillTableAdapters.USP_BillTableAdapter USP_BillTableAdapter;
        private System.Windows.Forms.BindingSource USP_MenuBindingSource;
        private DataSetBillTableAdapters.USP_MenuTableAdapter USP_MenuTableAdapter;
    }
}