using System;
using System.IO;


//Assignment 1: .NET PROGRAMMING CSCD371
//Tyler Rose & Mark Capka           //--students
//@TylerRose8    //@MarkCapka      //--github

//.NET 6.0  MSTest Visual Studio 2022




namespace PrincessBrideTrivia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = GetFilePath();
            Question[] questions = LoadQuestions(filePath);

            int numberOfCorrectGuesses = 0;
            for (int i = 0; i < questions.Length; i++)
            {
                bool result = AskQuestion(questions[i]);
                if (result)
                {
                    numberOfCorrectGuesses++;
                }
            }
            Console.WriteLine("You got " + GetPercentCorrect(numberOfCorrectGuesses, questions.Length) + " correct");
        }

        public static string GetPercentCorrect(int numberOfCorrectGuesses, int numberOfQuestions)
        {
            double percent = ((double)numberOfCorrectGuesses / numberOfQuestions * 100);
            string percentage = Math.Round(percent, 2) + "%";
            return percentage;
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

        public static Question[] LoadQuestions(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

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
                questions[i] = question;

                    
            }
            ShuffleQuestions(questions);
            return questions;
        }

        private static void ShuffleQuestions(Question[] questionArray)
        {
            Random rnd = new Random();

            for(int i = 0; i < questionArray.Length-1; i++)
            {
                SwapElements(questionArray, i, rnd.Next(0, questionArray.Length - 1));
            }
        }


        public static void SwapElements(Question[] array, int index1, int index2)
        {
            Question temp = array[index2];
            array[index2] = array[index1];
            array[index1] = temp;
        }
    }
}
