using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public partial class GameForm : Form
    {
        private static int MAP_WIDTH = 10;
        private static int MAP_HEIGHT = 20;
        private static int CELL_SIZE = 50;

        private Shape currentShape;
        private Shape nextShape;
        private Shape[,] map;
        private int linesRemoved;
        private int score;
        private int Interval;
        private int FastInterval;
        private bool pause;

        public GameForm()
        {
            InitializeComponent();
            KeyUp += new KeyEventHandler(HandleKeyUp);
            KeyDown += new KeyEventHandler(HandleKeyDown);
            Init();
        }

        public void Init()
        {
            map = new Shape[MAP_HEIGHT, MAP_WIDTH];
            score = 0;
            linesRemoved = 0;
            currentShape = ShapeFactory.GenerateShape(3, 0);
            nextShape = ShapeFactory.GenerateShape(3, 0);
            SetInterval(400);
            label1.Text = "Score: " + score;
            label2.Text = "Lines: " + linesRemoved;

            gameTimer.Interval = Interval;
            gameTimer.Tick += new EventHandler(Update);
            gameTimer.Start();

            Invalidate();
        }

        private void NextShpae()
        {
            currentShape = nextShape;
            nextShape = ShapeFactory.GenerateShape(3, 0);
        }

        private void SetInterval(int val)
        {
            Interval = val;
            FastInterval = Interval / 3;
        }

        private void TogglePause()
        {
            pause = !pause;
            if(pause)
            {
                gameTimer.Stop();
            } else
            {
                gameTimer.Start();
            }
        }

        // Управление
        private void HandleKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == GameControls.KeysDown)
            {
                gameTimer.Interval = Interval;
            } else if(e.KeyCode == GameControls.KeysPause)
            {
                TogglePause();
            }
        }

        // Управление
        private void HandleKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == GameControls.KeysDown)
            {
                gameTimer.Interval = FastInterval;
            } else if(e.KeyCode == GameControls.KeysRotate)
            {
                if (!IsIntersects())
                {
                    ResetArea();
                    currentShape.RotateShape();
                    Merge();
                    Invalidate();
                }
            } else if(e.KeyCode == GameControls.KeysRight)
            {
                if (!CollideHor(1))
                {
                    ResetArea();
                    currentShape.MoveRight();
                    Merge();
                    Invalidate();
                }
            } else if(e.KeyCode == GameControls.KeysLeft)
            {
                if (!CollideHor(-1))
                {
                    ResetArea();
                    currentShape.MoveLeft();
                    Merge();
                    Invalidate();
                }
            }
        }

        // Отрисовка следующей фигуры
        public void ShowNextShape(Graphics graphics)
        {
            for (int i = 0; i < nextShape.Height; i++)
            {
                for (int j = 0; j < nextShape.Width; j++)
                {
                    if (nextShape.Figure[i, j] != 0)
                    {
                        graphics.FillRectangle(nextShape.ShapeBrush, new Rectangle(800 + j * CELL_SIZE, CELL_SIZE + i * CELL_SIZE, CELL_SIZE, CELL_SIZE));
                    }
                }
            }
        }

        private void Update(object sender, EventArgs e)
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
                gameTimer.Interval = Interval;
                NextShpae();
                if (Collide())
                {
                    ClearMap();
                    gameTimer.Tick -= new EventHandler(Update);
                    gameTimer.Stop();
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
            for (int i = 0; i < MAP_HEIGHT; i++)
            {
                count = 0;
                for (int j = 0; j < MAP_WIDTH; j++)
                {
                    if (map[i, j] != null)
                        count++;
                }
                if (count == MAP_WIDTH)
                {
                    curRemovedLines++;
                    for (int k = i; k >= 1; k--)
                    {
                        for (int o = 0; o < MAP_WIDTH; o++)
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
                    SetInterval(Interval - 10);
            }

            label1.Text = "Score: " + score;
            label2.Text = "Lines: " + linesRemoved;
        }

        public bool IsIntersects()
        {
            for (int i = currentShape.Y; i < currentShape.Y + currentShape.Height; i++)
            {
                for (int j = currentShape.X; j < currentShape.X + currentShape.Width; j++)
                {
                    if (j >= 0 && j < MAP_WIDTH)
                    {
                        if (map[i, j] != null && currentShape.Figure[i - currentShape.Y, j - currentShape.X] == 0)
                            return true;
                    }
                }
            }
            return false;
        }

        // Синхронизация фигур с картой
        public void Merge()
        {
            for (int i = currentShape.Y; i < currentShape.Y + currentShape.Height; i++)
            {
                for (int j = currentShape.X; j < currentShape.X + currentShape.Width; j++)
                {
                    if (currentShape.Figure[i - currentShape.Y, j - currentShape.X] != 0)
                        if (currentShape.Figure[i - currentShape.Y, j - currentShape.X] != 0)
                        {
                            map[i, j] = currentShape;
                        }
                        else
                        {
                            map[i, j] = null;
                        }
                }
            }
        }

        // Проверка на наличие припятствия внизу
        public bool Collide()
        {
            for (int i = currentShape.Y + currentShape.Height - 1; i >= currentShape.Y; i--)
            {
                for (int j = currentShape.X; j < currentShape.X + currentShape.Width; j++)
                {
                    if (currentShape.Figure[i - currentShape.Y, j - currentShape.X] != 0)
                    {
                        if (i + 1 == MAP_HEIGHT)
                            return true;
                        if (map[i + 1, j] != null)
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
            for (int i = currentShape.Y; i < currentShape.Y + currentShape.Height; i++)
            {
                for (int j = currentShape.X; j < currentShape.X + currentShape.Width; j++)
                {
                    if (currentShape.Figure[i - currentShape.Y, j - currentShape.X] != 0)
                    {
                        if (j + 1 * dir > MAP_WIDTH - 1 || j + 1 * dir < 0)
                            return true;

                        if (map[i, j + 1 * dir] != null)
                        {
                            if (j - currentShape.X + 1 * dir >= currentShape.Height || j - currentShape.X + 1 * dir < 0)
                            {
                                return true;
                            }
                            if (currentShape.Figure[i - currentShape.Y, j - currentShape.X + 1 * dir] == 0)
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
            for (int i = currentShape.Y; i < currentShape.Y + currentShape.Height; i++)
            {
                for (int j = currentShape.X; j < currentShape.X + currentShape.Width; j++)
                {
                    if (i >= 0 && j >= 0 && i < MAP_HEIGHT && j < MAP_WIDTH)
                    {
                        if (currentShape.Figure[i - currentShape.Y, j - currentShape.X] != 0)
                        {
                            map[i, j] = null;
                        }
                    }
                }
            }
        }

        // Отрисовка фигур
        public void DrawMap(Graphics graphics)
        {
            for (int i = 0; i < MAP_HEIGHT; i++)
            {
                for (int j = 0; j < MAP_WIDTH; j++)
                {
                    if (map[i, j] != null)
                    {
                        graphics.FillRectangle(map[i, j].ShapeBrush, new Rectangle(CELL_SIZE + j * CELL_SIZE, CELL_SIZE + i * CELL_SIZE, CELL_SIZE, CELL_SIZE));
                    }
                }
            }
        }

        // Отрисовка поля
        public void DrawGrid(Graphics g)
        {
            for (int i = 0; i <= MAP_HEIGHT; i++)
            {
                g.DrawLine(Pens.Black, new Point(CELL_SIZE, CELL_SIZE + i * CELL_SIZE), new Point(CELL_SIZE + MAP_WIDTH * CELL_SIZE, CELL_SIZE + i * CELL_SIZE));
            }
            for (int i = 0; i <= MAP_WIDTH; i++)
            {
                g.DrawLine(Pens.Black, new Point(CELL_SIZE + i * CELL_SIZE, CELL_SIZE), new Point(CELL_SIZE + i * CELL_SIZE, CELL_SIZE + MAP_HEIGHT * CELL_SIZE));
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            DrawMap(e.Graphics);
            DrawGrid(e.Graphics);
            ShowNextShape(e.Graphics);
        }

        public void ClearMap()
        {
            for (int i = 0; i < MAP_HEIGHT; i++)
            {
                for (int j = 0; j < MAP_WIDTH; j++)
                {
                    map[i, j] = null;
                }
            }
        }
    }
}
