namespace QQchy
{
    partial class ChatList
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
            this.SearchT = new System.Windows.Forms.TextBox();
            this.SearchB = new System.Windows.Forms.Button();
            this.FriendLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.GroupPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.TextLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.MemberlistView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // SearchT
            // 
            this.SearchT.Location = new System.Drawing.Point(12, 23);
            this.SearchT.Name = "SearchT";
            this.SearchT.Size = new System.Drawing.Size(258, 25);
            this.SearchT.TabIndex = 3;
            this.SearchT.Text = "2017011519";
            this.SearchT.TextChanged += new System.EventHandler(this.SearchT_TextChanged);
            // 
            // SearchB
            // 
            this.SearchB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SearchB.BackColor = System.Drawing.Color.SeaShell;
            this.SearchB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SearchB.FlatAppearance.BorderColor = System.Drawing.Color.Salmon;
            this.SearchB.FlatAppearance.BorderSize = 0;
            this.SearchB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.AntiqueWhite;
            this.SearchB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OldLace;
            this.SearchB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchB.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SearchB.ForeColor = System.Drawing.Color.Salmon;
            this.SearchB.Location = new System.Drawing.Point(276, 21);
            this.SearchB.Name = "SearchB";
            this.SearchB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SearchB.Size = new System.Drawing.Size(26, 25);
            this.SearchB.TabIndex = 21;
            this.SearchB.UseVisualStyleBackColor = false;
            this.SearchB.Click += new System.EventHandler(this.SearchB_Click);
            // 
            // FriendLayoutPanel
            // 
            this.FriendLayoutPanel.BackColor = System.Drawing.Color.FloralWhite;
            this.FriendLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FriendLayoutPanel.Location = new System.Drawing.Point(12, 71);
            this.FriendLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.FriendLayoutPanel.Name = "FriendLayoutPanel";
            this.FriendLayoutPanel.Size = new System.Drawing.Size(290, 525);
            this.FriendLayoutPanel.TabIndex = 23;
            this.FriendLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.FriendLayoutPanel_Paint);
            this.FriendLayoutPanel.DoubleClick += new System.EventHandler(this.FriendLayoutPanel_DoubleClick);
            this.FriendLayoutPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FriendLayoutPanel_MouseDoubleClick);
            // 
            // GroupPanel
            // 
            this.GroupPanel.BackColor = System.Drawing.Color.FloralWhite;
            this.GroupPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GroupPanel.Location = new System.Drawing.Point(352, 71);
            this.GroupPanel.Margin = new System.Windows.Forms.Padding(0);
            this.GroupPanel.Name = "GroupPanel";
            this.GroupPanel.Size = new System.Drawing.Size(290, 525);
            this.GroupPanel.TabIndex = 24;
            // 
            // TextLabel
            // 
            this.TextLabel.AutoSize = true;
            this.TextLabel.BackColor = System.Drawing.Color.Transparent;
            this.TextLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TextLabel.Location = new System.Drawing.Point(454, 40);
            this.TextLabel.Name = "TextLabel";
            this.TextLabel.Size = new System.Drawing.Size(69, 20);
            this.TextLabel.TabIndex = 26;
            this.TextLabel.Text = "群聊列表";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(727, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "群聊人选候选区";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(731, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 29);
            this.button1.TabIndex = 28;
            this.button1.Text = "发起群聊";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(388, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 20);
            this.label2.TabIndex = 29;
            this.label2.Text = "*右键加入候选区，左键发起私聊";
            // 
            // MemberlistView
            // 
            this.MemberlistView.AllowDrop = true;
            this.MemberlistView.HideSelection = false;
            this.MemberlistView.LabelWrap = false;
            this.MemberlistView.Location = new System.Drawing.Point(703, 71);
            this.MemberlistView.MultiSelect = false;
            this.MemberlistView.Name = "MemberlistView";
            this.MemberlistView.Size = new System.Drawing.Size(158, 525);
            this.MemberlistView.TabIndex = 30;
            this.MemberlistView.UseCompatibleStateImageBehavior = false;
            this.MemberlistView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MemberlistView_MouseClick);
            // 
            // ChatList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 614);
            this.Controls.Add(this.MemberlistView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextLabel);
            this.Controls.Add(this.GroupPanel);
            this.Controls.Add(this.FriendLayoutPanel);
            this.Controls.Add(this.SearchB);
            this.Controls.Add(this.SearchT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ChatList";
            this.Text = "ChatList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SearchT;
        private System.Windows.Forms.Button SearchB;
        private System.Windows.Forms.FlowLayoutPanel FriendLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel GroupPanel;
        private System.Windows.Forms.Label TextLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView MemberlistView;
    }
}