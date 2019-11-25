using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    public sealed class SingletonEager
    {
        private static int counter = 0;
        private static readonly SingletonEager instance = new SingletonEager();
        public static SingletonEager GetInstance
        {
            get
            {
                return instance;
            }
        }
        private SingletonEager()
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
