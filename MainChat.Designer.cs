namespace QQchy
{
    partial class MainChat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.inputT = new System.Windows.Forms.RichTextBox();
            this.SendB = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.FileB = new System.Windows.Forms.Button();
            this.myImg = new System.Windows.Forms.PictureBox();
            this.myname = new System.Windows.Forms.Label();
            this.theirimgs = new System.Windows.Forms.PictureBox();
            this.theirnames = new System.Windows.Forms.Label();
            this.GroupButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ChatPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.fileL = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.theirimgs)).BeginInit();
            this.SuspendLayout();
            // 
            // inputT
            // 
            this.inputT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputT.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.inputT.ForeColor = System.Drawing.Color.Black;
            this.inputT.Location = new System.Drawing.Point(1, 327);
            this.inputT.Name = "inputT";
            this.inputT.Size = new System.Drawing.Size(594, 121);
            this.inputT.TabIndex = 4;
            this.inputT.Text = "";
            // 
            // SendB
            // 
            this.SendB.Location = new System.Drawing.Point(497, 408);
            this.SendB.Name = "SendB";
            this.SendB.Size = new System.Drawing.Size(98, 40);
            this.SendB.TabIndex = 5;
            this.SendB.Text = "Send";
            this.SendB.UseVisualStyleBackColor = true;
            this.SendB.Click += new System.EventHandler(this.Button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.Controls.Add(this.fileL);
            this.panel1.Controls.Add(this.InfoLabel);
            this.panel1.Controls.Add(this.FileB);
            this.panel1.Location = new System.Drawing.Point(1, 286);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 43);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // FileB
            // 
            this.FileB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FileB.BackColor = System.Drawing.Color.SeaShell;
            this.FileB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.FileB.FlatAppearance.BorderColor = System.Drawing.Color.Salmon;
            this.FileB.FlatAppearance.BorderSize = 0;
            this.FileB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.AntiqueWhite;
            this.FileB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OldLace;
            this.FileB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileB.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FileB.ForeColor = System.Drawing.Color.Salmon;
            this.FileB.Location = new System.Drawing.Point(10, 8);
            this.FileB.Name = "FileB";
            this.FileB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FileB.Size = new System.Drawing.Size(30, 30);
            this.FileB.TabIndex = 17;
            this.FileB.UseVisualStyleBackColor = false;
            this.FileB.Click += new System.EventHandler(this.FileB_Click);
            // 
            // myImg
            // 
            this.myImg.Location = new System.Drawing.Point(622, 214);
            this.myImg.Name = "myImg";
            this.myImg.Size = new System.Drawing.Size(140, 140);
            this.myImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.myImg.TabIndex = 7;
            this.myImg.TabStop = false;
            // 
            // myname
            // 
            this.myname.AutoSize = true;
            this.myname.BackColor = System.Drawing.Color.SeaShell;
            this.myname.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myname.ForeColor = System.Drawing.SystemColors.ControlText;
            this.myname.Location = new System.Drawing.Point(630, 357);
            this.myname.Name = "myname";
            this.myname.Size = new System.Drawing.Size(122, 25);
            this.myname.TabIndex = 16;
            this.myname.Text = "2017011518";
            this.myname.Click += new System.EventHandler(this.NameLabel_Click);
            // 
            // theirimgs
            // 
            this.theirimgs.Location = new System.Drawing.Point(622, 12);
            this.theirimgs.Name = "theirimgs";
            this.theirimgs.Size = new System.Drawing.Size(140, 140);
            this.theirimgs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.theirimgs.TabIndex = 17;
            this.theirimgs.TabStop = false;
            // 
            // theirnames
            // 
            this.theirnames.AutoSize = true;
            this.theirnames.BackColor = System.Drawing.Color.SeaShell;
            this.theirnames.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.theirnames.ForeColor = System.Drawing.SystemColors.ControlText;
            this.theirnames.Location = new System.Drawing.Point(630, 155);
            this.theirnames.Name = "theirnames";
            this.theirnames.Size = new System.Drawing.Size(122, 25);
            this.theirnames.TabIndex = 18;
            this.theirnames.Text = "2017011518";
            // 
            // GroupButton
            // 
            this.GroupButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GroupButton.BackColor = System.Drawing.Color.LightCyan;
            this.GroupButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.GroupButton.FlatAppearance.BorderColor = System.Drawing.Color.Salmon;
            this.GroupButton.FlatAppearance.BorderSize = 0;
            this.GroupButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.AntiqueWhite;
            this.GroupButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OldLace;
            this.GroupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GroupButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GroupButton.ForeColor = System.Drawing.Color.Teal;
            this.GroupButton.Location = new System.Drawing.Point(601, 408);
            this.GroupButton.Name = "GroupButton";
            this.GroupButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GroupButton.Size = new System.Drawing.Size(101, 30);
            this.GroupButton.TabIndex = 19;
            this.GroupButton.Text = "搜索用户";
            this.GroupButton.UseVisualStyleBackColor = false;
            this.GroupButton.Click += new System.EventHandler(this.GroupButton_Click);
            // 
            // button2
            // 
            this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button2.BackColor = System.Drawing.Color.LightCyan;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Salmon;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.AntiqueWhite;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OldLace;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.Color.Teal;
            this.button2.Location = new System.Drawing.Point(699, 408);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button2.Size = new System.Drawing.Size(96, 30);
            this.button2.TabIndex = 20;
            this.button2.Text = "切换聊天";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // ChatPanel
            // 
            this.ChatPanel.AutoScroll = true;
            this.ChatPanel.Location = new System.Drawing.Point(1, -1);
            this.ChatPanel.Name = "ChatPanel";
            this.ChatPanel.Size = new System.Drawing.Size(594, 289);
            this.ChatPanel.TabIndex = 21;
            this.ChatPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.FlowLayoutPanel1_Paint);
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.BackColor = System.Drawing.Color.SeaShell;
            this.InfoLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.InfoLabel.ForeColor = System.Drawing.Color.DimGray;
            this.InfoLabel.Location = new System.Drawing.Point(553, 13);
            this.InfoLabel.MaximumSize = new System.Drawing.Size(400, 0);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(0, 20);
            this.InfoLabel.TabIndex = 18;
            // 
            // fileL
            // 
            this.fileL.AutoSize = true;
            this.fileL.BackColor = System.Drawing.Color.Transparent;
            this.fileL.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fileL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fileL.Location = new System.Drawing.Point(237, 8);
            this.fileL.Name = "fileL";
            this.fileL.Size = new System.Drawing.Size(0, 25);
            this.fileL.TabIndex = 21;
            this.fileL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MainChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ChatPanel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.GroupButton);
            this.Controls.Add(this.theirnames);
            this.Controls.Add(this.theirimgs);
            this.Controls.Add(this.myname);
            this.Controls.Add(this.myImg);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SendB);
            this.Controls.Add(this.inputT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainChat";
            this.Text = "MainChat";
            this.Load += new System.EventHandler(this.MainChat_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.theirimgs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox inputT;
        private System.Windows.Forms.Button SendB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button FileB;
        private System.Windows.Forms.PictureBox myImg;
        private System.Windows.Forms.Label myname;
        private System.Windows.Forms.PictureBox theirimgs;
        private System.Windows.Forms.Label theirnames;
        private System.Windows.Forms.Button GroupButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FlowLayoutPanel ChatPanel;
        private System.Windows.Forms.Label fileL;
        private System.Windows.Forms.Label InfoLabel;
    }
}