using System;
using System.Collections.Generic;
using System.Text;
using C48_G01_EXAM01_Version03.Enums;

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
        public QuestionType QuestionType { get; set; }
        public abstract string TypeLabel { get; }

        #endregion

        #region Constructors
        public Question(string? header, string? body, double mark, QuestionType questionType)
        {
            Header = header;
            Body = body;
            Mark = mark;
            QuestionType = questionType;
        }

        public Question(string? header, string? body, double mark, Answer[]? answers, Answer? correctAnswer, QuestionType questionType) : this(header, body, mark, questionType)
        {
            Answers = answers;
            CorrectAnswer = correctAnswer;
        }

        #endregion



    }
}
