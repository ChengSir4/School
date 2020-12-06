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

namespace Snake_服务器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //socket采用Ipv4，传输为流，协议为tcp
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Dictionary<string, Socket> UserSocket = new Dictionary<string, Socket>();//创建键值对集合用来存放客户端的地址和端口号
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            string ComName = Dns.GetHostName();//获取主机名
            IPAddress[] iplist = Dns.GetHostEntry(ComName).AddressList;//获取ip地址列表
            for (int i = 0; i < iplist.Length; i++)
            {
                if (iplist[i].AddressFamily == AddressFamily.InterNetwork)//判断是否为ipv4的地址
                {
                    textBox1.Text = iplist[i].ToString();
                    break;
                }
            }
            IPAddress ip = IPAddress.Parse(textBox1.Text);//提供ip地址
            IPEndPoint ipEnd = new IPEndPoint(ip, 8100);//指定服务器的ip和端口
            socket.Bind(ipEnd);//绑定服务器的地址和端口
            socket.Listen(10);//设置最大监听数
            txtchat.Text += "开始监听...\r\n";
            Thread thread = new Thread(ListenChat);//创建一个线程执行
            thread.IsBackground = true;//设置为后台线程
            thread.Start();
        }
        /// <summary>
        /// 客户端连接成功保存Socket
        /// </summary>
        void ListenChat()
        {
            byte[] b = new byte[1024];
            while (true)
            {
                socketWatch = socket.Accept();//创建一个负责与客户端通信的socket
                int r = socketWatch.Receive(b);//接收用户的昵称
                string name = Encoding.UTF8.GetString(b, 0, r);
                int count = cmbName.Items.Count;
                for (int i = 0; i <= count; i++)
                {
                    //已有用户连接，判断昵称是否已经登录，已登录关闭，未登录添加
                    if (count > 0 && name == cmbName.Items[i].ToString())
                    {
                        socketWatch.Close();
                        break;
                    }
                    else if (i == count - 1 || count == 0)
                    {
                        txtchat.Text += socketWatch.RemoteEndPoint.ToString() + "连接成功\r\n";//将连接客户端的ip地址和端口号显示在文本框中
                        this.cmbName.Items.Add(name);
                        UserSocket.Add(socketWatch.RemoteEndPoint.ToString(), socketWatch);//将地址和所对应的Socket添加到键值对集合
                        cmbSoket.Items.Add(socketWatch.RemoteEndPoint.ToString());//将客户端地址和端口号添加到下拉菜单
                        Thread thread = new Thread(SendChat);
                        thread.IsBackground = true;
                        thread.Start(socketWatch);
                        break;
                    }
                }
            }
        }
        Socket socketWatch;//与用户通信的socket
        /// <summary>
        /// 接收客户端的消息
        /// </summary>
        /// <param name="socketclientpara"></param>
        void SendChat(object socketclientpara)
        {
            Socket socketclient = socketclientpara as Socket;//保存当前连接的Socket
            byte[] by = new byte[1024 * 1024];
            while (true)
            {
                try
                {
                    int r = socketclient.Receive(by);//接受用户发送的信息，没有可读取的数据时处于阻止状态
                    string str = Encoding.UTF8.GetString(by, 0, r);//用户发送的字节数转换为字符串
                    txtchat.Text += str + "\r\n";
                    foreach (string item in UserSocket.Keys)//获取所有键(ip以及端口号)
                    {
                        if (item != socketclient.RemoteEndPoint.ToString())//不对同一个用户发送
                            UserSocket[item].Send(Encoding.UTF8.GetBytes(str));
                    }
                }
                catch
                {
                    int i = 0;//记录索引
                    foreach (string item in UserSocket.Keys.ToArray())//获取所有键(ip以及端口号)
                    {
                        //断开连接，删除客户端对应的Socket
                        if (UserSocket[item].Poll(10, SelectMode.SelectRead))
                        {
                            UserSocket.Remove(item);
                            cmbName.Items.RemoveAt(i);
                            cmbSoket.Items.RemoveAt(i);
                            txtchat.Text += socketclient.RemoteEndPoint + ": 断开连接\r\n";
                            i--;
                        }
                        i++;
                    }
                    socketclient.Close();
                    break;
                }
            }
        }
    }
}
