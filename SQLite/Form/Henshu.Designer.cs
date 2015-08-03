namespace WordConvTool.Forms
{
    partial class Henshu
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.delete = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.registBtn = new System.Windows.Forms.Button();
            this.searchBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tanitsuDataGridView = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ikkatsuRegistBtn = new System.Windows.Forms.Button();
            this.ikkatsuDataGridView = new System.Windows.Forms.DataGridView();
            this.readFile = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tanitsuDataGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ikkatsuDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.ItemSize = new System.Drawing.Size(96, 25);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(387, 399);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.delete);
            this.tabPage1.Controls.Add(this.addBtn);
            this.tabPage1.Controls.Add(this.registBtn);
            this.tabPage1.Controls.Add(this.searchBtn);
            this.tabPage1.Controls.Add(this.clearBtn);
            this.tabPage1.Controls.Add(this.textBox3);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.tanitsuDataGridView);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(379, 366);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "単一登録";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 23;
            this.label3.Text = "物理名";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "ひらがな";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 21;
            this.label1.Text = "論理名";
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(187, 323);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(115, 25);
            this.delete.TabIndex = 20;
            this.delete.Text = "削除";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(219, 99);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(94, 23);
            this.addBtn.TabIndex = 17;
            this.addBtn.Text = "追加";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // registBtn
            // 
            this.registBtn.Location = new System.Drawing.Point(43, 323);
            this.registBtn.Name = "registBtn";
            this.registBtn.Size = new System.Drawing.Size(115, 25);
            this.registBtn.TabIndex = 19;
            this.registBtn.Text = "登録";
            this.registBtn.UseVisualStyleBackColor = true;
            this.registBtn.Click += new System.EventHandler(this.registBtn_Click);
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(57, 99);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(68, 23);
            this.searchBtn.TabIndex = 15;
            this.searchBtn.Text = "検索";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(131, 99);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(68, 23);
            this.clearBtn.TabIndex = 16;
            this.clearBtn.Text = "クリア";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(53, 68);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(267, 19);
            this.textBox3.TabIndex = 14;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(53, 42);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(267, 19);
            this.textBox2.TabIndex = 13;
            // 
            // tanitsuDataGridView
            // 
            this.tanitsuDataGridView.AllowUserToResizeColumns = false;
            this.tanitsuDataGridView.AllowUserToResizeRows = false;
            this.tanitsuDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tanitsuDataGridView.Location = new System.Drawing.Point(13, 138);
            this.tanitsuDataGridView.Name = "tanitsuDataGridView";
            this.tanitsuDataGridView.RowHeadersVisible = false;
            this.tanitsuDataGridView.RowTemplate.Height = 21;
            this.tanitsuDataGridView.Size = new System.Drawing.Size(346, 175);
            this.tanitsuDataGridView.TabIndex = 18;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(53, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(267, 19);
            this.textBox1.TabIndex = 12;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ikkatsuRegistBtn);
            this.tabPage2.Controls.Add(this.ikkatsuDataGridView);
            this.tabPage2.Controls.Add(this.readFile);
            this.tabPage2.Controls.Add(this.openFile);
            this.tabPage2.Controls.Add(this.textBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(379, 366);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "一括登録";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ikkatsuRegistBtn
            // 
            this.ikkatsuRegistBtn.Location = new System.Drawing.Point(182, 322);
            this.ikkatsuRegistBtn.Name = "ikkatsuRegistBtn";
            this.ikkatsuRegistBtn.Size = new System.Drawing.Size(123, 25);
            this.ikkatsuRegistBtn.TabIndex = 15;
            this.ikkatsuRegistBtn.Text = "登録";
            this.ikkatsuRegistBtn.UseVisualStyleBackColor = true;
            this.ikkatsuRegistBtn.Click += new System.EventHandler(this.ikkatsuRegistBtn_Click);
            // 
            // ikkatsuDataGridView
            // 
            this.ikkatsuDataGridView.AllowUserToResizeColumns = false;
            this.ikkatsuDataGridView.AllowUserToResizeRows = false;
            this.ikkatsuDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ikkatsuDataGridView.Location = new System.Drawing.Point(13, 94);
            this.ikkatsuDataGridView.Name = "ikkatsuDataGridView";
            this.ikkatsuDataGridView.RowHeadersVisible = false;
            this.ikkatsuDataGridView.RowTemplate.Height = 21;
            this.ikkatsuDataGridView.Size = new System.Drawing.Size(344, 212);
            this.ikkatsuDataGridView.TabIndex = 12;
            // 
            // readFile
            // 
            this.readFile.Location = new System.Drawing.Point(38, 54);
            this.readFile.Name = "readFile";
            this.readFile.Size = new System.Drawing.Size(103, 25);
            this.readFile.TabIndex = 11;
            this.readFile.Text = "読み込み";
            this.readFile.UseVisualStyleBackColor = true;
            this.readFile.Click += new System.EventHandler(this.readFile_Click);
            // 
            // openFile
            // 
            this.openFile.Location = new System.Drawing.Point(276, 23);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(63, 25);
            this.openFile.TabIndex = 10;
            this.openFile.Text = "開く";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(26, 24);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(235, 19);
            this.textBox4.TabIndex = 9;
            // 
            // Henshu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 400);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Henshu";
            this.Text = "Henshu";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tanitsuDataGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ikkatsuDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button registBtn;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridView tanitsuDataGridView;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ikkatsuRegistBtn;
        private System.Windows.Forms.DataGridView ikkatsuDataGridView;
        private System.Windows.Forms.Button readFile;
        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}