using Microsoft.Win32;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Tetris
{
    public partial class GameForm : Form
    {
        private static int NEXT_FIG_WIDTH = 100;
        private static int NEXT_FIG_HEIGHT = 100;

        public static int MAP_WIDTH = 10;
        private static int MAP_HEIGHT = 20;
        private static int CELL_SIZE = 25;

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
            RegisterFont("19490.otf");
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
            label1.Text = "" + score;
            label2.Text = "" + linesRemoved;

            gameTimer.Interval = Interval;
            gameTimer.Tick += new EventHandler(Update);
            gameTimer.Start();

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, gamePanel, new object[] { true });
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, nextFigurePanel, new object[] { true });

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
            if (pause)
            {
                pauseLabel.Visible = true;
                gameTimer.Stop();
            }
            else
            {
                pauseLabel.Visible = false;
                gameTimer.Start();
            }
        }

        // Управление
        private void HandleKeyUp(object sender, KeyEventArgs e)
        {
            if (!pause && e.KeyCode == GameControls.KeysDown)
            {
                gameTimer.Interval = Interval;
            }
            else if (e.KeyCode == GameControls.KeysPause)
            {
                TogglePause();
            }
        }

        // Управление
        private void HandleKeyDown(object sender, KeyEventArgs e)
        {
            if (!pause && e.KeyCode == GameControls.KeysDown)
            {
                gameTimer.Interval = FastInterval;
            }
            else if (!pause && e.KeyCode == GameControls.KeysRotate)
            {
                if (!IsIntersects())
                {
                    ResetArea();
                    currentShape.RotateShape();
                    Merge();
                    gamePanel.Refresh();
                }
            }
            else if (!pause && e.KeyCode == GameControls.KeysRight)
            {
                if (!CollideHor(1))
                {
                    ResetArea();
                    currentShape.MoveRight();
                    Merge();
                    gamePanel.Refresh();
                }
            }
            else if (!pause && e.KeyCode == GameControls.KeysLeft)
            {
                if (!CollideHor(-1))
                {
                    ResetArea();
                    currentShape.MoveLeft();
                    Merge();
                    gamePanel.Refresh();
                }
            }
        }

        // Отрисовка следующей фигуры
        public void ShowNextShape(Graphics graphics)
        {
            int offsetX = (NEXT_FIG_WIDTH - nextShape.RealWidth * CELL_SIZE) / 2;
            int offsetY = (NEXT_FIG_HEIGHT - nextShape.RealHeight * CELL_SIZE) / 2;
            
            for (int i = nextShape.RealTopOffset, y = 0; i < nextShape.RealTopOffset + nextShape.RealHeight; i++, y++)
            {
                for (int j = nextShape.RealLeftOffset, x = 0; j < nextShape.RealLeftOffset + nextShape.RealWidth; j++, x++)
                {
                    if (nextShape.Figure[i, j] != 0)
                    {
                        graphics.FillRectangle(nextShape.ShapeBrush, new Rectangle(offsetX + x * CELL_SIZE, offsetY + y * CELL_SIZE, CELL_SIZE, CELL_SIZE));
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
            nextFigurePanel.Refresh();
            gamePanel.Refresh();
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
                    {
                        count++;
                    }
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
                {
                    SetInterval(Interval - 10);
                }
            }

            label1.Text = "" + score;
            label2.Text = "" + linesRemoved;
        }

        public bool IsIntersects()
        {
            int[,] rotatedMatrix = currentShape.GetRotateShape();
            for (int i = currentShape.Y, y = 0; i < currentShape.Y + currentShape.Height; i++, y++)
            {
                for (int j = currentShape.X, x = 0; j < currentShape.X + currentShape.Width; j++, x++)
                {
                    if (j >= 0 && j < MAP_WIDTH && i >= 0 && i < MAP_HEIGHT)
                    {
                        if (map[i, j] != null && map[i, j] != currentShape && rotatedMatrix[y, x] != 0)
                        {
                            return true;
                        }
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
                    if (i >= 0 && j >= 0 && i < MAP_HEIGHT && j < MAP_WIDTH)
                    {
                        if (currentShape.Figure[i - currentShape.Y, j - currentShape.X] != 0)
                        {
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
                        {
                            return true;
                        }
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

        [DllImport("gdi32.dll")]
        private static extern int AddFontResource(string lpszFilename);
        
        /// <summary>
        /// Installs font on the user's system and adds it to the registry so it's available on the next session
        /// Your font must be included in your project with its build path set to 'Content' and its Copy property
        /// set to 'Copy Always'
        /// </summary>
        /// <param name="contentFontName">Your font to be passed as a resource (i.e. "myfont.tff")</param>
        private static void RegisterFont(string contentFontName)
        {
            // Creates the full path where your font will be installed
            var fontDestination = Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts), contentFontName);

            if (!File.Exists(fontDestination))
            {
                // Copies font to destination
                File.Copy(Path.Combine(Directory.GetCurrentDirectory(), "Resources", contentFontName), fontDestination);

                // Retrieves font name
                // Makes sure you reference System.Drawing
                PrivateFontCollection fontCol = new PrivateFontCollection();
                fontCol.AddFontFile(fontDestination);
                var actualFontName = fontCol.Families[0].Name;

                //Add font
                AddFontResource(fontDestination);
                //Add registry entry   
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts", actualFontName, contentFontName, RegistryValueKind.String);
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
                        graphics.FillRectangle(map[i, j].ShapeBrush, new Rectangle(j * CELL_SIZE, i * CELL_SIZE, CELL_SIZE, CELL_SIZE));
                    }
                }
            }
        }

        // Отрисовка поля
        public void DrawGrid(Graphics g)
        {
            for (int i = 0; i <= MAP_HEIGHT; i++)
            {
                g.DrawLine(Pens.Black, new Point(0, CELL_SIZE + i * CELL_SIZE), new Point(MAP_WIDTH * CELL_SIZE, CELL_SIZE + i * CELL_SIZE));
            }
            for (int i = 0; i <= MAP_WIDTH; i++)
            {
                g.DrawLine(Pens.Black, new Point(i * CELL_SIZE, 0), new Point(i * CELL_SIZE, MAP_HEIGHT * CELL_SIZE));
            }
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

        private void NextFigurePanel_Paint(object sender, PaintEventArgs e)
        {
            ShowNextShape(e.Graphics);
        }

        private void GamePanel_Paint(object sender, PaintEventArgs e)
        {
            DrawMap(e.Graphics);
            DrawGrid(e.Graphics);
        }
    }
}
