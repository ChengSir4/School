
using System.Windows.Forms;

namespace 方块
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 600;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 253);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;

        private void ShapeMove()
        {
            //未移动到最底端与其他形状不重复
            if (ShapeTool.JudgeShapeMove(shape))
            {
                //向下移动形状
                Game.start(shape, Keys.Down);
            }
            else
            {
                //到达最顶端
                if (ShapeTool.JudgeShapeUpMove(shape))
                {
                    this.timer1.Stop();
                    DialogResult dr = MessageBox.Show("很遗憾，你输了,是否重新开始游戏!", "提示", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        boxes.Clear();
                        this.Controls.Clear();
                        this.rowShapeNumber = new int[20];
                        this.timer1.Interval = 600;
                        //画地图
                        Draw.DrawMap();
                        //加载第一个
                        shape = PictureBoxTool.LoadShape();
                        //加载下一个
                        nextShape = PictureBoxTool.LoadNextShape();
                        //添加到窗体
                        this.Controls.AddRange(shape.pictures);
                        this.Controls.AddRange(nextShape.pictures);
                        this.timer1.Start();
                    }
                    else
                        FormClass.form1.Close();
                }
                else
                {
                    //添加到形状集合
                    boxes.AddRange(shape.pictures);
                    //每行计数
                    ShapeTool.RowNumber(rowShapeNumber, shape);
                    //删除占满行
                    ShapeTool.FormDrop(rowShapeNumber);
                    for (int i = 0; i < nextShape.pictures.Length; i++)
                    {
                        nextShape.pictures[i].Location = new System.Drawing.Point(nextShape.pictures[i].Location.X - 280, nextShape.pictures[i].Location.Y - 90);
                    }
                    //更换
                    shape = nextShape;
                    //加载下一个
                    nextShape = PictureBoxTool.LoadNextShape();
                    //新的添加到窗体
                    FormClass.form1.Controls.AddRange(nextShape.pictures);
                    this.timer1.Interval = 600;
                }
            }
        }

        private void JudgeUserKey(Keys key)
        {
            if (key == Keys.Down)
                this.timer1.Interval = 10;
            else if (User.Input(key))
                Game.start(shape, key);
        }
    }
}

