using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 方块
{
    /// <summary>
    /// 形状类
    /// </summary>
    abstract class Shape
    {
        public int id;
        //每个形状的块
        public PictureBox[] pictures;

        public abstract void modifyShape();
        public Shape(int id, PictureBox[] picture)
        {
            this.id = id;
            this.pictures = picture;
        }
    }
}
