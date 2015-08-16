using System;
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
            WordConverter.Settings1.Default.HotKey = this.hotKey.Text;
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


        private void Kojin_Load(object sender, EventArgs e)
        {
            this.hotKey.Text = WordConverter.Settings1.Default.HotKey;
            this.pascalCaseCheckBox.Checked = WordConverter.Settings1.Default.Pascal;
            this.camelCaseCheckBox.Checked = WordConverter.Settings1.Default.Camel;
            this.snakeCaseCheckBox.Checked = WordConverter.Settings1.Default.Snake;
        }

        private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            this.hotKey.Text = "";
            string str = "";

            if ((e.KeyData & Keys.Modifiers) == Keys.Shift)
            {
                str = "Shift";
            }
            if ((e.KeyData & Keys.Modifiers) == Keys.Control)
            {
                str = "Ctrl";
            }
            if ((e.KeyData & Keys.Modifiers) == Keys.Alt)
            {
                str = "Alt";
            }
            if ((e.KeyData & Keys.Modifiers) == (Keys.Shift | Keys.Control))
            {
                str = "Shift + Ctrl";
            }
            if ((e.KeyData & Keys.Modifiers) == (Keys.Shift | Keys.Alt))
            {
                str = "Shift + Alt";
            }
            if ((e.KeyData & Keys.Modifiers) == (Keys.Control | Keys.Alt))
            {
                str = "Ctrl + Alt";
            }
            if ((e.KeyData & Keys.Modifiers) == (Keys.Shift | Keys.Control | Keys.Alt))
            {
                str = "Shift + Ctrl + Alt";
            }

            string s = e.KeyCode.ToString();
            s = s.Replace("ControlKey", "");
            s = s.Replace("ShiftKey", "");
            s = s.Replace("AltKey", "");

            if (System.Text.RegularExpressions.Regex.IsMatch(
                s.ToUpper(), @"[A-Z]{1}"))
            {
                if (String.IsNullOrEmpty(str))
                {
                    str += s.ToUpper();
                }
                else
                {
                    str += " + " + s.ToUpper();
                }
            }

            this.hotKey.Text = str;

        }
    }
}
