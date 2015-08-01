using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordConvTool.Model;

namespace WordConvertTool
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Shinsei : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private static WordConvTool.CommonFunction common = new WordConvTool.CommonFunction();
        public string kensakuWord { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public Shinsei(string text)
        {
            InitializeComponent();
            this.Show();
            this.Activate();
            this.yomi1TextBox.Text = text.Trim();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shinseiButton_Click(object sender, EventArgs e)
        {
            string message = "";
            message += "論理名　：" + this.yomi1TextBox.Text + System.Environment.NewLine;
            message += "よみがな：" + this.yomi2TextBox.Text + System.Environment.NewLine;
            message += "物理名　：" + this.tangoTextBox.Text + System.Environment.NewLine + System.Environment.NewLine;
            string[] data = { this.yomi1TextBox.Text, this.yomi2TextBox.Text, this.tangoTextBox.Text };
            DialogResult result = MessageBox.Show(message + "申請してもよろしいですか？", "申請確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.Insert(data);
            }
            this.Shinsei_Load(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        private void Insert(string[] data)
        {
            using (var context = new MyContext())
            {
                UserMst user = new UserMst();
                user.USER_NAME = "ジョウジ";
                WordShinsei shinsei = new WordShinsei();
                shinsei.RONRI_NAME1 = data[0];
                shinsei.RONRI_NAME2 = data[1];
                shinsei.BUTSURI_NAME = data[2];
                shinsei.STATUS = 1;
                shinsei.User = user;
                context.WordShinsei.Add(shinsei);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearButton_Click(object sender, EventArgs e)
        {
            this.yomi1TextBox.Clear();
            this.yomi2TextBox.Clear();
            this.tangoTextBox.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Shinsei_Load(object sender, EventArgs e)
        {
            DispManager dispMode;
            dispMode = new DispManager(new StrategyShinki(this.shinseiDataGridView1));
            dispMode.Execute();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shounin_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < shinseiDataGridView1.Rows.Count; i++)
            {
                if (shinseiDataGridView1.Rows[i].Cells[0].Value == null)
                {
                    continue;
                }
                string[] data = { shinseiDataGridView1.Rows[i].Cells["RONRI_NAME1"].Value.ToString(), shinseiDataGridView1.Rows[i].Cells["BUTSURI_NAME"].Value.ToString() };
                if (shinseiDataGridView1.Rows[i].Cells[0].Value.Equals(true))
                {
                    string sql1 = "insert into WORD_DIC (RONRI_NAME1,BUTSURI_NAME) values ('" + data[0] + "', '" + data[1] + "')";
                    string sql2 = "delete from WORD_SHINSEI where RONRI_NAME1 = '" + data[0] + "'";
                    common.executeQuery(sql1);
                    common.executeQuery(sql2);
                }
            }
            MessageBox.Show("辞書テーブルに登録されました。");
            this.Shinsei_Load(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kyakka_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < shinseiDataGridView1.Rows.Count; i++)
            {
                if (shinseiDataGridView1.Rows[i].Cells[0].Value == null)
                {
                    continue;
                }
                string[] data = { shinseiDataGridView1.Rows[i].Cells["RONRI_NAME1"].Value.ToString(), shinseiDataGridView1.Rows[i].Cells["BUTSURI_NAME"].Value.ToString() };
                if (shinseiDataGridView1.Rows[i].Cells[0].Value.Equals(true))
                {
                    string sql = "delete from WORD_SHINSEI where RONRI_NAME1 = '" + data[0] + "'";
                    common.executeQuery(sql);
                }
            }
            this.Shinsei_Load(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.koushinRadioButton.Checked)
            {
                DispManager dispMode;
                dispMode = new DispManager(new StrategyKoushin(this.shinseiDataGridView1));
                this.shinseiDataGridView1 = dispMode.Execute();
            }
            if (this.shinkiRadioButton.Checked)
            {
                DispManager dispMode;
                dispMode = new DispManager(new StrategyShinki(this.shinseiDataGridView1));
                this.shinseiDataGridView1 = dispMode.Execute();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tojiru_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shinseiDataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn clickedColumn = this.shinseiDataGridView1.Columns[e.ColumnIndex];
            if (clickedColumn.Index == 0)
            {
                for (int i = 0; i < this.shinseiDataGridView1.RowCount; i++)
                {
                    if (this.shinseiDataGridView1[0, i].Value != null)
                    {
                        this.shinseiDataGridView1[0, i].Value = !(bool)this.shinseiDataGridView1[0, i].Value;
                    }
                    else
                    {
                        this.shinseiDataGridView1[0, i].Value = true;
                    }
                }
            }
        }
    }
}


