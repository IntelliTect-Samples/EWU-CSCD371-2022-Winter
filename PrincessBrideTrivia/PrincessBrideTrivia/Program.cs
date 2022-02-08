using System;
using System.IO;

namespace PrincessBrideTrivia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = GetFilePath();

            Question[] array =  LoadQuestions(filePath);

            Question[] questions = new Question[array.Length];
            Console.WriteLine(questions[2]);

            int numberCorrect = 0;
            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine(i);
                Question question = questions[i];
                bool result = AskQuestion(question);
                if (result)
                {
                    numberCorrect++;
                }
            }
            Console.WriteLine("You got " + GetPercentCorrect(numberCorrect, questions.Length) + " correct");
        }

        public static string GetPercentCorrect(int numberCorrectAnswers, int numberOfQuestions)
        {
            return (numberCorrectAnswers / numberOfQuestions * 100) + "%";
        }

        public static bool AskQuestion(Question question)
        {
            String T = question.Text;
            String[] A = question.Answers;
            DisplayQuestion(T, A);

            string userGuess = GetGuessFromUser();
            return DisplayResult(userGuess, question);
        }

        public static string GetGuessFromUser()
        {
            return Console.ReadLine();
        }

        public static bool DisplayResult(string userGuess, Question question)
        {
            if (userGuess == question.CorrectAnswerIndex)
            {
                Console.WriteLine("Correct");
                return true;
            }

            Console.WriteLine("Incorrect");
            return false;
        }

        public static void DisplayQuestion(String question, string[] Answers)
        {
            Console.WriteLine("Question: " + question);
            for (int i = 0; i < Answers.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + Answers[i]);
            }
        }

        public static string GetFilePath()
        {
            return "C:/Users/breit/.NET/EWU-CSCD371-2022-Winter/PrincessBrideTrivia/PrincessBrideTrivia/Trivia.txt";
        }

        public static Question[] LoadQuestions(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            Console.WriteLine(lines[1]);
            Question[] questions = new Question[lines.Length / 5];
            for (int i = 0; i < questions.Length; i++)
            {
                int lineIndex = i * 5;
                string questionText = lines[lineIndex];
                string answer1 = lines[lineIndex + 1];
                string answer2 = lines[lineIndex + 2];
                string answer3 = lines[lineIndex + 3];

                string[] answers = new string[3];

                answers[0] = answer1;
                answers[1] = answer2;   
                answers[2] = answer3;

                string correctAnswerIndex = lines[lineIndex + 4];

                Question question = new Question(questionText, answers, correctAnswerIndex);
                Console.WriteLine(question.Text);
                questions[i] = question;
            }
            return questions;
        }
    }
}
