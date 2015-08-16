﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordConvTool.Forms
{
    public partial class Kojin : Form
    {
        public Kojin()
        {
            InitializeComponent();
        }

        private void regist_Click(object sender, EventArgs e)
        {
            WordConverter.Settings1.Default.Pascal = this.pascalCaseCheckBox.Checked;
            WordConverter.Settings1.Default.Camel = this.camelCaseCheckBox.Checked;
            WordConverter.Settings1.Default.Snake = this.snakeCaseCheckBox.Checked;
            WordConverter.Settings1.Default.DispNumber = this.getDisplayNumber(this);
            WordConverter.Settings1.Default.Save();
            MessageBox.Show("設定を登録しました。");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kojin"></param>
        /// <returns></returns>
        private int getDisplayNumber(Kojin kojin)
        {

            if (this.displayNumberRadioBtn1.Checked)
            {
                return 10;
            }
            if (this.displayNumberRadioBtn2.Checked)
            {
                return 20;
            }
            if (this.displayNumberRadioBtn3.Checked)
            {
                return 30;
            }

            return 0;
        }

        private void clear_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            this.textBox1.Text = "";
            string str = "";

            if ((e.KeyData & Keys.Modifiers) == Keys.Shift)
            {
                str = "Shift";
            }
            if ((e.KeyData & Keys.Modifiers) == Keys.Control)
            {
                str = "Control";
            }
            if ((e.KeyData & Keys.Modifiers) == Keys.Alt)
            {
                str = "Alt";
            }
            if ((e.KeyData & Keys.Modifiers) == (Keys.Shift | Keys.Control))
            {
                str = "Shift + Control";
            }
            if ((e.KeyData & Keys.Modifiers) == (Keys.Shift | Keys.Alt))
            {
                str = "Shift + Alt";
            }
            if ((e.KeyData & Keys.Modifiers) == (Keys.Control | Keys.Alt))
            {
                str = "Control + Alt";
            }
            if ((e.KeyData & Keys.Modifiers) == (Keys.Shift | Keys.Control | Keys.Alt))
            {
                str = "Shift + Control + Alt";
            }

            str += e.KeyCode;

            if (!String.IsNullOrEmpty(str))
            {
                this.textBox1.Text = str;
            }
        }

        private void Kojin_Load(object sender, EventArgs e)
        {
            this.pascalCaseCheckBox.Checked = WordConverter.Settings1.Default.Pascal;
            this.camelCaseCheckBox.Checked = WordConverter.Settings1.Default.Camel;
            this.snakeCaseCheckBox.Checked = WordConverter.Settings1.Default.Snake;
        }

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{
        //    string str = this.textBox1.Text; 

        //    //if ((ev.KeyData & Keys.Modifiers) == Keys.Shift)
        //    //{
        //    //    str = "Shift";
        //    //}
        //    //if ((e.KeyData & Keys.Modifiers) == Keys.Control)
        //    //{
        //    //    str = "Control";
        //    //}
        //    //if ((e.KeyData & Keys.Modifiers) == Keys.Alt)
        //    //{
        //    //    str = "Alt";
        //    //}
        //    //if ((e.KeyData & Keys.Modifiers) == (Keys.Shift | Keys.Control))
        //    //{
        //    //    str = "Shift + Control";
        //    //}
        //    //if ((e.KeyData & Keys.Modifiers) == (Keys.Shift | Keys.Alt))
        //    //{
        //    //    str = "Shift + Alt";
        //    //}
        //    //if ((e.KeyData & Keys.Modifiers) == (Keys.Control | Keys.Alt))
        //    //{
        //    //    str = "Control + Alt";
        //    //}
        //    //if ((e.KeyData & Keys.Modifiers) == (Keys.Shift | Keys.Control | Keys.Alt))
        //    //{
        //    //    str = "Shift + Control + Alt";
        //    //}

        //    //str += e.KeyCode;

        //    if (!String.IsNullOrEmpty(str))
        //    {
        //        this.textBox1.Text = str;
        //    }
        //}
    }
}
