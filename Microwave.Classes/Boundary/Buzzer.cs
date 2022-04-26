using System;
using System.Collections.Generic;
using System.Text;
using Microwave.Classes.Boundary;
using Microwave.Classes.Interfaces;

namespace Microwave.Classes
{
   public class Buzzer: IBuzzer
   {
       private IOutput myOutput;

       public Buzzer(IOutput MyOutput)
       {
           myOutput = MyOutput;
       }
        public void BuzzerOn (string text)
        {
            myOutput.OutputLine(text);
        }
    }
}
