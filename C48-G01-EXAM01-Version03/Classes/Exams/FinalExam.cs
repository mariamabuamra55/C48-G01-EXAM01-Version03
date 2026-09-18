using System;
using System.Collections.Generic;
using System.Text;
using C48_G01_EXAM01_Version03.Classes.Questions;
using C48_G01_EXAM01_Version03.Enums;

namespace C48_G01_EXAM01_Version03.Classes.Exams
{
    internal class FinalExam : Exam
    {
       

        #region Constructors
        public FinalExam(int examTime, int numberOfQuestions, Question[]? questions)
             : base(examTime, numberOfQuestions, questions, ExamType.Final)
        {

        }
        #endregion  


        #region Methods
        public override void ShowExam()
        {
            RunExam();
        }

        #endregion
    }
}
