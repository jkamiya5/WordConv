﻿using System.Windows.Forms;
namespace WordConvertTool
{
    partial class Ichiran
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ichiranDataGridView = new System.Windows.Forms.DataGridView();
            this.wordList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.申請ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.単一登録ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.一括登録ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.プロパティ作成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formHeanderLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ichiranDataGridView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ichiranDataGridView
            // 
            this.ichiranDataGridView.AllowUserToResizeColumns = false;
            this.ichiranDataGridView.AllowUserToResizeRows = false;
            this.ichiranDataGridView.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.ichiranDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ichiranDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ichiranDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.wordList});
            this.ichiranDataGridView.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ichiranDataGridView.Location = new System.Drawing.Point(0, 9);
            this.ichiranDataGridView.Margin = new System.Windows.Forms.Padding(0);
            this.ichiranDataGridView.Name = "ichiranDataGridView";
            this.ichiranDataGridView.RowHeadersVisible = false;
            this.ichiranDataGridView.RowTemplate.Height = 21;
            this.ichiranDataGridView.Size = new System.Drawing.Size(330, 490);
            this.ichiranDataGridView.TabIndex = 0;
            this.ichiranDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.ichiranDataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            this.ichiranDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // wordList
            // 
            this.wordList.HeaderText = "wordList";
            this.wordList.MinimumWidth = 330;
            this.wordList.Name = "wordList";
            this.wordList.ReadOnly = true;
            this.wordList.Visible = false;
            this.wordList.Width = 330;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(1, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 495);
            this.label1.TabIndex = 1;
            // 
            // 申請ToolStripMenuItem
            // 
            this.申請ToolStripMenuItem.Name = "申請ToolStripMenuItem";
            this.申請ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.申請ToolStripMenuItem.Text = "申請";
            this.申請ToolStripMenuItem.Click += new System.EventHandler(this.申請ToolStripMenuItem_Click);
            // 
            // 単一登録ToolStripMenuItem
            // 
            this.単一登録ToolStripMenuItem.Name = "単一登録ToolStripMenuItem";
            this.単一登録ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.単一登録ToolStripMenuItem.Text = "単一登録";
            this.単一登録ToolStripMenuItem.Click += new System.EventHandler(this.単一登録ToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.申請ToolStripMenuItem,
            this.単一登録ToolStripMenuItem,
            this.一括登録ToolStripMenuItem,
            this.プロパティ作成ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 92);
            // 
            // 一括登録ToolStripMenuItem
            // 
            this.一括登録ToolStripMenuItem.Name = "一括登録ToolStripMenuItem";
            this.一括登録ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.一括登録ToolStripMenuItem.Text = "一括登録";
            this.一括登録ToolStripMenuItem.Click += new System.EventHandler(this.一括登録ToolStripMenuItem_Click);
            // 
            // プロパティ作成ToolStripMenuItem
            // 
            this.プロパティ作成ToolStripMenuItem.Name = "プロパティ作成ToolStripMenuItem";
            this.プロパティ作成ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.プロパティ作成ToolStripMenuItem.Text = "プロパティ作成";
            this.プロパティ作成ToolStripMenuItem.Click += new System.EventHandler(this.bo作成ToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.formHeanderLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.formHeanderLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.formHeanderLabel.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.formHeanderLabel.Location = new System.Drawing.Point(0, 0);
            this.formHeanderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.formHeanderLabel.Name = "label2";
            this.formHeanderLabel.Size = new System.Drawing.Size(330, 27);
            this.formHeanderLabel.TabIndex = 3;
            this.formHeanderLabel.Text = "WordConverter";
            this.formHeanderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.formHeanderLabel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.formHeanderLabel_MouseDoubleClick);
            this.formHeanderLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Ichiran_MouseDown);
            this.formHeanderLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Ichiran_MouseMove);
            // 
            // Ichiran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(330, 500);
            this.Controls.Add(this.formHeanderLabel);
            this.Controls.Add(this.ichiranDataGridView);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Ichiran";
            this.Text = "Ichiran";
            this.Load += new System.EventHandler(this.Ichiran_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ichiranDataGridView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView ichiranDataGridView;
        private DataGridViewTextBoxColumn wordList;
        private ToolStripMenuItem 申請ToolStripMenuItem;
        private ToolStripMenuItem 単一登録ToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip1;
        private Label label1;
        private Label formHeanderLabel;
        private ToolStripMenuItem 一括登録ToolStripMenuItem;
        private ToolStripMenuItem プロパティ作成ToolStripMenuItem;
    }
}

