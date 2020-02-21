using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QQchy
{
    public delegate void SetAbove2(string name);//显示当前聊天对话框委托
    public delegate void SetAbove4(string name);//显示当前聊天对话框委托
    public partial class FriendInfo : UserControl
    {
        public event SetAbove2 setabove; //右键
        public event SetAbove4 setabove4;//左键

        public FriendInfo(string fname, string status = "[添加好友成功]")
        {
            InitializeComponent();
            Name = fname;
            SetName(fname);
        }
        
        public FriendInfo()
        {
            InitializeComponent();
        }
        public void group()
        {
            label1.Visible = true;
        }
        public void SetName(string NameString)
        {
            this.NameLabel.Text = NameString;
        }
        public void SetPortrait(Bitmap a)
        {
            Portrait.Image = a;
        }
        public string GetName()
        {
            return NameLabel.Text;
        }

        public void setstatus(string status)
        {
            TextLabel.Text = status;
        }
        public void updateonline(bool Online)
        {
            if(Online)
                NameLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            else
                NameLabel.ForeColor = System.Drawing.SystemColors.ControlDark;

        }

        //返回头像
        public Bitmap GetPortrait()
        {
            return new Bitmap(Portrait.Image);
        }

        private void FriendInfo_Load(object sender, EventArgs e)
        {
            //setabove(this.NameLabel.Text);//发送委托
        }

        private void NameLabel_Click(object sender, EventArgs e)
        {
            //setabove(this.NameLabel.Text);//发送委托
            //setabove4(this.NameLabel.Text);
        }

        private void TextLabel_Click(object sender, EventArgs e)
        {
            //setabove(this.NameLabel.Text);//发送委托
            //setabove4(this.NameLabel.Text);
        }

        private void FriendInfo_Click(object sender, EventArgs e)
        {
            //setabove(this.NameLabel.Text);//发送委托
            //setabove4(this.NameLabel.Text);
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            //setabove4(this.NameLabel.Text);
        }

        private void FriendInfo_DoubleClick(object sender, EventArgs e)
        {
            //setabove(this.NameLabel.Text);//发送委托
        }

        private void NameLabel_DoubleClick(object sender, EventArgs e)
        {
            //setabove(this.NameLabel.Text);//发送委托
        }

        private void TextLabel_DoubleClick(object sender, EventArgs e)
        {
            //setabove(this.NameLabel.Text);//发送委托
        }

        private void Portrait_DoubleClick(object sender, EventArgs e)
        {
            //setabove(this.NameLabel.Text);//发送委托
        }

        private void Label1_DoubleClick(object sender, EventArgs e)
        {
            //setabove(this.NameLabel.Text);//发送委托
        }

        private void Portrait_Click(object sender, EventArgs e)
        {

        }

        private void FriendInfo_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //左键
                setabove(this.NameLabel.Text);//发送委托
            else if(e.Button == MouseButtons.Right)
                setabove4(this.NameLabel.Text);
        }

        private void TextLabel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //左键
                setabove(this.NameLabel.Text);//发送委托
            else if (e.Button == MouseButtons.Right)
                setabove4(this.NameLabel.Text);
        }

        private void NameLabel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //左键
                setabove(this.NameLabel.Text);//发送委托
            else if (e.Button == MouseButtons.Right)
                setabove4(this.NameLabel.Text);
        }

        private void Label1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //左键
                setabove(this.NameLabel.Text);//发送委托
            else if (e.Button == MouseButtons.Right)
                setabove4(this.NameLabel.Text);
        }

        private void Portrait_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //左键
                setabove(this.NameLabel.Text);//发送委托
            else if (e.Button == MouseButtons.Right)
                setabove4(this.NameLabel.Text);
        }
    }

}
