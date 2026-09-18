using C48_G84_EXAM02.Examination_System;

namespace C48_G84_EXAM02
{
    internal class Program
    {
        static void Main(string[] args)
        {



            #region RunningCode:
            Console.WriteLine("====Examination System====");
            int SubjectId;
            bool subjectIdParse = false;
            Console.WriteLine("enter Sujbect Id");
            do
            {
                subjectIdParse = int.TryParse(Console.ReadLine(), out SubjectId);  
            }
            while (!subjectIdParse);

            string SubjectName="";
            Console.WriteLine("enter subject Name");
            do
            {
                SubjectName = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(SubjectName));

            Subject subject = new Subject(SubjectId,SubjectName,null);
            Console.Clear();
            subject.ChooseExamType();
            #endregion
        }
    }
}
