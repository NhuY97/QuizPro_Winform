using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPro_v._1._0.Controller
{
    // đối tượng phương án 
    public class AnswerObj
    {
        string answerId;
        string answerName;
        bool isCorrect;

        public string AnswerId { get => answerId; set => answerId = value; }
        public string AnswerName { get => answerName; set => answerName = value; }
        public bool IsCorrect { get => isCorrect; set => isCorrect = value; }

        public AnswerObj(string answerId,string answerName,bool isCorrect)
        {
            this.answerId = answerId;
            this.answerName = answerName;
            this.isCorrect = isCorrect;
        }
    }
}
