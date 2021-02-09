namespace ScoreBoard
{
    public class Game
    {
        public int Id { get; }
        public Team Home { get; }
        public Team Away { get; }

        public Game(Team home, Team away, int id)
        {
            Id = id;
            Home = home;
            Away = away;
        }

        public void UpdateScore(int homeScore, int awayScore)
        {
            Home.Score = homeScore;
            Away.Score = awayScore;
        }
    }
}
