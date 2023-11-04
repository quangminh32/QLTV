using QLThuvienNTT;
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
    public partial class frmDocGia : Form
    {
        DocGia dg = new DocGia();
        Database db = new Database(frmMDI.svrName, frmMDI.dbName, frmMDI.intergratedMode); 
        DataTable dt = new DataTable();
        public frmDocGia()
        {
            InitializeComponent();            
        }

        private void frmDocGia_Load(object sender, EventArgs e)
        {
            dt = dg.LayDSDocGia();
            dgvDocGia.DataSource = dt; //gán dữ liệu cho datagrid
                                       //Thiết lập độ rộng các cột
            dgvDocGia.Columns[0].Visible=false;
            dgvDocGia.Columns[1].Width = 180;
            dgvDocGia.Columns[3].Width = 200;
            dgvDocGia.Columns[4].Width = 200;
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                db.Update("Select * from DocGia", dt); 
                MessageBox.Show("Cập nhật thành công");
            }
            catch (DataException de)
            {
                MessageBox.Show("Có lỗi khi cập nhật \n" + de.ToString(), "lỗi",
                MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmDocGia_FormClosing(Object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thoát", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dr == DialogResult.No)
                e.Cancel = true;
        }
    }
}
