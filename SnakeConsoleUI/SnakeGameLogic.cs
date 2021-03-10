using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeConsoleUI
{
    public static class SnakeGameLogic
    {
        public static void GameControls(SnakeModel snake)
        {

            var input = Console.ReadKey().Key;
            switch (input)
            {
                case ConsoleKey.DownArrow:
                    snake.Body.First().Direction = ConsoleKey.DownArrow;
                    break;
                case ConsoleKey.UpArrow:
                    snake.Body.First().Direction = ConsoleKey.UpArrow;

                    break;
                case ConsoleKey.LeftArrow:
                    snake.Body.First().Direction = ConsoleKey.LeftArrow;

                    break;
                case ConsoleKey.RightArrow:
                    snake.Body.First().Direction = ConsoleKey.RightArrow;
                    break;
            }

        }
        public static void GameMovement(SnakeModel snake, int gameSpeed)
        {
            snake.Body.First().prevY = snake.Body.First().Y;
            snake.Body.First().prevX = snake.Body.First().X;

            switch (snake.Body.First().Direction)
            {
                case ConsoleKey.DownArrow:
                    snake.Body.First().Y = snake.Body.First().Y + 1;
                    break;
                case ConsoleKey.RightArrow:
                    snake.Body.First().X = snake.Body.First().X + 1;
                    break;
                case ConsoleKey.UpArrow:
                    snake.Body.First().Y = snake.Body.First().Y - 1;
                    break;
                case ConsoleKey.LeftArrow:
                    snake.Body.First().X = snake.Body.First().X - 1;
                    break;
            }

            for (int i = 1; i <= snake.Body.Count() - 1; i++)
            {
                snake.Body[i].prevX = snake.Body[i].X;
                snake.Body[i].prevY = snake.Body[i].Y;
                snake.Body[i].X = snake.Body[i - 1].prevX;
                snake.Body[i].Y = snake.Body[i - 1].prevY;

            }

            Thread.Sleep(gameSpeed);
        }
    }
}
