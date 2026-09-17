using System;
using System.Collections.Generic;
using System.Text;

namespace C48_G84_EXAM02.Examination_System
{
    internal static class Helper
    {
        public static string printAnswers(List<Answers> answers)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in answers)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
       
    }
}
