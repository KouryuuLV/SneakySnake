using System;

// Starting material for exercise taken form https://www.gamedev.net/blogs/entry/2266700-c-console-snake-game/
// https://www.youtube.com/watch?v=gfkTfcpWqAY
namespace Snakegame
{
    class Program
    {
        static void Main(string[] args)
        {
            const int board_size = 17;
            char[,] board = new char[board_size, board_size];
            int horizontal = 5, vertical = 8, count = 0;

            for (int i = 0; i < board_size; i++)
            {
                for (int j = 0; j < board_size; j++)
                {
                    board[i, j] = '.';
                }
            }

            void draw_board()
            {
                for (int i = 0; i < board_size; i++)
                {
                    for (int j = 0; j < board_size; j++)
                    {
                        Console.Write(board[i, j]);
                    }
                    Console.WriteLine();
                }
            }

            while (count < 12)
            {
                if (count >= 0 && count < 6)
                {
                    board[vertical, horizontal] = '*';
                    board[vertical, horizontal + 1] = '*';
                    board[vertical, horizontal + 2] = '*';
                    board[vertical, horizontal + 3] = '*';
                    board[vertical, horizontal + 4] = '*';
                    board[vertical, horizontal + 5] = '*';
                    board[vertical, horizontal + 6] = '*';

                    draw_board();

                    horizontal++;
                }

                if (count > 5 && count < 12)
                {
                    board[vertical, horizontal] = '*';
                    board[vertical + 1, horizontal] = '*';
                    board[vertical + 2, horizontal] = '*';
                    board[vertical + 3, horizontal] = '*';
                    board[vertical + 4, horizontal] = '*';
                    board[vertical + 5, horizontal] = '*';
                    board[vertical + 6, horizontal] = '*';

                    draw_board();

                    vertical++;
                }

                count++;

                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("For Next step press <Enter>");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
