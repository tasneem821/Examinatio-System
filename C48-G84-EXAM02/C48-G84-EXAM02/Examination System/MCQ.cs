using System;
using System.Collections.Generic;
using System.Text;

namespace C48_G84_EXAM02.Examination_System
{
    internal class MCQ : Question
    {

        #region Constructors
        public MCQ()
        {
            
        }
        public MCQ(string _header, string _body, int _mark, List<Answers> _answers, Answers _rightAnswers) :base(_header,_body,_mark,_answers,_rightAnswers)
        {
            
        }
        #endregion
        #region Methods


        public override string ToString()
        {
            return $"Question: \n{Header}\n Choose from following Choices:\n {Body} \n Mark:{Mark}  \n \n "
                + $"Answers:\n {Helper.printAnswers(AnswerList)}";
        }
        #endregion

    }
}
