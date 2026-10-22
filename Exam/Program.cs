namespace Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject(1, "C# Programming");

            subject.CreateExam();         

            Console.WriteLine();
            Console.WriteLine(subject.Exam);

            subject.Exam.Show();
        }
    }
}
