using System.Windows.Forms;

namespace Tetris
{
    public class GameControls
    {
        public static Keys KeysRotate { get; set; } = Keys.W;
        public static Keys KeysRight { get; set; } = Keys.D;
        public static Keys KeysLeft { get; set; } = Keys.A;
        public static Keys KeysDown { get; set; } = Keys.S;
        public static Keys KeysPause { get; set; } = Keys.F;
    }
}
