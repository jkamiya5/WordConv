using SQLite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordConverter.Common;
using WordConverter.Const;
using WordConverter.Services;
using WordConvertTool;

namespace WordConverter.Form
{
    public class TanitsuTorokuAddService : IService<TanitsuTorokuAddServiceInBo, TanitsuTorokuAddServiceOutBo>
    {
        private TanitsuTorokuAddServiceInBo inBo;
        private static CommonFunction common = new CommonFunction();

        public void setInBo(TanitsuTorokuAddServiceInBo inBo)
        {
            this.inBo = inBo;
        }

        public TanitsuTorokuAddServiceOutBo execute()
        {
            TanitsuTorokuAddServiceOutBo outBo = new TanitsuTorokuAddServiceOutBo();

            using (var context = new MyContext())
            {
                var products = context.WordDic
                    .Where(x => x.RONRI_NAME1 == this.inBo.ronrimei1TextBox)
                    .ToArray();

                if (products.Count() > 0)
                {
                    outBo.errorMessage = MessageConst.ERR_002;
                    return outBo;

                }
            }

            List<HenshuWordBo> wordList = new List<HenshuWordBo>();
            HenshuWordBo word = new HenshuWordBo();

            for (int i = 0; i < this.inBo.tanitsuDataGridView.Rows.Count; i++)
            {
                word = new HenshuWordBo();
                word.WORD_ID = this.inBo.tanitsuDataGridView.Rows[i].Cells["WORD_ID"].Value.ToString().ToIntType();
                word.RONRI_NAME1 = this.inBo.tanitsuDataGridView.Rows[i].Cells["RONRI_NAME1"].Value.ToString();
                word.RONRI_NAME2 = common.nullAble(this.inBo.tanitsuDataGridView.Rows[i].Cells["RONRI_NAME2"].Value);
                word.BUTSURI_NAME = this.inBo.tanitsuDataGridView.Rows[i].Cells["BUTSURI_NAME"].Value.ToString();
                word.USER_NAME = common.nullAble(this.inBo.tanitsuDataGridView.Rows[i].Cells["USER_NAME"].Value);
                word.VERSION = common.nullAbleInt(this.inBo.tanitsuDataGridView.Rows[i].Cells["VERSION"].Value);
                word.CRE_DATE = common.nullAble(this.inBo.tanitsuDataGridView.Rows[i].Cells["CRE_DATE"].Value);
                wordList.Add(word);
            }

            word = new HenshuWordBo();
            word.RONRI_NAME1 = this.inBo.ronrimei1TextBox;
            word.RONRI_NAME2 = this.inBo.ronrimei2TextBox;
            word.BUTSURI_NAME = this.inBo.butsurimeiTextBox;
            wordList.Add(word);
            outBo.wordList = wordList;

            return outBo;
        }
    }
}
