using QLThuvienNTT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuvien
{
    internal class Sach
    {
        Database db;
        public Sach()
        {
            db = new Database(frmMDI.svrName, frmMDI.dbName, frmMDI.intergratedMode);
        }
        public DataTable LayDSSach()
        {
            return db.Execute("Select * from SACH");
        }
        public DataTable LayDSSachTheoDG(string madg)
        {
            return db.Execute("Select * from SACH s, PHIEUMUONSACH pm, CHITIETPHIEUMUON ct where s.masach = ct.masach and ct.maphieumuon = pm.maphieumuon and madocgia = "+madg);
        }

    }
}
