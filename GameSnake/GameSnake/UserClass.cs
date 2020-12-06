using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameSnake
{
    public static class UserClass
    {
        //保存玩家按键
        public static Keys key = Keys.Right;
        public static void UserKey(Keys k)
        {
            if (key != k)
            {
                switch (k)
                {
                    case Keys.Down:
                        if (SnakeClass.k != Keys.Up && SnakeClass.k != Keys.Down)
                            key = Keys.Down;
                        break;
                    case Keys.Up:
                        if (SnakeClass.k != Keys.Down && SnakeClass.k != Keys.Up)
                            key = Keys.Up;
                        break;
                    case Keys.Left:
                        if (SnakeClass.k != Keys.Right && SnakeClass.k != Keys.Left)
                            key = Keys.Left;
                        break;
                    case Keys.Right:
                        if (SnakeClass.k != Keys.Left && SnakeClass.k != Keys.Right)
                            key = Keys.Right;
                        break;
                    case Keys.Space:
                        if (FormClass.game.timer.Enabled == true)
                            FormClass.game.timer.Enabled = false;
                        else
                            FormClass.game.timer.Enabled = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
