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
            this.components = new System.ComponentModel.Container();
            this.ronrimei1TextBox = new System.Windows.Forms.TextBox();
            this.ronrimei2TextBox = new System.Windows.Forms.TextBox();
            this.butsurimeiTextBox = new System.Windows.Forms.TextBox();
            this.shinseiButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.shinseiDataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.shounin = new System.Windows.Forms.Button();
            this.kyakka = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.shinseiDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ronrimei1TextBox
            // 
            this.ronrimei1TextBox.Location = new System.Drawing.Point(55, 19);
            this.ronrimei1TextBox.Name = "ronrimei1TextBox";
            this.ronrimei1TextBox.Size = new System.Drawing.Size(298, 19);
            this.ronrimei1TextBox.TabIndex = 0;
            this.ronrimei1TextBox.Validated += new System.EventHandler(this.ronrimei1TextBox_Validated);
            // 
            // ronrimei2TextBox
            // 
            this.ronrimei2TextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.ronrimei2TextBox.Location = new System.Drawing.Point(55, 43);
            this.ronrimei2TextBox.Name = "ronrimei2TextBox";
            this.ronrimei2TextBox.Size = new System.Drawing.Size(298, 19);
            this.ronrimei2TextBox.TabIndex = 1;
            this.ronrimei2TextBox.Validating += new System.ComponentModel.CancelEventHandler(this.ronrimei2TextBox_Validating);
            this.ronrimei2TextBox.Validated += new System.EventHandler(this.ronrimei2TextBox_Validated);
            // 
            // butsurimeiTextBox
            // 
            this.butsurimeiTextBox.Location = new System.Drawing.Point(55, 69);
            this.butsurimeiTextBox.Name = "butsurimeiTextBox";
            this.butsurimeiTextBox.Size = new System.Drawing.Size(298, 19);
            this.butsurimeiTextBox.TabIndex = 2;
            this.butsurimeiTextBox.Validated += new System.EventHandler(this.butsurimeiTextBox_Validated);
            // 
            // shinseiButton
            // 
            this.shinseiButton.Location = new System.Drawing.Point(78, 101);
            this.shinseiButton.Name = "shinseiButton";
            this.shinseiButton.Size = new System.Drawing.Size(100, 25);
            this.shinseiButton.TabIndex = 3;
            this.shinseiButton.Text = "申請";
            this.shinseiButton.UseVisualStyleBackColor = true;
            this.shinseiButton.Click += new System.EventHandler(this.shinseiButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(208, 101);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(100, 25);
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
            this.shinseiDataGridView1.Location = new System.Drawing.Point(24, 140);
            this.shinseiDataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.shinseiDataGridView1.Name = "shinseiDataGridView1";
            this.shinseiDataGridView1.RowHeadersVisible = false;
            this.shinseiDataGridView1.RowTemplate.Height = 21;
            this.shinseiDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.shinseiDataGridView1.Size = new System.Drawing.Size(341, 170);
            this.shinseiDataGridView1.TabIndex = 5;
            this.shinseiDataGridView1.ReadOnly = false;
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
            this.shounin.Location = new System.Drawing.Point(79, 326);
            this.shounin.Name = "shounin";
            this.shounin.Size = new System.Drawing.Size(100, 25);
            this.shounin.TabIndex = 11;
            this.shounin.Text = "承認";
            this.shounin.UseVisualStyleBackColor = true;
            this.shounin.Click += new System.EventHandler(this.shounin_Click);
            // 
            // kyakka
            // 
            this.kyakka.Location = new System.Drawing.Point(209, 326);
            this.kyakka.Name = "kyakka";
            this.kyakka.Size = new System.Drawing.Size(100, 25);
            this.kyakka.TabIndex = 12;
            this.kyakka.Text = "却下";
            this.kyakka.UseVisualStyleBackColor = true;
            this.kyakka.Click += new System.EventHandler(this.kyakka_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Shinsei
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 378);
            this.Controls.Add(this.kyakka);
            this.Controls.Add(this.shounin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shinseiDataGridView1);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.shinseiButton);
            this.Controls.Add(this.butsurimeiTextBox);
            this.Controls.Add(this.ronrimei2TextBox);
            this.Controls.Add(this.ronrimei1TextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Shinsei";
            this.Text = "申請・承認";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Shinsei_FormClosing);
            this.Load += new System.EventHandler(this.Shinsei_Load);
            ((System.ComponentModel.ISupportInitialize)(this.shinseiDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ronrimei1TextBox;
        private System.Windows.Forms.TextBox ronrimei2TextBox;
        private System.Windows.Forms.TextBox butsurimeiTextBox;
        private System.Windows.Forms.Button shinseiButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.DataGridView shinseiDataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button shounin;
        private System.Windows.Forms.Button kyakka;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}