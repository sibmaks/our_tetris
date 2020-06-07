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

        public int RealHeight;
        public int RealWidth;

        public int RealTopOffset { get; private set; }
        public int RealLeftOffset { get; private set; }


        public Shape(int x, int y, int[,] figure, Brush brush)
        {
            X = x;
            Y = y;
            Figure = figure;
            ShapeBrush = brush;
            Height = Figure.GetLength(0);
            Width = Figure.GetLength(1);
            CalcRealSizes();
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

        private void CalcRealSizes()
        {
            RealHeight = 0;
            RealTopOffset = -1;

            for (int i = 0; i < Height; i++)
            {
                int zeros = 0;
                for (int j = 0; j < Width; j++)
                {
                    if (Figure[i, j] == 0)
                    {
                        zeros++;
                    }
                }
                if (zeros < Width)
                {
                    RealHeight++;
                    if (RealTopOffset == -1)
                    {
                        RealTopOffset = i;
                    }
                }
            }

            RealWidth = 0;
            RealLeftOffset = -1;

            for (int j = 0; j < Width; j++)
            {
                int zeros = 0;
                for (int i = 0; i < Height; i++)
                {
                    if (Figure[i, j] == 0)
                    {
                        zeros++;
                    }
                }
                if (zeros < Height)
                {
                    RealWidth++;
                    if (RealLeftOffset == -1)
                    {
                        RealLeftOffset = j;
                    }
                }
            }
        }

        public int[,] GetRotateShape()
        {
            int[,] tempMatrix = new int[Width, Height];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    tempMatrix[i, j] = Figure[j, Width - 1 - i];
                }
            }
            return tempMatrix;
        }

        // Повороты фигур
        public void RotateShape()
        {
            Figure = GetRotateShape();
            int offset = Tetris.MAP_WIDTH - (X + Figure.GetLength(0));
            if (offset < 0)
            {
                X += offset;
            }
            if (X < 0)
            {
                X = 0;
            }
            CalcRealSizes();
        }
    }
}
