using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPro_v._1._0
{
    public class DAL
    {
        private static DAL constance;
        public SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter da;
        SqlConnectionStringBuilder builder;
        private static string strConnection;
        private static string username;
        private static string password;
        private static string rolename;
        public string ERROR;
        private static readonly object key = new object();
        public DAL()
        {
            builder = new SqlConnectionStringBuilder();
            string[] str = StrConnection.Split(',');
            builder.DataSource = str[0];
            builder.UserID = str[1];
            builder.Password = str[2];
            builder.InitialCatalog = "QuanLyThiTracNghiemOnline";
            builder.IntegratedSecurity = bool.Parse(str[3]);
            ERROR = "";
            try
            {
                conn = new SqlConnection(builder.ConnectionString);
                comm = conn.CreateCommand();
            }
            catch (Exception e) { ERROR = e.Message; }
        }

        public static DAL Constance { get { lock (key) { if (constance == null){ constance = new DAL(); } return constance; } } set => constance = value; }

        public static string StrConnection { get => strConnection; set => strConnection = value; }
        public static string Username { get => username; set => username = value; }
        public static string Password { get => password; set => password = value; }
        public static string Rolename { get => rolename; set => rolename = value; }

        // query trả về bảng
        public DataSet ExecuteQueryDataSet(string StrSql, CommandType ct, params SqlParameter[] p)
        {

            DataSet ds = new DataSet();

            da = new SqlDataAdapter(StrSql, conn);
            da.SelectCommand.CommandType = ct;
            foreach (SqlParameter sp in p)
            {
                da.SelectCommand.Parameters.Add(sp);
            }
            try
            {
                da.Fill(ds);
            }
            catch (Exception e)
            {
                ERROR = e.Message;
            }
            finally
            {
                if (comm != null)
                    comm = null;
            }
            return ds;
        }
        // query trả về số record bị thao tác (thêm, sửa, xóa)
        public bool ExecuteQueryNonDataSet(string StrSql, CommandType ct, ref string error, params SqlParameter[] param)
        {
            bool f = false;


            comm = new SqlCommand(StrSql, conn);
            comm.CommandType = ct;
            comm.Parameters.Clear();
            foreach (SqlParameter sp in param)
            {
                comm.Parameters.Add(sp);
            }
            try
            {
                if(comm.ExecuteNonQuery() > 0)
                f = true;
            }
            catch (SqlException se)
            {
                error = se.Message;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            finally
            {
                if (comm != null)
                    comm = null;
            }
            return f;
        }
        // lấy giá trị dòng đầu và cột đầu của bảng 
        public object ExecuteQueryScalar(string StrSql, CommandType ct, ref string error, params SqlParameter[] param)
        {
            object f=new object();


            comm = new SqlCommand(StrSql, conn);
            comm.CommandType = ct;
            comm.Parameters.Clear();
            foreach (SqlParameter sp in param)
            {
                comm.Parameters.Add(sp);
            }
            try
            {
                f = comm.ExecuteScalar();
            }
            catch (SqlException se)
            {
                error = se.Message;
            }
            catch (Exception se)
            {
                Console.WriteLine(se.ToString() + ":  " + se.Message);
            }
            finally
            {
                if (comm != null)
                    comm = null;
            }
            return f;
        }
        // lấy output từ procedure
        public List<string> ExecuteQueryOutput(string StrSql, CommandType ct, params SqlParameter[] p)
        {
            comm = new SqlCommand(StrSql, conn);
            comm.CommandType = ct;
            comm.Parameters.Clear();

            List<string> list = new List<string>();

            foreach (SqlParameter sp in p)
            {
                comm.Parameters.Add(sp);
            }
            try
            {
                comm.ExecuteNonQuery();
                foreach (SqlParameter param in p)
                {
                    if (param.Direction == ParameterDirection.Output)
                    {
                        list.Add(param.Value.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                ERROR = e.Message;
            }
            finally
            {
                if (comm != null)
                    comm = null;
            }
            return list;
        }
    }
}
