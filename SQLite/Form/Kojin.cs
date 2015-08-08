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

        }

        private void clear_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
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

            if (!String.IsNullOrEmpty(str))
            {
                this.textBox1.Text = str;
            }
        }
    }
}