namespace ScoreBoard
{
    public class Team
    {
        public Team(string name)
        {
            Name = name;
        }

        public string Name { get;}
        public int Score { get; set; } = 0;
    }
}
