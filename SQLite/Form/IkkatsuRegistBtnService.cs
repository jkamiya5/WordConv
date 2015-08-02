using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordConvertTool;
using WordConvTool.Model;

namespace SQLite.Form
{
    class IkkatsuRegistBtnService
    {
        private IkkatsuRegistBtnServiceInBo inBo = new IkkatsuRegistBtnServiceInBo();

        internal void setInBo(IkkatsuRegistBtnServiceInBo InBo)
        {
            this.inBo = InBo;
        }

        internal IkkatsuRegistBtnServiceOutBo execute()
        {
            IkkatsuRegistBtnServiceOutBo outBo = new IkkatsuRegistBtnServiceOutBo();

            for (int i = 0; i < this.inBo.ikkatsuDataGridView.Rows.Count; i++)
            {
                if (this.inBo.ikkatsuDataGridView.Rows[i].Cells[0].Value == null)
                {
                    continue;
                }
                if (this.inBo.ikkatsuDataGridView.Rows[i].Cells[0].Value.Equals(true))
                {
                    using (var context = new MyContext())
                    {
                        long condtion = Convert.ToInt64(this.inBo.ikkatsuDataGridView.Rows[i].Cells["WORD_ID"].Value.ToString());
                        var upWord = context.WordDic
                            .Where(x => x.WORD_ID == condtion);

                        if (upWord.Count() == 1)
                        {
                            var w = context.WordDic.Single(x => x.WORD_ID == condtion);
                            w.RONRI_NAME1 = Convert.ToString(this.inBo.ikkatsuDataGridView.Rows[i].Cells["RONRI_NAME1"].Value);
                            w.BUTSURI_NAME = Convert.ToString(this.inBo.ikkatsuDataGridView.Rows[i].Cells["BUTSURI_NAME"].Value);
                            w.CRE_DATE = System.DateTime.Now.ToString();
                            context.SaveChanges();
                            continue;
                        }

                        UserMst user = new UserMst();
                        user.USER_NAME = "ジョウジ";
                        WordDic word = new WordDic();
                        word.RONRI_NAME1 = Convert.ToString(this.inBo.ikkatsuDataGridView.Rows[i].Cells["RONRI_NAME1"].Value);
                        word.BUTSURI_NAME = Convert.ToString(this.inBo.ikkatsuDataGridView.Rows[i].Cells["BUTSURI_NAME"].Value);
                        word.CRE_DATE = System.DateTime.Now.ToString();
                        word.User = user;
                        context.WordDic.Add(word);
                        context.SaveChanges();
                    }
                }
            }

            return outBo;
        }
    }
}
