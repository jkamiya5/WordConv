using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordConvTool.Forms;
using WordConvTool.Model;
using System.Configuration;
using SQLite.Form;

namespace WordConvertTool
{
    public partial class Ichiran : Form
    {

        [DllImport("user32.dll")]
        extern static int RegisterHotKey(IntPtr HWnd, int ID, int MOD_KEY, int KEY);
        [DllImport("user32.dll")]
        extern static int UnregisterHotKey(IntPtr HWnd, int ID);

        /// <summary>
        /// 
        /// </summary>
        public Ichiran()
        {
            //初期表示処理
            InitializeComponent();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // ホットキーの登録抹消
            //UnregisterHotKey(this.Handle, HOTKEY_ID);
        }


        /// <summary>
        /// 
        /// </summary>
        public void IchiranAction()
        {
            List<IchiranWordBo> wordList = new List<IchiranWordBo>();
            IchiranWordBo word = new IchiranWordBo();

            if (!String.IsNullOrEmpty(Clipboard.GetText()))
            {
                string dbConnectionString = ConfigurationManager.AppSettings.Get("DataSource");
                string key = Clipboard.GetText();
                string nl = Environment.NewLine;
                String[] keys = key.Split(new string[] { nl }, StringSplitOptions.None);

                if (keys.Count() == 1)
                {
                    using (SQLiteConnection cn = new SQLiteConnection(dbConnectionString))
                    {
                        cn.Open();
                        SQLiteCommand cmd = cn.CreateCommand();
                        cmd.CommandText = "SELECT * FROM WORD_DIC";

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader["RONRI_NAME1"].ToString().IndexOf(key) == 0 &&
                                    !isContains(reader["BUTSURI_NAME"].ToString(), wordList))
                                {
                                    word = new IchiranWordBo();
                                    word.RONRI_NAME1 = reader["RONRI_NAME1"].ToString();
                                    word.BUTSURI_NAME = reader["BUTSURI_NAME"].ToString();
                                    wordList.Add(word);
                                }
                            }
                        }
                        cn.Close();
                    }
                }
                else
                {
                    using (SQLiteConnection cn = new SQLiteConnection(dbConnectionString))
                    {
                        cn.Open();
                        SQLiteCommand cmd = cn.CreateCommand();

                        string condition = "";
                        foreach (object obj in keys)
                        {
                            if (!String.IsNullOrEmpty((string)obj))
                            {
                                condition += "\'" + obj + "\'" + ",";
                            }
                        }
                        char[] trimChars = { ',' };
                        condition = condition.Remove(condition.Length - 1);

                        cmd.CommandText = "SELECT * FROM WORD_DIC where RONRI_NAME1 in (" + condition + ")";

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                word = new IchiranWordBo();
                                word.RONRI_NAME1 = reader["RONRI_NAME1"].ToString();
                                word.BUTSURI_NAME = reader["BUTSURI_NAME"].ToString();
                                wordList.Add(word);
                            }
                        }
                        cn.Close();
                    }
                }
            }

            if (wordList.Count == 0 || String.IsNullOrEmpty(Clipboard.GetText()))
            {
                word.RONRI_NAME1 = "-";
                word.BUTSURI_NAME = Constant.NONE_WORD;
                wordList.Add(word);
            }

            ichiranDataGridView.DataSource = wordList;
            ichiranDataGridView.Columns["RONRI_NAME1"].Width = 110;
            ichiranDataGridView.Columns["BUTSURI_NAME"].Width = 160;
            ichiranDataGridView.ReadOnly = true;

            //隠していたフォームを表示する
            this.Show();
            this.Activate();

            //透過性
            this.Opacity = 0.94;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tango"></param>
        /// <param name="wordList"></param>
        /// <returns></returns>
        private bool isContains(string tango, List<IchiranWordBo> wordList)
        {
            if (wordList.Count > 0)
            {
                foreach (IchiranWordBo obj in wordList)
                {
                    if (obj.BUTSURI_NAME == tango)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 変換候補一覧のダブルクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.setClipBordMyValue();
        }

        /// <summary>
        /// 変換候補一覧のエンターイベントイベント
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                this.setClipBordMyValue();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// クリップボードに変換候補一覧の値を設定
        /// </summary>
        private void setClipBordMyValue()
        {
            String val = "";
            foreach (DataGridViewCell c in ichiranDataGridView.SelectedCells)
            {
                if (!String.IsNullOrEmpty(c.Value.ToString()))
                {
                    val += c.Value + System.Environment.NewLine;
                }
            }
            if (val.Trim() != Constant.NONE_WORD)
            {
                this.Close();
                Clipboard.SetText(val);
            }
            else
            {
                this.Close();
                Shinsei shinsei = new Shinsei(Clipboard.GetText());
            }
        }

        //マウスのクリック位置を記憶
        private Point mousePoint;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ichiran_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.Left += e.X - mousePoint.X;
                this.Top += e.Y - mousePoint.Y;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ichiran_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                //位置を記憶する
                mousePoint = new Point(e.X, e.Y);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //右クリックのときのみ
            if (e.Button == MouseButtons.Right)
            {
                int idx = ichiranDataGridView.CurrentCell.RowIndex;
                int rowindex = e.RowIndex;
                //コンテキストメニューを表示する
                this.contextMenuStrip1.Show();
                //マウスカーソルの位置を画面座標で取得
                Point p = Control.MousePosition;
                this.contextMenuStrip1.Top = p.Y;
                this.contextMenuStrip1.Left = p.X;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 申請ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Shinsei shinsei = new Shinsei(Clipboard.GetText());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 単一登録ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Henshu henshu = new Henshu(Constant.TANITSU_TOROKU);
        }


        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.ichiranDataGridView.RowsDefaultCellStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.ichiranDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }

        private void label2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void 一括登録ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Henshu henshu = new Henshu(Constant.IKKATSU_TOROKU);
        }

        private void bo作成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IchiranBoCreateService boCreateService = new IchiranBoCreateService();
            IchiranBoCreateServiceInBo boCreateServiceInBo = new IchiranBoCreateServiceInBo();
            boCreateServiceInBo.ichiranDataGridView = this.ichiranDataGridView;
            boCreateService.setInBo(boCreateServiceInBo);
            IchiranBoCreateServiceOutBo registServiceOutBo = boCreateService.execute();
            Clipboard.SetText(registServiceOutBo.boText);
        }
    }
}
