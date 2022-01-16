using System;
using System.IO;

// Whitney Bolar
// Course: CSCD 371 .Net Programming
// Description

// References:
// https://www.dotnetperls.com/path


namespace PrincessBrideTrivia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // * Code Reference: https://www.dotnetperls.com/path
                string path = @"C:\Users\WhitneyBolar\source\repos\Assignment1\EWU-CSCD371-2022-Winter\PrincessBrideTrivia\PrincessBrideTrivia\Trivia.txt";

                string filePath = GetFilePath(path);
                string fileName = Path.GetFileName(filePath);

                Question[] questions = LoadQuestions(fileName);

                int numberCorrect = 0;
                for (int i = 0; i < questions.Length; i++)
                {
                    bool result = AskQuestion(questions[i]);
                    if (result)
                    {
                        numberCorrect++;
                    }
                }

                Console.WriteLine("You got " + GetPercentCorrect(numberCorrect, questions.Length) + " correct");
            }

        private static string GetFilePath(string v)
        {
            throw new NotImplementedException();
        }

        public static string GetPercentCorrect(int numberCorrectAnswers, int numberOfQuestions)
        {
            return (numberCorrectAnswers / numberOfQuestions * 100) + "%";
        }

        public static bool AskQuestion(Question question)
        {
            DisplayQuestion(question);

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

        public static void DisplayQuestion(Question question)
        {
            Console.WriteLine("Question: " + question.Text);
            for (int i = 0; i < question.Answers.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + question.Answers[i]);
            }
        }

        public static string GetFilePath()
        {
            return "Trivia.txt";
        }

        public static Question[] LoadQuestions(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);

            Question[] questions = new Question[lines.Length / 5];
            for (int i = 0; i < questions.Length; i++)
            {
                int lineIndex = i * 5;
                string questionText = lines[lineIndex];

                string answer1 = lines[lineIndex + 1];
                string answer2 = lines[lineIndex + 2];
                string answer3 = lines[lineIndex + 3];

                string correctAnswerIndex = lines[lineIndex + 4];

                Question question = new Question();
                question.Text = questionText;
                question.Answers = new string[3];
                question.Answers[0] = answer1;
                question.Answers[1] = answer2;
                question.Answers[2] = answer3;
                question.CorrectAnswerIndex = correctAnswerIndex;
            }
            return questions;
        }
    }
}
