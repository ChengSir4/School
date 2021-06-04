using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 方块
{
    class Shape2 : Shape
    {
        public Shape2() : base(0,CreateShape2()) { }
        private static PictureBox[] CreateShape2()
        {
            PictureBox[] pictureBoxes = new PictureBox[4];
            pictureBoxes[0] = PictureBoxTool.CreatePictureBox("shape2-", "1", 1, 150, 30);
            pictureBoxes[1] = PictureBoxTool.CreatePictureBox("shape2-", "2", 2, 180, 30);
            pictureBoxes[2] = PictureBoxTool.CreatePictureBox("shape2-", "3", 3, 150, 60);
            pictureBoxes[3] = PictureBoxTool.CreatePictureBox("shape2-", "4", 4, 180, 60);
            return pictureBoxes;
        }
          
        public override void modifyShape()
        {

        }
    }
}
