using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeConsoleUI
{
    public static class SnakeGameField
    { 
        public static void Fill(string[,] gameField)
        {
            for (int i = 0; i < gameField.GetLength(1); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    if (i == 0 || i == gameField.GetLength(1) - 1)
                    {
                        gameField[i, j] = " ";
                    }
                    else if (j == 0 || j == gameField.GetLength(1) - 1)
                    {
                        gameField[i, j] = " ";
                    }
                    else
                    {
                        gameField[i, j] = "*";
                    }

                }
            }
        }
        public static void Draw(string[,] gameField, ConsoleColor fieldColor)
        {
            for (int i = 0; i < gameField.GetLength(1); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    if (gameField[i, j] == " ")
                    {
                        Console.SetCursorPosition(i, j);
                        Console.BackgroundColor = fieldColor;
                        Console.Write(gameField[i, j], Console.BackgroundColor);
                    }
                }
            }
            
        }
    }
}
