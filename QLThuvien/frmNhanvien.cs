using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLThuvienNTT
{
    public partial class frmNhanvien : Form
    {
        public bool themmoi = false;
        Nhanvien nv = new Nhanvien(); 
        public frmNhanvien()
        {
            InitializeComponent();
            HienthiNhanvien();
            HienthiBangcap();
        }
        void HienthiNhanvien()
        {
            lsvNhanVien.Items.Clear();
            lsvNhanVien.Refresh();
            DataTable dt = nv.LayDSNhanvien(); 
            lsvNhanVien.FullRowSelect = true; //cho phép chọn 1 dòng

            lsvNhanVien.View = View.Details; //cho phép hiển thị thông tin chi tiết dạng bảng

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi =
                lsvNhanVien.Items.Add(dt.Rows[i][0].ToString()); 
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
                lvi.SubItems.Add(dt.Rows[i][5].ToString());
            }
        }
        void setNull()
        {
            txtHoten.Text = ""; txtDiaChi.Text = ""; txtDienThoai.Text = "";
        }
        void setButton(bool val)
        {            
            btnThem.Enabled = val; 
            btnXoa.Enabled = val; 
            btnSua.Enabled = val; 
            btnThoat.Enabled = val; 
            btnLuu.Enabled = !val; 
            btnHuy.Enabled = !val;
        }
        void HienthiBangcap()
        {
            DataTable dt = nv.LayBangcap(); 
            cboBangCap.DataSource = dt; 
            cboBangCap.DisplayMember = "TenBangcap"; 
            cboBangCap.ValueMember = "MaBangcap";
        }
        private void frmNhanvien_Load(object sender, EventArgs e)
        {
            setNull(); 
            setButton(true); 
            HienthiNhanvien(); 
            HienthiBangcap();
        }

        private void lsvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvNhanVien.SelectedIndices.Count > 0)
            {                
                txtHoten.Text = lsvNhanVien.SelectedItems[0].SubItems[1].Text;
                //Chuyen sang kieu dateTime
                dtpNgaySinh.Value =
                DateTime.Parse(lsvNhanVien.SelectedItems[0].SubItems[2].Text); txtDiaChi.Text =
                lsvNhanVien.SelectedItems[0].SubItems[3].Text;
                txtDienThoai.Text = lsvNhanVien.SelectedItems[0].SubItems[4].Text;
                //Tìm  vị  trí  của  Tên  bằng  cấp  trong  Combobox
                cboBangCap.SelectedIndex =
                cboBangCap.FindString(lsvNhanVien.SelectedItems[0].SubItems[5].Text);
            }
        }        
        private void btnThem_Click(object sender, EventArgs e)
        {
            themmoi = true; 
            setButton(false); 
            txtHoten.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lsvNhanVien.SelectedIndices.Count > 0)
            {
                themmoi = false; 
                setButton(false);
            }
            else              
                MessageBox.Show("Bạn  phải  chọn  mẫu  tin  cập  nhật", "Sửa mẫu tin");

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            setButton(true);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thoát", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Close();
            }            
        }

        private void frmNhanvien_FormClosing(Object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thoát", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dr == DialogResult.No)            
                e.Cancel = true;            
        }

        private void btnXoa_Click(object sender, EventArgs e)
            {
            if (lsvNhanVien.SelectedIndices.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn xóa không?", "Xóa bằng cấp", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    nv.XoaNhanVien(lsvNhanVien.SelectedItems[0].SubItems[0].Text); 
                    lsvNhanVien.Items.RemoveAt(lsvNhanVien.SelectedIndices[0]);
                    setNull();
                }
            }
            else
                MessageBox.Show("Bạn  phải  chọn  mẩu  tin  cần  xóa");

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string ngay = String.Format("{0:MM/dd/yyyy}", dtpNgaySinh.Value);
            //Định  dạng  ngày  tương  ứng  với  trong  CSDL  SQLserver 
            if (themmoi)
            {                
                nv.ThemNhanVien(txtHoten.Text, ngay, txtDiaChi.Text, txtDienThoai.Text, cboBangCap.SelectedValue.ToString());
                MessageBox.Show("Thêm  mới  thành  công");
            }
            else 
            {
                nv.CapNhatNhanVien(lsvNhanVien.SelectedItems[0].SubItems[0].Text, txtHoten.Text, ngay, txtDiaChi.Text, txtDienThoai.Text,
                cboBangCap.SelectedValue.ToString());
                MessageBox.Show("Cập  nhật  thành  công");               
            }
            HienthiNhanvien();
            setNull();


        }

        
    }
}
