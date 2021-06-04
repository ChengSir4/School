using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 方块
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Shape shape;
        private Shape nextShape;
        private int[] rowShapeNumber = new int[20];
        public List<PictureBox> boxes = new List<PictureBox>();
        private void Form1_Load(object sender, EventArgs e)
        {
            FormClass.form1 = this;
            FormClass.form1.Size = new Size(616, 700);
            FormClass.form1.FormBorderStyle = FormBorderStyle.FixedSingle;
            FormClass.form1.MaximizeBox = false;
            //画地图
            Draw.DrawMap();
            //加载第一个
            shape = PictureBoxTool.LoadShape();
            //加载下一个
            nextShape = PictureBoxTool.LoadNextShape();
            //添加到窗体
            FormClass.form1.Controls.AddRange(shape.pictures);
            FormClass.form1.Controls.AddRange(nextShape.pictures);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ShapeMove();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Keys key = e.KeyCode;
            JudgeUserKey(key);
        }
    }
}
