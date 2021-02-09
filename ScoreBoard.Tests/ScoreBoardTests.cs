using Xunit;

namespace ScoreBoard.Tests
{
    public class ScoreBoardTests
    {
        [Fact]
        public void Start_One_Game()
        {
            ScoreBoard board = new ScoreBoard();

            board.StartGame("Mexico","Canada");

            Assert.Single(board.Games);

            foreach (Game game in board.Games)
            {
                Assert.Equal(0, game.Home.Score);
                Assert.Equal("Mexico", game.Home.Name);
                Assert.Equal(0, game.Away.Score);
                Assert.Equal("Canada", game.Away.Name);
            }            
        }

        [Fact]
        public void Start_Game_Whith_Empty_String()
        {
            ScoreBoard board = new ScoreBoard();

            board.StartGame(string.Empty, string.Empty);

            Assert.Single(board.Games);

            foreach (var game in board.Games)
            {
                Assert.Equal(0, game.Home.Score);
                Assert.Equal("", game.Home.Name);
                Assert.Equal(0, game.Away.Score);
                Assert.Equal("", game.Away.Name);
            }
        }

        [Fact]
        public void Start_Various_Games()
        {
            ScoreBoard board = new ScoreBoard();

            board.StartGame("Mexico", "Canada");
            board.StartGame("Spain", "Brazil");
            board.StartGame("Germany", "France");

            Assert.Equal(3, board.Games.Count);

            foreach (var game in board.Games)
            {
                Assert.Equal(0, game.Home.Score);
                Assert.Equal(0, game.Away.Score);
            }
        }

        [Fact]
        public void Finish_Game()
        {
            ScoreBoard board = new ScoreBoard();

            board.StartGame("Mexico", "Canada");
            board.StartGame("Spain", "Brazil");
            board.StartGame("Germany", "France");

            board.FinishGame(1);

            Assert.Equal(2, board.Games.Count);
            Assert.Equal("Mexico", board.Games[0].Home.Name);

            foreach (var game in board.Games)
            {
                Assert.NotEqual("Spain", game.Home.Name);
            }
        }

        [Fact]
        public void Finish_Game_With_None_Existing_Index()
        {
            ScoreBoard board = new ScoreBoard();

            board.StartGame("Mexico", "Canada");
            board.StartGame("Spain", "Brazil");
            board.StartGame("Germany", "France");

            board.FinishGame(10);
            board.FinishGame(-1);

            Assert.Equal(3, board.Games.Count);            
        }

        [Fact]
        public void Update_Score()
        {
            ScoreBoard board = new ScoreBoard();

            board.StartGame("Mexico", "Canada");
            board.StartGame("Spain", "Brazil");
            board.StartGame("Germany", "France");

            board.UpdateScore(0, 1, 0);
            board.UpdateScore(1, 3, 1);

            Assert.Equal(1, board.Games[0].Home.Score);
            Assert.Equal(1, board.Games[1].Away.Score);
        }

        [Fact]
        public void Update_Score_With_Invalid_Id()
        {
            ScoreBoard board = new ScoreBoard();

            board.StartGame("Mexico", "Canada");

            board.UpdateScore(4, 1, 0);

            Assert.Equal(0, board.Games[0].Home.Score);
            Assert.Equal(0, board.Games[0].Away.Score);
        }

        [Fact]
        public void Update_Score_With_Invalid_Scores()
        {
            ScoreBoard board = new ScoreBoard();

            board.StartGame("Mexico", "Canada");

            board.UpdateScore(0, -1, 0);

            Assert.Equal(0, board.Games[0].Home.Score);
            Assert.Equal(0, board.Games[0].Away.Score);
        }

        [Fact]
        public void Get_Summary()
        {
            ScoreBoard board = new ScoreBoard();

            board.StartGame("Mexico", "Canada");
            board.UpdateScore(0, 0, 5);
            board.StartGame("Spain", "Brazil");
            board.UpdateScore(1, 10, 2);
            board.StartGame("Germany", "France");
            board.UpdateScore(2, 2, 2);
            board.StartGame("Uruguay", "Italy");
            board.UpdateScore(3, 6, 6);
            board.StartGame("Argentina", "Australia");
            board.UpdateScore(4, 3, 1);

            var sum = board.GetSummary();

            Assert.Equal(3, sum[0].Id);
            Assert.Equal(1, sum[1].Id);
            Assert.Equal(0, sum[2].Id);
            Assert.Equal(4, sum[3].Id);
            Assert.Equal(2, sum[4].Id);
        }
    }
}
