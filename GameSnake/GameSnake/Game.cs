using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameSnake
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
        }
        public int result = 0;//得分
        public Label lalresult;//计分板
        public FoodClass food;//食物对象
        public SnakeClass snake;//蛇对象
        public PictureBox foodpic;//食物
        public PictureBox head = null;//蛇头
        public Timer timer = new Timer();//蛇移动计时器
        private void Game_Load(object sender, EventArgs e)
        {
            //设置游戏窗体
            this.Text = "贪吃蛇";
            this.MaximizeBox = false;
            this.Size = new Size(700, 470);
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.BackgroundImage = Bitmap.FromFile("GameBack.jpg");
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            //加载计分板
            lalresult = new Label();
            lalresult.Location = new Point(335, 6);
            lalresult.Size = new Size(30, 10);
            lalresult.Text = result.ToString();
            lalresult.BackColor = Color.FromArgb(0, SystemColors.Control);
            this.Controls.Add(lalresult);
            //设置计时器
            timer.Tick += timer_Tick;
            //创建蛇对象
            snake = new SnakeClass();
            snake.TfKey();
            //添加蛇头
            head = new PictureBox();
            head.Size = new Size(23, 23);
            head.Image = FormClass.user.snakeHead;
            head.SizeMode = PictureBoxSizeMode.StretchImage;//图片自适应
            snake.snake.Add(head);//蛇头添加到蛇
            snake.snake[0].Location = new Point(10, 25);
            this.Controls.Add(snake.snake[0]);
            //创建食物，指定位置
            food = new FoodClass();
            //设置显示的食物
            foodpic = new PictureBox();
            foodpic.Size = new Size(23, 23);
            foodpic.Image = FormClass.user.food;
            foodpic.SizeMode = PictureBoxSizeMode.StretchImage;//图片自适应
            foodpic.Location = food.FoodPoint;
            this.DesktopLocation = new Point(420, 190);//设置窗体出现的位置
            this.Controls.Add(foodpic);
            if (FormClass.user.cmbdiff.SelectedItem.ToString().Equals("简单"))
                this.timer.Interval = 250;
            else if (FormClass.user.cmbdiff.SelectedItem.ToString().Equals("普通"))
                this.timer.Interval = 150;
            else if (FormClass.user.cmbdiff.SelectedItem.ToString().Equals("困难"))
                this.timer.Interval = 50;
            timer.Start();
        }
        /// <summary>
        /// 蛇移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (snake.SheTou())
            {
                timer.Stop();
                DataClass.UpUserScore(this.result);//修改成绩
                DialogResult dr = MessageBox.Show("很遗憾,你输了,是否重新开始", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    this.Close();
                    FormClass.game = new Game();
                    FormClass.game.Show();
                }
                else
                {
                    //关闭当前游戏窗体
                    FormClass.game.Close();
                    //打开用户窗体
                    FormClass.user.Visible = true;
                }
            }
            else
            {
                //蛇移动
                if (snake.move())
                {
                    //记录成绩
                    result++;
                    lalresult.Text = result.ToString();
                    if (snake.SnakeLength == 601)
                    {
                        this.timer.Stop();
                        MessageBox.Show("游戏胜利");
                        //关闭当前游戏窗体
                        FormClass.game.Close();
                        //打开用户窗体
                        FormClass.user.Visible = true;
                    }
                    food.New();//重置食物坐标
                    foodpic.Location = food.FoodPoint;//更改食物坐标
                }
            }
        }
        /// <summary>
        /// 用户按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Game_KeyUp(object sender, KeyEventArgs e)
        {
            UserClass.UserKey(e.KeyCode);
            snake.TfKey();
        }
        /// <summary>
        /// 窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            //初始化游戏
            this.timer.Stop();
            snake.New();
            //打开用户窗体
            FormClass.user.Enabled = true;
            FormClass.user.timer.Start();
            FormClass.user.Visible = true;
        }
    }
}
