using SQLite.Services;
using System;
using System.Windows.Forms;
using WordConverter.Models.InBo;
using WordConverter.Models.OutBo;
using WordConvertTool;
using WordConvTool.Model;

namespace WordConverter.Services
{
    class TanitsuTorokuDeleteService : IService<TanitsuTorokuDeleteServiceInBo, TanitsuTorokuDeleteServiceOutBo>
    {
        /// <summary>
        /// 
        /// </summary>
        private TanitsuTorokuDeleteServiceInBo inBo;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inBo"></param>
        public void setInBo(TanitsuTorokuDeleteServiceInBo inBo)
        {
            this.inBo = (TanitsuTorokuDeleteServiceInBo)inBo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TanitsuTorokuDeleteServiceOutBo execute()
        {
            TanitsuTorokuDeleteServiceOutBo outBo = new TanitsuTorokuDeleteServiceOutBo();

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
                        var toRemoveWord = new WordDic { WORD_ID = condtion };
                        context.WordDic.Attach(toRemoveWord);
                        context.WordDic.Remove(toRemoveWord);
                        context.SaveChanges();
                    }
                }
            }
            MessageBox.Show("辞書テーブルから削除されました。");
            return outBo;
        }
    }
}
