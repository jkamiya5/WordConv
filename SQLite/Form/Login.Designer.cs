namespace WordConvertTool
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
            this.dataSourcePath = new System.Windows.Forms.TextBox();
            this.UserId = new System.Windows.Forms.TextBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dataSourcePath
            // 
            this.dataSourcePath.Location = new System.Drawing.Point(82, 51);
            this.dataSourcePath.Name = "dataSourcePath";
            this.dataSourcePath.Size = new System.Drawing.Size(223, 19);
            this.dataSourcePath.TabIndex = 0;
            // 
            // UserId
            // 
            this.UserId.Location = new System.Drawing.Point(82, 14);
            this.UserId.Name = "UserId";
            this.UserId.Size = new System.Drawing.Size(223, 19);
            this.UserId.TabIndex = 1;
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(106, 90);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(161, 25);
            this.loginBtn.TabIndex = 2;
            this.loginBtn.Text = "ログイン";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // openFile
            // 
            this.openFile.Location = new System.Drawing.Point(315, 49);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(67, 25);
            this.openFile.TabIndex = 11;
            this.openFile.Text = "参照";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "ユーザーID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "DBパス";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 130);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.openFile);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.UserId);
            this.Controls.Add(this.dataSourcePath);
            this.Name = "Login";
            this.Text = "ログイン";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox dataSourcePath;
        private System.Windows.Forms.TextBox UserId;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}