using System;
using System.Collections.Generic;
using System.Text;

namespace C48_G84_EXAM02.Examination_System
{
    internal abstract class Exam
    {
        #region Fields:
        private int examId;
        private string examTime;
        private int numberOfQuestions;
        private string examSubject;
        private List<Question> questions;
        private int totalMarks;
        protected string timeTaken;
        private int rightTotalMarks;


        #endregion

        #region Properties:
        public int ExamId { get; set; }
        public string ExamTime { get; set; }
        public int NumberOfQeustions { get; set; }
        public string ExamSubject { get; set; }
        public List<Question> Questions { get; set; }
        public int TotalMarks {  get; set; }
        public int RightTotalMarks { get; set; }
        public string TimeTaken { get; set; }
        #endregion

        #region Method:
        public abstract void ShowExam();
        public  void StartExam()
        {
            Console.WriteLine("Are you want to start the Exam ? (Y -> Yes) (N -> No)");
            string startExam = "";
            do
            {
                Console.WriteLine("make sure you enter the letter and upper case");
                startExam = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(startExam)&&(startExam=="Y"||startExam=="N"));

            if (startExam == "Y")
            {
                ShowExam();

            }

            else
            {
                Console.WriteLine("exam is not started");
                return;
            }
        }

        public abstract void ShowResults(Dictionary<int, bool> results);
        public void CalculateTotalMarks(Dictionary<int,bool>results,Dictionary<int,int>Marks)
        {
            foreach (var item in results)
            {
                TotalMarks += Marks[item.Key];

                if (item.Value == true)
                {
                    RightTotalMarks += Marks[item.Key];
                } 
            }
        }
        #endregion

        #region constructor:
        protected Exam()
        {
            
        }
        protected Exam(int _examId,string _examTime,int _numberOfQuestions,string _subject,List<Question> _questions)
        {
           ExamId = _examId;
            ExamTime = _examTime;
            NumberOfQeustions = _numberOfQuestions;
            ExamSubject = _subject;
            Questions = _questions;
        }
        #endregion
    }
}
