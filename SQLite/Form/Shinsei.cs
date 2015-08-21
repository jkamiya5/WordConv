﻿using System;
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
            this.shinseiDataGridView1.ReadOnly = true;
            this.ronrimei1TextBox.Text = text.Trim();

            if (BaseForm.UserInfo.role == Constant.IPPAN)
            {
                this.shounin.Enabled = false;
                this.kyakka.Enabled = false;
            }
            if (BaseForm.UserInfo.role == Constant.KANRI)
            {
                this.shinseiButton.Enabled = false;
                this.clearButton.Enabled = false;
            }
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

            common.addCheckBox(ref shinseiDataGridView1, 0);
            common.viewWidthSetting(ref shinseiDataGridView1, 20, 100);

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

                    WordDic word = new WordDic();
                    word.RONRI_NAME1 = Convert.ToString(this.shinseiDataGridView1.Rows[i].Cells["RONRI_NAME1"].Value);
                    word.BUTSURI_NAME = Convert.ToString(this.shinseiDataGridView1.Rows[i].Cells["BUTSURI_NAME"].Value);
                    word.CRE_DATE = System.DateTime.Now.ToString();
                    context.WordDic.Add(word);

                    context.SaveChanges();

                    upCount++;
                }
            }
            if (upCount == 0)
            {
                MessageBox.Show("申請された単語はありません。");
                return;
            }
            MessageBox.Show("選択された単語を承認しました。承認した単語が、辞書テーブルに登録されました。");
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
            if (upCount == 0)
            {
                MessageBox.Show("却下された単語はありません。");
                return;
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
            if (this.shinseiDataGridView1[0, 0].Value == null)
            {
                this.allCheckBoxValue = false;
            }

            if (clickedColumn.Index == 0)
            {
                for (int i = 0; i < this.shinseiDataGridView1.RowCount; i++)
                {
                    if (i == 0)
                    {
                        DataGridViewCell tmp = shinseiDataGridView1.CurrentCell;
                        shinseiDataGridView1.CurrentCell = shinseiDataGridView1.Rows[0].Cells[0];
                        shinseiDataGridView1.EndEdit();
                        shinseiDataGridView1[0, 0].Value = !this.allCheckBoxValue;
                        shinseiDataGridView1.CurrentCell = tmp;
                        continue;
                    }
                    if (this.shinseiDataGridView1[0, i].Value != null)
                    {
                        this.shinseiDataGridView1[0, i].Value = !this.allCheckBoxValue;
                        this.allCheckBoxValue = !this.allCheckBoxValue;
                    }
                    else
                    {
                        this.shinseiDataGridView1[0, i].Value = true;
                    }
                }
            }
        }

        private void Shinsei_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }


        private void ronrimei1TextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(this.ronrimei1TextBox.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(this.ronrimei1TextBox, "必須項目です。");
            }
        }

        private void ronrimei2TextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(this.ronrimei2TextBox.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(this.ronrimei2TextBox, "必須項目です。");
                return;
            }
            Regex regex = new Regex(@"^[あ-を]+$");
            if (!regex.IsMatch(this.ronrimei2TextBox.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(this.ronrimei2TextBox, "ひらがな以外が入力されました。");
            }
        }

        private void butsurimeiTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(this.butsurimeiTextBox.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(this.butsurimeiTextBox, "必須項目です。");
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


