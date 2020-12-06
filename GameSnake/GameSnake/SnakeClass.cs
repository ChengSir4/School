using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameSnake
{
    public class SnakeClass
    {
        private int Lenth = 1;//蛇的长度
        public Func<bool> move;//蛇的移动
        public static Keys k = Keys.Right;//当前蛇的移动方向
        private static Point tou = new Point();//保存蛇头移动前的坐标
        public List<PictureBox> snake = new List<PictureBox>();//蛇
        public int SnakeLength { get { return this.Lenth; } }
        /// <summary>
        /// 初始化蛇
        /// </summary>
        public void New()
        {
            Lenth = 1;
            if (UserClass.key == Keys.Up)
                FormClass.game.head.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            else if (UserClass.key == Keys.Down)
                FormClass.game.head.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            else if (UserClass.key == Keys.Left)
                FormClass.game.head.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            UserClass.key = Keys.Right;
            k = Keys.Right;
        }
        /// <summary>
        /// 通过用户按键让蛇移动
        /// </summary>
        public void TfKey()
        {
            switch (UserClass.key)
            {
                case Keys.Down:
                    move = Dow;
                    break;
                case Keys.Up:
                    move = Up;
                    break;
                case Keys.Left:
                    move = Left;
                    break;
                case Keys.Right:
                    move = Right;
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 向上移动
        /// </summary>
        /// <returns></returns>
        private bool Up()
        {
            //修改蛇的移动方向并重绘蛇头图片
            if (k != UserClass.key)
            {
                if (k == Keys.Left)
                    this.snake[0].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);//向左移动时按上方向键蛇头旋转90
                if (k == Keys.Right)
                    this.snake[0].Image.RotateFlip(RotateFlipType.Rotate270FlipNone);//向右移动时按上方向键蛇头旋转270
                this.snake[0].Refresh();//重绘
                k = UserClass.key;
            }
            tou = this.snake[0].Location;//记录蛇头移动
            this.snake[0].Location = new Point(this.snake[0].Location.X, this.snake[0].Location.Y - 23);
            if (EatFood())
                return true;
            else
            {
                MoveBody();
                return false;
            }
        }
        /// <summary>
        /// 向下移动
        /// </summary>
        /// <returns></returns>
        private bool Dow()
        {
            //修改蛇的移动方向并重绘蛇头图片
            if (k != UserClass.key)
            {
                if (k == Keys.Left)
                    this.snake[0].Image.RotateFlip(RotateFlipType.Rotate270FlipNone);//向左移动时按下方向键蛇头旋转270
                if (k == Keys.Right)
                    this.snake[0].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);//向右移动时按下方向键蛇头旋转90
                this.snake[0].Refresh();//重绘
                k = UserClass.key;
            }
            tou = this.snake[0].Location;//记录蛇头移动
            this.snake[0].Location = new Point(this.snake[0].Location.X, this.snake[0].Location.Y + 23);
            if (EatFood())
                return true;
            else
            {
                MoveBody();
                return false;
            }
        }
        /// <summary>
        /// 向左移动
        /// </summary>
        /// <returns></returns>
        private bool Left()
        {
            //修改蛇的移动方向并重绘蛇头图片
            if (k != UserClass.key)
            {
                if (k == Keys.Up)
                    this.snake[0].Image.RotateFlip(RotateFlipType.Rotate270FlipNone);//向左移动时按左方向键蛇头旋转270
                if (k == Keys.Down)
                    this.snake[0].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);//向右移动时按左方向键蛇头旋转90
                this.snake[0].Refresh();
                k = UserClass.key;
            }
            tou = this.snake[0].Location;//记录蛇头移动
            this.snake[0].Location = new Point(this.snake[0].Location.X - 23, this.snake[0].Location.Y);
            if (EatFood())
                return true;
            else
            {
                MoveBody();
                return false;
            }
        }
        /// <summary>
        /// 向右移动
        /// </summary>
        /// <returns></returns>
        private bool Right()
        {
            //修改蛇的移动方向并重绘蛇头图片
            if (k != UserClass.key)
            {
                if (k == Keys.Up)
                    this.snake[0].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);//向上移动时按右方向键蛇头旋转90
                if (k == Keys.Down)
                    this.snake[0].Image.RotateFlip(RotateFlipType.Rotate270FlipNone);//向下移动时按右方向键蛇头旋转270
                this.snake[0].Refresh();
                k = UserClass.key;
            }
            tou = this.snake[0].Location;//记录蛇头移动
            snake[0].Location = new Point(snake[0].Location.X + 23, snake[0].Location.Y);//修改坐标
            if (EatFood())
                return true;
            else
            {
                MoveBody();
                return false;
            }
        }
        #region 蛇头撞到地图
        /// <summary>
        /// 蛇头撞到地图
        /// </summary>
        /// <returns></returns>
        public bool SheTou()
        {
            //地图最上方
            if (this.snake[0].Location.Y == 25 && UserClass.key == Keys.Up)
            {
                //更改蛇头方向
                if (k == Keys.Left)
                    this.snake[0].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                if (k == Keys.Right)
                    this.snake[0].Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                this.snake[0].Refresh();//重绘蛇头
                return true;
            }
            //地图最下方
            else if (this.snake[0].Location.Y == 393 && UserClass.key == Keys.Down)
            {
                //更改蛇头方向
                if (k == Keys.Left)
                    this.snake[0].Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                if (k == Keys.Right)
                    this.snake[0].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                this.snake[0].Refresh();//重绘蛇头
                return true;
            }
            //地图最左侧
            else if (this.snake[0].Location.X == 10 && UserClass.key == Keys.Left)
            {
                if (k == Keys.Up)
                    this.snake[0].Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                if (k == Keys.Down)
                    this.snake[0].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                this.snake[0].Refresh();//重绘
                return true;
            }
            //地图最右侧
            else if (this.snake[0].Location.X == 654 && UserClass.key == Keys.Right)
            {
                if (k == Keys.Up)
                    this.snake[0].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                if (k == Keys.Down)
                    this.snake[0].Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                this.snake[0].Refresh();//重绘
                return true;
            }
            return false;
        }
        #endregion
        /// <summary>
        /// 返回true蛇吃到食物
        /// </summary>
        private bool EatFood()
        {
            //吃到食物添加PictureBox控件
            if (this.snake[0].Location.X == FormClass.game.foodpic.Location.X && this.snake[0].Location.Y == FormClass.game.foodpic.Location.Y)
            {
                snake.Insert(1, new PictureBox());
                snake[1].SizeMode = PictureBoxSizeMode.StretchImage;//图片自适应
                snake[1].Size = new Size(23, 23);//pictureBox的大小
                snake[1].Image = FormClass.user.snakeBody;//设置图片
                snake[1].Location = tou;
                FormClass.game.Controls.Add(snake[1]);//添加蛇身到窗体
                Lenth++;
                return true;
            }
            else
                return false;
        }
        private void MoveBody()
        {
            if (Lenth > 1)
            {
                snake[Lenth - 1].Location = tou;
                PictureBox p = snake[Lenth - 1];
                snake.RemoveAt(Lenth - 1);
                snake.Insert(1, p);
            }
        }
    }
}
