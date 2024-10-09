using Section02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section02 {
    internal class Program {
        static void Main(string[] args) {
            var greetings = new List<IGreeting> {
                new GreetingMorning(),
                new GreetingAfternoon(),
                new GreetingEvening(),
            };

            foreach (var greeting in greetings) {
                string msg = greeting.GetMessage();
                Console.WriteLine(msg);
            }
            Console.ReadLine();
        }
    }
}
