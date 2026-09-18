using C48_G01_EXAM01_Version03.Classes.Exams;
using System;
using System.Collections.Generic;
using System.Text;
using C48_G01_EXAM01_Version03.Classes.Questions;
using C48_G01_EXAM01_Version03.Enums;


namespace C48_G01_EXAM01_Version03.Classes.Subjects
{
    internal class Subject
    {
        #region Properties
        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }
        public Exam? Exam { get; set; }
        #endregion

        #region Constructors
        public Subject(int subjectId, string? subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }
        #endregion
    }
}
