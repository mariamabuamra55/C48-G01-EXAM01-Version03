using System;
using System.Collections.Generic;
using System.Text;
using C48_G01_EXAM01_Version03.Classes.Questions;
using C48_G01_EXAM01_Version03.Enums;
using System.Diagnostics;

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
        public abstract void ShowExam();

        protected void RunExam()
        {

            Console.WriteLine($"Running {ExamType} exam for {ExamTime} minutes");
            var stopwatch = Stopwatch.StartNew();

            if (Questions != null)
            {
                for (int i = 0; i < Questions.Length; i++)
                {
                    Console.Clear();
                    Question question = Questions[i];

                    Console.WriteLine($"Question {i + 1}: {question.Body}");
                    Console.WriteLine($"{question.TypeLabel} : Mark {question.Mark}");

                    if (question.Answers != null)
                    {
                        for (int j = 0; j < question.Answers.Length; j++)
                        {
                            Console.WriteLine($"{j + 1}. {question.Answers[j].AnswerText}");
                        }
                    }

                    Console.Write("enter your answer: ");
                    int maxChoice = question.Answers?.Length ?? 0;
                    int answerId = ReadAnswerId(maxChoice);
                    question.StudentAnswer = question.Answers?[answerId - 1];
                }
            }

            stopwatch.Stop();
            ShowResults(stopwatch.Elapsed);
        }
        private void ShowResults(TimeSpan elapsedTime)
        {
            Console.Clear();
            Console.WriteLine($"{ExamType} Exam Results:");
            double grade = 0;
            double total = 0;


            if (Questions != null)
            {
                foreach (var question in Questions)
                {
                    Console.WriteLine($"Question: {question.Body}");
                    Console.WriteLine($"Your Answer => {question.StudentAnswer?.AnswerText}");
                    Console.WriteLine($"Correct Answer => {question.CorrectAnswer?.AnswerText}");
                    Console.WriteLine();

                    total += question.Mark;
                    if (question.StudentAnswer?.AnswerId == question.CorrectAnswer?.AnswerId)
                        grade += question.Mark;
                }
            }

            Console.WriteLine($"Your Grade is {grade} from {total}");
            Console.WriteLine($"Time you take = {elapsedTime}");
            Console.WriteLine("Thank you");
        }

        private static int ReadAnswerId(int maxChoice)
        {
           while (true)
            {
                string? input = Console.ReadLine();
                if (int.TryParse(input, out var value) && value >= 1 && value <= maxChoice)
                    return value;

                Console.WriteLine($"Please enter a number between 1 and {maxChoice}.");
            }

        }

        public override string ToString()
        {
            return $"Exam Time: {ExamTime}\n Number Of Questions: {NumberOfQuestions}";
        }

        #endregion

    }
}
