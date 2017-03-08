using Akka.Actor;
using AkkaPlayground.Message;
using System;
using System.Collections.Immutable;

using static System.Console;

namespace AkkaPlayground.Actor
{
    using MoodMap = IImmutableDictionary<string, Action<MoodChange>>;

    public sealed class GreetingActor : ReceiveActor
    {
        private readonly MoodMap MoodActions;
        private string currentMood;

        public GreetingActor()
        {
            var stateBuilder = ImmutableDictionary.CreateBuilder<string, Action<MoodChange>>();
            stateBuilder.Add("happy", ChangeToHappy);
            stateBuilder.Add("angry", ChangeToAngry);
            MoodActions = stateBuilder.ToImmutable();

            Receive();
        }

        private void ChangeToHappy(MoodChange mood)
        {
            if (currentMood == "angry")
            {
                UnbecomeStacked();
            }
            currentMood = "happy";
            WriteLine("I am happy :)");
        }

        private void ChangeToAngry(MoodChange mood)
        {
            currentMood = "angry";
            WriteLine("I am angry!");
            BecomeStacked(AngryReceive);
        }

        private void Receive()
        {
            Receive<Greet>(greet => WriteLine($"Message from {greet.Who}"));
            Receive<MoodChange>(mood => MoodChangeHandler(mood));
        }

        private void AngryReceive()
        {
            Receive<MoodChange>(mood => MoodChangeHandler(mood));
        }

        private void MoodChangeHandler(MoodChange mood)
        {
            if (MoodActions.ContainsKey(mood.Mood))
            {
                MoodActions[mood.Mood](mood);
            }
        }
    }
}
