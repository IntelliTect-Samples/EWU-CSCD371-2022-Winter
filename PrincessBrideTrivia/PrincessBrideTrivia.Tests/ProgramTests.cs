using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;


namespace PrincessBrideTrivia.Tests
{
    [TestClass]
    public class ProgramTests
    {
        string filepath = "DELETEME.txt";
        Random seededRand = new Random(2); //This seed is guaranteed to give a random order
        Question[] questions;
        Question[] randomQuestions;

        [TestInitialize]
        public void TestInit()
        {
            GenerateQuestionsFile(filepath, 12);
            questions = Program.LoadQuestions(filepath);
            randomQuestions = Program.RandomizeArray<Question>(questions, seededRand);
            File.Delete(filepath);
        }

        [TestMethod]
        public void LoadQuestions_RetrievesQuestionsFromFile()
        {
            string filePath = Path.GetRandomFileName();
            try
            {
                // Arrange
                GenerateQuestionsFile(filePath, 2);

                // Act
                Question[] questions = Program.LoadQuestions(filePath);

                // Assert 
                Assert.AreEqual(2, questions.Length);
            }
            finally
            {
                File.Delete(filePath);
            }
        }

        [TestMethod]
        [DataRow("1", true)]
        [DataRow("2", false)]
        public void DisplayResult_ReturnsTrueIfCorrect(string userGuess, bool expectedResult)
        {
            // Arrange
            Question question = new Question();
            question.CorrectAnswerIndex = "1";

            // Act
            bool displayResult = Program.DisplayResult(userGuess, question);

            // Assert
            Assert.AreEqual(expectedResult, displayResult);
        }

        [TestMethod]
        public void GetFilePath_ReturnsFileThatExists()
        {
            // Arrange

            // Act
            string filePath = Program.GetFilePath();

            // Assert
            Assert.IsTrue(File.Exists(filePath));
        }

        [TestMethod]
        [DataRow(1, 1, "100%")]
        [DataRow(5, 10, "50%")]
        [DataRow(1, 10, "10%")]
        [DataRow(0, 10, "0%")]
        public void GetPercentCorrect_ReturnsExpectedPercentage(int numberOfCorrectGuesses,
            int numberOfQuestions, string expectedString)
        {
            // Arrange

            // Act
            string percentage = Program.GetPercentCorrect(numberOfCorrectGuesses, numberOfQuestions);

            // Assert
            Assert.AreEqual(expectedString, percentage);
        }



        [TestMethod]
        public void RandomizeArray_AltersQuestionArray()
        {
            bool isChanged = false;
            for (int i = 0; i < questions.Length; i++)
            {
                if (questions[i].Text.Equals(randomQuestions[i].Text))
                    isChanged = true;
            }

            Assert.IsTrue(isChanged);

            File.Delete(filepath);

        }


        [TestMethod]
        public void RandomizeArray_AlteredQuestionArrayHasOriginalQuestions()
        {
            string filepath = "DELETEME.txt";
            GenerateQuestionsFile(filepath, 12);
            Random seededRand = new Random(2); //This seed is guaranteed to give a random order
            Question[] questions = Program.LoadQuestions(filepath);
            Question[] randomQuestions = Program.RandomizeArray<Question>(questions, seededRand);
            bool hasOriginalQuestions = true;

            foreach (Question q in questions)
            {
                bool questionFound = false;

                foreach (Question randomq in randomQuestions)
                {
                    if (q.Text.Equals(randomq.Text) &&
                        q.Answers.Equals(randomq.Answers) &&
                        q.CorrectAnswerIndex.Equals(randomq.CorrectAnswerIndex))
                    {
                        questionFound = true;
                    }
                }

                if (questionFound == false)
                {
                    hasOriginalQuestions = questionFound;
                }
            }

            Assert.IsTrue(hasOriginalQuestions);

        }




        private static void GenerateQuestionsFile(string filePath, int numberOfQuestions)
        {
            for (int i = 0; i < numberOfQuestions; i++)
            {
                string[] lines = new string[5];
                lines[0] = "Question " + i + " this is the question text";
                lines[1] = "Answer 1";
                lines[2] = "Answer 2";
                lines[3] = "Answer 3";
                lines[4] = "2";
                File.AppendAllLines(filePath, lines);
            }
        }


    }


}

