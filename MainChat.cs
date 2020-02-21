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
using System.Net;
using System.Threading;
using System.IO;

namespace QQchy
{
    public partial class MainChat : Form
    {
        bool Isgroup = false;
        string Name = "";
        int _index = -1;
        int _gindex = -1;

        private TcpListener Listener;
        private TcpClient client;
        private Thread recv_thread;
        private ChatList MC;
        public MainChat()
        {
            InitializeComponent();
            this.myImg.Image = new Bitmap(Info.headP);
            this.myname.Text = Info.UserName;
            this.theirimgs.Image = new Bitmap("./Resources/headP/default.jpg");
            this.theirnames.Text = "Waiting...";
            this.FileB.Image = new Bitmap("./Resources/file.png");
            //Resources
            if (Info.TCPmode)
            {
                recv_thread = new Thread(Listen);
                recv_thread.IsBackground = true;
                recv_thread.Start();
            }
            else
            {
                recv_thread = new Thread(UDPListen);
                recv_thread.IsBackground = true;
                recv_thread.Start();
            }

            MC = new ChatList();
            MC.setabove += new SetAbove3(Helpsetabove);        
            MC.groupevent += new SetAbove7(switch2group);
        }
        private void Listen()
        {
            int LisPort = int.Parse(Info.UserName.Substring(6)) + 10000;
            Listener = new TcpListener(IPAddress.Any, LisPort);
            Listener.Start();
            AsyncCallback LisCallback = new AsyncCallback(recv_callback);
            Listener.BeginAcceptTcpClient(LisCallback, Listener);
        }
        //一个单独的线程单独端口监听所有信息，并另开线程处理信息
        private void recv_callback(IAsyncResult event_)
        {
            Listener = (TcpListener)event_.AsyncState;
            client = Listener.EndAcceptTcpClient(event_);
            Thread AcpThread = new Thread(recv_sort);  
            AcpThread.Start();
            AsyncCallback LisCallback = new AsyncCallback(recv_callback);
            Listener.BeginAcceptTcpClient(LisCallback, Listener);
        }
        private void recv_sort()
        {
            this.Invoke(new EventHandler(delegate
            {
                NetworkStream TCPstream = client.GetStream();
                string fname = TcpReceive(TCPstream);
                TcpSend(TCPstream, "ACK");
                string recvmess = TcpReceive(TCPstream);
                int index = -1;
                for (int i = 0; i < ChatList.Friends.Count; i++)
                {
                    if (ChatList.Friends[i].Name == fname)
                        index = i;
                }
                //收到文件
                if (recvmess.StartsWith("[FileName]"))
                {
                    if (index == -1)
                    {
                        Friend f = new Friend(fname);
                        string address = client.Client.RemoteEndPoint.ToString();
                        string[] split = address.Split(new char[] { ':' }, 2);
                        f.IP = split[0];
                        f.Online = true;
                        f.setabove += new SetAbove(MC.Chatlist_close);
                        f.setabove5 += new SetAbove5(MC.addmember);
                        ChatList.Friends.Add(f);

                    }
                    bool IsError = false;
                    string message = recvmess;

                    int posTemp = message.IndexOf("[Length]");
                    string FileName = message.Substring("[FileName]".Length, posTemp - "[FileName]".Length);
                    int FileLength = int.Parse(message.Substring(posTemp + "[Length]".Length));
                    string path = ".\\" + Info.UserName;
                    if (!Directory.Exists(path))
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(path);
                        directoryInfo.Create();
                    }
                    string FilePath = path + "\\" + FileName;

                    FileStream WriteStream;
                    try
                    {
                        WriteStream = new FileStream(FilePath, FileMode.Create, FileAccess.Write);
                    }
                    catch
                    {
                        MessageBox.Show("文件写入失败", "读写提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        return;
                    }

                    byte[] buffer = new byte[2048];
                    int ReceiveBytes = 0;
                    TCPstream.ReadTimeout = 20000;
                    fileL.Text = "正在接收文件";
                    int ReceiveLength = 0;
                    while (ReceiveLength < FileLength && !IsError)
                    {
                        try
                        {
                            ReceiveBytes = TCPstream.Read(buffer, 0, buffer.Length);
                            ReceiveLength += ReceiveBytes;
                            WriteStream.Write(buffer, 0, ReceiveBytes);
                        }
                        catch
                        {
                            IsError = true;
                            MessageBox.Show("文件接收中断", "读写提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    TCPstream.Flush();
                    TCPstream.Close();
                    if (!IsError)
                    {
                        WriteStream.Flush();
                        WriteStream.Close();
                    }
                    fileL.Text = "文件接收完成";
                    return;
                }
                else if (recvmess.StartsWith("[GROUP]"))//群聊消息
                {
                    string[] infoall = recvmess.Split((char)1);
                    string[] namesall = new string[infoall.Length - 2];
                    for (int i = 0; i < namesall.Length; i++)
                    {
                        namesall[i] = infoall[i + 1];
                    }
                    string itemt = infoall[infoall.Length - 1];
                    int haschat = MC.haschat(namesall);
                    if (haschat == -1)
                    {
                        for (int j = 0; j < namesall.Length; j++)
                        {
                            //如果namesall【j】不是好友则先加为好友
                            string frname = namesall[j];
                            if (frname == Info.UserName)
                                continue;
                            bool hasthisfriend = false;
                            for (int k = 0; k < ChatList.Friends.Count; k++)
                            {
                                if (ChatList.Friends[k].Name == frname)
                                {
                                    hasthisfriend = true;
                                    break;
                                }

                            }
                            if (hasthisfriend)
                                continue;
                            MC.addthisfriend(frname, true);
                        }
                        //组建后台群聊
                        bool flag = true;
                        Chat c = new Chat();
                        for (int i = 0; i < ChatList.Friends.Count; i++)
                        {
                            bool hasflag = false;
                            for (int j = 0; j < namesall.Length; j++)
                            {
                                if (namesall[j] == ChatList.Friends[i].Name)
                                { 
                                    hasflag = true;
                                    break;
                                }
                            }
                            if (!hasflag)
                                continue;
                            if (flag)
                            {
                                c.setabove6 += new SetAbove6(MC.startgroup);
                                c.setup(ChatList.Friends[i].Name, ChatList.Chats.Count);
                                c.members.Add(i);
                                flag = false;
                            }
                            else
                                c.members.Add(i);
                        }
                        ChatList.Chats.Add(c);
                        haschat = ChatList.Chats.Count - 1;
                    }
                    if (haschat == _gindex && Isgroup == true)
                    {

                        int tempi = -1;
                        for (int j = 0; j < ChatList.Friends.Count; j++)
                        {
                            if (ChatList.Friends[j].Name == namesall[0])
                            {
                                tempi = j;
                                break;
                            }
                        }
                        if (tempi == -1)
                        {
                            MessageBox.Show("出现连接异常2", "建群提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                            return;
                        }
                        Message NewSend = new Message(itemt, 0, ChatList.Friends[tempi].headP, namesall[0]);
                        ChatPanel.Controls.Add(NewSend);
                        ChatPanel.ScrollControlIntoView(NewSend);
                        ChatList.Chats[haschat].dias.Add(recvmess);
                        ChatList.Chats[haschat].newmess = false;
                        ChatList.Chats[haschat].tag.setstatus("");
                    }
                    else
                    { 
                        ChatList.Chats[haschat].newmess = true;
                        ChatList.Chats[haschat].dias.Add(recvmess);
                        ChatList.Chats[haschat].tag.setstatus("[您有新的未读消息]");
                    }
                }
                else
                {
                    if (index == -1)
                    {
                        Friend f = new Friend(fname);
                        //TcpClient tcpClient = Listener.AcceptTcpClient();
                        string address = client.Client.RemoteEndPoint.ToString();
                        string[] split = address.Split(new char[] { ':' }, 2);
                        f.IP = split[0];
                        f.Online = true;
                        f.newmess = true;
                        f.tag.setstatus("[您有新的未读消息]");
                        f.dias.Add(recvmess);
                        f.setabove += new SetAbove(MC.Chatlist_close);
                        f.setabove5 += new SetAbove5(MC.addmember);
                        ChatList.Friends.Add(f);
                    }
                    else
                    {
                        if (index == _index && Isgroup == false)
                        {
                            ChatList.Friends[index].dias.Add(recvmess);
                            ChatList.Friends[index].tag.setstatus("");
                            Message NewSend = new Message(recvmess, 0, ChatList.Friends[index].headP, fname);
                            ChatPanel.Controls.Add(NewSend);
                            ChatPanel.ScrollControlIntoView(NewSend);
                        }
                        else
                        {
                            ChatList.Friends[index].dias.Add(recvmess);
                            ChatList.Friends[index].newmess = true;
                            ChatList.Friends[index].tag.setstatus("[您有新的未读消息]");
                        }
                    }
                    return;
                }
            }));
        }

        static public void TcpSend(NetworkStream ClientToServer, string mess)
        {

            byte[] msg = Encoding.Default.GetBytes(mess);
            try
            {
                ClientToServer.Write(msg, 0, msg.Length);
            }
            catch
            {
                MessageBox.Show("发送消息失败", "连接提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
        }
        static public string TcpReceive(NetworkStream ClientToServer)
        {
            string recv = "";
            byte[] Buffer = new byte[1024];
            int length = 0;
            try
            {
                length = ClientToServer.Read(Buffer, 0, 1024);
                if (length > 0)
                    recv = Encoding.Default.GetString(Buffer, 0, length);
            }
            catch
            {
                MessageBox.Show("接收消息失败", "连接提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            return recv;
        }

        private string str_start0(string temp)
        {
            temp = "0" + temp;
            char[] chs = temp.ToCharArray();
            chs[0] = (char)0;
            temp = new string(chs);
            return temp;

        }

        private string mkperfix(int gid)
        {
            string s1 = "1";
            char[] chs = s1.ToCharArray();
            chs[0] = (char)1;
            s1 = new string(chs);
            string result = "[GROUP]" + s1 + Info.UserName + s1;
            for (int i = 0; i < ChatList.Chats[gid].members.Count; i++)
            {
                result = result + ChatList.Friends[ChatList.Chats[gid].members[i]].Name + s1;
            }
            return result;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            send_handler();
        }
        private void send_handler()
        {
            if (inputT.Text.Length == 0)
            {
                MessageBox.Show("请输入信息", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }
            if (!Isgroup)
            {
                if (ChatList.Friends[_index].Online == false)
                {
                    MessageBox.Show("好友不在线上，仅可查看历史", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    return;
                }
                if (Name == "" || _index == -1)
                {
                    MessageBox.Show("无发送对象", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    return;
                }
                bool flag = false;
                if (Info.TCPmode)
                    flag = SendText(ChatList.Friends[_index], inputT.Text);
                else
                    flag = UDPSendText(ChatList.Friends[_index], inputT.Text);
                if (flag)
                {
                    string temp = str_start0(inputT.Text);
                    ChatList.Friends[_index].dias.Add(temp);
                    if (temp[0] != 0)
                    {
                        MessageBox.Show("系统错误", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        return;
                    }
                    Message NewSend = new Message(inputT.Text, 1, ChatList.Friends[_index].headP, Name);
                    ChatPanel.Controls.Add(NewSend);
                    ChatPanel.ScrollControlIntoView(NewSend);
                    inputT.Clear();
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (_gindex == -1 || _gindex >= ChatList.Chats.Count)
                {
                    MessageBox.Show("不存在群聊", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    return;
                }
                bool successflag = true;
                string perfix = mkperfix(_gindex);
                for (int i = 0; i < ChatList.Chats[_gindex].members.Count; i++)
                {
                    int fid = ChatList.Chats[_gindex].members[i];
                    if (!SendText(ChatList.Friends[fid], perfix + inputT.Text))
                        successflag = false;
                    if (successflag)
                    {
                        fileL.Text = "成功分发消息";
                    }
                    else
                    {
                        fileL.Text = "";
                    }
                }
                ChatList.Chats[_gindex].dias.Add(perfix + inputT.Text);
                Message NewSend = new Message(inputT.Text, 1, Info.headP, Info.UserName);
                ChatPanel.Controls.Add(NewSend);
                ChatPanel.ScrollControlIntoView(NewSend);
                inputT.Clear();

            }

        }

        private bool SendText(Friend f, string Message, bool silentmode = false)
        {
            byte[] ACK = Encoding.Default.GetBytes(Info.UserName);
            byte[] SendMessage = Encoding.Default.GetBytes(Message);
            TcpClient NewClient = new TcpClient();
            try
            {
                int Port = int.Parse(f.Name.Substring(6)) + 10000;
                NewClient.Connect(f.IP, Port);
            }
            catch
            {   if (Isgroup == false)
                    MessageBox.Show("好友不在线上", "消息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                else
                    fileL.Text = "存在好友已下线";
                return false;
            }

            if (NewClient.Connected)
            {
                NetworkStream TCPstream = NewClient.GetStream();
                string response = "";
                try
                {
                    TCPstream.Write(ACK, 0, ACK.Length);//发送自己的名字，收到ACK时进行对话
                    byte[] ReturnMessage = new byte[20];
                    int length = TCPstream.Read(ReturnMessage, 0, ReturnMessage.Length);
                    response = Encoding.Default.GetString(ReturnMessage, 0, length);
                }
                catch
                {
                    TCPstream.Close();
                    NewClient.Close();
                    MessageBox.Show("握手失败", "消息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    return false;
                }
                if (response == "ACK")
                {
                    try
                    {
                        TCPstream.Write(SendMessage, 0, SendMessage.Length);
                    }
                    catch
                    {
                        TCPstream.Close();
                        NewClient.Close();
                        MessageBox.Show("发送失败", "消息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
                TCPstream.Close();
                NewClient.Close();
                return true;
            }
            return false;
        }

        private void NameLabel_Click(object sender, EventArgs e)
        {

        }

        private void MainChat_Load(object sender, EventArgs e)
        {

        }

        private void GroupButton_Click(object sender, EventArgs e)
        {
            MC.RefreshallShow();
            MC.ShowDialog();
        }
        public void clearChatPanel()
        {
            for (int i = 0; i < ChatPanel.Controls.Count; i++)
            {
                ChatPanel.Controls.RemoveAt(i);
            }
            while(ChatPanel.Controls.Count != 0)
                ChatPanel.Controls.RemoveAt(0);

        }
        public void RefreshAllchatshow()
        {
            clearChatPanel();
            if (Isgroup == false)
            {
                for (int i = 0; i < ChatList.Friends[_index].dias.Count; i++)
                {
                    Message NewSend;
                    if (ChatList.Friends[_index].dias[i][0] == 0)
                        NewSend = new Message(ChatList.Friends[_index].dias[i].Substring(1), 1, ChatList.Friends[_index].headP, Name);
                    else
                        NewSend = new Message(ChatList.Friends[_index].dias[i], 0, ChatList.Friends[_index].headP, Name);
                    ChatPanel.Controls.Add(NewSend);
                    ChatPanel.ScrollControlIntoView(NewSend);
                }
            }
            else
            {
                for (int i = 0; i < ChatList.Chats[_gindex].dias.Count; i++)
                {
                    Message NewSend;
                    //string fname = ChatList.Chats[_gindex].dias[i].Substring(0, 10);
                    string[] infoall = ChatList.Chats[_gindex].dias[i].Split((char)1);
                    string fname = infoall[1];//发送方名字
                    string itemt = infoall[infoall.Length - 1];
                    if (fname == Info.UserName)
                        NewSend = new Message(itemt, 1, Info.headP, fname);
                    else
                    {
                        int tempi = -1;
                        for (int j = 0; j < ChatList.Friends.Count; j++)
                        {
                            if(ChatList.Friends[j].Name == fname)
                            {
                                tempi = j;
                                break;
                            }
                        }
                        if (tempi == -1)
                        {
                            MessageBox.Show("出现连接异常", "建群提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                            return;
                        }
                        NewSend = new Message(itemt, 0, ChatList.Friends[tempi].headP, fname);
                    }
                    ChatPanel.Controls.Add(NewSend);
                    ChatPanel.ScrollControlIntoView(NewSend);
                }
            }
        }
        
         public void switch2group(int gindex)
        {
            Isgroup = true;
            _gindex = gindex;
            this.theirnames.Text = "[GROUP]\r\n"+ChatList.Friends[ChatList.Chats[gindex].members[0]].Name + "等人";
            this.theirimgs.Image = new Bitmap("./Resources/headP/default.jpg");
            ChatList.Chats[_gindex].tag.setstatus("");
            RefreshAllchatshow();
        }
        public void Helpsetabove(string name)
        {
            Isgroup = false;
            Name = name;
            for (int i = 0; i < ChatList.Friends.Count; i++)
            {
                if (ChatList.Friends[i].Name == Name)
                {
                    _index = i;
                    break;
                }
            }
            this.theirnames.Text = Name;
            this.theirimgs.Image = new Bitmap(ChatList.Friends[_index].headP);
            ChatList.Friends[_index].tag.setstatus("");
            RefreshAllchatshow();
        }

        private void FlowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FileB_Click(object sender, EventArgs e)
        {
            if (!Info.TCPmode)
            {
                MessageBox.Show("TCP模式功能", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }
            OpenFileDialog SelectFile = new OpenFileDialog();
            SelectFile.Filter = "All files (*.*)|*.*";
            if (SelectFile.ShowDialog() == DialogResult.OK)
            {
                if (!Isgroup)
                {
                    string file = Name + SelectFile.FileName;
                    Csendfile(file);
                }
                else
                {
                    Gsendfile(SelectFile.FileName);
                }

            }
        }
        private void Csendfile(string file)
        {
            string FileName = file;
            string fname = FileName.Substring(0, 10);
            FileName = FileName.Substring(10);

            string cancatenate = FileName.Substring(FileName.LastIndexOf('\\') + 1);
            FileStream ReadStream = new FileStream(FileName, FileMode.Open, FileAccess.Read);

            byte[] buffer = new byte[1024];
            int Packet = 1024;
            int TotalFileNum = (int)(ReadStream.Length + 1023) / 1024;

            if (TotalFileNum > 0)
            {
                TcpClient NewClient = new TcpClient();
                try
                {
                    int Port = int.Parse(fname.Substring(6)) + 10000;
                    NewClient.Connect(ChatList.Friends[_index].IP, Port);
                }
                catch
                {
                    MessageBox.Show("发起P2P连接失败,对方端口可能占用或者IP错误", "传输提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    return;
                }
                if (NewClient.Connected)
                {
                    NetworkStream TCPstream = NewClient.GetStream();
                    byte[] ACK = Encoding.Default.GetBytes(Info.UserName);
                    string response;
                    try
                    {
                        TCPstream.Write(ACK, 0, ACK.Length);
                        byte[] ReturnMessage = new byte[20];
                        int length = TCPstream.Read(ReturnMessage, 0, ReturnMessage.Length);
                        response = Encoding.Default.GetString(ReturnMessage, 0, length);
                    }
                    catch
                    {
                        MessageBox.Show("发起P2P连接失败", "连接提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        TCPstream.Close();
                        NewClient.Close();
                        return;
                    }
                    if (response == "ACK")//对方已经收到发出去的消息并加自己为好友
                    {
                        string temp = "[FileName]" + cancatenate + "[Length]" + ReadStream.Length.ToString();
                        byte[] msg = Encoding.Default.GetBytes(temp);
                        TCPstream.Write(msg, 0, msg.Length);
                        TCPstream.WriteTimeout = 20000;
                        int fileLength = 0;
                        try
                        {
                            while (fileLength < ReadStream.Length)
                            {
                                this.Invoke(new EventHandler(delegate
                                {
                                    double percent = Convert.ToInt32(100.0 * fileLength / ReadStream.Length);
                                    fileL.Text = "文件传输中..." + percent + "%";
                                }));
                                Packet = ReadStream.Read(buffer, 0, buffer.Length);
                                TCPstream.Write(buffer, 0, Packet);
                                fileLength += Packet;
                            }
                            this.Invoke(new EventHandler(delegate
                            {
                                fileL.Text = "文件传输完成";
                            }));
                            TCPstream.Flush();
                            ReadStream.Flush();
                            ReadStream.Close();
                        }
                        catch
                        {
                            MessageBox.Show("未能成功传输", "传输提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                            return;
                        }
                        temp = "[文件][" + cancatenate + "]已经传输完成并存入目录";
                        if (SendText(ChatList.Friends[_index], temp))
                        {
                            ChatList.Friends[_index].dias.Add(str_start0(temp));
                            Message NewSend = new Message(temp, 1, ChatList.Friends[_index].headP, Name);
                            ChatPanel.Controls.Add(NewSend);
                            ChatPanel.ScrollControlIntoView(NewSend);
                        }
                        else
                        {
                            MessageBox.Show("提示消息发送失败", "消息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    TCPstream.Close();
                    NewClient.Close();
                }
            }
            else
            {
                MessageBox.Show("文件大小不合规", "传输提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void Gsendfile(string file)
        {
            string cancatenate = file.Substring(file.LastIndexOf('\\') + 1);
            for (int gindex = 0; gindex < ChatList.Chats[_gindex].members.Count; gindex++)
            {
                int tempindex = ChatList.Chats[_gindex].members[gindex];
                FileStream ReadStream = new FileStream(file, FileMode.Open, FileAccess.Read);
                byte[] buffer = new byte[1024];
                int Packet = 1024;
                int TotalFileNum = (int)(ReadStream.Length + 1023) / 1024;
                if (TotalFileNum > 0)
                {
                    TcpClient NewClient = new TcpClient();
                    try
                    {
                        int Port = int.Parse(ChatList.Friends[tempindex].Name.Substring(6)) + 10000;
                        NewClient.Connect(ChatList.Friends[tempindex].IP, Port);
                    }
                    catch
                    {
                        fileL.Text = "部分好友已下线";
                        return;
                    }
                    if (NewClient.Connected)
                    {
                        NetworkStream TCPstream = NewClient.GetStream();
                        byte[] ACK = Encoding.Default.GetBytes(Info.UserName);
                        string response;
                        try
                        {
                            TCPstream.Write(ACK, 0, ACK.Length);//发送自己的名字，收到ACK时进行对话
                            byte[] ReturnMessage = new byte[20];
                            int length = TCPstream.Read(ReturnMessage, 0, ReturnMessage.Length);
                            response = Encoding.Default.GetString(ReturnMessage, 0, length);
                        }
                        catch
                        {
                            fileL.Text = "部分确认失败";
                            TCPstream.Close();
                            NewClient.Close();
                            continue;
                        }
                        if (response == "ACK")//对方已经收到发出去的消息并加自己为好友
                        {
                            string temp = "[FileName]" + cancatenate + "[Length]" + ReadStream.Length.ToString();
                            byte[] msg = Encoding.Default.GetBytes(temp);
                            TCPstream.Write(msg, 0, msg.Length);
                            TCPstream.WriteTimeout = 20000;
                            int fileLength = 0;
                            try
                            {
                                while (fileLength < ReadStream.Length)
                                {
                                    this.Invoke(new EventHandler(delegate
                                    {
                                        double percent = Convert.ToInt32(100.0 * fileLength / ReadStream.Length);
                                        fileL.Text = "文件传输中";
                                    }));
                                    Packet = ReadStream.Read(buffer, 0, buffer.Length);
                                    TCPstream.Write(buffer, 0, Packet);
                                    fileLength += Packet;
                                }

                                ReadStream.Flush();
                                TCPstream.Flush();
                                ReadStream.Close();
                            }
                            catch
                            {
                                fileL.Text = "部分帧失败";
                                return;
                            }
                        }
                        TCPstream.Close();
                        NewClient.Close();
                    }
                }
                else
                {
                    MessageBox.Show("文件大小不合规", "传输提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            inputT.Text = "[文件][" + cancatenate + "]已经传输完成并存入目录";
            send_handler();

        }


        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FileButton_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MC.RefreshallShow();
            MC.ShowDialog();
        }
        /////////////////////////////UDP sort
         private void UDPListen()
        {
            int LisPort = int.Parse(Info.UserName.Substring(6)) + 10000;//为每个用户使用单独侦听端口学号后4位加上10000
            IPEndPoint remoteIpep = new IPEndPoint(IPAddress.Any, 0);
            UdpClient udpcRecv = new UdpClient(LisPort);

            while (true)
            {
                byte[] bytRecv = udpcRecv.Receive(ref remoteIpep);
                string fname = Encoding.Unicode.GetString(bytRecv, 0, bytRecv.Length);
                int start = Environment.TickCount;
                while (Math.Abs(Environment.TickCount - start) < 10)//毫秒
                {

                }
                bytRecv = udpcRecv.Receive(ref remoteIpep);
                string recvmess = Encoding.Unicode.GetString(bytRecv, 0, bytRecv.Length);
                this.Invoke(new EventHandler(delegate
                {
                    int index = -1;
                    for (int i = 0; i < ChatList.Friends.Count; i++)
                    {
                        if (ChatList.Friends[i].Name == fname)
                            index = i;
                    }
                    if (index == -1)
                    {
                        Friend f = new Friend(fname);
                        string address = remoteIpep.Address.ToString();
                        string[] split = address.Split(new char[] { ':' }, 2);
                        f.IP = split[0];
                        f.Online = true;
                        f.newmess = true;
                        f.tag.setstatus("[您有新的未读消息]");
                        f.dias.Add(recvmess);
                        f.setabove += new SetAbove(MC.Chatlist_close);
                        f.setabove5 += new SetAbove5(MC.addmember);
                        ChatList.Friends.Add(f);
                    }
                    else
                    {
                        if (index == _index && Isgroup == false)
                        {
                            ChatList.Friends[index].dias.Add(recvmess);
                            ChatList.Friends[index].tag.setstatus("");
                            Message NewSend = new Message(recvmess, 0, ChatList.Friends[index].headP, fname);
                            ChatPanel.Controls.Add(NewSend);
                            ChatPanel.ScrollControlIntoView(NewSend);
                        }
                        else
                        {
                            ChatList.Friends[index].dias.Add(recvmess);
                            ChatList.Friends[index].newmess = true;
                            ChatList.Friends[index].tag.setstatus("[您有新的未读消息]");
                        }
                    }
                }));
            }

        }

        static void UDPSendMessage(object o, string IP, int port)
        {
            UdpClient udpcSend;
            udpcSend = new UdpClient();
            string message = (string)o;
            byte[] sendbytes = Encoding.Unicode.GetBytes(message);
            IPEndPoint remoteIpep = new IPEndPoint(IPAddress.Parse(IP), port); // 发送到的IP地址和端口号
            udpcSend.Send(sendbytes, sendbytes.Length, remoteIpep);
            udpcSend.Close();
        }
        private bool UDPSendText(Friend f, string Message)//发起P2P连接发送信息
        {
            byte[] ACK = Encoding.Default.GetBytes(Info.UserName);
            byte[] SendMessage = Encoding.Default.GetBytes(Message);
            TcpClient NewClient = new TcpClient();
            int Port = int.Parse(f.Name.Substring(6)) + 10000;
            try
            {
                UDPSendMessage(Info.UserName, f.IP, Port);
                UDPSendMessage(Message, f.IP, Port);
            }
            catch
            {
                if (Isgroup == false)
                    MessageBox.Show("好友不在线上", "消息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                else
                    fileL.Text = "存在好友已下线";
                return false;
            }
            return true;
        }

    }
}
