using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAspNetCoreApp.services
{
    public interface ICounter
    {
        int Value { get; }
    }

    public class RandomCounter : ICounter
    {
        int value;
        static Random rnd = new Random();

        public int Value => value;

        public RandomCounter()
        {
            value = rnd.Next(0, 1000000);
        }
    }

    public class CounterService
    {
        public ICounter Counter { get; }

        public CounterService(ICounter counter)
        {
            Counter = counter;
        }
    }
}
