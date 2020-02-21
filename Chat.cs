using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace QQchy
{
    public delegate void SetAbove6(int index);//显示当前聊天对话框委托
    public class Chat
    {
        public int index = -1;
        public int name;
        public List<int> members = new List<int>();
        public int num = 0;
        public FriendInfo tag;
        public List<string> dias = new List<string>();
        public event SetAbove6 setabove6;
        public bool newmess = false;
        public Chat()
        {
        }
        public void setup(string name, int index2)//first name in 
        {
            index = index2;
            tag = new FriendInfo(name);
            tag.group();
            tag.setabove += new SetAbove2(Helpsetabove);
            tag.setabove4 += new SetAbove4(Helpsetabove);
            tag.SetPortrait(new Bitmap("./Resources/headP/default.jpg"));
        }
        public void Helpsetabove(string name)
        {
            setabove6(index);
        }

    }
}














