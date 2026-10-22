using System;
using System.Collections.Generic;
using System.Text;

namespace Exam
{
    // (9) الامتحان النهائي: يعرض الأسئلة + الإجابات + الدرجة (Grade)
    class FinalExam : Exam
    {
        public FinalExam(int time, int numberOfQuestions, Subject subject)
            : base(time, numberOfQuestions, subject)
        {
        }

        public override void Show()
        {
            Console.WriteLine($"\n===== Final Exam ({Subject.SubjectName}) - {Time} min =====");
            int[] userAnswers = AskQuestions();

            int grade = 0;
            int total = 0;

            Console.WriteLine("\n===== Exam Result =====");
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Question q = Questions[i];
                total += q.Mark;

                // الإجابة اللي اختارها اليوزر
                Answer chosen = Array.Find(q.AnswerList, a => a.AnswerId == userAnswers[i]);

                Console.WriteLine($"\nQ{i + 1}: {q.Header} - {q.Body}");
                Console.WriteLine($"   Your answer: {chosen.AnswerText}");

                if (chosen.AnswerId == q.RightAnswer.AnswerId)
                {
                    grade += q.Mark;
                    Console.WriteLine("   Correct");
                }
                else
                {
                    Console.WriteLine("   Wrong");
                }
            }

            Console.WriteLine($"\nGrade: {grade} / {total}");
        }
    }
}
