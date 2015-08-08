﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordConvTool.Forms;
using WordConverter.Form;

namespace WordConvertTool
{
    public partial class BaseForm : Form
    {
        protected const int MOD_ALT = 0x0001;
        protected const int MOD_CONTROL = 0x0002;
        protected const int MOD_SHIFT = 0x0004;
        protected const int WM_HOTKEY = 0x0312;
        protected const int HOTKEY_ID = 0x0001;  // 0x0000～0xbfff 内の適当な値でよい
        protected const int HOTKEY2_ID = 0x0002;
        protected static IntPtr Handles;
        private static UserInfo userInfo;


        public static UserInfo UserInfo
        {
            get {

                return userInfo;
            }
        }

        [DllImport("user32.dll")]
        extern static int RegisterHotKey(IntPtr HWnd, int ID, int MOD_KEY, int KEY);
        [DllImport("user32.dll")]
        extern static int UnregisterHotKey(IntPtr HWnd, int ID);

        /// <summary>
        /// コンストラクタ（初期処理）
        /// </summary>
        public BaseForm()
        {
            this.InitializeComponent();
            ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;

            Login form = new Login();
            form.Show();

        }

        public BaseForm(UserInfo uInfo)
        {
            RegisterHotKey(this.Handle, HOTKEY_ID, MOD_CONTROL, (int)Keys.E);
            RegisterHotKey(this.Handle, HOTKEY2_ID, MOD_CONTROL, (int)Keys.W);
            userInfo = uInfo;
        }


        /// <summary>
        /// キーイベント検出処理
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_HOTKEY)
            {
                //一覧起動のショートカットキーが押された場合
                if ((int)m.WParam == HOTKEY_ID)
                {
                    Ichiran ichiran = new Ichiran();
                    ichiran.Show();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            Application.Exit();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseForm_Load(object sender, EventArgs e)
        {
            Hide();
        }

        private void 申請ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 編集ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 個人設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kojin form = new Kojin();
            form.Show();
        }

        private void ユーザー管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
