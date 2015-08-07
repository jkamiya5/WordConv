using SQLite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WordConvertTool;
using WordConvTool.Model;

namespace SQLite.Form
{
    class ShinseiShinseiService : IService<ShinseiShinseiServiceInBo, ShinseiShinseiServiceOutBo>
    {
        private ShinseiShinseiServiceInBo inBo;

        public void setInBo(ShinseiShinseiServiceInBo inBo)
        {
            this.inBo = inBo;
        }

        public ShinseiShinseiServiceOutBo execute()
        {
            ShinseiShinseiServiceOutBo outBo = new ShinseiShinseiServiceOutBo();

            string message = "";
            message += "論理名　：" + this.inBo.ronrimei1TextBox + System.Environment.NewLine;
            message += "よみがな：" + this.inBo.ronrimei2TextBox + System.Environment.NewLine;
            message += "物理名　：" + this.inBo.butsurimeiTextBox + System.Environment.NewLine + System.Environment.NewLine;

            if (String.IsNullOrEmpty(this.inBo.ronrimei1TextBox)
                || String.IsNullOrEmpty(this.inBo.ronrimei2TextBox)
                || String.IsNullOrEmpty(this.inBo.butsurimeiTextBox))
            {
                outBo.errorMessage = "論理名、よみがな、物理名は必須項目です。";
                return outBo;
            }

            using (var context = new MyContext())
            {
                string condtion = this.inBo.ronrimei1TextBox;
                var upWord = context.WordDic
                    .Where(x => x.RONRI_NAME1 == condtion);

                if (upWord.Count() > 0)
                {
                    outBo.errorMessage = "論理名は、辞書テーブルに既に存在します。";
                    return outBo;
                }
            }
            
            DialogResult result = MessageBox.Show(message + "申請してもよろしいですか？", "申請確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string[] data = { this.inBo.ronrimei1TextBox, this.inBo.ronrimei2TextBox, this.inBo.butsurimeiTextBox };
                this.Insert(data);
            }
            return outBo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        private void Insert(string[] data)
        {
            using (var context = new MyContext())
            {
                UserMst user = new UserMst();
                user.USER_NAME = "ジョウジ";
                WordShinsei shinsei = new WordShinsei();
                shinsei.RONRI_NAME1 = data[0];
                shinsei.RONRI_NAME2 = data[1];
                shinsei.BUTSURI_NAME = data[2];
                shinsei.STATUS = 0;
                shinsei.User = user;
                shinsei.CRE_DATE = System.DateTime.Now.ToString();
                context.WordShinsei.Add(shinsei);
                context.SaveChanges();
            }
        }
    }
}
