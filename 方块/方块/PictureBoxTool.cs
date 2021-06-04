using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 方块
{
    static class PictureBoxTool
    {
        private static Random random = new Random();
        /// <summary>
        /// 创建图片控件
        /// </summary>
        /// <param name="rowName">行号</param>
        /// <param name="columnName">列号</param>
        /// <param name="id">选择的图片id</param>
        /// <param name="x">坐标x</param>
        /// <param name="y">坐标y</param>
        /// <returns>控件</returns>
        public static PictureBox CreatePictureBox(String rowName, String columnName, int id, int x, int y)
        {
            PictureBox pb = new PictureBox();
            pb.Image = GetImage(id);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Size = new Size(30, 30);
            pb.Location = new Point(x, y);
            pb.Name = rowName + "-" + columnName;
            return pb;
        }
        /// <summary>
        /// 加载形状
        /// </summary>
        /// <param name="pictureBoxes">下一个</param>
        /// <returns>当前的</returns>
        public static Shape LoadShape()
        {
            //随机形状
            return RandomShape();
        }
        /// <summary>
        /// 随机下一个
        /// </summary>
        /// <returns>返回形状</returns>
        public static Shape LoadNextShape()
        {
            //随机形状
            Shape shape = RandomShape();
            //下一个形状放入到NEXT框
            for (int i = 0; i < shape.pictures.Length; i++)
            {
                shape.pictures[i].Location = new System.Drawing.Point(shape.pictures[i].Location.X + 280, shape.pictures[i].Location.Y + 90);
            }
            return shape;
        }
        /// <summary>
        /// 移动图片控件
        /// </summary>
        /// <param name="picture">移动的控件</param>
        /// <param name="x">x坐标</param>
        /// <param name="y">y坐标</param>
        public static void MovePictureBox(PictureBox picture,int x,int y)
        {
            picture.Location = new Point(x, y);
        }
        /// <summary>
        /// 选择图片
        /// </summary>
        /// <param name="id">图片id</param>
        /// <returns>1.blue，2.green，3.orange，4.red，5.h</returns>
        private static Image GetImage(int id)
        {
            Image image = null;
            switch (id)
            {
                case 1:
                    image = Image.FromFile("blue.jpg");
                    break;
                case 2:
                    image = Image.FromFile("green.jpg");
                    break;
                case 3:
                    image = Image.FromFile("orange.jpg");
                    break;
                case 4:
                    image = Image.FromFile("red.jpg");
                    break;
                case 5:
                    image = Image.FromFile("h.jpg");
                    break;
            }
            return image;
        }
        /// <summary>
        /// 随机形状
        /// </summary>
        /// <returns>随机的形状</returns>
        private static Shape RandomShape()
        {
            Shape shape = null;
            switch (random.Next(0, 5))
            {
                case 0:
                    shape = new Shape1();
                    break;
                case 1:
                    shape = new Shape2();
                    break;
                case 2:
                    shape = new Shape3();
                    break;
                case 3:
                    shape = new Shape4();
                    break;
                case 4:
                    shape = new Shape5();
                    break;
            }
            return shape;
        }
    }
}
