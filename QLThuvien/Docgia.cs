using QLThuvienNTT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuvien
{
    class DocGia
    {
        Database db;
        public DocGia()
        {
            db = new Database();
        }
        public DataTable LayDSDocGia()
        {
            string strSQL = "Select * from DOCGIA";
            DataTable dt = db.Execute(strSQL);
            Console.WriteLine(dt);            
            return dt;
        }
    }
}
