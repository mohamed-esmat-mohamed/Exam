using System;
using System.Collections.Generic;
using System.Text;

namespace Exam
{
    abstract class Question : ICloneable, IComparable<Question>
    {
        public string Header { get; set; }
        public string Body { get; set; } 
        public int Mark { get; set; }   
        public Answer[] AnswerList { get; set; }  
        public Answer RightAnswer { get; set; }   
        protected Question() : this("", "", 0)
        {
        }

        protected Question(string header, string body, int mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = new Answer[0];
        }

        protected Question(string header, string body, int mark, Answer[] answerList)
            : this(header, body, mark)
        {
            AnswerList = answerList;
        }
        public virtual void Display()
        {
            Console.WriteLine($"[{Header}]  (Mark: {Mark})");
            Console.WriteLine(Body);
            foreach (Answer a in AnswerList)
            {
                Console.WriteLine("   " + a);
            }
        }

        public object Clone()
        {
            Question copy = (Question)MemberwiseClone();
            copy.AnswerList = new Answer[AnswerList.Length];
            for (int i = 0; i < AnswerList.Length; i++)
            {
                copy.AnswerList[i] = (Answer)AnswerList[i].Clone();
            }
            if (RightAnswer != null)
            {
                copy.RightAnswer = Array.Find(copy.AnswerList, a => a.AnswerId == RightAnswer.AnswerId);
            }
            return copy;
        }
        public int CompareTo(Question other)
        {
            if (other == null) return 1;
            return Mark.CompareTo(other.Mark);
        }

        public override string ToString()
        {
            return $"{GetType().Name} - {Header} - Mark: {Mark}";
        }
    }
}