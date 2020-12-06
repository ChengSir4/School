using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameSnake
{
    public partial class Chat : Form
    {
        public Chat()
        {
            InitializeComponent();
        }
        Button Lensin;//确认
        TextBox txtIp;//服务器Ip
        TextBox txtchat;//消息框
        TextBox userchat;//用户输入文本框
        Socket socket;//通信Socket
        Thread thread;
        private void Chat_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            //设置窗体
            this.Text = "聊天";
            this.MaximizeBox = false;
            this.BackColor = Color.White;
            this.Size = new Size(650, 400);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            //创建消息框
            txtchat = new TextBox();
            txtchat.WordWrap = true;
            txtchat.ReadOnly = true;
            txtchat.Multiline = true;
            txtchat.Size = new Size(634, 250);
            txtchat.BackColor = Color.AntiqueWhite;
            txtchat.BorderStyle = BorderStyle.None;
            txtchat.ScrollBars = ScrollBars.Vertical;
            txtchat.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            //用户输入消息框
            userchat = new TextBox();
            userchat.Multiline = true;
            userchat.BackColor = Color.White;
            userchat.Size = new Size(634, 80);
            userchat.Location = new Point(0, 250);
            userchat.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            userchat.BorderStyle = BorderStyle.None;
            Button btnsend = new Button();
            btnsend.Text = "发送";
            btnsend.Click += Click_Chat;
            btnsend.Size = new Size(80, 25);
            btnsend.BackColor = Color.White;
            btnsend.Location = new Point(550, 333);
            txtIp = new TextBox();
            txtIp.Size = new Size(120, 20);
            txtIp.Location = new Point(439, 2);
            Lensin = new Button();
            Lensin.Text = "连接";
            Lensin.Click += Click_Lensin;
            Lensin.Size = new Size(60, 25);
            Lensin.Location = new Point(558, 0);
            this.Controls.Add(txtIp);
            this.Controls.Add(Lensin);
            this.Controls.Add(btnsend);
            this.Controls.Add(txtchat);
            this.Controls.Add(userchat);
        }
        void Click_Lensin(object sender, EventArgs e)
        {
            if (socket == null && !string.IsNullOrEmpty(txtIp.Text))
            {
                try
                {
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//创建socket
                    IPAddress iP = IPAddress.Parse(txtIp.Text);//连接的IP地址
                    IPEndPoint iPEnd = new IPEndPoint(iP, 8100);//指定的地址和端口号
                    socket.Connect(iPEnd);//建立连接
                    //给服务器发送昵称，是否已经连接
                    socket.Send(Encoding.UTF8.GetBytes(FormClass.user.txtname.Text));
                    //接受数据
                    thread = new Thread(AcceptChat);
                    thread.IsBackground = true;
                    thread.Start();
                }
                catch
                {
                    MessageBox.Show("服务器异常，连接服务器失败");
                    this.Close();
                }
            }
            else if (socket != null)
            {
                MessageBox.Show("服务器已连接");
            }
            else
                MessageBox.Show("服务器名不能为空");
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Click_Chat(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(userchat.Text))
                MessageBox.Show("输入不能为空");
            else if (!string.IsNullOrEmpty(txtIp.Text))
            {
                string str = FormClass.user.txtname.Text + ": " + userchat.Text;
                byte[] by = Encoding.UTF8.GetBytes(str);
                socket.Send(by);
                txtchat.Text += FormClass.user.txtname.Text + ": " + userchat.Text + "\r\n";
                txtchat.SelectionStart = txtchat.Text.Length - 1;
                txtchat.ScrollToCaret();
                userchat.Clear();
                userchat.Focus();
            }
            else
                MessageBox.Show("服务器名不能为空");
        }
        /// <summary>
        /// 接收数据
        /// </summary>
        void AcceptChat()
        {
            byte[] by = new byte[1024 * 1024];
            while (true)
            {
                try
                {
                    int r = socket.Receive(by);
                    if (socket.Poll(10, SelectMode.SelectRead))
                    {
                        txtchat.Text += "断开连接\r\n";
                        MessageBox.Show("该用户已登录，无法登录");
                        this.Close();
                        break;
                    }
                    string str = Encoding.UTF8.GetString(by, 0, r);
                    this.txtchat.Text += str + "\r\n";
                    txtchat.SelectionStart = txtchat.Text.Length - 1;
                    txtchat.ScrollToCaret();
                }
                catch
                {
                    this.socket.Close();
                    break;
                }
            }
        }
        /// <summary>
        /// 窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Chat_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.socket != null)
                this.socket.Close();
            FormClass.user.Enabled = true;
        }
    }
}
