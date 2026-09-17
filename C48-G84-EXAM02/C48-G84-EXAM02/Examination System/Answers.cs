using System;
using System.Collections.Generic;
using System.Text;

namespace C48_G84_EXAM02.Examination_System
{
    internal class Answers
    {

            #region Fields:
            private int answerId;
            private string answerText;

        #endregion

        #region Constructors:
        public Answers()
        {
            
        }

        public Answers(int _answerId,string _answerText)
        {
            AnswerId = _answerId;
            AnswerText = _answerText;
        }
        #endregion
        #region Properties:
        public int AnswerId { get; set; }

            public string AnswerText { get; set; }
            #endregion

            #region Methods:
            public override string ToString()
            {
                return $"{AnswerId}:{AnswerText}";
            }
            #endregion

}
}
