using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {
        static void Main()
        {
            var alarmClock = new AlarmClock() { Name = "Alarm" };

            var Human = new Person
            {
                Name = "Brian",
                Message = "Just five more minutes, please!"
            };

            alarmClock.Ring += Human.Reply;

            var Human2 = new Person
            {
                Name = "Erin",
                Message = "Yep, I've heard you, I'm getting up.."
            };

            alarmClock.Ring += Human2.Reply;

            var dog = new Dog
            {
                NickName="Avalon"
            };

            alarmClock.Ring += dog.Bark;

            alarmClock.WakeUp("It's time to wake up!");

            alarmClock.Ring -= Human.Reply;
            alarmClock.WakeUp("It's time to wake up!");

            Console.ReadKey();
        }
    }
}
