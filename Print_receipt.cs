using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using CrystalDecisions.CrystalReports.Engine;

using System.Data.SqlClient;

namespace Brada3
{
    public partial class Print_receipt : Form
    {
        ReportDocument cry=new ReportDocument();
        BradaDataClassesDataContext brada = new BradaDataClassesDataContext();

        public Print_receipt() 
        {
            InitializeComponent();
        }

        private void Print_receipt_Load(object sender, EventArgs e)
        {
            // ----------- LAst Report Viewer
            //this.reportViewer1.RefreshReport();
            //using (BradaDataContext brada=new BradaDataContext())
            //{
            //    var v = (from a in brada.join_tables_report1()
            //             select a);
            //    ReportDataSource rd = new ReportDataSource("DataSet3", v.ToList());
                
              //  reportViewer1.LocalReport.DataSources.Add(rd);
            
            //}

            //--------------------- Crystal Report Viewer

            cry.Load(@"C:\Users\Mohamed Atef\Documents\Visual Studio 2010\Projects\Brada3\Brada3\CrystalReport2Eid.rpt");

            SqlConnection con = new SqlConnection("Data Source=PROF-MOHAMED;Initial Catalog=Brada;Integrated Security=True;");

            SqlDataAdapter sda = new SqlDataAdapter();

           







        }
    }
}
