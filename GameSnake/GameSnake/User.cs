using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameSnake
{
    public partial class User : Form
    {
        Label name;//昵称
        Label diff;//难度
        Button btnstart;//开始游戏按钮
        Button btnbody;//选择蛇身按钮
        Button btnrank;//查询排名按钮
        Button btnchat;//聊天按钮
        Button btnmy;//关于我们按钮
        public ComboBox cmbdiff;//难度选项
        public TextBox txtname;//用户输入的昵称
        public Bitmap snakeHead = null;//蛇头图片
        public Bitmap snakeBody = null;//蛇身图片
        public Image food = Image.FromFile("Food.jpg");//食物图片
        public User()
        {
            InitializeComponent();
        }
        public Timer timer = new Timer();
        Random r = new Random();
        /// <summary>
        /// 加载窗体时设计布局
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //设置窗体
            this.MaximizeBox = false;
            this.DoubleBuffered = true;
            this.Size = new Size(712, 446);
            this.Text = "CLC贪吃蛇";
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackgroundImage = Image.FromFile("Back.jpg");
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            timer.Tick += Timer_FontStyle;
            //获取路径
            string file = Directory.GetCurrentDirectory();
            int index = file.LastIndexOf("\\");
            file = file.Substring(0, index - 1);
            index = file.LastIndexOf("\\");
            file = file.Substring(0, file.LastIndexOf("\\", index - 1));
            this.Icon = new Icon(file + "\\favicon.ico");
            //创建控件
            name = new Label();
            diff = new Label();
            txtname = new TextBox();
            btnbody = new Button();
            btnbody.Click += Click_btnbody;
            btnstart = new Button();
            btnrank = new Button();
            btnchat = new Button();
            cmbdiff = new ComboBox();
            btnmy = new Button();
            cmbdiff.Items.Add("简单");
            cmbdiff.Items.Add("普通");
            cmbdiff.Items.Add("困难");
            cmbdiff.SelectedIndex = 0;
            cmbdiff.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbdiff.Size = new Size(130, 23);
            cmbdiff.Location = new Point(301, 155);
            name.Text = "昵称:";
            name.Size = new Size(40, 15);
            name.BackColor = Color.FromArgb(142, 199, 66);
            name.Location = new Point(259, 127);
            diff.Text = "难度:";
            diff.Size = new Size(40, 15);
            diff.BackColor = Color.FromArgb(142, 199, 66);
            diff.Location = new Point(259, 158);
            txtname.Name = "txtUserName";
            txtname.Size = new Size(130, 15);
            txtname.Location = new Point(301, 124);
            btnstart.Name = "btnStart";
            btnstart.Text = "PLAY";
            btnstart.Click += Click_btnStart;
            btnstart.Size = new Size(100, 35);
            btnstart.Font = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold);
            btnstart.FlatStyle = FlatStyle.Popup;
            btnstart.BackColor = Color.FromArgb(0, SystemColors.Control);
            btnstart.Location = new Point(304, 310);
            btnbody.Name = "btnUpSnakebody";
            btnbody.Text = "皮肤";
            btnbody.Size = new Size(80, 25);
            btnbody.FlatStyle = FlatStyle.Popup;
            btnbody.BackColor = Color.FromArgb(0, SystemColors.Control);
            btnbody.Location = new Point(583, 295);
            btnchat.Name = "btnChat";
            btnchat.Text = "聊天";
            btnchat.Click += Click_btnChat;
            btnchat.Size = new Size(80, 25);
            btnchat.FlatStyle = FlatStyle.Popup;
            btnchat.Location = new Point(583, 325);
            btnchat.BackColor = Color.FromArgb(0, SystemColors.Control);
            btnrank.Name = "btnSelectRank";
            btnrank.Text = "查询排名";
            btnrank.Size = new Size(80, 25);
            btnrank.Click += Click_btnRank;
            btnrank.FlatStyle = FlatStyle.Popup;
            btnrank.BackColor = Color.FromArgb(0, SystemColors.Control);
            btnrank.Location = new Point(583, 355);
            btnmy.Name = "btnMy";
            btnmy.Text = "关于我们";
            btnmy.Click += Click_btnMy;
            btnmy.Size = new Size(80, 25);
            btnmy.FlatStyle = FlatStyle.Popup;
            btnmy.BackColor = Color.FromArgb(0, SystemColors.Control);
            btnmy.Location = new Point(19, 355);
            Label gameShuo = new Label();
            gameShuo.Size = new Size(185, 15);
            gameShuo.BackColor = Color.FromArgb(142, 199, 66);
            gameShuo.Location = new Point(265, 280);
            gameShuo.Text = "操作方式: 方向键移动，空格暂停";
            //添加控件
            this.Controls.Add(name);
            this.Controls.Add(diff);
            this.Controls.Add(btnmy);
            this.Controls.Add(txtname);
            this.Controls.Add(btnbody);
            this.Controls.Add(btnrank);
            this.Controls.Add(btnchat);
            this.Controls.Add(cmbdiff);
            this.Controls.Add(btnstart);
            this.Controls.Add(gameShuo);
            this.txtname.Focus();
            FormClass.user = this;//添加到窗体类
            this.DesktopLocation = new Point(420, 190);//设置窗体出现的位置
            timer.Start();
        }
        /// <summary>
        /// 皮肤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_btnbody(object sender, EventArgs e)
        {
            FormClass.upSnake = new UpSnake();
            this.Enabled = false;
            FormClass.upSnake.Show();
        }
        /// <summary>
        /// 开始游戏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_btnStart(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtname.Text))
            {
                if (this.txtname.Text.Length <= 5)
                {
                    int i = DataClass.SelectUser(this.txtname.Text);
                    //是否存在此用户
                    if (i == 0)
                    {
                        DialogResult dr = MessageBox.Show("该昵称未注册，是否注册", "操作提示", MessageBoxButtons.OKCancel);
                        if (dr == DialogResult.OK)
                            if (1 == DataClass.InsertUser(this.txtname.Text))
                                MessageBox.Show("注册成功");
                    }
                    else if (i == -1)
                    {
                        MessageBox.Show("数据库异常");
                    }
                    //选择蛇头蛇身
                    else if (this.snakeBody == null && this.snakeHead == null)
                        MessageBox.Show("请选择皮肤");
                    else if (this.snakeBody == null)
                        MessageBox.Show("请选择蛇身");
                    else if (this.snakeHead == null)
                        MessageBox.Show("请选择蛇头");
                    else
                    {
                        FormClass.game = new Game();
                        this.timer.Stop();
                        FormClass.user.Hide();
                        FormClass.game.Show();
                    }
                }
                else
                    MessageBox.Show("字符不能超过5个");
            }
            else
                MessageBox.Show("昵称不能为空，请输入昵称");
        }
        /// <summary>
        /// 查询排名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_btnRank(object sender, EventArgs e)
        {
            FormClass.snakeRank = new SnakeRank();
            this.Enabled = false;
            FormClass.snakeRank.Show();
        }
        /// <summary>
        /// PLAY字体颜色切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_FontStyle(object sender, EventArgs e)
        {
            switch (r.Next(0, 5))
            {
                case 0:
                    this.btnstart.ForeColor = Color.Red;
                    break;
                case 1:
                    this.btnstart.ForeColor = Color.Blue;
                    break;
                case 2:
                    this.btnstart.ForeColor = Color.Green;
                    break;
                case 3:
                    this.btnstart.ForeColor = Color.Gray;
                    break;
                case 4:
                    this.btnstart.ForeColor = Color.AliceBlue;
                    break;
            }
        }
        /// <summary>
        /// 关于我们
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_btnMy(object sender, EventArgs e)
        {
            MessageBox.Show("制作人:CLC团队\n成员:李杰，程佳伟，陈文浩\n联系方式:15234452232\n\n\t多元合创参赛项目，请勿抄袭");
        }
        /// <summary>
        /// 聊天
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_btnChat(object sender, EventArgs e)
        {
            //昵称不为空
            if (!string.IsNullOrEmpty(this.txtname.Text))
            {
                int i = DataClass.SelectUser(this.txtname.Text);
                //该昵称是否注册
                if (i == 1)
                {
                    FormClass.chat = new Chat();
                    this.Enabled = false;
                    FormClass.chat.Show();
                }
                else if (i == -1)
                    MessageBox.Show("数据库异常");
                else
                    MessageBox.Show("该昵称未注册,体验一下游戏完成注册再来聊天吧");
            }
            else
                MessageBox.Show("昵称为空");
        }
    }
}
