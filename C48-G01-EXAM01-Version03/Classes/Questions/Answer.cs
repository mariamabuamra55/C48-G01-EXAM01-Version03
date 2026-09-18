using System;
using System.Collections.Generic;
using System.Text;

namespace C48_G01_EXAM01_Version03.Classes.Questions
{
    internal class Answer
    {
        #region Properties
        public int AnswerId { get; set; }
        public string? AnswerText { get; set; }

        #endregion

        #region Constructors
        public Answer(int answerId, string? answerText)
        {
            AnswerId = answerId;
            AnswerText = answerText;
        }
        #endregion
    }
}
