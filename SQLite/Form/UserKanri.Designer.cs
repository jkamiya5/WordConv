namespace WordConvTool.Forms
{
    partial class UserKanri
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
            this.userKanriDataGridView1 = new System.Windows.Forms.DataGridView();
            this.regist = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.userName = new System.Windows.Forms.TextBox();
            this.search = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.kengen = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.empId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.userKanriDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.userKanriDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userKanriDataGridView1.Location = new System.Drawing.Point(21, 151);
            this.userKanriDataGridView1.Name = "dataGridView1";
            this.userKanriDataGridView1.RowTemplate.Height = 21;
            this.userKanriDataGridView1.Size = new System.Drawing.Size(438, 226);
            this.userKanriDataGridView1.TabIndex = 6;
            this.userKanriDataGridView1.AllowUserToResizeColumns = false;
            this.userKanriDataGridView1.AllowUserToResizeRows = false;
            this.userKanriDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userKanriDataGridView1.RowHeadersVisible = false;
            this.userKanriDataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.userKanriDataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.userKanriDataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridView1_CurrentCellDirtyStateChanged);
            // 
            // regist
            // 
            this.regist.Location = new System.Drawing.Point(94, 396);
            this.regist.Name = "regist";
            this.regist.Size = new System.Drawing.Size(126, 23);
            this.regist.TabIndex = 7;
            this.regist.Text = "登録";
            this.regist.UseVisualStyleBackColor = true;
            this.regist.Click += new System.EventHandler(this.regist_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(249, 396);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(126, 23);
            this.delete.TabIndex = 8;
            this.delete.Text = "削除";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(84, 47);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(315, 19);
            this.userName.TabIndex = 2;
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(94, 114);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(126, 23);
            this.search.TabIndex = 4;
            this.search.Text = "検索";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(249, 114);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(126, 23);
            this.add.TabIndex = 5;
            this.add.Text = "追加";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // kengen
            // 
            this.kengen.FormattingEnabled = true;
            this.kengen.Items.AddRange(new object[] {
            "管理",
            "一般"});
            this.kengen.Location = new System.Drawing.Point(84, 79);
            this.kengen.Name = "kengen";
            this.kengen.Size = new System.Drawing.Size(315, 20);
            this.kengen.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "ユーザー名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "権限";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "ユーザーID";
            // 
            // userId
            // 
            this.empId.Location = new System.Drawing.Point(84, 18);
            this.empId.Name = "userId";
            this.empId.Size = new System.Drawing.Size(315, 19);
            this.empId.TabIndex = 1;
            // 
            // UserKanri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 430);
            this.Controls.Add(this.empId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kengen);
            this.Controls.Add(this.add);
            this.Controls.Add(this.search);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.regist);
            this.Controls.Add(this.userKanriDataGridView1);
            this.Name = "UserKanri";
            this.Text = "ユーザー管理";
            ((System.ComponentModel.ISupportInitialize)(this.userKanriDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView userKanriDataGridView1;
        private System.Windows.Forms.Button regist;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.ComboBox kengen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox empId;
    }
}