using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 方块
{
    class Shape3 : Shape
    {
        public Shape3() : base(0, CreateShape3()) { }
        private static PictureBox[] CreateShape3()
        {
            PictureBox[] pictureBoxes = new PictureBox[4];
            pictureBoxes[0] = PictureBoxTool.CreatePictureBox("shape3-", "1", 2, 150, 30);
            pictureBoxes[1] = PictureBoxTool.CreatePictureBox("shape3-", "2", 2, 120, 60);
            pictureBoxes[2] = PictureBoxTool.CreatePictureBox("shape3-", "3", 2, 150, 60);
            pictureBoxes[3] = PictureBoxTool.CreatePictureBox("shape3-", "4", 2, 180, 60);
            return pictureBoxes;
        }
        public override void modifyShape()
        {
            if (!(ShapeTool.MinXPoint(this.pictures) == 30 || ShapeTool.MaxXPoint(this.pictures) == 300))
            {
                int index;
                switch (this.id)
                {
                    case 0:
                        //x最大
                        index = ShapeTool.pictureBoxesMaxXIndex(this.pictures);
                        if (ShapeTool.JudgeShapeModify(this.pictures[index].Location, -30, 30))
                        {
                            this.pictures[index].Location = new System.Drawing.Point(pictures[index].Location.X - 30, pictures[index].Location.Y + 30);
                            this.id++;
                        }
                        break;
                    case 1:
                        //y最小
                        index = ShapeTool.pictureBoxesMinYIndex(this.pictures);
                        if (ShapeTool.JudgeShapeModify(this.pictures[index].Location, 30, 30))
                        {
                            this.pictures[index].Location = new System.Drawing.Point(pictures[index].Location.X + 30, pictures[index].Location.Y + 30);
                            this.id++;
                        }
                        break;
                    case 2:
                        //x最小
                        index = ShapeTool.pictureBoxesMinXIndex(this.pictures);
                        if (ShapeTool.JudgeShapeModify(this.pictures[index].Location, 30, -30))
                        {
                            this.pictures[index].Location = new System.Drawing.Point(pictures[index].Location.X + 30, pictures[index].Location.Y - 30);
                            this.id++;
                        }
                        break;
                    case 3:
                        //y最大
                        index = ShapeTool.pictureBoxesMaxYIndex(this.pictures);
                        if (ShapeTool.JudgeShapeModify(this.pictures[index].Location, -30, -30))
                        {
                            this.pictures[index].Location = new System.Drawing.Point(pictures[index].Location.X - 30, pictures[index].Location.Y - 30);
                            this.id = 0;
                        }
                        break;
                }
            }
        }
    }
}
