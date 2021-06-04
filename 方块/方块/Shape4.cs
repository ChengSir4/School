using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 方块
{
    class Shape4 : Shape
    {
        public Shape4() : base(0, CreateShape4()) { }
        private static PictureBox[] CreateShape4()
        {
            PictureBox[] pictureBoxes = new PictureBox[4];
            pictureBoxes[0] = PictureBoxTool.CreatePictureBox("shape4-", "1", 3, 150, 30);
            pictureBoxes[1] = PictureBoxTool.CreatePictureBox("shape4-", "2", 3, 180, 30);
            pictureBoxes[2] = PictureBoxTool.CreatePictureBox("shape4-", "3", 3, 120, 60);
            pictureBoxes[3] = PictureBoxTool.CreatePictureBox("shape4-", "4", 3, 150, 60);
            return pictureBoxes;
        }
        public override void modifyShape()
        {
            if (!(ShapeTool.MinXPoint(this.pictures) == 30 || ShapeTool.MaxXPoint(this.pictures) == 300))
            {
                switch (this.id)
                {
                    case 0:
                        if (ShapeTool.JudgeShapeModify(this.pictures[0].Location, 0, 30) && ShapeTool.JudgeShapeModify(this.pictures[1].Location, -30, 0) && ShapeTool.JudgeShapeModify(this.pictures[2].Location, 60, 0) && ShapeTool.JudgeShapeModify(this.pictures[3].Location, 30, 30))
                        {
                            this.pictures[0].Location = new System.Drawing.Point(this.pictures[0].Location.X, this.pictures[0].Location.Y + 30);
                            this.pictures[1].Location = new System.Drawing.Point(this.pictures[1].Location.X - 30, this.pictures[1].Location.Y);
                            this.pictures[2].Location = new System.Drawing.Point(this.pictures[2].Location.X + 60, this.pictures[2].Location.Y);
                            this.pictures[3].Location = new System.Drawing.Point(this.pictures[3].Location.X + 30, this.pictures[3].Location.Y + 30);
                            this.id = 1;
                        }
                        break;
                    case 1:
                        if (ShapeTool.JudgeShapeModify(this.pictures[0].Location, 0, -30) && ShapeTool.JudgeShapeModify(this.pictures[1].Location, 30, 0) && ShapeTool.JudgeShapeModify(this.pictures[2].Location, -60, 0) && ShapeTool.JudgeShapeModify(this.pictures[3].Location, -30, -30))
                        {
                            this.pictures[0].Location = new System.Drawing.Point(this.pictures[0].Location.X, this.pictures[0].Location.Y - 30);
                            this.pictures[1].Location = new System.Drawing.Point(this.pictures[1].Location.X + 30, this.pictures[1].Location.Y);
                            this.pictures[2].Location = new System.Drawing.Point(this.pictures[2].Location.X - 60, this.pictures[2].Location.Y);
                            this.pictures[3].Location = new System.Drawing.Point(this.pictures[3].Location.X - 30, this.pictures[3].Location.Y - 30);
                            this.id = 0;
                        }
                        break;
                }
            }
        }
    }
}
