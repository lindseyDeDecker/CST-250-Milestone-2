using MinesweeperClasses;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Net.NetworkInformation;
using System.Reflection.PortableExecutable;

namespace MinesweeperConsole
{
    public class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Hello, welcome to Minesweeper!");
            Board board = new Board(10, 1);
            Console.WriteLine("Here is the answer key for the board");
            PrintBoard(board);

            Console.Write("\n");
            Console.Write("\n");
            Console.Write("\n");
            Console.WriteLine("Here is the playable version of the board.");
            PlayableBoard(board);

            int rewardCount = 0;
            bool victory = false;
            bool death = false;

            while (!victory && !death)
            {
                Console.WriteLine("Enter the row number.");
                int row = int.Parse(Console.ReadLine());
                row = row - 1;
                Console.WriteLine("Enter the column number.");
                int col = int.Parse(Console.ReadLine());
                col = col - 1;
                Console.WriteLine("Enter 1 to visit the cell, 2 to flag a cell or 3 to use sneak a peek at a cell (remember, this can only be used twice in a game).");
                int selection = int.Parse(Console.ReadLine());

                if (selection == 3)
                {
                    rewardCount++;
                }

                PrintSelection(row, col, selection, board, rewardCount);
                if (selection == 1)
                {
                    int status = board.DetermineGameStatus(board, row, col);

                    if (status == 3)
                    {
                        Console.WriteLine("Congratulations, you have won the game!!");
                        victory = true;
                    }
                    if (status == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("BOOMM... you revealed a bomb and have lost the game");
                        death = true;
                        Console.ResetColor();
                    }
                }

                
            }
        }

        static void PrintBoard(Board board)
        {
            PrintHeader(board);
            PrintDivider(board.Size);
            //looping through the full board size. 
            for (int i = 0; i < board.Size; i++)
            {
                PrintRow(i, board);
                PrintDivider(board.Size);
            }
        }
        static void PrintHeader(Board board)
        {
            for (int j = 0; j <= board.Size; j++)
            {
                string content = " ";

                if (j != 0)
                {
                    content = (j).ToString();
                }
                Console.Write(" " + content + "  ");
            }
            Console.Write("\n");
        }
        static void PrintRow(int i, Board board)
        {

            for (int j = 0; j <= board.Size; j++)
            {

                if (j == 0)
                {
                    int heading = (i + 1);
                    if (heading < 10)
                    {
                        Console.Write(" " + heading + " ");
                    }
                    else
                    {
                        Console.Write(" " + heading + "");
                    }
                }
                else
                {
                    Cell cell = board.Cells[i, (j - 1)];

                    if (cell.IsBomb)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("  B ");
                        Console.ResetColor();
                    }
                    else
                    {
                        if (cell.AdjacentBombs == 0)
                        {
                            Console.Write("  . ");
                        }
                        else if (cell.AdjacentBombs == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("  1 ");
                            Console.ResetColor();
                        }
                        else if (cell.AdjacentBombs == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("  2 ");
                            Console.ResetColor();
                        }
                        else if (cell.AdjacentBombs == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("  3 ");
                            Console.ResetColor();
                        }
                        else if (cell.AdjacentBombs == 4)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("  4 ");
                            Console.ResetColor();
                        }
                    }
                }

            }
            Console.Write("\n");
        }
        static void PrintDivider(int boardSize)
        {
            string row = "";
            for (int j = 0; j <= boardSize; j++)
            {
                if (j == 0)
                {
                    row += "   ";
                }
                else
                {
                    row += "+---";
                }
            }
            Console.WriteLine(row);
            //Console.Write("\n");
        }
        //Displays the board as the playable verision and not the answer key
        static void PlayableBoard(Board board)
        {
            PrintHeader(board);
            PrintDivider(board.Size);
            //looping through the full board size. 
            for (int i = 0; i < board.Size; i++)
            {
                PrintPlayableRow(i, board);
                PrintDivider(board.Size);
            }
        }
        //displays the rows with ? rather than with the assigned values
        static void PrintPlayableRow(int i, Board board)
        {
            for (int j = 0; j <= board.Size; j++)
            {
                
                if (j == 0)
                {
                    int heading = (i + 1);
                    if (heading < 10)
                    {
                        Console.Write(" " + heading + " ");
                    }
                    else
                    {
                        Console.Write(" " + heading + "");
                    }
                    continue;
                }
                Cell cell = board.Cells[i, (j - 1)];

                if (!cell.IsVisited && !cell.IsFlag)
                {
                    Console.Write("  ? ");
                }
                else
                {
                     if (cell.IsFlag)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("  F ");
                        Console.ResetColor();
                    }
                    else if (cell.IsBomb)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("  B ");
                        Console.ResetColor();
                    }
                   
                    else
                    {
                        if (cell.AdjacentBombs == 0)
                        {
                            Console.Write("  . ");
                        }
                        else if (cell.AdjacentBombs == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("  1 ");
                            Console.ResetColor();
                        }
                        else if (cell.AdjacentBombs == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("  2 ");
                            Console.ResetColor();
                        }
                        else if (cell.AdjacentBombs == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("  3 ");
                            Console.ResetColor();
                        }
                        else if (cell.AdjacentBombs == 4)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("  4 ");
                            Console.ResetColor();
                        }
                    }
                }
            }

            Console.Write("\n");

        }

        private static void PrintSelection(int row, int col, int selection, Board board, int rewardCount)
        {
           
            Cell cell = board.Cells[row, (col)];

            if (selection == 1)
            {
                cell.IsVisited = true;
                //this allows for a previously flagged space to be revealed after the user agrees
                if (cell.IsFlag)
                {
                    Console.WriteLine("Are you sure you want to reveal the flagged cell? 1 = yes, 2 = no.");
                    int flagVer = int.Parse(Console.ReadLine());
                    if (flagVer == 1)
                    {
                        cell.IsFlag = false;
                    }
                    else if (flagVer == 2)
                    {
                        cell.IsFlag = true;
                    }
                    else
                    {
                        Console.WriteLine("please enter a 1 for yes or a 2 for no.");
                    }
                    
                }

                PlayableBoard(board);
            }
            else if (selection == 2)
            {  
                cell.IsFlag = true;
                
                PlayableBoard(board);
            }
            else if (selection == 3)
            {
               
                if (rewardCount <= 2)
                {
                    if (cell.IsBomb)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Look out... row " + (row + 1) + " and column " + (col + 1) + " is a bomb!");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("Row " + (row + 1) + " and column " + (col + 1) + " is not a bomb!");
                    }
                }
                else
                {
                    Console.WriteLine("You have already used sneak peek 2 times this game!");
                }
            }
        }
    }
}

