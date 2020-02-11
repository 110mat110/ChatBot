using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudBackgroundConsole {
    [Serializable]
    public class QuestionAnswer {
        public string Question { get; set; }
        public string Answer { get; set; }
        public string[] Keys { get; set; }

        public QuestionAnswer() {
        }

        public float KeywordsMatch(string[] keywords) {
            int match = 0;
            foreach(string key in keywords) {
                if (Keys.Contains(key)) match++;
            }

            return (float)match / (float)Keys.Length;
        }
    }
}
