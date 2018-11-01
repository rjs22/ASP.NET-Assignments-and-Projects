using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Thread Example ...");

            // Create a new thread
            Thread newThread = new Thread(new ThreadStart(Alpha.Beta));
            newThread.Start();

            while (newThread.IsAlive)
            {
                Console.WriteLine("Beta thread is alive ...");
            }

            newThread.Abort();

            Console.ReadKey();
        }

    }
    class Alpha
    {
        public static void Beta()
        {
            Console.WriteLine("Alpha.Beta is currently running ...");


        }


    }


}
