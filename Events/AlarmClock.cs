using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class AlarmEventArgs: EventArgs
    {
        public DateTime Time;
        public string EventDescription;
    }
    delegate void AlarmEventHandler(object sender, AlarmEventArgs e);
    class AlarmClock
    {
        public string Name;
        public event AlarmEventHandler Ring;

        protected virtual void OnRing(AlarmEventArgs e)
        {
            Console.WriteLine($"{e.EventDescription}!!! Already {e.Time.ToShortTimeString()}");
            if (Ring != null)
                Ring(this, e);

        }

        public void WakeUp (string description)
        {
            OnRing(new AlarmEventArgs() { Time = DateTime.Now, EventDescription = description });
        }
    }
}
