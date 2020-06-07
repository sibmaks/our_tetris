using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Setting : Form
    {
        private bool wadsPreset;

        public Setting()
        {
            InitializeComponent();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(wadsPreset)
            {
                GameControls.KeysRotate = Keys.W;
                GameControls.KeysLeft = Keys.A;
                GameControls.KeysDown = Keys.S;
                GameControls.KeysRight = Keys.D;
            }
            else
            {
                GameControls.KeysRotate = Keys.Up;
                GameControls.KeysLeft = Keys.Left;
                GameControls.KeysDown = Keys.Down;
                GameControls.KeysRight = Keys.Right;
            }

            if (PauseBox.SelectedItem.Equals("Space"))
            {
                GameControls.KeysPause = Keys.Space;
            }
            else if (PauseBox.SelectedItem.Equals("P"))
            {
                PauseBox.SelectedItem = "P";
                GameControls.KeysPause = Keys.P;
            }
            else if (PauseBox.SelectedItem.Equals("F"))
            {
                GameControls.KeysPause = Keys.F;
            }

            Hide();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            if(Keys.Space == GameControls.KeysPause)
            {
                PauseBox.SelectedItem = "Space";
            }
            else if (Keys.P == GameControls.KeysPause)
            {
                PauseBox.SelectedItem = "P";
            }
            else if (Keys.F == GameControls.KeysPause)
            {
                PauseBox.SelectedItem = "F";
            }

            if(Keys.W == GameControls.KeysRotate)
            {
                wadsPreset = true;
            } else
            {
                wadsPreset = false;
            }
            UpdateGamePreset();
        }

        private void UpdateGamePreset()
        {
            if (wadsPreset)
            {
                wasdButton.BackColor = Color.DarkBlue;
                arrowsButton.BackColor = Color.Transparent;
            }
            else
            {
                wasdButton.BackColor = Color.Transparent;
                arrowsButton.BackColor = Color.DarkBlue;
            }
        }

        private void wasdButton_Click(object sender, EventArgs e)
        {
            wadsPreset = true;
            UpdateGamePreset();
        }

        private void arrowsButton_Click(object sender, EventArgs e)
        {
            wadsPreset = false;
            UpdateGamePreset();
        }
    }
}
