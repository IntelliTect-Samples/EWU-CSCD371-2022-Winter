namespace PrincessBrideTrivia
{
    public class Question
    {
        public string Text;
        public string[] Answers;
        public string CorrectAnswerIndex;

        public Question(string Q, string[] A, string a)
        {
            this.Text = Q;
            this.Answers = A;
            this.CorrectAnswerIndex = a;
        }
    }
}//Hi there buddy