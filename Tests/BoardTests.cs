using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe;

namespace Tests
{
    [TestClass]
    public class BoardTests
    {
        private IGame _target;
        private Player user;
        private Player computer;

        [TestInitialize]
        public void Setup()
        {
            _target = new Game();
            user = new Player { Mark = 'O', Name = "TestUser" };
            computer = new Player { Mark = 'X', Name = "Computer" };
        }

        [TestCleanup]
        public void CleanUp()
        {
            _target = null;
            user = null;
            computer = null;
        }

        [TestMethod]
        public void CanCheckWinsWhenThereIsWinner()
        {
            _target.SetCurrent(user);
            _target.PlaceUserMark(0, 0);
            _target.PlaceUserMark(0, 1);
            _target.PlaceUserMark(0, 2);

            Assert.IsTrue(_target.CheckWins());
        }
        
        [TestMethod]
        public void CanCheckIfBoardIsFull()
        {
            _target.SetCurrent(user);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _target.PlaceUserMark(i, j);
                }
            }
                Assert.IsTrue(_target.IsFull());
            
        }

        [TestMethod]
        public void CanPlaceUserMark() 
        {
            _target.SetCurrent(user);
            _target.PlaceUserMark(0, 0);

            var board = _target.GetBoard();

            Assert.IsTrue(board[0, 0] == user.Mark);
        }

        [TestMethod]
        public void CanPlayComputerTurn()
        {
            _target.SetCurrent(computer);
            _target.PlayComputerTurn();
            var result = false;
            var board = _target.GetBoard();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == computer.Mark) { result = true; break; }
                }
            }

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanCheckIfSpotAvailable() 
        {
            _target.SetCurrent(user);
            _target.PlaceUserMark(0,0);

            var board = _target.GetBoard();
            
            Assert.IsFalse(_target.IsSpotAvailable(0,0));
        }
    }
}