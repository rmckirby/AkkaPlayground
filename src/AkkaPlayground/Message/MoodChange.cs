namespace AkkaPlayground
{
    public struct MoodChange
    {
        public MoodChange(string mood)
        {
            Mood = mood;
        }

        public string Mood { get; }
    }
}
