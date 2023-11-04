using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace QLThuvienNTT
{
    class Database
    {
        SqlConnection sqlConn; //Doi tuong ket noi CSDL
        SqlDataAdapter da;//Bo dieu phoi du lieu
        DataSet ds; //Doi tuong chhua CSDL khi giao tiep
        public string svrName = "LAPTOP-AFOP5TPF\\SQLSERVER";	//chỉ định tên server
        public string dbName = "QLTHUVIEN";   //chỉ định tên CSDL
        public Database()
        {
            try
            {
                string strCnn = "Data source=" + svrName + ";database=" + dbName + "; Integrated Security = True";
                sqlConn = new SqlConnection(strCnn);
                sqlConn.Open();                
            }
            catch (Exception e)
            {
                Console.WriteLine("Khong on roi", e);
                // Handle the exception here
                // For example, you can log the error or show a message to the user
            }
        }
        public Database(string svrName, string dbName, bool intergratedMode) {
            string connStr;           
                
            connStr = "server=" + svrName + "; database=" + dbName + "; Integrated Security = True";  
            sqlConn = new SqlConnection(connStr);
        }


        //Phuong thuc de thuc hien cau lenh strSQL truy vân du lieu
        public DataTable Execute(string sqlStr)
        {
            da = new SqlDataAdapter(sqlStr, sqlConn); 
            ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        //Phuong thuc de thuc hien cac lenh Them, Xoa, Sua
        public void ExecuteNonQuery(string strSQL)
        {
            SqlCommand sqlcmd = new SqlCommand(strSQL, sqlConn); 
            if(sqlConn.State == ConnectionState.Closed)
                sqlConn.Open(); //Mo ket noi
            sqlcmd.ExecuteNonQuery();//Lenh hien lenh Them/Xoa/Sua
            if (sqlConn.State == ConnectionState.Open)
                sqlConn.Close();//Dong ket noi
        }

        public void Update(string strQuery, DataTable table)
        {
            //Cập nhật 1 Datatable xuống CSDL
            da = new SqlDataAdapter(strQuery, sqlConn);
            SqlCommandBuilder sqlcb = new SqlCommandBuilder(da);
            da.Update(table);
        }
    }
}
