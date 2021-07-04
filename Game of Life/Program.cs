using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the No of Rows:");
            int height = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the No of Columns:");
            int width = Convert.ToInt32(Console.ReadLine());
            int[,] board = new int[width,height];
            Console.WriteLine("Enter the data for matrix:");
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    board[i,j] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the no of Generations to process:");            
            int nGeneration = Convert.ToInt32(Console.ReadLine());
            GameOfLife(board, nGeneration);
        }

        public static void GameOfLife(int[,] board, int nGeneration)
        {
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);
            if (rows < 0)
                Console.WriteLine("Displaying data for the Generation: " + board);

            (int dx, int dy)[] directions = new (int dx, int dy)[]
            {
                (0,1),
                (0,-1),
                (1,0),
                (-1,0),
                (1,1),
                (1,-1),
                (-1,1),
                (-1,-1)
            };

            for(int k=1; k <= nGeneration; k++)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        int liveCount = 0;
                        foreach (var dir in directions)
                        {
                            int dirX = i + dir.dx;
                            int dirY = j + dir.dy;

                            if (dirX >= 0 && dirX < rows && dirY >= 0 && dirY < columns)
                            {
                                if (board[dirX, dirY] == 1 || board[dirX, dirY] == 3)
                                {
                                    liveCount++;
                                }
                            }
                        }


                        if (board[i, j] == 0)
                        {
                            if (liveCount == 3)
                            {
                                board[i, j] = 2;
                            }
                            continue;
                        }

                        if (liveCount < 2)
                        {
                            board[i, j] = 3;
                            continue;
                        }

                        if (liveCount > 3)
                        {
                            board[i, j] = 3;
                        }
                    }
                }
                swapValuetoOriginal(board, rows, columns);
                Console.WriteLine("Displaying data for the Generation: " + k + '\n');
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        Console.Write(string.Format("{0} ", board[i, j]));
                    }
                    Console.WriteLine(Environment.NewLine + Environment.NewLine);
                }
            }            
        }

        private static void swapValuetoOriginal(int [,] board, int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (board[i, j] == 2)
                    {
                        board[i, j] = 1;
                        continue;
                    }

                    if (board[i, j] == 3)
                    {
                        board[i, j] = 0;
                        continue;
                    }
                }
            }
        }
    }
}
