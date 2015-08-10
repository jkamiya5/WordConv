using SQLite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordConvertTool;
using WordConvTool;
using WordConvTool.Model;

namespace SQLite.Form
{

    public class IkkatsuTorokuIkkatsuRegistService : IService<IkkatsuTorokuIkkatsuRegistServiceInBo, IkkatsuTorokuIkkatsuRegistServiceOutBo>
    {
        /// <summary>
        /// 
        /// </summary>
        private static CommonFunction common = new CommonFunction();
        
        /// <summary>
        /// 
        /// </summary>
        private IkkatsuTorokuIkkatsuRegistServiceInBo inBo = new IkkatsuTorokuIkkatsuRegistServiceInBo();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="InBo"></param>
        internal void setInBo(IkkatsuTorokuIkkatsuRegistServiceInBo InBo)
        {
            this.inBo = InBo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal IkkatsuTorokuIkkatsuRegistServiceOutBo execute()
        {
            IkkatsuTorokuIkkatsuRegistServiceOutBo outBo = new IkkatsuTorokuIkkatsuRegistServiceOutBo();

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


                        String butsuriName = Convert.ToString(this.inBo.ikkatsuDataGridView.Rows[i].Cells["BUTSURI_NAME"].Value);
                        butsuriName = butsuriName.ToPascalCase();

                        if (upWord.Count() == 1)
                        {
                            var w = context.WordDic.Single(x => x.WORD_ID == condtion);
                            w.RONRI_NAME1 = Convert.ToString(this.inBo.ikkatsuDataGridView.Rows[i].Cells["RONRI_NAME1"].Value);
                            w.BUTSURI_NAME = butsuriName;
                            w.CRE_DATE = System.DateTime.Now.ToString();
                            context.SaveChanges();
                            continue;
                        }

                        WordDic word = new WordDic();
                        word.RONRI_NAME1 = Convert.ToString(this.inBo.ikkatsuDataGridView.Rows[i].Cells["RONRI_NAME1"].Value);
                        word.BUTSURI_NAME = butsuriName;
                        word.CRE_DATE = System.DateTime.Now.ToString();
                        context.WordDic.Add(word);
                        context.SaveChanges();
                    }
                }
            }

            return outBo;
        }

        void IService<IkkatsuTorokuIkkatsuRegistServiceInBo, IkkatsuTorokuIkkatsuRegistServiceOutBo>.setInBo(IkkatsuTorokuIkkatsuRegistServiceInBo inBo)
        {
            throw new NotImplementedException();
        }

        IkkatsuTorokuIkkatsuRegistServiceOutBo IService<IkkatsuTorokuIkkatsuRegistServiceInBo, IkkatsuTorokuIkkatsuRegistServiceOutBo>.execute()
        {
            throw new NotImplementedException();
        }
    }
}
