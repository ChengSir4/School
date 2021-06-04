using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 方块
{
    static class Game
    {
        private static Random random = new Random();
        public static void start(Shape shape, Keys key)
        {
            switch (key)
            {
                case Keys.Up:
                    shape.modifyShape();
                    break;
                case Keys.Down:
                    for (int i = 0; i < shape.pictures.Length; i++)
                    {
                        shape.pictures[i].Location = new Point(shape.pictures[i].Location.X, shape.pictures[i].Location.Y + 30);
                    }
                    break;
                case Keys.Left:
                    if (ShapeTool.JudgeLeftMove(shape))
                    {
                        for (int i = 0; i < shape.pictures.Length; i++)
                        {
                            shape.pictures[i].Location = new Point(shape.pictures[i].Location.X - 30, shape.pictures[i].Location.Y);
                        }
                    }
                    break;
                case Keys.Right:
                    if (ShapeTool.JudgeRightMove(shape))
                    {
                        for (int i = 0; i < shape.pictures.Length; i++)
                        {
                            shape.pictures[i].Location = new Point(shape.pictures[i].Location.X + 30, shape.pictures[i].Location.Y);
                        }
                    }
                    break;
            }
        }
    }
}
