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

				ReadLine();
			}
		}

		public static void Main() => new EntryPoint().Run();
    }
}