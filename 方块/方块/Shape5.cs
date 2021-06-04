using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 方块
{
    class Shape5 : Shape
    {
        public Shape5() : base(0, CreateShape5()) { }
        private static PictureBox[] CreateShape5()
        {
            PictureBox[] pictureBoxes = new PictureBox[4];
            pictureBoxes[0] = PictureBoxTool.CreatePictureBox("shape1-", "1", 4, 150, 30);
            pictureBoxes[1] = PictureBoxTool.CreatePictureBox("shape1-", "2", 4, 150, 60);
            pictureBoxes[2] = PictureBoxTool.CreatePictureBox("shape1-", "3", 4, 150, 90);
            pictureBoxes[3] = PictureBoxTool.CreatePictureBox("shape1-", "4", 4, 180, 90);
            return pictureBoxes;
        }
        public override void modifyShape()
        {
            if (!(ShapeTool.MinXPoint(this.pictures) == 30 || ShapeTool.MaxXPoint(this.pictures) == 300))
            {
                switch (this.id)
                {
                    case 0:
                        if (ShapeTool.JudgeShapeModify(this.pictures[0].Location, -30, 30) && ShapeTool.JudgeShapeModify(this.pictures[2].Location, 30, -30) && ShapeTool.JudgeShapeModify(this.pictures[3].Location, 0, -60))
                        {
                            this.pictures[0].Location = new System.Drawing.Point(this.pictures[0].Location.X - 30, this.pictures[0].Location.Y + 30);
                            this.pictures[2].Location = new System.Drawing.Point(this.pictures[2].Location.X + 30, this.pictures[2].Location.Y - 30);
                            this.pictures[3].Location = new System.Drawing.Point(this.pictures[3].Location.X, this.pictures[3].Location.Y - 60);
                            this.id++;
                        }
                        break;
                    case 1:
                        if (ShapeTool.JudgeShapeModify(this.pictures[0].Location, 30, 30) && ShapeTool.JudgeShapeModify(this.pictures[2].Location, -30, -30) && ShapeTool.JudgeShapeModify(this.pictures[3].Location, -60, 0))
                        {
                            this.pictures[0].Location = new System.Drawing.Point(this.pictures[0].Location.X + 30, this.pictures[0].Location.Y + 30);
                            this.pictures[2].Location = new System.Drawing.Point(this.pictures[2].Location.X - 30, this.pictures[2].Location.Y - 30);
                            this.pictures[3].Location = new System.Drawing.Point(this.pictures[3].Location.X - 60, this.pictures[3].Location.Y);
                            this.id++;
                        }
                        break;
                    case 2:
                        if (ShapeTool.JudgeShapeModify(this.pictures[0].Location, 30, -30) && ShapeTool.JudgeShapeModify(this.pictures[2].Location, -30, 30) && ShapeTool.JudgeShapeModify(this.pictures[3].Location, 0, 60))
                        {
                            this.pictures[0].Location = new System.Drawing.Point(this.pictures[0].Location.X + 30, this.pictures[0].Location.Y - 30);
                            this.pictures[2].Location = new System.Drawing.Point(this.pictures[2].Location.X - 30, this.pictures[2].Location.Y + 30);
                            this.pictures[3].Location = new System.Drawing.Point(this.pictures[3].Location.X, this.pictures[3].Location.Y + 60);
                            this.id++;
                        }
                        break;
                    case 3:
                        if (ShapeTool.JudgeShapeModify(this.pictures[0].Location, -30, -30) && ShapeTool.JudgeShapeModify(this.pictures[2].Location, 30, 30) && ShapeTool.JudgeShapeModify(this.pictures[3].Location, 60, 0))
                        {
                            this.pictures[0].Location = new System.Drawing.Point(this.pictures[0].Location.X - 30, this.pictures[0].Location.Y - 30);
                            this.pictures[2].Location = new System.Drawing.Point(this.pictures[2].Location.X + 30, this.pictures[2].Location.Y + 30);
                            this.pictures[3].Location = new System.Drawing.Point(this.pictures[3].Location.X + 60, this.pictures[3].Location.Y);
                            this.id = 0;
                        }
                        break;
                }
            }
        }
    }
}
