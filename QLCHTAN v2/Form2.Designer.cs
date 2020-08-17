namespace QLCHTAN_v2
{
    partial class Form2
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataSetBill = new QLCHTAN_v2.DataSetBill();
            this.USP_MenuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.USP_MenuTableAdapter = new QLCHTAN_v2.DataSetBillTableAdapters.USP_MenuTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_MenuBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.USP_MenuBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLCHTAN_v2.Menu1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(38, 35);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(651, 295);
            this.reportViewer1.TabIndex = 0;
            // 
            // DataSetBill
            // 
            this.DataSetBill.DataSetName = "DataSetBill";
            this.DataSetBill.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // USP_MenuBindingSource
            // 
            this.USP_MenuBindingSource.DataMember = "USP_Menu";
            this.USP_MenuBindingSource.DataSource = this.DataSetBill;
            // 
            // USP_MenuTableAdapter
            // 
            this.USP_MenuTableAdapter.ClearBeforeFill = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSetBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_MenuBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource USP_MenuBindingSource;
        private DataSetBill DataSetBill;
        private DataSetBillTableAdapters.USP_MenuTableAdapter USP_MenuTableAdapter;
    }
}