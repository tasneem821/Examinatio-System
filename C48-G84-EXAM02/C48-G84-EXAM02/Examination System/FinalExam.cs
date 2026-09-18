using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace C48_G84_EXAM02.Examination_System
{
    internal class FinalExam : Exam
    {
        public FinalExam()
        {
        }

        public FinalExam(int _examId, string _examTime, int _numberOfQuestions, string _subject, List<Question> _questions) : base(_examId, _examTime, _numberOfQuestions, _subject, _questions)
        {
        }

        public override void ShowExam()
        {
            Console.Clear();

            Stopwatch sw = Stopwatch.StartNew();
            Console.WriteLine("==Final Exam ==");
            Dictionary<int, bool> results = new Dictionary<int, bool>();
            Dictionary<int, int> Marks = new Dictionary<int, int>();

            foreach (var item in Questions)
            {
                Console.Clear();

                Console.WriteLine(item);
                Console.WriteLine("Enter Your Answer ID:");
                bool rightAnswerParse = false;
                int answerId;
                do
                {
                    rightAnswerParse = int.TryParse(Console.ReadLine(), out answerId);
                }
                while (!rightAnswerParse);
                string answerText = "";
                foreach (var answer in item.AnswerList)
                {
                    if (answer.AnswerId == answerId)
                    {
                        answerText = answer.AnswerText;
                    }
                }
                item.UserAnswer = new Answers(answerId, answerText);
                results.Add(answerId, item.CompareAnswers(answerId));
                Marks.Add(answerId, item.Mark);

            }

            sw.Stop();
            TimeTaken = sw.ToString();
            CalculateTotalMarks(results, Marks);
            ShowResults(results);
        }

        public override void ShowResults(Dictionary<int, bool> results)
        {
            Console.Clear();

            Console.WriteLine($"Final Exam Results");
            foreach (var item in Questions)
            {
                Console.WriteLine($"{item.Header} : {item.Body}");
                Console.WriteLine($"Your Answer => {item.UserAnswer.AnswerText}");
                Console.WriteLine($"Correct Answer => {item.RightAnswer.AnswerText}");

            }

            Console.WriteLine($"Your Grade is {RightTotalMarks} from {TotalMarks}");

            Console.WriteLine($"Time = {TimeTaken}");

            Console.WriteLine("Thank You");
        }
    }
}
