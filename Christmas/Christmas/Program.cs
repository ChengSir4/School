using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Christmas
{
    class Program
    {
        static Random r = new Random();
        static Point[] Deng = new Point[20];
        static Point[] deng = new Point[78];
        static List<Point> xue = new List<Point>();
        static List<Point> points = new List<Point>();
        static List<Point> shupoints = new List<Point>();
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.WindowWidth, 35);
            Console.Title = "圣诞快乐";
            Shu();//加载树
            LoadDeng();//加载灯
            Xue();//加载雪
            while (true)
            {
                DengMethod();//灯闪烁
                Move();//雪移动
                Move();//雪移动
                Xue();
                Thread.Sleep(60);
            }
        }
        static void Shu()
        {
            int w = Console.WindowWidth;
            int h = Console.WindowHeight;
            Console.SetCursorPosition(w / 2, 5);
            int top = Console.CursorTop;
            int left = Console.CursorLeft;
            int gtop = top;
            int glift = left;
            Console.ForegroundColor = ConsoleColor.White;
            #region 树身
            int[] arr = new int[] { 1, 2, 3, 4, 5 };
            for (int j = 0; j < 5; j++)
            {
                if (j == 4)
                {
                    Console.SetCursorPosition(++left, top);
                    for (int z = 0; z < arr[j]; z++)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        shupoints.Add(new Point(Console.CursorLeft, Console.CursorTop));
                        Console.Write("▼");
                    }
                }
                else
                {
                    if (j < 2)
                        Console.ForegroundColor = ConsoleColor.White;
                    else
                        Console.ForegroundColor = ConsoleColor.Green;
                    shupoints.Add(new Point(Console.CursorLeft, Console.CursorTop));
                    Console.Write(" ▲");
                    for (int z = 1; z < arr[j]; z++)
                    {
                        if (z != 0 && z != arr[j] - 1 && j >= 2)
                            points.Add(new Point(Console.CursorLeft, Console.CursorTop));
                        shupoints.Add(new Point(Console.CursorLeft, Console.CursorTop));
                        Console.Write("▲");
                    }
                }
                Console.SetCursorPosition(--left, ++top);
            }
            Console.SetCursorPosition(left += 2, top);
            int[] s = new int[] { 4, 6, 8, 10 };
            for (int i = 1; i <= h / 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (j == 3)
                    {
                        for (int z = 0; z < s[j]; z++)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            shupoints.Add(new Point(Console.CursorLeft, Console.CursorTop));
                            Console.Write("▼");
                        }
                    }
                    else
                    {
                        for (int z = 0; z < s[j]; z++)
                        {
                            if (z != 0 && z != s[j] - 1)
                                points.Add(new Point(Console.CursorLeft, Console.CursorTop));
                            Console.ForegroundColor = ConsoleColor.Green;
                            shupoints.Add(new Point(Console.CursorLeft, Console.CursorTop));
                            Console.Write("▲");
                        }
                    }
                    Console.SetCursorPosition(left -= 2, ++top);
                }
                for (int j = 0; j < 4; j++)
                    s[j] += 3;
                Console.SetCursorPosition(left += 5, top);
            }
            #endregion
            #region 树干
            gtop = Console.CursorTop - 1;
            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(glift, ++gtop);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("█");
            }
            #endregion
        }
        static void LoadDeng()
        {
            int n = 2;
            deng[0] = points[0];
            deng[1] = points[1];
            for (int i = 2; i < points.Count; i++)
            {
                if (n == deng.Length)
                    break;
                if (i % 2 == 0)
                {
                    deng[n] = points[i];
                    n++;
                }
            }
        }
        static void DengMethod()
        {
            for (int i = 0; i < deng.Length; i++)
            {
                if (deng[i].X == 0)
                    break;
                RandomColor();
                Console.SetCursorPosition(deng[i].X, deng[i].Y);
                Console.Write("★");
            }
        }
        static void RandomColor()
        {
            switch (r.Next(0, 6))
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
            }
        }
        static void Xue()
        {
            int w = Console.WindowWidth;
            int num = r.Next(0, 2);
            if (num == 0)
            {
                RandomColor();
                Console.Write("＊");
            }
            for (int i = num; i < w; i++)
            {
                Console.SetCursorPosition(i, 0);
                xue.Add(new Point(i, 0));
                Console.Write("＊");
                Console.ForegroundColor = ConsoleColor.White;
                int number = r.Next(1, r.Next(8, 18));
                if (i % 2 == 0)
                    while (number % 2 != 0)
                        number = r.Next(1, r.Next(8, 18));
                else if (i % 2 != 0)
                    while (number % 2 == 0)
                        number = r.Next(1, r.Next(8, 18));
                i += number;
                i--;
            }
        }
        static void Move()
        {
            for (int i = 0; i < xue.Count; i++)
            {
                Console.SetCursorPosition(xue[i].X, xue[i].Y);
                Console.Write("  ");
                int y = xue[i].Y + 1;
                xue[i] = new Point(xue[i].X, y);
                if (TfZ(xue[i]))
                {
                    xue.RemoveAt(i);
                    i--;
                }
                else
                {
                    RandomColor();
                    Console.SetCursorPosition(xue[i].X, xue[i].Y);
                    Console.Write("＊");
                }
            }
        }
        /// <summary>
        /// 判断当前雪花是否与树重合
        /// </summary>
        /// <param name="point"></param>
        /// <returns>重合返回true，否则返回false</returns>
        static bool TfZ(Point point)
        {
            int h = Console.WindowHeight;
            for (int i = 0; i < shupoints.Count; i++)
            {
                if (point.X == shupoints[i].X && point.Y == shupoints[i].Y || point.Y == h - 2)
                    return true;
                else if (point.X - 2 == shupoints[i].X && point.Y == shupoints[i].Y || point.Y == h - 2)
                    return true;
                else if (point.X + 1 == shupoints[i].X && point.Y == shupoints[i].Y || point.Y == h - 2)
                    return true;
            }
            return false;
        }
    }
}
