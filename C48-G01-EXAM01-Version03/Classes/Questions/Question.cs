using System;
using System.Collections.Generic;
using System.Text;

namespace C48_G01_EXAM01_Version03.Classes.Questions
{
    internal abstract class Question
    {
        #region Properties
        public string? Header { get; set; }
        public string? Body { get; set; }
        public double Mark { get; set; }

        public Answer[]? Answers { get; set; }
        public Answer? CorrectAnswer { get; set; }
        public Answer? StudentAnswer { get; set; }
        #endregion
    }
}
