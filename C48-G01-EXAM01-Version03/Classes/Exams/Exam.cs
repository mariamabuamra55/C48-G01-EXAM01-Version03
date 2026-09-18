using System;
using System.Collections.Generic;
using System.Text;
using C48_G01_EXAM01_Version03.Classes.Questions;
using C48_G01_EXAM01_Version03.Enums;

namespace C48_G01_EXAM01_Version03.Classes.Exams
{
    internal abstract class Exam
    {

        #region fields
        private const double minExamTime = 30;
        private const double maxExamTime = 180;
        private int examTime;
        #endregion

        #region Properties
         public int ExamTime
         {
            get { return examTime; }
            set
            {
                if (value < minExamTime || value > maxExamTime)
                {
                    throw new ArgumentOutOfRangeException($"Exam time must be between {minExamTime} and {maxExamTime} minutes please Enter right time");
                  
                }
                examTime = value;
            }
          }
         public int NumberOfQuestions { get; set; }
         public Question[] ?Questions { get; set; }
         public ExamType ExamType { get; set; }

        #endregion

        #region Constuctors
        public Exam(int examTime, int numberOfQuestions, Question[] questions, ExamType examType)
        {
            ExamTime = examTime;
            NumberOfQuestions = numberOfQuestions;
            Questions = questions;
            ExamType = examType;
        }
        #endregion

        #region Methods
        #endregion

    }
}
