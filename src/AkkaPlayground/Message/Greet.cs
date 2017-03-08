namespace AkkaPlayground.Message
{
    public struct Greet
    {
        public Greet(string who)
        {
            Who = who;
        }

        public string Who { get; }
    }
}
