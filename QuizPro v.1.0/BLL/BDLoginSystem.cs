using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QuizPro_v._1._0
{
    public class DBLoginSystem
    {
        public string error ="";
        public enum connStatus { success, fail, notconnect}; // trạng thái kết nối
        // success: thành công
        // fail: sai tài khoản hoặc mật khẩu
        //notconnect: lỗi kết nối đến CSDL
        public DBLoginSystem(string StrConnection)
        {
            DAL.StrConnection = StrConnection;
            error = DAL.Constance.ERROR;
        }

        public int isConnect(string username, string pwd, string rolename)
        {
            SqlParameter p1 = new SqlParameter("@user", username);
            SqlParameter p2 = new SqlParameter("@pwd", pwd);
            SqlParameter p3 = new SqlParameter("@rolename", rolename);
            bool result = false;
            try
            {
                result = DAL.Constance.ExecuteQueryNonDataSet("proc_LoginState", CommandType.StoredProcedure, ref error, p1, p2, p3);
            }
            catch (Exception e) { Console.Write(e.Message); return (int)connStatus.fail; }
                if (!result)
                {
                    return (int)connStatus.fail;
                }
                if (result)
                {
                    return (int)connStatus.success;
                }
                return (int)connStatus.notconnect;
        }
    }
}
