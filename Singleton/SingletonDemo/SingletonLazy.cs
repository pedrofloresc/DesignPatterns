using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    public sealed class SingletonLazy
    {
        private static int counter = 0;
        private static readonly Lazy<SingletonLazy> instance = new Lazy<SingletonLazy>(()=>new SingletonLazy());
        public static SingletonLazy GetInstance
        {
            get
            {
                return instance.Value;
            }
        }
        private SingletonLazy()
        {
            counter++;
            Console.WriteLine("Counter Value " + counter.ToString());
        }

        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }
    }
}
