using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPro_v._1._0
{
    public class BDAdminManager
    {
        public string error = ""; // lổi
        public enum WhichUser { ALL, ADMIN, TEACHER, STUDENT }; // đối tượng

        public BDAdminManager()
        {
            error = DAL.Constance.ERROR; // lấy lỗi từ DAL
        }
        // lấy danh sách user theo từng đối tượng (phân trang)
        public DataTable getListUser(int whichUser, int PageIndex, int PageSize, ref int RecordNo)
        {
            try
            {
                System.Data.SqlClient.SqlParameter p = new System.Data.SqlClient.SqlParameter();
                p.SqlDbType = SqlDbType.Int;
                p.ParameterName = "@RecordNo";
                p.Direction = ParameterDirection.Output;
                string _procName;
                switch (whichUser) {
                    case (int)WhichUser.ADMIN: _procName = "proc_ListAdmin";
                        break;
                    case (int)WhichUser.TEACHER: _procName = "proc_ListTeacher";
                        break;
                    case (int)WhichUser.STUDENT: _procName = "proc_ListStudent";
                        break;
                    default: _procName = "proc_ListUser";
                        break;
                }
                DataTable dt = DAL.Constance.ExecuteQueryDataSet(_procName, CommandType.StoredProcedure, new System.Data.SqlClient.SqlParameter("@pageIndex", PageIndex), new System.Data.SqlClient.SqlParameter("@pageSize", PageSize), p).Tables[0];
                RecordNo = int.Parse(p.Value.ToString());
                return dt;
            }
            catch (Exception e) { Console.Write(e.Message); return null; }
        }

        public bool updateAvatar(string username, string avatar)
        {
            return DAL.Constance.ExecuteQueryNonDataSet("proc_updateAvatar", CommandType.StoredProcedure, ref error, new SqlParameter("@username", username), new System.Data.SqlClient.SqlParameter("@avatar", avatar));
        }

        public bool changePwd(string username, string pwd){
            pwd = Encrypter.Encrypt(pwd);
            return DAL.Constance.ExecuteQueryNonDataSet("proc_changePwd", CommandType.StoredProcedure, ref error, new SqlParameter("@username", username), new SqlParameter("@pwd", pwd));
        }

        public bool ChangeRole(string role, string username)
        {
            return DAL.Constance.ExecuteQueryNonDataSet("proc_changeRole", CommandType.StoredProcedure, ref error, new SqlParameter("@username", username), new SqlParameter("rolename", role));
        }

        public bool deleteUser(string username)
        {
            return DAL.Constance.ExecuteQueryNonDataSet("proc_deleteUser", CommandType.StoredProcedure, ref error, new SqlParameter("@username", username));
        }

        public bool updateUser(string username,string fullname,bool gender,DateTime birthday)
        {
            SqlParameter p1 = new SqlParameter("@gender", gender);
            SqlParameter p2 = new SqlParameter("@birthday", birthday);
            p1.SqlDbType = SqlDbType.Bit;
            p2.SqlDbType = SqlDbType.Date;
            return DAL.Constance.ExecuteQueryNonDataSet("proc_editUser", CommandType.StoredProcedure, ref error,
                new SqlParameter("@username", username),new SqlParameter("@fullname",fullname), p1, p2);
        }

        public string getRoleid(string rolename)
        {
            rolename = rolename.ToLower();
            return DAL.Constance.ExecuteQueryScalar("proc_getRoleId", CommandType.StoredProcedure,ref error,
                new SqlParameter("@rolename", rolename)).ToString();
        }
        public bool addUser(String username, string fullname, bool gender, DateTime birthday, string roleid)
        {
            return DAL.Constance.ExecuteQueryNonDataSet("proc_addUser", CommandType.StoredProcedure,ref error, 
                new SqlParameter("@username", username), new SqlParameter("@fullname", fullname), new SqlParameter("@gender", gender),
                new SqlParameter("@birthday", birthday), new SqlParameter("@roleid", roleid));
        }

        public bool addClass(String classname, int maxMember)
        {
            return DAL.Constance.ExecuteQueryNonDataSet("proc_insertClass", CommandType.StoredProcedure, ref error,
                new SqlParameter("@classname", classname), new SqlParameter("@maxMember", maxMember));
        }

        public bool addListClass(String classname, string username)
        {
            return DAL.Constance.ExecuteQueryNonDataSet("proc_insertListClass", CommandType.StoredProcedure, ref error,
                new SqlParameter("@classname", classname), new SqlParameter("@username", username));
        }

        public DataTable getListClass()
        {
            DataSet ds = DAL.Constance.ExecuteQueryDataSet("proc_ListClass", CommandType.StoredProcedure);
            error = DAL.Constance.ERROR;
            return ds.Tables[0];
        }

        public DataTable getListSubject()
        {
            DataSet ds = DAL.Constance.ExecuteQueryDataSet("proc_ListSubject", CommandType.StoredProcedure);
            error = DAL.Constance.ERROR;
            return ds.Tables[0];
        }
        public bool updateListClass(string classid, string username)
        {
            return DAL.Constance.ExecuteQueryNonDataSet("proc_updateListClass", CommandType.StoredProcedure, ref error, new SqlParameter("@classid", classid), new SqlParameter("@username",username));
        }
        public bool updateTeacher(string subid, string username)
        {
            return DAL.Constance.ExecuteQueryNonDataSet("proc_updateTeacher", CommandType.StoredProcedure, ref error, new SqlParameter("@subid", subid), new SqlParameter("@username", username));
        }
        public bool insertTeacher(string subid, string username)
        {
            return DAL.Constance.ExecuteQueryNonDataSet("proc_insertTeacher", CommandType.StoredProcedure, ref error, new SqlParameter("@subid", subid), new SqlParameter("@username", username));
        }
        public bool deleteTeacher(string username)
        {
            return DAL.Constance.ExecuteQueryNonDataSet("", CommandType.StoredProcedure, ref error, new SqlParameter("@username", username));
        }
        public DataTable getUserInfo()
        {
            DataSet ds = DAL.Constance.ExecuteQueryDataSet("proc_getUSerInfo", CommandType.StoredProcedure, new SqlParameter("@username", DAL.Username));
            if (ds == null || ds.Tables.Count == 0)
            {
                error = DAL.Constance.ERROR;
                return null;
            }
            else return ds.Tables[0];
        }

        public string getClassName()
        {
            string sql = string.Format("SELECT dbo.getClassName('{0}')", DAL.Username);
            return DAL.Constance.ExecuteQueryScalar(sql, CommandType.Text, ref error).ToString();
        }

        public DataTable getSubject()
        {
            DataSet ds = DAL.Constance.ExecuteQueryDataSet("proc_getSubject", CommandType.StoredProcedure, new SqlParameter("@username", DAL.Username));
            if (ds == null || ds.Tables.Count == 0)
            {
                error = DAL.Constance.ERROR;
                return null;
            }
            else return ds.Tables[0];
        }
    }
}
