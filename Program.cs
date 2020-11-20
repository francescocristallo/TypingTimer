using System;
using System.Timers;

namespace TypingTimer
{
    /// <summary>
    /// Concept for sending a Typing signal in a chat after xx seconds while the user is Typing
    /// </summary>
    class Program
    {
        private static Timer TypingSignalTimer;
        private static Timer TypingEndSignalTimer;
        static void Main(string[] args)
        {
            Start();
            Console.ReadLine();
        }

        private static void Start()
        {
            TypingSignalTimer = new Timer(2500) { AutoReset = false };
            TypingSignalTimer.Elapsed += CanSendTypingSignal;

            TypingEndSignalTimer = new Timer(3500) { AutoReset = false };
            TypingEndSignalTimer.Elapsed += CanSendStopTypingSignal;

            Console.WriteLine("Start typing \n");

            var key = Console.ReadKey();
            while (key.Key.ToString() != "Esc")
            {
                TypingSignalTimer.Start();
                TypingEndSignalTimer.Stop();
                TypingEndSignalTimer.Start();
                key = Console.ReadKey();
            }
        }

        private static void CanSendTypingSignal(object sender, ElapsedEventArgs e)
        {
            //Send SignalR signal
            Console.WriteLine($"\n\n User is typing");
        }
        private static void CanSendStopTypingSignal(object sender, ElapsedEventArgs e)
        {
            //Send SignalR signal
            Console.WriteLine($"\n User stopped typing");
        }
    }
}
