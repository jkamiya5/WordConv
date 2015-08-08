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

namespace WordConvTool.Forms
{
    public partial class UserKanri : Form
    {
        private static WordConvTool.CommonFunction common = new WordConvTool.CommonFunction();

        public UserKanri()
        {
            InitializeComponent();
        }

        private void search_Click(object sender, EventArgs e)
        {
            List<UserBo> userList = new List<UserBo>();
            using (var context = new MyContext())
            {
                String condition = this.userName.Text.Trim();

                long userId = 99999;
                if (!String.IsNullOrEmpty(this.textBox1.Text))
                {
                    userId = (long)Convert.ToInt64(this.textBox1.Text);
                }

                IQueryable<UserBo> users = from a in context.UserMst
                                           where (a.USER_NAME.StartsWith(condition) 
                                                    || a.USER_ID == userId 
                                                    || a.ROLE == this.kengen.SelectedIndex)
                                           select new UserBo
                                                 {
                                                     USER_ID = a.USER_ID,
                                                     USER_NAME = a.USER_NAME,
                                                     KENGEN = ((KengenKbn)a.ROLE).ToString(),
                                                     MAIL_ADDRESS = a.MAIL_ADDRESS,
                                                     PASSWORD = a.PASSWORD,
                                                     SANKA_KAHI = ((SankaKahi)a.SANKA_KAHI).ToString(),
                                                     VERSION = a.VERSION
                                                 };

                this.dataGridView1.DataSource = users.ToList();

                dataGridView1.Columns["USER_ID"].HeaderText = "ユーザーID";
                dataGridView1.Columns["USER_NAME"].HeaderText = "ユーザー名";
                dataGridView1.Columns["KENGEN"].HeaderText = "権限";
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
        }

        private void add_Click(object sender, EventArgs e)
        {
            using (var context = new MyContext())
            {
                var products = context.UserMst
                    .Where(x => x.USER_NAME == this.userName.Text)
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
            user.KENGEN = ((KengenKbn)this.kengen.SelectedIndex).ToString();
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
    }
}
