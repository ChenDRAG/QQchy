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
    public delegate void SetAbove(string name);
    public delegate void SetAbove5(string name);
    public class Friend
    {
        public event SetAbove setabove;
        public event SetAbove5 setabove5;
        public string Name;
        public string Message = "";
        public bool Online = true;
        public string IP = "";
        public bool newmess = false;
        public List<string> dias = new List<string>();
        public FriendInfo tag;
        public Bitmap headP;

        public void Helpsetabove(string name)
        {
            setabove(name);

        }
        public Friend(string name)
        {
            Name = name;
            if (System.IO.File.Exists("./Resources/headP/" + Name + ".jpg"))
                headP = new Bitmap("./Resources/headP/" + Name + ".jpg");
            else
                headP = new Bitmap("./Resources/headP/(" + Convert.ToString(Convert.ToInt32(Name.Substring(8)) % 19 + 1) + ").jpg");
            tag = new FriendInfo(Name);
            tag.setabove += new SetAbove2(Helpsetabove);       
            tag.setabove4 += new SetAbove4(Helpsetabove5);
            tag.SetPortrait(headP);
            return;
        }
        public void Helpsetabove5(string name)
        {
            if (Online == false)
            {
                //MessageBox.Show("好友不在线，无法发起群聊。", "连接信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            setabove5(name);
        }
        public void update()
        {
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(Info.SIp, Info.SPort);
            }
            catch
            {
                MessageBox.Show("找不到中央服务器", "连接信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                client.Close();
                return;
            }
            if (client.Connected)
            {
                NetworkStream ClientToServer = client.GetStream();
                string QueryInfo = "q" + Name;
                MainChat.TcpSend(ClientToServer, QueryInfo);
                string response = MainChat.TcpReceive(ClientToServer);
                if (response.Length > 0)
                {
                    if (response.StartsWith("I") || response.StartsWith("P"))
                    {
                        Online = false;
                        tag.updateonline(Online);
                    }
                    else if (response == "n")
                    {
                        Online = false;
                        tag.updateonline(Online);
                    }
                    else
                    {
                        Online = true;
                        tag.updateonline(Online);
                    }
                }
                ClientToServer.Close();
            }
            client.Close();
        }

    }


}
