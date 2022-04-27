using System;
using Microwave.Classes;
using Microwave.Classes.Boundary;
using Microwave.Classes.Controllers;
using Microwave.Classes.Interfaces;

namespace Microwave.App
{
   class Program
   {
      static void Main(string[] args)
      {
         Button startCancelButton = new Button();
         Button powerButton = new Button();
         Button timeButton = new Button();
         Button reduceTimeButton = new Button();


         Door door = new Door();

         Output output = new Output();

         IBuzzer buzzer = new Buzzer(output);

         Display display = new Display(output);

         PowerTube powerTube = new PowerTube(output, 800);

         Light light = new Light(output);


         Microwave.Classes.Boundary.Timer timer = new Timer();

         CookController cooker = new CookController(timer, display, powerTube, buzzer);

         UserInterface ui = new UserInterface(powerButton, timeButton, startCancelButton, reduceTimeButton, door, display, light, cooker);

         // Finish the double association
         cooker.UI = ui;

         // Simulate a simple sequence

         powerButton.Press();

         powerButton.Press();

         powerButton.Press();

         powerButton.Press();



         timeButton.Press();

         startCancelButton.Press();


         // The simple sequence should now run

         System.Console.WriteLine("When you press enter, the program will stop");
         // Wait for input

         System.Console.ReadLine();
      }
   }
}
