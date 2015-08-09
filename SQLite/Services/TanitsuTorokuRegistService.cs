using SQLite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WordConvertTool;
using WordConvTool.Model;
using WordConvTool.Service;

namespace SQLite.Form
{
    public class TanitsuTorokuRegistService : IService<TanitsuTorokuRegistServiceInBo, TanitsuTorokuRegistServiceOutBo>
    {
        /// <summary>
        /// 
        /// </summary>
        public TanitsuTorokuRegistServiceInBo inBo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inBo"></param>
        public void setInBo(TanitsuTorokuRegistServiceInBo inBo)
        {
            this.inBo = inBo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TanitsuTorokuRegistServiceOutBo execute()
        {
            TanitsuTorokuRegistServiceOutBo outBo = new TanitsuTorokuRegistServiceOutBo();

            for (int i = 0; i < this.inBo.tanitsuDataGridView.Rows.Count; i++)
            {
                if (this.inBo.tanitsuDataGridView.Rows[i].Cells[0].Value == null)
                {
                    continue;
                }
                if (this.inBo.tanitsuDataGridView.Rows[i].Cells[0].Value.Equals(true))
                {
                    using (var context = new MyContext())
                    {
                        long condtion = Convert.ToInt64(this.inBo.tanitsuDataGridView.Rows[i].Cells["WORD_ID"].Value.ToString());
                        var upWord = context.WordDic
                            .Where(x => x.WORD_ID == condtion);

                        if (upWord.Count() == 1)
                        {
                            var w = context.WordDic.Single(x => x.WORD_ID == condtion);
                            w.RONRI_NAME1 = Convert.ToString(this.inBo.tanitsuDataGridView.Rows[i].Cells["RONRI_NAME1"].Value);
                            w.BUTSURI_NAME = Convert.ToString(this.inBo.tanitsuDataGridView.Rows[i].Cells["BUTSURI_NAME"].Value);
                            w.CRE_DATE = System.DateTime.Now.ToString();
                            context.SaveChanges();
                            continue;
                        }

                        //UserMst user = new UserMst();
                        //user.USER_NAME = "ジョウジ";
                        WordDic word = new WordDic();
                        word.RONRI_NAME1 = Convert.ToString(this.inBo.tanitsuDataGridView.Rows[i].Cells["RONRI_NAME1"].Value);
                        word.BUTSURI_NAME = Convert.ToString(this.inBo.tanitsuDataGridView.Rows[i].Cells["BUTSURI_NAME"].Value);
                        word.CRE_DATE = System.DateTime.Now.ToString();
                        //word.User = user;
                        word.USER_ID = BaseForm.UserInfo.userId;
                        context.WordDic.Add(word);
                        context.SaveChanges();
                    }
                }
            }
            return outBo;
        }
    }
}
