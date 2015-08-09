using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordConvertTool;
using WordConvTool.Model;
using WordConverter.Form;
using WordConverter.Services;

namespace WordConvTool.Forms
{
    public partial class UserKanri : Form
    {
        private static WordConvTool.CommonFunction common = new WordConvTool.CommonFunction();
        List<int> comboValList = new List<int>();

        public UserKanri()
        {
            InitializeComponent();
        }

        private void search_Click(object sender, EventArgs e)
        {
            UserKanriSearchServiceInBo userSearchServiceInBo = new UserKanriSearchServiceInBo();
            UserKanriSearchService userSearchService = new UserKanriSearchService();
            userSearchServiceInBo.userId = this.userId.Text;
            userSearchServiceInBo.userName = this.userName.Text;
            userSearchServiceInBo.kengenSelectedIndex = this.kengen.SelectedIndex;

            userSearchService.setInBo(userSearchServiceInBo);
            UserKanriSearchServiceOutBo shinseiServiseOutBo = userSearchService.execute();
            dataGridView1.DataSource = shinseiServiseOutBo.usersList;
            this.userKanriViewSetthing(ref dataGridView1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridView1"></param>
        private void userKanriViewSetthing(ref DataGridView dataGridView1)
        {
            this.setKengenComboBox(ref dataGridView1);

            dataGridView1.Columns["USER_ID"].HeaderText = "ユーザーID";
            dataGridView1.Columns["USER_NAME"].HeaderText = "ユーザー名";
            dataGridView1.Columns["Kengen"].HeaderText = "権限";
            dataGridView1.Columns["MAIL_ID"].HeaderText = "メールID";
            dataGridView1.Columns["MAIL_ADDRESS"].HeaderText = "メールアドレス";
            dataGridView1.Columns["PASSWORD"].HeaderText = "パスワード";
            dataGridView1.Columns["SANKA_KAHI"].HeaderText = "参加可否";
            dataGridView1.Columns["DELETE_FLG"].Visible = false;
            dataGridView1.Columns["VERSION"].Visible = false;
            dataGridView1.Columns["USER_ID"].ReadOnly = true;
            dataGridView1.Columns["USER_NAME"].ReadOnly = true;
            dataGridView1.Columns["KENGEN"].ReadOnly = true;
            dataGridView1.Columns["MAIL_ID"].ReadOnly = true;
            dataGridView1.Columns["MAIL_ADDRESS"].ReadOnly = true;
            dataGridView1.Columns["PASSWORD"].ReadOnly = true;
            dataGridView1.Columns["SANKA_KAHI"].ReadOnly = true;
            dataGridView1.Columns["DELETE_FLG"].ReadOnly = true;
            dataGridView1.Columns["MAIL_ID"].ReadOnly = true;
            dataGridView1.Columns["VERSION"].ReadOnly = true;

            common.addCheckBox(ref dataGridView1);
            common.viewWidthSetting(ref dataGridView1, 20, 100);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridView1"></param>
        private void setKengenComboBox(ref DataGridView dataGridView1)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                comboValList = new List<int>();
                comboValList.Add((int)dataGridView1.Rows[i].Cells["Kengen"].Value);
            }

            Boolean isExistComboBox = false;
            foreach (Object obj in dataGridView1.Columns)
            {
                if (obj is DataGridViewComboBoxColumn)
                {
                    isExistComboBox = true;
                }
            }
            if (!isExistComboBox)
            {
                DataTable kengenTable = new DataTable("Kengen");
                kengenTable.Columns.Add("Display", typeof(string));
                kengenTable.Columns.Add("Value", typeof(int));
                kengenTable.Rows.Add("管理", 0);
                kengenTable.Rows.Add("一般", 1);
                DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
                column.DataPropertyName = dataGridView1.Columns["Kengen"].DataPropertyName;
                column.DataSource = kengenTable;
                column.ValueMember = "Value";
                column.DisplayMember = "Display";
                dataGridView1.Columns.Remove("Kengen");
                dataGridView1.Columns.Insert(2, column);
                dataGridView1.Columns[2].Name = "Kengen";

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.userName.Text)
                || String.IsNullOrEmpty(this.userId.Text)
                || this.kengen.SelectedIndex == 0)
            {
                MessageBox.Show(
                    "ユーザーID、ユーザー名、権限は必須項目です。\n",
                    "入力エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
            using (var context = new MyContext())
            {
                long condition = this.userId.Text.ToKeyType();
                var products = context.UserMst
                    .Where(x => x.USER_ID == condition)
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

            List<UserBo> userList = new List<UserBo>();
            UserBo user = new UserBo();
            user.USER_NAME = this.userName.Text;
            userList.Add(user);
            this.dataGridView1.DataSource = userList;

        }

        private void regist_Click(object sender, EventArgs e)
        {

        }

        private void delete_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView1 != null && this.dataGridView1.Rows.Count > 0)
            {
                //列のインデックスを確認する
                if (e.ColumnIndex == 0 && e.RowIndex > -1)
                {
                    this.ColumnsReadOnlyValueChange(dataGridView1);
                }
            }
        }

        private void ColumnsReadOnlyValueChange(DataGridView dataGridView1)
        {
            dataGridView1.Columns["USER_NAME"].ReadOnly = !dataGridView1.Columns["USER_NAME"].ReadOnly;
            dataGridView1.Columns["KENGEN"].ReadOnly = !dataGridView1.Columns["KENGEN"].ReadOnly;
            dataGridView1.Columns["MAIL_ID"].ReadOnly = !dataGridView1.Columns["MAIL_ID"].ReadOnly;
            dataGridView1.Columns["MAIL_ADDRESS"].ReadOnly = !dataGridView1.Columns["MAIL_ADDRESS"].ReadOnly;
            dataGridView1.Columns["PASSWORD"].ReadOnly = !dataGridView1.Columns["PASSWORD"].ReadOnly;
            dataGridView1.Columns["SANKA_KAHI"].ReadOnly = !dataGridView1.Columns["SANKA_KAHI"].ReadOnly;
            dataGridView1.Columns["MAIL_ID"].ReadOnly = !dataGridView1.Columns["MAIL_ID"].ReadOnly;
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCellAddress.X == 0 && dataGridView1.IsCurrentCellDirty)
            {
                //コミットする
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (e.RowIndex < comboValList.Count - 1)
                {
                    string val = ((KengenKbn)comboValList[e.RowIndex]).ToString();
                    e.Value = val;
                }
            }
        }
    }
}
