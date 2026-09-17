using C48_G84_EXAM02.Examination_System;

namespace C48_G84_EXAM02
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region testing Classes:
            #region Answers
            //Answers
            //Console.WriteLine("Enter Your Answer Id:");
            //int answerId;
            //bool answerIdParse = false;
            //do
            //{
            //    Console.WriteLine("make sure its not null and from 1 to 4");
            //    answerIdParse = int.TryParse(Console.ReadLine(), out answerId);
            //}
            //while (!answerIdParse && (answerId >= 1 && answerId <= 4));

            //Console.WriteLine("Enter Your Answer Text:");
            //string answerString;
            //do
            //{
            //    Console.WriteLine("make sure its not null or white space only");
            //    answerString = Console.ReadLine();
            //}
            //while (string.IsNullOrWhiteSpace(answerString));

            //Answers answer = new Answers(answerId, answerString);
            //Console.WriteLine(answer);
            #endregion
            #region Question:
            Console.WriteLine("Enter Question Header:");
            string questionHeader;

            do
            {
                Console.WriteLine("make sure its not null or white space only");
                questionHeader = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(questionHeader));

            Console.WriteLine("Enter Question Body:");
            string questionBody;

            do
            {
                Console.WriteLine("make sure its not null or white space only");
                questionBody = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(questionBody));

            Console.WriteLine("Enter Question Mark:");
            int mark;
            bool markParse = false;
            do
            {
                Console.WriteLine("make sure its greader than or equal 0 and smaller than and equal 100");
                markParse = int.TryParse(Console.ReadLine(),out mark);
            }
            while (!markParse);
            //Console.WriteLine($"Mark:{mark}");
            Console.WriteLine("Enter Question Answers:");
            List<Answers> answers = new();
            int counter = 0;
            while (counter<4)
            {
                Console.WriteLine("Enter Your Answer Id:");
                int answerId;
                bool answerIdParse = false;
                do
                {
                    Console.WriteLine("make sure its not null and from 1 to 4");
                    answerIdParse = int.TryParse(Console.ReadLine(), out answerId);
                }
                while (!answerIdParse && (answerId >= 1 && answerId <= 4));

                Console.WriteLine("Enter Your Answer Text:");
                string answerString;
                do
                {
                    Console.WriteLine("make sure its not null or white space only");
                    answerString = Console.ReadLine();
                }
                while (string.IsNullOrWhiteSpace(answerString));

                Answers answer = new Answers(answerId, answerString);
                answers.Add(answer);
                counter++;
            }
            Console.WriteLine("Enter Right Answer:");

            Console.WriteLine("Enter Your Answer Id:");
            int rightAnswerId;
            bool rightAnswerIdParse = false;
            do
            {
                Console.WriteLine("make sure its not null and from 1 to 4");
                rightAnswerIdParse = int.TryParse(Console.ReadLine(), out rightAnswerId);
            }
            while (!rightAnswerIdParse && (rightAnswerId >= 1 && rightAnswerId <= 4));

            string rightAnswerText = "";
            foreach (var item in answers)
            {
                if(item.AnswerId == rightAnswerId)
                {
                    rightAnswerText = item.AnswerText;
                }
            }

            Answers rightAnswer = new Answers(rightAnswerId, rightAnswerText);
            Question question = new MCQ(questionHeader, questionBody, mark, answers, rightAnswer);
            Console.WriteLine(question);
            #endregion
            #endregion
        }
    }
}
