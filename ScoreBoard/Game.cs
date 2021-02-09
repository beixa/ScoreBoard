namespace ScoreBoard
{
    public class Game
    {
        public Team Home { get; }
        public Team Away { get; }

        public Game(Team home, Team away)
        {
            Home = home;
            Away = away;
        }
    }
}
