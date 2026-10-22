using System;
using System.Collections.Generic;
using System.Text;

namespace Exam
{
    class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; set; }  

        public Subject() : this(0, "")
        {
        }

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        public void CreateExam()
        {
            Console.WriteLine($"=== Create exam for subject: {SubjectName} ===");
            int type = Input.ReadInt("Choose exam type (1 = Final, 2 = Practical): ", 1, 2);
            int time = Input.ReadInt("Exam time (minutes): ", 1, 600);
            int count = Input.ReadInt("Number of questions: ", 1, 50);

            if (type == 1)
                Exam = new FinalExam(time, count, this);    
            else
                Exam = new PracticalExam(time, count, this);

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\n--- Question {i + 1} ---");

                if (type == 1)
                {
                    int qType = Input.ReadInt("Question type (1 = True/False, 2 = MCQ): ", 1, 2);
                    Exam.Questions[i] = qType == 1 ? ReadTrueFalse() : ReadMCQ();
                }
                else
                {
                    Exam.Questions[i] = ReadMCQ();
                }
            }
        }

        private Question ReadTrueFalse()
        {
            string header = Input.ReadString("Header: ");
            string body = Input.ReadString("Body: ");
            int mark = Input.ReadInt("Mark: ", 1, 100);
            int right = Input.ReadInt("Right answer (1 = True, 2 = False): ", 1, 2);
            return new TrueFalseQuestion(header, body, mark, right == 1);
        }

        private Question ReadMCQ()
        {
            string header = Input.ReadString("Header: ");
            string body = Input.ReadString("Body: ");
            int mark = Input.ReadInt("Mark: ", 1, 100);
            int choices = Input.ReadInt("Number of choices (2-6): ", 2, 6);

            Answer[] answers = new Answer[choices];
            for (int j = 0; j < choices; j++)
            {
                string text = Input.ReadString($"Choice {j + 1}: ");
                answers[j] = new Answer(j + 1, text);
            }

            int right = Input.ReadInt("Right choice number: ", 1, choices);
            return new MCQQuestion(header, body, mark, answers, right);
        }
    }
}