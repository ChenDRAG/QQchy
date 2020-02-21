using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QQchy
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Login login = new Login();
            login.ShowDialog();
            if (login.DialogResult == DialogResult.OK)
            {
                login.Close();
                MainChat MC = new MainChat();
                MC.ShowDialog();

                if (Login.Logout() == true)
                    MessageBox.Show("成功下线", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }

            System.Environment.Exit(0); 
        }
    }
}
