namespace PrincessBrideTrivia
{
    public class Question
    {
        public string Text;
        public string[] Answers;
        public string CorrectAnswerIndex;


        //hard-coded a default constructor (values are all overwritten in LoadQuestions()
        public Question()
        {
            this.Text = "";
            this.Answers = new string[0];
            this.CorrectAnswerIndex = "";
        }
    }
}