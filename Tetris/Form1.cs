using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form
    {
        Shape currentShape;
        int size;
        int[,] map = new int[20, 10];
        int linesRemoved;
        int score;
        int Interval;
        public Form1()
        {
            InitializeComponent();
            this.KeyUp += new KeyEventHandler(keyFunc);
            Init();
        }

        public void Init()
        {
            size = 50;
            score = 0;
            linesRemoved = 0;
            currentShape = new Shape(3, 0);
            Interval = 300;
            label1.Text = "Score: " + score;
            label2.Text = "Lines: " + linesRemoved;



            timer1.Interval = Interval;
            timer1.Tick += new EventHandler(update);
            timer1.Start();


            Invalidate();
        }

        // Управление
        private void keyFunc(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    if (!IsIntersects())
                    {
                        ResetArea();
                        currentShape.RotateShape();
                        Merge();
                        Invalidate();
                    }
                    break;
                case Keys.S:
                    timer1.Interval = 10;
                    break;
                case Keys.D:
                    if (!CollideHor(1))
                    {
                        ResetArea();
                        currentShape.MoveRight();
                        Merge();
                        Invalidate();
                    }
                    break;
                case Keys.A:
                    if (!CollideHor(-1))
                    {
                        ResetArea();
                        currentShape.MoveLeft();
                        Merge();
                        Invalidate();
                    }
                    break;
            }
        }

        // Отрисовка следующей фигуры
        public void ShowNextShape(Graphics graphics)
        {
            for (int i = 0; i < currentShape.sizeNextMatrix; i++)
            {
                for (int j = 0; j < currentShape.sizeNextMatrix; j++)
                {
                    if (currentShape.nextMatrix[i, j] == 1)
                    {
                        graphics.FillRectangle(Brushes.Red, new Rectangle(800 + j * size, 50 + i * size, size, size));
                    }
                    if (currentShape.nextMatrix[i, j] == 2)
                    {
                        graphics.FillRectangle(Brushes.Green, new Rectangle(800 + j * size, 50 + i * size, size, size));
                    }
                    if (currentShape.nextMatrix[i, j] == 3)
                    {
                        graphics.FillRectangle(Brushes.Yellow, new Rectangle(800 + j * size, 50 + i * size, size, size));
                    }
                    if (currentShape.nextMatrix[i, j] == 4)
                    {
                        graphics.FillRectangle(Brushes.Purple, new Rectangle(800 + j * size, 50 + i * size, size, size));
                    }
                    if (currentShape.nextMatrix[i, j] == 5)
                    {
                        graphics.FillRectangle(Brushes.Blue, new Rectangle(800 + j * size, 50 + i * size, size, size));
                    }
                    if (currentShape.nextMatrix[i, j] == 6)
                    {
                        graphics.FillRectangle(Brushes.Pink, new Rectangle(800 + j * size, 50 + i * size, size, size));
                    }
                    if (currentShape.nextMatrix[i, j] == 7)
                    {
                        graphics.FillRectangle(Brushes.Black, new Rectangle(800 + j * size, 50 + i * size, size, size));
                    }
                }
            }
        }

        private void update(object sender, EventArgs e)
        {
            ResetArea();
            if (!Collide())
            {
                currentShape.MoveDown();
            }
            else
            {
                Merge();
                SliceMap();
                timer1.Interval = Interval;
                currentShape.ResetShape(3, 0);
                if (Collide())
                {
                    ClearMap();
                    timer1.Tick -= new EventHandler(update);
                    timer1.Stop();
                    MessageBox.Show("Ваш результат: " + score);
                    Init();
                }
            }
            Merge();
            Invalidate();
        }

        // Подсчет очков и линий при сборе блоков в линию
        public void SliceMap()
        {
            int count = 0;
            int curRemovedLines = 0;
            for (int i = 0; i < 20; i++)
            {
                count = 0;
                for (int j = 0; j < 10; j++)
                {
                    if (map[i, j] != 0)
                        count++;
                }
                if (count == 10)
                {
                    curRemovedLines++;
                    for (int k = i; k >= 1; k--)
                    {
                        for (int o = 0; o < 10; o++)
                        {
                            map[k, o] = map[k - 1, o];
                        }
                    }
                }
            }
            for (int i = 0; i < curRemovedLines; i++)
            {
                score += 10 * (i + 1);
            }
            linesRemoved += curRemovedLines;

            if (linesRemoved % 5 == 0)
            {
                if (Interval > 60)
                    Interval -= 10;
            }

            label1.Text = "Score: " + score;
            label2.Text = "Lines: " + linesRemoved;
        }

        public bool IsIntersects()
        {
            for (int i = currentShape.y; i < currentShape.y + currentShape.sizeMatrix; i++)
            {
                for (int j = currentShape.x; j < currentShape.x + currentShape.sizeMatrix; j++)
                {
                    if (j >= 0 && j <= 9)
                    {
                        if (map[i, j] != 0 && currentShape.matrix[i - currentShape.y, j - currentShape.x] == 0)
                            return true;
                    }
                }
            }
            return false;
        }

        // Синхронизация фигур с картой
        public void Merge()
        {
            for (int i = currentShape.y; i < currentShape.y + currentShape.sizeMatrix; i++)
            {
                for (int j = currentShape.x; j < currentShape.x + currentShape.sizeMatrix; j++)
                {
                    if (currentShape.matrix[i - currentShape.y, j - currentShape.x] != 0)
                        map[i, j] = currentShape.matrix[i - currentShape.y, j - currentShape.x];
                }
            }
        }

        // Проверка на наличие припятствия внизу
        public bool Collide()
        {
            for (int i = currentShape.y + currentShape.sizeMatrix - 1; i >= currentShape.y; i--)
            {
                for (int j = currentShape.x; j < currentShape.x + currentShape.sizeMatrix; j++)
                {
                    if (currentShape.matrix[i - currentShape.y, j - currentShape.x] != 0)
                    {
                        if (i + 1 == 20)
                            return true;
                        if (map[i + 1, j] != 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        // Проверка на наличие припятствия по боком
        public bool CollideHor(int dir)
        {
            for (int i = currentShape.y; i < currentShape.y + currentShape.sizeMatrix; i++)
            {
                for (int j = currentShape.x; j < currentShape.x + currentShape.sizeMatrix; j++)
                {
                    if (currentShape.matrix[i - currentShape.y, j - currentShape.x] != 0)
                    {
                        if (j + 1 * dir > 9 || j + 1 * dir < 0)
                            return true;

                        if (map[i, j + 1 * dir] != 0)
                        {
                            if (j - currentShape.x + 1 * dir >= currentShape.sizeMatrix || j - currentShape.x + 1 * dir < 0)
                            {
                                return true;
                            }
                            if (currentShape.matrix[i - currentShape.y, j - currentShape.x + 1 * dir] == 0)
                                return true;
                        }
                    }
                }
            }
            return false;
        }

        // Очещение карты от куска фигуры при перемещении
        public void ResetArea()
        {
            for (int i = currentShape.y; i < currentShape.y + currentShape.sizeMatrix; i++)
            {
                for (int j = currentShape.x; j < currentShape.x + currentShape.sizeMatrix; j++)
                {
                    if (i >= 0 && j >= 0 && i < 20 && j < 10)
                    {
                        if (currentShape.matrix[i - currentShape.y, j - currentShape.x] != 0)
                        {
                            map[i, j] = 0;
                        }
                    }
                }
            }
        }

        // Отрисовка фигур
        public void DrawMap(Graphics graphics)
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (map[i, j] == 1)
                    {
                        graphics.FillRectangle(Brushes.Red, new Rectangle(50 + j * size, 50 + i * size, size, size));
                    }
                    if (map[i, j] == 2)
                    {
                        graphics.FillRectangle(Brushes.Green, new Rectangle(50 + j * size, 50 + i * size, size, size));
                    }
                    if (map[i, j] == 3)
                    {
                        graphics.FillRectangle(Brushes.Yellow, new Rectangle(50 + j * size, 50 + i * size, size, size));
                    }
                    if (map[i, j] == 4)
                    {
                        graphics.FillRectangle(Brushes.Purple, new Rectangle(50 + j * size, 50 + i * size, size, size));
                    }
                    if (map[i, j] == 5)
                    {
                        graphics.FillRectangle(Brushes.Blue, new Rectangle(50 + j * size, 50 + i * size, size, size));
                    }
                    if (map[i, j] == 6)
                    {
                        graphics.FillRectangle(Brushes.Pink, new Rectangle(50 + j * size, 50 + i * size, size, size));
                    }
                    if (map[i, j] == 7)
                    {
                        graphics.FillRectangle(Brushes.Black, new Rectangle(50 + j * size, 50 + i * size, size, size));
                    }
                }
            }
        }

        // Отрисовка поля
        public void DrawGrid(Graphics g)
        {
            for (int i = 0; i <= 20; i++)
            {
                g.DrawLine(Pens.Black, new Point(50, 50 + i * size), new Point(50 + 10 * size, 50 + i * size));
            }
            for (int i = 0; i <= 10; i++)
            {
                g.DrawLine(Pens.Black, new Point(50 + i * size, 50), new Point(50 + i * size, 50 + 20 * size));
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            DrawGrid(e.Graphics);
            DrawMap(e.Graphics);
            ShowNextShape(e.Graphics);
        }

        public void ClearMap()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    map[i, j] = 0;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
