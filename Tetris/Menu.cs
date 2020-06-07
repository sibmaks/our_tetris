using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();

        
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            Tetris form = new Tetris();
            form.ShowDialog();
        }

        private void BtnSetting_Click(object sender, EventArgs e)
        {
            Setting SettingForm = new Setting();
            SettingForm.ShowDialog();
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            About AboutForm = new About();
            AboutForm.ShowDialog();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
