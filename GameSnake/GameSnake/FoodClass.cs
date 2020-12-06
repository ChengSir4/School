using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSnake
{
    public class FoodClass
    {
        static Random r = new Random();//随机数种子
        private static Point[] Food = new Point[448];//食物会出现的全部坐标
        private Point point;//食物坐标
        private int index = 0;
        public Point FoodPoint { get { return point; } }
        static FoodClass()
        {
            int x = 10, y = 25;
            for (int i = 0; i < Food.Length; i++)
            {
                Food[i].X = x;
                x += 23;
                if (x == 654)
                    x = 10;
            }
            for (int i = 0; i < Food.Length; i++)
            {
                Food[i].Y = y;
                y += 23;
                if (y == 393)
                    y = 25;
            }
        }
        //修改食物坐标
        public FoodClass()
        {
            int j;
            for (int i = 0; i < 500; i++)
            {
                j = r.Next(1, 448);
                Point p = Food[0];
                Food[0] = Food[j];
                Food[j] = p;
            }
            point = Food[0];
            New();
        }
        /// <summary>
        /// 与蛇身重合重置食物
        /// </summary>
        public void New()
        {
            int num = 0;
            for (int i = 0; i < FormClass.game.snake.snake.Count; i++)
            {
                if (num == 448)//蛇占满地图
                {
                    point = Food[index];
                    return;
                }
                if (index == 448)//食物索引
                    index = 0;
                if (Food[index].X == FormClass.game.snake.snake[i].Location.X && Food[index].Y == FormClass.game.snake.snake[i].Location.Y)
                {
                    i--;
                    index++;
                }
                else
                {
                    point = Food[index];
                    return;
                }
                num++;
            }
        }
    }
}
