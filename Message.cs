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
    public partial class Message : UserControl
    {
        public Message(string ChatText, int ChatType, Bitmap Portrait, string ChatName = "2017011518")
        {
            InitializeComponent();
            ChatLabel.Text = ChatText;
            FriendNameLabel.Text = ChatName;
            MyNameLabel.Text = Info.UserName;
            this.Height = ChatLabel.Height + 60;
            if (ChatType == 0)
            {
                ChatLabel.Location = new Point(80, 40);
                ChatLabel.BringToFront();
            }
            else if (ChatType == 1)
            {
                ChatLabel.Location = new Point(this.Width - ChatLabel.Width - 70, 40);
                ChatLabel.BringToFront();
                ChatLabel.BackColor = Color.Aqua;
            }
            Bitmap ShowPortrait = new Bitmap(Portrait);
            if (ChatType == 0)
            {
                this.FriendPortrait.Image = ShowPortrait;
                MyPortrait.Visible = false;
                MyNameLabel.Visible = false;
            }
            else if (ChatType == 1)
            {
                this.MyPortrait.Image = new Bitmap(Info.headP);//TODO
                FriendPortrait.Visible = false;
                FriendNameLabel.Visible = false;
            }
        }

        private void Message_Load(object sender, EventArgs e)
        {

        }

        private void FriendPortrait_Click(object sender, EventArgs e)
        {

        }
    }
}
