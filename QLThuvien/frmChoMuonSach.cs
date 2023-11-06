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

namespace QLThuvien
{
    public partial class frmChoMuonSach : Form
    {
        PhieuMuon pm;
        DocGia dg;
        DataTable dt;
        //khai báo biến đ truyền qua form frmchitietphieumuon
        string mapm;
        string madg;
        string tendg;
        bool isAdded = true;
        public frmChoMuonSach()
        {
            InitializeComponent();
            pm = new PhieuMuon();
            dt = new DataTable();
            dg = new DocGia();            
        }
        private void frmChoMuonSach_Load(object sender, EventArgs e)
        {
            HienThiDanhSach();
            LayDSDocGia();

        }
        public void setButton(bool value)
        {
            btnThem.Enabled = value;
            btnXoa.Enabled = value;
            btnSua.Enabled = value;
            btnLuu.Enabled = !value;
            btnHuy.Enabled = !value;
            btnCTPhieuMuon.Enabled = value;
            btnThoat.Enabled = value;
        }
        public void HienThiDanhSach()
        {            
            dt.Rows.Clear();
            dt = pm.LayDSPhieuMuon();
            lsvPhieuMuon.Items.Clear();
            lsvPhieuMuon.View = View.Details;
            lsvPhieuMuon.FullRowSelect = true;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi;
                lvi = lsvPhieuMuon.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i]["HoTenDocGia"].ToString());
                lvi.SubItems.Add(String.Format("{0:MM/dd/yyyy}", dt.Rows[i]["NgayMuon"].ToString()));
            }            
        }

        public void LayDSDocGia()
        {
            DataTable dt_dg = dg.LayDSDocGia();
            cboHoTen.DataSource = dt_dg;
            cboHoTen.DisplayMember = "HoTenDocGia";
            cboHoTen.ValueMember = "MaDocGia";
            if (cboHoTen.Items.Count > 0)
                cboHoTen.SelectedIndex = 0;
        }        

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdded = true;
            setButton(false);

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lsvPhieuMuon.SelectedIndices.Count > 0)
            {
                isAdded = false;
                setButton(false);
            }
            else
                MessageBox.Show("Bạn phải chọn mẫu tin cập nhật", "Sửa mẫu tin");
        }

        private void lsvPhieuMuon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvPhieuMuon.SelectedIndices.Count > 0)
            {                
                cboHoTen.SelectedIndex = cboHoTen.FindString(lsvPhieuMuon.SelectedItems[0].SubItems[1].Text);
                dtpNgayMuon.Value = DateTime.Parse(lsvPhieuMuon.SelectedItems[0].SubItems[2].Text);
            }

        }

        private void btnCTPhieuMuon_Click(object sender, EventArgs e)
        {
            if (lsvPhieuMuon.SelectedIndices.Count > 0)
            {
                //Lấy thông tin về Mã độc giả (madg), Mã phiếu mượn 
                //(mapm) và tên độc giả (tendg)
                madg = cboHoTen.SelectedValue.ToString();
                mapm = lsvPhieuMuon.SelectedItems[0].Text;
                tendg = lsvPhieuMuon.SelectedItems[0].SubItems[1].Text;
                //và truyền qua form ChitietPhieuMuon
                frmChiTietPhieuMuon frm = new frmChiTietPhieuMuon(mapm, madg, tendg);
                frm.Show();
            }
            else
                MessageBox.Show("Bạn phải chọn một phiếu mượn đ nhập chi tiết");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lsvPhieuMuon.SelectedIndices.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có ch c xóa không?",
               "Xóa bằng cấp", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    pm.XoaPM(lsvPhieuMuon.SelectedItems[0].SubItems[0].Text);
                    lsvPhieuMuon.Items.RemoveAt(lsvPhieuMuon.SelectedIndices[0]);
                }
            }
            else
                MessageBox.Show("Bạn phải chọn mẩu tin cần xóa");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboHoTen.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn hãy nhập thông tin họ tên", "Thiếu thông tin");
                cboHoTen.Focus();
            }
            else
            {
                string ngaymuon = String.Format("{0:MM/dd/yyyy}", dtpNgayMuon.Value);
                string madg = cboHoTen.SelectedValue.ToString();
                try
                {
                    if (isAdded) //là thêm mới
                        pm.ThemPM(cboHoTen.SelectedValue.ToString(), ngaymuon);
                    else // là cập nhật
                    {
                        string mapm = lsvPhieuMuon.SelectedItems[0].SubItems[0].Text;
                        pm.CapNhatPM(mapm, ngaymuon, madg);
                    }
                    HienThiDanhSach();
                    setButton(true);
                    MessageBox.Show("Thành công");
                }
                catch (DataException de)
                {
                    MessageBox.Show("Có lỗi khi lưu : " + de.ToString());
                }
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            setButton(true);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmChoMuonSach_FormClosing(Object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thoát", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dr == DialogResult.No)
                e.Cancel = true;
        }
    }
}
