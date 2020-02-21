using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Net;

namespace QQchy
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            Info.headP = new Bitmap("./Resources/headP/2017011518.jpg");
            Info.SIp = "166.111.140.57";
            Info.SPort = 8000;
            Info.gget = 1000;
            this.ImgBox.Image = new Bitmap(Info.headP, 128, 128);
            this.DialogResult = DialogResult.No;

        }

        static bool LoginRequest()
        {
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(Info.SIp, Info.SPort);
            }
            catch
            {
                MessageBox.Show("连接失败", "登录提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return false;
            }
            if (client.Connected)
            {
                NetworkStream Stream = client.GetStream();
                byte[] send = Encoding.Default.GetBytes(Info.UserName + "_" + Info.Password);
                Stream.Write(send, 0, send.Length);

                byte[] buffer = new byte[1024];
                string response = Encoding.Default.GetString(buffer, 0, Stream.Read(buffer, 0, buffer.Length));
                if (response == "lol")
                {
                    Stream.Close();
                    client.Close();
                    return true;                  
                }
                else
                    MessageBox.Show("用户名密码错误", "登录提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return false;
            }
            else
                return false;
        }

        static public bool Logout()
        {
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(Info.SIp, Info.SPort);
            }
            catch
            {
                return false;
            }
            if (client.Connected)
            {
                NetworkStream Stream = client.GetStream();
                byte[] send = Encoding.Default.GetBytes("logout"+Info.UserName);
                Stream.Write(send, 0, send.Length);

                byte[] buffer = new byte[1024];
                string response = Encoding.Default.GetString(buffer, 0, Stream.Read(buffer, 0, buffer.Length));
                if (response == "loo")
                {
                    Stream.Close();
                    client.Close();
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        private void LoginB_Click(object sender, EventArgs e)
        {
            Info.UserName = UserT.Text;
            Info.Password = PassT.Text;
            try
            {
                Info.CPort = int.Parse(UserT.Text.Substring(6)) + 10000;
            }
            catch
            {
                MessageBox.Show("用户名非法", "登录提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }

            IPEndPoint[] listeners = IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpListeners();
            foreach (IPEndPoint p in listeners)
            {
                if (p.Port == Info.CPort)
                {
                    MessageBox.Show("端口号已被占用", "登录提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            if (LoginRequest())
            {
                Info.TCPmode = !checkBox1.Checked;
                this.DialogResult = DialogResult.OK;
            }
            return;
        }

        private void UserT_TextChanged(object sender, EventArgs e)
        {
            if (UserT.Text.Length != 10)
                return;
            if (System.IO.File.Exists("./Resources/headP/" + UserT.Text + ".jpg"))
            {
                Info.headP = new Bitmap("./Resources/headP/" + UserT.Text + ".jpg");
                this.ImgBox.Image = new Bitmap(Info.headP, 128, 128);
            }
            else
            {
                int num = Convert.ToInt32(UserT.Text.Substring(8)) % 19 + 1;
                string st = "./Resources/headP/(" + num.ToString() + ").jpg";
                if (System.IO.File.Exists(st))
                    Info.headP = new Bitmap(st);
                else
                {
                    MessageBox.Show("您的资源文件保存位置错误，将无法使用头像", "文件提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    Close();
                    return;
                }
                this.ImgBox.Image = new Bitmap(Info.headP, 128, 128);
            }
            return;
        }
    }
}
