using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPro_v._1._0
{
    public class UpdateUserStatus
    {
        // thay đổi trạng thái user
        public string ChangeStatus(string username)
        {
            string error = "";
            try
            {
                DAL.Constance.ExecuteQueryNonDataSet("proc_UpdateUserStatus",
                    System.Data.CommandType.StoredProcedure, ref error, new System.Data.SqlClient.SqlParameter("@username", username));
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return error;
        }
    }
}
