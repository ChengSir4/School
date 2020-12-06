using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameSnake
{
    public partial class UpSnake : Form
    {
        public UpSnake()
        {
            InitializeComponent();
        }
        ListView bodylist;//展示蛇身的list
        ListView headlist;//展示蛇头的list
        Bitmap head = null;//蛇头
        Bitmap body = null;//蛇身
        ImageList SnakeSelectedBody = new ImageList();//蛇身资源
        ImageList SnakeSelectedHead = new ImageList();//蛇头资源
        private void UpSnakeBody_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.Text = "皮肤";
            this.Size = new Size(818, 497);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            //清除蛇头蛇身图片集
            this.SnakeSelectedBody.Images.Clear();
            this.SnakeSelectedHead.Images.Clear();
            //蛇头蛇身的容器
            GroupBox GrbHead = new GroupBox();
            GrbHead.Size = new Size(800, 200);
            GrbHead.Dock = DockStyle.Top;
            GrbHead.Location = new Point(0, 0);
            GrbHead.Text = "蛇头";
            GroupBox GrbBody = new GroupBox();
            GrbBody.Size = new Size(800, 200);
            GrbBody.Dock = DockStyle.Top;
            GrbBody.Text = "蛇身";
            //展示蛇头的ListView，添加到GrbHead
            headlist = new ListView();
            headlist.View = View.LargeIcon;
            headlist.Click += Click_SnakeHead;
            headlist.BorderStyle = BorderStyle.None;
            headlist.HideSelection = false;
            GrbHead.Controls.Add(headlist);
            headlist.Dock = DockStyle.Fill;
            //展示蛇身的ListView，添加到GrbBody
            bodylist = new ListView();
            bodylist.View = View.LargeIcon;
            bodylist.Click += Click_SnakeBody;
            bodylist.BorderStyle = BorderStyle.None;
            bodylist.HideSelection = false;
            GrbBody.Controls.Add(bodylist);
            bodylist.Dock = DockStyle.Fill;
            //获取路径
            string file = Directory.GetCurrentDirectory();
            int index = file.LastIndexOf("\\");
            file = file.Substring(0, index + 1);
            //获取蛇头资源，并指定图片的大小
            string[] headarr = Directory.GetFiles(file + "SnakeHead");
            foreach (string item in headarr)
            {
                SnakeSelectedHead.ImageSize = new Size(90, 90);
                string n = Path.GetFileNameWithoutExtension(item);//获取文件名
                SnakeSelectedHead.Images.Add(n, Bitmap.FromFile(item));//将图片放到imageList中
            }
            //指定蛇头显示的大图标集合
            headlist.LargeImageList = SnakeSelectedHead;
            for (int i = 0; i < SnakeSelectedHead.Images.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = SnakeSelectedHead.Images.Keys[i];
                item.ImageIndex = SnakeSelectedHead.Images.IndexOfKey(item.Text);
                headlist.Items.Add(item);
            }
            //加载蛇身资源
            string[] bodyarr = Directory.GetFiles(file + "SnakeBody");
            foreach (string item in bodyarr)
            {
                SnakeSelectedBody.ImageSize = new Size(90, 90);
                string n = Path.GetFileNameWithoutExtension(item);//获取文件名
                SnakeSelectedBody.Images.Add(n, Bitmap.FromFile(item));//将图片放到imageList中
            }
            //指定显示大图标集合
            bodylist.LargeImageList = SnakeSelectedBody;
            for (int i = 0; i < SnakeSelectedBody.Images.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = SnakeSelectedBody.Images.Keys[i];
                item.ImageIndex = SnakeSelectedBody.Images.IndexOfKey(item.Text);
                bodylist.Items.Add(item);
            }
            //创建确认按钮
            Button btnEnt = new Button();
            btnEnt.Location = new Point(710, 407);
            btnEnt.Size = new Size(78, 31);
            btnEnt.Click += Click_btnEnt;
            btnEnt.Text = "确认";
            //创建取消按钮
            Button btnEsc = new Button();
            btnEsc.Location = new Point(12, 407);
            btnEsc.Size = new Size(78, 31);
            btnEsc.Click += Click_btnEsc;
            btnEsc.Text = "取消";
            //添加控件到窗体
            this.Controls.Add(btnEnt);
            this.Controls.Add(btnEsc);
            this.Controls.Add(GrbBody);
            this.Controls.Add(GrbHead);

        }
        private void Click_SnakeHead(object sender, EventArgs e)
        {
            if (headlist.SelectedItems.Count == 1)
            {
                int i = headlist.SelectedItems[0].ImageIndex;//获取选中项的索引
                head = (Bitmap)SnakeSelectedHead.Images[i];
            }
            else
            {
                MessageBox.Show("禁止选中多项");
                headlist.SelectedItems.Clear();
                head = null;
                body = null;
            }
        }
        private void Click_SnakeBody(object sender, EventArgs e)
        {
            if (bodylist.SelectedItems.Count == 1)
            {
                int i = bodylist.SelectedItems[0].ImageIndex;//获取选中项的索引
                body = (Bitmap)SnakeSelectedBody.Images[i];
            }
            else
            {
                MessageBox.Show("禁止选中多项");
                bodylist.SelectedItems.Clear();
                body = null;
                head = null;
            }
        }
        private void Click_btnEnt(object sender, EventArgs e)
        {
            if (body != null)
                FormClass.user.snakeBody = body;
            if (head != null)
                FormClass.user.snakeHead = head;
            this.Close();
        }
        private void Click_btnEsc(object sender, EventArgs e)
        {
            FormClass.upSnake = null;
            this.Close();
        }

        private void UpSnake_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormClass.user.Enabled = true;
        }
    }
}
