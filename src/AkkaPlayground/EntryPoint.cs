using System;
using Akka;
using Akka.Actor;

using AkkaPlayground.Actor;
using AkkaPlayground.Message;

using static System.Console;

namespace AkkaPlayground
{
    public sealed class EntryPoint
    {
        public void Run()
        {
            using (var system = ActorSystem.Create("MySystem"))
            {
                var greeter = system.ActorOf<GreetingActor>("greeter");

                greeter.Tell(new Greet("Bob"));

                ConsoleKeyInfo key;
                do
                {
                    key = Console.ReadKey();
                    greeter.Tell(new MoodChange("angry"));
                    greeter.Tell(new Greet("won't happen"));
                    greeter.Tell(new MoodChange("happy"));
                    greeter.Tell(new Greet("will happen"));
                }
                while (key.Key != ConsoleKey.Escape);

                ReadLine();
            }
        }

        public static void Main() => new EntryPoint().Run();
    }
}