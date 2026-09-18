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

        #region Methods
        private static int ReadIntInRange(int min, int max)
        {
            while (true)
            {
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int value) && value >= min && value <= max)
                    return value;

                Console.Write($"Please enter a number between {min} and {max}: ");
            }
        }
        private static double ReadPositiveDoubleMark()
        {
            while (true)
            {
                string? input = Console.ReadLine();
                if (double.TryParse(input, out double value) && value > 0)
                    return value;

                Console.Write("Please enter a valid positive number: ");
            }
        }
        private static int ReadPositiveIntNumberOFQuestions()
        {
            while (true)
            {
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int value) && value > 0)
                    return value;

                Console.Write("Please enter a valid positive number: ");
            }
        }

        private static MCQQuestion CreateMCQQuestion()
        {
            Console.Write("Please enter the question body:");
            string? body = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Please enter the question mark: ");
            double mark = ReadPositiveDoubleMark();

            Console.WriteLine();
            Console.Write("Choices of Question:");
            Answer[] answers = new Answer[4];
            for (int i = 0; i < 4; i++)
            {
                Console.Write($"Please enter choice number {i + 1}:");
                string? text = Console.ReadLine();
                answers[i] = new Answer(i + 1, text);
            }

            Console.Write("Please enter the ID of the correct answer (1 to 4): ");
            int correctId = ReadIntInRange(1, 4);
            Answer correctAnswer = answers[correctId - 1];

            return new MCQQuestion(null, body, mark, answers, correctAnswer);
        }
        private static TrueFalseQuestion CreateTrueFalseQuestion()
        {
            Console.Write("Please enter the question body: ");
            string? body = Console.ReadLine();

            Console.Write("Please enter the question mark: ");
            double mark = ReadPositiveDoubleMark();

            Answer[] answers = new[]
            {
              new Answer(1, "True"),
              new Answer(2, "False")
             };

            Console.WriteLine("Is the correct answer True or False? (1 for True, 2 for False):");
            int correctId = ReadIntInRange(1, 2);
            Answer correctAnswer = answers[correctId - 1];

            return new TrueFalseQuestion(null, body, mark, answers, correctAnswer);
        }

        private static Question CreateQuestion(ExamType examType, int index)
        {
            Console.WriteLine($"Enter details for question {index}:");

            if (examType == ExamType.Practical)
                return CreateMCQQuestion();

            Console.Write("Choose question type: 1 for MCQ, 2 for True/False: ");
            string? choice = Console.ReadLine();

            return choice == "2" ? CreateTrueFalseQuestion() : CreateMCQQuestion();
        }

        public void CreateExam()
        {
            Console.Write("Enter the type of exam (1 for Practical, 2 for Final): ");
            int examTypeChoice = int.Parse(Console.ReadLine() ?? "2");
            ExamType examType = examTypeChoice == 1 ? ExamType.Practical : ExamType.Final;

            Console.Write("Please enter the time for the exam (30 to 180 minutes): ");
            int examTime = ReadIntInRange(30, 180);

            Console.Write("Please enter the number of questions: ");
            int numberOfQuestions = ReadPositiveIntNumberOFQuestions();

            Console.Clear();

            Question[] questions = new Question[numberOfQuestions];
            for (int i = 0; i < numberOfQuestions; i++)
            {
                questions[i] = CreateQuestion(examType, i + 1);
            }

            Exam = examType == ExamType.Practical
                ? new PracticalExam(examTime, numberOfQuestions, questions)
                : new FinalExam(examTime, numberOfQuestions, questions);
        }
       
        #endregion

    }
}
