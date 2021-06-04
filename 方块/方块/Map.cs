using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 方块
{
    static class Map
    {
        public static void MyMap()
        {
            OneRow();
            LastRow();
            OneColumn();
            TwoColumn();
            LastColumn();
            ScoreAndNext();
            LabelMap();
        }
        /// <summary>
        /// 第一整行
        /// </summary>
        /// <param name="form">窗体对象</param>
        private static void OneRow()
        {
            Row("1", 0, 3, 20);
        }
        /// <summary>
        /// 最后一整行
        /// </summary>
        /// <param name="form">窗体对象</param>
        private static void LastRow()
        {
            Row("LastRow", 0, 630, 20);
        }
        /// <summary>
        /// 第一列
        /// </summary>
        /// <param name="form">窗体对象</param>
        private static void OneColumn()
        {
            Column("1", 0, 30, 20);
        }
        /// <summary>
        /// 第二列
        /// </summary>
        /// <param name="form">窗体对象</param>
        private static void TwoColumn()
        {
            Column("2", 330, 30, 20);
        }
        /// <summary>
        /// 最后一列
        /// </summary>
        /// <param name="form">窗体对象</param>
        private static void LastColumn()
        {
            Column("lastColumn", 570, 30, 20);
        }
        /// <summary>
        /// 成绩、下一个的布局
        /// </summary>
        /// <param name="form">窗体对象</param>
        private static void ScoreAndNext()
        {
            FormClass.form1.Controls.Add(PictureBoxTool.CreatePictureBox("2", "1", 5, 360, 30));
            FormClass.form1.Controls.Add(PictureBoxTool.CreatePictureBox("2", "2", 5, 540, 30));
            FormClass.form1.Controls.Add(PictureBoxTool.CreatePictureBox("13", "1", 5, 360, 330));
            FormClass.form1.Controls.Add(PictureBoxTool.CreatePictureBox("13", "2", 5, 540, 330));
            int y = 240;
            for (int i = 0; i < 13; i++)
            {
                if (i < 3 || i > 7)
                {
                    Row("score", 360, y, 7);
                }
                y += 30;
            }
        }
        /// <summary>
        /// 地图文本控件
        /// </summary>
        /// <param name="form">窗体对象</param>
        private static void LabelMap()
        {
            Label label1 = new Label();
            Label label2 = new Label();
            Label label3 = new Label();
            label1.AutoSize = true;
            label2.AutoSize = true;
            label3.AutoSize = true;
            //label1
            label1.Text = "NEXT";
            label1.Name = "next";
            label1.Font = new System.Drawing.Font("方正粗黑宋简体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label1.Location = new System.Drawing.Point(429, 36);
            label1.Size = new System.Drawing.Size(99, 34);
            //Label2
            label2.Text = "Score";
            label2.Name = "laScore";
            label2.Font = new System.Drawing.Font("方正粗黑宋简体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label2.Location = new System.Drawing.Point(430, 333);
            label2.Size = new System.Drawing.Size(99, 34);
            //label3
            label3.Text = "0";
            label3.Name = "score";
            label3.Font = new System.Drawing.Font("方正粗黑宋简体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label3.Location = new System.Drawing.Point(400, 390);
            label3.Size = new System.Drawing.Size(34, 34);
            FormClass.form1.Controls.Add(label1);
            FormClass.form1.Controls.Add(label2);
            FormClass.form1.Controls.Add(label3);
        }
        /// <summary>
        /// 打印行
        /// </summary>
        /// <param name="form">窗体对象</param>
        /// <param name="rowOrColumnName">行名</param>
        /// <param name="x">x坐标</param>
        /// <param name="y">y坐标</param>
        /// <param name="number">个数</param>
        private static void Row(string rowName, int x, int y, int number)
        {
            for (int i = 1; i <= number; i++)
            {
                FormClass.form1.Controls.Add(PictureBoxTool.CreatePictureBox(rowName, i.ToString(), 5, x, y));
                x += 30;
            }
        }
        /// <summary>
        /// 打印列
        /// </summary>
        /// <param name="form">窗体对象</param>
        /// <param name="columnName">列名</param>
        /// <param name="x">x坐标</param>
        /// <param name="y">y坐标</param>
        /// <param name="number">个数</param>
        private static void Column(string columnName, int x, int y, int number)
        {
            for (int i = 1; i <= number; i++)
            {
                FormClass.form1.Controls.Add(PictureBoxTool.CreatePictureBox(columnName, i.ToString(), 5, x, y));
                y += 30;
            }
        }
    }
}
