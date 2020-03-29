using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Adele
{
    class Program
    {
        static void Main()
        {

            Highscore highscore = new Highscore();
            bool gameOn = true;

            while (gameOn)
            {
                Console.Clear();
                Game game = new Game();
                Console.Write("1) Play\n2) Score \n3) Exit\n \n \n");
                string input = Console.ReadLine().ToLower();

                Random random = new Random();

                Console.CursorVisible = false;

                switch (input)
                {
                    case "1":
                    case "play":
                        Console.Clear();
                        Console.Write("Enter player name: ");
                        string name = Console.ReadLine();

                        Player player = new Player(name, 0);

                        Console.WriteLine("\nChoose difficulty:\n1)Easy\n2)Hardcore\n");
                        string difficulty = Console.ReadLine();
                        switch (difficulty)
                        {
                            case "2":
                            case "hardcore":
                                game.gameSpeed = 25;
                                break;
                            default:
                                break;
                        }

                        Console.Clear();
                        game.Play();
                        player.Score = game.applesEaten;
                        highscore.TopTen.Add(player);

                        break;

                    case "2":
                    case "score":
                        Console.Clear();
                        // game.HighScore();
                        highscore.ShowHighscore();
                        break;

                    case "3":
                    case "exit":
                        Console.Clear();
                        gameOn = false;
                        break;

                    default:

                        break;
                }
            }


        }
    }
}
