using CWI.Watcher.Classes;
using System;

namespace CWI.Watcher
{
    class Program
    {
        static void Main(string[] args)
        {
            int interval = 0;

#if DEBUG
            interval = 10000; //10 seconds
#else
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: CWI.Watcher.exe (millisecondsInterval)");
                return;
            }

            if (!int.TryParse(args[0], out interval))
            {
                Console.WriteLine("Invalid parameter.");
                Console.WriteLine("Usage: CWI.Watcher.exe (millisecondsInterval)");
                return;
            }
#endif

            Service.Run(interval);
        }
    }
}
