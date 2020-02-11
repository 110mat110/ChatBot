using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudBackgroundConsole {
    class Program {
        static void Main(string[] args) {
            var i = 2;
            i++;
            ++i;
            Console.WriteLine(i);
            var input = File.ReadAllLines(@"Content.json");
            Background background = new Background();

            JsonSerializerSettings settings = new JsonSerializerSettings() {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            foreach (string s in input) {
                background.AddQuestionIntoQAList(JsonConvert.DeserializeObject<QuestionAnswer>(s, settings));

            }


            Console.WriteLine("There are " + background.QA.Count + " Questions in database");
            Console.WriteLine("Now you can ask");
            while (true) {
                var question = Console.ReadLine();
                Console.WriteLine(background.GetAnswerFromQuestion(question));
            }

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
