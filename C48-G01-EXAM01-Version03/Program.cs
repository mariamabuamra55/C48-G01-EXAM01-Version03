using C48_G01_EXAM01_Version03.Classes.Subjects;

namespace C48_G01_EXAM01_Version03
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Subject subject = new Subject(1, "OOP");
            subject.CreateExam();
            Console.Clear();

            Console.WriteLine("Do You Want To Start Exam (Y | N)");
            string? answer = Console.ReadLine();

            if (answer?.Trim().ToUpper() == "Y")
            {
                subject.Exam?.ShowExam();
            }
            else
            {
                Console.WriteLine("Exam cancelled");
            }
        }
    }
}
