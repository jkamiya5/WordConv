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

namespace WordConvTool.Forms
{
    public partial class Henshu : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private static WordConvTool.CommonFunction common = new WordConvTool.CommonFunction();

        public Henshu()
        {
            InitializeComponent();
            this.Show();
            this.Activate();
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
            string dbConnectionString = ConfigurationManager.AppSettings.Get("DataSource");
            List<HenshuWordBo> wordList = new List<HenshuWordBo>();

            using (SQLiteConnection cn = new SQLiteConnection(dbConnectionString))
            {
                cn.Open();
                SQLiteCommand cmd = cn.CreateCommand();
                cmd.CommandText = "SELECT * FROM WORD_DIC where RONRI_NAME1 = '" + this.textBox1.Text + "'";

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!isContains(reader["BUTSURI_NAME"].ToString(), wordList))
                        {
                            HenshuWordBo word = new HenshuWordBo();
                            word.RONRI_NAME1 = reader["RONRI_NAME1"].ToString();
                            word.RONRI_NAME2 = reader["RONRI_NAME2"].ToString();
                            word.BUTSURI_NAME = reader["BUTSURI_NAME"].ToString();
                            word.USER_ID = reader["USER_ID"].ToString();
                            wordList.Add(word);
                        }
                    }
                }
                cn.Close();
            }

            common.addCheckBox(ref this.dataGridView1);
            common.viewSetting(ref this.dataGridView1, 20, 65);
            this.dispView(ref dataGridView1, wordList);
        }

        private void dispView(ref DataGridView dataGridView1, List<HenshuWordBo> wordList)
        {
            dataGridView1.DataSource = wordList;
            dataGridView1.Columns[0].HeaderText = "";
            dataGridView1.Columns[1].HeaderText = "論理名1";
            dataGridView1.Columns[2].HeaderText = "論理名2";
            dataGridView1.Columns[3].HeaderText = "物理名";
            dataGridView1.Columns[4].HeaderText = "ユーザーID";
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

            List<HenshuWordBo> wordList = new List<HenshuWordBo>();
            HenshuWordBo word = new HenshuWordBo();
            word.RONRI_NAME1 = this.textBox1.Text;
            word.RONRI_NAME2 = this.textBox2.Text;
            word.BUTSURI_NAME = this.textBox3.Text;
            wordList.Add(word);
            dataGridView1.DataSource = wordList;

            common.addCheckBox(ref this.dataGridView1);
            common.viewSetting(ref this.dataGridView1, 20, 65);
            this.dispView(ref dataGridView1, wordList);
        }


        private void regist_Click(object sender, EventArgs e)
        {
            using (var context = new MyContext())
            {
                UserMst user = new UserMst();
                user.USER_NAME = "ジョウジ";
                WordDic word = new WordDic();
                word.RONRI_NAME1 = this.textBox1.Text;
                word.RONRI_NAME2 = this.textBox2.Text;
                word.BUTSURI_NAME = this.textBox3.Text;
                word.User = user;
                context.WordDic.Add(word);
                context.SaveChanges();
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {

        }
    }
}
