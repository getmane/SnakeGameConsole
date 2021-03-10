using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeConsoleUI
{
    public static class SnakeGame
    {
        public static void Start(string[,] gameField, int gameSpeed,
            ConsoleColor snakeHeadColor, ConsoleColor snakeBodyColor,
            ConsoleColor fieldColor, ConsoleColor pointColor)
        {
            Random random = new Random();

            SnakeModel snake = new SnakeModel();

            SnakeGamePoints point = new SnakeGamePoints();

            point.X = random.Next(1, gameField.GetLength(1) - 1);
            point.Y = random.Next(1, gameField.GetLength(1) - 1);

            snake.Body.Add(new SnakeModelBodyPart());

            Console.SetCursorPosition(point.X, point.Y);
            

            while (Console.CursorLeft != gameField.GetLength(1) - 1
                && Console.CursorTop != gameField.GetLength(1) - 1
                && Console.CursorLeft != -1
                && Console.CursorTop != -1)
            {

                Task.Run(() => SnakeGameLogic.GameControls(snake));

                SnakeGameLogic.GameMovement(snake, gameSpeed);

                Console.ResetColor();
                Console.Clear();

                SnakeGameField.Draw(gameField, fieldColor);

                Console.SetCursorPosition(point.X, point.Y);
                Console.BackgroundColor = pointColor;
                Console.WriteLine(point.Fragment, Console.BackgroundColor);

                foreach (var piece in snake.Body)
                {
                    Console.SetCursorPosition(piece.X, piece.Y);
                    if (piece.X == snake.Body.First().X && piece.Y == snake.Body.First().Y)
                    {
                        Console.BackgroundColor = snakeHeadColor;
                    }
                    else
                    {
                        Console.BackgroundColor = snakeBodyColor;
                    }
                    Console.WriteLine(piece.Fragment, Console.BackgroundColor);

                }
                Console.ResetColor();
                Console.SetCursorPosition(snake.Body.First().X, snake.Body.First().Y);

                if (snake.Body.First().X == point.X && snake.Body.First().Y == point.Y)
                {
                    point.X = random.Next(1, gameField.GetLength(1) - 1);
                    point.Y = random.Next(1, gameField.GetLength(1) - 1);
                    snake.Body.Add(new SnakeModelBodyPart());
                }

                for (int i = 1; i <= snake.Body.Count() - 1; i++)
                {
                    if (Console.CursorLeft == snake.Body[i].prevX && Console.CursorTop == snake.Body[i].prevY)
                    {
                        Console.Clear();
                        Console.WriteLine("Game over");
                        break;
                    }
                }

                if (Console.CursorLeft == gameField.GetLength(1) - 1
                    || Console.CursorTop == gameField.GetLength(1) - 1
                    || Console.CursorLeft == 0
                    || Console.CursorTop == 0)
                {
                    Console.ResetColor();
                    Console.Clear();
                    Console.WriteLine("Game over");
                    break;
                }

            }
        }
    }
}
