using System;
using System.Threading;

namespace CWI.Watcher.Classes
{
    //Emulates a scheduled service
    public static class Service
    {
        public static void Run(int millisecondsInterval)
        {
            Console.WriteLine("Press 'Ctrl + C' to quit.");
            do
            {
                Console.WriteLine($"Checked in {DateTime.Now}");
                FileManager.Run();
                Thread.Sleep(millisecondsInterval);
            } while (true);
        }
    }
}
