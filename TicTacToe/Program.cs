using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var computer = new Player { Mark = 'X', Name = "Computer" };
            var user = new Player { Mark = 'O' };
            var continuePlay = true;
            var game = new Game();
            int rowValue = 0, colValue = 0;

            Console.WriteLine("Welcome to TicTacToe!");
            Console.WriteLine();
            Console.WriteLine("Please enter your name:");
          
            user.Name = Console.ReadLine();
            Console.WriteLine($"Hello {user.Name}! Let's start playing, good luck!");
            Console.WriteLine();

            while (continuePlay)
            {
                game = new Game();
                game.DrawInitialBoard();
                
                while (!game.CheckWins() && !game.IsFull())
                {
                    Console.WriteLine();
                    rowValue = GetNextRow();
                    colValue = GetNextCol();

                    while (!game.IsSpotAvailable(rowValue, colValue))
                    {
                        Console.WriteLine("This spot has been taken, please choose another spot.");
                        rowValue = GetNextRow();
                        colValue = GetNextCol();
                    }

                    game.Current = user;
                    game.PlaceUserMark(rowValue, colValue);
                    Console.WriteLine();
                    Console.WriteLine($"Your Play:");
                    game.DrawBoard();

                    if (GameFinished(game)) break;
                    
                    game.Current = computer;
                    game.PlayComputerTurn();
                    Console.WriteLine();
                    Console.WriteLine("Computer's Play:");
                    game.DrawBoard();

                    if (GameFinished(game)) break; 
                }

                Console.WriteLine();
                Console.WriteLine("Would you like to play again? Enter Y/N:");
                continuePlay = Console.ReadLine().ToUpper() == "Y";
                Console.WriteLine();
            }
            Console.WriteLine("Thanks for playing! Press any key to close.");
            Console.ReadLine();
        }

        public static bool GameFinished(Game game)
        {
            if (game.CheckWins()) { Console.WriteLine($"Congratulations! {game.Current.Name} is the winner!"); return true; };
            if (game.IsFull()) { Console.WriteLine($"Well played! This game was a tie, please play again to win!"); return true; }
            return false;
        }

        public static int GetNextRow()
        {
            Console.WriteLine("Your turn. Enter row value (0,1,2):");
            try
            {
                return Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter a valid row value (0,1,2):");
                return GetNextRow();
            }

        }

        public static int GetNextCol()
        {
            Console.WriteLine("Your turn. Enter column value (0,1,2):");
            try
            {
                return Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter a valid column value (0,1,2):");
                return GetNextCol();
            }

        }
    }
}

