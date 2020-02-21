namespace QQchy
{
    partial class Message
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.FriendNameLabel = new System.Windows.Forms.Label();
            this.FriendPortrait = new System.Windows.Forms.PictureBox();
            this.MyPortrait = new System.Windows.Forms.PictureBox();
            this.MyNameLabel = new System.Windows.Forms.Label();
            this.ChatLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FriendPortrait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyPortrait)).BeginInit();
            this.SuspendLayout();
            // 
            // FriendNameLabel
            // 
            this.FriendNameLabel.AutoSize = true;
            this.FriendNameLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FriendNameLabel.Location = new System.Drawing.Point(3, 14);
            this.FriendNameLabel.Name = "FriendNameLabel";
            this.FriendNameLabel.Size = new System.Drawing.Size(99, 20);
            this.FriendNameLabel.TabIndex = 5;
            this.FriendNameLabel.Text = "2016011435";
            // 
            // FriendPortrait
            // 
            this.FriendPortrait.BackColor = System.Drawing.Color.White;
            this.FriendPortrait.Location = new System.Drawing.Point(3, 37);
            this.FriendPortrait.Name = "FriendPortrait";
            this.FriendPortrait.Size = new System.Drawing.Size(60, 60);
            this.FriendPortrait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FriendPortrait.TabIndex = 6;
            this.FriendPortrait.TabStop = false;
            this.FriendPortrait.Click += new System.EventHandler(this.FriendPortrait_Click);
            // 
            // MyPortrait
            // 
            this.MyPortrait.BackColor = System.Drawing.Color.White;
            this.MyPortrait.Location = new System.Drawing.Point(466, 37);
            this.MyPortrait.Name = "MyPortrait";
            this.MyPortrait.Size = new System.Drawing.Size(60, 60);
            this.MyPortrait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MyPortrait.TabIndex = 7;
            this.MyPortrait.TabStop = false;
            // 
            // MyNameLabel
            // 
            this.MyNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MyNameLabel.AutoSize = true;
            this.MyNameLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MyNameLabel.Location = new System.Drawing.Point(427, 14);
            this.MyNameLabel.Name = "MyNameLabel";
            this.MyNameLabel.Size = new System.Drawing.Size(99, 20);
            this.MyNameLabel.TabIndex = 8;
            this.MyNameLabel.Text = "2016011481";
            // 
            // ChatLabel
            // 
            this.ChatLabel.AutoSize = true;
            this.ChatLabel.BackColor = System.Drawing.Color.SeaShell;
            this.ChatLabel.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChatLabel.Location = new System.Drawing.Point(78, 50);
            this.ChatLabel.MaximumSize = new System.Drawing.Size(350, 0);
            this.ChatLabel.Name = "ChatLabel";
            this.ChatLabel.Size = new System.Drawing.Size(50, 25);
            this.ChatLabel.TabIndex = 9;
            this.ChatLabel.Text = "消息";
            // 
            // Message
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ChatLabel);
            this.Controls.Add(this.MyNameLabel);
            this.Controls.Add(this.MyPortrait);
            this.Controls.Add(this.FriendPortrait);
            this.Controls.Add(this.FriendNameLabel);
            this.Name = "Message";
            this.Size = new System.Drawing.Size(537, 109);
            this.Load += new System.EventHandler(this.Message_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FriendPortrait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyPortrait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FriendNameLabel;
        private System.Windows.Forms.PictureBox FriendPortrait;
        private System.Windows.Forms.PictureBox MyPortrait;
        private System.Windows.Forms.Label MyNameLabel;
        private System.Windows.Forms.Label ChatLabel;
    }
}
