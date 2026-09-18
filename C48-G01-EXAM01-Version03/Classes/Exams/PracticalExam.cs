using C48_G01_EXAM01_Version03.Classes.Questions;
using System;
using System.Collections.Generic;
using System.Text;
using C48_G01_EXAM01_Version03.Enums;

namespace C48_G01_EXAM01_Version03.Classes.Exams
{
    internal class PracticalExam:Exam
    {

        #region Constructors
        public PracticalExam(int examTime, int numberOfQuestions, Question[]? questions)
            : base(examTime, numberOfQuestions, questions ?? Array.Empty<Question>(), ExamType.Practical)
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
