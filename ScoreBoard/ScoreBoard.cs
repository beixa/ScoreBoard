using System.Collections.Generic;
using System.Linq;

namespace ScoreBoard
{
    public class ScoreBoard
    {
        public readonly List<Game> games = new List<Game>();
        private int _id = 0;

        public void StartGame(string home, string away)
        {
            games.Add(new Game(new Team(home), new Team(away), _id++));
        }

        public void FinishGame(int id)
        {
            if(games.Exists(x => x.Id == id))
                games.Remove(games.Find(x => x.Id == id));
        }

        public void UpdateScore(int id, int homeScore, int awayScore)
        {
            if (games.Exists(x => x.Id == id) && homeScore >= 0 && awayScore >=0)
                games.Find(x => x.Id == id).UpdateScore(homeScore, awayScore);
        }

        public List<Game> GetSummary()
        {
            return games.OrderByDescending(x => x.TotalScore()).ThenByDescending(x => x.Id).ToList();
        }
        
    }
}
