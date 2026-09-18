using System;
using System.Collections.Generic;
using System.Text;

namespace C48_G84_EXAM02.Examination_System
{
    internal class Subject
    {
        #region Fields:
        private int subjectId;
        private string subjectName;
        private Exam? subjectExam;


        #endregion

        #region Properties:
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam? SubjectExam { get; set; }
        #endregion

        #region Method
        public void ChooseExamType()
        {
            Console.WriteLine($"Enter Type of Exam (1 for Practical) and (2 for Final)");
            int ExamNumber;
            bool examParse = false;

            do
            {
                examParse = int.TryParse(Console.ReadLine(), out ExamNumber);
            }
            while (!examParse &&(ExamNumber==1 || ExamNumber==2));

            if (ExamNumber == 1)
            {
                Console.Clear();
                CreatePracticalExam();
            }
            else
            {
                Console.Clear();

                CreateFinialExam();
            }
        }

        public void CreatePracticalExam() {
            Console.Clear();

            Console.WriteLine("====Creating Practical Exam====");
            Console.WriteLine("Enter ExamId:");
            int ExamId;
            bool examParse = false;
            do
            {
                examParse = int.TryParse(Console.ReadLine(), out ExamId);
            }
            while (!examParse);

            Console.WriteLine("Enter Number of Question:");
            int NumberOfQuestions;
            bool numParse = false;
            do
            {
                numParse = int.TryParse(Console.ReadLine(), out NumberOfQuestions);
            }
            while (!numParse);
            Console.WriteLine("Enter Exam Time:");
            string ExamTime = "";
            do
            {
                ExamTime = Console.ReadLine();
                Console.WriteLine("make sure exam time is not null");


            }
            while (string.IsNullOrEmpty(ExamTime));
            Console.WriteLine("Enter Exam Subject Name:");
            string ExamSubject = "";
            do
            {
                ExamSubject = Console.ReadLine();
                Console.WriteLine("make sure exam subject is not null");


            }
            while (string.IsNullOrEmpty(ExamSubject));
            List<Question> questions = new();

            for(int i = 0; i < NumberOfQuestions; i++)
            {
                Question question = EnterMcqQuestions();
                questions.Add(question);
            }
            Exam PracticalExam = new PracticalExam(ExamId, ExamTime, NumberOfQuestions, subjectName, questions);
            PracticalExam.StartExam();
        }
        public void CreateFinialExam() {
            Console.Clear();

            Console.WriteLine("====Creating Finial Exam====");
            Console.WriteLine("Enter ExamId:");
            int ExamId;
            bool examParse = false;
            do
            {
                examParse = int.TryParse(Console.ReadLine(), out ExamId);
            }
            while (!examParse);

            Console.WriteLine("Enter Number of Question:");
            int NumberOfQuestions;
            bool numParse = false;
            do
            {
                numParse = int.TryParse(Console.ReadLine(), out NumberOfQuestions);
            }
            while (!numParse);
            Console.WriteLine("Enter Exam Time:");
            string ExamTime = "";
            do
            {
                ExamTime = Console.ReadLine();
                Console.WriteLine("make sure exam time is not null");


            }
            while (string.IsNullOrEmpty(ExamTime));
            Console.WriteLine("Enter Exam Subject Name:");
            string ExamSubject = "";
            do
            {
                ExamSubject = Console.ReadLine();
                Console.WriteLine("make sure exam subject is not null");


            }
            while (string.IsNullOrEmpty(ExamSubject));
            List<Question> questions = new();

            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.WriteLine("Choose the Question you want to make");
                Console.WriteLine("1 for MCQ");
                Console.WriteLine("2 for True or False");

                int examNum;
                bool examNumParse = false;

                do
                {
                    examNumParse = int.TryParse(Console.ReadLine(), out examNum);
                }
                while (!examNumParse);
                if (examNum == 1)
                {
                    Question question = EnterMcqQuestions();
                    questions.Add(question);
                }
                else if (examNum == 2)
                {
                    Question question = EnterTrueOrFalseQuestions();
                    questions.Add(question);
                }
          
            }
            Exam FinialExam = new FinalExam(ExamId, ExamTime, NumberOfQuestions, subjectName, questions);
            FinialExam.StartExam();
        }
        public Question EnterMcqQuestions() {
            Console.Clear();

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
                markParse = int.TryParse(Console.ReadLine(), out mark);
            }
            while (!markParse);
            //Console.WriteLine($"Mark:{mark}");
            Console.WriteLine("Enter Question Answers:");
            List<Answers> answers = new();
            int counter = 0;
            while (counter < 4)
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
                if (item.AnswerId == rightAnswerId)
                {
                    rightAnswerText = item.AnswerText;
                }
            }

            Answers rightAnswer = new Answers(rightAnswerId, rightAnswerText);
            Question question = new MCQ(questionHeader, questionBody, mark, answers, rightAnswer);
            return question;
        }

        public Question EnterTrueOrFalseQuestions() {
            Console.Clear();

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
                markParse = int.TryParse(Console.ReadLine(), out mark);
            }
            while (!markParse);
            //Console.WriteLine($"Mark:{mark}");
            Answers answerTrue = new Answers(1, "True");
            Answers answerFalse = new Answers(2, "False");
            List<Answers> answers = new();
            answers.Add(answerTrue);
            answers.Add(answerFalse);
            Console.WriteLine("Enter Right Answer:");

            Console.WriteLine("Enter Your Answer Id:");
            int rightAnswerId;
            bool rightAnswerIdParse = false;
            do
            {
                Console.WriteLine("make sure its not null and 1 for True and 2 For False");
                rightAnswerIdParse = int.TryParse(Console.ReadLine(), out rightAnswerId);
            }
            while (!rightAnswerIdParse && (rightAnswerId >= 1 && rightAnswerId <= 2));

            string rightAnswerText = "";
            foreach (var item in answers)
            {
                if (item.AnswerId == rightAnswerId)
                {
                    rightAnswerText = item.AnswerText;
                }
            }

            Answers rightAnswer = new Answers(rightAnswerId, rightAnswerText);
            Question question = new TrueOrFalse(questionHeader, questionBody, mark, answers, rightAnswer);
            return question;
        }
        #endregion

        #region Constructor
        public Subject()
        {
            
        }
        public Subject(int _subjectId,string _subjectName,Exam? _subjectExam)
        {
         SubjectId = _subjectId;
         SubjectName = _subjectName;
         SubjectExam = _subjectExam;

        }
        #endregion
    }
}
