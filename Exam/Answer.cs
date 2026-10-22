using System;
using System.Collections.Generic;
using System.Text;

namespace Exam
{
    class Answer : ICloneable
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        public Answer() : this(0, "")
        {
        }

        public Answer(int answerId, string answerText)
        {
            AnswerId = answerId;
            AnswerText = answerText;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public override string ToString()
        {
            return $"{AnswerId}. {AnswerText}";
        }
    }
}
