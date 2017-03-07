using Akka.Actor;
using AkkaPlayground.Message;
using static System.Console;

namespace AkkaPlayground.Actor
{
	public sealed class GreetingActor : ReceiveActor
	{
		public GreetingActor()
		{
			Receive<Greet>(greet => WriteLine($"Message from {greet.Who}"));
		}
	}
}
