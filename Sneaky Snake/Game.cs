using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Adele
{
    class Game
    {

        Random random = new Random();
        int[] xPosition;
        int[] yPosition;
        int appleXDim;
        int appleYDim;
        public int applesEaten;
        public decimal gameSpeed;
        bool isGameOn;
        bool isWallHit;
        bool isAppleEaten;

        public Game()
        {


            xPosition = new int[50];
            xPosition[0] = 17;

            yPosition = new int[50];
            yPosition[0] = 10;

            appleXDim = 10;
            appleYDim = 10;
            applesEaten = 0;

            gameSpeed = 150;

            isGameOn = true;
            isWallHit = false;
            isAppleEaten = false;
        }


        public void Play()
        {

            setApplePositionOnScreen(random, out appleXDim, out appleYDim);
            paintApple(appleXDim, appleYDim);
            paintSnake(applesEaten, xPosition, yPosition, out xPosition, out yPosition);
            buildWall();

            ConsoleKey command = Console.ReadKey().Key;

            do
            {
                switch (command)
                {
                    case ConsoleKey.LeftArrow:
                        Console.SetCursorPosition(xPosition[0], yPosition[0]);
                        Console.Write(" ");
                        xPosition[0]--;
                        break;

                    case ConsoleKey.UpArrow:
                        Console.SetCursorPosition(xPosition[0], yPosition[0]);
                        Console.Write(" ");
                        yPosition[0]--;
                        break;

                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(xPosition[0], yPosition[0]);
                        Console.Write(" ");
                        xPosition[0]++;
                        break;

                    case ConsoleKey.DownArrow:
                        Console.SetCursorPosition(xPosition[0], yPosition[0]);
                        Console.Write(" ");
                        yPosition[0]++;
                        break;
                }


                paintSnake(applesEaten, xPosition, yPosition, out xPosition, out yPosition);

                isWallHit = DidSnakeHitWall(xPosition[0], yPosition[0]);

                if (isWallHit)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Game over. Your score: {0}\n\nPress ENTER to return to menu.", applesEaten);
                    Console.Read();

                    isGameOn = false;

                }

                // Vai ābolītis apēsts
                isAppleEaten = determineIfAppleWasEaten(xPosition[0], yPosition[0], appleXDim, appleYDim);


                // Attēlo ābolīti laukumā
                if (isAppleEaten)
                {
                    setApplePositionOnScreen(random, out appleXDim, out appleYDim);
                    paintApple(appleXDim, appleYDim);
                    applesEaten++;
                    gameSpeed *= .8m;
                }

                Console.SetCursorPosition(1, 20);
                showScore();

                if (Console.KeyAvailable) command = Console.ReadKey().Key;
                System.Threading.Thread.Sleep(Convert.ToInt32(gameSpeed));

            } while (isGameOn);
        }

        private void showScore()
        {
            int score = applesEaten;
            Console.Write("\n\nScore: {0}", score);
        }

        private static void paintSnake(int applesEaten, int[] xPositionIn, int[] yPositionIn, out int[] xPositionOut, out int[] yPositionOut)
        {
            // čūskas galva
            Console.SetCursorPosition(xPositionIn[0], yPositionIn[0]);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine('Ö');

            // čūskas aste
            for (int i = 1; i < applesEaten + 1; i++)
            {
                Console.SetCursorPosition(xPositionIn[i], yPositionIn[i]);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine('o');
            }

            // dzēš astes galu
            Console.SetCursorPosition(xPositionIn[applesEaten + 1], yPositionIn[applesEaten + 1]);
            Console.WriteLine(' ');

            // čūskas ķermeņa lokācija
            for (int i = applesEaten + 1; i > 0; i--)
            {
                xPositionIn[i] = xPositionIn[i - 1];
                yPositionIn[i] = yPositionIn[i - 1];
            }

            // return the new array
            xPositionOut = xPositionIn;
            yPositionOut = yPositionIn;
        }

        private static bool determineIfAppleWasEaten(int xPosition, int yPosition, int appleXDim, int appleYDim)
        {
            if (xPosition == appleXDim && yPosition == appleYDim) return true; return false;
        }

        private static void paintApple(int appleXDim, int appleYDim)
        {
            Console.SetCursorPosition(appleXDim, appleYDim);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write('@');
        }

        private static void setApplePositionOnScreen(Random random, out int appleXDim, out int appleYDim)
        {
            appleXDim = random.Next(0 + 2, 34 - 2);
            appleYDim = random.Next(0 + 2, 20 - 2);
        }

        private static bool DidSnakeHitWall(int xPosition, int yPosition)
        {
            if (xPosition == 1 || xPosition == 34 || yPosition == 1 || yPosition == 20) return true; return false;
        }

        private static void buildWall()
        {
            for (int i = 1; i < 21; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(1, i);
                Console.Write("#");
                Console.SetCursorPosition(34, i);
                Console.Write("#");
            }

            for (int i = 1; i < 35; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(i, 1);
                Console.Write("#");
                Console.SetCursorPosition(i, 20);
                Console.Write("#");
            }
        }
    }
}
