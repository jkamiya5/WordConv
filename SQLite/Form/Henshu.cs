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
using SQLite.Models;

namespace WordConvTool.Forms
{
    public partial class Henshu : Form
    {
        /// <summary>
        /// 共通関数インクルード
        /// </summary>
        private static WordConvTool.CommonFunction common = new WordConvTool.CommonFunction();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Henshu()
        {
            InitializeComponent();
            this.Show();
            this.Activate();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="selectedTanIndex"></param>
        public Henshu(int selectedTanIndex)
        {
            InitializeComponent();
            this.Show();
            this.Activate();
            this.tabControl1.SelectedIndex = selectedTanIndex;
        }

        /// <summary>
        /// 「読み込み」アクション
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void readFile_Click(object sender, EventArgs e)
        {
            IkkatsuTorokuReadFileService readFileService = new IkkatsuTorokuReadFileService();
            IkkatsuTorokuReadFileServiceInBo readFileServiceInBo = new IkkatsuTorokuReadFileServiceInBo();
            readFileService.setInBo(readFileServiceInBo);
            IkkatsuTorokuReadFileServiceOutBo registServiceOutBo = readFileService.execute();


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
                  this.textBox4.Text,      // Filename
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

                int RONRI_NAME1 = 1;
                int BUTSURI_NAME = 2;
                int rowId = 2;

                using (var context = new MyContext())
                {
                    while (!String.IsNullOrEmpty(oWSheet.Cells[rowId, RONRI_NAME1].Value))
                    {
                        string ronriName = oWSheet.Cells[rowId, RONRI_NAME1].Value;
                        string butsuriName = oWSheet.Cells[rowId, BUTSURI_NAME].Value;

                        if (!String.IsNullOrEmpty(ronriName) && !String.IsNullOrEmpty(butsuriName))
                        {

                            var upWord = context.WordDic.Where(x => x.RONRI_NAME1 == ronriName);
                            if (upWord.Count() == 1)
                            {
                                rowId++;
                                continue;
                            }

                            UserMst user = new UserMst();
                            user.USER_NAME = "ジョウジ";
                            WordDic word = new WordDic();
                            word.RONRI_NAME1 = Convert.ToString(ronriName);
                            word.BUTSURI_NAME = Convert.ToString(butsuriName).ToPascalCase();
                            word.CRE_DATE = System.DateTime.Now.ToString();
                            word.User = user;
                            context.WordDic.Add(word);
                        }
                        rowId++;
                    }
                    context.SaveChanges();
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

        /// <summary>
        /// 「開く」アクション
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFile_Click(object sender, EventArgs e)
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.textBox4.Text = ofd.FileName;
            }
        }

        /// <summary>
        /// 検索アクション
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchBtn_Click(object sender, EventArgs e)
        {
            this.searchAction(this.tanitsuDataGridView);
        }


        /// <summary>
        /// クリアアクション
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearBtn_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
        }


        /// <summary>
        /// 追加アクション
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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



        /// <summary>
        /// 単一登録・登録アクション
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registBtn_Click(object sender, EventArgs e)
        {
            TanitsuTorokuRegistService registService = new TanitsuTorokuRegistService();
            TanitsuTorokuRegistServiceInBo registServiceInBo = new TanitsuTorokuRegistServiceInBo();
            registServiceInBo.tanitsuDataGridView = this.tanitsuDataGridView;
            registService.setInBo(registServiceInBo);
            TanitsuTorokuRegistServiceOutBo registServiceOutBo = registService.execute();
            this.searchAction(this.tanitsuDataGridView);
        }


        /// <summary>
        /// 削除アクション
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delete_Click(object sender, EventArgs e)
        {
            TanitsuTorokuDeleteService deleteService = new TanitsuTorokuDeleteService();
            TanitsuTorokuDeleteServiceInBo deleteServiceInBo = new TanitsuTorokuDeleteServiceInBo();
            deleteServiceInBo.tanitsuDataGridView = this.tanitsuDataGridView;
            deleteService.setInBo(deleteServiceInBo);
            TanitsuTorokuDeleteServiceOutBo deleteServiceOutBo = (TanitsuTorokuDeleteServiceOutBo)deleteService.execute();
            this.searchAction(this.tanitsuDataGridView);
        }

        /// <summary>
        /// 一括登録・登録アクション
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ikkatsuRegistBtn_Click(object sender, EventArgs e)
        {
            IkkatsuTorokuIkkatsuRegistService ikkatsuRegistService = new IkkatsuTorokuIkkatsuRegistService();
            IkkatsuTorokuIkkatsuRegistServiceInBo inBo = new IkkatsuTorokuIkkatsuRegistServiceInBo();
            inBo.ikkatsuDataGridView = this.ikkatsuDataGridView;
            ikkatsuRegistService.setInBo(inBo);
            IkkatsuTorokuIkkatsuRegistServiceOutBo outBo = ikkatsuRegistService.execute();
            MessageBox.Show("辞書テーブルに登録・更新しました。");
        }

        /// <summary>
        /// タブコントロール初期表示処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex == Constant.TANITSU_TOROKU)
            {
                TanitsuTorokuInitService tanitsuService = new TanitsuTorokuInitService();
                TanitsuTorokuInitServiceInBo inBo = new TanitsuTorokuInitServiceInBo();
                tanitsuService.setInBo(inBo);
                TanitsuTorokuInitServiceOutBo outBo = tanitsuService.execute();
                this.henshuViewDispSetthing(ref this.ikkatsuDataGridView, outBo.henshuWordBoList);
            }
            else if (e.TabPageIndex == Constant.IKKATSU_TOROKU)
            {
                IkkatsuTorokuInitService ikkatsuService = new IkkatsuTorokuInitService();
                IkkatsuTorokuInitServiceInBo inBo = new IkkatsuTorokuInitServiceInBo();
                inBo.clipboardText = Clipboard.GetText();
                ikkatsuService.setInBo(inBo);
                IkkatsuTorokuInitServiceOutBo outBo = ikkatsuService.execute();
                this.henshuViewDispSetthing(ref this.ikkatsuDataGridView, outBo.henshuWordBoList);
            }
        }

        /// <summary>
        /// 編集画面データグリッドビュー表示設定処理
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="wordList"></param>
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

        /// <summary>
        /// 要素重複判定メソッド
        /// </summary>
        /// <param name="tango"></param>
        /// <param name="wordList"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 検索アクションサービス
        /// </summary>
        /// <param name="dataGridView"></param>
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
    }
}
