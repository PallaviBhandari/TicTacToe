using System;
using System.Collections.Generic;
using TicTacToe;

public class Game:IGame
{
    public char[,] Board;
    public Player Current;
    private const char EmptySpot = ' ';

    public char[,] GetBoard()
    {
        return Board;
    }
     
    public void SetCurrent(Player player)
    {
        Current = player;
    }

    public Game()
    {
        SetupBoard();
    }

    private void SetupBoard()
    {
        Board = new char[3, 3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Board[i, j] = EmptySpot;
            }
        }
    }

    public bool CheckWins()
    {
        if (CheckRows() || CheckColumns() || CheckDiagonals()) return true;
        return false;
    }

    private bool CheckDiagonals()
    {
        if (Board[0, 0] != EmptySpot && Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2]) return true;
        else if (Board[0, 2] != EmptySpot && Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0]) return true;
        return false;
    }

    private bool CheckColumns()
    {
        for (int i = 0; i < 3; i++)
        {
            if (Board[0, i] != EmptySpot && Board[0, i] == Board[1, i] && Board[1, i] == Board[2, i]) return true;
        }
        return false;
    }

    private bool CheckRows()
    {
        for (int i = 0; i < 3; i++)
        {
            if (Board[i, 0] != EmptySpot && Board[i, 0] == Board[i, 1] && Board[i, 1] == Board[i, 2]) return true;
        }
        return false;
    }

    public bool IsFull()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (Board[i, j] == EmptySpot) return false;
            }
        }
        return true;
    }

    public void PlayComputerTurn()
    {
        int rowNumber=0, colNumber=0;
        var positions = new List<string>();
       
        if (!IsFull())
        {
            Random random = new Random();
            do
            {
                rowNumber = random.Next(0, 3);
                colNumber = random.Next(0, 3);
                var position = $"{rowNumber}{colNumber}";
                if (Board[rowNumber, colNumber] == EmptySpot && !positions.Contains(position))
                {
                    Board[rowNumber, colNumber] = Current.Mark;
                    break;
                }
                else
                {
                    positions.Add(position);
                }
            } while (Board[rowNumber, colNumber] != EmptySpot);
        }
    }

    public void PlaceUserMark(int row, int col)
    {
        if (Board[row, col] == EmptySpot)
        {
            if (row >= 0 && row < 3 && col >= 0 && col < 3)
                Board[row, col] = Current.Mark;
        }
    }

    public void DrawBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($" {Board[i, 0]}---{Board[i, 1]}---{Board[i, 2]}");
            if (i < 2)
                Console.WriteLine("|    |    |");
        }
    }

    public void DrawInitialBoard()
    {
        var j = 0;
        Console.WriteLine("Board positions are as follows:");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($" {i}{j}---{i}{j+1}---{i}{j+2}");
            if (i < 2)
                Console.WriteLine(" |    |    |");
        }
    }

    public bool IsSpotAvailable(int row, int col)
    {
        return Board[row, col] == EmptySpot;
    }
}

