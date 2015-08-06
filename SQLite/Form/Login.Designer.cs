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
            this.SuspendLayout();
            // 
            // dataSourcePath
            // 
            this.dataSourcePath.Location = new System.Drawing.Point(53, 50);
            this.dataSourcePath.Name = "dataSourcePath";
            this.dataSourcePath.Size = new System.Drawing.Size(223, 19);
            this.dataSourcePath.TabIndex = 0;
            // 
            // UserId
            // 
            this.UserId.Location = new System.Drawing.Point(53, 17);
            this.UserId.Name = "UserId";
            this.UserId.Size = new System.Drawing.Size(223, 19);
            this.UserId.TabIndex = 1;
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(107, 92);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(130, 23);
            this.loginBtn.TabIndex = 2;
            this.loginBtn.Text = "ログイン";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // openFile
            // 
            this.openFile.Location = new System.Drawing.Point(286, 48);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(67, 25);
            this.openFile.TabIndex = 11;
            this.openFile.Text = "参照";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 135);
            this.Controls.Add(this.openFile);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.UserId);
            this.Controls.Add(this.dataSourcePath);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox dataSourcePath;
        private System.Windows.Forms.TextBox UserId;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Button openFile;
    }
}