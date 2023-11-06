using QLThuvienNTT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuvien
{
    internal class PhieuMuon
    {
        Database db;
        DataTable dt_pm;
        public PhieuMuon()
        {
            db = new Database(frmMDI.svrName, frmMDI.dbName, frmMDI.intergratedMode);
        }
        public DataTable LayDSPhieuMuon()
        {
            dt_pm = db.Execute("Select MaPhieuMuon, PMS.MaDocGia, DG.HoTenDocGia, NgayMuon from PHIEUMUONSACH PMS, DOCGIA DG where PMS.MaDocGia = DG.MaDocGia Order By MaPhieuMuon");
            return dt_pm;
        }
        public void ThemPM(string madocgia, string ngaymuon)
        {
            string sql = string.Format("INSERT INTO PHIEUMUONSACH VALUES('{0}',{1})",ngaymuon,madocgia);
            db.ExecuteNonQuery(sql);
        }
        public void XoaPM(string index)
        {
            String sql = "Delete from PHIEUMUONSACH where MaPhieuMuon = " + index;
            db.ExecuteNonQuery(sql);
        }
        public void CapNhatPM(string index, string ngaymuon, string madocgia)
        {
            string sql = string.Format("Update PHIEUMUONSACH set ngaymuon='{0}',madocgia={1} where MaPhieuMuon = {2}",ngaymuon,madocgia,index);
            db.ExecuteNonQuery(sql);
        }
    }

}


