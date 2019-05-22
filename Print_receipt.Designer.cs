namespace Brada3
{
    partial class Print_receipt
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
            this.Tbl_Daily_operationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BradaDataSet = new Brada3.BradaDataSet();
            this.item_orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TBL_NumbersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TBL_NumbersTableAdapter = new Brada3.BradaDataSetTableAdapters.TBL_NumbersTableAdapter();
            this.Tbl_Casheir_nameBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Tbl_Casheir_nameTableAdapter = new Brada3.BradaDataSetTableAdapters.Tbl_Casheir_nameTableAdapter();
            this.item_orderTableAdapter = new Brada3.BradaDataSetTableAdapters.item_orderTableAdapter();
            this.Tbl_Daily_operationTableAdapter = new Brada3.BradaDataSetTableAdapters.Tbl_Daily_operationTableAdapter();
            this.Tbl_Casheir_SalesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Tbl_Casheir_SalesTableAdapter = new Brada3.BradaDataSetTableAdapters.Tbl_Casheir_SalesTableAdapter();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.Tbl_Daily_operationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BradaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item_orderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBL_NumbersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tbl_Casheir_nameBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tbl_Casheir_SalesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Tbl_Daily_operationBindingSource
            // 
            this.Tbl_Daily_operationBindingSource.DataMember = "Tbl_Daily_operation";
            this.Tbl_Daily_operationBindingSource.DataSource = this.BradaDataSet;
            // 
            // BradaDataSet
            // 
            this.BradaDataSet.DataSetName = "BradaDataSet";
            this.BradaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // item_orderBindingSource
            // 
            this.item_orderBindingSource.DataMember = "item_order";
            this.item_orderBindingSource.DataSource = this.BradaDataSet;
            // 
            // TBL_NumbersBindingSource
            // 
            this.TBL_NumbersBindingSource.DataMember = "TBL_Numbers";
            this.TBL_NumbersBindingSource.DataSource = this.BradaDataSet;
            // 
            // TBL_NumbersTableAdapter
            // 
            this.TBL_NumbersTableAdapter.ClearBeforeFill = true;
            // 
            // Tbl_Casheir_nameBindingSource
            // 
            this.Tbl_Casheir_nameBindingSource.DataMember = "Tbl_Casheir_name";
            this.Tbl_Casheir_nameBindingSource.DataSource = this.BradaDataSet;
            // 
            // Tbl_Casheir_nameTableAdapter
            // 
            this.Tbl_Casheir_nameTableAdapter.ClearBeforeFill = true;
            // 
            // item_orderTableAdapter
            // 
            this.item_orderTableAdapter.ClearBeforeFill = true;
            // 
            // Tbl_Daily_operationTableAdapter
            // 
            this.Tbl_Daily_operationTableAdapter.ClearBeforeFill = true;
            // 
            // Tbl_Casheir_SalesBindingSource
            // 
            this.Tbl_Casheir_SalesBindingSource.DataMember = "Tbl_Casheir_Sales";
            this.Tbl_Casheir_SalesBindingSource.DataSource = this.BradaDataSet;
            // 
            // Tbl_Casheir_SalesTableAdapter
            // 
            this.Tbl_Casheir_SalesTableAdapter.ClearBeforeFill = true;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(558, 320);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Print_receipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 320);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "Print_receipt";
            this.Text = "Print_receipt";
            this.Load += new System.EventHandler(this.Print_receipt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Tbl_Daily_operationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BradaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item_orderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBL_NumbersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tbl_Casheir_nameBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tbl_Casheir_SalesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource TBL_NumbersBindingSource;
        private BradaDataSet BradaDataSet;
        private System.Windows.Forms.BindingSource Tbl_Casheir_nameBindingSource;
        private System.Windows.Forms.BindingSource item_orderBindingSource;
        private BradaDataSetTableAdapters.TBL_NumbersTableAdapter TBL_NumbersTableAdapter;
        private BradaDataSetTableAdapters.Tbl_Casheir_nameTableAdapter Tbl_Casheir_nameTableAdapter;
        private BradaDataSetTableAdapters.item_orderTableAdapter item_orderTableAdapter;
        private System.Windows.Forms.BindingSource Tbl_Daily_operationBindingSource;
        private BradaDataSetTableAdapters.Tbl_Daily_operationTableAdapter Tbl_Daily_operationTableAdapter;
        private System.Windows.Forms.BindingSource Tbl_Casheir_SalesBindingSource;
        private BradaDataSetTableAdapters.Tbl_Casheir_SalesTableAdapter Tbl_Casheir_SalesTableAdapter;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}