using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordConvertTool;
using WordConvTool.Model;
using SQLite.Form;

namespace WordConvTool.Forms
{
    public partial class Henshu : Form
    {
        private static WordConvTool.CommonFunction common = new WordConvTool.CommonFunction();

        public Henshu()
        {
            InitializeComponent();
            this.Show();
            this.Activate();
        }

        public Henshu(int selectedTanIndex)
        {
            InitializeComponent();
            this.Show();
            this.Activate();
            this.tabControl1.SelectedIndex = selectedTanIndex;
        }

        private void readFile_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;   // マウスカーソルを砂時計
            Microsoft.Office.Interop.Excel.Application oExcelApp = null; // Excelオブジェクト
            Microsoft.Office.Interop.Excel.Workbook oExcelWBook = null;  // Excel Workbookオブジェクト
            try
            {
                oExcelApp = new Microsoft.Office.Interop.Excel.Application();
                oExcelApp.DisplayAlerts = false; // Excelの確認ダイアログ表示有無
                oExcelApp.Visible = false;       // Excel表示有無
                // Excelファイルをオープンする(第一パラメタ以外は省略可)
                oExcelWBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcelApp.Workbooks.Open(
                  this.textBox1.Text,      // Filename
                  Type.Missing,  // UpdateLinks
                  Type.Missing,  // ReadOnly
                  Type.Missing,  // Format
                  Type.Missing,  // Password
                  Type.Missing,  // WriteResPassword
                  Type.Missing,  // IgnoreReadOnlyRecommended
                  Type.Missing,  // Origin
                  Type.Missing,  // Delimiter
                  Type.Missing,  // Editable
                  Type.Missing,  // Notify
                  Type.Missing,  // Converter
                  Type.Missing,  // AddToMru
                  Type.Missing,  // Local
                  Type.Missing   // CorruptLoad
                ));

                Microsoft.Office.Interop.Excel._Worksheet oWSheet =
                    (Microsoft.Office.Interop.Excel._Worksheet)oExcelWBook.ActiveSheet;

                int YOMI = 1;
                int TANGO = 2;
                int rowId = 2;

                while (String.IsNullOrEmpty(oWSheet.Cells[rowId, YOMI].Value))
                {
                    string yomi = oWSheet.Cells[rowId, YOMI].Value;
                    string tango = oWSheet.Cells[rowId, TANGO].Value;

                    if (String.IsNullOrEmpty(yomi) && yomi.Length > 0)
                    {
                        string sql1 = "insert into word (yomi,tango) values('"
                            + yomi + "', '" + tango + "')";
                        common.executeQuery(sql1);
                    }

                    rowId++;
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show(
                "Excelファイルの操作に失敗しました。\n",
                System.Windows.Forms.Application.ProductName,
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
            finally
            {
                oExcelWBook.Close(Type.Missing, Type.Missing, Type.Missing);
                oExcelApp.Quit();
            }
            this.Cursor = Cursors.Default;  // マウスカーソルを戻す
            MessageBox.Show("正常に読み込みました。");
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = ofd.FileName;
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            this.searchAction(this.tanitsuDataGridView);
        }

        private void searchAction(DataGridView dataGridView)
        {
            List<HenshuWordBo> wordList = new List<HenshuWordBo>();
            using (var context = new MyContext())
            {
                IQueryable<HenshuWordBo> words = from a in context.WordDic
                                                 join b in context.UserMst on a.USER_ID equals b.USER_ID
                                                 select new HenshuWordBo
                                            {
                                                WORD_ID = a.WORD_ID,
                                                RONRI_NAME1 = a.RONRI_NAME1,
                                                BUTSURI_NAME = a.BUTSURI_NAME,
                                                USER_NAME = b.USER_NAME,
                                                CRE_DATE = a.CRE_DATE,
                                                VERSION = (int)a.VERSION
                                            };

                HenshuWordBo[] dispWords = words.Where(x => x.RONRI_NAME1.IndexOf(this.textBox1.Text) > -1).ToArray();

                foreach (var word in dispWords)
                {
                    HenshuWordBo w = new HenshuWordBo();
                    w.WORD_ID = word.WORD_ID;
                    w.RONRI_NAME1 = word.RONRI_NAME1;
                    w.BUTSURI_NAME = word.BUTSURI_NAME;
                    w.USER_NAME = word.USER_NAME;
                    w.CRE_DATE = word.CRE_DATE;
                    w.VERSION = (int)word.VERSION;
                    wordList.Add(w);
                }
            }

            this.henshuViewDispSetthing(ref dataGridView, wordList);
        }


        private bool isContains(string tango, List<HenshuWordBo> wordList)
        {
            if (wordList.Count > 0)
            {
                foreach (HenshuWordBo obj in wordList)
                {
                    if (obj.BUTSURI_NAME == tango)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        private void clearBtn_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
        }


        private void addBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.textBox1.Text) || String.IsNullOrEmpty(this.textBox3.Text))
            {
                MessageBox.Show(
                    "論理名1と物理名は必須項目です。\n",
                    "入力エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            using (var context = new MyContext())
            {
                var products = context.WordDic
                    .Where(x => x.RONRI_NAME1 == this.textBox1.Text)
                    .ToArray();

                if (products.Count() > 0)
                {
                    MessageBox.Show(
                        "既に登録されています\n",
                        "入力エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }

            List<HenshuWordBo> wordList = new List<HenshuWordBo>();
            HenshuWordBo word = new HenshuWordBo();
            word.RONRI_NAME1 = this.textBox1.Text;
            word.BUTSURI_NAME = this.textBox3.Text;
            wordList.Add(word);

            this.henshuViewDispSetthing(ref this.tanitsuDataGridView, wordList);
        }


        private void registBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.tanitsuDataGridView.Rows.Count; i++)
            {
                if (this.tanitsuDataGridView.Rows[i].Cells[0].Value == null)
                {
                    continue;
                }
                if (this.tanitsuDataGridView.Rows[i].Cells[0].Value.Equals(true))
                {
                    using (var context = new MyContext())
                    {
                        long condtion = Convert.ToInt64(this.tanitsuDataGridView.Rows[i].Cells["WORD_ID"].Value.ToString());
                        var upWord = context.WordDic
                            .Where(x => x.WORD_ID == condtion);

                        if (upWord.Count() == 1)
                        {
                            var w = context.WordDic.Single(x => x.WORD_ID == condtion);
                            w.RONRI_NAME1 = Convert.ToString(this.tanitsuDataGridView.Rows[i].Cells["RONRI_NAME1"].Value);
                            w.BUTSURI_NAME = Convert.ToString(this.tanitsuDataGridView.Rows[i].Cells["BUTSURI_NAME"].Value);
                            w.CRE_DATE = System.DateTime.Now.ToString();
                            context.SaveChanges();
                            continue;
                        }

                        UserMst user = new UserMst();
                        user.USER_NAME = "ジョウジ";
                        WordDic word = new WordDic();
                        word.RONRI_NAME1 = Convert.ToString(this.tanitsuDataGridView.Rows[i].Cells["RONRI_NAME1"].Value);
                        word.BUTSURI_NAME = Convert.ToString(this.tanitsuDataGridView.Rows[i].Cells["BUTSURI_NAME"].Value);
                        word.CRE_DATE = System.DateTime.Now.ToString();
                        word.User = user;
                        context.WordDic.Add(word);
                        context.SaveChanges();
                    }
                }
            }
            MessageBox.Show("辞書テーブルに登録・更新しました。");
            this.searchAction(this.tanitsuDataGridView);
        }


        private void delete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.tanitsuDataGridView.Rows.Count; i++)
            {
                if (this.tanitsuDataGridView.Rows[i].Cells[0].Value == null)
                {
                    continue;
                }
                if (this.tanitsuDataGridView.Rows[i].Cells[0].Value.Equals(true))
                {
                    using (var context = new MyContext())
                    {
                        long condtion = Convert.ToInt64(this.tanitsuDataGridView.Rows[i].Cells["WORD_ID"].Value.ToString());
                        var toRemoveWord = new WordDic { WORD_ID = condtion };
                        context.WordDic.Attach(toRemoveWord);
                        context.WordDic.Remove(toRemoveWord);
                        context.SaveChanges();
                    }
                }
            }
            MessageBox.Show("辞書テーブルから削除されました。");
            this.searchAction(this.tanitsuDataGridView);
        }

        private void ikkatsuRegistBtn_Click(object sender, EventArgs e)
        {
            IkkatsuRegistBtnService ikkatsuRegistService = new IkkatsuRegistBtnService();
            IkkatsuRegistBtnServiceInBo inBo = new IkkatsuRegistBtnServiceInBo();
            ikkatsuRegistService.setInBo(inBo);
            IkkatsuRegistBtnServiceOutBo outBo = ikkatsuRegistService.execute();
            MessageBox.Show("辞書テーブルに登録・更新しました。");
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex == Constant.TANITSU_TOROKU)
            {
                TanitsuTorokuService tanitsuService = new TanitsuTorokuService();
                TanitsuTorokuServiceInBo inBo = new TanitsuTorokuServiceInBo();
                tanitsuService.setInBo(inBo);
                TanitsuTorokuServiceOutBo outBo = tanitsuService.execute();
                this.henshuViewDispSetthing(ref this.ikkatsuDataGridView, outBo.henshuWordBoList);
            }
            else if (e.TabPageIndex == Constant.IKKATSU_TOROKU)
            {
                IkkatsuTorokuService ikkatsuService = new IkkatsuTorokuService();
                IkkatsuTorokuServiceInBo inBo = new IkkatsuTorokuServiceInBo();
                ikkatsuService.setInBo(inBo);
                IkkatsuTorokuServiceOutBo outBo = ikkatsuService.execute();
                this.henshuViewDispSetthing(ref this.ikkatsuDataGridView, outBo.henshuWordBoList);
            }
        }

        private void henshuViewDispSetthing(ref DataGridView dataGridView, List<HenshuWordBo> wordList)
        {
            dataGridView.DataSource = wordList;
            dataGridView.Columns["RONRI_NAME1"].HeaderText = "論理名1";
            dataGridView.Columns["BUTSURI_NAME"].HeaderText = "物理名";
            dataGridView.Columns["USER_NAME"].HeaderText = "登録ユーザー名";
            dataGridView.Columns["CRE_DATE"].HeaderText = "登録日付";
            dataGridView.Columns["WORD_ID"].Visible = false;
            dataGridView.Columns["VERSION"].Visible = false;
            dataGridView.Columns["RONRI_NAME1"].ReadOnly = true;
            dataGridView.Columns["USER_NAME"].ReadOnly = true;
            dataGridView.Columns["CRE_DATE"].ReadOnly = true;

            common.addCheckBox(ref dataGridView);
            common.viewWidthSetting(ref dataGridView, 20, 100);
        }
    }
}
