using System;
using System.Collections.Generic;
using System.Text;
using Microwave.Classes.Interfaces;

namespace Microwave.Classes
{
    class Buzzer: IBuzzer
    {
        private IOutput myOutput;
        public void BuzzerOn (string text)
        {
            myOutput.OutputLine(text);
        }
    }
}
