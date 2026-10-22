using System;
using System.Collections.Generic;
using System.Text;

namespace Exam
{
    class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string header, string body, int mark, bool correctIsTrue)
            : base(header, body, mark,
                   new Answer[] { new Answer(1, "True"), new Answer(2, "False") })
        {
            RightAnswer = correctIsTrue ? AnswerList[0] : AnswerList[1];
        }

        public override void Display()
        {
            Console.WriteLine("--- True or False Question ---");
            base.Display(); 
        }
    }
}