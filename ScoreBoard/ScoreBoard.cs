using System.Collections.Generic;

namespace ScoreBoard
{
    public class ScoreBoard
    {
        public readonly List<Game> games = new List<Game>();
        public readonly int Id = 0;

        public void StartGame(string home, string away)
        {
            games.Add(new Game(new Team(home), new Team(away), Id+1));
        }

        public void FinishGame(int id)
        {
            if(id <= games.Count && id > 0)
                games.Remove(games.Find(x => x.Id == id));
        }
    }
}
