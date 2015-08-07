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
        /// <summary>
        /// 
        /// </summary>
        private ShinseiShinseiServiceInBo inBo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inBo"></param>
        public void setInBo(ShinseiShinseiServiceInBo inBo)
        {
            this.inBo = inBo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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

            string[] data = { this.inBo.ronrimei1TextBox, this.inBo.ronrimei2TextBox, this.inBo.butsurimeiTextBox };
            DialogResult result = MessageBox.Show(message + "申請してもよろしいですか？", "申請確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
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
