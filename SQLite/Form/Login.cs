﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordConverter.Form;
using WordConvTool.Model;

namespace WordConvertTool
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ログインボタンクリックアクション
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginBtn_Click(object sender, EventArgs e)
        {
            using (var context = new MyContext())
            {
                long condtion = Convert.ToInt64(this.UserId.Text);
                var w = context.UserMst.Where(x => x.USER_ID == condtion).ToArray();

                if (w.Count() == 0)
                {
                    MessageBox.Show(
                        "ユーザーIDが存在しません。\n",
                        System.Windows.Forms.Application.ProductName,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
                if (w.Count() == 1)
                {
                    WordConverter.Settings1.Default.UserId = this.UserId.Text;
                    WordConverter.Settings1.Default.DataSource = this.dataSourcePath.Text;
                    WordConverter.Settings1.Default.Save();

                    this.Close();

                    UserInfoBo userInfo = new UserInfoBo();
                    userInfo.role = w[0].ROLE;
                    userInfo.userId = w[0].USER_ID;

                    BaseForm form = new BaseForm(userInfo);

                    return;
                }
            }
        }

        /// <summary>
        /// 初期表示アクション
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Load(object sender, EventArgs e)
        {
            this.dataSourcePath.Text = WordConverter.Settings1.Default.DataSource;
            this.UserId.Text = WordConverter.Settings1.Default.UserId;

        }

        /// <summary>
        /// 参照アクション
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFile_Click(object sender, EventArgs e)
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Path.GetDirectoryName(this.dataSourcePath.Text);
            ofd.FileName = Path.GetFileName(this.dataSourcePath.Text);

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.dataSourcePath.Text = ofd.FileName;
            }
        }
    }
}
