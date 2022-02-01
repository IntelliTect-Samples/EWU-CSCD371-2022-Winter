using System;

namespace CanHazFunny{

    public class Jester{
        
        private IGetJoke joker;

        private IPrintJoke printer;

        public Jester(IGetJoke Joker, IPrintJoke Printer)
        {
        joker = Joker;

        printer = Printer;

        if(joker == null || printer == null){
            throw new ArgumentException("null dependency");
        }
        }

        public void TellJoke(){
            string joke = joker.GetJoke();

            while(joke.Contains("Chuck Norris")){
                joke = joker.GetJoke();
            }

            printer.PrintJoke(joke);
        }
    }
}