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
    public partial class SnakeRank : Form
    {
        public SnakeRank()
        {
            InitializeComponent();
        }
        public ComboBox cmb;//难度下拉框
        DataTable dt;//排名数据
        Label OneResult;//第一名
        Label TwoResult;//第二名
        Label ThreeResult;//第三名
        Timer timer = new Timer();
        Random r = new Random();
        private void SnakeRank_Load(object sender, EventArgs e)
        {
            //设置窗体
            this.MaximizeBox = false;
            this.Text = "排名";
            this.Size = new Size(880, 600);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.BackgroundImage = Image.FromFile("RankBack.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            //timer时间
            timer.Interval = 90;
            timer.Tick += Timer_FontStyle;
            //添加显示数据的控件
            Label diff = new Label();
            diff.Text = "难度:";
            diff.Size = new Size(35, 23);
            diff.Location = new Point(405, 219);
            diff.BackColor = Color.Transparent;
            diff.Font = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular);
            diff.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(diff);
            //第一名
            OneResult = new Label();
            OneResult.Size = new Size(130, 30);
            OneResult.BackColor = Color.Transparent;
            OneResult.Font = new Font(FontFamily.GenericSansSerif, 13, FontStyle.Bold);
            OneResult.TextAlign = ContentAlignment.MiddleCenter;
            OneResult.Location = new Point(385, 182);
            //第二名
            TwoResult = new Label();
            TwoResult.Size = new Size(130, 30);
            TwoResult.BackColor = Color.Transparent;
            TwoResult.Font = new Font(FontFamily.GenericMonospace, 13, FontStyle.Italic);
            TwoResult.TextAlign = ContentAlignment.MiddleCenter;
            TwoResult.Location = new Point(280, 220);
            //第三名
            ThreeResult = new Label();
            ThreeResult.Size = new Size(130, 30);
            ThreeResult.BackColor = Color.Transparent;
            ThreeResult.Font = new Font(FontFamily.GenericMonospace, 13, FontStyle.Italic);
            ThreeResult.TextAlign = ContentAlignment.MiddleCenter;
            ThreeResult.Location = new Point(490, 220);
            this.Controls.Add(OneResult);
            this.Controls.Add(TwoResult);
            this.Controls.Add(ThreeResult);
            //排名
            Label id = new Label();
            id.Text = "R";
            id.Size = new Size(23, 22);
            id.BackColor = Color.Transparent;
            id.Location = new Point(352, 250);
            id.BorderStyle = BorderStyle.FixedSingle;
            id.TextAlign = ContentAlignment.MiddleCenter;
            id.Font = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold);
            this.Controls.Add(id);
            //昵称
            Label laName = new Label();
            laName.Text = "昵称";
            laName.Size = new Size(80, 22);
            laName.BackColor = Color.Transparent;
            laName.Location = new Point(375, 250);
            laName.BorderStyle = BorderStyle.FixedSingle;
            laName.TextAlign = ContentAlignment.MiddleCenter;
            laName.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
            this.Controls.Add(laName);
            //成绩
            Label laResult = new Label();
            laResult.Text = "成绩";
            laResult.Size = new Size(80, 22);
            laResult.BackColor = Color.Transparent;
            laResult.Location = new Point(455, 250);
            laResult.BorderStyle = BorderStyle.FixedSingle;
            laResult.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
            laResult.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(laResult);
            int p = 273;
            Label Id;
            for (int i = 0; i < 10; i++)
            {
                Id = new Label();
                Id.Text = (i + 1).ToString();
                Id.Size = new Size(23, 22);
                Id.Location = new Point(352, p);
                Id.BackColor = Color.Transparent;
                Id.BorderStyle = BorderStyle.FixedSingle;
                Id.TextAlign = ContentAlignment.MiddleCenter;
                Id.Font = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold);
                this.Controls.Add(Id);
                p = Id.Location.Y + 22;
            }
            //添加前十名文本控件
            p = 273;
            Label Name;
            Label Result;
            for (int i = 0; i < 10; i++)
            {
                Name = new Label();
                Name.Name = $"Name{(i + 1)}";
                Name.Text = "";
                Name.Size = new Size(80, 22);
                Name.Location = new Point(375, p);
                Name.BackColor = Color.Transparent;
                Name.BorderStyle = BorderStyle.FixedSingle;
                Name.TextAlign = ContentAlignment.MiddleCenter;
                Name.Font = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold);
                this.Controls.Add(Name);
                Result = new Label();
                Result.Name = $"Result{i + 1}";
                Result.Text = "";
                Result.Size = new Size(80, 22);
                Result.Location = new Point(455, p);
                Result.BackColor = Color.Transparent;
                Result.BorderStyle = BorderStyle.FixedSingle;
                Result.TextAlign = ContentAlignment.MiddleCenter;
                Result.Font = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold);
                this.Controls.Add(Result);
                p = Result.Location.Y + 22;
            }
            //难度下拉框及选项
            cmb = new ComboBox();
            cmb.Items.Add("简单");
            cmb.Items.Add("普通");
            cmb.Items.Add("困难");
            cmb.SelectedIndexChanged += Click_Diff;
            cmb.SelectedIndex = 0;
            cmb.Size = new Size(50, 23);
            cmb.Location = new Point(440, 220);
            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(cmb);
            //查询排名
            dt = DataClass.SelectScore(this.cmb.SelectedIndex);
            NameScore();
            timer.Start();//启动计时器刷新第一名字体颜色
        }
        /// <summary>
        /// 前三名昵称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_Diff(object sender, EventArgs e)
        {
            dt = DataClass.SelectScore(this.cmb.SelectedIndex);
            if (dt.Rows.Count > 0)
                this.OneResult.Text = dt.Rows[0][0].ToString();
            if (dt.Rows.Count > 1)
                this.TwoResult.Text = dt.Rows[1][0].ToString();
            if (dt.Rows.Count > 2)
                this.ThreeResult.Text = dt.Rows[2][0].ToString();
            NameScore();
        }
        /// <summary>
        /// 展示或刷新控件中的用户成绩
        /// </summary>
        private void NameScore()
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.Controls[$"Name{i + 1}"].Text = dt.Rows[i][0].ToString();
                this.Controls[$"Result{i + 1}"].Text = dt.Rows[i][1].ToString();
            }
        }
        /// <summary>
        /// 窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SnakeRank_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.timer.Stop();
            FormClass.user.timer.Start();
            FormClass.user.Enabled = true;
        }
        /// <summary>
        /// 更该第一名字体颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_FontStyle(object sender, EventArgs e)
        {
            switch (r.Next(0, 5))
            {
                case 0:
                    this.OneResult.ForeColor = Color.Red;
                    break;
                case 1:
                    this.OneResult.ForeColor = Color.Blue;
                    break;
                case 2:
                    this.OneResult.ForeColor = Color.Green;
                    break;
                case 3:
                    this.OneResult.ForeColor = Color.Gray;
                    break;
                case 4:
                    this.OneResult.ForeColor = Color.AliceBlue;
                    break;
            }
        }
    }
}
