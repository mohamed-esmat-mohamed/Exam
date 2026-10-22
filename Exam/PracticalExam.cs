using System;
using System.Collections.Generic;
using System.Text;

namespace Exam
{
    class PracticalExam : Exam
    {
        public PracticalExam(int time, int numberOfQuestions, Subject subject)
            : base(time, numberOfQuestions, subject)
        {
        }

        public override void Show()
        {
            Console.WriteLine($"\n===== Practical Exam ({Subject.SubjectName}) - {Time} min =====");
            AskQuestions();
            Console.WriteLine("\n===== Right Answers =====");
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.WriteLine($"Q{i + 1}: {Questions[i].Header}");
                Console.WriteLine($"   Right answer: {Questions[i].RightAnswer}");
            }
        }
    }
}
