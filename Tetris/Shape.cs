using System;
using System.Drawing;

namespace Tetris
{
    class Shape
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public int[,] Figure { get; private set; }
        public Brush ShapeBrush { get; }

        public readonly int Height;
        public readonly int Width;

        public Shape(int x, int y, int[,] figure, Brush brush)
        {
            X = x;
            Y = y;
            Figure = figure;
            ShapeBrush = brush;
            Height = Figure.GetLength(0);
            Width = Figure.GetLength(1);
        }

        public void MoveDown()
        {
            Y++;
        }
        public void MoveRight()
        {
            X++;
        }
        public void MoveLeft()
        {
            X--;
        }

        // Повороты фигур
        public void RotateShape()
        {
            int[,] tempMatrix = new int[Figure.GetLength(0), Figure.GetLength(1)];
            for (int i = 0; i < Figure.GetLength(0); i++)
            {
                for (int j = 0; j < Figure.GetLength(1); j++)
                {
                    tempMatrix[i, j] = Figure[j, (Figure.GetLength(1) - 1) - i];
                }
            }
            Figure = tempMatrix;
            int offset1 = 8 - (X + Figure.GetLength(0));
            if (offset1 < 0)
            {
                for (int i = 0; i < Math.Abs(offset1); i++)
                    MoveLeft();
            }

            if (X < 0)
            {
                for (int i = 0; i < Math.Abs(X) + 1; i++)
                    MoveRight();
            }
        }
    }
}
