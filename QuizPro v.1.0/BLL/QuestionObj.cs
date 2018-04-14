using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPro_v._1._0.Controller
{
    // đối tượng câu hỏi
    public class QuestionObj
    {
        string quesName;
        string quesId;

        public string QuesName { get => quesName; set => quesName = value; }
        public string QuesId { get => quesId; set => quesId = value; }

        public QuestionObj(string quesId,string quesName)
        {
            this.quesName = quesName;
            this.quesId = quesId;
        }
    }
}
