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
using WordConverter.Common;
using WordConverter.Services;
using WordConverter.Models.OutBo;
using WordConverter.Models.InBo;
using System.Text.RegularExpressions;
using WordConvTool.Const;
using WordConverter.Const;

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
        private static CommonFunction common = new CommonFunction();
        public string kensakuWord { get; set; }
        public bool allCheckBoxValue { get; set; }


        private static readonly Shinsei _instance = new Shinsei();
        public static Shinsei Instance
        {
            get
            {
                return _instance;
            }
        }

        private Shinsei()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public void moveShinsei(string text)
        {
            this.ronrimei1TextBox.Text = text.Trim();
            if (BaseForm.UserInfo.kengen == Constant.IPPAN)
            {
                this.shounin.Enabled = false;
                this.kyakka.Enabled = false;
            }
            if (BaseForm.UserInfo.kengen == Constant.KANRI)
            {
                this.shinseiButton.Enabled = false;
                this.clearButton.Enabled = false;
                this.ronrimei1TextBox.Enabled = false;
                this.ronrimei2TextBox.Enabled = false;
                this.butsurimeiTextBox.Enabled = false;
                errorProvider1.SetError(this.ronrimei1TextBox, "");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shinseiButton_Click(object sender, EventArgs e)
        {
            bool isNgRequired = false;
            if (String.IsNullOrEmpty(this.ronrimei1TextBox.Text))
            {
                errorProvider1.SetError(this.ronrimei1TextBox, MessageConst.ERR_001);
                isNgRequired = true;
            }
            if (String.IsNullOrEmpty(this.ronrimei2TextBox.Text))
            {
                errorProvider1.SetError(this.ronrimei2TextBox, MessageConst.ERR_001);
                isNgRequired = true;
            }
            if (String.IsNullOrEmpty(this.butsurimeiTextBox.Text))
            {
                errorProvider1.SetError(this.butsurimeiTextBox, MessageConst.ERR_001);
                isNgRequired = true;
            }
            if (isNgRequired)
            {
                return;
            }

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
                MessageBox.Show(shinseiServiseOutBo.errorMessage, MessageConst.ERR_003, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            shinseiDataGridView1.Columns["BUTSURI_NAME"].ReadOnly = true;
            shinseiDataGridView1.Columns["STATUS"].ReadOnly = true;
            shinseiDataGridView1.Columns["USER_NAME"].ReadOnly = true;
            shinseiDataGridView1.Columns["CRE_DATE"].ReadOnly = true;

            common.addCheckBox(ref shinseiDataGridView1, 0);
            common.checkBoxWidthSetting(ref shinseiDataGridView1, 20, 100);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shounin_Click(object sender, EventArgs e)
        {
            int upCount = 0;

            for (int i = 0; i < shinseiDataGridView1.Rows.Count; i++)
            {
                if (shinseiDataGridView1.Rows[i].Cells[0].Value == null
                    || (bool)shinseiDataGridView1.Rows[i].Cells[0].Value == false)
                {
                    continue;
                }

                using (var context = new MyContext())
                {
                    long condtion = Convert.ToInt64(this.shinseiDataGridView1.Rows[i].Cells["SHINSEI_ID"].Value.ToString());

                    var w = context.WordShinsei.Single(x => x.SHINSEI_ID == condtion);
                    w.CRE_DATE = System.DateTime.Now.ToString();
                    w.STATUS = 1;

                    WordDic word = new WordDic();
                    word.RONRI_NAME1 = Convert.ToString(this.shinseiDataGridView1.Rows[i].Cells["RONRI_NAME1"].Value);
                    word.RONRI_NAME2 = Convert.ToString(this.shinseiDataGridView1.Rows[i].Cells["RONRI_NAME2"].Value);
                    word.BUTSURI_NAME = Convert.ToString(this.shinseiDataGridView1.Rows[i].Cells["BUTSURI_NAME"].Value);
                    word.USER_ID = BaseForm.UserInfo.userId;
                    word.CRE_DATE = System.DateTime.Now.ToString();
                    context.WordDic.Add(word);

                    context.SaveChanges();

                    upCount++;
                }
            }
            if (upCount == 0)
            {
                MessageBox.Show(MessageConst.ERR_004);
                return;
            }
            MessageBox.Show(MessageConst.CONF_002);
            this.Shinsei_Load(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kyakka_Click(object sender, EventArgs e)
        {
            int upCount = 0;

            for (int i = 0; i < shinseiDataGridView1.Rows.Count; i++)
            {
                if (shinseiDataGridView1.Rows[i].Cells[0].Value == null
                    || (bool)shinseiDataGridView1.Rows[i].Cells[0].Value == false)
                {
                    continue;
                }
                using (var context = new MyContext())
                {
                    long condtion = Convert.ToInt64(this.shinseiDataGridView1.Rows[i].Cells["SHINSEI_ID"].Value.ToString());
                    var w = context.WordShinsei.Single(x => x.SHINSEI_ID == condtion);
                    w.CRE_DATE = System.DateTime.Now.ToString();
                    w.STATUS = 2;
                    context.SaveChanges();
                }
                upCount++;
            }
            if (upCount == 0)
            {
                MessageBox.Show(MessageConst.ERR_004);
                return;
            }
            MessageBox.Show(MessageConst.CONF_003);
            this.Shinsei_Load(sender, e);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shinseiDataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //DataGridViewColumn clickedColumn = this.shinseiDataGridView1.Columns[e.ColumnIndex];
            //if (this.shinseiDataGridView1[0, 0].Value == null)
            //{
            //    this.allCheckBoxValue = false;
            //}

            //if (clickedColumn.Index == 0)
            //{
            //    for (int i = 0; i < this.shinseiDataGridView1.RowCount; i++)
            //    {
            //        if (i == 0)
            //        {
            //            DataGridViewCell tmp = shinseiDataGridView1.CurrentCell;
            //            shinseiDataGridView1.CurrentCell = shinseiDataGridView1.Rows[0].Cells[0];
            //            shinseiDataGridView1.EndEdit();
            //            shinseiDataGridView1[0, 0].Value = !this.allCheckBoxValue;
            //            shinseiDataGridView1.CurrentCell = tmp;
            //            continue;
            //        }
            //        if (this.shinseiDataGridView1[0, i].Value != null)
            //        {
            //            this.shinseiDataGridView1[0, i].Value = !this.allCheckBoxValue;
            //            this.allCheckBoxValue = !this.allCheckBoxValue;
            //        }
            //        else
            //        {
            //            this.shinseiDataGridView1[0, i].Value = true;
            //        }
            //    }
            //}
        }

        private void Shinsei_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void ronrimei2TextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.ronrimei2TextBox.Text)
                && !Regex.IsMatch(this.ronrimei2TextBox.Text, @"^\p{IsHiragana}*$"))
            {
                e.Cancel = true;
                errorProvider1.SetError(this.ronrimei2TextBox, "ひらがな以外が入力されました。");
            }
        }

        private void ronrimei1TextBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.ronrimei1TextBox, "");
        }

        private void ronrimei2TextBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.ronrimei2TextBox, "");

        }

        private void butsurimeiTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.butsurimeiTextBox, "");
        }
    }
}


