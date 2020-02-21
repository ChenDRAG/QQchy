namespace QQchy
{
    partial class Login
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PassT = new System.Windows.Forms.TextBox();
            this.UserT = new System.Windows.Forms.TextBox();
            this.PassL = new System.Windows.Forms.Label();
            this.UserL = new System.Windows.Forms.Label();
            this.LoginB = new System.Windows.Forms.Button();
            this.ImgBox = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PassT);
            this.groupBox1.Controls.Add(this.UserT);
            this.groupBox1.Controls.Add(this.PassL);
            this.groupBox1.Controls.Add(this.UserL);
            this.groupBox1.Location = new System.Drawing.Point(39, 162);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(514, 119);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // PassT
            // 
            this.PassT.Location = new System.Drawing.Point(150, 71);
            this.PassT.Name = "PassT";
            this.PassT.Size = new System.Drawing.Size(342, 25);
            this.PassT.TabIndex = 3;
            this.PassT.Text = "net2019";
            this.PassT.UseSystemPasswordChar = true;
            // 
            // UserT
            // 
            this.UserT.Location = new System.Drawing.Point(150, 24);
            this.UserT.Name = "UserT";
            this.UserT.Size = new System.Drawing.Size(342, 25);
            this.UserT.TabIndex = 2;
            this.UserT.Text = "2017011518";
            this.UserT.TextChanged += new System.EventHandler(this.UserT_TextChanged);
            // 
            // PassL
            // 
            this.PassL.AutoSize = true;
            this.PassL.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PassL.Location = new System.Drawing.Point(6, 69);
            this.PassL.Name = "PassL";
            this.PassL.Size = new System.Drawing.Size(138, 27);
            this.PassL.TabIndex = 1;
            this.PassL.Text = "Password:";
            // 
            // UserL
            // 
            this.UserL.AutoSize = true;
            this.UserL.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserL.Location = new System.Drawing.Point(6, 21);
            this.UserL.Name = "UserL";
            this.UserL.Size = new System.Drawing.Size(138, 27);
            this.UserL.TabIndex = 0;
            this.UserL.Text = "Username:";
            // 
            // LoginB
            // 
            this.LoginB.Location = new System.Drawing.Point(189, 294);
            this.LoginB.Name = "LoginB";
            this.LoginB.Size = new System.Drawing.Size(208, 40);
            this.LoginB.TabIndex = 1;
            this.LoginB.Text = "Login";
            this.LoginB.UseVisualStyleBackColor = true;
            this.LoginB.Click += new System.EventHandler(this.LoginB_Click);
            // 
            // ImgBox
            // 
            this.ImgBox.Location = new System.Drawing.Point(228, 28);
            this.ImgBox.Name = "ImgBox";
            this.ImgBox.Size = new System.Drawing.Size(128, 128);
            this.ImgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImgBox.TabIndex = 8;
            this.ImgBox.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(430, 306);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(85, 19);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "UDPmode";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 346);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.ImgBox);
            this.Controls.Add(this.LoginB);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Login";
            this.RightToLeftLayout = true;
            this.Text = "Welcome to chyChat!";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox PassT;
        private System.Windows.Forms.TextBox UserT;
        private System.Windows.Forms.Label PassL;
        private System.Windows.Forms.Label UserL;
        private System.Windows.Forms.Button LoginB;
        private System.Windows.Forms.PictureBox ImgBox;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}