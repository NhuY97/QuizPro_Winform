using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using QuizPro_v._1._0.Controller;

namespace QuizPro_v._1._0
{
    public class BDStudentManager
    {
        public string error = "";

        public BDStudentManager()
        {
            error = DAL.Constance.ERROR;
        }

        public string getFullname(string username)
        {
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@username";
            p1.Value = username;
            p1.Direction = ParameterDirection.Input;
            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@fullname";
            p2.Direction = ParameterDirection.Output;
            p2.SqlDbType = SqlDbType.NVarChar;
            p2.DbType = DbType.String;
            p2.Size = 50;

            List<string> l = new List<string>();
            try
            {
                l = DAL.Constance.ExecuteQueryOutput("proc_getUserName", CommandType.StoredProcedure, p1, p2);
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            if (l.Count > 0)
            {
                return l.First();
            }
            else return "";
        }

        public string getAVGMark()
        {
            string sql = string.Format("SELECT dbo.getAvgMark('{0}')", DAL.Username);
            return DAL.Constance.ExecuteQueryScalar(sql, CommandType.Text, ref error).ToString();
        }
        public DataTable getExamInfo(string username)
        {
            try
            {
                DataSet ds = DAL.Constance.ExecuteQueryDataSet("proc_StudentViewExam", CommandType.StoredProcedure, new SqlParameter("@username", username));
                return ds.Tables[0];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public DataTable getExamHistory(string username)
        {
            try
            {
                DataSet ds = DAL.Constance.ExecuteQueryDataSet("proc_getExamHistory", CommandType.StoredProcedure, new SqlParameter("@username", username));
                return ds.Tables[0];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<QuestionObj> getQuestion(string examId)
        {
            List<QuestionObj> list = new List<QuestionObj>();
            DataSet ds = DAL.Constance.ExecuteQueryDataSet("proc_getQuestion", CommandType.StoredProcedure, new SqlParameter("@examid", examId));
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                QuestionObj question = new QuestionObj(row.ItemArray[0].ToString(), row.ItemArray[1].ToString());
                list.Add(question);
            }
            return list;
        }

        public List<AnswerObj> getAnswer(string quesId)
        {
            List<AnswerObj> list = new List<AnswerObj>();
            DataSet ds = DAL.Constance.ExecuteQueryDataSet("proc_getAnswer", CommandType.StoredProcedure, new SqlParameter("@quesid", quesId));
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                AnswerObj answer = new AnswerObj(row.ItemArray[0].ToString(), 
                    row.ItemArray[1].ToString(), (Boolean)row.ItemArray[2]);
                list.Add(answer);
            }
            return list;
        }

        public bool submitExam(string examId, double mark, string timeComplete)
        {
            SqlParameter p1 = new SqlParameter("@username", DAL.Username);
            SqlParameter p2 = new SqlParameter("@examid", examId);
            SqlParameter p3 = new SqlParameter("@mark", mark);
            SqlParameter p4 = new SqlParameter("@timeComplete", timeComplete);
            p3.SqlDbType = SqlDbType.Decimal;
            return DAL.Constance.ExecuteQueryNonDataSet("PROC_submitExam", CommandType.StoredProcedure,ref error, p1, p2, p3, p4);
        }
    }
}
