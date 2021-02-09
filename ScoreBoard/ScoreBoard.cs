using System.Collections.Generic;
using System.Linq;

namespace ScoreBoard
{
    public class ScoreBoard
    {
        public List<Game> Games { get; } = new List<Game>();
        private int Count { get; set; }

        public void StartGame(string home, string away)
        {
            Games.Add(new Game(new Team(home), new Team(away), Count++));
        }

        public void FinishGame(int id)
        {
            if(Games.Exists(x => x.Id == id))
                Games.Remove(Games.Find(x => x.Id == id));
        }

        public void UpdateScore(int id, int homeScore, int awayScore)
        {
            if (Games.Exists(x => x.Id == id) && homeScore >= 0 && awayScore >=0)
                Games.Find(x => x.Id == id).UpdateScore(homeScore, awayScore);
        }

        public List<Game> GetSummary()
        {
            return Games.OrderByDescending(x => x.TotalScore()).ThenByDescending(x => x.Id).ToList();
        }
        
    }
}
