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
using SQLite.Form;

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
            this.ronrimei1TextBox.Text = text.Trim();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shinseiButton_Click(object sender, EventArgs e)
        {
            ShinseiShinseiServiceInBo shinseiServiseInBo = new ShinseiShinseiServiceInBo();
            ShinseiShinseiService shinseiService = new ShinseiShinseiService();
            shinseiServiseInBo.clipboardText = Clipboard.GetText();
            shinseiServiseInBo.ronrimei1TextBox = this.ronrimei1TextBox.Text;
            shinseiServiseInBo.ronrimei2TextBox = this.ronrimei2TextBox.Text;
            shinseiServiseInBo.butsurimeiTextBox = this.butsurimeiTextBox.Text;
            shinseiService.setInBo(shinseiServiseInBo);
            ShinseiShinseiServiceOutBo shinseiServiseOutBo = shinseiService.execute();

            if (!String.IsNullOrEmpty(shinseiServiseOutBo.errorMessage))
            {
                MessageBox.Show(shinseiServiseOutBo.errorMessage, "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Shinsei_Load(sender, e);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearButton_Click(object sender, EventArgs e)
        {
            this.ronrimei1TextBox.Clear();
            this.ronrimei2TextBox.Clear();
            this.butsurimeiTextBox.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Shinsei_Load(object sender, EventArgs e)
        {
            ShinseiInitServiceInBo initServiceInBo = new ShinseiInitServiceInBo();
            ShinseiInitService initService = new ShinseiInitService();
            initServiceInBo.clipboardText = Clipboard.GetText();
            initService.setInBo(initServiceInBo);
            ShinseiInitServiceOutBo initServiceOutBo = initService.execute();
            this.shinseiDataGridView1.DataSource = initServiceOutBo.dispShinseiList;

            shinseiDataGridView1.Columns["RONRI_NAME1"].HeaderText = "論理名1";
            shinseiDataGridView1.Columns["RONRI_NAME2"].HeaderText = "論理名2";
            shinseiDataGridView1.Columns["BUTSURI_NAME"].HeaderText = "物理名";
            shinseiDataGridView1.Columns["STATUS"].HeaderText = "ステータス";
            shinseiDataGridView1.Columns["USER_NAME"].HeaderText = "登録ユーザー名";
            shinseiDataGridView1.Columns["CRE_DATE"].HeaderText = "登録日付";
            shinseiDataGridView1.Columns["SHINSEI_ID"].Visible = false;
            shinseiDataGridView1.Columns["VERSION"].Visible = false;
            shinseiDataGridView1.Columns["RONRI_NAME1"].ReadOnly = true;
            shinseiDataGridView1.Columns["RONRI_NAME2"].ReadOnly = true;
            shinseiDataGridView1.Columns["USER_NAME"].ReadOnly = true;
            shinseiDataGridView1.Columns["CRE_DATE"].ReadOnly = true;

            common.addCheckBox(ref shinseiDataGridView1);
            common.viewWidthSetting(ref shinseiDataGridView1, 20, 100);

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

                using (var context = new MyContext())
                {
                    long condtion = Convert.ToInt64(this.shinseiDataGridView1.Rows[i].Cells["SHINSEI_ID"].Value.ToString());

                    var w = context.WordShinsei.Single(x => x.SHINSEI_ID == condtion);
                    w.CRE_DATE = System.DateTime.Now.ToString();
                    w.STATUS = 1;

                    UserMst user = new UserMst();
                    user.USER_NAME = "ジョウジ";
                    WordDic word = new WordDic();
                    word.RONRI_NAME1 = Convert.ToString(this.shinseiDataGridView1.Rows[i].Cells["RONRI_NAME1"].Value);
                    word.BUTSURI_NAME = Convert.ToString(this.shinseiDataGridView1.Rows[i].Cells["BUTSURI_NAME"].Value);
                    word.CRE_DATE = System.DateTime.Now.ToString();
                    word.User = user;
                    context.WordDic.Add(word);

                    context.SaveChanges();
                }
            }
            MessageBox.Show("承認された単語が、辞書テーブルに登録されました。");
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
            MessageBox.Show("選択された単語が却下されました。");
            this.Shinsei_Load(sender, e);
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


