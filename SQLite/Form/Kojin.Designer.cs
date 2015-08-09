namespace WordConvTool.Forms
{
    partial class Kojin
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.pascalCaseCheckBox = new System.Windows.Forms.CheckBox();
            this.camelCaseCheckBox = new System.Windows.Forms.CheckBox();
            this.snakeCaseCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.regist = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(29, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(262, 19);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(44, 88);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(35, 16);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "10";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(85, 88);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(35, 16);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "20";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(126, 88);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(35, 16);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "30";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // pascalCaseCheckBox
            // 
            this.pascalCaseCheckBox.AutoSize = true;
            this.pascalCaseCheckBox.Location = new System.Drawing.Point(45, 145);
            this.pascalCaseCheckBox.Name = "pascalCaseCheckBox";
            this.pascalCaseCheckBox.Size = new System.Drawing.Size(84, 16);
            this.pascalCaseCheckBox.TabIndex = 4;
            this.pascalCaseCheckBox.Text = "PascalCase";
            this.pascalCaseCheckBox.UseVisualStyleBackColor = true;
            // 
            // camelCaseCheckBox
            // 
            this.camelCaseCheckBox.AutoSize = true;
            this.camelCaseCheckBox.Location = new System.Drawing.Point(45, 167);
            this.camelCaseCheckBox.Name = "camelCaseCheckBox";
            this.camelCaseCheckBox.Size = new System.Drawing.Size(80, 16);
            this.camelCaseCheckBox.TabIndex = 5;
            this.camelCaseCheckBox.Text = "camelCase";
            this.camelCaseCheckBox.UseVisualStyleBackColor = true;
            // 
            // snakeCaseCheckBox
            // 
            this.snakeCaseCheckBox.AutoSize = true;
            this.snakeCaseCheckBox.Location = new System.Drawing.Point(45, 189);
            this.snakeCaseCheckBox.Name = "snakeCaseCheckBox";
            this.snakeCaseCheckBox.Size = new System.Drawing.Size(95, 16);
            this.snakeCaseCheckBox.TabIndex = 6;
            this.snakeCaseCheckBox.Text = "SNAKE_CASE";
            this.snakeCaseCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(28, 125);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(148, 92);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "変換形式";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(27, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(149, 39);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "表示件数";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "起動ホットキー";
            // 
            // regist
            // 
            this.regist.Location = new System.Drawing.Point(57, 262);
            this.regist.Name = "regist";
            this.regist.Size = new System.Drawing.Size(90, 23);
            this.regist.TabIndex = 10;
            this.regist.Text = "登録";
            this.regist.UseVisualStyleBackColor = true;
            this.regist.Click += new System.EventHandler(this.regist_Click);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(176, 262);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(90, 23);
            this.clear.TabIndex = 11;
            this.clear.Text = "クリア";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // Kojin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 321);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.regist);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.snakeCaseCheckBox);
            this.Controls.Add(this.camelCaseCheckBox);
            this.Controls.Add(this.pascalCaseCheckBox);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Kojin";
            this.Text = "個人設定";
            this.Load += new System.EventHandler(this.Kojin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.CheckBox pascalCaseCheckBox;
        private System.Windows.Forms.CheckBox camelCaseCheckBox;
        private System.Windows.Forms.CheckBox snakeCaseCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button regist;
        private System.Windows.Forms.Button clear;
    }
}