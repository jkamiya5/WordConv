﻿using System;
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
using WordConverter.Common;
using WordConverter.Models.InBo;
using WordConverter.Models.OutBo;
using WordConvTool.Const;
using WordConverter.Const;

namespace WordConvTool.Forms
{
    public partial class UserKanri : Form
    {
        private static CommonFunction common = new CommonFunction();
        List<int> kengenValList = new List<int>();
        List<bool> sankaValList = new List<bool>();
        List<bool> checkValList = new List<bool>();

        /// <summary>
        /// 
        /// </summary>
        private static readonly UserKanri _instance = new UserKanri();

        /// <summary>
        /// 
        /// </summary>
        public static UserKanri Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private UserKanri()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void search_Click(object sender, EventArgs e)
        {
            this.searchAction(ref userKanriDataGridView1, this);

        }

        private void searchAction(ref DataGridView userKanriDataGridView1, UserKanri userKanri)
        {
            errorProvider1.SetError(userKanri.empId, "");
            errorProvider1.SetError(userKanri.userName, "");
            errorProvider1.SetError(userKanri.kengen, "");

            UserKanriSearchServiceInBo userSearchServiceInBo = new UserKanriSearchServiceInBo();
            UserKanriSearchService userSearchService = new UserKanriSearchService();
            userSearchServiceInBo.empId = userKanri.empId.Text;
            userSearchServiceInBo.userName = userKanri.userName.Text;
            userSearchServiceInBo.kengenSelectedIndex = userKanri.kengen.SelectedIndex;
            userSearchService.setInBo(userSearchServiceInBo);
            UserKanriSearchServiceOutBo userSearchServiceOutBo = userSearchService.execute();
            userKanriDataGridView1.DataSource = userSearchServiceOutBo.usersList;

            this.userKanriViewSetthing(ref userKanriDataGridView1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridView1"></param>
        private void userKanriViewSetthing(ref DataGridView dataGridView1)
        {
            this.setKengenComboBox(ref dataGridView1);

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                sankaValList = new List<bool>();
                sankaValList.Add((bool)dataGridView1.Rows[i].Cells["SANKA_KAHI"].Value);
            }
            common.addCheckBox(ref dataGridView1, dataGridView1.Columns["SANKA_KAHI"].Index);
            common.addCheckBox(ref dataGridView1, 0);
            common.checkBoxWidthSetting(ref dataGridView1, 20, 100);

            dataGridView1.Columns["USER_ID"].HeaderText = "ユーザーID";
            dataGridView1.Columns["EMP_ID"].HeaderText = "社員ID";
            dataGridView1.Columns["USER_NAME"].HeaderText = "ユーザー名";
            dataGridView1.Columns["KENGEN"].HeaderText = "権限";
            dataGridView1.Columns["MAIL_ID"].HeaderText = "メールID";
            dataGridView1.Columns["MAIL_ADDRESS"].HeaderText = "メールアドレス";
            dataGridView1.Columns["PASSWORD"].HeaderText = "パスワード";
            dataGridView1.Columns["SANKA_KAHI"].HeaderText = "参加可否";
            dataGridView1.Columns["CRE_DATE"].HeaderText = "更新日付";
            dataGridView1.Columns["USER_ID"].Visible = false;
            dataGridView1.Columns["DELETE_FLG"].Visible = false;
            dataGridView1.Columns["VERSION"].Visible = false;
            dataGridView1.Columns["EMP_ID"].ReadOnly = true;
            dataGridView1.Columns["USER_NAME"].ReadOnly = true;
            dataGridView1.Columns["KENGEN"].ReadOnly = true;
            dataGridView1.Columns["MAIL_ID"].ReadOnly = true;
            dataGridView1.Columns["MAIL_ADDRESS"].ReadOnly = true;
            dataGridView1.Columns["PASSWORD"].ReadOnly = true;
            dataGridView1.Columns["SANKA_KAHI"].ReadOnly = true;
            dataGridView1.Columns["DELETE_FLG"].ReadOnly = true;
            dataGridView1.Columns["VERSION"].ReadOnly = true;
            dataGridView1.Columns["CRE_DATE"].ReadOnly = true;
            dataGridView1.Columns["MAIL_ADDRESS"].Width = 150;
            dataGridView1.Columns["KENGEN"].Width = 70;
            dataGridView1.Columns["SANKA_KAHI"].Width = 70;
            dataGridView1.Columns["CRE_DATE"].Width = 110;
            dataGridView1.Columns["EMP_ID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["USER_NAME"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["KENGEN"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["MAIL_ID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["MAIL_ADDRESS"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["PASSWORD"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["SANKA_KAHI"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["CRE_DATE"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["USER_NAME"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridView1"></param>
        private void setKengenComboBox(ref DataGridView dataGridView1)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                kengenValList = new List<int>();
                kengenValList.Add((int)dataGridView1.Rows[i].Cells["Kengen"].Value);
            }
            bool isExistComboBox = false;
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
                int index = dataGridView1.Columns["Kengen"].Index;
                dataGridView1.Columns.Remove("Kengen");
                dataGridView1.Columns.Insert(index, column);
                dataGridView1.Columns[index].Name = "Kengen";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_Click(object sender, EventArgs e)
        {
            bool isNgRequired = false;
            if (String.IsNullOrEmpty(this.empId.Text))
            {
                errorProvider1.SetError(this.empId, MessageConst.ERR_001);
                isNgRequired = true;
            }
            if (String.IsNullOrEmpty(this.userName.Text))
            {
                errorProvider1.SetError(this.userName, MessageConst.ERR_001);
                isNgRequired = true;
            }
            if (String.IsNullOrEmpty(this.kengen.Text) || this.kengen.Text.ToIntType() == 2)
            {
                errorProvider1.SetError(this.kengen, MessageConst.ERR_001);
                isNgRequired = true;
            }
            if (isNgRequired)
            {
                return;
            }

            checkValList = new List<bool>();
            for (int i = 0; i < this.userKanriDataGridView1.Rows.Count; i++)
            {
                if (this.userKanriDataGridView1.Rows[i].Cells[0].Value != null &&
                    (bool)this.userKanriDataGridView1.Rows[i].Cells[0].Value != false)
                {
                    checkValList.Add((bool)this.userKanriDataGridView1.Rows[i].Cells[0].Value);
                    continue;
                }
                checkValList.Add(false);
            }

            UserKanriAddServiceInBo userAddServiceInBo = new UserKanriAddServiceInBo();
            userAddServiceInBo.empId = this.empId.Text.ToString();
            userAddServiceInBo.userName = this.userName.Text.ToString();
            userAddServiceInBo.kengenSelectedIndex = this.kengen.SelectedIndex;
            userAddServiceInBo.userKanriDataGridView1 = this.userKanriDataGridView1;
            UserKanriAddService userAddService = new UserKanriAddService();
            userAddService.setInBo(userAddServiceInBo);
            UserKanriAddServiceOutBo shinseiServiseOutBo = userAddService.execute();

            if (!String.IsNullOrEmpty(shinseiServiseOutBo.errorMessage))
            {
                MessageBox.Show(
                    shinseiServiseOutBo.errorMessage,
                    "入力エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
            this.userKanriDataGridView1.DataSource = shinseiServiseOutBo.userList;
            this.userKanriViewSetthing(ref this.userKanriDataGridView1);
            this.setCheckValList(ref this.userKanriDataGridView1);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridView"></param>
        private void setCheckValList(ref DataGridView dataGridView)
        {
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (dataGridView.Rows[i].Cells["EMP_ID"].Value.ToString().ToIntType()
                    != this.empId.Text.ToString().ToIntType())
                {
                    dataGridView.Rows[i].Cells[0].Value = checkValList[i];
                    continue;
                }
                dataGridView.Rows[i].Cells[0].Value = true;
                break;
            }
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (dataGridView.Rows[i].Cells[0].Value != null &&
                    (bool)dataGridView.Rows[i].Cells[0].Value == true)
                {
                    dataGridView.Rows[i].Cells["USER_NAME"].ReadOnly = false;
                    dataGridView.Rows[i].Cells["KENGEN"].ReadOnly = false;
                    dataGridView.Rows[i].Cells["MAIL_ID"].ReadOnly = false;
                    dataGridView.Rows[i].Cells["MAIL_ADDRESS"].ReadOnly = false;
                    dataGridView.Rows[i].Cells["PASSWORD"].ReadOnly = false;
                    dataGridView.Rows[i].Cells["SANKA_KAHI"].ReadOnly = false;
                    dataGridView.Rows[i].DefaultCellStyle.BackColor = Constant.CHECK_BOX_ON_COLOR;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void regist_Click(object sender, EventArgs e)
        {
            UserKanriRegistServiceInBo userRegistServiceInBo = new UserKanriRegistServiceInBo();
            userRegistServiceInBo.empId = this.empId.Text.ToString();
            userRegistServiceInBo.userName = this.userName.Text.ToString();
            userRegistServiceInBo.kengenSelectedIndex = this.kengen.SelectedIndex;
            userRegistServiceInBo.userKanriDataGridView1 = this.userKanriDataGridView1;
            UserKanriRegistService userRegistService = new UserKanriRegistService();
            userRegistService.setInBo(userRegistServiceInBo);
            UserKanriRegistServiceOutBo userRegistServiceOutBo = userRegistService.execute();

            if (!String.IsNullOrEmpty(userRegistServiceOutBo.errorMessage))
            {
                MessageBox.Show(
                    userRegistServiceOutBo.errorMessage,
                    "入力エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show(MessageConst.CONF_004);
            this.searchAction(ref userKanriDataGridView1, this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delete_Click(object sender, EventArgs e)
        {
            bool isExistCheck = false;
            for (int i = 0; i < this.userKanriDataGridView1.Rows.Count; i++)
            {
                if (this.userKanriDataGridView1.Rows[i].Cells[0].Value == null
                    || (bool)this.userKanriDataGridView1.Rows[i].Cells[0].Value == false)
                {
                    continue;
                }
                using (var context = new MyContext())
                {
                    long condtion = Convert.ToInt64(this.userKanriDataGridView1.Rows[i].Cells["USER_ID"].Value.ToString());
                    var u = context.UserMst.Single(x => x.USER_ID == condtion);
                    u.DELETE_FLG = 1;
                    u.CRE_DATE = System.DateTime.Now.ToString();
                    context.SaveChanges();
                }
                isExistCheck = true;
            }
            if (!isExistCheck)
            {
                MessageBox.Show(
                    MessageConst.ERR_005,
                    "入力エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
            MessageBox.Show(MessageConst.CONF_005);
            this.searchAction(ref userKanriDataGridView1, this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this.userKanriDataGridView1 != null && this.userKanriDataGridView1.Rows.Count > 0)
            {
                //列のインデックスを確認する
                if (e.ColumnIndex == 0 && e.RowIndex > -1)
                {
                    this.columnsReadOnlyValueChange(ref this.userKanriDataGridView1, e.RowIndex);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridView1"></param>
        /// <param name="rowIndex"></param>
        private void columnsReadOnlyValueChange(ref DataGridView dataGridView1, int rowIndex)
        {
            dataGridView1.Rows[rowIndex].Cells["USER_NAME"].ReadOnly = !dataGridView1.Rows[rowIndex].Cells["USER_NAME"].ReadOnly;
            dataGridView1.Rows[rowIndex].Cells["KENGEN"].ReadOnly = !dataGridView1.Rows[rowIndex].Cells["KENGEN"].ReadOnly;
            dataGridView1.Rows[rowIndex].Cells["MAIL_ID"].ReadOnly = !dataGridView1.Rows[rowIndex].Cells["MAIL_ID"].ReadOnly;
            dataGridView1.Rows[rowIndex].Cells["MAIL_ADDRESS"].ReadOnly = !dataGridView1.Rows[rowIndex].Cells["MAIL_ADDRESS"].ReadOnly;
            dataGridView1.Rows[rowIndex].Cells["PASSWORD"].ReadOnly = !dataGridView1.Rows[rowIndex].Cells["PASSWORD"].ReadOnly;
            dataGridView1.Rows[rowIndex].Cells["SANKA_KAHI"].ReadOnly = !dataGridView1.Rows[rowIndex].Cells["SANKA_KAHI"].ReadOnly;
            dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = common.switchRowBackColor(dataGridView1.Rows[rowIndex]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (userKanriDataGridView1.CurrentCellAddress.X == 0 && userKanriDataGridView1.IsCurrentCellDirty)
            {
                //コミットする
                userKanriDataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (e.RowIndex < kengenValList.Count - 1)
                {
                    string val = ((KengenKbn)kengenValList[e.RowIndex]).ToString();
                    e.Value = val;
                }
            }
            if (e.ColumnIndex == 4)
            {
                if (e.RowIndex < sankaValList.Count - 1)
                {
                    bool val = (bool)sankaValList[e.RowIndex];
                    e.Value = val;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserKanri_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void empId_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.empId, "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userName_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.userName, "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kengen_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.kengen, "");
        }

        private void clear_Click(object sender, EventArgs e)
        {
            this.empId.Text = "";
            this.userName.Text = "";
            this.kengen.Text = "";
        }
    }
}
