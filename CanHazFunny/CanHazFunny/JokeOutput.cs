﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    internal class JokeOutput : IJokeOutput
    {
        public void TellJoke(string text)
        {
            Console.WriteLine(text);
        }
    }
}