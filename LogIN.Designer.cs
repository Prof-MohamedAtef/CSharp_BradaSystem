namespace Brada3
{
    partial class LogIN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIN));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox_LogIN = new System.Windows.Forms.GroupBox();
            this.Btn_Login_Select_Admins = new System.Windows.Forms.Button();
            this.Txt_LogIn_Password = new System.Windows.Forms.TextBox();
            this.Txt_LogIn_UserName = new System.Windows.Forms.TextBox();
            this.LBL_LogIn_Password = new System.Windows.Forms.Label();
            this.LBL_LogIn_UserName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1.SuspendLayout();
            this.groupBox_LogIN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 727);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1370, 22);
            this.statusStrip1.TabIndex = 25;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // groupBox_LogIN
            // 
            this.groupBox_LogIN.Controls.Add(this.pictureBox1);
            this.groupBox_LogIN.Controls.Add(this.Btn_Login_Select_Admins);
            this.groupBox_LogIN.Controls.Add(this.Txt_LogIn_Password);
            this.groupBox_LogIN.Controls.Add(this.Txt_LogIn_UserName);
            this.groupBox_LogIN.Controls.Add(this.LBL_LogIn_Password);
            this.groupBox_LogIN.Controls.Add(this.LBL_LogIn_UserName);
            this.groupBox_LogIN.Location = new System.Drawing.Point(12, 45);
            this.groupBox_LogIN.Name = "groupBox_LogIN";
            this.groupBox_LogIN.Size = new System.Drawing.Size(1310, 528);
            this.groupBox_LogIN.TabIndex = 24;
            this.groupBox_LogIN.TabStop = false;
            // 
            // Btn_Login_Select_Admins
            // 
            this.Btn_Login_Select_Admins.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Login_Select_Admins.Location = new System.Drawing.Point(80, 381);
            this.Btn_Login_Select_Admins.Name = "Btn_Login_Select_Admins";
            this.Btn_Login_Select_Admins.Size = new System.Drawing.Size(1135, 95);
            this.Btn_Login_Select_Admins.TabIndex = 6;
            this.Btn_Login_Select_Admins.Text = "Log In";
            this.Btn_Login_Select_Admins.UseVisualStyleBackColor = true;
            this.Btn_Login_Select_Admins.Click += new System.EventHandler(this.Btn_Login_Select_Admins_Click);
            // 
            // Txt_LogIn_Password
            // 
            this.Txt_LogIn_Password.Location = new System.Drawing.Point(898, 237);
            this.Txt_LogIn_Password.Name = "Txt_LogIn_Password";
            this.Txt_LogIn_Password.Size = new System.Drawing.Size(317, 20);
            this.Txt_LogIn_Password.TabIndex = 5;
            // 
            // Txt_LogIn_UserName
            // 
            this.Txt_LogIn_UserName.Location = new System.Drawing.Point(898, 190);
            this.Txt_LogIn_UserName.Name = "Txt_LogIn_UserName";
            this.Txt_LogIn_UserName.Size = new System.Drawing.Size(317, 20);
            this.Txt_LogIn_UserName.TabIndex = 4;
            // 
            // LBL_LogIn_Password
            // 
            this.LBL_LogIn_Password.AutoSize = true;
            this.LBL_LogIn_Password.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_LogIn_Password.Location = new System.Drawing.Point(731, 232);
            this.LBL_LogIn_Password.Name = "LBL_LogIn_Password";
            this.LBL_LogIn_Password.Size = new System.Drawing.Size(115, 23);
            this.LBL_LogIn_Password.TabIndex = 3;
            this.LBL_LogIn_Password.Text = "Password :";
            // 
            // LBL_LogIn_UserName
            // 
            this.LBL_LogIn_UserName.AutoSize = true;
            this.LBL_LogIn_UserName.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_LogIn_UserName.Location = new System.Drawing.Point(731, 189);
            this.LBL_LogIn_UserName.Name = "LBL_LogIn_UserName";
            this.LBL_LogIn_UserName.Size = new System.Drawing.Size(127, 23);
            this.LBL_LogIn_UserName.TabIndex = 2;
            this.LBL_LogIn_UserName.Text = "User Name :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(80, 86);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(580, 252);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // LogIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox_LogIN);
            this.Name = "LogIN";
            this.Text = "LogIN";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox_LogIN.ResumeLayout(false);
            this.groupBox_LogIN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox_LogIN;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Btn_Login_Select_Admins;
        private System.Windows.Forms.TextBox Txt_LogIn_Password;
        private System.Windows.Forms.TextBox Txt_LogIn_UserName;
        private System.Windows.Forms.Label LBL_LogIn_Password;
        private System.Windows.Forms.Label LBL_LogIn_UserName;
    }
}