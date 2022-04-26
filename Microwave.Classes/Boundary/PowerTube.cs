using System;
using System.Diagnostics.CodeAnalysis;
using Microwave.Classes.Interfaces;

namespace Microwave.Classes.Boundary
{
    public class PowerTube : IPowerTube
    {
        private IOutput myOutput;
        public int Watt { get; set; }
        private bool IsOn = false;

        public PowerTube(IOutput output, int watt)
        {
            myOutput = output;
            Watt = watt;
        }

        public void TurnOn(int power)
        {
            if (power < 1 || Watt < power)
            {
                throw new ArgumentOutOfRangeException("power", power, "Must be between 1 and" + Watt + " (incl.)");
            }

            if (IsOn)
            {
                throw new ApplicationException("PowerTube.TurnOn: is already on");
            }

            myOutput.OutputLine($"PowerTube works with {power}");
            IsOn = true;
        }

        public void TurnOff()
        {
            if (IsOn)
            {
                myOutput.OutputLine($"PowerTube turned off");
            }

            IsOn = false;
        }
    }
}