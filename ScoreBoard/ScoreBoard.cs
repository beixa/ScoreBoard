using System.Collections.Generic;

namespace ScoreBoard
{
    public class ScoreBoard
    {
        public readonly List<Game> games = new List<Game>();

        public void StartGame(string home, string away)
        {
            games.Add(new Game(new Team(home), new Team(away)));
        }
    }
}
