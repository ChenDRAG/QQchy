namespace QQchy
{
    partial class FriendInfo
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
            this.Portrait = new System.Windows.Forms.PictureBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.TextLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Portrait)).BeginInit();
            this.SuspendLayout();
            // 
            // Portrait
            // 
            this.Portrait.BackColor = System.Drawing.Color.White;
            this.Portrait.Location = new System.Drawing.Point(12, 13);
            this.Portrait.Name = "Portrait";
            this.Portrait.Size = new System.Drawing.Size(66, 63);
            this.Portrait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Portrait.TabIndex = 7;
            this.Portrait.TabStop = false;
            this.Portrait.Click += new System.EventHandler(this.Portrait_Click);
            this.Portrait.DoubleClick += new System.EventHandler(this.Portrait_DoubleClick);
            this.Portrait.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Portrait_MouseClick);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.BackColor = System.Drawing.Color.LightCyan;
            this.NameLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NameLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.NameLabel.Location = new System.Drawing.Point(98, 13);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(132, 27);
            this.NameLabel.TabIndex = 15;
            this.NameLabel.Text = "2017011518";
            this.NameLabel.Click += new System.EventHandler(this.NameLabel_Click);
            this.NameLabel.DoubleClick += new System.EventHandler(this.NameLabel_DoubleClick);
            this.NameLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NameLabel_MouseClick);
            // 
            // TextLabel
            // 
            this.TextLabel.AutoSize = true;
            this.TextLabel.BackColor = System.Drawing.Color.LightCyan;
            this.TextLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TextLabel.Location = new System.Drawing.Point(99, 56);
            this.TextLabel.Name = "TextLabel";
            this.TextLabel.Size = new System.Drawing.Size(109, 20);
            this.TextLabel.TabIndex = 16;
            this.TextLabel.Text = "[添加好友成功]";
            this.TextLabel.Click += new System.EventHandler(this.TextLabel_Click);
            this.TextLabel.DoubleClick += new System.EventHandler(this.TextLabel_DoubleClick);
            this.TextLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextLabel_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightCyan;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(232, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "等人";
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            this.label1.DoubleClick += new System.EventHandler(this.Label1_DoubleClick);
            this.label1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Label1_MouseClick);
            // 
            // FriendInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.Portrait);
            this.Name = "FriendInfo";
            this.Size = new System.Drawing.Size(274, 99);
            this.Load += new System.EventHandler(this.FriendInfo_Load);
            this.Click += new System.EventHandler(this.FriendInfo_Click);
            this.DoubleClick += new System.EventHandler(this.FriendInfo_DoubleClick);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FriendInfo_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.Portrait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Portrait;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label TextLabel;
        private System.Windows.Forms.Label label1;
    }
}
