using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 方块
{
    class ShapeTool
    {
        /// <summary>
        /// 修改形状后与其它形状重复
        /// </summary>
        /// <param name="boxes">其他形状</param>
        /// <param name="x">偏移x</param>
        /// <param name="y">偏移y</param>
        /// <param name="point">形状的坐标点</param>
        /// <returns>重复返回false，反之true</returns>
        public static bool JudgeShapeModify(Point point, int x, int y)
        {
            for (int j = 0; j < FormClass.form1.boxes.Count; j++)
            {
                if (point.X + x == FormClass.form1.boxes[j].Location.X && point.Y + y == FormClass.form1.boxes[j].Location.Y)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// 判断Y坐标的移动
        /// </summary>
        /// <param name="boxes">集合</param>
        /// <param name="point">坐标点</param>
        /// <param name="addRess">偏移量</param>
        /// <returns>与其他坐标重合返回true，反之false</returns>
        private static bool JudgeMovePointY(Point point, int addRess)
        {
            for (int i = 0; i < FormClass.form1.boxes.Count; i++)
            {
                if (FormClass.form1.boxes[i].Location.X == point.X && FormClass.form1.boxes[i].Location.Y == point.Y + addRess)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 判断X坐标的移动
        /// </summary>
        /// <param name="boxes">集合</param>
        /// <param name="point">坐标点</param>
        /// <param name="addRess">偏移量</param>
        /// <returns></returns>
        private static bool JudgeMovePointX(Point point, int addRess)
        {
            for (int i = 0; i < FormClass.form1.boxes.Count; i++)
            {
                if (FormClass.form1.boxes[i].Location.X == point.X + addRess && FormClass.form1.boxes[i].Location.Y == point.Y)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 判断移动到最左端或移动后与其他坐标重复
        /// </summary>
        /// <param name="boxes">集合</param>
        /// <param name="shape">形状</param>
        /// <returns>移动到最左端或移动后与其他坐标重复返回false，反之true</returns>
        public static bool JudgeLeftMove(Shape shape)
        {
            for (int i = 0; i < shape.pictures.Length; i++)
            {
                if (shape.pictures[i].Location.X < 60 || JudgeMovePointX(shape.pictures[i].Location, -30))
                    return false;
            }
            return true;
        }
        /// <summary>
        /// 判断移动到最右端或移动后与其他坐标重复
        /// </summary>
        /// <param name="boxes">集合</param>
        /// <param name="shape">形状</param>
        /// <returns>移动到最右端或移动后与其他坐标重复返回false，反之true</returns>
        public static bool JudgeRightMove(Shape shape)
        {
            //移动到最右端或移动后与其他坐标重复
            for (int i = 0; i < shape.pictures.Length; i++)
            {
                if (shape.pictures[i].Location.X > 270 || JudgeMovePointX(shape.pictures[i].Location, 30))
                    return false;
            }
            return true;
        }
        /// <summary>
        /// 形状移动到最底端或与其他坐标重复
        /// </summary>
        /// <param name="boxes">集合</param>
        /// <param name="shape">形状</param>
        /// <returns>移动到最底端或移动后与其他坐标重复返回false，反之true</returns>
        public static bool JudgeShapeMove(Shape shape)
        {
            for (int i = 0; i < shape.pictures.Length; i++)
            {
                if (shape.pictures[i].Location.Y > 570 || JudgeMovePointY(shape.pictures[i].Location, 30))
                    return false;
            }
            return true;
        }
        /// <summary>
        /// 判断是否到达最顶端
        /// </summary>
        /// <param name="shape">形状</param>
        /// <returns>到达最顶端返回true，反之返回false</returns>
        public static bool JudgeShapeUpMove(Shape shape)
        {
            for (int i = 0; i < shape.pictures.Length; i++)
            {
                if (shape.pictures[i].Location.Y <= 30)
                    return true;
            }
            return false;
        }
        public static int MaxXPoint(params PictureBox[] pictureBoxes)
        {
            int maxX = pictureBoxes[0].Location.X;
            for (int i = 1; i < pictureBoxes.Length; i++)
            {
                if (pictureBoxes[i].Location.X > maxX)
                    maxX = pictureBoxes[i].Location.X;
            }
            return maxX;
        }
        public static int MinXPoint(params PictureBox[] pictureBoxes)
        {
            int minX = pictureBoxes[0].Location.X;
            for (int i = 1; i < pictureBoxes.Length; i++)
            {
                if (pictureBoxes[i].Location.X < minX)
                    minX = pictureBoxes[i].Location.X;
            }
            return minX;
        }
        private static int MinYPoint(params PictureBox[] pictureBoxes)
        {
            int minY = pictureBoxes[0].Location.Y;
            for (int i = 1; i < pictureBoxes.Length; i++)
            {
                if (pictureBoxes[i].Location.Y < minY)
                    minY = pictureBoxes[i].Location.Y;
            }
            return minY;
        }
        private static int MaxYPoint(params PictureBox[] pictureBoxes)
        {
            int maxY = pictureBoxes[0].Location.Y;
            for (int i = 1; i < pictureBoxes.Length; i++)
            {
                if (pictureBoxes[i].Location.Y > maxY)
                    maxY = pictureBoxes[i].Location.Y;
            }
            return maxY;
        }
        public static int pictureBoxesMaxXIndex(params PictureBox[] pictureBoxes)
        {
            int max = MaxXPoint(pictureBoxes);
            for (int i = 0; i < pictureBoxes.Length; i++)
            {
                if (max == pictureBoxes[i].Location.X)
                    return i;
            }
            return -1;
        }
        public static int pictureBoxesMinXIndex(params PictureBox[] pictureBoxes)
        {
            int min = MinXPoint(pictureBoxes);
            for (int i = 0; i < pictureBoxes.Length; i++)
            {
                if (min == pictureBoxes[i].Location.X)
                    return i;
            }
            return -1;
        }
        public static int pictureBoxesMaxYIndex(params PictureBox[] pictureBoxes)
        {
            int max = MaxYPoint(pictureBoxes);
            for (int i = 0; i < pictureBoxes.Length; i++)
            {
                if (max == pictureBoxes[i].Location.Y)
                    return i;
            }
            return -1;
        }
        public static int pictureBoxesMinYIndex(params PictureBox[] pictureBoxes)
        {
            int min = MinYPoint(pictureBoxes);
            for (int i = 0; i < pictureBoxes.Length; i++)
            {
                if (min == pictureBoxes[i].Location.Y)
                    return i;
            }
            return -1;
        }
        public static void RowNumber(int[] arr, Shape shape)
        {
            for (int i = 0; i < shape.pictures.Length; i++)
            {
                arr[shape.pictures[i].Location.Y / 30 - 1]++;
            }
        }
        /// <summary>
        /// 删除要删除的方块的记录
        /// </summary>
        /// <param name="boxes">所有落下方块</param>
        /// <param name="y">要删除方块的坐标</param>
        /// <returns>窗体需要删除的方块</returns>
        private static List<PictureBox> DropBox(int y)
        {
            List<PictureBox> newBoxes = new List<PictureBox>();
            for (int i = 0; i < FormClass.form1.boxes.Count; i++)
            {
                if (FormClass.form1.boxes[i].Location.Y == y)
                {
                    newBoxes.Add(FormClass.form1.boxes[i]);
                    FormClass.form1.boxes.RemoveAt(i);
                    i--;
                }
            }
            return newBoxes;
        }
        /// <summary>
        /// 删除窗体占满一行的方块
        /// </summary>
        /// <param name="form">窗体</param>
        /// <param name="boxes">所有落下的方块</param>
        /// <param name="y">要删除的行坐标</param>
        private static void FormDrop(int y)
        {
            //窗体要删除的方块
            List<PictureBox> formDrop = DropBox(y);
            for (int i = 0; i < formDrop.Count; i++)
            {
                int formNumber = FormClass.form1.Controls.Count;
                for (int j = 0; j < formNumber; j++)
                {
                    if (formDrop[i].Location.X == FormClass.form1.Controls[j].Location.X && formDrop[i].Location.Y == FormClass.form1.Controls[j].Location.Y)
                    {
                        FormClass.form1.Controls.RemoveAt(j);
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// 重新排列所有落下的方块
        /// </summary>
        /// <param name="pictures">排列的所有方块数组</param>
        private static void SortShape(int index, params PictureBox[] pictures)
        {
            for (int i = 0; i < pictures.Length; i++)
            {
                if (pictures[i].Location.Y / 30 - 1 < index)
                    pictures[i].Location = new Point(pictures[i].Location.X, pictures[i].Location.Y + 30);
            }
        }
        /// <summary>
        /// 排列计数器
        /// </summary>
        /// <param name="arr">数组</param>
        /// <param name="index">开始下标</param>
        private static void SortArr(int[] arr, int index)
        {
            int i;
            for (i = index; i > 0; i--)
            {
                arr[i] = arr[i - 1];
                if (arr[i] == 0)
                    break;
            }
        }
        /// <summary>
        /// 计算成绩
        /// </summary>
        private static void CalcScore()
        {
            for (int i = 0; i < FormClass.form1.Controls.Count; i++)
            {
                if (FormClass.form1.Controls[i].Name.Equals("score"))
                    FormClass.form1.Controls[i].Text = (Convert.ToInt32(FormClass.form1.Controls[i].Text) + 10).ToString();
            }
        }

        public static void FormDrop(int[] arr)
        {
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] == 10)
                {
                    int y = (i + 1) * 30;
                    FormDrop(y);
                    SortShape(i, FormClass.form1.boxes.ToArray());
                    SortArr(arr, i);
                    CalcScore();
                    i++;
                }
            }
        }
    }
}
