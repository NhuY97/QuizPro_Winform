using QuizPro_v._1._0.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPro_v._1._0.BLL
{
    public class BDTeacherManager
    {
        public string error = "";
        public enum WhichObj { EXAM, QUESTION, QUESTIONSOFEXAM }; // đối tượng

        string examid;

        public string Examid { get => examid; set => examid = value; }

        public BDTeacherManager()
        {
            error = DAL.Constance.ERROR;
        }
        // thông tin của từng đối tượng
        public DataTable getListObj(int whichUser, int PageIndex, int PageSize, ref int RecordNo)
        {
            try
            {
                DataTable dt;
                System.Data.SqlClient.SqlParameter p = new System.Data.SqlClient.SqlParameter();
                p.SqlDbType = SqlDbType.Int;
                p.ParameterName = "@RecordNo";
                p.Direction = ParameterDirection.Output;
                switch (whichUser)
                {
                    case (int)WhichObj.EXAM:
                        dt = DAL.Constance.ExecuteQueryDataSet("proc_ListExam", CommandType.StoredProcedure, new SqlParameter("@pageIndex", PageIndex), new SqlParameter("@pageSize", PageSize), new SqlParameter("@username", DAL.Username), p).Tables[0];
                        break;
                    case (int)WhichObj.QUESTION:
                        dt = DAL.Constance.ExecuteQueryDataSet("proc_ListQuestion", CommandType.StoredProcedure, new SqlParameter("@pageIndex", PageIndex), new SqlParameter("@pageSize", PageSize), new SqlParameter("@username", DAL.Username), p).Tables[0];
                        break;
                    case (int)WhichObj.QUESTIONSOFEXAM:
                        dt = DAL.Constance.ExecuteQueryDataSet("proc_ListQuestionsOfExam", CommandType.StoredProcedure, new SqlParameter("@pageIndex", PageIndex), new SqlParameter("@pageSize", PageSize), p, new SqlParameter("@examid", Examid)).Tables[0];
                        break;
                    default: dt = null;
                        break;
                }
                RecordNo = int.Parse(p.Value.ToString());
                return dt;
            }
            catch (Exception e) { Console.Write(e.Message); return null; }
        }

        public DataTable getListTypeName()
        {
            return DAL.Constance.ExecuteQueryDataSet("exec PROC_getContent null", CommandType.Text).Tables[0];
        }

        public bool UpdateQuestion(string quesId, string quesContent, string typeId)
        {
            return DAL.Constance.ExecuteQueryNonDataSet("proc_updateQues", CommandType.StoredProcedure, ref error, new SqlParameter("@quesid", quesId), new SqlParameter("@quescontent", quesContent), new SqlParameter("@typeid", typeId));
        }

        public bool UpdateAnswer(List<AnswerObj> listAnsw, string quesID)
        {
            bool result = true;
            foreach (AnswerObj anw in listAnsw)
            {
                if(anw.AnswerName != "")
                {
                    if (anw.AnswerId != "")
                    {
                        if (!DAL.Constance.ExecuteQueryNonDataSet("proc_updateAnswer", CommandType.StoredProcedure, ref error, new SqlParameter("@ansid", anw.AnswerId), new SqlParameter("@quesid", quesID), new SqlParameter("@anscontent", anw.AnswerName), new SqlParameter("@iscorrect", anw.IsCorrect)))
                            result = false;
                    }
                    else
                    {
                        if (!DAL.Constance.ExecuteQueryNonDataSet("proc_insertAnswer", CommandType.StoredProcedure, ref error, new SqlParameter("@quesid", quesID), new SqlParameter("@anscontent", anw.AnswerName), new SqlParameter("@iscorrect", anw.IsCorrect)))
                            result = false;
                    }
                }
                else if(anw.AnswerId != "")
                {
                    if (!DAL.Constance.ExecuteQueryNonDataSet("proc_deleteAnswer", CommandType.StoredProcedure, ref error, new SqlParameter("@ansid", anw.AnswerId)))
                        result = false;
                }

            }
            return result;
        }


        public bool DeleteQuestion(string quesId)
        {
            return DAL.Constance.ExecuteQueryNonDataSet("proc_deleteQues", CommandType.StoredProcedure, ref error, new SqlParameter("quesid", quesId));
        }


        public bool DeleteQuestionInExam(string quesId, string examId)
        {
            return DAL.Constance.ExecuteQueryNonDataSet("proc_deleteQuesInExam", CommandType.StoredProcedure, ref error, new SqlParameter("quesid", quesId), new SqlParameter("examid", examId));
        }

        public bool DeleteExam(string examId)
        {
            return DAL.Constance.ExecuteQueryNonDataSet("proc_deleteExam", CommandType.StoredProcedure, ref error, new SqlParameter("examid", examId));
        }

        public bool UpdateExam(string examId, string examName, int timeTest, DateTime dateTest)
        {
            return DAL.Constance.ExecuteQueryNonDataSet("proc_updateExam", CommandType.StoredProcedure, ref error, new SqlParameter("@examid", examId), new SqlParameter("@timetest", timeTest), new SqlParameter("@examname", examName), new SqlParameter("@datetest", dateTest), new SqlParameter("@username", DAL.Username));
        }

        public DataTable ListQuestionToInsForExam(string examID)
        {
            return DAL.Constance.ExecuteQueryDataSet("proc_ListQuestionNotExistInExam",CommandType.StoredProcedure, new SqlParameter("@examid", examID)).Tables[0];
        }

        public bool insertQuesToExam(string questionid, string examid)
        {
            return DAL.Constance.ExecuteQueryNonDataSet("proc_insertExamQues", CommandType.StoredProcedure, ref error, new SqlParameter("@questionid", questionid), new SqlParameter("@examid",examid));
        }


        public DataTable ListClassExam(string examID)
        {
            return DAL.Constance.ExecuteQueryDataSet("proc_ListClassExam", CommandType.StoredProcedure, new SqlParameter("@examid", examID)).Tables[0];
        }

        public DataTable ListClassNotExistInExam(string examID)
        {
            return DAL.Constance.ExecuteQueryDataSet("[proc_ListClassNotExistInExam]", CommandType.StoredProcedure, new SqlParameter("@examid", examID)).Tables[0];
        }

        public bool insertClassToExam(string questionid, string examid)
        {
            return DAL.Constance.ExecuteQueryNonDataSet("proc_insertExamClass", CommandType.StoredProcedure, ref error, new SqlParameter("@classid", questionid), new SqlParameter("@examid", examid));
        }

        public bool deleteClassExam(string examid, string classid)
        {
            return DAL.Constance.ExecuteQueryNonDataSet("proc_deleteClassExam", CommandType.StoredProcedure, ref error, new SqlParameter("@examid", examid), new SqlParameter("@classid",classid));
        }

        public bool insertExam(string examName,int timeTest, DateTime dateTest)
        {
            return DAL.Constance.ExecuteQueryNonDataSet("proc_insertExam", CommandType.StoredProcedure, ref error, new SqlParameter("@timetest", timeTest), new SqlParameter("@exname", examName), new SqlParameter("@datetest", dateTest), new SqlParameter("@username", DAL.Username));
        }

        public DataTable getListTypeQuesOfSubj(string subid)
        {
            DataSet ds;
            if((ds = DAL.Constance.ExecuteQueryDataSet("PROC_getContent", CommandType.StoredProcedure, new SqlParameter("@subid",subid))) == null)
            {
                error = DAL.Constance.ERROR;
                return null;
            }
            return ds.Tables[0];
        }

        public DataTable getListSubject()
        {
            DataSet ds;
            if ((ds = DAL.Constance.ExecuteQueryDataSet("proc_getSubject", CommandType.StoredProcedure, new SqlParameter("@username", DAL.Username))) == null)
            {
                error = DAL.Constance.ERROR;
                return null;
            }
            return ds.Tables[0];
        }
        public bool insertQuestion(string quesContent, string typeid)
        {
            return DAL.Constance.ExecuteQueryNonDataSet("proc_insertQuestion", CommandType.StoredProcedure, ref error, new SqlParameter("@quescontent", quesContent), new SqlParameter("@typeid", typeid));
        }

        public string getIdOfLastQuestion()
        {
            return DAL.Constance.ExecuteQueryScalar("SELECT dbo.autoCreateID('QU')",CommandType.Text, ref error).ToString();
        }
    }
}
