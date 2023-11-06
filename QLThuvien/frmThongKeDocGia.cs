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
    public partial class frmThongKeDocGia : Form
    {
        DocGia dg;
        float tong = 0;
        DataTable dt = new DataTable();

        public frmThongKeDocGia()
        {
            InitializeComponent();
            dg = new DocGia();

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmDocGiaNoTien frm = new frmDocGiaNoTien();
            frm.Show();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            lvMuonSach.View = View.Details;
            lvMuonSach.FullRowSelect = true;
            lvMuonSach.Items.Clear();
            tong = 0; //tổng số tiền độc giả nợ
            dt.Clear();
            if (rdbTatCa.Checked) {
                dt = dg.LayDSDocGia();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    float tien = float.Parse(dt.Rows[i]["tienno"].ToString());



                    string tienno = String.Format("{0:0,000}", tien);
                    tong += tien;
                    ListViewItem lvi = lvMuonSach.Items.Add(i.ToString());
                    lvi.SubItems.Add(dt.Rows[i]["hotendocgia"].ToString());
                    lvi.SubItems.Add(tienno);

                }
            }
                
            else {
                dt = dg.LayDSDocGia();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    float tien = float.Parse(dt.Rows[i]["tienno"].ToString());

                    if (tien > 0)
                    {
                        string tienno = String.Format("{0:0,000}", tien);
                        tong += tien;
                        ListViewItem lvi = lvMuonSach.Items.Add(i.ToString());
                        lvi.SubItems.Add(dt.Rows[i]["hotendocgia"].ToString());
                        lvi.SubItems.Add(tienno);
                    }
                }
            }
                
            lblTong.Text = String.Format("{0:0,000}", tong);
        }
    }
}
