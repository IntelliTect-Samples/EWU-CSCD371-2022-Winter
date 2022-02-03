using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class MockJester : IPrint, ICanJoke
    {
        public string? _joke { get; set; }  

        public string GetJoke()
        {
            string joke = "You saved me, why? mm monke";

            return joke;
        }

        public void Print(string text)
        {
            _joke = text;
        }
    }
}
