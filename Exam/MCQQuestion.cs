using System;
using System.Collections.Generic;
using System.Text;

namespace Exam
{
    class MCQQuestion : Question
    {
        public MCQQuestion(string header, string body, int mark, Answer[] answers, int rightAnswerId)
            : base(header, body, mark, answers)
        {
            RightAnswer = Array.Find(answers, a => a.AnswerId == rightAnswerId);
        }

        public override void Display()
        {
            Console.WriteLine("--- MCQ Question ---");
            base.Display();
        }
    }
}
