using System;
using System.Diagnostics.CodeAnalysis;
using Microwave.Classes.Interfaces;

namespace Microwave.Classes.Boundary
{
    public class PowerTube : IPowerTube
    {
        private IOutput myOutput;
        public int MaxWatt { get; set; }
        private bool IsOn = false;

        public PowerTube(IOutput output, int maxWatt)
        {
            myOutput = output;
            MaxWatt = maxWatt;
        }
            
        public void TurnOn(int power)
        {
            if (power < 1 || MaxWatt < power)
            {
                throw new ArgumentOutOfRangeException("power", power, "Must be between 1 and" + MaxWatt + " (incl.)");
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