using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace HMI.MVVM.Model
{
    public class DataValue
    {
        public event EventHandler? ValueChanged;
        public string Name { get; set; } = "0";
        public DataValue()
        {
            // Add a timer here
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000; // 1 second
            timer.Elapsed += TimerElapsed;
            timer.Start();
        }

        private void TimerElapsed(object? sender, ElapsedEventArgs e)
        {
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}