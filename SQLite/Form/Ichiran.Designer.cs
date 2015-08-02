using System.Windows.Forms;
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.wordList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.申請ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.単一登録ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.一括登録ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.wordList});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.Location = new System.Drawing.Point(0, 8);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(300, 491);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            // 
            // wordList
            // 
            this.wordList.HeaderText = "wordList";
            this.wordList.MinimumWidth = 300;
            this.wordList.Name = "wordList";
            this.wordList.ReadOnly = true;
            this.wordList.Visible = false;
            this.wordList.Width = 450;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(1, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 495);
            this.label1.TabIndex = 1;
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
            this.単一登録ToolStripMenuItem.Name = "編集ToolStripMenuItem";
            this.単一登録ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.単一登録ToolStripMenuItem.Text = "単一登録";
            this.単一登録ToolStripMenuItem.Click += new System.EventHandler(this.単一登録ToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.申請ToolStripMenuItem,
            this.単一登録ToolStripMenuItem,
            this.一括登録ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 92);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(300, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "WordConverter";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.label2_MouseDoubleClick);
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Ichiran_MouseDown);
            this.label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Ichiran_MouseMove);
            // 
            // 一括登録ToolStripMenuItem
            // 
            this.一括登録ToolStripMenuItem.Name = "一括登録ToolStripMenuItem";
            this.一括登録ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.一括登録ToolStripMenuItem.Text = "一括登録";
            this.一括登録ToolStripMenuItem.Click += new System.EventHandler(this.一括登録ToolStripMenuItem_Click);
            // 
            // Ichiran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(300, 500);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Ichiran";
            this.Text = "Ichiran";
            this.Deactivate += new System.EventHandler(this.Ichiran_Deactivate);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn wordList;
        private ToolStripMenuItem 申請ToolStripMenuItem;
        private ToolStripMenuItem 単一登録ToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip1;
        private Label label1;
        private Label label2;
        private ToolStripMenuItem 一括登録ToolStripMenuItem;
    }
}

