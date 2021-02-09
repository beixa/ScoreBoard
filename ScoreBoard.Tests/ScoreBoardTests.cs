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

            Assert.Single(board.games);

            foreach (var game in board.games)
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

            Assert.Single(board.games);

            foreach (var game in board.games)
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

            Assert.Equal(3, board.games.Count);

            foreach (var game in board.games)
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

            Assert.Equal(2, board.games.Count);
            Assert.Equal("Spain", board.games[0].Home.Name);

            foreach (var game in board.games)
            {
                Assert.NotEqual("Mexico", game.Home.Name);
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
            board.FinishGame(0);

            Assert.Equal(3, board.games.Count);            
        }
    }
}
