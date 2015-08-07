namespace WordConvertTool
{
    partial class BaseForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.申請ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.編集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.個人設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ユーザー管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.申請ToolStripMenuItem,
            this.編集ToolStripMenuItem,
            this.個人設定ToolStripMenuItem,
            this.ユーザー管理ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 136);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "終了";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // 申請ToolStripMenuItem
            // 
            this.申請ToolStripMenuItem.Name = "申請ToolStripMenuItem";
            this.申請ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.申請ToolStripMenuItem.Text = "申請";
            this.申請ToolStripMenuItem.Click += new System.EventHandler(this.申請ToolStripMenuItem_Click);
            // 
            // 編集ToolStripMenuItem
            // 
            this.編集ToolStripMenuItem.Name = "編集ToolStripMenuItem";
            this.編集ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.編集ToolStripMenuItem.Text = "編集";
            this.編集ToolStripMenuItem.Click += new System.EventHandler(this.編集ToolStripMenuItem_Click);
            // 
            // 個人設定ToolStripMenuItem
            // 
            this.個人設定ToolStripMenuItem.Name = "個人設定ToolStripMenuItem";
            this.個人設定ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.個人設定ToolStripMenuItem.Text = "個人設定";
            this.個人設定ToolStripMenuItem.Click += new System.EventHandler(this.個人設定ToolStripMenuItem_Click);
            // 
            // ユーザー管理ToolStripMenuItem
            // 
            this.ユーザー管理ToolStripMenuItem.Name = "ユーザー管理ToolStripMenuItem";
            this.ユーザー管理ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ユーザー管理ToolStripMenuItem.Text = "ユーザー管理";
            this.ユーザー管理ToolStripMenuItem.Click += new System.EventHandler(this.ユーザー管理ToolStripMenuItem_Click);
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 172);
            this.Name = "BaseForm";
            this.Text = "BaseForm1";
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 申請ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 編集ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 個人設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ユーザー管理ToolStripMenuItem;
    }
}