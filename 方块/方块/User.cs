using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 方块
{
    class User
    {
        public static bool Input(Keys key)
        {
            if (key == Keys.Up || key == Keys.Down || key == Keys.Left || key == Keys.Right)
                return true;
            return false;
        }
    }
}
