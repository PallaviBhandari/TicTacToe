namespace TicTacToe
{
    public interface IGame
    {
        char[,] GetBoard();
        void SetCurrent(Player player);
        bool CheckWins();
        bool IsFull();
        void PlayComputerTurn();
        void PlaceUserMark(int row, int col);
        bool IsSpotAvailable(int row, int col);
    }
}
