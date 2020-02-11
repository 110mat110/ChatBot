using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudBackgroundConsole {
    class Background {

        public List<string> UniqueKeyWods { get; private set; } 
        public List<QuestionAnswer> QA { get; private set; }

        public Background() {
            QA = new List<QuestionAnswer>();
            UniqueKeyWods = new List<string>();
        }

        public void AddQuestionIntoQAList(QuestionAnswer qa) {
            QA.Add(qa);
            foreach(string key in qa.Keys) {
                if (!UniqueKeyWods.Contains(key))
                    UniqueKeyWods.Add(key);
            }
        }

        public string GetAnswerFromQuestion(string Question) {
            Question = Question.ToLower().Replace("?", string.Empty);
            Question = Question.Replace(".", string.Empty);
            Question = Question.Replace(",", string.Empty);
            var words = Question.Split(' ');

            List<string> keys = new List<string>();
            foreach (string word in words) 
                if (UniqueKeyWods.Contains(word)) {
                    keys.Add(word);
                }
                    

            QuestionAnswer answer = QA[0];
            float match = 0;
            foreach (QuestionAnswer qa in QA) {
                if (qa.KeywordsMatch(keys.ToArray()) >= match) {
                    match = qa.KeywordsMatch(keys.ToArray());
                    answer = qa;
                }
            }
            Console.WriteLine("Match: " + match * 100 + "%");
            if (match > 0.40f)
                return answer.Answer;
            else return ("We are sorry, but we did not find qualified answer to your question. Please, try again");
        }
    }
}
