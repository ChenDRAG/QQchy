using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
namespace QQchy
{
    public delegate void SetAbove3(string name);
    public delegate void SetAbove7(int index);
    public partial class ChatList : Form
    {
        public event SetAbove3 setabove;
        public event SetAbove7 groupevent;
        static public List<Friend> Friends = new List<Friend>();
        static public List<Chat> Chats = new List<Chat>();
        public ChatList()
        {
            InitializeComponent();
            this.SearchB.Image = new Bitmap("./Resources/Search.png");
            RefreshallShow();

        }
        private void SearchB_Click(object sender, EventArgs e)
        {
            if (SearchT.Text.Length != 10)
            {
                MessageBox.Show("用户不存在", "查询结果", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }
            addthisfriend(SearchT.Text);
            return;
        }

        public void addthisfriend(string name, bool silentmode = false)
        {
            Friend f = new Friend(name);
            if (name == Info.UserName)
            {
                if (!silentmode)
                    MessageBox.Show("您在线上", "查询结果", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }
            for (int i = 0; i < Friends.Count; i++)
            {
                if (f.Name == Friends[i].Name)
                {
                    if (!silentmode)
                        MessageBox.Show("好友已存在", "查询结果", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(Info.SIp, Info.SPort);
            }
            catch
            {
                if (!silentmode)
                    MessageBox.Show("连接失败", "连接信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                client.Close();
            }
            if (client.Connected)
            {
                NetworkStream ClientToServer = client.GetStream();
                string QueryInfo = "q" + f.Name;
                MainChat.TcpSend(ClientToServer, QueryInfo);
                string response = MainChat.TcpReceive(ClientToServer);
                if (response.Length > 0)
                {
                    if (response.StartsWith("I") || response.StartsWith("P"))
                    {
                        if (!silentmode)
                            MessageBox.Show("未找到用户", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else if (response == "n")
                    {
                        if (!silentmode)
                            MessageBox.Show("用户不在线", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        f.IP = response;
                        f.Online = true;
                        f.setabove += new SetAbove(Chatlist_close);
                        f.setabove5 += new SetAbove5(addmember);
                        Friends.Add(f);

                    }
                }
                ClientToServer.Close();
            }
            client.Close();
            if (!silentmode)
                AddShow(Friends.Count - 1);
            return;
        }

        public void Chatlist_close(string name) 
        {
            setabove(name);
            this.Close();
        }

        public bool hasmember(string name)
        {
            for (int i = 0; i < MemberlistView.Items.Count; i++)
            {
                if (MemberlistView.Items[i].Text == name)
                    return true;
            }
            return false;
            
        }
        public void addmember(string name)
        {
            if (hasmember(name))
            {
                MessageBox.Show(name+"集合成员已添加过", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                TcpClient client = new TcpClient();
                try
                {

                    client.Connect(Info.SIp, Info.SPort);
                }
                catch
                {
                    MessageBox.Show("连接失败", "连接信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    client.Close();
                }
                if (client.Connected)
                {
                    NetworkStream ClientToServer = client.GetStream();
                    string QueryInfo = "q" + name;
                    MainChat.TcpSend(ClientToServer, QueryInfo);
                    string response = MainChat.TcpReceive(ClientToServer);
                    if (response.Length > 0)
                    {
                        if (response.StartsWith("I") || response.StartsWith("P"))
                        {
                            MessageBox.Show("未找到用户", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                            return;
                        }
                        else if (response == "n")
                        {
                            MessageBox.Show("用户不在线", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                            return;
                        }
                        else
                        {
                            ListViewItem list_data = new ListViewItem();
                            list_data.Text = name;
                            MemberlistView.Items.Add(list_data);
                        }
                    }
                    ClientToServer.Close();
                }
                client.Close();   
            }
        }

        private bool RefreshShow(Friend friend)
        {
            FriendInfo TempTag = friend.tag;
            string TempString = friend.Name;
            for (int i = 0; i < FriendLayoutPanel.Controls.Count; i++)
            {
                if (FriendLayoutPanel.Controls[i].Name == TempString)
                {
                    //break;
                    return true;
                }
            }
            FriendLayoutPanel.Controls.Add(TempTag);
            return true;
        }

        private bool AddShow(int i)
        {
            FriendLayoutPanel.Controls.Add(Friends[i].tag);
            return true;
        }

        public bool RefreshallShow()
        {
            for (int i = 0; i < Friends.Count; i++)
            {
                Friends[i].update();
                RefreshShow(Friends[i]);
            }
            for (int i = 0; i < Chats.Count; i++)
            {
                if (i >= GroupPanel.Controls.Count)
                    GroupPanel.Controls.Add(Chats[i].tag);
            }
            
            for (int i = 0; i < Chats.Count; i++)
            {
                if (Chats[i].index != i)
                    MessageBox.Show("debug error2", "群聊提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                GroupPanel.Controls.Add(Chats[i].tag);
            }


            while (MemberlistView.Items.Count > 0)
                MemberlistView.Items.RemoveAt(0);
            if (MemberlistView.Items.Count > 0)
            {
                MemberlistView.Items.Clear();
                MemberlistView.Clear();
            }
            MemberlistView.Clear(); 
            MemberlistView.Items.Clear();

            return true;
        }

        private void FriendLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FriendLayoutPanel_DoubleClick(object sender, EventArgs e)
        {

        }

        private void FriendLayoutPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        public int haschat(string[] fnames)
        {
            int[] findexs = new int[100];//all  -1
            for (int i = 0; i < 100; i++)
            {
                findexs[i] = -1;
            }
            bool ownflag = false;
            for (int i = 0; i < fnames.Length; i++)
            {
                if (fnames[i] == Info.UserName)
                {
                    findexs[i] = 666;
                    ownflag = true;
                    continue;
                }
                for (int j = 0; j < ChatList.Friends.Count; j++)
                {
                    if (ChatList.Friends[j].Name == fnames[i])
                    { 
                        findexs[i] = j;
                        break;
                    }
                }
            }

            for (int i = 0; i < ChatList.Chats.Count; i++)
            {
                if(ownflag == false)
                { 
                    if (fnames.Length != ChatList.Chats[i].members.Count)
                        continue;
                }
                else
                { 
                    if(fnames.Length != ChatList.Chats[i].members.Count + 1)
                            continue;
                }
                bool flag = true;
                for (int j = 0; j < fnames.Length; j++)
                {
                    if (findexs[j] == 666)     //indicate the user himself
                    {
                        continue;
                    }
                    if (!ChatList.Chats[i].members.Contains(findexs[j]))
                    { 
                        flag = false;
                        break;
                    }
                }
                if (flag)
                    return i;
            }
            return -1;
        }

        public void startgroup(int gindex)
        {
            groupevent(gindex);
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Info.TCPmode == false)
            {
                    MessageBox.Show("TCP模式功能", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    return;
            }
            if (MemberlistView.Items.Count <= 1)
            {
                MessageBox.Show("人数不足不能发起", "群聊提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }
            string[] fnames = new string[MemberlistView.Items.Count];
            for (int i = 0; i < fnames.Length; i++)
            {
                fnames[i] = MemberlistView.Items[i].Text;
            }
            if (haschat(fnames) != -1)
            {
                MessageBox.Show("群聊已经存在", "群聊提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }
            Chat c = new Chat();
            bool flag = true;
            
            for (int i = 0; i < Friends.Count; i++)
            {
                if (hasmember(Friends[i].Name))
                    if(flag)
                    {
                        c.setabove6 += new SetAbove6(startgroup);
                        c.setup(Friends[i].Name, Chats.Count);
                        c.members.Add(i);
                        flag = false;
                    }
                    else
                        c.members.Add(i);
            }

            Chats.Add(c);
            GroupPanel.Controls.Add(c.tag);

        }

        private void SearchT_TextChanged(object sender, EventArgs e)
        {

        }

        private void MemberlistView_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
