using System;
using System.Collections.Generic;
using System.Text;

namespace C48_G84_EXAM02.Examination_System
{
    internal abstract class Question
    {

        #region Fields:
        private string header;
        private string body;
        private int mark;

        private Answers[] answerList;
        private Answers rightAnswer;



        #endregion

        #region Properties:
        public string Header { get; set; }
        public string Body { get; set; }

        public int Mark { get; set; }

        public List<Answers> AnswerList { get; set; }
        public Answers RightAnswer { get; set; }

        #endregion

        #region Methods:
        public override abstract string ToString();

        #endregion

        #region Constructor

        protected Question()
        {
            
        }

        protected Question(string _header,string _body,int _mark, List<Answers> _answers, Answers _rightAnswers)
        {
            Header = _header;
            Body = _body;
            Mark = _mark;
            AnswerList = _answers;
            RightAnswer = _rightAnswers;
        }
        #endregion
    }
}


