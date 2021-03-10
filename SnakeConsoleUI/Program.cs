using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeConsoleUI
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Random random = new Random();

            string[,] gameField = new string[30, 30];

            int gameSpeed = 50;

            ConsoleColor snakeHeadColor = ConsoleColor.Blue;
            ConsoleColor snakeBodyColor = ConsoleColor.White;
            ConsoleColor fieldColor = ConsoleColor.White;
            ConsoleColor pointColor = ConsoleColor.Red;


            SnakeGameField.Fill(gameField);
            SnakeGameField.Draw(gameField, fieldColor);

            SnakeGame.Start(gameField, gameSpeed, 
                snakeHeadColor, snakeBodyColor, 
                fieldColor, pointColor);

            Console.SetCursorPosition(0, 1);

        }   

    }
}
