using System;
using System.Collections.Generic;
using System.Text;

namespace Exam
{

    abstract class Exam : ICloneable, IComparable<Exam>
    {
        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }
        public Question[] Questions { get; set; }
        public Subject Subject { get; set; }    
        protected Exam(int time, int numberOfQuestions)
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
            Questions = new Question[numberOfQuestions];
        }

        protected Exam(int time, int numberOfQuestions, Subject subject)
            : this(time, numberOfQuestions)
        {
            Subject = subject;
        }
        public abstract void Show();
        protected int[] AskQuestions()
        {
            int[] userAnswers = new int[NumberOfQuestions];
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Question {i + 1}:");
                Questions[i].Display();
                userAnswers[i] = Input.ReadInt("Your answer (number): ", 1, Questions[i].AnswerList.Length);
            }
            return userAnswers;
        }

        public object Clone()
        {
            Exam copy = (Exam)MemberwiseClone();
            copy.Questions = new Question[Questions.Length];
            for (int i = 0; i < Questions.Length; i++)
            {
                copy.Questions[i] = (Question)Questions[i].Clone();
            }
            return copy;
        }
        public int CompareTo(Exam other)
        {
            if (other == null) return 1;
            return NumberOfQuestions.CompareTo(other.NumberOfQuestions);
        }

        public override string ToString()
        {
            string subjectName = Subject != null ? Subject.SubjectName : "No Subject";
            return $"{GetType().Name} | Subject: {subjectName} | Time: {Time} min | Questions: {NumberOfQuestions}";
        }
    }
}

