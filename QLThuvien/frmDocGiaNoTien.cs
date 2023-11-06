using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThuvien
{
    public partial class frmDocGiaNoTien : Form
    {
        public DataTable dt_DG = new DataTable();       

        public frmDocGiaNoTien()
        {
            InitializeComponent();           
        }

        private void frmDocGiaNoTien_Load(object sender, EventArgs e)
        {
            /*string crpPath = @"F:\SGU\C#\lab9\QLThuvien - 3 lop\QLThuvien\rptTinhHinhDocGiaNoTienPhat.rpt";
            ReportDocument crp = new ReportDocument();
            //crp.SetDataSource(dt_DG); //chỉ định datasource cho report
            crp.Load(crpPath);
            crystalReportViewer1.ReportSource = crp; //hi n thị report lên form*/
            
        }
    }
}
