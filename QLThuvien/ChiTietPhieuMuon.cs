using QLThuvienNTT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuvien
{
    internal class ChiTietPhieuMuon
    {
        Database db;
        public ChiTietPhieuMuon()
        {
            db = new Database(frmMDI.svrName, frmMDI.dbName, frmMDI.intergratedMode);
        }
        public DataTable LayDSChiTietPhieuMuon()
        {
            return db.Execute("Select * from ChiTietPhieuMuon Order By MaPhieuMuon");
        }
        public DataTable LayDSChiTietPhieuMuon(int MaPM)
        {
            return db.Execute(string.Format("Select * from ChiTietPhieuMuon where maphieumuon = {1} Order By MaPhieuMuon",MaPM));
        }
        public void ThemCTPM(string MaSach, string MaPM)
        {
            string sql = string.Format("INSERT INTO CHITIETPHIEUMUON VALUES({0},{1})",MaSach,MaPM);
            db.ExecuteNonQuery(sql);
        }
        public void XoaCTPM(string MaSach, string MaPM)
        {
            String sql = string.Format("Delete from CHITIETPHIEUMUON where Masach={0} and MaPhieuMuon = {1}",MaSach,MaPM);
            db.ExecuteNonQuery(sql);
        }

    }
}
