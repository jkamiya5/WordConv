using SQLite.Services;
using System;
using System.Linq;
using System.Windows.Forms;
using WordConverter.Models.InBo;
using WordConverter.Models.OutBo;
using WordConvertTool;
using WordConvTool.Model;

namespace WordConverter.Services
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
            outBo = this.inputCheck(this.inBo);

            if (!String.IsNullOrEmpty(outBo.errorMessage))
            {
                return outBo;
            }

            string message = "";
            message += "論理名　：" + this.inBo.ronrimei1TextBox + System.Environment.NewLine;
            message += "よみがな：" + this.inBo.ronrimei2TextBox + System.Environment.NewLine;
            message += "物理名　：" + this.inBo.butsurimeiTextBox + System.Environment.NewLine + System.Environment.NewLine;
            DialogResult result = MessageBox.Show(message + "申請してもよろしいですか？", "申請確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                using (var context = new MyContext())
                {
                    WordShinsei shinsei = new WordShinsei();
                    shinsei.RONRI_NAME1 = this.inBo.ronrimei1TextBox;
                    shinsei.RONRI_NAME2 = this.inBo.ronrimei2TextBox;
                    shinsei.BUTSURI_NAME = this.inBo.butsurimeiTextBox;
                    shinsei.STATUS = 0;
                    shinsei.USER_ID = BaseForm.UserInfo.userId;
                    shinsei.CRE_DATE = System.DateTime.Now.ToString();
                    context.WordShinsei.Add(shinsei);
                    context.SaveChanges();
                }
            }
            return outBo;
        }

        private ShinseiShinseiServiceOutBo inputCheck(ShinseiShinseiServiceInBo inBo)
        {
            ShinseiShinseiServiceOutBo outBo = new ShinseiShinseiServiceOutBo();

            if (String.IsNullOrEmpty(inBo.ronrimei1TextBox)
                || String.IsNullOrEmpty(inBo.ronrimei2TextBox)
                || String.IsNullOrEmpty(inBo.butsurimeiTextBox))
            {
                outBo.errorMessage = "論理名、よみがな、物理名は必須項目です。";
                return outBo;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(inBo.ronrimei2TextBox, @"^[あ-ん]*$"))
            {
                outBo.errorMessage = "ひらがな以外が含まれています。";
                return outBo;
            }

            using (var context = new MyContext())
            {
                string condtion = inBo.ronrimei1TextBox;
                var upWord = context.WordDic
                    .Where(x => x.RONRI_NAME1 == condtion);

                if (upWord.Count() > 0)
                {
                    outBo.errorMessage = "辞書テーブルに既に存在する単語です。";
                    return outBo;
                }
            }

            using (var context = new MyContext())
            {
                string condtion = inBo.ronrimei1TextBox;
                var upWord = context.WordShinsei
                    .Where(x => x.RONRI_NAME1 == condtion && x.STATUS == 1);

                if (upWord.Count() > 0)
                {
                    outBo.errorMessage = "既に申請中の単語です。";
                    return outBo;
                }
            }

            using (var context = new MyContext())
            {
                string condtion = inBo.ronrimei1TextBox;
                var upWord = context.WordShinsei
                    .Where(x => x.RONRI_NAME1 == condtion && x.STATUS == 2);

                if (upWord.Count() > 0)
                {
                    outBo.errorMessage = "既に却下済みの単語です。";
                    return outBo;
                }
            }

            return outBo;
        }
    }
}
