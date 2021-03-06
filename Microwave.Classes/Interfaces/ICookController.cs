using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microwave.Classes.Interfaces
{
    public interface ICookController
    {
        int MaxWatt { get; set; }
        void StartCooking(int power, int time);
        void Stop();
        void AddTime(int addedTime);
        void ReduceTime(int reducedTime);
    }
}
