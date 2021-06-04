using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 方块
{
    class Shape1 : Shape
    {
        public Shape1() : base(0, CreateShape1()) { }
        /// <summary>
        /// 创建形状
        /// </summary>
        /// <returns>4个图片控件</returns>
        private static PictureBox[] CreateShape1()
        {
            PictureBox[] pictureBoxes = new PictureBox[4];
            pictureBoxes[0] = PictureBoxTool.CreatePictureBox("shape1-", "1", 1, 120, 30);
            pictureBoxes[1] = PictureBoxTool.CreatePictureBox("shape1-", "2", 1, 150, 30);
            pictureBoxes[2] = PictureBoxTool.CreatePictureBox("shape1-", "3", 1, 180, 30);
            pictureBoxes[3] = PictureBoxTool.CreatePictureBox("shape1-", "4", 1, 210, 30);
            return pictureBoxes;
        }

        public override void modifyShape()
        {
            if (!(ShapeTool.MinXPoint(this.pictures) == 30 || ShapeTool.MaxXPoint(this.pictures) == 300))
            {
                switch (this.id)
                {
                    case 0:
                        if (ShapeTool.JudgeShapeModify(this.pictures[0].Location, 60, 0) && ShapeTool.JudgeShapeModify(this.pictures[1].Location, 30, -30) && ShapeTool.JudgeShapeModify(this.pictures[2].Location, 0, -60) && ShapeTool.JudgeShapeModify(this.pictures[3].Location, -30, -90))
                        {
                            PictureBoxTool.MovePictureBox(this.pictures[0], this.pictures[0].Location.X + 60, this.pictures[0].Location.Y);
                            PictureBoxTool.MovePictureBox(this.pictures[1], this.pictures[1].Location.X + 30, this.pictures[1].Location.Y - 30);
                            PictureBoxTool.MovePictureBox(this.pictures[2], this.pictures[2].Location.X, this.pictures[2].Location.Y - 60);
                            PictureBoxTool.MovePictureBox(this.pictures[3], this.pictures[3].Location.X - 30, this.pictures[3].Location.Y - 90);
                            this.id = 1;
                        }
                        break;
                    case 1:
                        if (ShapeTool.MinXPoint(this.pictures) == 60)
                        {
                            if (ShapeTool.JudgeShapeModify(this.pictures[0].Location, -30, 0) && ShapeTool.JudgeShapeModify(this.pictures[1].Location, 0, 30) && ShapeTool.JudgeShapeModify(this.pictures[2].Location, 30, 60) && ShapeTool.JudgeShapeModify(this.pictures[3].Location, 60, 90))
                            {
                                PictureBoxTool.MovePictureBox(this.pictures[0], this.pictures[0].Location.X - 30, this.pictures[0].Location.Y);
                                PictureBoxTool.MovePictureBox(this.pictures[1], this.pictures[1].Location.X, this.pictures[1].Location.Y + 30);
                                PictureBoxTool.MovePictureBox(this.pictures[2], this.pictures[2].Location.X + 30, this.pictures[2].Location.Y + 60);
                                PictureBoxTool.MovePictureBox(this.pictures[3], this.pictures[3].Location.X + 60, this.pictures[3].Location.Y + 90);
                            }
                        }
                        else
                        {
                            if (ShapeTool.JudgeShapeModify(this.pictures[0].Location, -60, 0) && ShapeTool.JudgeShapeModify(this.pictures[1].Location, -30, 30) && ShapeTool.JudgeShapeModify(this.pictures[2].Location, 0, 60) && ShapeTool.JudgeShapeModify(this.pictures[3].Location, 30, 90))
                            {
                                PictureBoxTool.MovePictureBox(this.pictures[0], this.pictures[0].Location.X - 60, this.pictures[0].Location.Y);
                                PictureBoxTool.MovePictureBox(this.pictures[1], this.pictures[1].Location.X - 30, this.pictures[1].Location.Y + 30);
                                PictureBoxTool.MovePictureBox(this.pictures[2], this.pictures[2].Location.X, this.pictures[2].Location.Y + 60);
                                PictureBoxTool.MovePictureBox(this.pictures[3], this.pictures[3].Location.X + 30, this.pictures[3].Location.Y + 90);
                            }
                        }
                        this.id = 0;
                        break;
                }
            }
        }
    }
}
