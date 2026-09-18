using System;
using System.Collections.Generic;
using System.Text;

namespace C48_G01_EXAM01_Version03.Classes.Questions
{
    internal class TrueFalseQuestion: Question
    {
        #region Properties
        public override string TypeLabel => " True OR False Question";
        #endregion
        #region Constructors
        public TrueFalseQuestion(string? header, string? body, double mark, Answer[]? answers, Answer? correctAnswer) : base(header, body, mark, answers, correctAnswer, Enums.QuestionType.TrueFalse)
        {
        }
        #endregion
    }
}
