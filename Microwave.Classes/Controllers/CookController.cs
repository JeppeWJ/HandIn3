using System;
using Microwave.Classes.Interfaces;

namespace Microwave.Classes.Controllers
{
    public class CookController : ICookController
    {
        // Since there is a 2-way association, this cannot be set until the UI object has been created
        // It also demonstrates property dependency injection
        public IUserInterface UI { set; private get; }

        private bool isCooking = false;
        private IBuzzer _buzzer; 
        private IDisplay myDisplay;
        private IPowerTube myPowerTube;
        private ITimer myTimer;

        public CookController(
            ITimer timer,
            IDisplay display,
            IPowerTube powerTube,
            IUserInterface ui, IBuzzer Buzzer) : this(timer, display, powerTube,Buzzer)
        {
            UI = ui;
        }

        public CookController(
            ITimer timer,
            IDisplay display,
            IPowerTube powerTube, IBuzzer Buzzer)
        {
            myTimer = timer;
            myDisplay = display;
            myPowerTube = powerTube;
            _buzzer = Buzzer;

            timer.Expired += new EventHandler(OnTimerExpired);
            timer.TimerTick += new EventHandler(OnTimerTick);
        }

        public void StartCooking(int power, int time)
        {
            myPowerTube.TurnOn(power);
            myTimer.Start(time);
            isCooking = true;
        }

        public void Stop()
        {
            isCooking = false;
            myPowerTube.TurnOff();
            myTimer.Stop();
        }

        public void AddTime(int addedTime)
        {
           int time = myTimer.TimeRemaining;
           myTimer.Start(time + addedTime);
        }

        public void ReduceTime(int reducedTime)
        {
            int time = myTimer.TimeRemaining;
            myTimer.Start(time-reducedTime);
        }

        public void OnTimerExpired(object sender, EventArgs e)
        {
            if (isCooking)
            {
                _buzzer.BuzzerOn("Bip Bip Bip!");
                isCooking = false;
                myPowerTube.TurnOff();
                UI.CookingIsDone();
            
            }
        }

        public void OnTimerTick(object sender, EventArgs e)
        {
            if (isCooking)
            {
                int remaining = myTimer.TimeRemaining;
                myDisplay.ShowTime(remaining / 60, remaining % 60);
            }
        }
    }
}