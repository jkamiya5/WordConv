namespace WordConvertTool
{
    public partial class Shinsei
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
            this.yomi1TextBox = new System.Windows.Forms.TextBox();
            this.yomi2TextBox = new System.Windows.Forms.TextBox();
            this.tangoTextBox = new System.Windows.Forms.TextBox();
            this.shinseiButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.shinseiDataGridView1 = new System.Windows.Forms.DataGridView();
            this.shinkiRadioButton = new System.Windows.Forms.RadioButton();
            this.koushinRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.shounin = new System.Windows.Forms.Button();
            this.kyakka = new System.Windows.Forms.Button();
            this.tojiru = new System.Windows.Forms.Button();
            this.viewChangeRadioGroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.shinseiDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // yomi1TextBox
            // 
            this.yomi1TextBox.Location = new System.Drawing.Point(55, 19);
            this.yomi1TextBox.Name = "yomi1TextBox";
            this.yomi1TextBox.Size = new System.Drawing.Size(219, 19);
            this.yomi1TextBox.TabIndex = 0;
            // 
            // yomi2TextBox
            // 
            this.yomi2TextBox.Location = new System.Drawing.Point(55, 43);
            this.yomi2TextBox.Name = "yomi2TextBox";
            this.yomi2TextBox.Size = new System.Drawing.Size(219, 19);
            this.yomi2TextBox.TabIndex = 1;
            // 
            // tangoTextBox
            // 
            this.tangoTextBox.Location = new System.Drawing.Point(55, 69);
            this.tangoTextBox.Name = "tangoTextBox";
            this.tangoTextBox.Size = new System.Drawing.Size(219, 19);
            this.tangoTextBox.TabIndex = 2;
            // 
            // shinseiButton
            // 
            this.shinseiButton.Location = new System.Drawing.Point(65, 99);
            this.shinseiButton.Name = "shinseiButton";
            this.shinseiButton.Size = new System.Drawing.Size(75, 23);
            this.shinseiButton.TabIndex = 3;
            this.shinseiButton.Text = "申請";
            this.shinseiButton.UseVisualStyleBackColor = true;
            this.shinseiButton.Click += new System.EventHandler(this.shinseiButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(160, 99);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // shinseiDataGridView1
            // 
            this.shinseiDataGridView1.AllowUserToResizeColumns = false;
            this.shinseiDataGridView1.AllowUserToResizeRows = false;
            this.shinseiDataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.shinseiDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.shinseiDataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.shinseiDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shinseiDataGridView1.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.shinseiDataGridView1.Location = new System.Drawing.Point(14, 166);
            this.shinseiDataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.shinseiDataGridView1.Name = "shinseiDataGridView1";
            this.shinseiDataGridView1.RowHeadersVisible = false;
            this.shinseiDataGridView1.RowTemplate.Height = 21;
            this.shinseiDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.shinseiDataGridView1.Size = new System.Drawing.Size(284, 150);
            this.shinseiDataGridView1.TabIndex = 5;
            this.shinseiDataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.shinseiDataGridView1_ColumnHeaderMouseClick);
            // 
            // shinkiRadioButton
            // 
            this.shinkiRadioButton.AutoSize = true;
            this.shinkiRadioButton.Checked = true;
            this.shinkiRadioButton.Location = new System.Drawing.Point(25, 137);
            this.shinkiRadioButton.Name = "shinkiRadioButton";
            this.shinkiRadioButton.Size = new System.Drawing.Size(47, 16);
            this.shinkiRadioButton.TabIndex = 6;
            this.shinkiRadioButton.TabStop = true;
            this.shinkiRadioButton.Text = "新規";
            this.shinkiRadioButton.UseVisualStyleBackColor = true;
            // 
            // koushinRadioButton
            // 
            this.koushinRadioButton.AutoSize = true;
            this.koushinRadioButton.Location = new System.Drawing.Point(73, 137);
            this.koushinRadioButton.Name = "koushinRadioButton";
            this.koushinRadioButton.Size = new System.Drawing.Size(47, 16);
            this.koushinRadioButton.TabIndex = 7;
            this.koushinRadioButton.Text = "更新";
            this.koushinRadioButton.UseVisualStyleBackColor = true;
            this.koushinRadioButton.CheckedChanged += new System.EventHandler(this.viewRadioButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "論理名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "よみがな";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "物理名";
            // 
            // shounin
            // 
            this.shounin.Location = new System.Drawing.Point(18, 326);
            this.shounin.Name = "shounin";
            this.shounin.Size = new System.Drawing.Size(83, 23);
            this.shounin.TabIndex = 11;
            this.shounin.Text = "承認";
            this.shounin.UseVisualStyleBackColor = true;
            this.shounin.Click += new System.EventHandler(this.shounin_Click);
            // 
            // kyakka
            // 
            this.kyakka.Location = new System.Drawing.Point(113, 326);
            this.kyakka.Name = "kyakka";
            this.kyakka.Size = new System.Drawing.Size(83, 23);
            this.kyakka.TabIndex = 12;
            this.kyakka.Text = "却下";
            this.kyakka.UseVisualStyleBackColor = true;
            this.kyakka.Click += new System.EventHandler(this.kyakka_Click);
            // 
            // tojiru
            // 
            this.tojiru.Location = new System.Drawing.Point(208, 326);
            this.tojiru.Name = "tojiru";
            this.tojiru.Size = new System.Drawing.Size(83, 23);
            this.tojiru.TabIndex = 13;
            this.tojiru.Text = "閉じる";
            this.tojiru.UseVisualStyleBackColor = true;
            this.tojiru.Click += new System.EventHandler(this.tojiru_Click);
            // 
            // viewChangeRadioGroupBox
            // 
            this.viewChangeRadioGroupBox.Location = new System.Drawing.Point(19, 127);
            this.viewChangeRadioGroupBox.Name = "viewChangeRadioGroupBox";
            this.viewChangeRadioGroupBox.Size = new System.Drawing.Size(111, 35);
            this.viewChangeRadioGroupBox.TabIndex = 14;
            this.viewChangeRadioGroupBox.TabStop = false;
            this.viewChangeRadioGroupBox.Visible = false;
            // 
            // Shinsei
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 382);
            this.Controls.Add(this.tojiru);
            this.Controls.Add(this.kyakka);
            this.Controls.Add(this.shounin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.koushinRadioButton);
            this.Controls.Add(this.shinkiRadioButton);
            this.Controls.Add(this.shinseiDataGridView1);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.shinseiButton);
            this.Controls.Add(this.tangoTextBox);
            this.Controls.Add(this.yomi2TextBox);
            this.Controls.Add(this.yomi1TextBox);
            this.Controls.Add(this.viewChangeRadioGroupBox);
            this.MaximizeBox = false;
            this.Name = "Shinsei";
            this.Text = "Shinsei";
            this.Load += new System.EventHandler(this.Shinsei_Load);
            ((System.ComponentModel.ISupportInitialize)(this.shinseiDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox yomi1TextBox;
        private System.Windows.Forms.TextBox yomi2TextBox;
        private System.Windows.Forms.TextBox tangoTextBox;
        private System.Windows.Forms.Button shinseiButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.DataGridView shinseiDataGridView1;
        private System.Windows.Forms.RadioButton shinkiRadioButton;
        private System.Windows.Forms.RadioButton koushinRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button shounin;
        private System.Windows.Forms.Button kyakka;
        private System.Windows.Forms.Button tojiru;
        private System.Windows.Forms.GroupBox viewChangeRadioGroupBox;
    }
}