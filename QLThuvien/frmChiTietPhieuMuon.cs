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
    public partial class frmChiTietPhieuMuon : Form
    {
        public string mapm;
        public string madg;
        public string tendg;
        DataTable dt_s; // sách có trong thư viện
        DataTable dt_schon; // sách cho độc giả mượn
        ChiTietPhieuMuon ctpm;
        Sach sach;
        public frmChiTietPhieuMuon(string MAPM, string MADG, string TENDG)
        {
            InitializeComponent();
            ctpm = new ChiTietPhieuMuon();
            dt_s = new DataTable();
            dt_schon = new DataTable();
            sach = new Sach();
            //nhận tham số từ bên Form PHIEUMUON truyền qua
            mapm = MAPM;
            madg = MADG;
            tendg = TENDG;
        }
        public void HienThiDanhSach_SachNguon()
        {
            dt_s.Rows.Clear();
            dt_s = sach.LayDSSach();
            lsvSachNguon.Items.Clear();
            lsvSachNguon.View = View.Details;
            lsvSachNguon.FullRowSelect = true;
            for (int i = 0; i < dt_s.Rows.Count; i++)
            {
                ListViewItem lvi;
                lvi = lsvSachNguon.Items.Add(dt_s.Rows[i][0].ToString());
                lvi.SubItems.Add(dt_s.Rows[i]["TenSach"].ToString());
                lvi.SubItems.Add(dt_s.Rows[i]["TacGia"].ToString());
                lvi.SubItems.Add(dt_s.Rows[i]["NamXuatBan"].ToString());
                lvi.SubItems.Add(dt_s.Rows[i]["NhaXuatBan"].ToString());
                lvi.SubItems.Add(dt_s.Rows[i]["TriGia"].ToString());
                lvi.SubItems.Add(String.Format("{0:MM/dd/yyyy}", dt_s.Rows[i]["NgayNhap"].ToString()));
            }
        }
        public void HienThiDanhSach_SachChon()
        {
            dt_schon.Rows.Clear();
            dt_schon = sach.LayDSSachTheoDG(madg);
            lsvSachChon.Items.Clear();
            lsvSachChon.View = View.Details;
            lsvSachChon.FullRowSelect = true;
            for (int i = 0; i < dt_schon.Rows.Count; i++)
            {
                ListViewItem lvi;
                lvi = lsvSachChon.Items.Add(dt_schon.Rows[i][0].ToString());
                lvi.SubItems.Add(dt_schon.Rows[i]["TenSach"].ToString());
                lvi.SubItems.Add(dt_schon.Rows[i]["TacGia"].ToString());
                lvi.SubItems.Add(dt_schon.Rows[i]["NamXuatBan"].ToString());
                lvi.SubItems.Add(dt_schon.Rows[i]["NhaXuatBan"].ToString());
                lvi.SubItems.Add(dt_schon.Rows[i]["TriGia"].ToString());
                lvi.SubItems.Add(String.Format("{0:MM/dd/yyyy}", dt_s.Rows[i]["NgayNhap"].ToString()));
            }
        }

        bool isChoosen(string item, ListView lv)
        {
            for (int i = 0; i < lv.Items.Count; i++)
                if (item.Equals(lv.Items[i].Text))
                    return false;
            return true;
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (lsvSachNguon.SelectedIndices.Count > 0)
            {
                for (int i = 0; i < lsvSachNguon.SelectedIndices.Count; i++)
                {
                    if (lsvSachChon.Items.Count >= 3)
                    {
                        MessageBox.Show("Mỗi Độc giả chỉ được mượn tối đa 3 quy n");
                        return;
                    }
                    if (isChoosen(lsvSachNguon.SelectedItems[i].Text, lsvSachChon))
                    { //ki m tra xem sách đã được cho mượn rồi hay không?
                        ListViewItem lviSachNguon = lsvSachNguon.Items[lsvSachNguon.SelectedIndices[i]];
                        ListViewItem lviSachChon = lsvSachChon.Items.Add(lviSachNguon.SubItems[0].Text);
                        lviSachChon.SubItems.Add(lviSachNguon.SubItems[1].Text);
                        lviSachChon.SubItems.Add(lviSachNguon.SubItems[2].Text);
                        lviSachChon.SubItems.Add(lviSachNguon.SubItems[3].Text);
                        lviSachChon.SubItems.Add(lviSachNguon.SubItems[4].Text);
                        lviSachChon.SubItems.Add(lviSachNguon.SubItems[5].Text);
                        lviSachChon.SubItems.Add(lviSachNguon.SubItems[6].Text);
                        //thêm mới sách vào chi tiết phiếu mượn
                        ctpm.ThemCTPM(lsvSachNguon.SelectedItems[i].Text, mapm);
                    }
                    else
                    {
                        MessageBox.Show("Sách này đã được chọn rồi, vui lòng chọn sách khác", "Lỗi chọn sách",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

        }

        private void btnHuyCT_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void frmChiTietPhieuMuon_FormClosing(Object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thoát", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dr == DialogResult.No)
                e.Cancel = true;
        }

        private void btnTra_Click(object sender, EventArgs e)
        {
            if (lsvSachChon.SelectedIndices.Count > 0)
            {
                for (int i = 0; i < lsvSachChon.SelectedIndices.Count; i++)
                {
                    ctpm.XoaCTPM(lsvSachChon.SelectedItems[i].SubItems[0].Text, mapm);
                    lsvSachChon.Items.RemoveAt(lsvSachChon.SelectedIndices[i]);
                }
            }

        }

        private void frmChiTietPhieuMuon_Load(object sender, EventArgs e)
        {
            lblMaPM.Text = mapm; //hi n thị mã phi u mượn
            lblTenDG.Text = tendg; // hi n thị tên độc giả mượn sách
            HienThiDanhSach_SachNguon(); 
            HienThiDanhSach_SachChon();
        }
    }
}
